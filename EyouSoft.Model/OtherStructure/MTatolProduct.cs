using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.OtherStructure
{
    #region 实体
    /// <summary>
    /// 积分产品信息
    /// </summary>
    [Serializable]
    public class MTatolProduct
    {
        /// <summary>
        /// 积分产品编号
        /// </summary>
        public int ProductID { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 产品类别
        /// </summary>
        public EyouSoft.Model.Enum.ProductClass ProductClass { get; set; }
        /// <summary>
        /// 产品数量
        /// </summary>
        public int Num { get; set; }
        /// <summary>
        /// 所需积分
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// 市场价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 产品信息
        /// </summary>
        public string ProductInfo { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 发布用户
        /// </summary>
        public string OperatorId { get; set; }
        /// <summary>
        /// 产品图片集合
        /// </summary>
        public IList<MTatolProductPic> PicList { get; set; }

        /// <summary>
        /// 产品兑换数量
        /// </summary>
        public int ExchangeNum { get; set; }
        /// <summary>
        /// 产品库存数量
        /// </summary>
        public int KunCunNum { get { return (Num - ExchangeNum); } }
        /// <summary>
        /// 用户总积分
        /// </summary>
        public int SumTotal { get; set; }
        /// <summary>
        /// 用户已兑换积分
        /// </summary>
        public int ExchangeTotal { get; set; }
        /// <summary>
        /// 用户可用积分
        /// </summary>
        public int KeYongTotal { get { return (SumTotal - ExchangeTotal); } }
        /// <summary>
        /// 产品发布人
        /// </summary>
        public string OperatorName { get; set; }

        /// <summary>
        /// 产品图片
        /// </summary>
        public string Pic { get; set; }
    }

    /// <summary>
    /// 积分产品图片
    /// </summary>
    [Serializable]
    public class MTatolProductPic
    {
        /// <summary>
        /// 图片编号
        /// </summary>
        public int PicID { get; set; }
        /// <summary>
        /// 积分产品编号
        /// </summary>
        public int ProductID { get; set; }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// 图片描述
        /// </summary>
        public string Desc { get; set; }
    }

    /// <summary>
    /// 积分产品兑换信息
    /// </summary>
    [Serializable]
    public class MTotalToProduct
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 会员编号
        /// </summary>
        public string MemberID { get; set; }
        /// <summary>
        /// 积分产品编号
        /// </summary>
        public int ProductID { get; set; }
        /// <summary>
        /// 兑换数量
        /// </summary>
        public int Num { get; set; }
        /// <summary>
        /// 所兑积分
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// 兑换时间
        /// </summary>
        public DateTime ExchangeTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public EyouSoft.Model.Enum.ExchangeStatus Status { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        public string OperatorId { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? IssueTime { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 会员账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 会员姓名
        /// </summary>
        public string MemberName { get; set; }
        /// <summary>
        /// 审核人姓名
        /// </summary>
        public string OperatorName { get; set; }
    }

    /// <summary>
    /// 个人会员积分获取信息
    /// </summary>
    [Serializable]
    public class MMemberTotal
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 会员编号
        /// </summary>
        public string MemberID { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        public EyouSoft.Model.Enum.OrderClass OrderType { get; set; }
        /// <summary>
        /// 所获积分
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// 获取时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 有效时间
        /// </summary>
        public DateTime? ValidTime { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 会员账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 会员姓名
        /// </summary>
        public string MemberName { get; set; }
    }

    /// <summary>
    /// 个人会员联系信息表
    /// </summary>
    public class MMemberContact
    {
        public MMemberContact() { }

        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 会员编号
        /// </summary>
        public string MemberID { get; set; }
        /// <summary>
        /// 会员姓名
        /// </summary>
        public string MemberName { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactTel { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 邮编
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string BenZhu { get; set; }
    }

    #endregion

    #region 查询实体
    /// <summary>
    /// 积分产品查询实体
    /// </summary>
    [Serializable]
    public class MTatolProductCX
    {
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 产品类别
        /// </summary>
        public EyouSoft.Model.Enum.ProductClass? ProductClass { get; set; }
        /// <summary>
        /// 所需积分开始
        /// </summary>
        public int TotalS { get; set; }
        /// <summary>
        /// 所需积分结束
        /// </summary>
        public int TotalE { get; set; }
        /// <summary>
        /// 发布时间开始
        /// </summary>
        public DateTime? IssueTimeS { get; set; }
        /// <summary>
        /// 发布时间结束
        /// </summary>
        public DateTime? IssueTimeE { get; set; }
    }

    /// <summary>
    /// 积分产品兑换信息查询实体
    /// </summary>
    [Serializable]
    public class MTotalToProductCX
    {
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 会员账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 会员姓名
        /// </summary>
        public string MemberName { get; set; }
        /// <summary>
        /// 兑换积分开始
        /// </summary>
        public int TotalS { get; set; }
        /// <summary>
        /// 兑换积分结束
        /// </summary>
        public int TotalE { get; set; }
        /// <summary>
        /// 兑换时间开始
        /// </summary>
        public DateTime? ExchangeTimeS { get; set; }
        /// <summary>
        /// 兑换时间结束
        /// </summary>
        public DateTime? ExchangeTimeE { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public EyouSoft.Model.Enum.ExchangeStatus? Status { get; set; }
        /// <summary>
        /// 审核时间开始
        /// </summary>
        public DateTime? IssueTimeS { get; set; }
        /// <summary>
        /// 审核时间结束
        /// </summary>
        public DateTime? IssueTimeE { get; set; }
    }

    /// <summary>
    /// 个人会员积分获取信息查询实体
    /// </summary>
    [Serializable]
    public class MMemberTotalCX
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 会员账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 会员姓名
        /// </summary>
        public string MemberName { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        public EyouSoft.Model.Enum.OrderClass? OrderType { get; set; }
        /// <summary>
        /// 所获积分开始
        /// </summary>
        public int TotalS { get; set; }
        /// <summary>
        /// 所获积分结束
        /// </summary>
        public int TotalE { get; set; }
        /// <summary>
        /// 获取时间开始
        /// </summary>
        public DateTime? IssueTimeS { get; set; }
        /// <summary>
        /// 获取时间结束
        /// </summary>
        public DateTime? IssueTimeE { get; set; }
        /// <summary>
        /// 有效时间开始
        /// </summary>
        public DateTime? ValidTimeS { get; set; }
        /// <summary>
        /// 有效时间结束
        /// </summary>
        public DateTime? ValidTimeE { get; set; }


    }
    #endregion
}
