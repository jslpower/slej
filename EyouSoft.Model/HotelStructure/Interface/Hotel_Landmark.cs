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
   [Table("Hotel_Landmark")]
   public class Hotel_Landmark
   {
      /// <summary>
      /// 酒店代码
      /// </summary>
      [PrimaryKey]
      [DisplayName("酒店代码")]
      public string CITY_CODE { get; set; }
      /// <summary>
      /// 地标名称
      /// </summary>
      [PrimaryKey]
      [DisplayName("地标名称")]
      public string LANDMARK_NAME { get; set; }
      /// <summary>
      /// 类别
      /// </summary>
      [PrimaryKey]
      [DisplayName("类别")]
      public string CATEGORY { get; set; }
      /// <summary>
      /// 城市名称
      /// </summary>
      [DisplayName("城市名称")]
      public string CITY_NAME { get; set; }
      /// <summary>
      /// 国家代码
      /// </summary>
      [DisplayName("国家代码")]
      public string COUNTRY_CODE { get; set; }
      /// <summary>
      /// 该区域酒店 code 队列
      /// </summary>
      [DisplayName("该区域酒店 code 队列")]
      public string HOTELS { get; set; }
   }
}
