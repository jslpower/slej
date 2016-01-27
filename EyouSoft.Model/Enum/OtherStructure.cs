using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.Enum
{
    #region 证件类型
    /// <summary>
    /// 证件类型1:身份证;2:护照;3:军官证;4:台胞证;5:港澳通行证)
    /// </summary>
    public enum CardType
    {
        /// <summary>
        /// none
        /// </summary>
        请选择 = 0,
        /// <summary>
        /// 身份证
        /// </summary>
        身份证,
        /// <summary>
        /// 护照
        /// </summary>
        护照,
        /// <summary>
        /// 军官证
        /// </summary>
        军官证,
        /// <summary>
        /// 台胞证
        /// </summary>
        台胞证,
        /// <summary>
        /// 港澳通行证
        /// </summary>
        港澳通行证
    }
    #endregion



    #region 性别
    /// <summary>
    #region 资讯类型
    /// <summary>
    /// 资讯类型
    /// </summary>
    public enum GongGaoJiBie
    {
        /// <summary>
        /// 普通会员
        /// </summary>
        普通会员 = 0,
        /// <summary>
        /// 贵宾会员
        /// </summary>
        贵宾会员,
        /// <summary>
        /// 免费代理
        /// </summary>
        免费代理,

        /// <summary>
        /// 代理
        /// </summary>
        代理,
        /// <summary>
        /// 员工
        /// </summary>
        员工,
    }
    #endregion/// 性别
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// 男
        /// </summary>
        男 = 0,
        /// <summary>
        /// 女
        /// </summary>
        女 = 1,
    }
    #endregion

    #region 游客类型
    /// <summary>
    /// 游客类型
    /// </summary>
    public enum YouKeType
    {
        /// <summary>
        /// 成人 = 0
        /// </summary>
        成人 = 0,
        /// <summary>
        /// 儿童
        /// </summary>
        儿童
    }
    #endregion

    #region 线路区域类别
    /// <summary>
    /// 线路区域类别
    /// </summary>
    public enum AreaType
    {
        /// <summary>
        /// 国内长线
        /// </summary>
        国内长线 = 1,
        /// <summary>
        /// 出境线路
        /// </summary>
        出境线路,
        /// <summary>
        /// 周边短线
        /// </summary>
        周边短线
    }
    #endregion

    #region 广告位置
    /// <summary>
    /// 广告位置
    /// </summary>
    public enum AdvArea
    {
        /// <summary>
        /// none = 0
        /// </summary>
        请选择 = 0,
        /// <summary>
        ///1 首页轮换广告
        /// </summary>
        首页轮换广告,
        /// <summary>
        ///2 首页左侧广告1
        /// </summary>
        首页左侧广告,
        /// <summary>
        ///3 首页左侧广告2
        /// </summary>
        首页左侧广告2,
        /// <summary>
        ///4 首页左侧广告3
        /// </summary>
        首页左侧广告3,
        /// <summary>
        ///5 首页底部广告
        /// </summary>
        首页底部广告,
        /// <summary>
        ///6 周边短线首页轮换广告
        /// </summary>
        周边短线首页轮换广告,
        /// <summary>
        ///7 国内长线首页轮换广告
        /// </summary>
        国内长线首页轮换广告,
        /// <summary>
        ///8 国际线路首页轮换广告
        /// </summary>
        国际线路首页轮换广告,
        /// <summary>
        ///9 优惠门票首页轮换广告
        /// </summary>
        优惠门票首页轮换广告,
        /// <summary>
        ///10 酒店首页轮换广告
        /// </summary>
        酒店首页轮换广告,
        /// <summary>
        ///11 会员商城首页轮换广告
        /// </summary>
        会员商城首页轮换广告,
        /// <summary>
        ///12 签证首页轮换广告
        /// </summary>
        签证首页轮换广告,
        /// <summary>
        ///13 购物广场联盟
        /// </summary>
        购物广场联盟,
        /// <summary>
        ///14 休闲娱乐会所
        /// </summary>
        休闲娱乐会所,
        /// <summary>
        ///15 天下商旅E家
        /// </summary>
        天下商旅E家,
        /// <summary>
        /// 16 机票栏目广告
        /// </summary>
        机票栏目广告

    }
    #endregion

    #region 操作人类型
    /// <summary>
    /// 操作人类型
    /// </summary>
    public enum OperatorLeiXing
    {
        /// <summary>
        /// 会员
        /// </summary>
        会员 = 0,
        /// <summary>
        /// 管理
        /// </summary>
        管理
    }
    #endregion

    #region 旅游资讯排序字段
    /// <summary>
    /// 旅游排序字段
    /// </summary>
    public enum TravelArticleFiledOrder
    {
        /// <summary>
        /// 发布时间
        /// </summary>
        IssueTime = 0,
        /// <summary>
        /// 排序规则
        /// </summary>
        SortRule,
        /// <summary>
        /// 首页显示
        /// </summary>
        IsFrontPage,
        /// <summary>
        /// 头条
        /// </summary>
        IsHot,

        /// <summary>
        /// 浏览量
        /// </summary>
        Click

    }
    #endregion

    #region 排序
    /// <summary>
    /// 排序
    /// </summary>
    public enum OrderBy
    {
        /// <summary>
        /// 升序
        /// </summary>
        ASC = 0,
        /// <summary>
        /// 降序
        /// </summary>
        DESC
    }
    #endregion

    #region 资讯类型
    /// <summary>
    /// 资讯类型
    /// </summary>
    public enum ArticleType
    {
        /// <summary>
        /// 公告
        /// </summary>
        公告 = 0,
        /// <summary>
        /// 旅游资讯
        /// </summary>
        旅游资讯,
        /// <summary>
        /// 会员公告
        /// </summary>
        会员公告
    }
    #endregion

    #region 积分产品类别
    /// <summary>
    /// 积分产品类别
    /// </summary>
    public enum ProductClass
    {
        /// <summary>
        /// 电子数码
        /// </summary>
        电子数码 = 1
    }
    #endregion

    #region 订单类型
    /// <summary>
    /// 订单类型
    /// </summary>
    public enum OrderClass
    {
        /// <summary>
        /// 线路
        /// </summary>
        线路 = 1,
        /// <summary>
        /// 酒店
        /// </summary>
        酒店 = 2,
        /// <summary>
        /// 门票
        /// </summary>
        门票 = 3,
        /// <summary>
        /// 签证
        /// </summary>
        签证 = 4,
        /// <summary>
        /// 机票
        /// </summary>
        机票 = 5
    }
    #endregion

    #region 积分产品兑换状态
    /// <summary>
    /// 积分产品兑换状态
    /// </summary>
    public enum ExchangeStatus
    {
        /// <summary>
        /// 未兑换
        /// </summary>
        未兑换 = 1,
        /// <summary>
        /// 已兑换
        /// </summary>
        已兑换 = 2
    }
    #endregion

    /*
    #region 短信接收人类型
    /// <summary>
    /// 短信接收人类型
    /// </summary>
    public enum SmsJieShouRenLeiXing
    {
        /// <summary>
        /// 系统
        /// </summary>
        系统 = 0,
        /// <summary>
        /// 游客
        /// </summary>
        游客,
        /// <summary>
        /// 供应商
        /// </summary>
        供应商
    }
    #endregion

    #region 短信发送类型
    /// <summary>
    /// 短信发送类型
    /// </summary>
    public enum SmsFaSongLeiXing
    {
        /// <summary>
        /// 下单
        /// </summary>
        下单 = 0,
        /// <summary>
        /// 自动确认
        /// </summary>
        自动确认
    }
    #endregion
    */

    #region 短信发送类型
    /// <summary>
    /// 短信发送类型
    /// </summary>
    public enum DuanXinFaSongLeiXing
    {
        /// <summary>
        /// none
        /// </summary>
        None = 0,
        /// <summary>
        /// 下单
        /// </summary>
        下单 = 1,
        /// <summary>
        /// 确认
        /// </summary>
        确认 = 2,
        /// <summary>
        /// 支付
        /// </summary>
        支付 = 3,
        /// <summary>
        /// 充值
        /// </summary>
        充值 = 4
    }
    #endregion

    #region 设置订单状态类型
    /// <summary>
    /// 设置订单状态类型
    /// </summary>
    public enum SetDingDanStatusLeiXing
    {
        /// <summary>
        /// 系统自动处理
        /// </summary>
        系统 = 0,
        /// <summary>
        /// 管理员处理
        /// </summary>
        管理员
    }
    #endregion

    #region 验证码类型
    /// <summary>
    /// 验证码类型
    /// </summary>
    public enum YanZhengMaLeiXing
    {
        /// <summary>
        /// 用户注册
        /// </summary>
        用户注册 = 0,
        /// <summary>
        /// 余额支付
        /// </summary>
        余额支付 = 1,
        /// <summary>
        /// 用户登录
        /// </summary>
        用户登录 = 2
    }
    #endregion

    #region 验证码状态
    /// <summary>
    /// 验证码状态
    /// </summary>
    public enum YanZhengMaStatus
    {
        /// <summary>
        /// 有效
        /// </summary>
        有效 = 0,
        /// <summary>
        /// 已过期
        /// </summary>
        已过期 = 1,
        /// <summary>
        /// 已使用
        /// </summary>
        已使用 = 2
    }
    #endregion

    #region
    /// <summary>
    /// 商城模块分类
    /// </summary>
    public enum ModelTypes
    {
        /// <summary>
        /// 购物广场联盟
        /// </summary>
        购物广场联盟 = 1,
        /// <summary>
        /// 休闲娱乐会所
        /// </summary>
        休闲娱乐会所 = 2,
        /// <summary>
        /// 天下商旅E家
        /// </summary>
        天下商旅E家 = 3
    }
    #endregion

    #region 下级分销提成状态
    /// <summary>
    /// 下级分销提成状态
    /// </summary>
    public enum XiaJiFenXiaoTiChengStatus
    {
        /// <summary>
        /// 未处理
        /// </summary>
        未处理 = 0,
        /// <summary>
        /// 已取消
        /// </summary>
        已取消 = 1,
        /// <summary>
        /// 已成交
        /// </summary>
        已成交 = 2
    }
    #endregion

    #region 返联盟推广返利状态
    /// <summary>
    /// 返联盟推广返利状态
    /// </summary>
    public enum FanLianMengTuiGuangFanLiStatus
    {
        未返 = 0,
        已返 = 1
    }
    #endregion

    #region 交易类别
    /// <summary>
    /// 交易类别
    /// </summary>
    public enum JiaoYiLeiBie
    {
        /// <summary>
        /// 充值 用户E额宝余额增加，系统余额增加
        /// </summary>
        充值 = 0,
        /// <summary>
        /// 提现（用户E额宝余额减少，系统余额减少）
        /// </summary>
        提现 = 1,
        /// <summary>
        /// 消费（使用E额宝支付时用户E额宝余额减少，使用快钱支付时E额宝余额不变，系统余额增加）
        /// </summary>
        消费 = 2,
        /// <summary>
        /// 返利（用户E额宝余额增加，系统余额减少）
        /// </summary>
        返利 = 3,
        /// <summary>
        /// 下级分销结算（用户E额宝余额增加，系统余额减少）
        /// </summary>
        分销奖金 = 4,
        /// <summary>
        /// 返联盟推广返利（用户E额宝余额增加，系统余额减少）
        /// </summary>
        返联盟推广返利 = 5,
        /// <summary>
        /// E额宝增值（用户E额宝余额增加，系统余额减少）
        /// </summary>
        E额宝增值 = 6,
        /// <summary>
        /// 产品销售款(交易成功后给予供应商销售款)
        /// </summary>
        产品销售款 = 7,
        /// <summary>
        /// 平台交易费(交易成功后平台收取供应商的平台费)
        /// </summary>
        平台交易费 = 8,
        /// <summary>
        /// 分销利润(交易成功后给予分销商的分销费)
        /// </summary>
        分销利润 = 9,
    }
    #endregion

    #region 交易状态
    /// <summary>
    /// 交易状态
    /// </summary>
    public enum JiaoYiStatus
    {
        /// <summary>
        /// 交易失败
        /// </summary>
        交易失败 = 0,
        /// <summary>
        /// 交易成功
        /// </summary>
        交易成功 = 1,
        /// <summary>
        /// 交易冻结
        /// </summary>
        交易冻结 = 2
    }
    #endregion
    #region 交易状态
    /// <summary>
    /// 交易状态
    /// </summary>
    public enum FenXiaoJiaoYiStatus
    {
        /// <summary>
        /// 交易失败
        /// </summary>
        交易失败 = 0,
        /// <summary>
        /// 交易成功
        /// </summary>
        已成功 = 1,
        /// <summary>
        /// 交易冻结
        /// </summary>
        交易冻结 = 2
    }
    #endregion

    #region 支付方式
    /// <summary>
    /// 支付方式
    /// </summary>
    public enum ZhiFuFangShi
    {
        /// <summary>
        /// 快钱
        /// </summary>
        快钱 = 0,
        /// <summary>
        /// E额宝
        /// </summary>
        E额宝 = 1,
        /// <summary>
        /// 线下支付
        /// </summary>
        线下支付 = 2,
        /// <summary>
        /// 支付宝
        /// </summary>
        支付宝 = 3,
        /// <summary>
        /// 微信
        /// </summary>
        微信 = 4
    }
    #endregion

    #region 订单类别
    /// <summary>
    /// 订单类别
    /// </summary>
    public enum DingDanLeiBie
    {
        线路订单 = 0,
        商城订单 = 1,
        门票订单 = 2,
        酒店订单 = 3,
        签证订单 = 4,
        机票订单 = 5,
        团购订单 = 6,
        租车订单 = 7,
        充值订单 = 8,
        下级分销结算 = 9,
        返联盟推广返利 = 10,
        订单返利 = 11,
        E额宝增值 = 12,
        E额宝提现 = 13,
        自组团订单 = 14
    }
    #endregion

    #region 订单状态描述
    /// <summary>
    /// 订单状态描述
    /// </summary>
    public enum DingDanStatusMiaoShu
    {
        提交成功oo请等待审核 = 0,
        审核成功oo请马上付款 = 1,
        支付成功oo请等待配发 = 2,
        配发成功oo请注意查收 = 3,
        请待出团后分成oo合作愉快 = 4,
        交易完成oo合作愉快 = 5,
        已提分成oo合作愉快 = 6,
        取消成功oo订单已经失效 = 7
    }
    #endregion
    #region 积分兑换状态
    /// <summary>
    /// 积分兑换状态
    /// </summary>
    public enum JiFenDuiHuanStatus
    {
        未审核 = 0,
        审核未通过 = 1,
        审核通过 = 2
    }
    #endregion
}
