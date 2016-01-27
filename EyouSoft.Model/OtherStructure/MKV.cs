using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model
{
    /// <summary>
    /// 公司信息
    /// </summary>
    public class MKV
    {
        public MKV() { }

        /// <summary>
        /// KEY
        /// </summary>
        public string K { get; set; }
        /// <summary>
        /// VALUE
        /// </summary>
        public string V { get; set; }

    }

    /// <summary>
    /// 公司信息设置
    /// </summary>
    public class MCompanySetting
    {
        /// <summary>
        /// 公司介绍
        /// </summary>
        public string CompanyIntroduce { get; set; }
        /// <summary>
        /// 关于我们
        /// </summary>
        public string About { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string Contact { get; set; }
        /// <summary>
        /// 诚聘英才
        /// </summary>
        public string Join { get; set; }
        /// <summary>
        /// 法律声明
        /// </summary>
        public string LegalNotices { get; set; }
        /// <summary>
        /// 版权信息
        /// </summary>
        public string Copyright { get; set; }
        /// <summary>
        /// 统计代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 网站基本信息 Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 网站基本信息 Keywords
        /// </summary>
        public string Keywords { get; set; }
        /// <summary>
        ///网站基本信息 Title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        ///网站基本信息 Logo
        /// </summary>
        public string Logo { get; set; }
        /// <summary>
        /// 线路订单积分兑换配置
        /// </summary>
        public string RouteTatol { get; set; }
        /// <summary>
        /// 景点订单积分兑换配置
        /// </summary>
        public string ScenicTatol { get; set; }
        /// <summary>
        /// 酒店订单积分兑换配置
        /// </summary>
        public string HotelTatol { get; set; }
        /// <summary>
        /// 签证订单积分兑换配置
        /// </summary>
        public string QianZhengDingDanJiFenPeiZhi { get; set; }
        /// <summary>
        /// 机票订单积分兑换配置
        /// </summary>
        public string JiPiaoDingDanJiFenPeiZhi { get; set; }
        /// <summary>
        /// 自动处理订单状态-线路-指定时间（分钟）
        /// </summary>
        public int ApdXianLuTime { get; set; }
        /// <summary>
        /// 自动处理订单状态-酒店-指定时间（分钟）
        /// </summary>
        public int ApdJiuDianTime { get; set; }
        /// <summary>
        /// 自动处理订单状态-景点-指定时间（分钟）
        /// </summary>
        public int ApdJingDianTime { get; set; }
        /// <summary>
        /// 自动处理订单状态-线路-接收号码
        /// </summary>
        public string AdpXianLuHaoMa { get; set; }
        /// <summary>
        /// 自动处理订单状态-酒店-接收号码
        /// </summary>
        public string AdpJiuDianHaoMa { get; set; }
        /// <summary>
        /// 自动处理订单状态-门票-接收号码
        /// </summary>
        public string AdpJingDianHaoMa { get; set; }
        /// <summary>
        /// 火车查询
        /// </summary>
        public string TrainSearch { get; set; }
        /// <summary>
        /// 公交查询
        /// </summary>
        public string TransitSearch { get; set; }
        /// <summary>
        /// 航班查询
        /// </summary>
        public string FlightSearch { get; set; }
        /// <summary>
        /// 天气查询
        /// </summary>
        public string WeatherSearch { get; set; }
        /// <summary>
        /// 手机查询
        /// </summary>
        public string MobileSearch { get; set; }
        /// <summary>
        /// 火车旅游常识
        /// </summary>
        public string TrainTravelTips { get; set; }
        /// <summary>
        /// 旅游地图
        /// </summary>
        public string TouristMap { get; set; }
        /// <summary>
        /// 在线翻译
        /// </summary>
        public string OnlineTranslation { get; set; }
        /// <summary>
        /// 邮编区号
        /// </summary>
        public string ZipCode { get; set; }
        /// <summary>
        /// 我要做分销商
        /// </summary>
        public string MakeFenXiao { get; set; }
        /// <summary>
        /// 我要做贵宾会员
        /// </summary>
        public string MakeGuiBin { get; set; }
        /// <summary>
        /// 我要做普通会员
        /// </summary>
        public string MakePuTong { get; set; }
        /// <summary>
        /// 我要应聘专职
        /// </summary>
        public string MakeYingPing { get; set; }
        /// <summary>
        /// 我要做供应商
        /// </summary>
        public string MakeGongYing { get; set; }
        /// <summary>
        /// 首页顶部搜索框的链接
        /// </summary>
        public string MenPiaoLinks { get; set; }

        public string XieYi { get; set; }
        /// <summary>
        /// E额宝说明
        /// </summary>
        public string EBao { get; set; }
        /// <summary>
        /// 手机版E额宝说明
        /// </summary>
        public string MoblieEBao { get; set; }
        /// <summary>
        /// 签证协议
        /// </summary>
        public string VisaXieYi { get; set; }
        /// <summary>
        /// 门票协议
        /// </summary>
        public string TicketXieYi { get; set; }
        /// <summary>
        /// 酒店协议
        /// </summary>
        public string HotelXieYi { get; set; }
        /// <summary>
        /// 租车协议
        /// </summary>
        public string ZuCheXieyi { get; set; }
        /// <summary>
        /// 商城协议
        /// </summary>
        public string ShopXieYi { get; set; }
        /// <summary>
        /// 出境协议
        /// </summary>
        public string ChuJingXieYi { get; set; }
        /// <summary>
        /// 短线协议
        /// </summary>
        public string DuanXianXieYi { get; set; }
        /// <summary>
        /// 团购协议
        /// </summary>
        public string TuanGouXieYi { get; set; }
        /// <summary>
        /// 报价协议
        /// </summary>
        public string BaoJiaXieYi { get; set; }
        /// <summary>
        /// 关于商旅e家
        /// </summary>
        public string SLEJText { get; set; }
        /// <summary>
        /// 手机版关于商旅e家
        /// </summary>
        public string MoblieSLEJText { get; set; }
        /// <summary>
        /// 代理条款
        /// </summary>
        public string DaiLiTiaoKuan { get; set; }
        /// <summary>
        /// 手机网站设置
        /// </summary>
        public string WapSet { get; set; }
        /// <summary>
        /// 平台交易费率
        /// </summary>
        public decimal JiaoYiLv { get; set; }


        #region 201411114更新
        /// <summary>
        /// E额宝是什么
        /// </summary>
        public string EBaoSSM { get; set; }
        /// <summary>
        /// E额宝余额管理
        /// </summary>
        public string EBaoYEGL { get; set; }
        /// <summary>
        /// E额宝充值明细
        /// </summary>
        public string EBaoCZMX { get; set; }
        /// <summary>
        /// E额宝购买明细
        /// </summary>
        public string EBaoGMMX { get; set; }
        /// <summary>
        /// E额宝返利明细
        /// </summary>
        public string EBaoFLMX { get; set; }
        /// <summary>
        /// E额宝提现明细
        /// </summary>
        public string EBaoTXMX { get; set; }
        /// <summary>
        /// 我的下级分销奖
        /// </summary>
        public string EBaoFXJ { get; set; }
        /// <summary>
        /// E额宝综合明细
        /// </summary>
        public string EBaoZHMX { get; set; }
        /// <summary>
        /// E额宝总明细
        /// </summary>
        public string EBaoZMX { get; set; }
        /// <summary>
        /// E额宝积分增值
        /// </summary>
        public string EBaoJFZZ { get; set; }


        #endregion

        #region 20150713手机版加入我们
        /// <summary>
        /// Wap我要做分销商
        /// </summary>
        public string WapMakeFenXiao { get; set; }
        /// <summary>
        /// Wap我要做贵宾会员
        /// </summary>
        public string WapMakeGuiBin { get; set; }
        /// <summary>
        /// Wap我要做普通会员
        /// </summary>
        public string WapMakePuTong { get; set; }
        /// <summary>
        /// Wap我要应聘专职
        /// </summary>
        public string WapMakeYingPing { get; set; }
        /// <summary>
        /// Wap我要做供应商
        /// </summary>
        public string WapMakeGongYing { get; set; }
        #endregion

    }

    #region 下级分销奖励配置信息业务实体
    /// <summary>
    /// 下级分销奖励配置信息业务实体
    /// </summary>
    public class MXiaJiFenXiaoJiangLiPeiZhiInfo
    {
        /// <summary>
        /// 结算比例
        /// </summary>
        public decimal JieSuanBiLi { get; set; }
        /// <summary>
        /// 最小结算佣金金额
        /// </summary>
        public decimal ZuiXiaoJieSuanYongJinJinE { get; set; }
        /// <summary>
        /// 结算比例百分比
        /// </summary>
        public string JieSuanBiLiBaiFenBi { get { return (JieSuanBiLi * 100).ToString("F2") + "%"; } }
    }
    #endregion

}
