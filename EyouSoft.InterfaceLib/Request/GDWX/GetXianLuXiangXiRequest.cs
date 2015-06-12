using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.InterfaceLib.Models.GDWX;

namespace EyouSoft.InterfaceLib.Request.GDWX
{
    /// <summary>
    /// 获取线路详情request
    /// </summary>
    public class GetXianLuXiangXiRequest : RequestBase
    {
        /// <summary>
        /// 线路ID集合  1/2/3 多条用/隔开， 一次最多 20 个
        /// </summary>
        public string lineids;
    }
}
