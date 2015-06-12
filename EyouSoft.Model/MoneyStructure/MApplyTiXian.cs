using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.Enum;


namespace EyouSoft.Model.MoneyStructure
{
    #region 提现信息业务实体
    /// <summary>
    /// 提现信息业务实体
    /// </summary>
    public class MApplyTiXian
    {
        /// <summary>
        /// 提现编号
        /// </summary>
        public string TiXianId { get; set; }
        /// <summary>
        /// 提现自增编号
        /// </summary>
        public int Id{get;set;}
        /// <summary>
        /// 会员ID
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 开户行
        /// </summary>
        public string KaiHuBank { get; set; }
        /// <summary>
        /// 开户名
        /// </summary>
        public string KaiHuName { get; set; }
        /// <summary>
        /// 银行帐号
        /// </summary>
        public string BankNum { get; set; }
        /// <summary>
        /// 提现金额
        /// </summary>
        public decimal JinE { get; set; }
        /// <summary>
        /// 提现状态
        /// </summary>
        public TiXianState TiXianStatus { get; set; }
        /// <summary>
        /// 提现时间
        /// </summary>
        public DateTime TiXianTime { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public TiXianShenHe ApplyStatus { get; set; }
        /// <summary>
        /// 审核备注
        /// </summary>
        public string ShenHeBeiZhu{get;set;}
        /// <summary>
        /// 备注
        /// </summary>
        public string BeiZhu{get;set;}
        /// <summary>
        /// 交易号
        /// </summary>
        public string TransactionID{get;set;}
    }
    #endregion

    #region 提现申请查询实体类
    public class MApplyTiXianSer
    {
        /// <summary>
        /// 会员ID
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 提现状态
        /// </summary>
        public TiXianState? TiXianStatus { set; get; }
        /// <summary>
        /// 提现起始时间
        /// </summary>
        public DateTime? TiXianStartTime { set; get; }
        /// <summary>
        /// 提现截至时间
        /// </summary>
        public DateTime? TiXianEndTime { set; get; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public TiXianShenHe? ApplyStatus { set; get; }
    }
    #endregion
}
