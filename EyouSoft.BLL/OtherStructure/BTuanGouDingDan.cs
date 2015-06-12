using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.OtherStructure
{
    public class BTuanGouDingDan
    {
        private readonly EyouSoft.IDAL.OtherStructure.ITuanGouDingDan dal = new EyouSoft.DAL.OtherStructure.DTuanGouDingDan();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(EyouSoft.Model.OtherStructure.MTuanGouDingDan model)
        {
            model.IssueTime = DateTime.Now;
            if (string.IsNullOrEmpty(model.SupplierID)) return 0;
            return dal.Add(model);
        }
        ///// <summary>
        ///// 更新一条数据
        ///// </summary>
        //public int Update(EyouSoft.Model.OtherStructure.MTuanGouDingDan model)
        //{
        //    if (model.OrderID == 0) return 0;
        //    return dal.Update(model);
        //}
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            if (ID == 0) return 0;
            return dal.Delete(ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EyouSoft.Model.OtherStructure.MTuanGouDingDan GetModel(int ID)
        {
            if (ID == 0) return null;
            return dal.GetModel(ID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.OtherStructure.MTuanGouDingDan> GetList(int PageSize, int PageIndex, ref int RecordCount, EyouSoft.Model.OtherStructure.MTuanGouDingDanSer serModel)
        {
            return dal.GetList(PageSize, PageIndex, ref RecordCount, serModel);
        }
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetNumById(int id)
        {
            return dal.GetNumById(id);
        }
        /// <summary>
        /// 设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int SheZhiOrderStatus(string orderId, EyouSoft.Model.Enum.XianLuStructure.OrderStatus status)
        {
            if (string.IsNullOrEmpty(orderId)) return 0;
            return dal.SheZhiOrderStatus(orderId, status);
        }
        /// <summary>
        /// 支付完成执行方法
        /// </summary>
        /// <param name="info">订单</param>
        /// <returns></returns>
        public int SheZhiZhiFus(EyouSoft.Model.OtherStructure.MTuanGouDingDan info)
        {
            if (info.OrderID == 0) return 0;
            return dal.SheZhiZhiFus(info);
        }
        /// <summary>
        /// 根据订单状态获取订单数量
        /// </summary>
        /// <param name="Status">订单状态</param>
        /// <returns></returns>
        public int GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus Status)
        {
            return dal.GetOrderNum(Status);
        }
    }
}
