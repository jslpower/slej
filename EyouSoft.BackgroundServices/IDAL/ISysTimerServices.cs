using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.BackgroundServices.Model;

namespace EyouSoft.BackgroundServices.IDAL
{
    /// <summary>
    /// 系统定时服务接口
    /// </summary>
    public interface ISysTimerServices
    {
        /// <summary>
        /// 获取需要自动处理订单状态的订单信息集合
        /// </summary>
        /// <returns></returns>
        IList<MDingDanInfo> GetDingDans();
    }
}
