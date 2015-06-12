using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.OtherStructure
{
    #region 推广返利信息业务实体
    /// <summary>
    /// 推广返利信息业务实体
    /// </summary>
    public class MTuiGuangFanLiInfo
    {
        /// <summary>
        /// 返利编号
        /// </summary>
        public string FanLiId { get; set; }
        /// <summary>
        /// 推广编号
        /// </summary>
        public string TuiGuangId { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string DingDanId { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        public EyouSoft.Model.OtherStructure.DingDanType DingDanLeiXing { get; set; }
        /// <summary>
        /// 下单人编号
        /// </summary>
        public string XiaDanRenId { get; set; }
        /// <summary>
        /// 返利比例（OUTPUT）
        /// </summary>
        public decimal FanLiBiLi { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }

        /// <summary>
        /// 返利状态（OUTPUT）
        /// </summary>
        public EyouSoft.Model.Enum.FanLianMengTuiGuangFanLiStatus FanLiStatus { get; set; }
        /// <summary>
        /// 订单金额（OUTPUT）
        /// </summary>
        public decimal DingDanJinE { get; set; }
        /// <summary>
        /// 返利金额（OUTPUT）
        /// </summary>
        public decimal FanLiJinE { get; set; }
        /// <summary>
        /// 订单状态（OUTPUT）
        /// </summary>
        public EyouSoft.Model.Enum.XianLuStructure.OrderStatus DingDanStatus { get; set; }
        /// <summary>
        /// 订单付款状态（OUTPUT）
        /// </summary>
        public EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus DingDanFuKuanStatus { get; set; }
        /// <summary>
        /// 下单人姓名（OUTPUT）
        /// </summary>
        public string XiaDanRenName { get; set; }
        /// <summary>
        /// 下单时间（OUTPUT）
        /// </summary>
        public DateTime XiaDanShiJian { get; set; }
        /// <summary>
        /// 返利时间（OUTPUT）
        /// </summary>
        public DateTime FanLiShiJian { get; set; }
        /// <summary>
        /// 订单代理商编号（OUTPUT）
        /// </summary>
        public string DingDanDaiLiShangId { get; set; }
        /// <summary>
        /// 订单代理商网站名称（OUTPUT）
        /// </summary>
        public string DingDanDaiLiShangWangZhanName { get; set; }
        /// <summary>
        /// 推广人会员编号（OUTPUT）
        /// </summary>
        public string TuiGuangRenHuiYuanId { get; set; }
        /// <summary>
        /// 推广人会员姓名（OUTPUT）
        /// </summary>
        public string TuiGuangRenName { get; set; }

        /// <summary>
        /// 产品名称（OUTPUT）
        /// </summary>
        public string CPName { get; set; }
        /// <summary>
        /// 返利比例百分比形式
        /// </summary>
        public string FanLiBiLiBaiFenBi { get { return (FanLiBiLi * 100).ToString("F2") + "%"; } }
        /// <summary>
        /// 返利交易号
        /// </summary>
        public string FanLiJiaoYiHao { get; set; }
    }
    #endregion

    #region 推广返利信息查询业务实体
    /// <summary>
    /// 推广返利信息查询业务实体
    /// </summary>
    public class MTuiGuangFanLiChaXunInfo
    {
        /// <summary>
        /// 推广人会员编号
        /// </summary>
        public string TuiGuanRenHuiYuanId { get; set; }

        /// <summary>
        /// 返利状态
        /// </summary>
        public EyouSoft.Model.Enum.FanLianMengTuiGuangFanLiStatus? FanLiStatus { get; set; }
        /// <summary>
        /// 下单时间-起
        /// </summary>
        public DateTime? XiaDanShiJian1 { get; set; }
        /// <summary>
        /// 下单时间止
        /// </summary>
        public DateTime? XiaDanShiJian2 { get; set; }
    }
    #endregion

    #region 推广来源信息业务实体
    /// <summary>
    /// 推广来源信息业务实体
    /// </summary>
    public class MTuiGuangLaiYuanInfo
    {
        /// <summary>
        /// 信息编号
        /// </summary>
        public string XinXiId { get; set; }
        /// <summary>
        /// 推广编号
        /// </summary>
        public string TuiGuangId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 来源地址
        /// </summary>
        public string LaiYuan { get; set; }
    }
    #endregion

    #region 会员推广信息业务实体
    /// <summary>
    /// 会员推广信息业务实体
    /// </summary>
    public class MHuiYuanTuiGuangInfo
    {
        /// <summary>
        /// 推广编号
        /// </summary>
        public string TuiGuangId { get; set; }
        /// <summary>
        /// 推广域名
        /// </summary>
        public string TuiGuangYuMing { get; set; }
    }
    #endregion

    #region 推广返利比例信息业务实体
    /// <summary>
    /// 推广返利比例信息业务实体
    /// </summary>
    public class MTuiGuangFanLiBiLiInfo
    {
        /// <summary>
        /// 自增编号
        /// </summary>
        public int IdentityId { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal JinE { get; set; }
        /// <summary>
        /// 返利比例
        /// </summary>
        public decimal BiLi { get; set; }
        /// <summary>
        /// 返利比例百分比 返利比例*100
        /// </summary>
        public decimal BiLi1 { get { return BiLi * 100; } }
    }
    #endregion
}
