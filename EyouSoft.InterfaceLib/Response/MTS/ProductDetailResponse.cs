using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using EyouSoft.InterfaceLib.Models;
using EyouSoft.InterfaceLib.Models.MTS;

namespace EyouSoft.InterfaceLib.Response.MTS
{
   [XmlRoot("Response")]
   public class ProductDetailResponse : ResponseArray<ProductDetailResponse.item>
   {
      public class item
      {
         public int Id;
         public string Name;
         public string Unit;
         /// <summary>
         /// 最少购买数量
         /// </summary>
         public int LimitCount;
         /// <summary>
         /// 购买截止日期
         /// </summary>
         public DateTime RequireDate;
         /// <summary>
         /// 订单有效期说明
         /// </summary>
         public string OrderLimit;
         public string Description;
         /// <summary>
         /// 游客提示
         /// </summary>
         public string GuestPrompt;
         /// <summary>
         /// 门市价
         /// </summary>
         public double SalesPrice;
         /// <summary>
         /// 建议零售价
         /// </summary>
         public double RetailPrice;
         /// <summary>
         /// 结算价
         /// </summary>
         public double SettlementPrice;
         /// <summary>
         /// 退票价
         /// </summary>
         public double RefundPrice;
         /// <summary>
         /// 退票说明
         /// </summary>
         public string RefundDescription;
         /// <summary>
         /// 景区id
         /// </summary>
         public int ResourceId;
         /// <summary>
         /// 景区名称
         /// </summary>
         public string ResourceName;
         /// <summary>
         /// 所属地区
         /// </summary>
         public string ResourceArea;
         /// <summary>
         /// 景区资源类别 //2,4,12
         /// </summary>
         public string ResourceType;
         /// <summary>
         /// 级别
         /// </summary>
         public Grades ResourceLevel;
         /// <summary>
         /// 地址
         /// </summary>
         public string ResourceAddress;
         /// <summary>
         /// 景区说明
         /// </summary>
         public string ResourceDescription;
         /// <summary>
         ///   /// <summary>
         /// 帮助信息
         /// </summary>
         /// </summary>
         public string Help;
         /// <summary>
         /// 费用包含
         /// </summary>
         public string Services;
         /// <summary>
         /// 是否需要证件
         /// </summary>
         public Is IsCertificate;
         /// <summary>
         /// 产品类型
         /// </summary>
         public ChanPinLeiXing Type;
         /// <summary>
         /// 销售价
         /// </summary>
         public string price_xs;
      }
   }
}
