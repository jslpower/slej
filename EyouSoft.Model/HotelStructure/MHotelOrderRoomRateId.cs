using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.HotelStructure
{
   using System;
   using Linq.ORM.Attribute;
   using System.ComponentModel;
   using Linq.ORM;
   /// <summary>
   /// 
   /// </summary>
   [Table("tbl_HotelOrderRoomRateId")]
   public class MHotelOrderRoomRateId
   {
      /// <summary>
      /// 
      /// </summary>
      [PrimaryKey]
      [Identity(IdentityType.Increment)]
      public int OrId { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string HotelId { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string OrderId { get; set; }
      /// <summary>
      /// 
      /// </summary>
      public string RoomRateIds { get; set; }
   }
}
