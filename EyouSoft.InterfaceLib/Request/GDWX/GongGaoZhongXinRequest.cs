using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.InterfaceLib.Models.GDWX;

namespace EyouSoft.InterfaceLib.Request.GDWX
{
    public class GongGaoZhongXinRequest : RequestBase
    {
        /// <summary>
        /// 类型  0,1,2
        ///0 全部，1 仅同行，
        ///2 仅直客
        ///要获取在同行显示的值要写成0,1直客0,2
        /// </summary>
        public string type;
        public int pagesize;
        public int page;
    }
}
