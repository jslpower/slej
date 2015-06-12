using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster.ShangCheng
{
    public partial class OrderEdit : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected string getOpt = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("save") == "save") BaoCun();
            initPage();
        }
        void initPage()
        {

            getOpt = EyouSoft.Common.Utils.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.XianLuStructure.OrderStatus)), EyouSoft.Common.Utils.GetQueryStringValue("ddlType"), true, "-1", "请选择");

            var model = new EyouSoft.BLL.MallStructure.BShangChengDingDan().GetModel(Utils.GetQueryStringValue("id"));
            if (model != null)
            {
                lblChanPinMingCheng.Text = model.ProductName;
                lblDingDanHao.Text = model.OrderCode;
                lblXiaDanRen.Text = model.ContactName;
                lblXiaDanRiQi.Text = model.IssueTime.ToString("yyyy-MM-dd");
                lblDingDanJinE.Text = model.OrderPrice.ToString("C2");
                lblLianXiDianHua.Text = model.ContactPhone;
                lblChanPinShuLiang.Text = model.ProductNum.ToString();
                lblBeiZhu.Text = model.Remark;
                lblZhiFuZhuangTai.Text = (int)model.PayState == 0 ? EyouSoft.Model.Enum.PaymentState.未支付.ToString() : model.OrderState.ToString();
                lblDingDanZhuangTai.Text = model.OrderState.ToString();
                if (model.Address != null) lblShouHuoDiZhi.Text = string.Format("{0}{1}{2}{3}", model.Address.ProvinceName, model.Address.CityName, model.Address.DistrictName, model.Address.AddressInfo);
                // initDDLStr(((int)model.OrderState).ToString());
            }
            //else
            //{
            //    initDDLStr("");
            //}
        }
        /// <summary>
        /// 保存
        /// </summary>
        void BaoCun()
        {
            var model = new EyouSoft.Model.MallStructure.MShangChengDingDan();

            //model.OrderState = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)Utils.GetInt(Utils.GetFormValue("ddlDingDanZhuangTai"));
            //model.ProductNum = Utils.GetInt(Utils.GetFormValue(txtChanPinShuLiang.UniqueID));
            //model.OrderPrice = Utils.GetDecimal(Utils.GetFormValue(txtDingDanJinE.UniqueID));
            //model.ContactPhone = Utils.GetFormValue(txtLianXiDianHua.UniqueID);
            //model.Remark = Utils.GetFormValue(txtDingDanBeiZhu.UniqueID);
            //model.OrderID = Utils.GetQueryStringValue("id");

            int result = 0;
            result = new EyouSoft.BLL.MallStructure.BShangChengDingDan().Update(model);
            Response.Clear();
            Response.Write(UtilsCommons.AjaxReturnJson(result == 1 ? "1" : "0", result == 1 ? "修改成功" : "修改失败"));
            Response.End();

        }
        /// <summary>
        /// 初始化状态
        /// </summary>
        /// <param name="strSelect"></param>
        void initDDLStr(string strSelect)
        {
            getOpt = EyouSoft.Common.Utils.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.XianLuStructure.OrderStatus)), strSelect, true, "-1", "请选择");
        }
    }
}
