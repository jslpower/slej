using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.Enum.XianLuStructure;

namespace EyouSoft.Model.XianLuStructure
{
    #region 自组团主表
    public class MZiZuTuan
    {

        public MZiZuTuan()
		{}
		#region Model
		private string _zutuanid;
		private string _xdrid;
		private int? _renshu;
		private decimal? _carmoney;
		private int? _zaocannum;
		private decimal? _zaocanjia;
		private int? _wucannum;
		private decimal? _wucanjia;
		private int? _wancannum;
		private decimal? _wancanjia;
		private decimal? _canwujia;
		private string _baoxian;
		private decimal? _bxjiage;
		private int? _baoxianday;
		private int? _daoyounum;
		private decimal? _daoyoumoney;
		private decimal? _zcmoney;
		private decimal? _zongmoney;
		private DateTime? _chufatime;
		private DateTime? _issuetime;
		private string _xianluid;
        private string _tourid;
        private string _xianluname;
		private decimal? _crjiage;
		private decimal? _etjiage;
		private EyouSoft.Model.Enum.MemberTypes _usertype;
        private string _ordercode;
        private EyouSoft.Model.Enum.XianLuStructure.OrderStatus _orderstate;
        private decimal? _rsbxjiage;
        private decimal? _jtbxjiage;
        private string _agencyid;
        private decimal? _agencyjine;
        private decimal? _etagencyjine;
        private decimal? _zongjine;
        private int _chengtuannum;
        private decimal? _jtbaoxianjia;
        private decimal? _rsbaoxianjia;
        private int _ertongnum;
        private int _dipeidaoyounum;
        private decimal? _dipeirjjia;
        private decimal? _quanpeirjjia;
        private string _hangbanid;

		/// <summary>
		/// 自组团Id
		/// </summary>
		public string ZuTuanId
		{
			set{ _zutuanid=value;}
			get{return _zutuanid;}
		}
		/// <summary>
		/// 下单人id
		/// </summary>
		public string XDRId
		{
			set{ _xdrid=value;}
			get{return _xdrid;}
		}
		/// <summary>
		/// 成人人数
		/// </summary>
		public int? RenShu
		{
			set{ _renshu=value;}
			get{return _renshu;}
		}
		/// <summary>
		/// 车辆人均
		/// </summary>
		public decimal? CarMoney
		{
			set{ _carmoney=value;}
			get{return _carmoney;}
		}
		/// <summary>
		/// 早餐数
		/// </summary>
		public int? ZaoCanNum
		{
			set{ _zaocannum=value;}
			get{return _zaocannum;}
		}
		/// <summary>
		/// 早餐价
		/// </summary>
		public decimal? ZaoCanJia
		{
			set{ _zaocanjia=value;}
			get{return _zaocanjia;}
		}
		/// <summary>
		/// 午餐数
		/// </summary>
		public int? WuCanNum
		{
			set{ _wucannum=value;}
			get{return _wucannum;}
		}
		/// <summary>
		/// 午餐价
		/// </summary>
		public decimal? WuCanJia
		{
			set{ _wucanjia=value;}
			get{return _wucanjia;}
		}
		/// <summary>
		/// 晚餐数
		/// </summary>
		public int? WanCanNum
		{
			set{ _wancannum=value;}
			get{return _wancannum;}
		}
		/// <summary>
		/// 晚餐价
		/// </summary>
		public decimal? WanCanJia
		{
			set{ _wancanjia=value;}
			get{return _wancanjia;}
		}
		/// <summary>
		/// 餐费人均价
		/// </summary>
		public decimal? CanWuJia
		{
			set{ _canwujia=value;}
			get{return _canwujia;}
		}
		/// <summary>
		/// 保险方式（人身，交通）
		/// </summary>
		public string BaoXian
		{
			set{ _baoxian=value;}
			get{return _baoxian;}
		}
		/// <summary>
		/// 保险人均价格
		/// </summary>
		public decimal? BXJiaGe
		{
			set{ _bxjiage=value;}
			get{return _bxjiage;}
		}
		/// <summary>
		/// 保险天数
		/// </summary>
		public int? BaoXianDay
		{
			set{ _baoxianday=value;}
			get{return _baoxianday;}
		}
		/// <summary>
		/// 全陪导游人数
		/// </summary>
		public int? DaoYouNum
		{
			set{ _daoyounum=value;}
			get{return _daoyounum;}
		}
		/// <summary>
		/// 全陪导游人均
		/// </summary>
		public decimal? DaoYouMoney
		{
			set{ _daoyoumoney=value;}
			get{return _daoyoumoney;}
		}
		/// <summary>
		/// 租车总价
		/// </summary>
		public decimal? ZCMoney
		{
			set{ _zcmoney=value;}
			get{return _zcmoney;}
		}
		/// <summary>
		/// 总价
		/// </summary>
		public decimal? ZongMOney
		{
			set{ _zongmoney=value;}
			get{return _zongmoney;}
		}
		/// <summary>
		/// 出发时间
		/// </summary>
		public DateTime? ChuFaTime
		{
			set{ _chufatime=value;}
			get{return _chufatime;}
		}
		/// <summary>
		/// 下单时间
		/// </summary>
		public DateTime? IssueTime
		{
			set{ _issuetime=value;}
			get{return _issuetime;}
		}
		/// <summary>
		/// 线路id
		/// </summary>
		public string XianLuId
		{
			set{ _xianluid=value;}
			get{return _xianluid;}
		}
        /// <summary>
        /// 线路名
        /// </summary>
        public string XianLuName
        {
            set { _xianluname = value; }
            get { return _xianluname; }
        }
        /// <summary>
        /// 发班id
        /// </summary>
        public string TourId
        {
            set { _tourid = value; }
            get { return _tourid; }
        }
		/// <summary>
		/// 成人价
		/// </summary>
		public decimal? CRJiage
		{
			set{ _crjiage=value;}
			get{return _crjiage;}
		}
		/// <summary>
		/// 儿童价
		/// </summary>
		public decimal? ETJiage
		{
			set{ _etjiage=value;}
			get{return _etjiage;}
		}
		/// <summary>
		/// 会员类型
		/// </summary>
        public EyouSoft.Model.Enum.MemberTypes UserType
		{
			set{ _usertype=value;}
			get{return _usertype;}
		}
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderCode
        {
            set { _ordercode = value; }
            get { return _ordercode; }
        }
        /// <summary>
        /// 订单状态
        /// </summary>
        public EyouSoft.Model.Enum.XianLuStructure.OrderStatus OrderState
        {
            set { _orderstate = value; }
            get { return _orderstate; }
        }
        /// <summary>
        /// 人身保险金额
        /// </summary>
        public decimal? RSBXJiaGe
        {
            set { _rsbxjiage = value; }
            get { return _rsbxjiage; }
        }
       /// <summary>
       /// 交通保险金额
       /// </summary>
        public decimal? JTBXJiaGe
        {
            set { _jtbxjiage = value; }
            get { return _jtbxjiage; }
        }
        /// <summary>
        /// 分销商id
        /// </summary>
        public string AgencyId
        {
            set { _agencyid = value; }
            get { return _agencyid; }
        }
        /// <summary>
        /// 成人分销金额
        /// </summary>
        public decimal? AgencyJinE
        {
            set { _agencyjine = value; }
            get { return _agencyjine; }
        }
        /// <summary>
        /// 儿童分销金额
        /// </summary>
        public decimal? ETAgencyJinE
        {
            set { _etagencyjine = value; }
            get { return _etagencyjine; }
        }
        /// <summary>
        /// 订单总金额
        /// </summary>
        public decimal? ZongJinE
        {
            set { _zongjine = value; }
            get { return _zongjine; }
        }
        /// <summary>
        /// 成团人数
        /// </summary>
        public int ChengTuanNum
        {
            set { _chengtuannum = value; }
            get { return _chengtuannum; }
        }
        /// <summary>
        /// 儿童人数
        /// </summary>
        public int ErTongNum
        {
            set { _ertongnum = value; }
            get { return _ertongnum; }
        }
        /// <summary>
        /// 地陪导游人数
        /// </summary>
        public int DiPeiDaoYouNum
        {
            set { _dipeidaoyounum = value; }
            get { return _dipeidaoyounum; }
        }
        /// <summary>
        /// 地陪导游人均价格
        /// </summary>
        public decimal? DiPeiRJJia
        {
            set { _dipeirjjia = value; }
            get { return _dipeirjjia; }
        }
        /// <summary>
        /// 全陪导游人均价格
        /// </summary>
        public decimal? QuanPeiRJJia
        {
            set { _quanpeirjjia = value; }
            get { return _quanpeirjjia; }
        }
        /// <summary>
        /// 航班id
        /// </summary>
        public string HangBanId
        {
            set { _hangbanid = value; }
            get { return _hangbanid; }
        }
        /// <summary>
        /// 付款状态
        /// </summary>
        public FuKuanStatus FuKuanStatus { get; set; }
		#endregion Model
    }
    #endregion
    #region 自组团租车行程
    public class MZiZuTuanXingCheng
    {
        public MZiZuTuanXingCheng()
        { }
        #region Model
        private int _orderid;
        private string _zizutuanid;
        private string _zucheid;
        private int? _chenum;
        private string _qidian;
        private string _zhongdian;
        private decimal? _feiyong;
        private decimal _gonglishu;
        /// <summary>
        /// 主id
        /// </summary>
        public int OrderId
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 自组团id
        /// </summary>
        public string ZiZuTuanId
        {
            set { _zizutuanid = value; }
            get { return _zizutuanid; }
        }
        /// <summary>
        /// 车辆id
        /// </summary>
        public string ZucheId
        {
            set { _zucheid = value; }
            get { return _zucheid; }
        }
        /// <summary>
        /// 租车数量
        /// </summary>
        public int? CheNum
        {
            set { _chenum = value; }
            get { return _chenum; }
        }
        /// <summary>
        /// 起点
        /// </summary>
        public string QiDian
        {
            set { _qidian = value; }
            get { return _qidian; }
        }
        /// <summary>
        /// 终点
        /// </summary>
        public string ZhongDian
        {
            set { _zhongdian = value; }
            get { return _zhongdian; }
        }
        /// <summary>
        /// 费用
        /// </summary>
        public decimal? FeiYong
        {
            set { _feiyong = value; }
            get { return _feiyong; }
        }
        /// <summary>
        /// 公里数
        /// </summary>
        public decimal GongLiShu
        {
            set { _gonglishu = value; }
            get { return _gonglishu; }
        }
        #endregion Model

    }
    #endregion
    #region 查询实体类
    public class MZiZuTuanSer
    {
        /// <summary>
        /// 会员ID
        /// </summary>
        public string XDRId { get; set; }
        /// <summary>
        /// 分销商ID
        /// </summary>
        public string AgencyId { get; set; }
        /// <summary>
        /// 下单开始时间
        /// </summary>
        public DateTime? IssueStarTime { set; get; }
        /// <summary>
        /// 下单结束时间
        /// </summary>
        public DateTime? IssueEndTime { set; get; }
        /// <summary>
        /// 出发时间
        /// </summary>
        public DateTime? ChuFaTime { set; get; }
    }
    #endregion
}
