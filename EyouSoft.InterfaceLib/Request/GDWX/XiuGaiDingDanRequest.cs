using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.InterfaceLib.Models.GDWX;

namespace EyouSoft.InterfaceLib.Request.GDWX
{
    /// <summary>
    /// 修改订单
    /// </summary>
    public class XiuGaiDingDanRequest : RequestBase
    {
        /// <summary>
        /// 订单号 
        /// </summary>
        public int orderid;
        /// <summary>
        /// 成人 
        /// </summary>
        public int num1;
        /// <summary>
        /// 儿童占床 
        /// </summary>
        public int num2;
        /// <summary>
        /// 儿童不占床 
        /// </summary>
        public int num3;
        /// <summary>
        /// 预订人姓名 
        /// </summary>
        public string order_name;
        /// <summary>
        /// 预订人手机号 
        /// </summary>
        public string order_tel;
        /// <summary>
        /// 预订人备注 
        /// </summary>
        public string order_content;
    }
}
