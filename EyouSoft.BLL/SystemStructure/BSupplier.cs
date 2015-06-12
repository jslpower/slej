using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit.BLL;
using EyouSoft.Model.SystemStructure;

namespace EyouSoft.BLL.SystemStructure
{
    public class BSupplier : BLLBase
    {
        private readonly EyouSoft.IDAL.SystemStructure.ISupplier dal = new EyouSoft.DAL.SystemStructure.DSupplier();
        /// <summary>
        /// 验证用户名是否存在
        /// </summary>
        /// <param name="accountName">用户名</param>
        /// <returns></returns>
        public bool ExistsName(string accountName)
        {
            if (string.IsNullOrEmpty(accountName)) return false;
            return dal.ExistsName(accountName);
        }
        /// <summary>
        /// 添加供应商
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public int Insert(MSupplier info)
        {
            info.IssueTime = DateTime.Now;
            return dal.Insert(info);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Update(MSupplier info)
        {
            if (string.IsNullOrEmpty(info.ID)) return 0;
            return dal.Update(info);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public int Delete(string supplierID)
        {
            if (string.IsNullOrEmpty(supplierID)) return 0;
            return dal.Delete(supplierID);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="supplierid">供应商编号</param>
        /// <returns></returns>
        public MSupplier GetModel(string supplierid)
        {
            if (string.IsNullOrEmpty(supplierid)) return null;
            return dal.GetModel(supplierid);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="supplierid">供应商编号</param>
        /// <returns></returns>
        public MSupplier GetSupplierModel(string supplierName)
        {
            if (string.IsNullOrEmpty(supplierName)) return null;
            return dal.GetSupplierModel(supplierName);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="serch"></param>
        /// <returns></returns>
        public IList<MSupplier> GetList(int pageSize, int pageIndex, ref int recordCount, MSupplierSer serch)
        {
            return dal.GetList(pageSize, pageIndex, ref recordCount, serch);
        }
    }
}
