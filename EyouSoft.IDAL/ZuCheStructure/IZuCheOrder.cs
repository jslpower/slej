using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.ZuCheStructure;

namespace EyouSoft.IDAL.ZuCheStructure
{
    public interface IZuCheOrder
    {
        /// <summary>
        /// 写入订单信息，返回1成功，其它失败
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        int Add(MZuCheOrder model);
        /// <summary>
        /// 更新订单信息，返回1成功，其它失败
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Update(MZuCheOrder model);
        /// <summary>
        /// 获取订单信息实体
        /// </summary>
        /// <param name="OrderID">订单编号</param>
        /// <returns></returns>
        MZuCheOrder GetModel(string OrderID);
        /// <summary>
        /// 获取订单信息集合
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<MZuCheOrder> GetOrders(int pageSize, int pageIndex, ref int recordCount, MZuCheOrderChaXun chaXun);
        /// <summary>
        /// 设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="memberId">会员编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        int SheZhiOrderStatus(string orderId, string memberId, EyouSoft.Model.Enum.XianLuStructure.OrderStatus status);
        /// <summary>
        /// 设置付款状态，返回1成功，其它失败
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="memberId">会员编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        int SheZhiFuKuanStatus(string orderId, string memberId, EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus status);
        /// <summary>
        /// 支付完成执行方法
        /// </summary>
        /// <param name="info">订单</param>
        /// <returns></returns>
        int SheZhiZhiFus(MZuCheOrder info);
        /// <summary>
        /// 删除未审核订单
        /// </summary>
        /// <param name="orderid">订单id</param>
        /// <returns></returns>
        int DeleteOrder(string orderid);
        /// <summary>
        /// 根据订单状态获取订单数量
        /// </summary>
        /// <param name="Status">订单状态</param>
        /// <returns></returns>
        int GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus Status);
    }
}
