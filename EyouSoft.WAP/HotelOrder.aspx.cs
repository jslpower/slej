using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Model.HotelStructure.WebModel;
using EyouSoft.BLL.HotelStructure;
using EyouSoft.Common.Page;
using EyouSoft.Model.Enum;
using EyouSoft.BLL.SystemStructure;
using EyouSoft.Common;
using EyouSoft.Model.HotelStructure;
using EyouSoft.IDAL.AccountStructure;

namespace EyouSoft.WAP
{
    public partial class HotelOrder : WebPageBase
    {
        BHotel2 bll = new BHotel2();
        BFeeSettings bllFeeSetting = new BFeeSettings();
        MHotelOrderXiangQing Model = new MHotelOrderXiangQing();
        protected decimal DanJia = 0;
        protected decimal ZongJia = 0;
        protected decimal JieSuanJia = 0;
        protected decimal HuiYuanDanJia = 0;
        protected decimal GuiBingDanJia = 0;
        protected decimal DaiLiDanJia = 0;
        protected decimal YuanGongDanJia = 0;
        protected int DaysNum = 0;
        protected string MingXi = "";
        protected string HotelRoomName = "";
        protected int usercate = 0;//会员级别0-未登录及未注册用户
        protected bool isShow = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "填写订单";
            if (Request.QueryString["dotype"] == "save")
            {
                TiJiaoOrder();
            }
            if (!IsPostBack)
            {
                if (new EyouSoft.IDAL.AccountStructure.BSellers().WebSiteShowOrHidden(Request.Url.Host.ToLower().Replace("m.", "")) == ShowHidden.隐藏)
                {
                    isShow = false;
                }
                //根据价格id获取对应房型下的所有价格信息
                var searchModel = new MRoomRateSearchModel
                {
                    RuZhuRiQi = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("CheckInDate")),
                    LiDianRiQi = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("CheckOutDate")),
                    RoomTypeId = Utils.GetQueryStringValue("RoomTypeId"),
                    RoomRateIds = Utils.GetQueryStringValue("RoomRateIds"),
                    RoomCount = Utils.GetInt(Utils.GetQueryStringValue("RoomCount")),
                };
                string msg;
                MHotelOrderXiangQing hotelOrder = bll.GetOrderRoomRateInfo(searchModel, out msg);
                if (hotelOrder == null)
                {
                    Response.Write("<div class=\"font16 fontred\" style=\"padding-top:20px;text-align:center;\">"+msg+"</div>"
);
                    Response.End();
                }
                int hotelday = 0;
                for (int htime = 0; htime < hotelOrder.RoomRates.Count; htime++)
                {
                    hotelday = hotelday + hotelOrder.RoomRates[htime].Time.Count();
                }
                if (hotelOrder.RoomRates == null || hotelOrder.RoomRates.Count == 0 || hotelday != (Utils.GetDateTime(Utils.GetQueryStringValue("CheckOutDate")) - Utils.GetDateTime(Utils.GetQueryStringValue("CheckInDate"))).Days)
                {
                    Response.Write("<div class=\"font16 fontred\" style=\"padding-top:20px;text-align:center;\">物价信息未发现！</div>");
                    Response.End();
                }
                if (hotelOrder != null)
                {
                    var tl = hotelOrder.RoomRates.Where(x => x.Status == "noavail").ToList();
                    if (tl.Count > 0)
                    {
                        System.Text.StringBuilder builder1 = new System.Text.StringBuilder();
                        builder1.Append("<script language='javascript'>");
                        builder1.AppendFormat("alert('{0}');", "该房型已满，请重新选择");
                        builder1.AppendFormat("history.back({0})", -1);
                        builder1.Append("</script>");
                        Response.Write(builder1.ToString());
                        Response.End();

                    }
                    if (isLogin)
                    {
                        usercate = (int)m.UserType;
                        hotelOrder.ContactName = m.MemberName;
                        hotelOrder.ContactMobile = m.Mobile;
                    }
                    else
                    {
                        hotelOrder.ContactName = "&nbsp;";
                        hotelOrder.ContactMobile = "&nbsp;";
                    }
                    var feeSetting = bllFeeSetting.GetByType(FeeTypes.酒店);
                    foreach (MHotelRoomRateBindModel roomRate in hotelOrder.RoomRates)
                    {
                        for (int rday = 0; rday < roomRate.Time.Count; rday++)
                        {
                            if (isLogin)
                            {
                                roomRate.DanJia = BHotel2.CalculateFee(roomRate.SettlementPrice, roomRate.PreferentialPrice, m.UserType, feeSetting, FeeTypes.酒店);
                            }
                            else
                            {
                                roomRate.DanJia = BHotel2.CalculateFee(roomRate.SettlementPrice, roomRate.PreferentialPrice, EyouSoft.Model.Enum.MemberTypes.普通会员, feeSetting, FeeTypes.酒店);
                            }
                            MingXi += "<li><span class=\"font_yellow floatR\">¥" + roomRate.DanJia + " × <em class=\"roomNum\">1</em> </span> " + roomRate.Time[rday] + "      " + hotelOrder.RommType.RoomName + "      " + hotelOrder.RoomRates[0].Breakfast + "</li>";
                            hotelOrder.TotalAmount += Math.Round(hotelOrder.RoomCount * roomRate.DanJia);
                        }
                    }
                    ZongJia = hotelOrder.TotalAmount;
                    if (hotelOrder.CheckInDate.Date == DateTime.Now.Date)
                    {
                        if (DateTime.Now < DateTime.Parse(DateTime.Now.Date.ToString("yyyy-MM-dd") + " 18:00:00"))
                        {
                            hotelOrder.DaoDianShiJian = "1800";
                        }
                        else
                        {
                            hotelOrder.DaoDianShiJian = DateTime.Now.AddHours(1).ToString("HHmm");
                        }
                    }
                    else
                    {
                        hotelOrder.DaoDianShiJian = "1800";
                    }
                    HotelName.Text = hotelOrder.Hotel.HotelName;
                    RuZhuDay.Text = hotelOrder.CheckInDate.ToString("yyyy-MM-dd");
                    LiDianDay.Text = hotelOrder.CheckOutDate.ToString("yyyy-MM-dd");
                    DayNum.Text = (hotelOrder.CheckOutDate - hotelOrder.CheckInDate).Days.ToString();
                    DaysNum = (hotelOrder.CheckOutDate - hotelOrder.CheckInDate).Days;
                    DanJia = hotelOrder.RoomRates[0].DanJia;
                    JieSuanJia = hotelOrder.RoomRates[0].SettlementPrice;
                    ConName.Text = hotelOrder.ContactName;
                    ConMoblie.Text = hotelOrder.ContactMobile;
                    HotelRoomName = hotelOrder.RommType.RoomName;
                    HuiYuanDanJia = EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee(JieSuanJia, JieSuanJia, EyouSoft.Model.Enum.MemberTypes.普通会员, (EyouSoft.Model.SystemStructure.MFeeSettings)hotelOrder.FeeSetting, EyouSoft.Model.Enum.FeeTypes.酒店);
                    GuiBingDanJia = EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee(JieSuanJia, JieSuanJia, EyouSoft.Model.Enum.MemberTypes.贵宾会员, (EyouSoft.Model.SystemStructure.MFeeSettings)hotelOrder.FeeSetting, EyouSoft.Model.Enum.FeeTypes.酒店);
                    DaiLiDanJia = EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee(JieSuanJia, JieSuanJia, EyouSoft.Model.Enum.MemberTypes.代理, (EyouSoft.Model.SystemStructure.MFeeSettings)hotelOrder.FeeSetting, EyouSoft.Model.Enum.FeeTypes.酒店);
                    YuanGongDanJia = EyouSoft.BLL.HotelStructure.BHotel2.CalculateFee(JieSuanJia, JieSuanJia, EyouSoft.Model.Enum.MemberTypes.员工, (EyouSoft.Model.SystemStructure.MFeeSettings)hotelOrder.FeeSetting, EyouSoft.Model.Enum.FeeTypes.酒店);
                    //if (isLogin)
                    //{
                    //    if (m.UserType == MemberTypes.普通会员)
                    //    {
                    //        DanJia = HuiYuanDanJia;
                    //    }
                    //    else if (m.UserType == MemberTypes.贵宾会员)
                    //    {
                    //        DanJia = GuiBingDanJia;
                    //    }
                    //    else if (m.UserType == MemberTypes.代理)
                    //    {
                    //        DanJia = DaiLiDanJia;
                    //    }
                    //    else if (m.UserType == MemberTypes.员工)
                    //    {
                    //        DanJia = YuanGongDanJia;
                    //    }
                    //}
                    //for (int i = 0; i < DaysNum; i++)
                    //{
                    //    MingXi += "<li><span class=\"font_yellow floatR\">¥" + DanJia + " × <em class=\"roomNum\">1</em> </span> " + hotelOrder.CheckInDate.AddDays(i).ToShortDateString() + "      " + hotelOrder.RommType.RoomName + "      " + hotelOrder.RoomRates[0].Breakfast + "</li>";
                    //}

                }
                else
                {
                    Response.End();
                }
            }
        }

        protected void TiJiaoOrder()
        {
            //根据价格id获取对应房型下的所有价格信息
            var searchModel = new MRoomRateSearchModel
            {
                RuZhuRiQi = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("CheckInDate")),
                LiDianRiQi = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("CheckOutDate")),
                RoomTypeId = Utils.GetQueryStringValue("RoomTypeId"),
                RoomRateIds = Utils.GetQueryStringValue("RoomRateIds"),
                RoomCount = Utils.GetInt(Utils.GetQueryStringValue("RoomCount")),
            };
            string msg;
            MHotelOrderXiangQing hotelOrder = bll.GetOrderRoomRateInfo(searchModel, out msg);
            if (hotelOrder == null)
            {
                Response.Write(msg);
                Response.End();
            }
            if (hotelOrder.RoomRates == null || hotelOrder.RoomRates.Count == 0 || hotelOrder.RoomRates.Count != (Utils.GetDateTime(Utils.GetQueryStringValue("CheckOutDate")) - Utils.GetDateTime(Utils.GetQueryStringValue("CheckInDate"))).Days)
            {
                msg = "物价信息未发现！";
            }
            if (hotelOrder != null)
            {
                var tl = hotelOrder.RoomRates.Where(x => x.Status == "noavail").ToList();
                if (tl.Count > 0)
                {
                    msg = "该房型已满，请重新选择";
                }
                hotelOrder.ContactName = m.MemberName;
                hotelOrder.ContactMobile = m.Mobile;
                var feeSetting = bllFeeSetting.GetByType(FeeTypes.酒店);
                foreach (MHotelRoomRateBindModel roomRate in hotelOrder.RoomRates)
                {
                    roomRate.DanJia = BHotel2.CalculateFee(roomRate.SettlementPrice, roomRate.PreferentialPrice, m.UserType, feeSetting, FeeTypes.酒店);
                }
                if (hotelOrder.CheckInDate.Date == DateTime.Now.Date)
                {
                    if (DateTime.Now < DateTime.Parse(DateTime.Now.Date.ToString("yyyy-MM-dd") + " 18:00:00"))
                    {
                        hotelOrder.DaoDianShiJian = "1800";
                    }
                    else
                    {
                        hotelOrder.DaoDianShiJian = DateTime.Now.AddHours(1).ToString("HHmm");
                    }
                }
                else
                {
                    hotelOrder.DaoDianShiJian = "1800";
                }
            }
            Model = hotelOrder;
            hotelOrder.DaoDianShiJian = Utils.GetFormValue("DaoDianTime");
            hotelOrder.RoomCount = Utils.GetInt(Utils.GetFormValue("RoomNum"));
            hotelOrder.TotalAmount = hotelOrder.RoomRates[0].DanJia;
            string[] RuZhuRenName = HttpContext.Current.Request.Form.GetValues("RuZhuRenName");
            string[] RuZhuRenMoblie = HttpContext.Current.Request.Form.GetValues("RuZhuRenMoblie");
            IList<MHotelOrderContact> Contact = new List<MHotelOrderContact>();
            for (int t = 0; t < RuZhuRenName.Length; t++)
            {
                MHotelOrderContact modelc = new MHotelOrderContact();
                modelc.ContactName = RuZhuRenName[t];
                modelc.Mobile = RuZhuRenMoblie[t];
                Contact.Add(modelc);
            }
            //提交订单
            Model.ContactName = RuZhuRenName[0];
            Model.ContactMobile = RuZhuRenMoblie[0];
            Model.OrderCotact = Contact.ToArray<MHotelOrderContact>();
            Model.OperatorId = m.UserId;
            if (isfenxiao)
            {
                string url = HttpContext.Current.Request.Url.Host.ToLower();
                url = url.Replace("m.", "");
                BSellers bsells = new BSellers();
                EyouSoft.Model.AccountStructure.MSellers seller = new EyouSoft.Model.AccountStructure.MSellers();
                seller = bsells.GetMSellersByWebSite(url);
                if (seller != null)
                {
                    if (bsells.JudgeAuthor(url, EyouSoft.Model.Enum.FeeTypes.酒店))
                    {
                        Model.SellerID = seller.ID;
                    }
                }
            }
            
            Model.Remark = Utils.GetFormValue("BeiZhu");
            var list = new EyouSoft.BLL.HotelStructure.BHotelRoomType().GetHotelRoomTypeModel(Model.RoomTypeId);
            if (list != null)
            {
                Model.PaymentType = list.Payment;
            }
            Model.OrderSite = OrderSite.WAP;
            bool n = bll.SubmitHotelOrder(Model, m.UserType, out msg);
            if (n) msg = "下单成功，请前往订单中心查看";
            RCWE(UtilsCommons.AjaxReturnJson(n ? "1" : "0", msg));
        }
    }
}
