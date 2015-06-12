using System;
using Linq.ORM.Attribute;

namespace EyouSoft.Model.ScenicStructure
{


   /// <summary>
   /// 景区门票
   /// </summary>
   [Table("tbl_ScenicTickets")]
   public class MScenicTickets
   {
      /// <summary>
      /// 门票编号
      /// </summary>
      [PrimaryKey]
      public string TicketsId { get; set; }
      /// <summary>
      /// 景区编号(不使用)
      /// </summary>
      public string ScenicId { get; set; }
      /// <summary>
      /// 门票类型名称
      /// </summary>
      public string TypeName { get; set; }
      /// <summary>
      /// 英文名称
      /// </summary>
      public string EnName { get; set; }
      /// <summary>
      /// 门市价
      /// </summary>
      public decimal RetailPrice { get; set; }
      /// <summary>
      /// 网站优惠价(网络销售价)
      /// </summary>
      public decimal WebsitePrices { get; set; }
      /// <summary>
      /// 市场限制最低价
      /// </summary>
      public decimal MarketPrice { get; set; }
      /// <summary>
      /// 同行分销价（结算价）
      /// </summary>
      public decimal DistributionPrice { get; set; }
      /// <summary>
      /// 最少限制（张/套）
      /// </summary>
      public int Limit { get; set; }
      /// <summary>
      /// 票价有效时间_始
      /// </summary>
      public DateTime? StartTime { get; set; }
      /// <summary>
      /// 票价有效时间_止
      /// </summary>
      public DateTime? EndTime { get; set; }
      /// <summary>
      /// 门票说明
      /// </summary>
      public string Description { get; set; }
      /// <summary>
      /// 同业销售须知 （只有同业分销商能看到）
      /// </summary>
      public string SaleDescription { get; set; }
      /// <summary>
      /// 状态（上架，下架）
      /// </summary>
      public EyouSoft.Model.Enum.ScenicStructure.ScenicTicketsStatus? Status { get; set; }
      /// <summary>
      /// 自定义排序
      /// </summary>
      public int CustomOrder { get; set; }
      /// <summary>
      /// 发布人
      /// </summary>
      public string OperatorId { get; set; }
      /// <summary>
      /// 发布时间
      /// </summary>
      public DateTime IssueTime { get; set; }
      /// <summary>
      /// 最后修改时间
      /// </summary>
      public DateTime LastUpdateTime { get; set; }
      /// <summary>
      /// 景区名称
      /// </summary>
      [ColumnIgnore]
      public string ScenicName { get; set; }
      /// <summary>
      /// 是否同行分销
      /// </summary>
      public bool IsFenXiao { get; set; }
      /// <summary>
      /// 门票数量
      /// </summary>
      public int Number { get; set; }
      /// <summary>
      /// 接口票Id(接口)
      /// </summary>
      public string InterafaceTicketId { get; set; }
      /// <summary>
      /// 景区id(接口)
      /// </summary>
      public string InterafaceScenicId { get; set; }
   }

   /// <summary>
   /// 景区门票
   /// </summary>
   public class MScenicTicketsSearch
   {
      /// <summary>
      /// 景区编号
      /// </summary>
      public string ScenicId { get; set; }
      /// <summary>
      /// 门票类型名称
      /// </summary>
      public string TypeName { get; set; }
      /// <summary>
      /// 英文名称
      /// </summary>
      public string EnName { get; set; }
      /// <summary>
      /// 票价有效时间_始
      /// </summary>
      public DateTime? StartTimeS { get; set; }
      /// <summary>
      /// 票价有效时间_始
      /// </summary>
      public DateTime? StartTimeE { get; set; }
      /// <summary>
      /// 票价有效时间_止
      /// </summary>
      public DateTime? EndTimeS { get; set; }
      /// <summary>
      /// 票价有效时间_止
      /// </summary>
      public DateTime? EndTimeE { get; set; }
      /// <summary>
      /// 状态（上架，下架）
      /// </summary>
      public EyouSoft.Model.Enum.ScenicStructure.ScenicTicketsStatus? Status { get; set; }
      /// <summary>
      /// 最后修改时间
      /// </summary>
      public DateTime? LastUpdateTimeS { get; set; }
      /// <summary>
      /// 最后修改时间
      /// </summary>
      public DateTime? LastUpdateTimeE { get; set; }
      /// <summary>
      /// 景区名称
      /// </summary>
      public string ScenicName { get; set; }
      /// <summary>
      /// 是否同行分销
      /// </summary>
      public bool? IsFenXiao { get; set; }
   }
}
