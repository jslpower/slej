using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.SystemStructure;

namespace EyouSoft.IDAL.SystemStructure
{
    public interface ISupplier
    {
        /// <summary>
        /// 验证用户名是否存在
        /// </summary>
        /// <param name="accountName">用户名</param>
        /// <returns></returns>
        bool ExistsName(string accountName);
        /// <summary>
        /// 添加供应商
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        int Insert(MSupplier info);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        int Update(MSupplier info);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        int Delete(string supplierID);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="supplierid">供应商编号</param>
        /// <returns></returns>
        MSupplier GetModel(string supplierid);
        // <summary>
        /// 获取实体
        /// </summary>
        /// <param name="supplierid">供应商编号</param>
        /// <returns></returns>
        MSupplier GetSupplierModel(string supplierName);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="serch"></param>
        /// <returns></returns>
        IList<MSupplier> GetList(int pageSize, int pageIndex, ref int recordCount, MSupplierSer serch);

    }
}
