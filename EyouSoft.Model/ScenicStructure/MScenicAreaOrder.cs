using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.Enum.ScenicStructure;
using EyouSoft.Model.Enum.XianLuStructure;
using Linq.Web.Html.Interface;
using Linq.ORM;
using Linq.ORM.Attribute;
using System.ComponentModel;
using EyouSoft.Model.Enum;

namespace EyouSoft.Model.ScenicStructure
{
   /// <summary>
   /// 景区订单
   /// </summary>
   [Table("tbl_ScenicAreaOrder")]
   public class MScenicAreaOrder
   {
      /// <summary>
      /// 订单编号
      /// </summary>
      [PrimaryKey]
      public string OrderId { get; set; }
      /// <summary>
      /// 订单编号
      /// </summary>
      public string OrderCode { get; set; }
      /// <summary>
      /// 景区编号
      /// </summary>
      public string ScenicId { get; set; }
      /// <summary>
      /// 门票编号
      /// </summary>
      public string TicketsId { get; set; }
      /// <summary>
      /// 订单总金额(门票单价 * 数量)
      /// </summary>
      public decimal Price { get; set; }
      /// <summary>
      /// 门票数量
      /// </summary>
      public int Num { get; set; }
      /// <summary>
      /// 订单状态
      /// </summary>
      public OrderStatus Status { get; set; }
      /// <summary>
      /// 订单来源
      /// </summary>
      public ScenicAreaOrderSource Source { get; set; }
      /// <summary>
      /// 付款状态
      /// </summary>
      public FuKuanStatus FuKuanStatus { get; set; }
      /// <summary>
      /// 下单人编号
      /// </summary>
      public string OperatorId { get; set; }
      /// <summary>
      /// 下单时间
      /// </summary>
      public DateTime IssueTime { get; set; }

      /// <summary>
      /// 取票人
      /// </summary>
      public string ContactName { get; set; }

      /// <summary>
      /// 取票人电话
      /// </summary>
      public string ContactTel { get; set; }

      /// <summary>
      /// 分销金额
      /// </summary>
      public decimal AgencyJinE { get; set; }
      /// <summary>
      /// 备注
      /// </summary>
      public string Remark { get; set; }
      /// <summary>
      /// 下单单位名称
      /// </summary>
      public string BuyCompanyName { get; set; }

      /// <summary>
      /// 景区名称
      /// </summary>
      [ColumnIgnore]
      public string ScenicName { get; set; }

      /// <summary>
      /// 门票类型名称
      /// </summary>
      [ColumnIgnore]
      public string TypeName { get; set; }
      /// <summary>
      /// 预订人姓名
      /// </summary>
      public string OperatorName { get; set; }
      /// <summary>
      /// 预订人手机
      /// </summary>
      public string OperatorMobile { get; set; }
      /// <summary>
      /// 预定人会员类型
      /// </summary>
      [ColumnIgnore]
      public EyouSoft.Model.Enum.MemberTypes UserType { get; set; }
      /// <summary>
      /// 出发日期
      /// </summary>
      [ValueFormatter(typeof(DefaultDateTimeFormat))]
      public DateTime ChuFaRiQi { get; set; }
      /// <summary>
      /// 分销商ID
      /// </summary>
      [DisplayName("分销商ID")]
      public string SellerID { get; set; }

      public string ApiOrderId { get; set; }
       /// <summary>
       /// 订单来源
       /// </summary>
      public OrderSite OrderSite { get; set; }
   }
}
