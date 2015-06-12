using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.Bussiness;
using EyouSoft.Model.SystemStructure;
using Linq.Web.Html.Interface;
using EyouSoft.Model.Enum.XianLuStructure;

namespace EyouSoft.Model.HotelStructure.WebModel
{
   public class MHotelSearchModel1 : MHotel2, ISearchable
   {
      public string CityName { get; set; }


      [ValueFormatter(typeof(DefaultDateTimeFormat))]
      public DateTime? RuZhuRiQi { get; set; }
      [ValueFormatter(typeof(DefaultDateTimeFormat))]
      public DateTime? LiDianRiQi { get; set; }
      public int? JiaGe1 { get; set; }
      public int? JiaGe2 { get; set; }
      /// <summary>
      /// 不去取接口来的数据
      /// </summary>
      public bool NoInterface { get; set; }
      /// <summary>
      /// 是否只取有图片的酒店
      /// </summary>
      public bool MustHasImg { get; set; }
      /// <summary>
      /// 详细页的当前价格
      /// </summary>
      public int[] RoomRateId { get; set; }
      public string RoomTypeId { get; set; }
      public string RoomTypeId_Except { get; set; }
      public string RoomRateId_Except { get; set; }

      /// <summary>
      /// 给左边的搜索框用的
      /// </summary>
      public string MyKeyword { get; set; }
      /// <summary>
      /// 给左边的搜索框用的
      /// </summary>
      public string Mudidi { get; set; }
      /// <summary>
      /// 给左边的搜索框用的
      /// </summary>
      public string SanZiMa { get; set; }
      /// <summary>
      /// 给左边的搜索框用的
      /// </summary>
      [ValueFormatter(typeof(DefaultDateTimeFormat))]
      public DateTime? RuZhuRiQi2 { get; set; }
      /// <summary>
      /// 给左边的搜索框用的
      /// </summary>
      [ValueFormatter(typeof(DefaultDateTimeFormat))]
      public DateTime? LiDianRiQi2 { get; set; }

      public SearchModel SearchInfo
      {
         get;
         set;
      }

      /// <summary>
      /// 状态（首页推荐、上下架）
      /// </summary>
      public XianLuZT[] IsIndex { get; set; }
      /// <summary>
      /// 界面绑定用
      /// </summary>

      public string FirstImageAddress { get; set; }
      /// <summary>
      /// 用于接收数据库查询的结果
      /// </summary>
      public MHotelRoomRateBindModel RoomRate1 { get; set; }
      /// <summary>
      /// 用于接收数据库查询的结果
      /// </summary>
      public MBaseHotelRoomType RoomTypeInfo1 { get; set; }
      /// <summary>
      /// 界面绑定时的价格list
      /// </summary>
      public List<MHotelRoomRateBindModel> RoomRateInfo { get; set; }

   }

   public class MRoomRateSearchModel
   {
      public string RoomRateIds { get; set; }
      public DateTime? RuZhuRiQi { get; set; }
      public DateTime? LiDianRiQi { get; set; }
      public string RoomTypeId { get; set; }
      public int RoomCount { get; set; }
   }
}
