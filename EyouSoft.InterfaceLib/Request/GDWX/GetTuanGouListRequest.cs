using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.InterfaceLib.Models.GDWX;

namespace EyouSoft.InterfaceLib.Request.GDWX
{
    public class GetTuanGouListRequest : RequestBase
    {
        /// <summary>
        /// 每页条数 
        /// </summary>
        public int pagesize;
        /// <summary>
        /// 页码 
        /// </summary>
        public int page;
    }
}
