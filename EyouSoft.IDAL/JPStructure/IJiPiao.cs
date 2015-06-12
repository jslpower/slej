//机票公共信息相关interface 汪奇志 2014-11-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.JPStructure
{
    /// <summary>
    /// 机票公共信息相关interface
    /// </summary>
    public interface IJiPiao
    {
        /// <summary>
        /// 写入通知信息业务实体，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Notify_C(EyouSoft.Model.JPStructure.MNotifyInfo info);

        /// <summary>
        /// 获取通知处理成功次数
        /// </summary>
        /// <param name="leiXing">通知类型</param>
        /// <param name="guanLianLeiXing">关联类型</param>
        /// <param name="guanLianId">关联编号</param>
        /// <returns></returns>
        int Notify_GetChuLiCiShu(string leiXing, string guanLianLeiXing, string guanLianId);
    }
}
