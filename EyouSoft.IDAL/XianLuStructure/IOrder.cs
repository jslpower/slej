//线路产品订单相关信息数据访问类接口 汪奇志 2013-03-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.XianLuStructure;
using EyouSoft.Model.Enum.XianLuStructure;

namespace EyouSoft.IDAL.XianLuStructure
{
    /// <summary>
    /// 线路产品订单相关信息数据访问类接口
    /// </summary>
    public interface IOrder
    {
        /// <summary>
        /// 写入订单信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(MOrderInfo info);
        /// <summary>
        /// 获取订单信息实体
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <returns></returns>
        MOrderInfo GetInfo(string orderId);
        /// <summary>
        /// 更新订单信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        int Update(MOrderInfo info);
        /// <summary>
        /// 设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="memberId">会员编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        int SheZhiOrderStatus(string orderId, OrderStatus status);
        /// <summary>
        /// 写入订单变更历史记录，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int InsertOrderHistory(MOrderHistoryInfo info);
        /// <summary>
        /// 设置付款状态，返回1成功，其它失败
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="memberId">会员编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        int SheZhiFuKuanStatus(string orderId, string memberId, FuKuanStatus status);

        /// <summary>
        /// 获取订单信息集合
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<MOrderInfo> GetOrders(int pageSize, int pageIndex, ref int recordCount, MOrderChaXunInfo chaXun);
        /// <summary>
        /// 支付完成执行方法
        /// </summary>
        /// <param name="info">订单</param>
        /// <returns></returns>
        int SheZhiZhiFus(MOrderInfo info);
        /// <summary>
        /// 根据订单状态获取订单数量
        /// </summary>
        /// <param name="Status">订单状态</param>
        /// <returns></returns>
        int GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus Status);
    }
}
