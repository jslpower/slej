//机票订单信息相关 汪奇志 2014-11-12
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EyouSoft.Model.JPStructure
{
    #region 今日天下通API-机票订单信息业务实体
    /// <summary>
    /// 今日天下通API-机票订单信息业务实体
    /// </summary>
    public class MJinRi_Api_DingDanInfo
    {
        /// <summary>
        /// 订单编号（API） xml>JIT-Order-Response>Response>OrderNo
        /// </summary>
        public string ApiDingDanId { get; set; }
        /// <summary>
        /// Pnr编码 xml>JIT-Order-Response>Response>PNR
        /// </summary>
        public string PNR { get; set; }
        /// <summary>
        /// 给客户的优惠点 xml>JIT-Order-Response>Response>GrowDiscount
        /// </summary>
        public decimal KeHuYouHuiDian { get; set; }
        /// <summary>
        /// 经销商的利润点 xml>JIT-Order-Response>Response>StayDiscount
        /// </summary>
        public decimal JingXiaoShangLiRunDian { get; set; }
        /// <summary>
        /// 订单金额（包含基建燃油费）xml>JIT-Order-Response>Response>Paymoney
        /// </summary>
        public decimal JinE { get; set; }
        /// <summary>
        /// 经销商的利润 xml>JIT-Order-Response>Response>Profit
        /// </summary>
        public decimal JingXiaoShangLiRun { get; set; }
        /// <summary>
        /// 订单状态（API） xml>JIT-Order-Response>Response>Status
        /// </summary>
        public string ApiStatus { get; set; }
        /// <summary>
        /// 政策编号 xml>JIT-Order-Response>Response>RateID
        /// </summary>
        public string ZhengCeId { get; set; }
        /// <summary>
        /// 航班日期 xml>JIT-Order-Response>Response>Date
        /// </summary>
        public DateTime HangBanRiQi { get; set; }
        /// <summary>
        /// 出发城市三字码 xml>JIT-Order-Response>Response>Scity
        /// </summary>
        public string ChuFaChengShiSanZiMa { get; set; }
        /// <summary>
        /// 到达城市三字码 xml>JIT-Order-Response>Response>Ecity
        /// </summary>
        public string DaoDaChengShiSanZiMa { get; set; }
        /// <summary>
        /// 航班号 xml>JIT-Order-Response>Response>Flight
        /// </summary>
        public string HangBanHao { get; set; }
        /// <summary>
        /// 起飞时间 xml>JIT-Order-Response>Response>Stime
        /// </summary>
        public string QiFeiShiJian { get; set; }
        /// <summary>
        /// 到达时间 xml>JIT-Order-Response>Response>Etime
        /// </summary>
        public string DaoDaShiJian { get; set; }
        /// <summary>
        /// 舱位 xml>JIT-Order-Response>Response>Cabin
        /// </summary>
        public string CangWei { get; set; }
        /// <summary>
        /// 票面价格 xml>JIT-Order-Response>Response>Price
        /// </summary>
        public decimal PiaoMianJiaGe { get; set; }
        /// <summary>
        /// 税费金额（机场建设费+燃油费）xml>JIT-Order-Response>Response>Tax
        /// </summary>
        public decimal ShuiFeiJinE { get; set; }
        /// <summary>
        /// 订票人数 xml>JIT-Order-Response>Response>PCount
        /// </summary>
        public int DingPiaoRenShu { get; set; }
        /// <summary>
        /// 乘客姓名集合 xml>JIT-Order-Response>Response>PName
        /// </summary>
        public string ChengKeXingMing { get; set; }
        /// <summary>
        /// 下单时间（API）xml>JIT-Order-Response>Response>OrderTime
        /// </summary>
        public DateTime ApiXiaDanShiJian { get; set; }
        /// <summary>
        /// 支付时间 xml>JIT-Order-Response>Response>PayTime
        /// </summary>
        public DateTime ZhiFuShiJian { get; set; }
        /// <summary>
        /// 取消时间 xml>JIT-Order-Response>Response>CanTime
        /// </summary>
        public DateTime QuXiaoShiJian { get; set; }
        /// <summary>
        /// 退款时间 xml>JIT-Order-Response>Response>Rtime
        /// </summary>
        public DateTime TuiKuanShiJian { get; set; }
        /// <summary>
        /// 退款详细说明 xml>JIT-Order-Response>Response>Repeal
        /// </summary>
        public string TuiKuanShuoMing { get; set; }
        /// <summary>
        /// 出票时间 xml>JIT-Order-Response>Response>OutTime
        /// </summary>
        public DateTime ChuPiaoShiJian { get; set; }
        /// <summary>
        /// 退废票处理时间 xml>JIT-Order-Response>Response>OverTime
        /// </summary>
        public DateTime TuiFeiPiaoChuLiShiJian { get; set; }
        /// <summary>
        /// 支付方式（API） xml>JIT-Order-Response>Response>PayWay
        /// </summary>
        public string ApiZhiFuFangShi { get; set; }
        /// <summary>
        /// 退费票人数 xml>JIT-Order-Response>Response>RCount
        /// </summary>
        public int TuiFeiPiaoRenShu { get; set; }
        /// <summary>
        /// 退费票说明 xml>JIT-Order-Response>Response>RInfo
        /// </summary>
        public string TuiFeiPiaoShuoMing { get; set; }
        /// <summary>
        /// 实际退款金额 xml>JIT-Order-Response>Response>RMoney
        /// </summary>
        public decimal ShiJiTuiKuanJinE { get; set; }
        /// <summary>
        /// 票号，多个以”|”分割 xml>JIT-Order-Response>Response>TicketNo
        /// </summary>
        public string PiaoHao { get; set; }
        /// <summary>
        /// 客票类型 xml>JIT-Order-Response>Response>TicketType
        /// </summary>
        public string KePiaoLeiXing { get; set; }
        /// <summary>
        /// 证件号，多个以”|”分割 xml>JIT-Order-Response>Response>CardNo
        /// </summary>
        public string ZhengJianHao { get; set; }
        /// <summary>
        /// 退废票原因 xml>JIT-Order-Response>Response>Cause
        /// </summary>
        public string TuiFeiPiaoYuanYin { get; set; }
        /// <summary>
        /// 退废票备注 xml>JIT-Order-Response>Response>Remark
        /// </summary>
        public string TuiFeiPiaoBeiZhu { get; set; }
        /// <summary>
        /// 供应商不出票，填写取消的说明 xml>JIT-Order-Response>Response>Explain
        /// </summary>
        public string BuChuPiaoYuanYin { get; set; }
        /// <summary>
        /// 暂时不能出票，发送的消息 xml>JIT-Order-Response>Response>Message
        /// </summary>
        public string BuChuPiaoXiaoXi { get; set; }
        /// <summary>
        /// 暂不能出票时间 xml>JIT-Order-Response>Response>ZcpTime
        /// </summary>
        public string BuChuPiaoShiJian { get; set; }
        /// <summary>
        /// 暂不能废票时间 xml>JIT-Order-Response>Response>ZfpTime
        /// </summary>
        public string BuFeiPiaoShiJian { get; set; }
        /// <summary>
        /// 暂不能退票时间 xml>JIT-Order-Response>Response>ZtpTime
        /// </summary>
        public string BuTuiPiaoShiJian { get; set; }
        /// <summary>
        /// 暂不能退票 xml>JIT-Order-Response>Response>NoCancel
        /// </summary>
        public string BuNengTuiPiao { get; set; }
        /// <summary>
        /// 退款记录 xml>JIT-Order-Response>Response>Rlog
        /// </summary>
        public string TuiKuanJiLu { get; set; }
        /// <summary>
        /// 审核时间 xml>JIT-Order-Response>Response>CheckTime
        /// </summary>
        public string ShenHeShiJian { get; set; }
        /// <summary>
        /// 改签状态 xml>JIT-Order-Response>Response>ZhuanQianStatus
        /// </summary>
        public string GaiQianStatus { get; set; }
        /// <summary>
        /// 改签说明 xml>JIT-Order-Response>Response>ZhuanQianStr
        /// </summary>
        public string GaiQianShuoMing { get; set; }
        /// <summary>
        /// 改签回复 xml>JIT-Order-Response>Response>ZhuanQianReplyStr
        /// </summary>
        public string GaiQianHuiFu { get; set; }
        /// <summary>
        /// 航班延误时间 xml>JIT-Order-Response>Response>FlightDallyTime
        /// </summary>
        public string HangBanYanWuShiJian { get; set; }
        /// <summary>
        /// 航班延误说明 xml>JIT-Order-Response>Response>FlightDallyMark
        /// </summary>
        public string HangBanYanWuShuoMing { get; set; }
        /// <summary>
        /// 采购商ID xml>JIT-Order-Response>Response>ProxyerID
        /// </summary>
        public string CaiGouShangId { get; set; }
        /// <summary>
        /// 供应商ID xml>JIT-Order-Response>Response>ProviderID
        /// </summary>
        public string GongYingShangId { get; set; }
        /// <summary>
        /// 行程单信息 xml>JIT-Order-Response>Response>JourneyTicket
        /// </summary>
        public string XingChengDanXinXi { get; set; }
        /// <summary>
        /// 支付宝交易号 xml>JIT-Order-Response>Response>TradeNo
        /// </summary>
        public string ZhiFuBaoJiaoYiHao { get; set; }
        /// <summary>
        /// 机场建设费 xml>JIT-Order-Response>Response>AirportTax
        /// </summary>
        public decimal JiJianJinE { get; set; }
        /// <summary>
        /// 燃油费 xml>JIT-Order-Response>Response>FuelTax
        /// </summary>
        public decimal RanYouJinE { get; set; }
    }
    #endregion

    #region 今日天下通API-创建订单请求信息业务
    /// <summary>
    /// 今日天下通API-创建订单请求信息业务
    /// </summary>
    public class MJinRi_Api_XiaDanRequestInfo
    {
        /// <summary>
        /// 供票商ID (加密码)
        /// </summary>
        public string GongPiaoShangId { get; set; }
        /// <summary>
        /// 政策ID (GongPiaoShangId和ZhengCeId必须至少有一项)
        /// </summary>
        public string ZhengCeId { get; set; }
        /// <summary>
        /// 乘机人姓名 (多人用“|”分隔)
        /// </summary>
        public string ChengJiRenXingMing { get; set; }
        /// <summary>
        /// 乘机人证件号码 (多人用“|”分隔)(IN开头)
        /// </summary>
        public string ChengJiRenZhengJianHao { get; set; }
        /// <summary>
        /// 舱位号
        /// </summary>
        public string CangWei { get; set; }
        /// <summary>
        /// 航班号
        /// </summary>
        public string HangBanHao { get; set; }
        /// <summary>
        /// 出发城市三字码
        /// </summary>
        public string ChuFaChengShiSanZiMa { get; set; }
        /// <summary>
        /// 到达城市三字码
        /// </summary>
        public string DaoDaChengShiSanZiMa { get; set; }
        /// <summary>
        /// 出发日期
        /// </summary>
        public DateTime ChuFaRiQi { get; set; }
        /// <summary>
        /// 采购返点
        /// </summary>
        public decimal CaiGouFanDian { get; set; }
        /// <summary>
        /// 是否打印行程单 0:不打印 1：打印  与乘机人对应 (格式：1|1|0|0|)
        /// </summary>
        public string ShiFuDaYinXingChengDan { get; set; }
        /// <summary>
        /// 接收方式 0:前台 1:后台
        /// </summary>
        public string JieShouFangShi { get; set; }
        /// <summary>
        /// 政策类型 默认为5 0:普通政策 1:特殊外放政策 2:特殊高返政策
        /// </summary>
        public string ZhengCeLeiXing { get; set; }
        /// <summary>
        /// 航线类型(当前只支持0单程) 0:单程 1:往返 2:单程和往返
        /// </summary>
        public string HangXianLeiXing { get; set; }
        /// <summary>
        /// 是否允许更换PNR出票，默认0 0:允许 1：不允许
        /// </summary>
        public string ShiFouYunXuGengHuanPnr { get; set; }
        /// <summary>
        /// 是否自动代扣 默认为F  T:自动代扣（系统创单后自动扣款） F:不自动代扣
        /// </summary>
        public string ShiFouZiDongDaiKou { get; set; }
        /// <summary>
        /// 乘客类型，默认为成人A（儿童无法和成人一起创单）A:  成人 C:  儿童
        /// </summary>
        public string ChengKeLeiXing { get; set; }
        /// <summary>
        /// 服务商ID
        /// </summary>
        public string FuWuShangId { get; set; }
        /// <summary>
        /// pnr编码
        /// </summary>
        public string PNR { get; set; }
        /// <summary>
        /// pnr信息
        /// </summary>
        public string PnrInfo { get; set; }
    }
    #endregion

    #region 订单信息业务实体
    /// <summary>
    /// 订单信息业务实体
    /// </summary>
    public class MDingDanInfo : ICloneable
    {
        /// <summary>
        /// clone
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            var obj = new MDingDanInfo();

            obj.ApiDingDanId = this.ApiDingDanId;
            obj.ApiJieShouFangShi = this.ApiJieShouFangShi;
            obj.CaiGouFanDian = this.CaiGouFanDian;
            obj.CangWei = this.CangWei;
            obj.ChengKeLeiXing = this.ChengKeLeiXing;
            obj.ChengKes = this.ChengKes;
            obj.ChengRenDingDanId = this.ChengRenDingDanId;
            obj.ChuFaChengShiSanZiMa = this.ChuFaChengShiSanZiMa;
            obj.ChuFaRiQi = this.ChuFaRiQi;
            obj.DaoDaChengShiSanZiMa = this.DaoDaChengShiSanZiMa;
            obj.DaoDaShiJian = this.DaoDaShiJian;
            obj.DingDanStatus = this.DingDanStatus;
            obj.FuKuanStatus = this.FuKuanStatus;
            obj.GongPiaoShangId = this.GongPiaoShangId;
            obj.HangBanHao = this.HangBanHao;
            obj.HangXianLeiXing = this.HangXianLeiXing;
            obj.HuiYuanId = this.HuiYuanId;
            obj.JinE = this.JinE;
            obj.JingXiaoShangLiRun = this.JingXiaoShangLiRun;
            obj.JingXiaoShangLiRunDian = this.JingXiaoShangLiRunDian;
            obj.KeHuYouHuiDian = this.KeHuYouHuiDian;
            obj.PiaoMianJiaGe = this.PiaoMianJiaGe;
            obj.PNR = this.PNR;
            obj.QiFeiShiJian = this.QiFeiShiJian;
            obj.ShiFouYunXuGengHuanPnr = this.ShiFouYunXuGengHuanPnr;
            obj.ShiFouZiDongDaiKou = this.ShiFouZiDongDaiKou;
            obj.ShiFuDaYinXingChengDan = this.ShiFuDaYinXingChengDan;
            obj.ShuiFeiJinE = this.ShuiFeiJinE;
            obj.XiaDanShiJian = this.XiaDanShiJian;
            obj.ZhengCeId = this.ZhengCeId;
            obj.ZhengCeLeiXing = this.ZhengCeLeiXing;
            obj.HangBanInfo = this.HangBanInfo;
            obj.XiangApiFuKuanStatus = this.XiangApiFuKuanStatus;
            obj.XiangApiFuKuanShiJian = this.XiangApiFuKuanShiJian;
            obj.FuKuanShiJian = this.FuKuanShiJian;
            obj.JiaoYiHao = this.JiaoYiHao;
            obj.JiLuJiaGe = this.JiLuJiaGe;
            return obj;
        }

        /// <summary>
        /// 订单编号（系统）
        /// </summary>
        public string DingDanId { get; set; }
        /// <summary>
        /// 订单编号（API）
        /// </summary>
        public string ApiDingDanId { get; set; }
        /// <summary>
        /// 供票商ID (加密码)
        /// </summary>
        public string GongPiaoShangId { get; set; }
        /// <summary>
        /// 政策ID (GongPiaoShangId和ZhengCeId必须至少有一项)
        /// </summary>
        public string ZhengCeId { get; set; }
        /// <summary>
        /// 舱位
        /// </summary>
        public string CangWei { get; set; }
        /// <summary>
        /// 航班号
        /// </summary>
        public string HangBanHao { get; set; }
        /// <summary>
        /// 出发城市三字码
        /// </summary>
        public string ChuFaChengShiSanZiMa { get; set; }
        /// <summary>
        /// 到达城市三字码
        /// </summary>
        public string DaoDaChengShiSanZiMa { get; set; }
        /// <summary>
        /// 出发日期
        /// </summary>
        public DateTime ChuFaRiQi { get; set; }
        /// <summary>
        /// 采购返点
        /// </summary>
        public decimal CaiGouFanDian { get; set; }
        /// <summary>
        /// 是否打印行程单
        /// </summary>
        public ShiFuDaYinXingChengDan ShiFuDaYinXingChengDan { get; set; }
        /// <summary>
        /// 政策类型
        /// </summary>
        public ZhengCeLeiXing ZhengCeLeiXing { get; set; }
        /// <summary>
        /// 航线类型(当前接口只支持单程)
        /// </summary>
        public HangXianLeiXing HangXianLeiXing { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime XiaDanShiJian { get; set; }
        /// <summary>
        /// 乘客信息集合
        /// </summary>
        public IList<MChengKeInfo> ChengKes { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public DingDanStatus DingDanStatus { get; set; }
        /// <summary>
        /// 付款状态
        /// </summary>
        public EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus FuKuanStatus { get; set; }
        /// <summary>
        /// 付款时间
        /// </summary>
        public DateTime FuKuanShiJian { get; set; }
        /// <summary>
        /// Pnr编码
        /// </summary>
        public string PNR { get; set; }
        /// <summary>
        /// PNR信息
        /// </summary>
        public string PnrInfo { get; set; }
        /// <summary>
        /// 给客户的优惠点
        /// </summary>
        public decimal KeHuYouHuiDian { get; set; }
        /// <summary>
        /// 经销商的利润点
        /// </summary>
        public decimal JingXiaoShangLiRunDian { get; set; }
        /// <summary>
        /// 订单金额（不包含基建燃油费）
        /// </summary>
        public decimal JinE { get; set; }
        /// <summary>
        /// 经销商的利润
        /// </summary>
        public decimal JingXiaoShangLiRun { get; set; }
        /// <summary>
        /// 起飞时间
        /// </summary>
        public string QiFeiShiJian { get; set; }
        /// <summary>
        /// 到达时间
        /// </summary>
        public string DaoDaShiJian { get; set; }
        /// <summary>
        /// 票面价格
        /// </summary>
        public decimal PiaoMianJiaGe { get; set; }
        /// <summary>
        /// 税费金额（机场建设费+燃油费）
        /// </summary>
        public decimal ShuiFeiJinE { get; set; }
        /// <summary>
        /// 订票人数
        /// </summary>
        public int DingPiaoRenShu { get; set; }
        /// <summary>
        /// 成人订单编号（儿童订单需要成人订单编号）
        /// </summary>
        public string ChengRenDingDanId { get; set; }
        /// <summary>
        /// 会员编号
        /// </summary>
        public string HuiYuanId { get; set; }
        /// <summary>
        /// 乘客类型
        /// </summary>
        public ChengKeLeiXing ChengKeLeiXing { get; set; }
        /// <summary>
        /// API接收方式
        /// </summary>
        public ApiJieShouFangShi ApiJieShouFangShi { get; set; }
        /// <summary>
        /// 是否允许更换PNR出票
        /// </summary>
        public ShiFouYunXuGengHuanPnr ShiFouYunXuGengHuanPnr { get; set; }
        /// <summary>
        /// 是否自动代扣
        /// </summary>
        public ShiFouZiDongDaiKou ShiFouZiDongDaiKou { get; set; }
        /// <summary>
        /// 取消订单备注
        /// </summary>
        public string QuXiaoBeiZhu { get; set; }
        /// <summary>
        /// 预订的航班信息
        /// </summary>
        public MHangBanInfo HangBanInfo { get; set; }
        /// <summary>
        /// 向API付款状态
        /// </summary>
        public XiangApiFuKuanStatus XiangApiFuKuanStatus { get; set; }
        /// <summary>
        /// 向API付款时间
        /// </summary>
        public DateTime XiangApiFuKuanShiJian { get; set; }
        /// <summary>
        /// 儿童订单编号
        /// </summary>
        public string ErTongDingDanId { get; set; }
        /// <summary>
        /// 交易号
        /// </summary>
        public string JiaoYiHao { get; set; }

        #region 扩展属性
        /// <summary>
        /// 记录订单价格
        /// </summary>
        public decimal JiLuJiaGe { get; set; }
        #endregion
    }
    #endregion

    #region 乘客信息业务实体
    /// <summary>
    /// 乘客信息业务实体
    /// </summary>
    public class MChengKeInfo
    {
        /// <summary>
        /// 乘客编号
        /// </summary>
        public string ChengKeId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string XingMing { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string ZhengJianHao { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public ZhengJianLeiXing ZhengJianLeiXing { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime ChuShengRiQi { get; set; }
        /// <summary>
        /// 乘客类型
        /// </summary>
        public ChengKeLeiXing ChengKeLeiXing { get; set; }
    }
    #endregion

    #region 今日天下通API-创建儿童PNR信息返回业务实体
    /// <summary>
    /// 今日天下通API-创建儿童PNR信息返回业务实体
    /// </summary>
    public class MJinRi_Api_CreateErTongPnrResponseInfo
    {
        /// <summary>
        /// PNR编码
        /// </summary>
        public string Pnr { get; set; }
        /// <summary>
        /// PNR详细信息
        /// </summary>
        public string PnrInfo { get; set; }
        /// <summary>
        /// 返回值，1成功，其它失败
        /// </summary>
        public string RetCode { get; set; }
    }
    #endregion

    #region 订单相关信息业务实体
    /// <summary>
    /// 订单相关信息业务实体
    /// </summary>
    public class MDingDanXiangGuanInfo
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string DingDanId { get; set; }
        /// <summary>
        /// 信息类型
        /// </summary>
        public string LeiXing { get; set; }
        /// <summary>
        /// JSON
        /// </summary>
        public string JSON { get; set; }
    }
    #endregion

    #region 向API付款结果信息业务实体
    /// <summary>
    /// 向API付款结果信息业务实体
    /// </summary>
    public class MXiangApiFuKuanJieGuoInfo
    {
        /// <summary>
        /// 成人订单编号
        /// </summary>
        public string DingDanId1 { get; set; }
        /// <summary>
        /// 儿童订单编号
        /// </summary>
        public string DingDanId2 { get; set; }
        /// <summary>
        /// 成人订单向API付款结果 1成功 其它失败
        /// </summary>
        public string XiangApiFuKuanJieGuo1 { get; set; }
        /// <summary>
        /// 儿童订单向API付款结果 1成功 其它失败
        /// </summary>
        public string XiangApiFuKuanJieGuo2 { get; set; }
        /// <summary>
        /// 设置成人订单向API付款状态结果 1成功 其它失败
        /// </summary>
        public string SheZhiXiangApiFuKuanJieGuo1 { get; set; }
        /// <summary>
        /// 设置儿童订单向API付款状态结果 1成功 其它失败
        /// </summary>
        public string SheZhiXiangApiFuKuanJieGuo2 { get; set; }

        /// <summary>
        /// 结果  1成功 其它失败
        /// </summary>
        public string JieGuo { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string XiaoXi { get; set; }
    }
    #endregion
}
