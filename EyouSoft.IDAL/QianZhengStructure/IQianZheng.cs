//签证信息接口 汪奇志 2013-11-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.Enum.XianLuStructure;

namespace EyouSoft.IDAL.QianZhengStructure
{
    /// <summary>
    /// 签证信息接口
    /// </summary>
    public interface IQianZheng
    {        
        /// <summary>
        /// 写入签证信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Insert(EyouSoft.Model.QianZhengStructure.MQianZhengInfo info);
        /// <summary>
        /// 更新签证信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int Update(EyouSoft.Model.QianZhengStructure.MQianZhengInfo info);
        /// <summary>
        /// 删除签证信息，返回1成功，其它失败
        /// </summary>
        /// <param name="qianZhengId">签证编号</param>
        /// <param name="faBuRenId">发布人编号</param>
        /// <returns></returns>
        int Delete(string qianZhengId, int faBuRenId);
        /// <summary>
        /// 获取签证信息业务实体
        /// </summary>
        /// <param name="qianZhengId">签证编号</param>
        /// <returns></returns>
        EyouSoft.Model.QianZhengStructure.MQianZhengInfo GetInfo(string qianZhengId);
        /// <summary>
        /// 获取签证信息集合
        /// </summary>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询信息</param>
        /// <returns></returns>
        IList<EyouSoft.Model.QianZhengStructure.MQianZhengInfo> GetQianZhengs(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.QianZhengStructure.MQianZhengChaXunInfo chaXun);
        /// <summary>
        /// 根据条件获取前几条数据
        /// </summary>
        /// <param name="top">数据量</param>
        /// <param name="chaXun">条件</param>
        /// <returns></returns>
        IList<EyouSoft.Model.QianZhengStructure.MQianZhengInfo> GetTopQianZheng(int top, EyouSoft.Model.QianZhengStructure.MQianZhengChaXunInfo chaXun);

        /// <summary>
        /// 获取签证下订单数
        /// </summary>
        /// <param name="qianZhengId">签证编号</param>
        /// <returns></returns>
        int GetDingDanShu(string qianZhengId);
        /// <summary>
        /// 更新订单状态
        /// </summary>
        /// <param name="orderId">订单id</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        int SheZhiOrderStatus(string orderId, OrderStatus status);
        /// <summary>
        /// 修改状态
        /// </summary>
        int UpdateState(string Id, EyouSoft.Model.Enum.XianLuStructure.XianLuZT state);
    }
}
