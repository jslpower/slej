using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.OtherStructure
{
    /// <summary>
    /// 地标信息业务实体
    /// </summary>
    public class MDiBiaoInfo
    {
        /// <summary>
        /// 地标编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 地标名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 省份编号
        /// </summary>
        public int ProvinceId { get; set; }
        /// <summary>
        /// 城市编号
        /// </summary>
        public int CityId { get; set; }
        /// <summary>
        /// 县区编号
        /// </summary>
        public int DistrictId { get; set; }
        /// <summary>
        /// 省份名称(OUTPUT)
        /// </summary>
        public string ProvinceName { get; set; }
        /// <summary>
        /// 城市名称(OUTPUT)
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// 县区名称(OUTPUT)
        /// </summary>
        public string DistrictName { get; set; }

    }
}
