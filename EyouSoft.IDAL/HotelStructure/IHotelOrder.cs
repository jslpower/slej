using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.HotelStructure;
namespace EyouSoft.IDAL.HotelStructure
{
    public interface IHotelOrder
    {
        #region IHotelOrder 成员

        /// <summary>
        /// 增加一条数据
        ///  -1：酒店已删除或下架
        /// -2：房型已删除或下架
        /// -3:入住时间段存在错误价格信息
        /// -4:订单预订房间数超过房型最大房间数
        /// </summary>
        int Add(MHotelOrder model);

        /// <summary>
        /// 更新一条数据
        /// -1：酒店已删除或下架
        /// -2：房型已删除或下架
        /// -3:入住时间段存在错误价格信息
        /// -4:订单预订房间数超过房型最大房间数
        /// </summary>
        int Update(MHotelOrder model);



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        MHotelOrder GetModel(string OrderId);

        /// <summary>
        /// 获得数据列表集合，分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        IList<MHotelOrder> GetList(int pageSize, int pageIndex, ref int recordCount, MHotelOrderSeach seach);

        /// <summary>
        /// 获得前几行数据集合
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="seach"></param>
        /// <returns></returns>
        IList<MHotelOrder> GetList(int Top, MHotelOrderSeach seach);

        /// <summary>
        /// 修改订单状态
        /// </summary>
        /// <param name="OrderState"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool UpdateOrderState(EyouSoft.Model.Enum.OrderState OrderState, string OrderId);


        /// <summary>
        /// 修改审核状态
        /// </summary>
        /// <param name="CheckState"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool UpdatePaymentState(EyouSoft.Model.Enum.PaymentState PaymentState, string OrderId);

        /// <summary>
        /// 获取联系人
        /// </summary>
        /// <param name="OrderId">订单id</param>
        /// <returns></returns>
        IList<EyouSoft.Model.HotelStructure.MHotelOrderContact> GetContent(string OrderId);
        /// <summary>
        /// 支付完成执行方法
        /// </summary>
        /// <param name="info">订单</param>
        /// <returns></returns>
        int SheZhiZhiFus(MHotelOrder info);
        /// <summary>
        /// 删除酒店订单
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
        #endregion
    }
}
