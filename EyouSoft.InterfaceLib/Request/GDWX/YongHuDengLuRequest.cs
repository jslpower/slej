using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.InterfaceLib.Enums.GDWX;
using EyouSoft.InterfaceLib.Models.GDWX;

namespace EyouSoft.InterfaceLib.Request.GDWX
{
    /// <summary>
    /// 登录请求
    /// </summary>
    public class YongHuDengLuRequest : RequestBase
    {
        /// <summary>
        /// 登录用户类型
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
    }
}
