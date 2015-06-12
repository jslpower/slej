using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.OtherStructure
{

    public class BOnLinePay
    {
        private readonly EyouSoft.IDAL.IOnLinePay dal = new EyouSoft.DAL.DOnLinePay();
        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BOnLinePay() { }
        #endregion
        #region 成员方法
        /// <summary>
        /// 新增支付记录    
        /// </summary>
        /// <param name="model">信息实体</param>
        /// <returns></returns>
        public bool Add(EyouSoft.Model.OnLinePayRecord model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 判断订单有无支付成功
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <param name="orderType">订单类型</param>
        /// <returns></returns>
        public bool IsPaySuccess(string orderId, EyouSoft.Model.OrderType orderType)
        {
            return dal.IsPaySuccess(orderId, orderType);
        }
        /// <summary>
        /// 获取支付宝卖家账号
        /// </summary>
        /// <returns></returns>
        public string GetAlipayAccount()
        {
            return dal.GetAlipayAccount();
        }
        #endregion 成员方法
    }
}
