using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.InterfaceLib.Enums.GDWX;
using System.ComponentModel;
using EyouSoft.InterfaceLib.Models.GDWX;

namespace EyouSoft.InterfaceLib.Request.GDWX
{
    public class GetXianLuListRequest : RequestBase
    {
        /// <summary>
        /// 线路标题  线路标题模糊搜索
        /// </summary>
        public string title;
        /// <summary>
        ///  每页条数,默认 20
        /// </summary>
        [DefaultValue(20)]
        public int pagesize;
        /// <summary>
        /// 页码  默认 1
        /// </summary>
        [DefaultValue(1)]
        public int page;
        /// <summary>
        /// 是否调取发班 boolean 默认 false
        /// </summary>
        public Is has_tour;
        /// <summary>
        /// 是否调取行程 boolean 默认 false
        /// </summary>
        public Is has_itinerary;
    }
}
