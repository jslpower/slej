using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.Enum;

namespace EyouSoft.Model.OtherStructure
{
    public class MTuanGouDingDan
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public int OrderID { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public int ProductID { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 购买数量
        /// </summary>
        public int ProductNum { get; set; }
        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal OrderPrice { get; set; }
        /// <summary>
        /// 购买人编号
        /// </summary>
        public string PeopleID { get; set; }
        /// <summary>
        /// 购买人姓名
        /// </summary>
        public string PeopleName { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string PeopleMobile { get; set; }
        /// <summary>
        /// 购买时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public EyouSoft.Model.Enum.XianLuStructure.OrderStatus OrderState { get; set; }
        /// <summary>
        /// 支付状态
        /// </summary>
        public EyouSoft.Model.Enum.PaymentState PayState { get; set; }
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string SupplierID { get; set; }
        /// <summary>
        /// 收货人地址
        /// </summary>
        public string Peopleaddress { get; set; }
        /// <summary>
        /// 订单来源
        /// </summary>
        public OrderSite OrderSite { get; set; }
    }
    public class MTuanGouDingDanSer
    {
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string SupplierID { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 购买人编号
        /// </summary>
        public string PeopleID { get; set; }
    }
}