using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.InterfaceLib.GDWX.Interface.Enums;

namespace EyouSoft.InterfaceLib.Models.GDWX
{
    public class RequestBase
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
        ///  查询类型  linearealist(必须)
        /// </summary>
        public string querytype;
        /// <summary>
        /// 线路类型【1：出境 2：港澳 3：台湾 1,2,3：所有】
        /// </summary>
        public string type;
    }
}
