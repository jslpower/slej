using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.InterfaceLib.Models.GDWX;

namespace EyouSoft.InterfaceLib.Request.GDWX
{
    public class GetQianZhengDingDanXiangXiRequest : RequestBase
    {
        /// <summary>
        /// 订单 ID  1/2/3
        /// </summary>
        public string orderids;
    }
}
