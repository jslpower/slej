using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.Enum.QianZhengStructure
{
    #region 洲枚举
    /// <summary>
    /// 洲枚举
    /// </summary>
    public enum Zhou
    {
        /// <summary>
        /// 欧洲
        /// </summary>
        欧洲 = 1,
        /// <summary>
        /// 亚洲
        /// </summary>
        亚洲 = 2,
        /// <summary>
        /// 美洲
        /// </summary>
        美洲 = 3,
        /// <summary>
        /// 非洲
        /// </summary>
        非洲 = 4,
        /// <summary>
        /// 大洋洲
        /// </summary>
        大洋洲 = 5
    }
    #endregion

    #region 订单来源
    /// <summary>
    /// 订单来源
    /// </summary>
    public enum DingDanLaiYuan
    {
        /// <summary>
        /// 网站
        /// </summary>
        网站 = 0,
        /// <summary>
        /// 同业通
        /// </summary>
        同业通 = 1
    }
    #endregion

    #region 签证类型
    /// <summary>
    /// 签证类型
    /// </summary>
    public enum QianZhengLeiXing
    {
        /// <summary>
        /// 旅游签证
        /// </summary>
        旅游签证=0,
        /// <summary>
        /// 商务签证
        /// </summary>
        商务签证=1,
        /// <summary>
        /// 探亲签证
        /// </summary>
        探亲签证=2,
        /// <summary>
        /// 公务签证
        /// </summary>
        公务签证=3,
        /// <summary>
        /// 其他签证
        /// </summary>
        其他签证=4
    }
    #endregion
}
