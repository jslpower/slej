using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.SystemStructure;

namespace EyouSoft.Model.HotelStructure.WebModel
{
   public class MHotelRoomRateBindModel : MHotelRoomRate2
   {
      public MBaseHotelRoomType RoomTypeInfo { get; set; }
      public MFeeSettings FeeSetting { get; set; }
      /// <summary>
      /// 当前用户计算后的单价
      /// </summary>
      public decimal DanJia { get; set; }
      /// <summary>
      /// 当前价格对应的时间
      /// </summary>
      public List<DateTime> Time { get; set; }

      public string HotelCode { get; set; }
   }
}
