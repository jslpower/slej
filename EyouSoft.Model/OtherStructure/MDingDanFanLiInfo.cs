//订单返利信息业务实体 汪奇志 2014-11-06
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.OtherStructure
{
    #region 订单返利信息业务实体
    /// <summary>
    /// 订单返利信息业务实体
    /// </summary>
    public class MDingDanFanLiInfo
    {
        /// <summary>
        /// 返利编号
        /// </summary>
        public string FanLiId { get; set; }
        /// <summary>
        /// 会员编号
        /// </summary>
        public string HuiYuanId { get; set; }
        /// <summary>
        /// 会员代理商编号（OUTPUT）
        /// </summary>
        public string HuiYuanDaiLiShangId { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string DingDanId { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        public EyouSoft.Model.OtherStructure.DingDanType DingDanLeiXing { get; set; }
        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal DingDanJinE { get; set; }
        /// <summary>
        /// 分销金额
        /// </summary>
        public decimal FenXiaoJinE { get; set; }
        /// <summary>
        /// 返利金额
        /// </summary>
        public decimal FanLiJinE { get; set; }
        /// <summary>
        /// 返利交易号（OUTPUT）
        /// </summary>
        public string FanLiJiaoYiHao { get; set; }
        /// <summary>
        /// 返利时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 会员余额（OUTPUT）
        /// </summary>
        public decimal HuiYuanYuE { get; set; }
        /// <summary>
        /// 账户余额（系统）（OUTPUT）
        /// </summary>
        public decimal YuE { get; set; }
        /// <summary>
        /// 会员姓名（OUTPUT）
        /// </summary>
        public string HuiYuanName { get; set; }
        /// <summary>
        /// 会员代理商网站名称（OUTPUT）
        /// </summary>
        public string HuiYuanDaiLiShangWangZhanName { get; set; }
        /// <summary>
        /// 会员用户名
        /// </summary>
        public string HuiYuanYongHuMing { get; set; }
    }
    #endregion

    #region 订单返利信息查询业务实体
    /// <summary>
    /// 订单返利信息查询业务实体
    /// </summary>
    public class MDingDanFanLiChaXunInfo
    {
        /// <summary>
        /// 会员编号
        /// </summary>
        public string HuiYuanId { get; set; }
        /// <summary>
        /// 返利时间-起
        /// </summary>
        public DateTime? FanLiShiJian1 { get; set; }
        /// <summary>
        /// 返利时间-止
        /// </summary>
        public DateTime? FanLiShiJian2 { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        public EyouSoft.Model.OtherStructure.DingDanType? DingDanLeiXing { get; set; }
    }
    #endregion


}
