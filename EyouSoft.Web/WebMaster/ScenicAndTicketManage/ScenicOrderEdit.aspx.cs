using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;
using EyouSoft.Model.ScenicStructure.WebModel;

namespace EyouSoft.Web.WebMaster.ScenicAndTicketManage
{
    /// <summary>
    /// 刘飞
    /// 2013-4-16
    /// 景区订单修改
    /// </summary>
    public partial class ScenicOrderEdit : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected string StrOrderpeople = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string orderid = Utils.GetQueryStringValue("orderid");
            string dotype = Utils.GetQueryStringValue("dotype");

            if (!IsPostBack)
            {
                PageInit(orderid, dotype);
            }
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="id">景区编号</param>
        /// <param name="dotype">操作类型(查看，修改)</param>
        private void PageInit(string id, string dotype)
        {
            EyouSoft.BLL.ScenicStructure.BScenicArea bllscenic = new EyouSoft.BLL.ScenicStructure.BScenicArea();
            if (id != "")
            {
                EyouSoft.Model.ScenicStructure.MScenicAreaOrder ordermodel = bllscenic.GetScenicAreaOrderModel(id);
                if (ordermodel != null)
                {
                    //StrOrderStatus = EyouSoft.Common.Utils.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.XianLuStructure.OrderStatus)), ((int)ordermodel.Status).ToString(), false);
                    this.txtTicketNum.Text = ordermodel.Num.ToString()+"张";
                    ScenicName.Text = ordermodel.ScenicName;
                    this.txtticketPrice.Text = ordermodel.Price.ToString("f2");
                    this.txtContactTel.Text = ordermodel.ContactTel;
                    this.txtContactName.Text = ordermodel.ContactName;
                    this.txtRemark.Text = ordermodel.Remark;
                    TicketType.Text = ordermodel.TypeName;
                    OrderStatus.Text = (ordermodel.Status).ToString();
                    PayState.Text = (ordermodel.FuKuanStatus).ToString();
                    //BindTicketType(ordermodel.TicketsId, ordermodel.ScenicId);
                    GetOrderPeople(ordermodel.OperatorId);
                }
                
            }

        }

        protected void GetOrderPeople(string operatorid)
        {
            EyouSoft.BLL.OtherStructure.BMember bll = new EyouSoft.BLL.OtherStructure.BMember();
            EyouSoft.Model.MMember model = bll.GetModel(operatorid);
            if (model != null)
            {
                this.StrOrderpeople = model.MemberName;
                txtopeater.Text = model.MemberName;
            }
            else
                this.StrOrderpeople = "";
        }


        /// <summary>
        /// 修改操作
        /// </summary>
        /// <param name="id">景区编号</param>
        /// <param name="dotype">操作类型</param>
        /// <returns></returns>
        //private string PageSave(string id, string dotype)
        //{
        //    string msg = string.Empty;
        //    string ticketNum = Utils.GetFormValue(this.txtTicketNum.UniqueID);
        //    decimal ticketPrice = Utils.GetDecimal(this.txtticketPrice.Value);
        //    string scenicid = Utils.GetFormValue("sltscenci");
        //    string scenictypename = Utils.GetFormValue("slttickettype");
        //    int orderstatus = Utils.GetInt(Utils.GetFormValue("orderstatus"));
        //    string contactname = Utils.GetFormValue(this.txtContactName.UniqueID);
        //    string contacttel = Utils.GetFormValue(this.txtContactTel.UniqueID);
        //    string source = Utils.GetFormValue(this.hidsource.UniqueID);
        //    string remark = Utils.GetFormValue(this.txtRemark.UniqueID);
        //    int sel_PayState = Utils.GetInt(Utils.GetFormValue("sel_PayState"));
        //    if (id != "" && dotype == "update")
        //    {
        //        EyouSoft.BLL.ScenicStructure.BScenicArea bll = new EyouSoft.BLL.ScenicStructure.BScenicArea();
        //        EyouSoft.Model.ScenicStructure.MScenicAreaOrder model = new EyouSoft.Model.ScenicStructure.MScenicAreaOrder();
        //        model.IssueTime = DateTime.Now;
        //        model.Num = Utils.GetInt(ticketNum);
        //        model.OrderId = id;
        //        model.Price = ticketPrice;
        //        model.ScenicId = scenicid;
        //        if (!string.IsNullOrEmpty(source))
        //            model.Source = (EyouSoft.Model.Enum.ScenicStructure.ScenicAreaOrderSource)Utils.GetInt(source);
        //        else
        //            model.Source = EyouSoft.Model.Enum.ScenicStructure.ScenicAreaOrderSource.网站;
        //        model.Remark = remark;
        //        model.Status = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)orderstatus;
        //        model.TicketsId = scenictypename;
        //        model.ContactName = contactname;
        //        model.ContactTel = contacttel;
        //        model.FuKuanStatus = (EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus)sel_PayState;
        //        if (bll.UpdateScenicAreaOrder(model))
        //        {
        //            if (model.Status == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货)
        //            {
        //                if (!(new EyouSoft.BLL.OtherStructure.BTatolProduct().ExistsMemberTotal(model.OrderId, Utils.GetFormValue(this.hidMemberId.UniqueID))))
        //                    SaveTotal(model);
        //            }
        //            if (model.Status != EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货)
        //            {
        //                if (new EyouSoft.BLL.OtherStructure.BTatolProduct().ExistsMemberTotal(model.OrderId, Utils.GetFormValue(this.hidMemberId.UniqueID)))
        //                    new EyouSoft.BLL.OtherStructure.BTatolProduct().DeleteMemberTotal(Utils.GetFormValue(this.hidMemberId.UniqueID), model.OrderId);
        //            }
        //            msg = Utils.AjaxReturnJson("1", "修改成功!");
        //        }
        //        else
        //        {
        //            msg = Utils.AjaxReturnJson("0", "修改失败!");
        //        }
        //    }
        //    return msg;
        //}

        /// <summary>
        /// 订单获取积分
        /// </summary>
        //bool SaveTotal(EyouSoft.Model.ScenicStructure.MScenicAreaOrder info)
        //{
        //    var model = new BLL.OtherStructure.BKV().GetCompanySetting();
        //    int tatol = 0;
        //    if (model == null)
        //        tatol = Convert.ToInt32(Math.Round(info.Price));
        //    else
        //        tatol = Convert.ToInt32(Math.Round(info.Price / (Utils.GetInt(model.ScenicTatol.Trim()) == 0 ? 1 : Utils.GetInt(model.ScenicTatol.Trim()))));
        //    if (tatol > 0)
        //    {
        //        EyouSoft.Model.OtherStructure.MMemberTotal addTotal = new EyouSoft.Model.OtherStructure.MMemberTotal();
        //        addTotal.MemberID = Utils.GetFormValue(this.hidMemberId.UniqueID);
        //        addTotal.OrderId = info.OrderId;
        //        addTotal.OrderType = EyouSoft.Model.Enum.OrderClass.门票;
        //        addTotal.Total = tatol;
        //        return new EyouSoft.BLL.OtherStructure.BTatolProduct().AddMemberTotal(addTotal);
        //    }
        //    else
        //        return false;
        //}

        /// <summary>
        /// 绑定景区
        /// </summary>
        /// <param name="scenicid"></param>
        //private void BindScenic(string scenicid)
        //{
        //    EyouSoft.BLL.ScenicStructure.BScenicArea bll = new EyouSoft.BLL.ScenicStructure.BScenicArea();
        //    MScenicAreaSearchModel model = new MScenicAreaSearchModel();
        //    IList<Model.ScenicStructure.MScenicArea> list = bll.GetScenicAreaListAll(0, model);
        //    StringBuilder str = new StringBuilder();
        //    str.Append("<option value='-1'>请选择</option>");
        //    if (list != null && list.Count > 0)
        //    {
        //        for (int i = 0; i < list.Count; i++)
        //        {
        //            if (scenicid == list[i].ScenicId)
        //            {
        //                str.AppendFormat("<option value='{0}' selected='selected'>{1}</option>", list[i].ScenicId, list[i].ScenicName);
        //            }
        //            else
        //            {
        //                str.AppendFormat("<option value='{0}'>{1}</option>", list[i].ScenicId, list[i].ScenicName);
        //            }
        //        }
        //    }
        //    ScenicName = str.ToString();
        //}
        /// <summary>
        /// 绑定门票类型
        /// </summary>
        /// <param name="ticketid"></param>
        //private void BindTicketType(string ticketid, string scenicid)
        //{
        //    EyouSoft.BLL.ScenicStructure.BScenicTickets bll = new EyouSoft.BLL.ScenicStructure.BScenicTickets();
        //    IList<EyouSoft.Model.ScenicStructure.MScenicTickets> list = bll.GetTopList(0, new MScenicTicketsSearchModel { Status = EyouSoft.Model.Enum.ScenicStructure.ScenicTicketsStatus.上架, ScenicId = scenicid });
        //    StringBuilder str = new StringBuilder();
        //    str.Append("<option value='-1'>请选择</option>");
        //    if (list != null && list.Count > 0)
        //    {
        //        for (int i = 0; i < list.Count; i++)
        //        {
        //            if (ticketid == list[i].TicketsId)
        //            {
        //                str.AppendFormat("<option value='{0}' selected='selected'>{1}</option>", list[i].TicketsId, list[i].TypeName);
        //            }
        //            else
        //            {
        //                str.AppendFormat("<option value='{0}'>{1}</option>", list[i].TicketsId, list[i].TypeName);
        //            }
        //        }
        //    }
        //    TicketType = str.ToString();
        //}
    }
}
