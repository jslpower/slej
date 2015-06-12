//线路产品订单相关信息业务逻辑类 汪奇志 2013-03-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.XianLuStructure;
using EyouSoft.Model.Enum.XianLuStructure;
using EyouSoft.Toolkit;

namespace EyouSoft.BLL.XianLuStructure
{
    /// <summary>
    /// 线路产品订单相关信息业务逻辑类
    /// </summary>
    public class BOrder
    {
        private readonly EyouSoft.IDAL.XianLuStructure.IOrder dal = new EyouSoft.DAL.XianLuStructure.DOrder();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BOrder() { }
        #endregion

        #region private members
        /// <summary>
        /// 写入订单变更历史记录，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int InsertOrderHistory(MOrderHistoryInfo info)
        {
            if (info == null || string.IsNullOrEmpty(info.OrderId)
                || string.IsNullOrEmpty(info.OperatorId)) return 0;

            info.IssueTime = DateTime.Now;

            return dal.InsertOrderHistory(info);
        }
        #endregion

        #region public members
        /// <summary>
        /// 写入订单信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MOrderInfo info)
        {
            if (info == null) return 0;

            if (string.IsNullOrEmpty(info.XianLuId) || string.IsNullOrEmpty(info.TourId)) return -1;

            info.OrderId = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;
            info.Status = EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理;
            info.FuKuanStatus = EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.未付款;

            if (info.YouKes != null && info.YouKes.Count > 0)
            {
                foreach (var item in info.YouKes)
                {
                    item.YouKeId = Guid.NewGuid().ToString();
                }
            }

            int dalRetCode = dal.Insert(info);

            if (dalRetCode == 1)
            {
                var history = new EyouSoft.Model.XianLuStructure.MOrderHistoryInfo();
                history.BeiZhu = "下单";
                history.LeiXing = OrderHistoryLeiXing.新增;
                history.OperatorId = info.OperatorId;
                history.OrderId = info.OrderId;
                history.Status = info.Status;
                InsertOrderHistory(history);

                //发送短信
                //new EyouSoft.BLL.OtherStructure.BSms().FaSongDingDanDuanXin(1, info.OrderId, EyouSoft.Model.Enum.SmsFaSongLeiXing.下单);
                new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(info.OrderId, EyouSoft.Model.Enum.DingDanLeiBie.线路订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.下单);
                //分销比例
                var jianglibi = new EyouSoft.Model.OtherStructure.MJiangJiBi();
                //返联盟推广
                var flmtgInfo = new EyouSoft.Model.OtherStructure.MTuiGuangFanLiInfo();
                flmtgInfo.DingDanId = info.OrderId;
                switch (info.RouteType)
                {
                    case EyouSoft.Model.Enum.AreaType.出境线路: flmtgInfo.DingDanLeiXing = EyouSoft.Model.OtherStructure.DingDanType.出境订单;jianglibi.OrderType = EyouSoft.Model.OtherStructure.DingDanType.出境订单;  break;
                    case EyouSoft.Model.Enum.AreaType.国内长线: flmtgInfo.DingDanLeiXing = EyouSoft.Model.OtherStructure.DingDanType.长线订单;jianglibi.OrderType = EyouSoft.Model.OtherStructure.DingDanType.长线订单; break;
                    case EyouSoft.Model.Enum.AreaType.周边短线: flmtgInfo.DingDanLeiXing = EyouSoft.Model.OtherStructure.DingDanType.短线订单;jianglibi.OrderType = EyouSoft.Model.OtherStructure.DingDanType.短线订单; break;
                }
                flmtgInfo.FanLiBiLi = 0;
                flmtgInfo.XiaDanRenId = info.OperatorId;
                new EyouSoft.BLL.OtherStructure.BTuiGuang().TuiGuangFanLi_C(flmtgInfo);

                //分销比例
                jianglibi.DingDanId = info.OrderId;
                jianglibi.JiangLiBiLi = new EyouSoft.BLL.OtherStructure.BKV().GetXiaJiFenXiaoJiangLiPeiZhi().JieSuanBiLi;
                new EyouSoft.BLL.OtherStructure.BTuiGuang().FenXiaoJiangli_C(jianglibi);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取订单信息实体
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <returns></returns>
        public MOrderInfo GetInfo(string orderId)
        {
            if (string.IsNullOrEmpty(orderId)) return null;

            return dal.GetInfo(orderId);
        }

        /// <summary>
        /// 更新订单信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Update(MOrderInfo info)
        {
            if (info == null) return 0;

            if (string.IsNullOrEmpty(info.XianLuId) || string.IsNullOrEmpty(info.TourId)) return -1;
            if (string.IsNullOrEmpty(info.OperatorId)) return -2;

            if (info.YouKes != null && info.YouKes.Count > 0)
            {
                foreach (var item in info.YouKes)
                {
                    if (string.IsNullOrEmpty(item.YouKeId))
                        item.YouKeId = Guid.NewGuid().ToString();
                }
            }

            info.IssueTime = DateTime.Now;
            int dalRetCode = dal.Update(info);

            if (dalRetCode == 1)
            {
                var history = new EyouSoft.Model.XianLuStructure.MOrderHistoryInfo();
                history.BeiZhu = "修改";
                history.LeiXing = OrderHistoryLeiXing.修改;
                history.OperatorId = info.OperatorId;
                history.OrderId = info.OrderId;
                history.Status = info.Status;

                InsertOrderHistory(history);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="memberId">会员编号</param>
        /// <param name="status">状态</param>
        /// <param name="history">订单变更记录信息</param>
        /// <returns></returns>
        public int SheZhiOrderStatus(string orderId, OrderStatus status, MOrderHistoryInfo history)
        {
            if (string.IsNullOrEmpty(orderId) || history == null || string.IsNullOrEmpty(history.OperatorId)) return 0;

            history.LeiXing = OrderHistoryLeiXing.设置状态;
            history.Status = status;
            history.OrderId = orderId;

            int dalRetCode = dal.SheZhiOrderStatus(orderId, status);

            if (dalRetCode == 1)
            {
                InsertOrderHistory(history);

                //if (status == OrderStatus.待付款)
                //{
                //    new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(orderId, EyouSoft.Model.Enum.DingDanLeiBie.线路订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.确认);
                //}
            }

            return dalRetCode;
        }

        /// <summary>
        /// 设置付款状态，返回1成功，其它失败
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="memberId">会员编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int SheZhiFuKuanStatus(string orderId, string memberId, FuKuanStatus status, MOrderHistoryInfo history)
        {
            if (string.IsNullOrEmpty(orderId) || string.IsNullOrEmpty(memberId)
                || history == null || string.IsNullOrEmpty(history.OperatorId)) return 0;

            history.LeiXing = OrderHistoryLeiXing.设置付款状态;
            history.Status = OrderStatus.交易完成;
            history.OrderId = orderId;

            int dalRetCode = dal.SheZhiFuKuanStatus(orderId, memberId, status);

            if (dalRetCode == 1)
            {
                InsertOrderHistory(history);
            }

            return dalRetCode;
        }

        /// <summary>
        /// 获取订单信息集合
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<MOrderInfo> GetOrders(int pageSize, int pageIndex, ref int recordCount, MOrderChaXunInfo chaXun)
        {
            if (!Utils.ValidPaging(pageSize, pageIndex)) return null;

            if (chaXun != null && chaXun.IsFeiHuiYuan)
            {
                if (string.IsNullOrEmpty(chaXun.FeiHuiYuanDianHua)
                    //|| string.IsNullOrEmpty(chaXun.FeiHuiYuanDingDanHao) 
                    || string.IsNullOrEmpty(chaXun.FeiHuiYuanXingMing))
                    return null;
            }

            return dal.GetOrders(pageSize, pageIndex, ref recordCount, chaXun);
        }
        /// <summary>
        /// 支付完成执行方法
        /// </summary>
        /// <param name="info">订单</param>
        /// <returns></returns>
        public int SheZhiZhiFus(MOrderInfo info)
        {
            if (string.IsNullOrEmpty(info.OrderId)) return 0;
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
        #endregion
    }
}
