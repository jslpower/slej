//下级分销提成信息业务实体 汪奇志 2014-10-30
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.OtherStructure
{
    #region 下级分销提成信息业务实体
    /// <summary>
    /// 下级分销提成信息业务实体
    /// </summary>
    public class MXiaJiFenXiaoTiChengInfo
    {
        /// <summary>
        /// 提成编号
        /// </summary>
        public string TiChengId { get; set; }
        /// <summary>
        /// 会员编号
        /// </summary>
        public string HuiYuanId { get; set; }
        /// <summary>
        /// 下级分销佣金金额
        /// </summary>
        public decimal YongJinJinE { get; set; }
        /// <summary>
        /// 提成比例
        /// </summary>
        public decimal BiLi { get; set; }
        /// <summary>
        /// 提成金额
        /// </summary>
        public decimal JinE { get; set; }
        /// <summary>
        /// 提成时间
        /// </summary>
        public DateTime ShiJian { get; set; }
        /// <summary>
        /// 提成状态
        /// </summary>
        public EyouSoft.Model.Enum.XiaJiFenXiaoTiChengStatus Status { get; set; }
        /// <summary>
        /// 转账时间
        /// </summary>
        public DateTime ZhuanZhangShiJian { get; set; }
        /// <summary>
        /// 转账操作人编号
        /// </summary>
        public int ZhuanZhangCaoZuoRenId { get; set; }
        /// <summary>
        /// 交易号
        /// </summary>
        public string JiaoYiHao { get; set; }
        /// <summary>
        /// 提成金额(百分比)
        /// </summary>
        public string BiLiBaiFenBi { get { return (BiLi * 100).ToString("F2") + "%"; } }
        /// <summary>
        /// 会员用户名（OUTPUT）
        /// </summary>
        public string HuiYuanYongHuMing { get; set; }
        /// <summary>
        /// 会员姓名（OUTPUT）
        /// </summary>
        public string HuiYuanXingMing { get; set; }
    }
    #endregion

    #region 下级分销提成信息查询实体
    /// <summary>
    /// 下级分销提成信息查询实体
    /// </summary>
    public class MXiaJiFenXiaoTiChengChaXunInfo
    {
        /// <summary>
        /// 会员编号
        /// </summary>
        public string HuiYuanId { get; set; }
    }
    #endregion

    #region 下级分销提成金额信息业务实体
    /// <summary>
    /// 下级分销提成金额信息业务实体
    /// </summary>
    public class MXiaJiFenXiaoTiChengJinEInfo
    {
        /// <summary>
        /// 所有下级分销佣金金额
        /// </summary>
        public decimal SuoYouYongJinJinE { get; set; }
        /// <summary>
        /// 已申请下级分销佣金金额
        /// </summary>
        public decimal YiShenQingYongJinJinE { get; set; }
        /// <summary>
        /// 已申请提成金额
        /// </summary>
        public decimal YiShenQingJinE { get; set; }
        /// <summary>
        /// 已审批下级分销佣金金额
        /// </summary>
        public decimal YiShenPiYongJinJinE { get; set; }
        /// <summary>
        /// 已审批提成金额
        /// </summary>
        public decimal YiShenPiJinE { get; set; }
        /// <summary>
        /// 未结算下级分销佣金金额
        /// </summary>
        public decimal WeiJieSuanYongJinJinE { get { return SuoYouYongJinJinE - YiShenQingYongJinJinE; } }
        /// <summary>
        /// 总共赚取的佣金奖励金额
        /// </summary>
        public decimal ZongJinE { get; set; }
    }
    #endregion
}
