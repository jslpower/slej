using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using EyouSoft.Common;
using EyouSoft.Model.XianLuStructure;
using System.Collections.Generic;
using EyouSoft.Model.Enum;
using EyouSoft.Model.Enum.XianLuStructure;

namespace EyouSoft.Web.WebMaster
{
    public partial class OrderEdit : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected string Strsex = string.Empty;
        protected string StrOrderStatus = string.Empty;
        protected string StrPayStatus = string.Empty;
        protected string Strzhengjiantype = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string dotype = Utils.GetQueryStringValue("dotype");
            string type = Utils.GetQueryStringValue("type");
            //获得操作ID
            string id = Utils.GetQueryStringValue("id");
            if (type == "save" && dotype == "update")
            {
                Response.Clear();
                Response.Write(PageSave(dotype, id));
                Response.End();
            }
            if (!IsPostBack)
            {
                PageInit(dotype, id);
            }
        }
        private void PageInit(string dotype, string id)
        {
            if (dotype == "update")
            {
                EyouSoft.BLL.XianLuStructure.BOrder bll = new EyouSoft.BLL.XianLuStructure.BOrder();
                MOrderInfo model = bll.GetInfo(id);
                if (model != null)
                {
                    this.txtadultcount.Text = model.ChengRenShu.ToString();
                    this.txtadultprice.Text = model.JSJCR.ToString("f2");
                    this.txtchildcount.Text = model.ErTongShu.ToString();
                    this.txtchildprice.Text = model.JSJER.ToString("f2");
                    this.txtContactMobile.Text = model.LxrTelephone;
                    this.txtContactName.Text = model.LxrName;
                    this.txtHetongMoney.Text = model.JinE.ToString("f2");
                    this.txtleavedate.Text = model.LDate.ToString("yyyy-MM-dd");
                    this.txtorderremark.Text = model.XiaDanBeiZhu;
                    this.txtZhengjiancode.Text = model.LxrZhengJianCode;
                    this.lbordercode.Text = model.OrderCode;
                    this.lborderdate.Text = model.IssueTime.ToString("yyyy-MM-dd");
                    this.hidcardtype.Value = ((int)model.LxrZhengJianType).ToString();
                    this.hidorderstatus.Value = ((int)model.Status).ToString();
                    this.hidsex.Value = ((int)model.LxrGender).ToString();
                    this.lbpaystatus.Text = model.FuKuanStatus.ToString();
                    BindSex(model.LxrGender);
                    BindPayStatus(model.FuKuanStatus);
                    BindOrderStatus(model.Status);
                    Bindzhengjiantype(model.LxrZhengJianType);
                }
            }
        }

        #region 绑定下拉框
        private void BindSex(Gender sex)
        {
            Strsex = EyouSoft.Common.Utils.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(Gender)), ((int)sex).ToString(), false);
        }
        private void BindPayStatus(FuKuanStatus paystatus)
        {
            StrPayStatus = EyouSoft.Common.Utils.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(FuKuanStatus)), ((int)paystatus).ToString(), false);
        }
        private void BindOrderStatus(OrderStatus orderstatus)
        {
            StrOrderStatus = EyouSoft.Common.Utils.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(OrderStatus)), ((int)orderstatus).ToString(), false);
        }
        private void Bindzhengjiantype(CardType cartype)
        {
            Strzhengjiantype = EyouSoft.Common.Utils.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(CardType)), ((int)cartype).ToString(), false);
        }
        #endregion


        private string PageSave(string dotype, string id)
        {
            string msg = string.Empty;
            string leavedate = Utils.GetFormValue(this.txtleavedate.UniqueID);
            string adultcount = Utils.GetFormValue(this.txtadultcount.UniqueID);
            string childcount = Utils.GetFormValue(this.txtchildcount.UniqueID);
            decimal adultprice = Utils.GetDecimal(Utils.GetFormValue(this.txtadultprice.UniqueID));
            decimal childprice = Utils.GetDecimal(Utils.GetFormValue(this.txtchildprice.UniqueID));
            string contactname = Utils.GetFormValue(this.txtContactName.UniqueID);
            string contacttel = Utils.GetFormValue(this.txtContactMobile.UniqueID);
            string carcode = Utils.GetFormValue(this.txtZhengjiancode.UniqueID);
            string sex = Utils.GetFormValue(this.hidsex.UniqueID);
            string cardtype = Utils.GetFormValue(this.hidcardtype.UniqueID);
            string orderstatus = Utils.GetFormValue(this.hidorderstatus.UniqueID);
            decimal hetongmoney = Utils.GetDecimal(Utils.GetFormValue(this.txtHetongMoney.UniqueID));
            string remark = Utils.GetFormValue(this.txtorderremark.UniqueID);
            if (dotype == "update" && !string.IsNullOrEmpty(id))
            {
                EyouSoft.BLL.XianLuStructure.BOrder bll = new EyouSoft.BLL.XianLuStructure.BOrder();
                MOrderInfo model = new MOrderInfo();
                model.ChengRenShu = Utils.GetInt(adultcount);
                model.ErTongShu = Utils.GetInt(childcount);
                //model.Historys
                model.JinE = hetongmoney;
                model.JSJCR = adultprice;
                model.JSJER = childprice;
                model.LDate = Utils.GetDateTime(leavedate);
                model.LxrGender = (Gender)Utils.GetInt(sex);
                model.LxrName = contactname;
                model.LxrTelephone = contacttel;
                model.LxrZhengJianCode = carcode;
                model.LxrZhengJianType = (CardType)Utils.GetInt(cardtype);
                model.OperatorId = UserInfo.UserId.ToString();
                model.OrderId = id;
                model.XiaDanBeiZhu = remark;
                model.YouKes = OrderCustomer1.GetCustomerList();
                //model.TourId=

                int result = 0;
                int orderResult = 0;

                #region 订单变更记录信息
                MOrderHistoryInfo modelhistory = new MOrderHistoryInfo();
                modelhistory.LeiXing = OrderHistoryLeiXing.设置状态;
                modelhistory.IssueTime = DateTime.Now;
                //modelhistory.OperatorId =
                modelhistory.OperatorLeiXing = OperatorLeiXing.管理;
                modelhistory.OperatorName = UserInfo.Username;
                modelhistory.OrderId = id;
                modelhistory.Status = (OrderStatus)Utils.GetInt(orderstatus);
                orderResult = bll.SheZhiOrderStatus(id, (OrderStatus)Utils.GetInt(orderstatus), modelhistory);
                #endregion

                #region 修改操作
                result = bll.Update(model);
                #endregion

                if (result == 1 && orderResult == 1)
                {
                    msg = Utils.AjaxReturnJson("1", "修改成功!");
                }
                else
                {
                    msg = Utils.AjaxReturnJson("0", "修改失败!");
                }
            }
            else
            {
                msg = Utils.AjaxReturnJson("0", "修改失败!");
            }
            return msg;
        }
    }
}
