using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.Enum;

namespace EyouSoft.Model.ZuCheStructure
{
    public class MZuCheOrder
    {
        public MZuCheOrder() { }

        #region Model
        private string _orderid;
        private string _carname;
        private string _zucheid;
        private int? _zuchetype;
        private int? _cartype;
        private decimal? _gonglishu;
        private int? _zuchetianshu;
        private decimal? _zujin;
        private EyouSoft.Model.Enum.XianLuStructure.OrderStatus _status = 0;
        private EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus _fukuanstatus = 0;
        private DateTime? _ldate;
        private string _xiadanbeizhu;
        private string _lxrname;
        private string _lxrtelephone;
        private string _operatorid;
        private DateTime _issuetime = DateTime.Now;
        private string _tuangouid;
        private IList<ZuCheXingCheng> _xingcheng;
        private string _ordercode;
        private DateTime? _edate;
        private int _number = 0;
        private string _yudingrname;
        private string _yudingrtelephone;
        private decimal _agencyjine;
        private string _agencyid;
        private MemberTypes _usertype;
        private OrderSite _ordersite;
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 车辆名称
        /// </summary>
        public string CarName
        {
            set { _carname = value; }
            get { return _carname; }
        }
        /// <summary>
        /// 租车编号
        /// </summary>
        public string ZuCheID
        {
            set { _zucheid = value; }
            get { return _zucheid; }
        }
        /// <summary>
        /// 租车方式
        /// </summary>
        public int? ZuCheType
        {
            set { _zuchetype = value; }
            get { return _zuchetype; }
        }
        /// <summary>
        /// 汽车类型
        /// </summary>
        public int? CarType
        {
            set { _cartype = value; }
            get { return _cartype; }
        }
        /// <summary>
        /// 累计公里数
        /// </summary>
        public decimal? GongLiShu
        {
            set { _gonglishu = value; }
            get { return _gonglishu; }
        }
        /// <summary>
        /// 租车天数
        /// </summary>
        public int? ZuCheTianShu
        {
            set { _zuchetianshu = value; }
            get { return _zuchetianshu; }
        }
        /// <summary>
        /// 车辆租金
        /// </summary>
        public decimal? ZuJin
        {
            set { _zujin = value; }
            get { return _zujin; }
        }
        /// <summary>
        /// 分销金额
        /// </summary>
        public decimal AgencyJinE
        {
            set { _agencyjine = value; }
            get { return _agencyjine; }
        }
        /// <summary>
        /// 分销商Id
        /// </summary>
        public string AgencyId
        {
            set { _agencyid = value; }
            get { return _agencyid; }
        }
        /// <summary>
        /// 订单状态
        /// </summary>
        public EyouSoft.Model.Enum.XianLuStructure.OrderStatus Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 付款状态
        /// </summary>
        public EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus FuKuanStatus
        {
            set { _fukuanstatus = value; }
            get { return _fukuanstatus; }
        }
        /// <summary>
        /// 租车开始时间
        /// </summary>
        public DateTime? LDate
        {
            set { _ldate = value; }
            get { return _ldate; }
        }
        /// <summary>
        /// 租车结束时间
        /// </summary>
        public DateTime? EDate
        {
            set { _edate = value; }
            get { return _edate; }
        }
        /// <summary>
        /// 下单备注
        /// </summary>
        public string XiaDanBeiZhu
        {
            set { _xiadanbeizhu = value; }
            get { return _xiadanbeizhu; }
        }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string LxrName
        {
            set { _lxrname = value; }
            get { return _lxrname; }
        }
        /// <summary>
        /// 联系人电话
        /// </summary>
        public string LxrTelephone
        {
            set { _lxrtelephone = value; }
            get { return _lxrtelephone; }
        }
        /// <summary>
        /// 下单人编号
        /// </summary>
        public string OperatorId
        {
            set { _operatorid = value; }
            get { return _operatorid; }
        }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime IssueTime
        {
            set { _issuetime = value; }
            get { return _issuetime; }
        }
        /// <summary>
        /// 团购编号
        /// </summary>
        public string TuanGouId
        {
            set { _tuangouid = value; }
            get { return _tuangouid; }
        }
        /// <summary>
        /// 租车行程
        /// </summary>
        public IList<ZuCheXingCheng> Xingcheng
        {
            get { return _xingcheng; }
            set { _xingcheng = value; }
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
        /// 租车数量
        /// </summary>
        public int Number
        {
            set { _number = value; }
            get { return _number; }
        }
        /// <summary>
        /// 预定人姓名
        /// </summary>
        public string YuDingRName
        {
            set { _yudingrname = value; }
            get { return _yudingrname; }
        }
        /// <summary>
        /// 预定人电话
        /// </summary>
        public string YuDingRTelephone
        {
            set { _yudingrtelephone = value; }
            get { return _yudingrtelephone; }
        }
        /// <summary>
        /// 会员类型
        /// </summary>
        public MemberTypes UserType
        {
            set { _usertype = value; }
            get { return _usertype; }
        }
        /// <summary>
        /// 下单站点
        /// </summary>
        public OrderSite OrderSite
        {
            set { _ordersite = value; }
            get { return _ordersite; }
        }
        #endregion Model
    }

    public class ZuCheXingCheng
    {
        public ZuCheXingCheng() { }

        #region Model
        private string _orderid;
        private string _lplace;
        private string _eplace;
        private decimal? _gonglishu;
        private int _identityid;
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 起始地
        /// </summary>
        public string LPlace
        {
            set { _lplace = value; }
            get { return _lplace; }
        }
        /// <summary>
        /// 目的地
        /// </summary>
        public string EPlace
        {
            set { _eplace = value; }
            get { return _eplace; }
        }
        /// <summary>
        /// 公里数
        /// </summary>
        public decimal? GongLiShu
        {
            set { _gonglishu = value; }
            get { return _gonglishu; }
        }
        /// <summary>
        /// 自增编号
        /// </summary>
        public int IdentityId
        {
            set { _identityid = value; }
            get { return _identityid; }
        }
        #endregion Model
    }

    public class MZuCheOrderChaXun
    {
        /// <summary>
        /// 会员编号
        /// </summary>
        public string HuiYuanId { get; set; }
        /// <summary>
        /// 分销商编号
        /// </summary>
        public string AgencyId { get; set; }
        /// <summary>
        /// 租车编号
        /// </summary>
        public string ZuCheId { get; set; }
        /// <summary>
        /// 团队编号
        /// </summary>
        public string TourId { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 下单人姓名
        /// </summary>
        public string XiaDanRenName { get; set; }
        /// <summary>
        /// 下单开始时间
        /// </summary>
        public DateTime? SXiaDanTime { get; set; }
        /// <summary>
        /// 下单结束时间
        /// </summary>
        public DateTime? EXiaDanTime { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public EyouSoft.Model.Enum.XianLuStructure.OrderStatus? OrderStatus { get; set; }
        /// <summary>
        /// 付款状态
        /// </summary>
        public EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus? FuKuanStatus { get; set; }
        /// <summary>
        /// 团购编号
        /// </summary>
        public string TuanGouId { get; set; }
        /// <summary>
        /// 汽车名称
        /// </summary>
        public string CarName { get; set; }
    }
}
