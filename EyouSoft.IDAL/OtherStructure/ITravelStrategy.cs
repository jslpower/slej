using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model;

namespace EyouSoft.IDAL
{
    /// <summary>
    /// 旅游攻略
    /// </summary>
    public interface ITravelStrategy
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(MTravelStrategy model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(MTravelStrategy model);
        /// <summary>
        /// 删除数据
        /// </summary>
        bool Delete(string TravelID);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool Delete(params string[] ids);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        MTravelStrategy GetModel(string TravelID);
        /// <summary>
        /// 获得数据列表集合，分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="chaXun"></param>
        /// <param name="filedOrder">排序：IsHot ASC，SortRule DESC，IssueTime DESC</param>
        /// <returns></returns>
        IList<MTravelStrategy> GetList(int pageSize, int pageIndex, ref int recordCount, MTravelStrategyCX chaXun, IList<EyouSoft.Model.TravelArticleOrderBy> FiledOrder);
        /// <summary>
        /// 获得前几行数据集合
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="chaXun"></param>
        /// <param name="filedOrder">排序：IsHot ASC，SortRule DESC，IssueTime DESC</param>
        /// <returns></returns>
        IList<MTravelStrategy> GetTopList(int Top, MTravelStrategyCX chaXun, IList<EyouSoft.Model.TravelArticleOrderBy> FiledOrder);

        /// <summary>
        /// 点击量+1
        /// </summary>
        /// <param name="Id"></param>
        bool SetClick(string Id);

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="Id">编号</param>
        /// <param name="flag">状态</param>
        bool SetCheck(bool flag, string Id);

        /// <summary>
        /// 批量审核
        /// </summary>
        /// <param name="flag">状态</param>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool SetCheck(bool flag, params string[] Ids);
    }
}
