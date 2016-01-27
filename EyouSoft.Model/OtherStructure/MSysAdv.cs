using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.Enum;

namespace EyouSoft.Model
{
    /// <summary>
    /// 站点广告
    /// </summary>
    public class MSysAdv
    {
        public MSysAdv() { }

        /// <summary>
        /// 广告编号
        /// </summary>
        public int AdvID { get; set; }
        /// <summary>
        /// 广告位置编号
        /// </summary>
        public AdvArea AreaId { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string ImgPath { get; set; }
        /// <summary>
        /// 广告链接地址
        /// </summary>
        public string AdvLink { get; set; }
        /// <summary>
        /// 广告标题
        /// </summary>
        public string AdvTitle { get; set; }
        /// <summary>
        /// 点击量
        /// </summary>
        public int Click { get; set; }
        /// <summary>
        /// 排序编号
        /// </summary>
        public int SortId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 代理商id
        /// </summary>
        public string AgencyId { get; set; }

    }

    /// <summary>
    /// 站点广告查询实体
    /// </summary>
    public class MSearchSysAdv
    {
        /// <summary>
        /// 广告位置编号
        /// </summary>
        public AdvArea[] AreaIds { get; set; }
        /// <summary>
        /// 广告标题
        /// </summary>
        public string AdvTitle { get; set; }
        /// <summary>
        /// 代理商Id
        /// </summary>
        public string AgencyId { get; set; }
        /// <summary>
        /// 公司简称
        /// </summary>
        public string CompanyJC { get; set; }
        /// <summary>
        /// 网点名称
        /// </summary>
        public string WebSiteName { get; set; }
    }
}
