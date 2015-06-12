using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model
{
   using System;
   using Linq.ORM;
   using System.ComponentModel;
   using Linq.ORM.Attribute;
   /// <summary>
   /// 
   /// </summary>
   [Table("tbl_HotelLandMark")]
   public class MHotelLandMark
   {
      /// <summary>
      /// 酒店编号
      /// </summary>
      [DisplayName("酒店编号")]
      public string HotelId { get; set; }
      /// <summary>
      /// 地标编号
      /// </summary>
      [DisplayName("地标编号")]
      public int LandMarkId { get; set; }
   }
}