//机票政策信息相关 汪奇志 2014-11-12
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.JPStructure
{
    #region 机票政策信息业务实体
    /// <summary>
    /// 机票政策信息业务实体
    /// </summary>
    public class MZhengCeInfo
    {
        /// <summary>
        /// 政策编号 xml>JIT-Policy-Response>Response.PolicyId
        /// </summary>
        public string ZhengCeId { get; set; }
        /// <summary>
        /// 供票商代号 xml>JIT-Policy-Response>Response.RateId
        /// </summary>
        public string GongPiaoShangId { get; set; }
        /// <summary>
        /// 出发城市,多个以’|’分割 xml>JIT-Policy-Response>Response.ScityE
        /// </summary>
        public string ChuFaChengShi { get; set; }
        /// <summary>
        /// 到达城市,多个以’|’分割 xml>JIT-Policy-Response>Response.EcityE
        /// </summary>
        public string DaoDaChengShi { get; set; }
        /// <summary>
        /// 适用的航空公司二字码 xml>JIT-Policy-Response>Response.AirComE
        /// </summary>
        public string ShiYongHangKongGongSiErZiMa { get; set; }
        /// <summary>
        /// 不适用的航空公司二字码 xml>JIT-Policy-Response>Response.NoAirComE
        /// </summary>
        public string BuShiYongHangKongGongSiErZiMa { get; set; }
        /// <summary>
        /// 地区限制城市 xml>JIT-Policy-Response>Response.PolicyType
        /// </summary>
        public string DiQuXianZhi { get; set; }
        /// <summary>
        /// 舱位（F/Y）多个以’/’分割 xml>JIT-Policy-Response>Response.Cabin
        /// </summary>
        public string CangWei { get; set; }
        /// <summary>
        /// 航线类型(0:单程/1:往返/2:单程及往返) xml>JIT-Policy-Response>Response.VoyageType
        /// </summary>
        public string HangXianLeiXing { get; set; }
        /// <summary>
        /// 乘客类型(0:散客/1:团队/2:散客及团队) xml>JIT-Policy-Response>Response.UserType
        /// </summary>
        public string ChengKeLeiXing { get; set; }
        /// <summary>
        /// 政策类型(0:普通政策/1:特殊外放政策/2:特殊政策/为空则 xml>JIT-Policy-Response>Response.RateType
        /// </summary>
        public string ZhengCeLeiXing { get; set; }
        /// <summary>
        /// 政策返点 xml>JIT-Policy-Response>Response.Discounts
        /// </summary>
        public string ZhengCeFanDian { get; set; }
        /// <summary>
        /// 开始日期 xml>JIT-Policy-Response>Response.Sdate
        /// </summary>
        public string KaiShiRiQi { get; set; }
        /// <summary>
        /// 结束日期 xml>JIT-Policy-Response>Response.Edate
        /// </summary>
        public string JieShuRiQi { get; set; }
        /// <summary>
        /// 上班时间 xml>JIT-Policy-Response>Response.WorkTimBegin
        /// </summary>
        public string ShangBanShiJian { get; set; }
        /// <summary>
        /// 下班时间 xml>JIT-Policy-Response>Response.WorkTImeEnd
        /// </summary>
        public string XiaBanShiJian { get; set; }
        /// <summary>
        /// 奖励点 xml>JIT-Policy-Response>Response.Rewards
        /// </summary>
        public string JiangLiDian { get; set; }
        /// <summary>
        /// 政策备注 xml>JIT-Policy-Response>Response.Remark
        /// </summary>
        public string ZhengCeBeiZhu { get; set; }
        /// <summary>
        /// 出票类型0：BSP；1：B2B；2：BSP自动出票；3：B2B自动出票；4：CRS xml>JIT-Policy-Response>Response.ET
        /// </summary>
        public string ChuPiaoLeiXing { get; set; }
        /// <summary>
        /// 星期 xml>JIT-Policy-Response>Response.WP
        /// </summary>
        public string XingQi { get; set; }
        /// <summary>
        /// 出票速度 xml>JIT-Policy-Response>Response.SP
        /// </summary>
        public string ChuPiaoSuDu { get; set; }
        /// <summary>
        /// 平台管理费 xml>JIT-Policy-Response>Response.XF
        /// </summary>
        public string PingTaiGuanLiFei { get; set; }
        /// <summary>
        /// 促销返点 xml>JIT-Policy-Response>Response.PromotionDiscount
        /// </summary>
        public string CuXiaoFanDian { get; set; }
        /// <summary>
        /// 新平台政策编号 xml>JIT-Policy-Response>Response.NewRateNo
        /// </summary>
        public string XinPingTaiZhengCeId { get; set; }
        /// <summary>
        /// 供票商工作号 xml>JIT-Policy-Response>Response.OfficeNum
        /// </summary>
        public string GongPiaoShangGongZuoHao { get; set; }
        /// <summary>
        /// 退废票上班时间 xml>JIT-Policy-Response>Response.RefundTimeBegin
        /// </summary>
        public string TuiFeiPiaoShangBanShiJian { get; set; }
        /// <summary>
        /// 退废票下班时间 xml>JIT-Policy-Response>Response.RefundTimeEnd
        /// </summary>
        public string TuiFeiPiaoXiaBanShiJian { get; set; }
        /// <summary>
        /// 最后一次更新时间 xml>JIT-Policy-Response>Response.LastModifyTime
        /// </summary>
        public string ZuiHouGengXinShiJian { get; set; }
    }
    #endregion

    #region 机票政策信息查询实体-按政策编号
    /// <summary>
    /// 机票政策信息查询实体-按政策编号
    /// </summary>
    public class MZhengCeChaXunInfo1
    {
        /// <summary>
        /// 政策编号
        /// </summary>
        public string ZhengCeId { get; set; }
        /// <summary>
        /// 出发城市三字码
        /// </summary>
        public string ChuFaChengShiSanZiMa { get; set; }
        /// <summary>
        /// 到达城市三字码
        /// </summary>
        public string DaoDaChengShiSanZiMa { get; set; }
        /// <summary>
        /// 服务商ID
        /// </summary>
        public string FuWuShangId { get; set; }
    }
    #endregion

    #region 机票政策信息查询实体-按航班信息
    /// <summary>
    /// 机票政策信息查询实体-按航班信息
    /// </summary>
    public class MZhengCeChaXunInfo2
    {
        /// <summary>
        /// 出发城市三字码
        /// </summary>
        public string ChuFaChengShiSanZiMa { get; set; }
        /// <summary>
        /// 到达城市三字码
        /// </summary>
        public string DaoDaChengShiSanZiMa { get; set; }
        /// <summary>
        /// 起飞日期
        /// </summary>
        public DateTime QiFeiRiQi { get; set; }
        /// <summary>
        /// 航空公司二字码
        /// </summary>
        public string HangKongGongSiErZiMa { get; set; }
        /// <summary>
        /// 舱位（A为全部）
        /// </summary>
        public string CangWei { get; set; }
        /// <summary>
        /// 政策类型(0:普通政策/1:特殊外放政策/2:特殊政策)
        /// </summary>
        public string ZhengCeLeiXing { get; set; }
        /// <summary>
        /// 乘客类型(0:散客/1:团队/2:散客及团队)
        /// </summary>
        public string ChengKeLeiXing { get; set; }
        /// <summary>
        /// 航线类型(0:单程/1:往返/2:单程及往返)
        /// </summary>
        public string HangXianLeiXing { get; set; }
        /// <summary>
        /// 航班号
        /// </summary>
        public string HangBanHao { get; set; }
        /// <summary>
        /// 要获取的政策数量
        /// </summary>
        public int ZhengCeShuLiang { get; set; }
        /// <summary>
        /// 服务商ID
        /// </summary>
        public string FuWuShangId { get; set; }
    }
    #endregion

    #region 机票政策信息查询实体-按PNR信息
    /// <summary>
    /// 机票政策信息查询实体-按PNR信息
    /// </summary>
    public class MZhengCeChaXunInfo3
    {
        /// <summary>
        /// pnr编码
        /// </summary>
        public string PNR { get; set; }
        /// <summary>
        /// pnr信息
        /// </summary>
        public string PnrInfo { get; set; }
        /// <summary>
        /// 政策类型 默认全部
        /// </summary>
        public string ZhengCeLeiXing { get; set; }
        /// <summary>
        /// 航班类型 0：单程  1：往返程  2:单程及往返
        /// </summary>
        public string HangBanLeiXing { get; set; }
        /// <summary>
        /// 乘客类型 A:成人， C:儿童。 默认为A
        /// </summary>
        public string ChengKeLeiXing { get; set; }
        /// <summary>
        /// 要获取的政策数量
        /// </summary>
        public int ZhengCeShuLiang { get; set; }
        /// <summary>
        /// 服务商ID
        /// </summary>
        public string FuWuShangId { get; set; }
    }
    #endregion
}
