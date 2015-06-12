using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.InterfaceLib.Models.GDWX
{
    /// <summary>
    /// 行程
    /// </summary>
    public class XingCheng
    {
        /// <summary>
        /// 序号 
        /// </summary>
        public int id;
        /// <summary>
        /// 线路ｉｄ
        /// </summary>
        public int line_id;
        /// <summary>
        /// 第几天
        /// </summary>
        public int day_num;
        /// <summary>
        /// 标题 
        /// </summary>
        public string title;
        /// <summary>
        /// 航班 
        /// </summary>
        public string flights;
        /// <summary>
        /// 交通工具 
        /// </summary>
        public int transport;
        /// <summary>
        /// 交通工具 
        /// </summary>
        public int transport1;
        /// <summary>
        /// 是否包含早餐 
        /// </summary>
        public int zaocan;
        /// <summary>
        /// 是否包含午餐 
        /// </summary>
        public int wucan;
        /// <summary>
        /// 是否包含晚餐 
        /// </summary>
        public int wancan;
        /// <summary>
        /// 酒店 test
        /// </summary>
        public string hotel;
        /// <summary>
        /// 说明 test
        /// </summary>
        public string content;
    }
}
