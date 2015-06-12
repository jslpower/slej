using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.ZuCheStructure;
using EyouSoft.Toolkit;

namespace EyouSoft.BLL.ZuCheStructure
{
    public class BZuCheOrder
    {
        private readonly EyouSoft.IDAL.ZuCheStructure.IZuCheOrder dal = new EyouSoft.DAL.ZuCheStructure.DZuCheOrder();

        public BZuCheOrder()
        {

        }

        /// <summary>
        /// 写入订单信息，返回1成功，其它失败
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public int Add(MZuCheOrder model)
        {
            if (model == null) return 0;

            if (string.IsNullOrEmpty(model.ZuCheID)
                || string.IsNullOrEmpty(model.YuDingRName)) return -1;
            model.IssueTime = DateTime.Now;
            model.Status = EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理;
            model.FuKuanStatus = EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.未付款;

            int dalRetCode = dal.Add(model);
            if (dalRetCode == 1)
            {
                //发短信

                //分销比例
                var jianglibi = new EyouSoft.Model.OtherStructure.MJiangJiBi();
                jianglibi.DingDanId = model.OrderId;
                jianglibi.OrderType = EyouSoft.Model.OtherStructure.DingDanType.租车订单;
                jianglibi.JiangLiBiLi = new EyouSoft.BLL.OtherStructure.BKV().GetXiaJiFenXiaoJiangLiPeiZhi().JieSuanBiLi;
                new EyouSoft.BLL.OtherStructure.BTuiGuang().FenXiaoJiangli_C(jianglibi);
            }
            return dalRetCode;
        }

        /// <summary>
        /// 更新订单信息，返回1成功，其它失败
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(MZuCheOrder model)
        {
            if (model == null) return 0;
            if (string.IsNullOrEmpty(model.ZuCheID)) return -1;
            if (string.IsNullOrEmpty(model.OperatorId.ToString())) return -2;

            model.IssueTime = DateTime.Now;
            int dalRetCode = dal.Update(model);
            if (dalRetCode == 1)
            {

            }
            return dalRetCode;
        }

        /// <summary>
        /// 获取订单信息实体
        /// </summary>
        /// <param name="OrderID">订单编号</param>
        /// <returns></returns>
        public MZuCheOrder GetModel(string OrderID)
        {
            if (string.IsNullOrEmpty(OrderID)) return null;

            return dal.GetModel(OrderID);
        }

        /// <summary>
        /// 获取订单信息集合
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<MZuCheOrder> GetOrders(int pageSize, int pageIndex, ref int recordCount, MZuCheOrderChaXun chaXun)
        {
            if (!Utils.ValidPaging(pageSize, pageIndex)) return null;

            return dal.GetOrders(pageSize, pageIndex, ref recordCount, chaXun);
        }

        /// <summary>
        /// 设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="memberId">会员编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int SheZhiOrderStatus(string orderId, string memberId, EyouSoft.Model.Enum.XianLuStructure.OrderStatus status)
        {
            if (string.IsNullOrEmpty(orderId) || string.IsNullOrEmpty(memberId)) return 0;

            int dalRetCode = dal.SheZhiOrderStatus(orderId, memberId, status);

            return dalRetCode;
        }

        /// <summary>
        /// 设置付款状态，返回1成功，其它失败
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="memberId">会员编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int SheZhiFuKuanStatus(string orderId, string memberId, EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus status)
        {
            if (string.IsNullOrEmpty(orderId) || string.IsNullOrEmpty(memberId)) return 0;

            int dalRetCode = dal.SheZhiFuKuanStatus(orderId, memberId, status);

            if (dalRetCode == 1)
            {

            }

            return dalRetCode;
        }
        /// <summary>
        /// 支付完成执行方法
        /// </summary>
        /// <param name="info">订单</param>
        /// <returns></returns>
        public int SheZhiZhiFus(MZuCheOrder info)
        {
            if (string.IsNullOrEmpty(info.OrderId)) return 0;
            return dal.SheZhiZhiFus(info);
        }
        /// <summary>
        /// 删除未审核订单
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
    }
}
