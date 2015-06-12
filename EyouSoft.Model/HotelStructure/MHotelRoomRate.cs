using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.HotelStructure
{
   using System;
   using Linq.ORM;
   using System.ComponentModel;
   using Linq.ORM.Attribute;
   /// <summary>
   /// 
   /// </summary>
   [Table("tbl_HotelRoomRate")]
   public class MHotelRoomRate2
   {
      /// <summary>
      /// 酒店价格编号
      /// </summary>
      [PrimaryKey]
      [Identity(IdentityType.Increment)]
      [DisplayName("酒店价格编号")]
      public int RoomRateId { get; set; }
      /// <summary>
      /// 酒店编号
      /// </summary>
      [DisplayName("酒店编号")]
      public string HotelId { get; set; }
      /// <summary>
      /// 房型编号
      /// </summary>
      [DisplayName("房型编号")]
      public string RoomTypeId { get; set; }
      /// <summary>
      /// 销售价，税前价格+其他费用（如服务费、税）
      /// </summary>
      [DisplayName("销售价，税前价格+其他费用（如服务费、税）")]
      public decimal AmountPrice { get; set; }
      /// <summary>
      /// 优惠价
      /// </summary>
      [DisplayName("优惠价")]
      public decimal PreferentialPrice { get; set; }
      /// <summary>
      /// 结算价
      /// </summary>
      [DisplayName("结算价")]
      public decimal SettlementPrice { get; set; }
      /// <summary>
      /// 开始日期
      /// </summary>
      [DisplayName("开始日期")]
      public DateTime StartDate { get; set; }
      /// <summary>
      /// 结束日期
      /// </summary>
      [DisplayName("结束日期")]
      public DateTime EndDate { get; set; }
      /// <summary>
      /// 原因
      /// </summary>
      [DisplayName("原因")]
      public string Reason { get; set; }
      /// <summary>
      /// 添加时间
      /// </summary>
      [DisplayName("添加时间")]
      public DateTime IssueTime { get; set; }
      /// <summary>
      /// 添加人
      /// </summary>
      [DisplayName("添加人")]
      public int OperatorId { get; set; }
      /// <summary>
      /// 房间数量
      /// </summary>
      [DisplayName("房间数量")]
      public int ShuLiang { get; set; }
      /// <summary>
      /// 剩余数量
      /// </summary>
      [DisplayName("剩余数量")]
      public int ShengYuShuLiang { get; set; }
      /// <summary>
      /// 所属价格计划（接口）
      /// </summary>
      [DisplayName("所属价格计划（接口）")]
      public string InterfaceID { get; set; }
      /// <summary>
      /// 供应商代码
      /// </summary>
      [DisplayName("供应商代码")]
      public string VenderCode { get; set; }
      /// <summary>
      /// 早餐供应（接口）
      /// </summary>
      [DisplayName("早餐供应（接口）")]
      public string Breakfast { get; set; }
      /// <summary>
      /// 计划名称（接口）
      /// </summary>
      [DisplayName("计划名称（接口）")]
      public string RoomRateName { get; set; }

      public string HotelCode { get; set; }
      public string RoomTypeCode { get; set; }
      public string Status { get; set; }
      public string CityCode { get; set; }
   }
}
