using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.OtherStructure
{
    #region 充值信息业务实体
    /// <summary>
    /// 充值信息业务实体
    /// </summary>
    public class MChongZhi
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string DingDanId { get; set; }
        /// <summary>
        /// 交易号
        /// </summary>
        public string JiaoYiHao { get; set; }
        /// <summary>
        /// 会员编号
        /// </summary>
        public string HuiYuanId { get; set; }
        /// <summary>
        /// 充值金额
        /// </summary>
        public decimal JinE { get; set; }
        /// <summary>
        /// 充值时间
        /// </summary>
        public DateTime Issuetime { get; set; }
        /// <summary>
        /// 支付状态
        /// </summary>
        public EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus ZhiFuStatus { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public EyouSoft.Model.Enum.ZhiFuFangShi? ZhiFuFangShi { get; set; }
        /// <summary>
        /// 会员姓名
        /// </summary>
        public string HuiYuanName { get; set; }
        /// <summary>
        /// 会员用户名
        /// </summary>
        public string HuiYuanYongHuMing { get; set; }
    }
    #endregion

    #region 充值信息查询业务实体
    /// <summary>
    /// 充值信息查询业务实体
    /// </summary>
    public class MChongZhiChaXunInfo
    {
        /// <summary>
        /// 会员编号
        /// </summary>
        public string HuiYuanId { get; set; }
        /// <summary>
        /// 充值金额-起
        /// </summary>
        public decimal? JinE1 { get; set; }
        /// <summary>
        /// 充值金额-止
        /// </summary>
        public decimal? JinE2 { get; set; }
        /// <summary>
        /// 充值时间-起
        /// </summary>
        public DateTime? ChongZhiShiJian1 { get; set; }
        /// <summary>
        /// 充值时间-止
        /// </summary>
        public DateTime? ChongZhiShiJian2 { get; set; }
    }
    #endregion
}
