using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.Enum;

namespace EyouSoft.Model.OtherStructure
{
    /// <summary>
    /// 积分兑换实体
    /// </summary>
    public class MJiFen
    {
		#region Model
		private string _duihuanid;
		private int? _duihuanjine;
		private decimal? _shengyujine;
		private DateTime? _issuetime;
		private string _userid;
		private int? _duihuanstatus;
		/// <summary>
		/// 兑换主id
		/// </summary>
		public string DuiHuanId
		{
			set{ _duihuanid=value;}
			get{return _duihuanid;}
		}
		/// <summary>
		/// 兑换积分
		/// </summary>
		public int? DuiHuanJinE
		{
			set{ _duihuanjine=value;}
			get{return _duihuanjine;}
		}
		/// <summary>
		/// 剩余积分
		/// </summary>
        public decimal? ShengYuJinE
		{
			set{ _shengyujine=value;}
			get{return _shengyujine;}
		}
		/// <summary>
		/// 兑换时间
		/// </summary>
		public DateTime? IssueTime
		{
			set{ _issuetime=value;}
			get{return _issuetime;}
		}
		/// <summary>
		/// 会员id
		/// </summary>
		public string UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 状态
		/// </summary>
        public JiFenDuiHuanStatus? DuiHuanStatus{set;get;}
		#endregion Model
    }
    /// <summary>
    /// 积分查询实体
    /// </summary>
    public class MJiFenSer
    {
        /// <summary>
        /// 会员id
        /// </summary>
        public string UserId { set; get; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? StartTime { set; get; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { set; get; }
        /// <summary>
        /// 兑换状态
        /// </summary>
        public JiFenDuiHuanStatus? DuiHuanStatus { set; get; }
    }
}
