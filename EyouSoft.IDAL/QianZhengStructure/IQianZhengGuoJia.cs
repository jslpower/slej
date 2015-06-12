//签证国家信息接口 汪奇志 2013-11-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.QianZhengStructure
{
    /// <summary>
    /// 签证国家信息接口
    /// </summary>
    public interface IQianZhengGuoJia
    {
        /// <summary>
        /// 获取签证国家信息集合
        /// </summary>
        /// <param name="chaXun">查询信息</param>
        /// <returns></returns>
        IList<EyouSoft.Model.QianZhengStructure.MQianZhengGuoJiaInfo> GetGuoJias(EyouSoft.Model.QianZhengStructure.MQianZhengGuoJiaChaXunInfo chaXun);
        /// <summary>
        /// 获取签证国家信息实体
        /// </summary>
        /// <param name="guoJiaId">国家编号</param>
        /// <returns></returns>
        EyouSoft.Model.QianZhengStructure.MQianZhengGuoJiaInfo GetInfo(int guoJiaId);
    }
}
