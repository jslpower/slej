using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.InterfaceLib.Enums.GDWX;
using EyouSoft.InterfaceLib.Models.GDWX;

namespace EyouSoft.InterfaceLib.Request.GDWX
{
    public class QianZhengYuDingRequest : RequestBase
    {
        /// <summary>
        /// 签证 ID 
        /// </summary>
        public int visaid;
        /// <summary>
        /// 类型 
        /// </summary>
        public DengluLeiXing type;
        /// <summary>
        /// 用户名 直客不需要
        /// </summary>
        public string username;
        /// <summary>
        /// 密码  直客不需要
        /// </summary>
        public string password;
        /// <summary>
        /// 出发日期
        /// </summary>
        public DateTime days;
        /// <summary>
        /// 成人 
        /// </summary>
        public int num1;
        /// <summary>
        /// 儿童 
        /// </summary>
        public int num2;
        /// <summary>
        /// 预订人姓名 
        /// </summary>
        public string order_name;
        /// <summary>
        /// 预订人电话 
        /// </summary>
        public string order_tel;
        /// <summary>
        /// 备注 
        /// </summary>
        public string order_content;
    }
}
