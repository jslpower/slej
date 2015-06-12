using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.MallStructure;
using EyouSoft.Model.Enum.XianLuStructure;

namespace EyouSoft.IDAL.MallStructure
{
    public interface IShangChengDingDan
    {
        /// <summary>
        /// 写入订单表，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(MShangChengDingDan info);
        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns>-99：产品下有订单 1：成功 其他返回值：失败</returns>
        int Delete(string OrderID);
        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="ShangPinID">订单编号</param>
        /// <returns></returns>
        MShangChengDingDan GetModel(string OrderID);
        /// <summary>
        /// 更新订单，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        int Update(MShangChengDingDan info);
        /// <summary>
        /// 获取商品集合
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<MShangChengDingDan> GetList(int pageSize, int pageIndex, ref int recordCount, MShangChengDingDanSer chaXun);
        /// <summary>
        /// 设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        int SheZhiOrderStatus(string orderId, OrderStatus status);
        /// <summary>
        /// 支付完成执行方法
        /// </summary>
        /// <param name="info">订单</param>
        /// <returns></returns>
        int SheZhiZhiFus(MShangChengDingDan info);
        /// <summary>
        /// 根据订单状态获取订单数量
        /// </summary>
        /// <param name="Status">订单状态</param>
        /// <returns></returns>
        int GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus Status);

    }
}
