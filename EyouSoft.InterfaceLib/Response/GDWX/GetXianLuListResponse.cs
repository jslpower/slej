using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.InterfaceLib.Models.GDWX;

namespace EyouSoft.InterfaceLib.Response.GDWX
{
    public class GetXianLuListResponse : ResponseBase
    {
        /// <summary>
        /// 数据总条数
        /// </summary>
        public int num_rows{ get; set; }
        /// <summary>
        /// 数据总页数 
        /// </summary>
        public int page_count{ get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int page{ get; set; }
        /// <summary>
        /// 每页条数
        /// </summary>
        public int pagesize{ get; set; }
        /// <summary>
        ///接口调用结果具体数据
        /// </summary>
        public List<XianLu> data{ get; set; }
    }
}
