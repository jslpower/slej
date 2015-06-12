using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.OtherStructure
{
    public interface ISystemLandMark
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(EyouSoft.Model.OtherStructure.MSystemLandMark model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(EyouSoft.Model.OtherStructure.MSystemLandMark model);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool Delete(params string[] Ids);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        EyouSoft.Model.OtherStructure.MSystemLandMark GetModel(int Id);
        /// <summary>
        /// 分页获得数据列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="Search"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.OtherStructure.MSystemLandMark> GetList(int PageSize, int PageIndex, ref int RecordCount, EyouSoft.Model.OtherStructure.MSystemLandMark Search);
        /// <summary>
        /// 获得前几行数据集合
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="Search"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.OtherStructure.MSystemLandMark> GetTopList(int Top, EyouSoft.Model.OtherStructure.MSystemLandMark Search);
    }
}
