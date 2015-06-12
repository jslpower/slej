using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.InterfaceLib.Enums.GDWX;
using EyouSoft.InterfaceLib.Models.GDWX;

namespace EyouSoft.InterfaceLib.Response.GDWX
{
    public class GongGaoZhongXinResponse : ResponseBase
    {
        /// <summary>
        /// 总条数
        /// </summary>
        public int num_rows;
        /// <summary>
        /// 总页数
        /// </summary>
        public int page_count;
        /// <summary>
        /// 当前页
        /// </summary>
        public int page;
        /// <summary>
        /// 每页条数
        /// </summary>
        public int pagesize;

        public GongGaoZhongXin[] data;
    }

}
