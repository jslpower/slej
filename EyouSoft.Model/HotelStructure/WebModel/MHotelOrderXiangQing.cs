using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.SystemStructure;
using Linq.Bussiness;

namespace EyouSoft.Model.HotelStructure.WebModel
{
   public class MHotelOrderXiangQing : MHotelOrder
   {
      public MHotelRoomRate2 RoomRate { get; set; }
      public MBaseHotelRoomType RommType { get; set; }
      public MFeeSettings FeeSetting { get; set; }
      public MHotel2 Hotel { get; set; }
      public MHotelOrderContact[] OrderCotact { get; set; }
      public string DaoDianShiJian { get; set; }
      public string VenderCode { get; set; }
      /// <summary>
      /// 提交时使用
      /// </summary>
      public string RoomRateIds { get; set; }

      public List<MHotelRoomRateBindModel> RoomRates { get; set; }
      /// <summary>
      /// 入住天数
      /// </summary>
      public int Day { get; set; }
   }
}
