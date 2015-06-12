using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.WeiXin;

namespace EyouSoft.IDAL.WeiXin
{
    public interface IDWeiXin
    {
        /// <summary>
        /// 获取绑定信息
        /// </summary>
        /// <param name="Openid"></param>
        /// <returns></returns>
        MWinXin GetModel(string openid);

        /// <summary>
        /// 添加绑定信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        int Insert(MWinXin info);
    }
}
