using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit.BLL;
using EyouSoft.Model.WeiXin;

namespace EyouSoft.BLL.WeiXin
{
    public class BWeiXin
    {
        private readonly EyouSoft.IDAL.WeiXin.IDWeiXin dal = new EyouSoft.DAL.WeiXin.DWeiXin();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        public int Insert(MWinXin model)
        {
            return dal.Insert(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public MWinXin GetModel(string openid)
        {
            if (string.IsNullOrEmpty(openid)) return null;
            return dal.GetModel(openid);
        }
    }
}
