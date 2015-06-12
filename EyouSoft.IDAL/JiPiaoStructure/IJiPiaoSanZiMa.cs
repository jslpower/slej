/*//机票-城市三字码信息接口 汪奇志 2013-11-05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.JiPiaoStructure
{
    /// <summary>
    /// 机票-城市三字码信息接口
    /// </summary>
    public interface IJiPiaoSanZiMa
    {
        /// <summary>
        /// 获取三字码信息集合
        /// </summary>
        /// <returns></returns>
        IList<EyouSoft.Model.JiPiaoStructure.MJiPiaoSanZiMaInfo> GetSanZiMas();
        /// <summary>
        /// 获取三字码信息业务实体
        /// </summary>
        /// <param name="code">三字码</param>
        /// <returns></returns>
        EyouSoft.Model.JiPiaoStructure.MJiPiaoSanZiMaInfo GetSanZiMaInfo(string code);
    }
}
*/