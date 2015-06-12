//签证订单信息接口 汪奇志 2013-11-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.QianZhengStructure
{
    /// <summary>
    /// 签证订单信息接口
    /// </summary>
    public interface IQianZhengDingDan
    {
        /// <summary>
        /// 写入订单信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(EyouSoft.Model.QianZhengStructure.MQianZhengDingDanInfo info);
        /// <summary>
        /// 更新订单信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Update(EyouSoft.Model.QianZhengStructure.MQianZhengDingDanInfo info);
        /// <summary>
        /// 删除订单信息，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="xiaDanRenId">下单人编号</param>
        /// <returns></returns>
        int Delete(string dingDanId, string xiaDanRenId);
        /// <summary>
        /// 获取订单信息实体
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <returns></returns>
        EyouSoft.Model.QianZhengStructure.MQianZhengDingDanInfo GetInfo(string dingDanId);
        /// <summary>
        /// 获取订单信息集合
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.QianZhengStructure.MQianZhengDingDanInfo> GetDingDans(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.QianZhengStructure.MQianZhengDingDanChaXunInfo chaXun);
        /// <summary>
        /// 设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="xiaDanRenId">下单人编号</param>
        /// <param name="dingDanStatus">状态</param>
        /// <returns></returns>
        int SheZhiDingDanStatus(string dingDanId, string xiaDanRenId, EyouSoft.Model.Enum.XianLuStructure.OrderStatus dingDanStatus);
        /// <summary>
        /// 设置付款状态，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="xiaDanRenId">下单人编号</param>
        /// <param name="fuKuanStatus">状态</param>
        /// <param name="fuKuanTime">付款时间</param>
        /// <returns></returns>
        int SheZhiFuKuanStatus(string dingDanId, string xiaDanRenId, EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus fuKuanStatus, DateTime fuKuanTime);
        /// <summary>
        /// 支付完成执行方法
        /// </summary>
        /// <param name="info">订单</param>
        /// <returns></returns>
        int SheZhiZhiFus(EyouSoft.Model.QianZhengStructure.MQianZhengDingDanInfo info);
        /// <summary>
        /// 根据订单状态获取订单数量
        /// </summary>
        /// <param name="Status">订单状态</param>
        /// <returns></returns>
        int GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus Status);
    }
}
