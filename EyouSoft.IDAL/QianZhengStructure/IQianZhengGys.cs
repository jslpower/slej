//签证供应商信息接口 汪奇志 2013-11-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.QianZhengStructure
{
    /// <summary>
    /// 签证供应商信息接口
    /// </summary>
    public interface IQianZhengGys
    {
        /// <summary>
        /// 写入签证供应商信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(EyouSoft.Model.QianZhengStructure.MQianZhengGysInfo info);
        /// <summary>
        /// 更新签证供应商信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Update(EyouSoft.Model.QianZhengStructure.MQianZhengGysInfo info);
        /// <summary>
        /// 删除签证供应商信息，返回1成功，其它失败
        /// </summary>
        /// <param name="gysId">供应商编号</param>
        /// <returns></returns>
        int Delete(string gysId);
        /// <summary>
        /// 获取签证供应商信息业务实体
        /// </summary>
        /// <param name="gysId">供应商编号</param>
        /// <returns></returns>
        EyouSoft.Model.QianZhengStructure.MQianZhengGysInfo GetInfo(string gysId);
        /// <summary>
        /// 获取签证供应商信息集合
        /// </summary>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.QianZhengStructure.MQianZhengGysInfo> GetGyss(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.QianZhengStructure.MQianZhengGysChaXunInfo chaXun);
        /// <summary>
        /// 获取签证数量
        /// </summary>
        /// <param name="gysId">供应商编号</param>
        /// <returns></returns>
        int GetQianZhengShu(string gysId);
    }
}
