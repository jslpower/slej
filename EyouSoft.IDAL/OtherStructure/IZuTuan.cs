using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.OtherStructure;

namespace EyouSoft.IDAL.OtherStructure
{
    public interface IZuTuan
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(MZuTuan model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(MZuTuan model);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="LinkID"></param>
        /// <returns></returns>
        MZuTuan GetModel();
    }
}
