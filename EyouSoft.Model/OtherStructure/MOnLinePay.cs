using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model
{
    /// <summary>
    /// 在线支付记录实体
    /// </summary>
    public class OnLinePayRecord
    {
        /// <summary>
        /// 对应的具体订单ID(如:团队订单ID,酒店订单ID,景点订单ID,租车订单ID,秒杀ID)
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        public OrderType OrderType { get; set; }
        /// <summary>
        /// 外部支付流水号(由我们传给支付接口的唯一订单号)
        /// </summary>
        public string OutTradeNo { get; set; }
        /// <summary>
        /// 支付接口的支付流水号(由支付接口传给我们的唯一订单号)
        /// </summary>
        public string TradeNo { get; set; }
        /// <summary>
        /// 支付金额
        /// </summary>
        public decimal Totalfee { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public PayType PayType { get; set; }
        /// <summary>
        /// 是否已支付
        /// </summary>
        public bool IsPay { get; set; }
        /// <summary>
        /// 支付成功时间
        /// </summary>
        public DateTime SuccessTime { get; set; }
    }

    /// <summary>
    /// 订单类型
    /// </summary>
    /// zhangzy  2011-1-27
    public enum OrderType
    {
        /// <summary>
        /// 团队订单 = 1
        /// </summary>
        Tour = 1,
        /// <summary>
        /// 酒店订单 = 2
        /// </summary>
        Hotel = 2,
        /// <summary>
        /// 景点订单 = 3
        /// </summary>
        Spot = 3,
        /// <summary>
        /// 签证订单
        /// </summary>
        QianZheng = 4,
        /// <summary>
        /// 机票订单
        /// </summary>
        JiPiao = 5
    }

    /// <summary>
    /// 支付方式
    /// </summary>
    public enum PayType
    {
        /// <summary>
        /// 支付宝 = 1
        /// </summary>
        Alipay = 1,
        /// <summary>
        /// 财付通 = 2
        /// </summary>
        Tenpay = 2,
        /// <summary>
        /// 通联支付
        /// </summary>
        AllInPay = 3
    }
}
