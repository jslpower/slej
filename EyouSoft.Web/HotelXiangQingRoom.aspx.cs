using System;
using EyouSoft.BLL.HotelStructure;
using Common.page;
using EyouSoft.Model.HotelStructure.WebModel;
using Linq.Web;
using System.Collections.Generic;
using EyouSoft.Model.SystemStructure;

namespace EyouSoft.Web
{
   [NoCache]
   public partial class HotelXiangQingRoom : ClientModelViewPageBase<MHotelSearchModel1>
   {

      BHotel2 bll = new BHotel2();
      protected void Page_Load(object sender, EventArgs e)
      {
         if (!Model.RuZhuRiQi.HasValue)
         {
            Model.RuZhuRiQi = DateTime.Now.Date;
         }
         if (!Model.LiDianRiQi.HasValue || Model.LiDianRiQi <= Model.RuZhuRiQi)
         {
            Model.LiDianRiQi = Model.RuZhuRiQi.Value.AddDays(1);
         }
         if (string.IsNullOrEmpty(Model.HotelId))
         { 
            Response.End();
         }
         var s = bll.GetHotelList(Model, false, CurrentUser.UserType, false);
         if (s.Count > 0)
         {
            Model.RoomRateInfo = s[0].RoomRateInfo;
         }
      }


      protected decimal SearchMin(IList<decimal> arr, out int index)
      {
         if (arr != null && arr.Count > 0)
         {
            index = -1;
            decimal min = decimal.MaxValue;
            for (int i = 0, k = arr.Count; i < k; i++)
            {
               if (arr[i] < min)
               {
                  min = arr[i];
                  index = i;
               }
            }
            return min;
         }
         throw new InvalidOperationException();
      }
   }


   public class TempClass
   {
      public List<int> RoomRateIds { get; set; }
      /// <summary>
      /// 套餐名称
      /// </summary>
      public List<string> RoomRateName { get; set; }
      public List<decimal> PreferentialPrice { get; set; }
      public List<decimal> SettlementPrice { get; set; }
      public MFeeSettings FeeSetting { get; set; }
      public List<string> BreakFasts { get; set; }
   }
}
