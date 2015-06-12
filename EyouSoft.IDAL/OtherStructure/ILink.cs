using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.OtherStructure
{
    public interface ILink
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(EyouSoft.Model.MLink model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(EyouSoft.Model.MLink model);
        /// <summary>
        /// 删除数据
        /// </summary>
        int Delete(string LinkID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        EyouSoft.Model.MLink GetModel(string LinkID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        IList<EyouSoft.Model.MLink> GetList();
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        IList<EyouSoft.Model.MLink> GetList(int PageSize, int PageIndex, ref int RecordCount);

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        IList<EyouSoft.Model.MLink> GetList(int Top);

    }
}
