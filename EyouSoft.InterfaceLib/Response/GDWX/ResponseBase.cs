using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.InterfaceLib.Enums.GDWX;

namespace EyouSoft.InterfaceLib.Response.GDWX
{
    public class ResponseBase
    {
        /// <summary>
        /// 接口调用状态  1 成功，其它失败
        /// </summary>
        public Success success;
        /// <summary>
        /// 接口调用信息  出错信息或者成功信息
        /// </summary>
        public string msg;
    }
}
