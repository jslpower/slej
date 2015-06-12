using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.OtherStructure
{
   public interface IPayMents
    {
        /// <summary>
        /// 新增收益率
        /// </summary>
        /// <param name="interest"></param>
        /// <returns></returns>
        int AddInterestRate(decimal interest);
        /// <summary>
        /// 修改收益率
        /// </summary>
        /// <param name="interest"></param>
        /// <returns></returns>
        int UpdateInterestRate(decimal interest);

        bool ExistsData();

       /// <summary>
       /// 获取收益实体
       /// </summary>
       /// <returns></returns>
        EyouSoft.Model.OtherStructure.MInterestRate Get();

       /// <summary>
       /// 收支记录表分页
       /// </summary>
       /// <param name="pageSize"></param>
       /// <param name="PageIndex"></param>
       /// <param name="RecordCount"></param>
       /// <returns></returns>
       IList<EyouSoft.Model.OtherStructure.MPayMentsInfo> GetList(int pageSize,int PageIndex,ref int RecordCount,EyouSoft.Model.OtherStructure.MPaySearch searchModel);

       /// <summary>
       /// 历史收益总和
       /// </summary>
       /// <param name="memberID"></param>
       /// <returns></returns>
       decimal GetHistoryRate(string memberID);

    }
}
