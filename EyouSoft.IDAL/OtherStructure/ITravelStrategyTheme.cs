using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL
{
    public interface ITravelStrategyTheme
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(EyouSoft.Model.MTravelStrategyTheme model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(EyouSoft.Model.MTravelStrategyTheme model);
        /// <summary>
        /// 删除数据
        /// </summary>
        int Delete(string ThemeID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        EyouSoft.Model.MTravelStrategyTheme GetModel(int ThemeID);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        IList<EyouSoft.Model.MTravelStrategyTheme> GetList(EyouSoft.Model.MTravelStrategyTheme Search);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        IList<EyouSoft.Model.MTravelStrategyTheme> GetList(int PageSize, int PageIndex, ref int RecordCount, EyouSoft.Model.MTravelStrategyTheme Search);

    }
}
