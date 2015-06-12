using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.MemberStructure
{
    /// <summary>
    /// 地址
    /// </summary>
    public class MDiZhi
    {
        /// <summary>
        /// 地址编号
        /// </summary>
        public int AddressID { get; set; }
        /// <summary>
        /// 省份编号
        /// </summary>
        public int ProvinceID { get; set; }
        /// <summary>
        /// 省份名称
        /// </summary>
        public string ProvinceName { get; set; }
        /// <summary>
        /// 城市编号
        /// </summary>
        public int CityID { get; set; }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// 县区编号
        /// </summary>
        public int DistrictID { get; set; }
        /// <summary>
        /// 县区名称
        /// </summary>
        public string DistrictName { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string AddressInfo { get; set; }
        /// <summary>
        /// 添加人编号
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 添加人姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; }
        /// <summary>
        /// 是否默认
        /// </summary>
        public bool IsDefault { get; set; }
    }

    public class MDiZhiSer
    {
        /// <summary>
        /// 添加人编号
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 是否默认
        /// </summary>
        public bool IsDefault { get; set; }
    }
}
