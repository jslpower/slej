using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.Enum.XianLuStructure;

namespace EyouSoft.Model.ScenicStructure
{
    #region 景点点评信息业务实体
    /// <summary>
    /// 景点点评信息业务实体
    /// </summary>
    public class MJingDianDianPingInfo
    {
        /// <summary>
        /// 点评编号
        /// </summary>
        public string DianPingId { get; set; }
        /// <summary>
        /// 景点编号
        /// </summary>
        public string JingDianId { get; set; }
        /// <summary>
        /// 景点名称
        /// </summary>
        public string JingDianName { get; set; }
        /// <summary>
        /// 浏览时间
        /// </summary>
        public DateTime? YouLanShiJian { get; set; }
        /// <summary>
        /// 购票张数
        /// </summary>
        public int ShuLiang { get; set; }
        /// <summary>
        /// 景区
        /// </summary>
        public DianPingStatus JingQu { get; set; }
        /// <summary>
        /// 预订
        /// </summary>
        public DianPingStatus YuDing { get; set; }
        /// <summary>
        /// 满意度
        /// </summary>
        public decimal ManYiDu { get; set; }
        /// <summary>
        /// 点评方式
        /// </summary>
        public DianPingType DianPingFangShi { get; set; }
        /// <summary>
        /// 点评内容
        /// </summary>
        public string DianPingNeiRong { get; set; }
        /// <summary>
        /// 排序方式
        /// </summary>
        public int SortId { get; set; }
        /// <summary>
        /// 是否审核
        /// </summary>
        public bool IsCheck { get; set; }
        /// <summary>
        /// 操作员编号
        /// </summary>
        public string OperatorId { get; set; }
        /// <summary>
        /// 操作员姓名
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 点评时间
        /// </summary>
        public DateTime DianPingShiJian { get; set; }
    }
    #endregion

    #region 景点点评查询信息业务实体
    /// <summary>
    /// 景点点评查询信息业务实体
    /// </summary>
    public class MJingDianDianPingChaXunInfo
    {
        public string JingDianName { get; set; }
        public string OperatorName { get; set; }
        public DateTime? DPSTime { get; set; }
        public DateTime? DPETime { get; set; }
        public bool? IsShenHe { get; set; }
        public string OperatorId { get; set; }
        public string JingDianId { get; set; }
    }
    #endregion
}
