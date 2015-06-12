/*using System;
using EyouSoft.Model.Enum;
using Linq.ORM;
using Linq.ORM.Attribute;

namespace EyouSoft.Model.MoneyStructure
{
    [Table("tbl_JA_Account")]
    public partial class MAccount
    {
        public MAccount()
        { }
        #region Model
        private int _id;
        private string _userid;
        private string _transactionid;
        private decimal _amounts;
        private decimal _balance;
        private DateTime _transactiontime;
        private ChongZhiWay _transactionway;
        private TCate _transactioncate;
        private TStatus _transactionstate;
        private string _transactiondesc;
        private string _orderid;
        private EyouSoft.Model.Enum.DingDanLeiBie? _ordertype;
        private string _tranuserid;
        [PrimaryKey]
        [Identity(IdentityType.Increment)]
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 会员ID
        /// </summary>
        public string UserId
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 交易号
        /// </summary>
        public string TransactionID
        {
            set { _transactionid = value; }
            get { return _transactionid; }
        }
        /// <summary>
        /// 交易金额
        /// </summary>
        public decimal Amounts
        {
            set { _amounts = value; }
            get { return _amounts; }
        }
        /// <summary>
        /// 余额
        /// </summary>
        public decimal balance
        {
            set
            { _balance = value; }
            get { return _balance; }
        }
        /// <summary>
        /// 交易时间
        /// </summary>
        public DateTime TransactionTime
        {
            set { _transactiontime = value; }
            get { return _transactiontime; }
        }
        /// <summary>
        /// 交易方式
        /// </summary>
        public ChongZhiWay TransactionWay
        {
            set { _transactionway = value; }
            get { return _transactionway; }
        }
        /// <summary>
        /// 交易类别(0-充值,1-提现,2-消费,3-返利)
        /// </summary>
        public TCate TransactionCate
        {
            set { _transactioncate = value; }
            get { return _transactioncate; }
        }
        /// <summary>
        /// 交易状态
        /// </summary>
        public TStatus TransactionState
        {
            set { _transactionstate = value; }
            get { return _transactionstate; }
        }
        /// <summary>
        /// 交易状态
        /// </summary>
        public string TransactionDesc
        {
            set { _transactiondesc = value; }
            get { return _transactiondesc; }
        }
        /// <summary>
        /// 返利时提供订单编号(该字段只用于返利)
        /// </summary>
        public string OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 订单类型
        /// </summary>
        public EyouSoft.Model.Enum.DingDanLeiBie? OrderType
        {
            set { _ordertype = value; }
            get { return _ordertype; }
        }
        /// <summary>
        /// 交易对象Id
        /// </summary>
        public string TranUserId
        {
            set { _tranuserid = value; }
            get { return _tranuserid; }
        }
        #endregion Model
    }
}
*/