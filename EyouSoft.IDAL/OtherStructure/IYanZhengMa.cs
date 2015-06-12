using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.OtherStructure
{
    /// <summary>
    /// 验证码相关interface
    /// </summary>
    public interface IYanZhengMa
    {
        /// <summary>
        /// 写入验证码信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(EyouSoft.Model.OtherStructure.MYanZhengMaInfo info);
        /// <summary>
        /// 获取验证码信息
        /// </summary>
        /// <param name="shouJi">手机号码</param>
        /// <param name="yanZhengMa">验证码</param>
        /// <param name="leiXing">类型</param>
        /// <returns></returns>
        EyouSoft.Model.OtherStructure.MYanZhengMaInfo GetInfo(string shouJi, string yanZhengMa, EyouSoft.Model.Enum.YanZhengMaLeiXing leiXing);
        /// <summary>
        /// 设置验证码状态，返回1成功，其它失败
        /// </summary>
        /// <param name="identityId">验证码编号[自增编号]</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        int SetStatus(int identityId, EyouSoft.Model.Enum.YanZhengMaStatus status);
    }
}
