using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.Enum;

namespace EyouSoft.Model.MallStructure
{
    public class MShangChengDingDan
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductID { get; set; }
        /// <summary>
        /// 产品数量
        /// </summary>
        public int ProductNum { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal OrderPrice { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public EyouSoft.Model.Enum.XianLuStructure.OrderStatus OrderState { get; set; }
        /// <summary>
        /// 支付状态
        /// </summary>
        public EyouSoft.Model.Enum.PaymentState PayState { get; set; }
        /// <summary>
        /// 下单人编号
        /// </summary>
        public string ContactID { get; set; }
        /// <summary>
        /// 下单人姓名
        /// </summary>
        public string ContactName { get; set; }
        /// <summary>
        /// 下单人联系方式
        /// </summary>
        public string ContactPhone { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public EyouSoft.Model.MemberStructure.MDiZhi Address { get; set; }
        /// <summary>
        ///  分销商编号
        /// </summary>
        public string SupplierID { get; set; }
        /// <summary>
        /// 分销商金额
        /// </summary>
        public decimal SupplierMoney { get; set; }
        /// <summary>
        /// 下单人会员类型
        /// </summary>
        public MemberTypes UserType { get; set; }
        /// <summary>
        /// 下单人姓名
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 下单人联系电话
        /// </summary>
        public string OperatorMobile { get; set; }
        /// <summary>
        /// 订单来源
        /// </summary>
        public OrderSite OrderSite { get; set; }


        #region  扩展属性
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 下单开始时间
        /// </summary>
        public DateTime XiaDanBeginTime { get; set; }
        /// <summary>
        /// 下单结束时间
        /// </summary>
        public DateTime XiaDanEndTime { get; set; }
        #endregion
    }
    public class MShangChengDingDanSer
    {
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string GYSid { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 下单开始时间
        /// </summary>
        public DateTime XiaDanBeginTime { get; set; }
        /// <summary>
        /// 下单结束时间
        /// </summary>
        public DateTime XiaDanEndTime { get; set; }
        /// <summary>
        /// 下单人编号
        /// </summary>
        public string ContactID { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderState? OrderState { get; set; }
        /// <summary>
        /// 分销商id
        /// </summary>
        public string SupplierID { get; set; }

    }
}
