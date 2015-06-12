using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL
{
    public interface IArticleClass
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(EyouSoft.Model.MArticleClass model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(EyouSoft.Model.MArticleClass model);
        /// <summary>
        /// 删除数据
        /// </summary>
        int Delete(string ClassId);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        EyouSoft.Model.MArticleClass GetModel(int ClassId);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        IList<EyouSoft.Model.MArticleClass> GetList(int PageSize, int PageIndex, ref int RecordCount, EyouSoft.Model.MArticleClass Search);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        IList<EyouSoft.Model.MArticleClass> GetList(int top, EyouSoft.Model.MArticleClass Search);

    }
}
