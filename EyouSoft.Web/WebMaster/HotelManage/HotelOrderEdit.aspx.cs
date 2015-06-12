using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.BLL.HotelStructure;
using EyouSoft.Model.HotelStructure;

namespace EyouSoft.Web.WebMaster.HotelManage
{
    public partial class HotelOrderEdit : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected bool quxiao = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            string getID = Utils.GetQueryStringValue("id");
            string dotype = Utils.GetQueryStringValue("dotype");
            getOrder(getID);

        }
        private void getOrder(string id)
        {
            BHotelOrder bll = new BHotelOrder();
            MHotelOrder model = new MHotelOrder();
            model = bll.GetModel(id);
            if (model != null)
            {
                orderCode.Text = model.OrderCode;
                hotelName.Text = model.HotelName;
                destineDate.Text = model.CheckOutDate.ToString("yyyy-MM-dd");
                txt_inDate.Text = model.CheckInDate.ToString("yyyy-MM-dd");
                txt_outDate.Text = model.CheckOutDate.ToString("yyyy-MM-dd");
                txt_roomNum.Text = model.RoomCount.ToString();
                orderMoney.Text = model.TotalAmount.ToString("0.00");
                txt_linkName.Text = model.ContactName;
                txt_linkMobil.Text = model.ContactMobile;
                txt_hotelback.Text = model.Remark;
                PayState.Text = (model.PaymentState).ToString();
                orderState.Text = (model.OrderState).ToString();
            }
        }

        /// <summary>
        /// 订单获取积分
        /// </summary>
        //bool SaveTotal(MHotelOrder info)
        //{
        //    var model = new BLL.OtherStructure.BKV().GetCompanySetting();
        //    int tatol = 0;
        //    if (model == null)
        //        tatol = Convert.ToInt32(Math.Round(info.TotalAmount));
        //    else
        //        tatol = Convert.ToInt32(Math.Round(info.TotalAmount / (Utils.GetInt(model.HotelTatol.Trim()) == 0 ? 1 : Utils.GetInt(model.HotelTatol.Trim()))));
        //    if (tatol > 0)
        //    {
        //        EyouSoft.Model.OtherStructure.MMemberTotal addTotal = new EyouSoft.Model.OtherStructure.MMemberTotal();
        //        addTotal.MemberID = Utils.GetFormValue(this.hidMemberId.UniqueID);
        //        addTotal.OrderId = info.OrderId;
        //        addTotal.OrderType = EyouSoft.Model.Enum.OrderClass.酒店;
        //        addTotal.Total = tatol;
        //        return new EyouSoft.BLL.OtherStructure.BTatolProduct().AddMemberTotal(addTotal);
        //    }
        //    else
        //        return false;
        //}

        //private string save(string id, string dotype)
        //{

        //    string inDate = Utils.GetFormValue(this.txt_inDate.UniqueID);
        //    string outDate = Utils.GetFormValue(this.txt_outDate.UniqueID);
        //    string orderMoney = Utils.GetFormValue(this.orderMoney.UniqueID);

        //    string linkName = Utils.GetFormValue(this.txt_linkName.UniqueID);
        //    string linkMobil = Utils.GetFormValue(this.txt_linkMobil.UniqueID);
        //    int roomNum = Utils.GetInt(Utils.GetFormValue(this.txt_roomNum.UniqueID));

        //    string orderState = Utils.GetFormValue("ddl_orderState");
        //    string source = Utils.GetFormValue(this.hidsource.UniqueID);

        //    int sel_PayState = Utils.GetInt(Utils.GetFormValue("sel_PayState"));

        //    string hotelback = Utils.GetFormValue(this.txt_hotelback.UniqueID);

        //    BHotelOrder bll = new BHotelOrder();
        //    MHotelOrder model = bll.GetModel(id);
        //    model.OrderId = id;
        //    model.CheckInDate = Utils.GetDateTime(inDate);
        //    model.CheckOutDate = Utils.GetDateTime(outDate);
        //    model.RoomCount = roomNum;
        //    model.TotalAmount = Utils.GetDecimal(orderMoney);
        //    model.ContactName = linkName;
        //    model.ContactMobile = linkMobil;
        //    model.PaymentState = (EyouSoft.Model.Enum.PaymentState)sel_PayState;
        //    model.OrderState = (EyouSoft.Model.Enum.OrderState)Utils.GetInt(orderState);
        //    if (!string.IsNullOrEmpty(source))
        //        model.Source = (EyouSoft.Model.Enum.ScenicStructure.ScenicAreaOrderSource)Utils.GetInt(source);
        //    else
        //        model.Source = EyouSoft.Model.Enum.ScenicStructure.ScenicAreaOrderSource.网站;

        //    model.Remark = hotelback;
        //    int result = 0;
        //    if (dotype == "save")
        //    {
        //        result = bll.Update(model);
        //    }

        //    string strReturn = string.Empty;
        //    switch (result)
        //    {
        //        case 1:
        //            if (model.OrderState == EyouSoft.Model.Enum.OrderState.交易完成)
        //            {
        //                if (!(new EyouSoft.BLL.OtherStructure.BTatolProduct().ExistsMemberTotal(model.OrderId, Utils.GetFormValue(this.hidMemberId.UniqueID))))
        //                    SaveTotal(model);
        //            }
        //            if (model.OrderState != EyouSoft.Model.Enum.OrderState.交易完成)
        //            {
        //                if (new EyouSoft.BLL.OtherStructure.BTatolProduct().ExistsMemberTotal(model.OrderId, Utils.GetFormValue(this.hidMemberId.UniqueID)))
        //                    new EyouSoft.BLL.OtherStructure.BTatolProduct().DeleteMemberTotal(Utils.GetFormValue(this.hidMemberId.UniqueID), model.OrderId);
        //            }
        //            strReturn = "修改订单成功";
        //            break;
        //        case -1:
        //            strReturn = "酒店已删除或下架";
        //            break;
        //        case -2:
        //            strReturn = "房型已删除或下架";
        //            break;
        //        case -3:
        //            strReturn = "入住时间段存在错误价格信息";
        //            break;
        //        case -4:
        //            strReturn = "订单预订房间数超过房型最大房间数";
        //            break;
        //        case -99: strReturn = "操作失败：预订数量不能超过房型剩余数量"; break;
        //        default:
        //            strReturn = "下单失败";
        //            break;
        //    }



        //    return Utils.AjaxReturnJson(result.ToString(), strReturn);

        //}

    }
}
