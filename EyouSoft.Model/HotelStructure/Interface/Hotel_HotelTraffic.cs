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
   [Table("Hotel_HotelTraffic")]
   public class Hotel_HotelTraffic
   {
      /// <summary>
      /// 酒店代码
      /// </summary>
      [PrimaryKey]
      [DisplayName("酒店代码")]
      public string HOTEL_CODE { get; set; }
      /// <summary>
      /// 交通信息名称
      /// </summary>
      [PrimaryKey]
      [DisplayName("交通信息名称")]
      public string TRAFFIC_NAME { get; set; }
      /// <summary>
      /// 距离
      /// </summary>
      [DisplayName("距离")]
      public string DISTANCE { get; set; }
      /// <summary>
      /// 车程
      /// </summary>
      [DisplayName("车程")]
      public string CAR_INTERVAL { get; set; }
      /// <summary>
      /// 步程
      /// </summary>
      [DisplayName("步程")]
      public string FOOT_INTERVAL { get; set; }
      /// <summary>
      /// 类别
      /// </summary>
      [DisplayName("类别")]
      public string CATEGORY { get; set; }
   }
}
