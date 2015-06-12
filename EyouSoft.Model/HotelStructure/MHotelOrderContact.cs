using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.HotelStructure
{
   using System;
   using Linq.ORM.Attribute;
   using System.ComponentModel;
   /// <summary>
   /// 
   /// </summary>
   [Table("tbl_HotelOrderContact")]
   public class MHotelOrderContact
   {
      /// <summary>
      /// 联系人姓名
      /// </summary>
      public string ContactName { get; set; }
      /// <summary>
      /// 订单ID
      /// </summary>
      public string OrderId { get; set; }
      /// <summary>
      /// 身份证号
      /// </summary>
      public string CardNum { get; set; }
      /// <summary>
      /// 联系方式
      /// </summary>
      public string Mobile { get; set; }
      /// <summary>
      /// 
      /// </summary>
      [PrimaryKey]
      [Identity(Linq.ORM.IdentityType.Increment)]
      public int ID { get; set; }
   }
}
