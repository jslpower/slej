using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.OtherStructure
{
    public interface ISysLogHandle
    {

        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(EyouSoft.Model.MSysLogHandle model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(EyouSoft.Model.MSysLogHandle model);
        /// <summary>
        /// 删除数据
        /// </summary>
        int Delete(string Id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        EyouSoft.Model.MSysLogHandle GetModel(string Id);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        IList<EyouSoft.Model.MSysLogHandle> GetList(int PageSize,int PageIndex,ref int RecordCount,EyouSoft.Model.MSearchSysLogHandle Search);
    }
}
