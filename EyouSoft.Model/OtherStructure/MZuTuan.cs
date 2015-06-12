using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.OtherStructure
{
    public class MZuTuan
    {
        public MZuTuan()
		{}
		#region Model
		private decimal? _carmoney;
		private string _zaocanmoney;
        private string _wucanmoney;
        private string _wancanmoney;
        private string _rsyiwai;
        private string _jtyiwai;
		private decimal? _daoyoumoney;
        private decimal? _mscarmoney;
        private string _mszaocanmoney;
        private string _mswucanmoney;
        private string _mswancanmoney;
        private string _msrsyiwai;
        private string _msjtyiwai;
        private decimal? _msdaoyoumoney;
        private int _dxrs;
        private int _cxrs;
        private int _cjrs;
        private decimal? _dipeidaoyou;
        private decimal? _msdipeidaoyou;
        private decimal? _dxdipeidaoyou;
        private decimal? _msdxdipeidaoyou;
        private decimal? _dxdaoyoumoney;
        private decimal? _msdxdaoyoumoney;
        private decimal? _cjdipeidaoyou;
        private decimal? _mscjdipeidaoyou;
        private decimal? _cjdaoyoumoney;
        private decimal? _mscjdaoyoumoney;
        
		/// <summary>
		/// 人均汽车费用
		/// </summary>
		public decimal? CarMoney
		{
			set{ _carmoney=value;}
			get{return _carmoney;}
		}
		/// <summary>
		/// 早餐费用
		/// </summary>
        public string ZaoCanMoney
		{
			set{ _zaocanmoney=value;}
			get{return _zaocanmoney;}
		}
		/// <summary>
		/// 午餐费用
		/// </summary>
        public string WuCanMoney
		{
			set{ _wucanmoney=value;}
			get{return _wucanmoney;}
		}
		/// <summary>
		/// 晚餐费用
		/// </summary>
        public string WanCanMoney
		{
			set{ _wancanmoney=value;}
			get{return _wancanmoney;}
		}
		/// <summary>
		/// 人身意外险
		/// </summary>
        public string RSYiWai
		{
			set{ _rsyiwai=value;}
			get{return _rsyiwai;}
		}
		/// <summary>
		/// 交通意外险
		/// </summary>
        public string JTYiWai
		{
			set{ _jtyiwai=value;}
			get{return _jtyiwai;}
		}
		/// <summary>
		/// 国内长线全陪导游费用
		/// </summary>
		public decimal? DaoYouMoney
		{
			set{ _daoyoumoney=value;}
			get{return _daoyoumoney;}
		}
        /// <summary>
        /// 人均汽车门市费用
        /// </summary>
        public decimal? MSCarMoney
        {
            set { _mscarmoney = value; }
            get { return _mscarmoney; }
        }
        /// <summary>
        /// 早餐门市费用
        /// </summary>
        public string MSZaoCanMoney
        {
            set { _mszaocanmoney = value; }
            get { return _mszaocanmoney; }
        }
        /// <summary>
        /// 午餐门市费用
        /// </summary>
        public string MSWuCanMoney
        {
            set { _mswucanmoney = value; }
            get { return _mswucanmoney; }
        }
        /// <summary>
        /// 晚餐门市费用
        /// </summary>
        public string MSWanCanMoney
        {
            set { _mswancanmoney = value; }
            get { return _mswancanmoney; }
        }
        /// <summary>
        /// 人身意外险门市费用
        /// </summary>
        public string MSRSYiWai
        {
            set { _msrsyiwai = value; }
            get { return _msrsyiwai; }
        }
        /// <summary>
        /// 交通意外险门市费用
        /// </summary>
        public string MSJTYiWai
        {
            set { _msjtyiwai = value; }
            get { return _msjtyiwai; }
        }
        /// <summary>
        /// 国内长线全陪导游门市费用
        /// </summary>
        public decimal? MSDaoYouMoney
        {
            set { _msdaoyoumoney = value; }
            get { return _msdaoyoumoney; }
        }
        /// <summary>
        /// 短线人数
        /// </summary>
        public int DXRS
        {
            set { _dxrs = value; }
            get { return _dxrs; }
        }
        /// <summary>
        /// 长线人数
        /// </summary>
        public int CXRS
        {
            set { _cxrs = value; }
            get { return _cxrs; }
        }
        /// <summary>
        /// 出境人数
        /// </summary>
        public int CJRS
        {
            set { _cjrs = value; }
            get { return _cjrs; }
        }
        /// <summary>
        /// 国内长线地陪导游成本价
        /// </summary>
        public decimal? DiPeiDaoYou
        {
            set { _dipeidaoyou = value; }
            get { return _dipeidaoyou; }
        }
        /// <summary>
        /// 国内长线地陪导游门市价
        /// </summary>
        public decimal? MSDiPeiDaoYou
        {
            set { _msdipeidaoyou = value; }
            get { return _msdipeidaoyou; }
        }
        /// <summary>
        /// 周边短线地陪导游成本价
        /// </summary>
        public decimal? DXDiPeiDaoYou
        {
            set { _dxdipeidaoyou = value; }
            get { return _dxdipeidaoyou; }
        }
        /// <summary>
        /// 周边短线地陪导游门市价
        /// </summary>
        public decimal? MSDXDiPeiDaoYou
        {
            set { _msdxdipeidaoyou = value; }
            get { return _msdxdipeidaoyou; }
        }
        /// <summary>
        /// 周边短线全陪导游成本价
        /// </summary>
        public decimal? DXDaoYouMoney
        {
            set { _dxdaoyoumoney = value; }
            get { return _dxdaoyoumoney; }
        }
        /// <summary>
        /// 周边短线全陪导游门市价
        /// </summary>
        public decimal? MSDXDaoYouMoney
        {
            set { _msdxdaoyoumoney = value; }
            get { return _msdxdaoyoumoney; }
        }
        /// <summary>
        /// 国际线路地陪导游成本价
        /// </summary>
        public decimal? CJDiPeiDaoYou
        {
            set { _cjdipeidaoyou = value; }
            get { return _cjdipeidaoyou; }
        }
        /// <summary>
        /// 国际线路地陪导游门市价
        /// </summary>
        public decimal? MSCJDiPeiDaoYou
        {
            set { _mscjdipeidaoyou = value; }
            get { return _mscjdipeidaoyou; }
        }
        /// <summary>
        /// 国际线路全陪导游成本价
        /// </summary>
        public decimal? CJDaoYouMoney
        {
            set { _cjdaoyoumoney = value; }
            get { return _cjdaoyoumoney; }
        }
        /// <summary>
        /// 国际线路全陪导游门市价
        /// </summary>
        public decimal? MSCJDaoYouMoney
        {
            set { _mscjdaoyoumoney = value; }
            get { return _mscjdaoyoumoney; }
        }
		#endregion Model
    }
}
