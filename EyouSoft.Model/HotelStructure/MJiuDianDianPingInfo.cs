using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.Enum.XianLuStructure;

namespace EyouSoft.Model.HotelStructure
{
    #region 酒店点评信息业务实体
    /// <summary>
    /// 酒店点评信息业务实体
    /// </summary>
    public class MJiuDianDianPingInfo
    {
        /// <summary>
        /// 点评编号
        /// </summary>
        public string DianPingId { get; set; }
        /// <summary>
        /// 酒店编号
        /// </summary>
        public string JiuDianId { get; set; }
        /// <summary>
        /// 酒店名称
        /// </summary>
        public string JiuDianName { get; set; }
        /// <summary>
        /// 入住时间
        /// </summary>
        public DateTime? RuZhuShiJian { get; set; }
        /// <summary>
        /// 卫生
        /// </summary>
        public DianPingStatus WeiSheng { get; set; }
        /// <summary>
        /// 服务
        /// </summary>
        public DianPingStatus FuWu { get; set; }
        /// <summary>
        /// 设施
        /// </summary>
        public DianPingStatus SheShi { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        public DianPingStatus WeiZhi { get; set; }
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

    #region 酒店点评查询信息业务实体
    /// <summary>
    /// 酒店点评查询信息业务实体
    /// </summary>
    public class MJiuDianDianPingChaXunInfo
    {
        public string JiuDianName { get; set; }
        public string OperatorName { get; set; }
        public DateTime? DPSTime { get; set; }
        public DateTime? DPETime { get; set; }
        public bool? IsShenHe { get; set; }
        public string OperatorId { get; set; }
        public string JiuDianId { get; set; }
    }
    #endregion
}
