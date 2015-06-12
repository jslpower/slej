using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq.Bussiness;
using EyouSoft.Model.JPStructure;

namespace EyouSoft.Model.OtherStructure
{
    public class MDingDan
    {
        public MDingDan()
        { }
        #region Model
        private string _orderid;
        private decimal _jine;
        private EyouSoft.Model.Enum.XianLuStructure.OrderStatus _orderstatus;
        private string _ordercode;
        private string _xdrid;
        private EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus _fukuanstatus;
        private string _beizhu;
        private string _lxrname;
        private string _lxrmoblie;
        private DateTime _issuetime;
        private string _ordername;
        private string _ordernum;
        private decimal _agencyjine;
        private string _agencyid;
        private DingDanType _ordertype;
        private string _productid;
        private DingDanStatus _dingdanstatus;

        /// <summary>
        /// 订单Id
        /// </summary>
        public string OrderId
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 支付金额
        /// </summary>
        public decimal JinE
        {
            set { _jine = value; }
            get { return _jine; }
        }
        /// <summary>
        /// 订单状态
        /// </summary>
        public EyouSoft.Model.Enum.XianLuStructure.OrderStatus OrderStatus
        {
            set { _orderstatus = value; }
            get { return _orderstatus; }
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
        /// 下单人id
        /// </summary>
        public string XDRId
        {
            set { _xdrid = value; }
            get { return _xdrid; }
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
        /// 备注
        /// </summary>
        public string BeiZhu
        {
            set { _beizhu = value; }
            get { return _beizhu; }
        }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string LXRName
        {
            set { _lxrname = value; }
            get { return _lxrname; }
        }
        /// <summary>
        /// 联系人手机
        /// </summary>
        public string LXRMoblie
        {
            set { _lxrmoblie = value; }
            get { return _lxrmoblie; }
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
        /// 订单名称
        /// </summary>
        public string OrderName
        {
            set { _ordername = value; }
            get { return _ordername; }
        }
        /// <summary>
        /// 订单数量
        /// </summary>
        public string OrderNum
        {
            set { _ordernum = value; }
            get { return _ordernum; }
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
        /// 分销商id
        /// </summary>
        public string AgencyId
        {
            set { _agencyid = value; }
            get { return _agencyid; }
        }
        /// <summary>
        /// 订单类型
        /// </summary>
        public DingDanType OrderType
        {
            set { _ordertype = value; }
            get { return _ordertype; }
        }
        /// <summary>
        /// 产品id
        /// </summary>
        public string ProductID
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 订单状态
        /// </summary>
        public DingDanStatus DingDanStatus
        {
            set { _dingdanstatus = value; }
            get { return _dingdanstatus; }
        }
        /// <summary>
        /// 出发时间
        /// </summary>
        public DateTime ChuFaShiJian { get; set; }
        /// <summary>
        /// 回归时间
        /// </summary>
        public DateTime HuiGuiShiJian { get; set; }
        /// <summary>
        /// 未处理订单状态
        /// </summary>
        public EyouSoft.Model.Enum.XianLuStructure.OrderStatus DingDanZT { get; set; }

        #endregion Model
    }
    /// <summary>
    /// 会员申请查询实体
    /// </summary>
    public class MSearchDingDan : ISearchable
    {
        private bool _iswap = false;
        public SearchModel SearchInfo { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime startime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime endtime { get; set; }
        /// <summary>
        /// 下单人
        /// </summary>
        public string xiadanrenid { get; set; }
        /// <summary>
        /// 分销商id
        /// </summary>
        public string fenxiaoid { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        public DingDanType dingdantype { get; set; }
        /// <summary>
        /// 产品id
        /// </summary>
        public string changpingid { get; set; }
        /// <summary>
        /// 联系人手机
        /// </summary>
        public string lxrmoblie { get; set; }
        /// <summary>
        /// 订单Id
        /// </summary>
        public string DingDanId { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string DingDanBianHao { get; set; }
        /// <summary>
        ///  订单状态
        /// </summary>
        public IList<EyouSoft.Model.Enum.XianLuStructure.OrderStatus> OrderStatus { get; set; }
        /// <summary>
        /// 是否是WAP版（WAP版没有签证栏目）
        /// </summary>
        public bool IsWAP
        {
            set { _iswap = value; }
            get { return _iswap; }
        }
    }
    /// <summary>
    /// 订单类别
    /// </summary>
    public enum DingDanType
    {
        长线订单 = 0,
        短线订单 = 1,
        出境订单 = 2,
        商城订单 = 3,
        门票订单 = 4,
        酒店订单 = 5,
        签证订单 = 6,
        团购订单 = 7,
        租车订单 = 8,
        单团订单 = 9,
        机票订单 = 10,
        充值订单 = 11
    }

    /// <summary>
    /// 下级分销奖励比值
    /// </summary>
    public class MJiangJiBi
    {
        /// <summary>
        /// 订单id
        /// </summary>
        public string DingDanId { set; get; }
        /// <summary>
        /// 订单类别
        /// </summary>
        public DingDanType OrderType { set; get; }
        /// <summary>
        /// 奖励比值
        /// </summary>
        public decimal JiangLiBiLi { set; get; }
    }
}

