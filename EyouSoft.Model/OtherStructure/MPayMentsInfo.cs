using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.OtherStructure
{
    //收支记录表业务实体
    public class MPayMentsInfo
    {
        /// <summary>
        /// 自增长ID
        /// </summary>
        public int PID { get; set; }
        /// <summary>
        /// 会员id
        /// </summary>
        public string MemID { get; set; }
        
        /// <summary>
        /// 账户金额
        /// </summary>
        public decimal Account { get; set; }
        /// <summary>
        /// 日收入率
        /// </summary>
        public decimal IntersetRate { get; set; }
        /// <summary>
        /// 日收入额
        /// </summary>
        public decimal DayInCome { get; set; }
        /// <summary>
        /// 交易日期
        /// </summary>
        public DateTime DealDate { get; set; }
    }
    /// <summary>
    /// 利率表业务实体
    /// </summary>
    public class MInterestRate
    {
        /// <summary>
        /// 自增长ID
        /// </summary>
        public int RateID { get; set; }
        /// <summary>
        /// 利率(每万份收益率)
        /// </summary>
        public decimal Interest { get; set; }
    }

    /// <summary>
    /// 收益表查询实体
    /// </summary>
    public class MPaySearch
    {

        /// <summary>
        /// 会员ID
        /// </summary>
        public string MemID { get; set; }
        /// <summary>
        /// 会员姓名
        /// </summary>
        public string Mname { get; set; }
        /// <summary>
        /// 收益开始日期
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// 收益结束日期
        /// </summary>
        public DateTime? EndDate { get; set; }
    }
}
