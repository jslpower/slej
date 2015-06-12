/*//机票-城市三字码信息业务实体 汪奇志 2013-11-05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.JiPiaoStructure
{
    /// <summary>
    /// 机票-城市三字码信息业务实体
    /// </summary>
    public class MJiPiaoSanZiMaInfo
    {
        /// <summary>
        /// 自增编号
        /// </summary>
        public int IdentityId { get; set; }
        /// <summary>
        /// 三字码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// 机场名称
        /// </summary>
        public string AirportName { get; set; }
        /// <summary>
        /// 省份名称
        /// </summary>
        public string ProvinceName { get; set; }
        /// <summary>
        /// 全拼
        /// </summary>
        public string PY1 { get; set; }
        /// <summary>
        /// 简拼
        /// </summary>
        public string PY2 { get; set; }
        /// <summary>
        /// 首字母
        /// </summary>
        public string PY3 { get; set; }
        /// <summary>
        /// 是否热点
        /// </summary>
        public bool IsReDian { get; set; }
    }
}
*/