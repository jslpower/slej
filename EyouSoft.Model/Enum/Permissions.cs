using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.Enum.Privs
{
    #region 一级栏目枚举
    /// <summary>
    /// 一级栏目枚举
    /// </summary>
    public enum Menu1
    {
        None = 0,
        /// <summary>
        /// 线路产品管理
        /// </summary>
        线路产品管理 = 1,
        /// <summary>
        /// 景区门票管理
        /// </summary>
        景区门票管理 = 2,
        /// <summary>
        /// 酒店管理
        /// </summary>
        酒店管理 = 3,
        /// <summary>
        /// 个人会员管理
        /// </summary>
        个人会员管理 = 4,
        /// <summary>
        /// 基础信息管理
        /// </summary>
        基础信息管理 = 5,
        /// <summary>
        /// 后台用户管理
        /// </summary>
        后台用户管理 = 6,
        /// <summary>
        /// 积分产品管理
        /// </summary>
        财务管理 = 7,
        /// <summary>
        /// 签证管理
        /// </summary>
        签证管理 = 8,
        /// <summary>
        /// 机票管理
        /// </summary>
        //机票管理
    }
    #endregion

    #region 二级栏目枚举
    /// <summary>
    /// 二级栏目枚举
    /// </summary>
    public enum Menu2
    {
        None = 0,

        #region 线路产品管理
        /// <summary>
        /// 线路产品管理_线路管理
        /// </summary>
        线路产品管理_线路管理 = 101,
        /// <summary>
        /// 线路产品管理_订单管理
        /// </summary>
        线路产品管理_订单管理 = 102,
        /// <summary>
        /// 线路产品管理_团购产品
        /// </summary>
        线路产品管理_团购产品 = 103,
        /// <summary>
        /// 线路产品管理_线路点评
        /// </summary>
        //线路产品管理_线路点评 = 104,
        /// <summary>
        /// 团购产品
        /// </summary>
        团购产品 = 104,
        /// <summary>
        /// 团购订单
        /// </summary>
        团购订单 = 105,
        /// <summary>
        /// 线路产品管理_组团费用
        /// </summary>
        线路产品管理_组团费用 = 106,


        #endregion

        #region 景区门票管理
        /// <summary>
        /// 景区门票管理_景区管理
        /// </summary>
        景区门票管理_景区管理 = 201,
        /// <summary>
        /// 景区门票管理_景区门票管理
        /// </summary>
        景区门票管理_景区门票管理 = 202,
        /// <summary>
        /// 景区门票管理_景区主题管理
        /// </summary>
        //景区门票管理_景区主题管理 = 203,
        /// <summary>
        /// 景区门票管理_景区订单管理
        /// </summary>
        景区门票管理_景区订单管理 = 204,
        /// <summary>
        /// 景区门票管理_景区点评
        /// </summary>
        //景区门票管理_景区点评 = 205,
        #endregion

        #region 酒店管理
        /// <summary>
        /// 酒店管理_酒店管理
        /// </summary>
        酒店管理_酒店管理 = 301,
        /// <summary>
        /// 酒店管理_酒店房型管理
        /// </summary>
        酒店管理_酒店房型管理 = 302,
        /// <summary>
        /// 酒店管理_酒店订单管理
        /// </summary>
        酒店管理_酒店订单管理 = 303,
        /// <summary>
        /// 酒店管理_酒店点评
        /// </summary>
        //酒店管理_酒店点评 = 304,
        #endregion

        #region 个人会员管理
        /// <summary>
        /// 个人会员管理_会员管理
        /// </summary>
        个人会员管理_会员管理 = 401,
        #endregion

        #region 系统设置
        系统设置_费用相关 = 37,
        #endregion
        #region 基础信息管理

        基础信息管理_系统设置 = 500,
        /// <summary>
        /// 基础信息管理_公司信息
        /// </summary>
        基础信息管理_公司信息 = 501,
        /// <summary>
        /// 基础信息管理_网站基本信息
        /// </summary>
        基础信息管理_网站基本信息 = 502,
        /// <summary>
        /// 基础信息管理_线路区域
        /// </summary>
        基础信息管理_线路区域 = 503,
        /// <summary>
        /// 基础信息管理_城市信息
        /// </summary>
        基础信息管理_城市信息 = 504,
        /// <summary>
        /// 基础信息管理_线路主题
        /// </summary>
        基础信息管理_线路主题 = 505,
        /// <summary>
        /// 基础信息管理_旅游资讯类别
        /// </summary>
        基础信息管理_旅游资讯类别 = 506,
        /// <summary>
        /// 基础信息管理_旅游资讯
        /// </summary>
        基础信息管理_旅游资讯 = 507,
        /// <summary>
        /// 基础信息管理_站点广告
        /// </summary>
        基础信息管理_站点广告 = 508,
        /// <summary>
        /// 基础信息管理_友情链接
        /// </summary>
        基础信息管理_友情链接 = 509,
        /// <summary>
        /// 基础信息管理_旅游攻略主题
        /// </summary>
        基础信息管理_旅游攻略主题 = 510,
        /// <summary>
        /// 基础信息管理_旅游攻略
        /// </summary>
        基础信息管理_旅游攻略 = 511,
        /// <summary>
        /// 基础信息管理_地标管理
        /// </summary>
        基础信息管理_地标管理 = 512,
        /// <summary>
        /// 基础信息管理_反馈信息管理
        /// </summary>
        基础信息管理_反馈信息管理 = 513,
        /// <summary>
        /// 基础信息管理_商城产品类别管理
        /// </summary>
        基础信息管理_商城产品类别管理 = 514,
        /// <summary>
        /// 基础信息管理_网站协议
        /// </summary>
        基础信息管理_网站协议 = 515,
        #endregion

        #region 后台用户管理
        /// <summary>
        /// 后台用户管理_个人信息
        /// </summary>
        后台用户管理_个人信息 = 601,
        /// <summary>
        /// 后台用户管理_后台用户管理
        /// </summary>
        后台用户管理_后台用户管理 = 602,
        /// <summary>
        /// 后台用户管理_后台用户管理
        /// </summary>
        后台用户管理_供应商管理 = 603,
        #endregion

        #region 财务管理
        /// <summary>
        /// 积分产品管理_产品管理
        /// </summary>
        财务管理_充值管理 = 701,
        /// <summary>
        /// 积分产品管理_积分管理
        /// </summary>
        财务管理_提现管理 = 702,
        /// <summary>
        /// 积分产品管理_兑换管理
        /// </summary>
        财务管理_返利管理 = 703,
        /// <summary>
        /// 财务管理_交易管理
        /// </summary>
        财务管理_交易管理 = 704,
        /// <summary>
        /// 财务管理_账户明细
        /// </summary>
        财务管理_账户明细 = 705,
        /// <summary>
        /// 财务管理_订单列表
        /// </summary>
        财务管理_交易统计 =706,
        /// <summary>
        /// 财务管理_积分兑换
        /// </summary>
        财务管理_积分兑换 = 707,
        #endregion

        #region 签证管理
        签证管理_签证管理 = 802,
        /// <summary>
        /// 签证管理_签证订单管理
        /// </summary>
        签证管理_签证订单管理 = 803,
        #endregion

        #region 租车
        租车产品管理 = 1101,
        租车订单管理 = 1102,
        #endregion

        #region 机票
        机票订单管理 = 1201
        #endregion
    }
    #endregion

    #region 明细权限枚举
    /// <summary>
    /// 明细权限枚举
    /// </summary>
    public enum Privs
    {
        /// <summary>
        /// 订单取消
        /// </summary>
        订单取消 = 10001,
        /// <summary>
        /// 权限分配
        /// </summary>
        权限分配 = 10002
    }
    #endregion
}
