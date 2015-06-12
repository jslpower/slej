using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.InterfaceLib.Request.GDWX;
using EyouSoft.InterfaceLib.Models.GDWX;

namespace EyouSoft.InterfaceLib.Response.GDWX
{
    /// <summary>
    /// 路线预订响应
    /// </summary>
    public class LuXianYuDingResponse : ResponseBase
    {
        public YuDingXinXi[] data;
    }
}