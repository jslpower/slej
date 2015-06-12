//机票相关枚举 汪奇志  2013-12-03
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.Enum.JiPiaoStructure
{
    #region 机票确认方式
    /// <summary>
    /// 机票确认方式
    /// </summary>
    public enum QueRenFangShi
    {
        /// <summary>
        /// 不用确认
        /// </summary>
        不用确认,
        /// <summary>
        /// 短信确认
        /// </summary>
        短信确认,
        /// <summary>
        /// 电话确认
        /// </summary>
        电话确认
    }
    #endregion

    #region 机票出票方式
    /// <summary>
    /// 机票出票方式
    /// </summary>
    public enum ChuPiaoFangShi
    {
        /// <summary>
        /// 直接出票
        /// </summary>
        直接出票,
        /// <summary>
        /// 先不出票
        /// </summary>
        先不出票
    }
    #endregion

    #region 机票出票状态
    /// <summary>
    /// 机票出票状态
    /// </summary>
    public enum ChuPiaoStatus
    {
        /// <summary>
        /// 未出票
        /// </summary>
        未出票,
        /// <summary>
        /// 已出票
        /// </summary>
        已出票
    }
    #endregion
}
