//交易明细信息业务实体 汪奇志 2014-11-06
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.OtherStructure
{
    #region 交易明细信息业务实体
    /// <summary>
    /// 交易明细信息业务实体
    /// </summary>
    public class MJiaoYiMingXiInfo
    {
        /// <summary>
        /// 明细编号
        /// </summary>
        public string MingXiId { get; set; }
        /// <summary>
        /// 会员编号
        /// </summary>
        public string HuiYuanId { get; set; }
        /// <summary>
        /// 交易号（系统订单号）
        /// </summary>
        public string JiaoYiHao { get; set; }
        /// <summary>
        /// 交易金额
        /// </summary>
        public decimal JiaoYiJinE { get; set; }
        /// <summary>
        /// 交易时间
        /// </summary>
        public DateTime JiaoYiShiJian { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public EyouSoft.Model.Enum.ZhiFuFangShi ZhiFuFangShi { get; set; }
        /// <summary>
        /// 交易类别
        /// </summary>
        public EyouSoft.Model.Enum.JiaoYiLeiBie JiaoYiLeiBie { get; set; }
        /// <summary>
        /// 交易状态
        /// </summary>
        public EyouSoft.Model.Enum.JiaoYiStatus JiaoYiStatus { get; set; }
        /// <summary>
        /// 交易描述
        /// </summary>
        public string JiaoYiMiaoShu { get; set; }
        /// <summary>
        /// 订单编号（系统订单编号）
        /// </summary>
        public string DingDanId { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        public EyouSoft.Model.Enum.DingDanLeiBie DingDanLeiXing { get; set; }
        /// <summary>
        /// Api交易号（支付接口交易号）
        /// </summary>
        public string ApiJiaoYiHao { get; set; }

        /// <summary>
        /// 交易后会员E额宝余额（OUTPUT）
        /// </summary>
        public decimal HuiYuanEYuE { get; set; }
        /// <summary>
        /// 会员姓名（OUTPUT）
        /// </summary>
        public string HuiYuanName { get; set; }
        /// <summary>
        /// 会员用户名（OUTPUT）
        /// </summary>
        public string HuiYuanYongHuMing { get; set; }
    }
    #endregion

    #region 交易明细信息查询业务实体
    /// <summary>
    /// 交易明细信息查询业务实体
    /// </summary>
    public class MJiaoYiMingXiChaXunInfo
    {
        /// <summary>
        /// 会员编号
        /// </summary>
        public string HuiYuanId { get; set; }
        /// <summary>
        /// 交易时间-起
        /// </summary>
        public DateTime? JiaoYiShiJian1 { get; set; }
        /// <summary>
        /// 交易时间-止
        /// </summary>
        public DateTime? JiaoYiShiJian2 { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public EyouSoft.Model.Enum.ZhiFuFangShi? ZhiFuFangShi { get; set; }
    }
    #endregion

    #region 账户余额（系统）信息业务实体
    /// <summary>
    /// 账户余额（系统）信息业务实体
    /// </summary>
    public class MYuEInfo
    {
        /// <summary>
        /// E额宝余额
        /// </summary>
        public decimal EEBaoYuE { get; set; }
        /// <summary>
        /// 快钱余额
        /// </summary>
        public decimal KuaiQianYuE { get; set; }
        /// <summary>
        /// 余额
        /// </summary>
        public decimal YuE { get; set; }
    }
    #endregion
}
