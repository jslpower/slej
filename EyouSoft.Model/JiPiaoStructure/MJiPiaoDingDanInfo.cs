/*//机票订单信息相关业务实体 汪奇志 2013-12-03
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.JiPiaoStructure
{
    #region 机票订单信息业务实体
    /// <summary>
    /// 机票订单信息业务实体
    /// </summary>
    public class MJiPiaoDingDanInfo
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string DingDanId { get; set; }
        /// <summary>
        /// 航班编号
        /// </summary>
        public string HangBanId { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string DingDanHao { get; set; }
        /// <summary>
        /// 出发日期
        /// </summary>
        public DateTime ChuFaRiQi { get; set; }
        /// <summary>
        /// 联系姓名
        /// </summary>
        public string LxrXingMing { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string LxrDianHua { get; set; }
        /// <summary>
        /// 联系邮箱
        /// </summary>
        public string LxrYouXiang { get; set; }
        /// <summary>
        /// 联系地址
        /// </summary>
        public string LxrDiZhi { get; set; }
        /// <summary>
        /// 下单备注
        /// </summary>
        public string BeiZhu { get; set; }
        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal JinE { get; set; }
        /// <summary>
        /// 下单人编号
        /// </summary>
        public string XiaDanRenId { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime IssueTime { get; set; }
        /// <summary>
        /// 接口订单编号
        /// </summary>
        public string ApiDingDanId { get; set; }
        /// <summary>
        /// 是否需要报销凭证
        /// </summary>
        public bool IsBaoXiaoPingZheng { get; set; }
        /// <summary>
        /// 报销凭证收件人姓名
        /// </summary>
        public string PzXingMing { get; set; }
        /// <summary>
        /// 报销凭证收件人省份
        /// </summary>
        public int PzShengFenId { get; set; }
        /// <summary>
        /// 报销凭证收件人城市
        /// </summary>
        public int PzChengShiId { get; set; }
        /// <summary>
        /// 报销凭证收件人县区
        /// </summary>
        public int PzXianQuId { get; set; }
        /// <summary>
        /// 报销凭证收件人地址
        /// </summary>
        public string PzDiZhi { get; set; }
        /// <summary>
        /// 报销凭证收件人电话
        /// </summary>
        public string PzDianHua { get; set; }
        /// <summary>
        /// 报销凭证收件人邮编
        /// </summary>
        public string PzYouBian { get; set; }
        /// <summary>
        /// 确认方式
        /// </summary>
        public EyouSoft.Model.Enum.JiPiaoStructure.QueRenFangShi QueRenFangShi { get; set; }
        /// <summary>
        /// 出票方式
        /// </summary>
        public EyouSoft.Model.Enum.JiPiaoStructure.ChuPiaoFangShi ChuPiaoFangShi { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public EyouSoft.Model.Enum.XianLuStructure.OrderStatus DingDanStatus { get; set; }
        /// <summary>
        /// 付款状态
        /// </summary>
        public EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus FuKuanStatus { get; set; }
        /// <summary>
        /// 出票状态
        /// </summary>
        public EyouSoft.Model.Enum.JiPiaoStructure.ChuPiaoStatus ChuPiaoStatus { get; set; }
        /// <summary>
        /// 乘机人信息集合
        /// </summary>
        public IList<MJiPiaoChengJiRenInfo> ChengJiRens { get; set; }
        /// <summary>
        /// API返点金额
        /// </summary>
        public decimal ApiFaDianJinE { get; set; }
        /// <summary>
        /// API订单金额
        /// </summary>
        public decimal ApiJinE { get; set; }
        /// <summary>
        /// 付款时间
        /// </summary>
        public DateTime FuKuanTime { get; set; }
    }
    #endregion

    #region 机票订单查询信息业务实体
    /// <summary>
    /// 机票订单查询信息业务实体
    /// </summary>
    public class MJiPiaoDingDanChaXunInfo
    {
        /// <summary>
        /// 下单人编号
        /// </summary>
        public string XiaDanRenId { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string DingDanHao { get; set; }
        /// <summary>
        /// 下单开始时间
        /// </summary>
        public DateTime? XiaDanSTime { get; set; }
        /// <summary>
        /// 下单截止时间
        /// </summary>
        public DateTime? XiaDanETime { get; set; }
        /// <summary>
        /// 出发起始日期
        /// </summary>
        public DateTime? ChuFaSRiQi { get; set; }
        /// <summary>
        /// 出发截止日期
        /// </summary>
        public DateTime? ChuFaERiQi { get; set; }
        /// <summary>
        /// 乘机人姓名
        /// </summary>
        public string CjrXingMing { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string LxrXingMing { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public EyouSoft.Model.Enum.XianLuStructure.OrderStatus? DingDanStatus { get; set; }
        /// <summary>
        /// 付款状态
        /// </summary>
        public EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus? FuKuanStatus { get; set; }
        /// <summary>
        /// 出票状态
        /// </summary>
        public EyouSoft.Model.Enum.JiPiaoStructure.ChuPiaoStatus? ChuPiaoStatus { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string DingDanId { get; set; }

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

    #region 机票乘机人信息业务实体
    /// <summary>
    /// 机票乘机人信息业务实体
    /// </summary>
    public class MJiPiaoChengJiRenInfo
    {
        /// <summary>
        /// 自增编号
        /// </summary>
        public int IdentityId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string XingMing { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string DianHua { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public EyouSoft.Model.Enum.YouKeType LeiXing { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string ShenFenZhengHaoMa { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public EyouSoft.Model.Enum.CardType ZhengJianLeiXing { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string ZhengJianHaoMa { get; set; }
        /// <summary>
        /// 航空意外险份数
        /// </summary>
        public int YiWaiXian { get; set; }
        /// <summary>
        /// 航空延误险份数
        /// </summary>
        public int YanWuXian { get; set; }
        /// <summary>
        /// 航空意外险单价
        /// </summary>
        public decimal YiWaiXianJiaGe { get; set; }
        /// <summary>
        /// 航空延误险单价
        /// </summary>
        public decimal YanWuXianJiaGe { get; set; }
        /// <summary>
        /// 是否发送短信
        /// </summary>
        public bool IsDuanXin { get; set; }
    }
    #endregion

    #region 机票API下单返回信息
    /// <summary>
    /// 机票API下单返回信息
    /// </summary>
    public class MApiXiaDanInfo
    {
        /// <summary>
        /// 下单结果 1成功 其它失败
        /// </summary>
        public int RetCode { get; set; }
        /// <summary>
        /// 错误提示信息
        /// </summary>
        public string CuoWuTiShi { get; set; }
        /// <summary>
        /// API订单号
        /// </summary>
        public string ApiDingDanHao { get; set; }
        /// <summary>
        /// API返点金额
        /// </summary>
        public decimal ApiFaDianJinE { get; set; }
        /// <summary>
        /// API订单金额
        /// </summary>
        public decimal ApiJinE { get; set; }
    }
    #endregion
}
*/