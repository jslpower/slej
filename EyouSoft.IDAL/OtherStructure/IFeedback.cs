using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.OtherStructure;

namespace EyouSoft.IDAL.OtherStructure
{
    public interface IFeedback
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int add(MFeedback model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int update(MFeedback model);
        /// <summary>
        /// 删除数据
        /// </summary>
        int Delete(string model);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        MFeedback GetModel(string MemberID);
        /// <summary>)
        /// 分页获得数据列表
        /// </summary>
        IList<EyouSoft.Model.OtherStructure.MFeedback> GetList(int PageSize, int PageIndex, ref int RecordCount, EyouSoft.Model.OtherStructure.MSearchFeedback Search);
    }
}
