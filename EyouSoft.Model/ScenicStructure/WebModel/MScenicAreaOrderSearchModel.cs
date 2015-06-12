using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.Bussiness;

namespace EyouSoft.Model.ScenicStructure.WebModel
{
   /// <summary>
   /// 景区订单
   /// </summary>
    public class MScenicAreaOrderSearchModel 
   {
        public SearchModel SearchInfo { get; set; }
        /// <summary>
        /// 订单Id
        /// </summary>
        public string OrderId { get; set; }
      /// <summary>
      /// 订单编号
      /// </summary>
      public string OrderCode { get; set; }

     
      /// <summary>
      /// 订单状态
      /// </summary>
      public EyouSoft.Model.Enum.XianLuStructure.OrderStatus? Status { get; set; }

      /// <summary>
      /// 景区名称
      /// </summary>
      public string ScenicName { get; set; }

      /// <summary>
      /// 门票类型名称
      /// </summary>
      public string ScenicTicketTypeName { get; set; }

      /// <summary>
      /// 下单开始时间
      /// </summary>
      public DateTime? BeginTime { get; set; }

      /// <summary>
      /// 下单结束时间
      /// </summary>
      public DateTime? EndTime { get; set; }

      /// <summary>
      /// 用户编号
      /// </summary>
      public string UserId { get; set; }

      /// <summary>
      /// 用户编号
      /// </summary>
      public string SellerID { get; set; }

      /// <summary>
      /// 订单来源
      /// </summary>
      public EyouSoft.Model.Enum.ScenicStructure.ScenicAreaOrderSource? Source { get; set; }

      /// <summary>
      /// 景点编号
      /// </summary>
      public string JingDianId { get; set; }

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
