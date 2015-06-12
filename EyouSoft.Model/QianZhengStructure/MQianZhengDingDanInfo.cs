//签证订单信息业务实体 汪奇志 2013-11-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.QianZhengStructure
{
    #region 签证订单信息业务实体
    /// <summary>
    /// 签证订单信息业务实体
    /// </summary>
    public class MQianZhengDingDanInfo
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string DingDanId { get; set; }
        /// <summary>
        /// 签证编号
        /// </summary>
        public string QianZhengId { get; set; }
        /// <summary>
        /// 预订时间
        /// </summary>
        public DateTime YuDingShiJian { get; set; }
        /// <summary>
        /// 预订数量
        /// </summary>
        public int YuDingShuLiang { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string LxrXingMing { get; set; }
        /// <summary>
        /// 联系人电话
        /// </summary>
        public string LxrDianHua { get; set; }
        /// <summary>
        /// 联系人邮箱
        /// </summary>
        public string LxrYouXiang { get; set; }
        /// <summary>
        /// 联系人地址
        /// </summary>
        public string LxrDiZhi { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string BeiZhu { get; set; }
        /// <summary>
        /// 预订单价
        /// </summary>
        public decimal DanJia { get; set; }
        /// <summary>
        /// 结算费用
        /// </summary>
        public decimal JinE { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public EyouSoft.Model.Enum.XianLuStructure.OrderStatus DingDanStatus { get; set; }
        /// <summary>
        /// 付款状态
        /// </summary>
        public EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus FuKuanStatus { get; set; }
        /// <summary>
        /// 下单人编号
        /// </summary>
        public string XiaDanRenId { get; set; }
        /// <summary>
        /// 订单来源
        /// </summary>
        public EyouSoft.Model.Enum.QianZhengStructure.DingDanLaiYuan LaiYuan { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime LatestTime { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string DingDanHao { get; set; }

        /// <summary>
        /// 签证名称(OUTPUT)
        /// </summary>
        public string QianZhengName { get; set; }
        /// <summary>
        /// 签证国家编号(OUTPUT)
        /// </summary>
        public int QianZhengGuoJiaId { get; set; }
        /// <summary>
        /// 付款时间
        /// </summary>
        public DateTime FuKuanTime { get; set; }
        /// <summary>
        /// 分销商ID
        /// </summary>
        public string AgencyId { get; set; }
        /// <summary>
        /// 分销金额
        /// </summary>
        public decimal AgencyJinE { get; set; }
    }
    #endregion

    #region 签证订单查询信息业务实体
    /// <summary>
    /// 签证订单查询信息业务实体
    /// </summary>
    public class MQianZhengDingDanChaXunInfo
    {
        /// <summary>
        /// 下单人编号
        /// </summary>
        public string XiaDanRenId { get; set; }
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string GysId { get; set; }
        /// <summary>
        ///  签证编号
        /// </summary>
        public string QianZhengId { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string LxrXingMing { get; set; }
        /// <summary>
        /// 预订开始时间
        /// </summary>
        public DateTime? XiaDanSTime { get; set; }
        /// <summary>
        /// 预订截止时间
        /// </summary>
        public DateTime? XiaDanETime { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public EyouSoft.Model.Enum.XianLuStructure.OrderStatus? DingDanStatus { get; set; }
        /// <summary>
        /// 付款状态
        /// </summary>
        public EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus? FuKuanStatus { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        public EyouSoft.Model.Enum.QianZhengStructure.DingDanLaiYuan? LaiYuan { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string DingDanHao { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string DingDanHaoUniqueID { get; set; }
        /// <summary>
        /// 签证名称
        /// </summary>
        public string QianZhengName { get; set; }
        /// <summary>
        /// 签证国家编号
        /// </summary>
        public int? QianZhengGuoJiaId { get; set; }
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
        /// <summary>
        /// 分销商Id
        /// </summary>
        public string AgencyId { get; set; }
    }
    #endregion
}
