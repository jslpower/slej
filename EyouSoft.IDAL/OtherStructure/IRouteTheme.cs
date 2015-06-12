using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.OtherStructure
{
    public interface IRouteTheme
    {
        int Add(EyouSoft.Model.MRouteTheme model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(EyouSoft.Model.MRouteTheme model);
        /// <summary>
        /// 删除数据
        /// </summary>
        int Delete(int ID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        EyouSoft.Model.MRouteTheme GetModel(int ID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        IList<EyouSoft.Model.MRouteTheme> GetList();
        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        IList<EyouSoft.Model.MRouteTheme> GetList(int PageSize, int PageIndex, ref int RecordCount);
    }
}
