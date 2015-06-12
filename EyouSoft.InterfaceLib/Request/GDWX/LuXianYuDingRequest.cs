using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.InterfaceLib.Enums.GDWX;
using EyouSoft.InterfaceLib.Models.GDWX;

namespace EyouSoft.InterfaceLib.Request.GDWX
{
    /// <summary>
    /// 路线预订请求
    /// </summary>
    public class LuXianYuDingRequest 
    {

        /// <summary>
        /// 用户编号  我们提供(必须)
        /// </summary>
        public string usercd;
        /// <summary>
        /// 授权码  我们提供(必须)
        /// </summary>
        public string authno;
        /// <summary>
        ///  查询类型  lineorder(必须)
        /// </summary>
        public string querytype;
        /// <summary>
        /// 发班 ID 
        /// </summary>
        public int tourid;
        /// <summary>
        /// 类型  1同行2会员3直客;1 和 2 必须要有用户名和密码
        /// </summary>
        public DengluLeiXing type;
        /// <summary>
        /// 用户名
        /// </summary>
        public string username;
        /// <summary>
        /// 密码 
        /// </summary>
        public string password;
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
