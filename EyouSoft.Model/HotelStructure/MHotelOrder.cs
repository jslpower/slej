using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.Enum;
using EyouSoft.Model.Enum.ScenicStructure;
using Linq.ORM;
using Linq.ORM.Attribute;
using Linq.Web.Html.Interface;
namespace EyouSoft.Model.HotelStructure
{
   /// <summary>
   /// 酒店系统订单信息
   /// </summary>
   [Table("tbl_HotelOrder")]
   public class MHotelOrder
   {
      public MHotelOrder() { }
      /// <summary>
      /// 订单编号（平台）
      /// </summary>
      [PrimaryKey]
      public string OrderId { get; set; }
      /// <summary>
      /// 酒店编号
      /// </summary>
      public string HotelId { get; set; }
      /// <summary>
      /// 酒店
      /// </summary>
      [ColumnIgnore]
      public string HotelName { get; set; }
      /// <summary>
      /// 星级代码
      /// </summary>
      [ColumnIgnore]
      public EyouSoft.Model.Enum.HotelStar? Star { get; set; }
      /// <summary>
      /// 房型编号
      /// </summary>
      public string RoomTypeId { get; set; }
      /// <summary>
      /// 房型名称
      /// </summary>
      [ColumnIgnore]
      public string RoomName { get; set; }
      /// <summary>
      /// 订单号
      /// </summary>
      public string OrderCode { get; set; }
      /// <summary>
      /// 房间数
      /// </summary>
      public int RoomCount { get; set; }
      /// <summary>
      /// 入住时间
      /// </summary>
      [ValueFormatter(typeof(DefaultDateTimeFormat))]
      public DateTime CheckInDate { get; set; }
      /// <summary>
      /// 离店时间
      /// </summary>
      [ValueFormatter(typeof(DefaultDateTimeFormat))]
      public DateTime CheckOutDate { get; set; }
      /// <summary>
      /// 总房价
      /// </summary>
      public decimal TotalAmount { get; set; }
      /// <summary>
      /// 联系人姓名
      /// </summary>
      public string ContactName { get; set; }
      /// <summary>
      /// 联系人手机
      /// </summary>
      public string ContactMobile { get; set; }
      /// <summary>
      /// 备注
      /// </summary>
      public string Remark { get; set; }
      /// <summary>
      /// 支付方式
      /// </summary>
      public Payment PaymentType { get; set; }
      /// <summary>
      /// 支付状态
      /// </summary>
      public PaymentState PaymentState { get; set; }
      /// <summary>
      /// 订单状态
      /// </summary>
      public OrderState OrderState { get; set; }
      /// <summary>
      /// 订单来源
      /// </summary>
      public ScenicAreaOrderSource Source { get; set; }
      /// <summary>
      /// 会员编号
      /// </summary>
      public string OperatorId { get; set; }
      /// <summary>
      /// 操作员姓名
      /// </summary>
      [ColumnIgnore]
      public string OperatorName { get; set; }
      /// <summary>
      /// 操作人手机
      /// </summary>
      [ColumnIgnore]
      public string OperatorMobile { get; set; }
      /// <summary>
      /// 会员类型
      /// </summary>
      [ColumnIgnore]
      public MemberTypes UserType { get; set; }
      /// <summary>
      /// 添加时间
      /// </summary>
      public DateTime IssueTime { get; set; }
      /// <summary>
      /// 价格编号
      /// </summary>
      public int JiaGeId { get; set; }
      /// <summary>
      /// 单价
      /// </summary>
      public decimal DanJia { get; set; }
      /// <summary>
      /// 下单单位名称
      /// </summary>
      public string BuyCompanyName { get; set; }
      /// <summary>
      /// 分销商ID
      /// </summary>
      public string SellerID { get; set; }
      /// <summary>
      /// 接口订单ID
      /// </summary>
      public string InterfaceID { get; set; }
      /// <summary>
      /// 分销金额
      /// </summary>
      public decimal AgencyJinE { get; set; }
      /// <summary>
      /// 订单来源
      /// </summary>
      public OrderSite OrderSite {get;set;}
      /// <summary>
      /// 入住人联系集合
      /// </summary>
      [ColumnIgnore]
      public IList<MHotelOrderContact> OrderContact { get; set; }
   }



   /// <summary>
   /// 酒店系统订单查询实体
   /// </summary>
   public class MHotelOrderSeach
   {
      /// <summary>
      /// 酒店编号
      /// </summary>
      public string HotelId { get; set; }

      /// <summary>
      /// 酒店名称
      /// </summary>
      public string HotelName { get; set; }

      /// <summary>
      /// 房型名称
      /// </summary>
      public string RoomName { get; set; }

      /// <summary>
      /// 订单号
      /// </summary>
      public string OrderCode { get; set; }

      /// <summary>
      /// 总房价
      /// </summary>
      public decimal TotalAmount { get; set; }
      /// <summary>
      /// 预定开始时间
      /// </summary>
      public DateTime? BeginIssueTime { get; set; }

      /// <summary>
      /// 预定结束时间
      /// </summary>
      public DateTime? EndIssueTime { get; set; }

      /// <summary>
      /// 入住开始时间
      /// </summary>
      public DateTime? BeginCheckInDate { get; set; }

      /// <summary>
      /// 入住结束时间
      /// </summary>
      public DateTime? EndCheckInDate { get; set; }

      /// <summary>
      /// 离店开始时间
      /// </summary>
      public DateTime? BeginCheckOutDate { get; set; }

      /// <summary>
      /// 离店开始时间
      /// </summary>
      public DateTime? EndCheckOutDate { get; set; }

      /// <summary>
      /// 分销商id
      /// </summary>
      public string SellerID { get; set; }

      /// <summary>
      /// 分销金额
      /// </summary>
      public decimal AgencyJinE { get; set; }

      /// <summary>
      /// 下单人编号
      /// </summary>
      public string OperatorId { get; set; }

      /// <summary>
      /// 下单人
      /// </summary>
      public string OperatorName { get; set; }

      /// <summary>
      /// 订单来源
      /// </summary>
      public EyouSoft.Model.Enum.ScenicStructure.ScenicAreaOrderSource? Source { get; set; }

      /// <summary>
      /// 是否非会员查询
      /// </summary>
      public bool IsFeiHuiYuan { get; set; }
      /// <summary>
      /// 非会员查询-订单号
      /// </summary>
      public string FeiHuiYuanDingDanHao { get; set; }
      /// <summary>
      /// 非会员查询-姓名
      /// </summary>
      public string FeiHuiYuanXingMing { get; set; }
      /// <summary>
      /// 非会员查询-联系电话
      /// </summary>
      public string FeiHuiYuanDianHua { get; set; }
      /// <summary>
      /// 订单所属单位
      /// </summary>
      public string BuyCompanyName { get; set; }
   }
}
