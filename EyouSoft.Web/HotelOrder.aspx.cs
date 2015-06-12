using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Model.HotelStructure;
using Common.page;
using Common;
using Linq.Web;
using EyouSoft.Model.HotelStructure.WebModel;
using EyouSoft.Model.Enum;
using EyouSoft.BLL.HotelStructure;
using EyouSoft.Model.SystemStructure;
using EyouSoft.BLL.SystemStructure;
using EyouSoft.Web.MasterPage;
using EyouSoft.IDAL.AccountStructure;

namespace EyouSoft.Web
{
   [IsLogin] 
   [NoCache]
   public partial class HotelOrder : ClientModelViewPageBase<MHotelOrderXiangQing>
   {
      BHotel2 bll = new BHotel2();
      BSellers bseller = new BSellers();
      BFeeSettings bllFeeSetting = new BFeeSettings();
      protected void Page_Load(object sender, EventArgs e)
      {
         (Master as Front2).HeadMenuIndex = 7;

         //首次进入页面
         if (string.IsNullOrEmpty(Request["submit"]))
         {
            //根据价格id获取对应房型下的所有价格信息
            var searchModel = new MRoomRateSearchModel
            {
               RuZhuRiQi = Model.CheckInDate,
               LiDianRiQi = Model.CheckOutDate,
               RoomTypeId = Model.RoomTypeId,
               RoomRateIds = Model.RoomRateIds,
               RoomCount = Model.RoomCount,
            };
            string msg;
            MHotelOrderXiangQing hotelOrder = bll.GetOrderRoomRateInfo(searchModel, out msg);
            if (hotelOrder == null)
            {
               Response.Write("<div class=\"font16 fontred\" style=\"padding-top:20px;text-align:center;\">"+msg+"</div>");
               Response.End();
            }
            int hotelday = 0;
            for (int htime = 0; htime < hotelOrder.RoomRates.Count; htime++)
            {
                hotelday = hotelday + hotelOrder.RoomRates[htime].Time.Count();
            }
            if (hotelOrder.RoomRates == null || hotelOrder.RoomRates.Count == 0 || hotelday != (Model.CheckOutDate - Model.CheckInDate).Days)
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
               hotelOrder.ContactName = CurrentUser.MemberName;
               hotelOrder.ContactMobile = CurrentUser.Mobile;
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
                      hotelOrder.TotalAmount += Math.Round(hotelOrder.RoomCount * roomRate.DanJia);
                  }

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
               Model = hotelOrder;
            }
            else
            {
               Response.End();
            }
         }
         else
         {
            //提交订单
            Model.OperatorId = CurrentUser.UserId;
            Model.OrderSite = OrderSite.PC;
            string msg;
            var list = new EyouSoft.BLL.HotelStructure.BHotelRoomType().GetHotelRoomTypeModel(Model.RoomTypeId);
            if (list != null)
            {
                Model.PaymentType = list.Payment;
            }
            bool i = bll.SubmitHotelOrder(Model, CurrentUser.UserType, out msg);
            Response.Write((i ? 1 : 0) + ":" + msg);
            Response.End();
         }
      }

      protected IEnumerable<SelectListItem> RoomCount()
      {
         for (int i = 1; i < 11; i++)
         {
            yield return new SelectListItem { Text = i.ToString(), Value = i.ToString() };
         }
      }
   }
}
