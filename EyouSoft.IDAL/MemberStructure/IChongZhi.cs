/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.MemberStructure;

namespace EyouSoft.IDAL.MemberStructure
{
    /// <summary>
    /// 充值
    /// </summary>
    public interface IChongZhi
    {
        /// <summary>
        /// 写入充值记录，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(MChongZhi info);
        ///// <summary>
        ///// 修改充值数据，返回1成功，其它失败
        ///// </summary>
        ///// <param name="info">实体</param>
        ///// <returns></returns>
        //int Update(MChongZhi info);
        /// <summary>
        /// 获取充值
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<MChongZhi> GetList(int pageSize, int pageIndex, ref int recordCount, MChongZhiSer chaXun);
    }
}
*/