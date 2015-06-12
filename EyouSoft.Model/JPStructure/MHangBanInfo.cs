//机票航班信息相关业务实体 汪奇志 2014-11-12
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.JPStructure
{
    #region 航班信息业务实体
    /// <summary>
    /// 航班信息业务实体
    /// </summary>
    public class MHangBanInfo
    {
        /// <summary>
        /// 航班日期 xml>JIT-Flight-Response>Response.Sdate
        /// </summary>
        public DateTime HangBanRiQi { get; set; }
        /// <summary>
        /// 出发城市三字码 xml>JIT-Flight-Response>Response.Scity
        /// </summary>
        public string ChuFaChengShiSanZiMa { get; set; }
        /// <summary>
        /// 到达城市三字码 xml>JIT-Flight-Response>Response.Ecity
        /// </summary>
        public string DaoDaChengShiSanZiMa { get; set; }
        /// <summary>
        /// 航班号 xml>JIT-Flight-Response>Response.FlightNo
        /// </summary>
        public string HangBanHao { get; set; }
        /// <summary>
        /// 航空公司二字代码 xml>JIT-Flight-Response>Response.AirLine
        /// </summary>
        public string HangKongGongSiErZiMa { get; set; }
        /// <summary>
        /// 机型 xml>JIT-Flight-Response>Response.FlightType
        /// </summary>
        public string JiXing { get; set; }
        /// <summary>
        /// 起飞时间 xml>JIT-Flight-Response>Response.Stime
        /// </summary>
        public string QiFeiShiJian { get; set; }
        /// <summary>
        /// 到达时间 xml>JIT-Flight-Response>Response.ETime
        /// </summary>
        public string DaoDaShiJian { get; set; }
        /// <summary>
        /// 是否经停 0：否 1：是 xml>JIT-Flight-Response>Response.Stop
        /// </summary>
        public string ShiFouJingTing { get; set; }
        /// <summary>
        /// 电子客票 E xml>JIT-Flight-Response>Response.Epiao
        /// </summary>
        public string DianZiKePiao { get; set; }
        /// <summary>
        /// 税费金额（机场建设费+燃油费） xml>JIT-Flight-Response>Response.Tax
        /// </summary>
        public decimal ShuiFeiJinE { get; set; }
        /// <summary>
        /// 出发航站楼 xml>JIT-Flight-Response>Response.AirTerminal
        /// </summary>
        public string ChuFaHangZhanLou { get; set; }
        /// <summary>
        /// 到达航站楼 xml>JIT-Flight-Response>Response.AirTerminal
        /// </summary>
        public string DaoDaHangZhanLou { get; set; }
        /// <summary>
        /// 机场建设费 xml>JIT-Flight-Response>Response.AirTax
        /// </summary>
        public decimal JiJianJinE { get; set; }
        /// <summary>
        /// 燃油费 xml>JIT-Flight-Response>Response.Fees
        /// </summary>
        public decimal RanYouJinE { get; set; }
        /// <summary>
        /// 舱位信息集合
        /// </summary>
        public IList<MCangWeiInfo> CangWeis { get; set; }


    }
    #endregion

    #region 舱位信息业务实体
    /// <summary>
    /// 舱位信息业务实体
    /// </summary>
    public class MCangWeiInfo
    {
        /// <summary>
        /// 舱位 xml>JIT-Flight-Response>Response>Cabin.C
        /// </summary>
        public string CangWei { get; set; }
        /// <summary>
        /// 舱位数量 1-9 A(>9) xml>JIT-Flight-Response>Response>Cabin.N
        /// </summary>
        public string CangWeiShu { get; set; }
        /// <summary>
        /// 折扣率 xml>JIT-Flight-Response>Response>Cabin.D
        /// </summary>
        public int ZheKouLv { get; set; }
        /// <summary>
        /// 票面价格 xml>JIT-Flight-Response>Response>Cabin.P
        /// </summary>
        public decimal PiaoMianJiaGe { get; set; }
        /// <summary>
        /// 销售价格(无返点价格)结算价、成本价
        /// </summary>
        public decimal XiaoShouJiaGe
        {
            get
            {
                if (FanDian == 0)
                {
                    return PiaoMianJiaGe;
                }
                return PiaoMianJiaGe * (1 - FanDian / 100M);
            }
        }
        /// <summary>
        /// 返点 xml>JIT-Flight-Response>Response>Cabin.K
        /// </summary>
        public decimal FanDian { get; set; }
        /// <summary>
        /// 供应商ID xml>JIT-Flight-Response>Response>Cabin.ID
        /// </summary>
        public string GongYingShangId { get; set; }
        /// <summary>
        /// 是否是特殊舱位 0：否 1：是 xml>JIT-Flight-Response>Response>Cabin.T
        /// </summary>
        public string ShiFouTeShu { get; set; }
        /// <summary>
        /// 平台管理费 xml>JIT-Flight-Response>Response>Cabin.XF 
        /// </summary>
        public decimal PingTaiGuanLiFei { get; set; }
        /// <summary>
        /// 供票是否是上班时间 0：所有时间 1：上班时间 xml>JIT-Flight-Response>Response>Cabin.PI   
        /// </summary>
        public string GongPiaoShiJian { get; set; }
        /// <summary>
        /// 政策类型 xml>JIT-Flight-Response>Response>Cabin.RT   
        /// </summary>
        public ZhengCeLeiXing ZhengCeLeiXing { get; set; }
        /// <summary>
        /// 政策备注 xml>JIT-Flight-Response>Response>Cabin.RM   
        /// </summary>
        public string ZhengCeBeiZhu { get; set; }
        /// <summary>
        /// 政策ID xml>JIT-Flight-Response>Response>Cabin.RID   
        /// </summary>
        public string ZhengCeId { get; set; }
        /// <summary>
        /// 供应商office号 xml>JIT-Flight-Response>Response>Cabin.OfficeNum   
        /// </summary>
        public string GongYingShangOfficeId { get; set; }
        /// <summary>
        /// 改签规定 xml>JIT-Flight-Response>Response>Cabin.Change   
        /// </summary>
        public string GaiQianGuiDing { get; set; }
        /// <summary>
        /// 退票规定 xml>JIT-Flight-Response>Response>Cabin.Return   
        /// </summary>
        public string TuiPiaoGuiDing { get; set; }

        #region 扩展 舱位不同身份的优惠信息
        /// <summary>
        /// 舱位不同身份的优惠信息
        /// </summary>
        public string YouHuiXinXi { get; set; }
        /// <summary>
        /// 燃油费+机建费
        /// </summary>
        public decimal FuJiaFei { get; set; }
        /// <summary>
        /// 页面显示价格，根据身份计算后的价格
        /// </summary>
        public decimal XianShiJiaGe { get; set; }
        #endregion
    }
    #endregion

    #region 航班信息查询业务实体
    /// <summary>
    /// 航班信息查询业务实体
    /// </summary>
    public class MHangBanChaXunInfo
    {
        /// <summary>
        /// 航班日期
        /// </summary>
        public DateTime HangBanRiQi { get; set; }
        /// <summary>
        /// 出发城市三字码
        /// </summary>
        public string ChuFaChengShiSanZiMa { get; set; }
        /// <summary>
        /// 到达城市三字码
        /// </summary>
        public string DaoDaChengShiSanZiMa { get; set; }
        /// <summary>
        /// 舱位类型
        /// </summary>
        public string CangWei { get; set; }
        /// <summary>
        /// 是否获取特价 T:获取 F:不获取
        /// </summary>
        public string ShiFouTeJia { get; set; }
        /// <summary>
        /// 服务商ID
        /// </summary>
        public string FuWuShangId { get; set; }
    }
    #endregion

    #region 舱位特价信息业务实体
    /// <summary>
    /// 舱位特价信息业务实体
    /// </summary>
    public class MCangWeiTeJiaInfo
    {
        /// <summary>
        /// 价格
        /// </summary>
        public decimal JiaGe { get; set; }
        /// <summary>
        /// 获取特价返回值 success成功 其它失败
        /// </summary>
        public string RetCode { get; set; }
    }
    #endregion

    #region 舱位特价信息查询业务实体
    /// <summary>
    /// 舱位特价信息查询业务实体
    /// </summary>
    public class MCangWeiTeJiaChaXunInfo
    {
        /// <summary>
        /// 航班日期
        /// </summary>
        public DateTime HangBanRiQi { get; set; }
        /// <summary>
        /// 出发城市三字码
        /// </summary>
        public string ChuFaChengShiSanZiMa { get; set; }
        /// <summary>
        /// 到达城市三字码
        /// </summary>
        public string DaoDaChengShiSanZiMa { get; set; }
        /// <summary>
        /// 舱位代码
        /// </summary>
        public string CangWei { get; set; }
        /// <summary>
        /// 航班号
        /// </summary>
        public string HangBanHao { get; set; }
        /// <summary>
        /// 服务商ID
        /// </summary>
        public string FuWuShangId { get; set; }
    }
    #endregion

    #region 航班退改签说明信息业务实体
    /// <summary>
    /// 航班退改签说明信息业务实体
    /// </summary>
    public class MTuiGaiQianShuoMingInfo
    {
        /// <summary>
        /// 航空公司二字代码 xml>JinRiRuleResponse>Response>Rules>Airline
        /// </summary>
        public string HangKongGongSiErZiMa { get; set; }
        /// <summary>
        /// 舱位 xml>JinRiRuleResponse>Response>Rules>Cabin
        /// </summary>
        public string CangWei { get; set; }
        /// <summary>
        /// 改签时间-起始 xml>JinRiRuleResponse>Response>Rules>ChangeSdate
        /// </summary>
        public string GaiQianShiJian1 { get; set; }
        /// <summary>
        /// 改签时间-截止 xml>JinRiRuleResponse>Response>Rules>ChangeEdate
        /// </summary>
        public string GaiQianShiJian2 { get; set; }
        /// <summary>
        /// 退废时间-起始 xml>JinRiRuleResponse>Response>Rules>RefundSdate
        /// </summary>
        public string TuiFeiShiJian1 { get; set; }
        /// <summary>
        /// 退废时间-截止 xml>JinRiRuleResponse>Response>Rules>RefundEdate
        /// </summary>
        public string TuiFeiShiJian2 { get; set; }
        /// <summary>
        /// 改签说明 xml>JinRiRuleResponse>Response>Rules>Change
        /// </summary>
        public string GaiQianShuoMing { get; set; }
        /// <summary>
        /// 退废说明 xml>JinRiRuleResponse>Response>Rules>Refund
        /// </summary>
        public string TuiFeiShuoMing { get; set; }
        /// <summary>
        /// 其它说明 xml>JinRiRuleResponse>Response>Rules>Remark
        /// </summary>
        public string QiTaShuoMing { get; set; }
    }
    #endregion

    #region 航班退改签说明信息查询业务实体
    /// <summary>
    /// 航班退改签说明信息查询业务实体
    /// </summary>
    public class MTuiGaiQianShuoMingChaXunInfo
    {
        /// <summary>
        /// 舱位
        /// </summary>
        public string CangWei { get; set; }
        /// <summary>
        /// 航空公司二字代码
        /// </summary>
        public string HangKongGongSiErZiMa { get; set; }
        /// <summary>
        /// 航班日期
        /// </summary>
        public DateTime HangBanRiQi { get; set; }
        /// <summary>
        /// 服务商ID
        /// </summary>
        public string FuWuShangId { get; set; }
    }
    #endregion
}
