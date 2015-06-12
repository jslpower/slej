using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.MallStructure;

namespace EyouSoft.BLL.MallStructure
{
    public class BShangChengDingDan
    {
        private readonly EyouSoft.IDAL.MallStructure.IShangChengDingDan dal = new EyouSoft.DAL.MallStructure.DShangChengDingDan();
        /// <summary>
        /// 写入商品表，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MShangChengDingDan info)
        {
            info.OrderID = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;

            if (string.IsNullOrEmpty(info.ProductID)) return 0;

            int reltCode = dal.Insert(info);
            if(reltCode ==1)
            {
                //分销比例
                var jianglibi = new EyouSoft.Model.OtherStructure.MJiangJiBi();
                jianglibi.DingDanId = info.OrderID;
                jianglibi.OrderType = EyouSoft.Model.OtherStructure.DingDanType.商城订单;
                jianglibi.JiangLiBiLi = new EyouSoft.BLL.OtherStructure.BKV().GetXiaJiFenXiaoJiangLiPeiZhi().JieSuanBiLi;
                new EyouSoft.BLL.OtherStructure.BTuiGuang().FenXiaoJiangli_C(jianglibi);
            }
            return reltCode;
        }
        ///// <summary>
        ///// 删除商品
        ///// </summary>
        ///// <param name="ChanPinBianHao"></param>
        ///// <returns>-99：产品下有订单 1：成功 其他返回值：失败</returns>
        //public int Delete(string ChanPinBianHao)
        //{
        //    if (string.IsNullOrEmpty(ChanPinBianHao)) return 0;
        //    return dal.Delete(ChanPinBianHao);
        //}
        /// <summary>
        /// 获取商品信息实体
        /// </summary>
        /// <param name="OrderID">订单编号</param>
        /// <returns></returns>
        public MShangChengDingDan GetModel(string OrderID)
        {
            if (string.IsNullOrEmpty(OrderID)) return null;
            return dal.GetModel(OrderID);

        }
        /// <summary>
        /// 更新订单，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Update(MShangChengDingDan info)
        {
            if (string.IsNullOrEmpty(info.OrderID)) return 0;
            return dal.Update(info);
        }
        /// <summary>
        /// 获取商品集合
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<MShangChengDingDan> GetList(int pageSize, int pageIndex, ref int recordCount, MShangChengDingDanSer chaXun)
        {

            return dal.GetList(pageSize, pageIndex, ref recordCount, chaXun);
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
        public int SheZhiZhiFus(MShangChengDingDan info)
        {
            if (string.IsNullOrEmpty(info.OrderID)) return 0;
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
