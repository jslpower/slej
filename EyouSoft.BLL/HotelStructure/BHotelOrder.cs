using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.HotelStructure;
using EyouSoft.Toolkit;
using Linq.Expressions;
using EyouSoft.IDAL.HotelStructure;
namespace EyouSoft.BLL.HotelStructure
{
    public class BHotelOrder
    {
        private readonly EyouSoft.IDAL.HotelStructure.IHotelOrder dal = new EyouSoft.DAL.HotelStructure.DHotelOrder();

        #region IHotelOrder 成员

        /// <summary>
        /// 增加一条数据
        /// -1：酒店已删除或下架
        /// -2：房型已删除或下架
        /// -3:入住时间段存在错误价格信息
        /// -4:订单预订房间数超过房型最大房间数
        /// 1:成功 0：失败
        /// </summary>
        public int Add(MHotelOrder model)
        {
            if (string.IsNullOrEmpty(model.HotelId)
                || string.IsNullOrEmpty(model.RoomTypeId)
                || model.RoomCount == 0
                || model.CheckInDate == null
                || model.CheckOutDate == null
                || model.TotalAmount == 0
                || string.IsNullOrEmpty(model.ContactName)
                || string.IsNullOrEmpty(model.ContactMobile)) return 0;


            model.OrderId = Guid.NewGuid().ToString();

            int dalRetCode = dal.Add(model);

            if (dalRetCode == 1)
            {
                //发送短信
                //new EyouSoft.BLL.OtherStructure.BSms().FaSongDingDanDuanXin(2, model.OrderId, EyouSoft.Model.Enum.SmsFaSongLeiXing.下单);
            }

            return dalRetCode;

        }

        /// <summary>
        /// 更新一条数据
        /// -1：酒店已删除或下架
        /// -2：房型已删除或下架
        /// -3:入住时间段存在错误价格信息
        /// -4:订单预订房间数超过房型最大房间数
        /// 1:成功 0：失败
        /// </summary>
        public int Update(MHotelOrder model)
        {
            if (string.IsNullOrEmpty(model.OrderId)
                || string.IsNullOrEmpty(model.HotelId)
                || string.IsNullOrEmpty(model.RoomTypeId)
                || model.RoomCount == 0
                || model.CheckInDate == null
                || model.CheckOutDate == null
                || model.TotalAmount == 0
                || string.IsNullOrEmpty(model.ContactName)
                || string.IsNullOrEmpty(model.ContactMobile)) return 0;

            return dal.Update(model);
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        public MHotelOrder GetModel(string OrderId)
        {
            if (string.IsNullOrEmpty(OrderId)) return null;
            return dal.GetModel(OrderId);
        }

        /// <summary>
        /// 获得数据列表集合，分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public IList<MHotelOrder> GetList(int pageSize, int pageIndex, ref int recordCount, MHotelOrderSeach seach)
        {
            if (seach != null && seach.IsFeiHuiYuan)
            {
                if (string.IsNullOrEmpty(seach.FeiHuiYuanDianHua)
                    || string.IsNullOrEmpty(seach.FeiHuiYuanDingDanHao)
                    || string.IsNullOrEmpty(seach.FeiHuiYuanXingMing))
                    return null;
            }

            return dal.GetList(pageSize, pageIndex, ref recordCount, seach);
        }

        /// <summary>
        /// 获得前几行数据集合
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="seach"></param>
        /// <returns></returns>
        public IList<MHotelOrder> GetList(int Top, MHotelOrderSeach seach)
        {

            return dal.GetList(Top, seach);


        }

        /// <summary>
        /// 修改订单状态
        /// </summary>
        /// <param name="OrderState"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool UpdateOrderState(EyouSoft.Model.Enum.OrderState? OrderState, string OrderId)
        {
            if (!OrderState.HasValue || string.IsNullOrEmpty(OrderId)) return false;
            return dal.UpdateOrderState(OrderState.Value, OrderId);
        }


        /// <summary>
        /// 修改审核状态
        /// </summary>
        /// <param name="CheckState"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool UpdatePaymentState(EyouSoft.Model.Enum.PaymentState? PaymentState, string OrderId)
        {
            if (!PaymentState.HasValue || string.IsNullOrEmpty(OrderId)) return false;
            return dal.UpdatePaymentState(PaymentState.Value, OrderId);
        }
        /// <summary>
        /// 获取联系人
        /// </summary>
        /// <param name="OrderId">订单id</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.HotelStructure.MHotelOrderContact> GetContent(string OrderId)
        {
            return dal.GetContent(OrderId);
        }
        /// <summary>
        /// 支付完成执行方法
        /// </summary>
        /// <param name="info">订单</param>
        /// <returns></returns>
        public int SheZhiZhiFus(MHotelOrder info)
        {
            if (string.IsNullOrEmpty(info.OrderId)) return 0;
            return dal.SheZhiZhiFus(info);
        }
        /// <summary>
        /// 删除酒店订单
        /// </summary>
        /// <param name="orderid">订单id</param>
        /// <returns></returns>
        public int DeleteOrder(string orderid)
        {
            if (string.IsNullOrEmpty(orderid)) return 0;
            return dal.DeleteOrder(orderid);
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
        #endregion
    }
}
