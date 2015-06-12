using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.Bussiness;
using EyouSoft.Model.HotelStructure.Interface;
using Linq.Web.Html.Interface;

namespace EyouSoft.Model.HotelStructure.WebModel
{
   public class MHotelXiangQingModel : MHotel2
   {
      [ValueFormatter(typeof(DefaultDateTimeFormat))]
      public DateTime? RuZhuRiQi { get; set; }
      [ValueFormatter(typeof(DefaultDateTimeFormat))]
      public DateTime? LiDianRiQi { get; set; }
      public string CityName { get; set; }
      public string FirstImageAddress { get; set; }

      public SearchModel SearchInfo
      {
         get;
         set;
      }
      /// <summary>
      /// 房型和价格信息
      /// </summary>
      public IList<MHotelImg> Images { get; set; }
      public IList<Hotel_HotelTraffic> Traffic { get; set; }
      public IList<Hotel_HotelAmenity> SheShi { get; set; }
   }


   public class MHotelXiangQingModel2 : MHotelXiangQingModel
   {
      public string RoomTypeId_Except { get; set; }
      public string RoomRateId_Except { get; set; }
      public string RoomTypeId { get; set; }
      public List<MHotelRoomRateBindModel> RoomRateInfo { get; set; }
      public string RoomRateIds { get; set; }
      public MBaseHotelRoomType RoomTypeInfo { get; set; }
   }
}
