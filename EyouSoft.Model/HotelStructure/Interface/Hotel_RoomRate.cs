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
   [Table("Hotel_RoomRate")]
   public class Hotel_RoomRate
   {
      /// <summary>
      /// 酒店代码
      /// </summary>
      [PrimaryKey]
      [DisplayName("酒店代码")]
      public string HOTEL_CODE { get; set; }
      /// <summary>
      /// 房型代码
      /// </summary>
      [PrimaryKey]
      [DisplayName("房型代码")]
      public string ROOM_TYPE_CODE { get; set; }
      /// <summary>
      /// 价格计划代码
      /// </summary>
      [PrimaryKey]
      [DisplayName("价格计划代码")]
      public string RATE_PLAN_CODE { get; set; }
      /// <summary>
      /// 开始时间
      /// </summary>
      [PrimaryKey]
      [DisplayName("开始时间")]
      public DateTime START_DATE { get; set; }
      /// <summary>
      /// 供应商代码
      /// </summary>
      [PrimaryKey]
      [DisplayName("供应商代码")]
      public string VENDOR_CODE { get; set; }
      /// <summary>
      /// 价格计划名称
      /// </summary>
      [DisplayName("价格计划名称")]
      public string RATE_PLAN_NAME { get; set; }
      /// <summary>
      /// 支付方式
      /// </summary>
      [DisplayName("支付方式")]
      public string PAYMENT_METHOD { get; set; }
      /// <summary>
      /// 价格
      /// </summary>
      [DisplayName("价格")]
      public string AMOUNT_PRICE { get; set; }
      /// <summary>
      /// 货币代码
      /// </summary>
      [DisplayName("货币代码")]
      public string CURRENCY { get; set; }
      /// <summary>
      /// 保留
      /// </summary>
      [DisplayName("保留")]
      public string FEE_PERCENT { get; set; }
      /// <summary>
      /// 结束时间
      /// </summary>
      [DisplayName("结束时间")]
      public string END_DATE { get; set; }
      /// <summary>
      /// 早餐
      /// </summary>
      [DisplayName("早餐")]
      public string FREE_MEAL { get; set; }
      /// <summary>
      /// 门市价
      /// </summary>
      [DisplayName("门市价")]
      public string DISPLAY_PRICE { get; set; }
      /// <summary>
      /// 状态
      /// </summary>
      [DisplayName("状态")]
      public string STATUS { get; set; }
      /// <summary>
      /// 是否为自签酒店
      /// </summary>
      [DisplayName("是否为自签酒店")]
      public string IS_SIGN { get; set; }
      /// <summary>
      /// 时间戳
      /// </summary>
      [DisplayName("时间戳")]
      public decimal? TIME_STAMP { get; set; }
      /// <summary>
      /// 时间戳2
      /// </summary>
      [DisplayName("时间戳2")]
      public decimal? LOAD_TIME { get; set; }
   }
}
