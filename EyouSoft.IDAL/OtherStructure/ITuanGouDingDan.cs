using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.OtherStructure
{
    public interface ITuanGouDingDan
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(EyouSoft.Model.OtherStructure.MTuanGouDingDan model);
        ///// <summary>
        ///// 更新一条数据
        ///// </summary>
        //int Update(EyouSoft.Model.OtherStructure.MTuanGouDingDan model);
        /// <summary>
        /// 删除数据
        /// </summary>
        int Delete(int ID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        EyouSoft.Model.OtherStructure.MTuanGouDingDan GetModel(int ID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.OtherStructure.MTuanGouDingDan> GetList(int PageSize, int PageIndex, ref int RecordCount, EyouSoft.Model.OtherStructure.MTuanGouDingDanSer serModel);
        /// <summary>
        /// 根据产品id获取订单数量
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int GetNumById(int id);
        /// <summary>
        /// 设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        int SheZhiOrderStatus(string orderId, EyouSoft.Model.Enum.XianLuStructure.OrderStatus status);
                /// <summary>
        /// 支付完成执行方法
        /// </summary>
        /// <param name="info">订单</param>
        /// <returns></returns>
        int SheZhiZhiFus(EyouSoft.Model.OtherStructure.MTuanGouDingDan info);

        /// <summary>
        /// 根据订单状态获取订单数量
        /// </summary>
        /// <param name="Status">订单状态</param>
        /// <returns></returns>
        int GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus Status);

    }
}
