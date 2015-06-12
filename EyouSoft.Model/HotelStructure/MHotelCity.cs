using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.ORM.Attribute;
using Linq.ORM;

namespace EyouSoft.Model.HotelStructure
{
   /// <summary>
   /// //酒店城市信息
   /// </summary>
   [Table("tbl_HotelCity")]
   public class MHotelCity
   {
      public MHotelCity() { }
      /// <summary>
      /// 编号
      /// </summary>
      [PrimaryKey]
      [Identity(IdentityType.Increment)]
      public int ID { get; set; }
      /// <summary>
      /// 城市名称
      /// </summary>
      public string CityName { get; set; }
      /// <summary>
      /// 全拼
      /// </summary>
      public string Spelling { get; set; }
      /// <summary>
      /// 简拼
      /// </summary>
      public string SimpleSpelling { get; set; }
      /// <summary>
      /// 三字码
      /// </summary>
      public string CityCode { get; set; }
      /// <summary>
      /// 是否常用
      /// </summary>
      public bool IsHot { get; set; }
   }
}
