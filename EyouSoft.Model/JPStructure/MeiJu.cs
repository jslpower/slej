//机票相关枚举信息 汪奇志 2014-11-12
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.JPStructure
{
    #region 乘客类型
    /// <summary>
    /// 乘客类型
    /// </summary>
    public enum ChengKeLeiXing
    {
        成人 = 0,
        儿童 = 1
    }
    #endregion

    #region 证件类型
    /// <summary>
    /// 证件类型
    /// </summary>
    public enum ZhengJianLeiXing
    {
        None=0,
        身份证=1
    }
    #endregion

    #region 航线类型
    /// <summary>
    /// 航线类型
    /// </summary>
    public enum HangXianLeiXing
    {
        单程=0,
        往返=1,
        单程和往返=2
    }
    #endregion

    #region 政策类型
    /// <summary>
    /// 政策类型
    /// </summary>
    public enum ZhengCeLeiXing
    {
        普通政策 = 0,
        特殊外放政策 = 1,
        特殊高返政策 = 2
    }
    #endregion

    #region 订单状态-系统
    /// <summary>
    /// 订单状态-系统
    /// </summary>
    public enum DingDanStatus
    {
        等待确认 = -1,
        等待支付 = 0,
        /// <summary>
        /// 支付成功-系统支付到接口
        /// </summary>
        支付成功 = 1,
        出票成功 = 2,
        取消订单 = 6,
        暂不能出票 = 7,
        系统未确认 = 101,
        系统已确认 = 102,
        /// <summary>
        /// 支付成功-用户支付到平台
        /// </summary>
        支付成功_平台 = 103
    }
    #endregion

    #region 订单状态-API
    /// <summary>
    /// 订单状态-API
    /// </summary>
    public enum ApiDingDanStatus
    {
        等待确认=-1,
        等待支付=0,
        支付成功=1,
        出票成功=2,
        申请废票=3,
        申请退票=4,
        退款中=5,
        取消订单=6,
        暂不能出票=7,
        暂不能废=8,
        暂不能退=9,
        航班延误=10,
        退款成功=14
    }
    #endregion

    #region API接收方式
    /// <summary>
    /// API接收方式
    /// </summary>
    public enum ApiJieShouFangShi
    {
        前台=0,
        后台=1
    }
    #endregion

    #region 是否允许更换PNR出票
    /// <summary>
    /// 是否允许更换PNR出票
    /// </summary>
    public enum ShiFouYunXuGengHuanPnr
    {
        允许=0,
        不允许=1
    }
    #endregion

    #region 是否自动代扣
    /// <summary>
    /// 是否自动代扣
    /// </summary>
    public enum ShiFouZiDongDaiKou
    {
        否 = 0,
        是=1
    }
    #endregion

    #region 是否打印行程单
    /// <summary>
    /// 是否打印行程单
    /// </summary>
    public enum ShiFuDaYinXingChengDan
    {
        否=0,
        是=1
    }
    #endregion

    #region 向API付款状态
    /// <summary>
    /// 向API付款状态
    /// </summary>
    public enum XiangApiFuKuanStatus
    {
        未支付 = 0,
        已支付 = 1
    }
    #endregion
}
