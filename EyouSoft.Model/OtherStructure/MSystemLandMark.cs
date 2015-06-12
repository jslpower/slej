using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.OtherStructure
{
    public class MSystemLandMark
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 地标名称
        /// </summary>
        public string Por { get; set; }
        /// <summary>
        /// 城市编号
        /// </summary>
        public int CityId { get; set; }
        /// <summary>
        /// 三字码
        /// </summary>
        public string CityCode { get; set; }
    }
}
