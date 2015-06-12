using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL
{
    public interface IOnLinePay
    {
        /// <summary>
        /// 新增支付记录
        /// </summary>
        /// <param name="model">信息实体</param>
        /// <returns></returns>
        bool Add(EyouSoft.Model.OnLinePayRecord model);
        /// <summary>
        /// 判断订单有无支付成功
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <param name="orderType">订单类型</param>
        /// <returns></returns>
        bool IsPaySuccess(string orderId, EyouSoft.Model.OrderType orderType);
        /// <summary>
        /// 获取支付宝卖家账号
        /// </summary>
        /// <returns></returns>
        string GetAlipayAccount();
    }
}
