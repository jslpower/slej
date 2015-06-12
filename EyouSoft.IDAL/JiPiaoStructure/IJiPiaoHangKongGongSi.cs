/*//机票-航空公司信息接口 汪奇志 2013-11-06
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.JiPiaoStructure
{
    /// <summary>
    /// 机票-航空公司信息接口
    /// </summary>
    public interface IJiPiaoHangKongGongSi
    {
        /// <summary>
        /// 获取航空公司信息集合
        /// </summary>
        /// <returns></returns>
        IList<EyouSoft.Model.JiPiaoStructure.MJiPiaoHangKongGongSiInfo> GetHangKongGongSis();
        /// <summary>
        /// 获取航空公司信息业务实体
        /// </summary>
        /// <param name="code">航空公司代码</param>
        /// <returns></returns>
        EyouSoft.Model.JiPiaoStructure.MJiPiaoHangKongGongSiInfo GetHangKongGongSiInfo(string code);
    }
}
*/