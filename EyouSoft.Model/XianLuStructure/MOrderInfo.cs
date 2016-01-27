//线路产品订单信息业务实体 汪奇志 2013-03-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.Enum.XianLuStructure;
using EyouSoft.Model.Enum;

namespace EyouSoft.Model.XianLuStructure
{
    #region 线路订单信息业务实体
    /// <summary>
    /// 线路订单信息业务实体
    /// </summary>
    public partial class MOrderInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MOrderInfo() { }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 线路编号
        /// </summary>
        public string XianLuId { get; set; }
        /// <summary>
        /// 线路名称
        /// </summary>
        public string XianLuName { get; set; }
        /// <summary>
        /// 团队编号
        /// </summary>
        public string TourId { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderStatus Status { get; set; }
        /// <summary>
        /// 成人数
        /// </summary>
        public int ChengRenShu { get; set; }
        /// <summary>
        /// 儿童数
        /// </summary>
        public int ErTongShu { get; set; }
        /// <summary>
        /// 合同金额
        /// </summary>
        public decimal JinE { get; set; }
        /// <summary>
        /// 分销金额
        /// </summary>
        public decimal AgencyJinE { get; set; }
        /// <summary>
        /// 分销商ID
        /// </summary>
        public string AgencyId { get; set; }
        /// <summary>
        /// 付款状态
        /// </summary>
        public FuKuanStatus FuKuanStatus { get; set; }
        /// <summary>
        /// 出发日期
        /// </summary>
        public DateTime LDate { get; set; }
        /// <summary>
        /// 其它要求
        /// </summary>
        public string QiTaBeiZhu { get; set; }
        /// <summary>
        /// 下单备注
        /// </summary>
        public string XiaDanBeiZhu { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string LxrName { get; set; }
        /// <summary>
        /// 联系人电话
        /// </summary>
        public string LxrTelephone { get; set; }
        /// <summary>
        /// 联系人性别
        /// </summary>
        public Gender LxrGender { get; set; }
        /// <summary>
        /// 联系人证件类型
        /// </summary>
        public CardType LxrZhengJianType { get; set; }
        /// <summary>
        /// 联系人证件号码
        /// </summary>
        public string LxrZhengJianCode { get; set; }
        /// <summary>
        /// 下单人[会员]编号
        /// </summary>
        public string OperatorId { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 游客信息集合
        /// </summary>
        public IList<MOrderYouKeInfo> YouKes { get; set; }
        /// <summary>
        /// 订单变更历史记录信息集合
        /// </summary>
        public IList<MOrderHistoryInfo> Historys { get; set; }
        /// <summary>
        /// 线路发班信息集合
        /// </summary>
        public IList<MXianLuTourTraffice> Traffice { get; set; }
        /// <summary>
        /// 团购编号
        /// </summary>
        public string TuanGouId { get; set; }
        /// <summary>
        /// 线路来源
        /// </summary>
        public LineSource Line_Source { set; get; }
        /// <summary>
        /// 会员类型
        /// </summary>
        public MemberTypes UserType { set; get; }
        /// <summary>
        /// 线路类型
        /// </summary>
        public AreaType RouteType { set; get; }
        /// <summary>
        /// 预定人手机
        /// </summary>
        public string Mobile { set; get; }
        /// <summary>
        /// 预定人姓名
        /// </summary>
        public string MemberName { set; get; }

        /// <summary>
        /// API ORDER ID
        /// </summary>
        public string Api_OrderId { get; set; }
        /// <summary>
        /// 航班号
        /// </summary>
        public string TrafficId { get; set; }
        /// <summary>
        /// 订单来源
        /// </summary>
        public OrderSite OrderSite { get; set; }
        /// <summary>
        /// 客户交易成人价
        /// </summary>
        public decimal JiaoYiCR { get; set; }
        /// <summary>
        /// 客户交易儿童价
        /// </summary>
        public decimal JiaoYiET { get; set; }
        /// <summary>
        /// 分销交易成人价
        /// </summary>
        public decimal WebSiteCR { get; set; }
        /// <summary>
        /// 分销交易成人价
        /// </summary>
        public decimal WebSiteET { get; set; }
    }
    #endregion

    #region 线路订单游客信息业务实体
    /// <summary>
    /// 线路订单游客信息业务实体
    /// </summary>
    public partial class MOrderYouKeInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MOrderYouKeInfo() { }

        /// <summary>
        /// 游客编号
        /// </summary>
        public string YouKeId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public YouKeType LeiXing { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IdCode { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public CardType ZhengJianType { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string ZhengJianCode { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string BeiZhu { get; set; }
        /// <summary>
        /// 自增编号
        /// </summary>
        public int IdentityId { get; set; }
    }
    #endregion

    #region 线路订单变更信息业务实体
    /// <summary>
    /// 线路订单变更信息业务实体
    /// </summary>
    public partial class MOrderHistoryInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MOrderHistoryInfo() { }

        /// <summary>
        /// 自增编号
        /// </summary>
        public int IdentityId { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 当前状态
        /// </summary>
        public OrderStatus Status { get; set; }
        /// <summary>
        /// 变更备注
        /// </summary>
        public string BeiZhu { get; set; }
        /// <summary>
        /// 操作人编号
        /// </summary>
        public string OperatorId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public OrderHistoryLeiXing LeiXing { get; set; }
        /// <summary>
        /// 操作人姓名
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 操作人类型
        /// </summary>
        public OperatorLeiXing OperatorLeiXing { get; set; }
    }
    #endregion
    #region 线路订单查询信息业务实体
    /// <summary>
    /// 线路订单查询信息业务实体
    /// </summary>
    public class MOrderChaXunInfo
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public MOrderChaXunInfo() { }

        /// <summary>
        /// 会员编号
        /// </summary>
        public string HuiYuanId { get; set; }
        /// <summary>
        /// 分销商id
        /// </summary>
        public string AgencyId { get; set; }
        /// <summary>
        /// 线路编号
        /// </summary>
        public string XianLuId { get; set; }
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
        public OrderStatus? OrderStatus { get; set; }
        /// <summary>
        /// 付款状态
        /// </summary>
        public FuKuanStatus? FuKuanStatus { get; set; }
        /// <summary>
        /// 团购编号
        /// </summary>
        public string TuanGouId { get; set; }
        /// <summary>
        /// 线路名称
        /// </summary>
        public string RouteName { get; set; }
        /// <summary>
        /// 线路类型
        /// </summary>
        public AreaType? RouteType { set; get; }
        /// <summary>
        /// 付款金额
        /// </summary>
        public string JinE { get; set; }
        /// <summary>
        /// 是否非会员查询
        /// </summary>
        public bool IsFeiHuiYuan { get; set; }
        /// <summary>
        /// 非会员查询-订单号
        /// </summary>
        public string FeiHuiYuanDingDanHao { get; set; }
        /// <summary>
        /// 非会员查询-姓名
        /// </summary>
        public string FeiHuiYuanXingMing { get; set; }
        /// <summary>
        /// 非会员查询-联系电话
        /// </summary>
        public string FeiHuiYuanDianHua { get; set; }
    }
    #endregion
}
