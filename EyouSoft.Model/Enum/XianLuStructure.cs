//线路产品相关枚举值 汪奇志 2013-03-13
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.Enum.XianLuStructure
{
    #region 线路状态
    /// <summary>
    /// 线路状态
    /// </summary>
    public enum XianLuZhuangTai
    {
        /// <summary>
        /// none
        /// </summary>
        None = 0,
        /// <summary>
        /// 最新
        /// </summary>
        最新,
        /// <summary>
        /// 推荐
        /// </summary>
        推荐,
        /// <summary>
        /// 热点
        /// </summary>
        热点,
        /// <summary>
        /// 精华
        /// </summary>
        精华,
        /// <summary>
        /// 特价
        /// </summary>
        特价,
        /// <summary>
        /// 豪华
        /// </summary>
        豪华,
        /// <summary>
        /// 纯玩
        /// </summary>
        纯玩,
        /// <summary>
        /// 经典
        /// </summary>
        经典
    }
    #endregion

    #region 收客状态
    /// <summary>
    /// 收客状态
    /// </summary>
    public enum ShouKeZhuangTai
    {
        /// <summary>
        /// 正常
        /// </summary>
        正常 = 0,
        /// <summary>
        /// 停收
        /// </summary>
        停收
    }
    #endregion

    #region 订单状态
    /// <summary>
    /// 订单状态
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// 未处理
        /// </summary>
        未处理 = 0,
        /// <summary>
        /// 待付款
        /// </summary>
        待付款 = 1,
        /// <summary>
        /// 订单出货
        /// </summary>
        订单出货 = 2,
        /// <summary>
        /// 确认收货
        /// </summary>
        确认收货 = 3,
        /// <summary>
        /// 待返利
        /// </summary>
        待返利 = 4,
        /// <summary>
        /// 交易完成
        /// </summary>
        交易完成 = 5,
        /// <summary>
        /// 取消订单
        /// </summary>
        取消订单 = 6
    }
    #endregion

    #region 付款状态
    /// <summary>
    /// 付款状态
    /// </summary>
    public enum FuKuanStatus
    {
        /// <summary>
        /// 未付款
        /// </summary>
        未付款 = 0,
        /// <summary>
        /// 已付款
        /// </summary>
        已付款 = 1
    }
    #endregion

    #region 订单历史记录类型
    /// <summary>
    /// 订单历史记录类型
    /// </summary>
    public enum OrderHistoryLeiXing
    {
        /// <summary>
        /// 新增
        /// </summary>
        新增 = 0,
        /// <summary>
        /// 修改
        /// </summary>
        修改,
        /// <summary>
        /// 设置状态
        /// </summary>
        设置状态,
        /// <summary>
        /// 设置付款状态
        /// </summary>
        设置付款状态
    }
    #endregion

    #region 线路点评类型
    /// <summary>
    /// 线路点评类型
    /// </summary>
    public enum DianPingStatus
    {
        /// <summary>
        /// 满意
        /// </summary>
        满意 = 1,
        /// <summary>
        /// 一般
        /// </summary>
        一般 = 2,
        /// <summary>
        /// 差评
        /// </summary>
        差评 = 3

    }
    #endregion

    #region 线路点评方式
    /// <summary>
    /// 线路点评方式
    /// </summary>
    public enum DianPingType
    {
        /// <summary>
        /// 短信点评
        /// </summary>
        短信点评 = 1,
        /// <summary>
        /// 电话回访
        /// </summary>
        电话回访 = 2,
        /// <summary>
        /// 网页点评
        /// </summary>
        网页点评 = 3,

    }
    #endregion

    #region 线路查询天数枚举

    /// <summary>
    /// 线路查询天数枚举
    /// </summary>
    public enum RouteSearchDay
    {
        /// <summary>
        /// 一日游
        /// </summary>
        一日游 = 1,
        /// <summary>
        /// 二日游
        /// </summary>
        二日游 = 2,
        /// <summary>
        /// 三日游
        /// </summary>
        三日游 = 3,
        /// <summary>
        /// 四日游
        /// </summary>
        四日游 = 4,
        /// <summary>
        /// 五日游
        /// </summary>
        五日游 = 5,
        /// <summary>
        /// 六日游
        /// </summary>
        六日游 = 6,
        /// <summary>
        /// 七日游
        /// </summary>
        七日游 = 7,
        /// <summary>
        /// 八日游
        /// </summary>
        八日以上游 = 8

    }

    #endregion

    #region 线路状态 20141114
    public enum XianLuZT
    {
        /// <summary>
        /// 默认状态
        /// </summary>
        默认状态 = 0,
        /// <summary>
        /// 线路下架
        /// </summary>
        下架,
        /// <summary>
        /// 首页推荐
        /// </summary>
        首页推荐
    }
    #endregion
}
