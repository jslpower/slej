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
   [Table("Hotel_City")]
   public class Hotel_City
   {
      /// <summary>
      /// 
      /// </summary>
      [PrimaryKey]
      public string CITY_CODE { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string CITY_NAME { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string CITY_PINYIN { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string CITY_PYFW { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string COUNTRY_CODE { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string PROVINCE { get; set; }
   }
}
