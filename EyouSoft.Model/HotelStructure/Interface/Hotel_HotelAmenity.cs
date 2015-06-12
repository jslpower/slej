using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.HotelStructure.Interface
{
   using System;
   using Linq.ORM;
   using System.ComponentModel;
   using Linq.ORM.Attribute;
   /// <summary>
   /// 
   /// </summary>
   [Table("Hotel_HotelAmenity")]
   public class Hotel_HotelAmenity
   {
      /// <summary>
      /// 酒店代码
      /// </summary>
      [PrimaryKey]
      [DisplayName("酒店代码")]
      public string HOTEL_CODE { get; set; }
      /// <summary>
      /// 设施名称
      /// </summary>
      [PrimaryKey]
      [DisplayName("设施名称")]
      public string AMENITY_NAME { get; set; }
      /// <summary>
      /// 设施状态
      /// </summary>
      [DisplayName("设施状态")]
      public string AMENITY_STATUS { get; set; }
      /// <summary>
      /// 设施类别
      /// </summary>
      [DisplayName("设施类别")]
      public string AMENITY_TYPE { get; set; }


      public enum AmenityType
      {
         /// <summary>
         /// 餐饮
         /// </summary>
         [Description("餐饮")]
         CAT,
         /// <summary>
         /// 休闲娱乐
         /// </summary>
         [Description("休闲娱乐")]
         REC,
         /// <summary>
         /// 服务
         /// </summary>
         [Description("服务")]
         SER,
      }
   }
}
