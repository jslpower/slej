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
   [Table("Hotel_HotelInfo")]
   public class Hotel_HotelInfo
   {
      /// <summary>
      /// 
      /// </summary>
      [PrimaryKey]
      public string HOTEL_CODE { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string HOTEL_NAMECN { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string HOTEL_NAMEEN { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string BRAND_CODE { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string STATUS { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string RANK_CODE { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string CITY_CODE { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string COUNTRY_CODE { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string PROVINCE { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string HOTEL_ADDRESS { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string POSTAL_CODE { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string TEL { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string OPEN_DATE { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string FIX_MENT { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string ROOM_QUANTITY { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string FLOOR { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string FAX { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string DISTRICT { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string LONG_DESC { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string LATITUDE { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string LONGITUDE { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string IMG_DT { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string IMG_KF { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string IMG_WJ { get; set; }
      /// <summary>
      /// 接口支付方式（前台现付：T，代收代付：S，预付：Y）
      /// </summary>
      public string PAYMENT_METHOD { get; set; }

      public enum Star
      {
         //  表示1-5星级：
         _1S = 1,
         _2S =2,
         _3S =3,
         _4S =4,
         _5S =5,
         //表示1-5准星级：
         _1A = 6,
         _2A = 7,
         _3A = 8,
         _4A = 9,
         _5A = 10,
      }
   }
}
