using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.InterfaceLib.Models.GDWX
{
    public class Company
    {
        /// <summary>
        /// 公司 ID 
        /// </summary>
        public int id;
        /// <summary>
        /// 公司名称 
        /// </summary>
        public string title;
        /// <summary>
        /// 省 
        /// </summary>
        public int province_id;
        /// <summary>
        /// 市 
        /// </summary>
        public int city_id;
        /// <summary>
        /// 区 
        /// </summary>
        public int area_id;
        /// <summary>
        /// 地址 
        /// </summary>
        public string address;
    }
}
