using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.Model.Enum
{
    #region 用户在线状态

    /// <summary>
    /// 用户在线状态
    /// </summary>
    public enum UserOnlineStatus
    {
        /// <summary>
        /// 离线
        /// </summary>
        Offline = 0,
        /// <summary>
        /// 在线
        /// </summary>
        Online
    }

    #endregion

    #region 用户状态

    /// <summary>
    /// 用户状态
    /// </summary>
    public enum UserStatus
    {
        /// <summary>
        /// 未启用=0
        /// </summary>
        未启用 = 0,
        /// <summary>
        /// 正常=1
        /// </summary>
        正常 = 1,
        /// <summary>
        /// 黑名单=2
        /// </summary>
        黑名单 = 2,
        /// <summary>
        /// 已停用=3
        /// </summary>
        已停用 = 3
    }

    #endregion

    #region 用户登录类型

    /// <summary>
    /// 用户登录类型
    /// </summary>
    public enum UserLoginType
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        用户登录 = 0,
        /// <summary>
        /// 客服登录
        /// </summary>
        客服登录,
        /// <summary>
        /// 自动登录
        /// </summary>
        自动登录
    }

    #endregion
}
