using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.XianLuStructure;
using EyouSoft.Model.Enum.XianLuStructure;

namespace EyouSoft.IDAL.XianLuStructure
{
    public interface IZiZuTuan
    {
        /// <summary>
        /// 增加自组团
        /// </summary>
        /// <param name="model">数据集</param>
        /// <returns></returns>
        int Add(MZiZuTuan model);
        /// <summary>
        /// 增加自组团租车行程
        /// </summary>
        /// <param name="model">数据集</param>
        /// <returns></returns>
        void AddXC(MZiZuTuanXingCheng model);
        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.XianLuStructure.MZiZuTuan> GetList(int PageSize, int PageIndex, string OrderBy, ref int RecordCount,EyouSoft.Model.XianLuStructure.MZiZuTuanSer model);
         /// <summary>
        /// 获取提现信息业务实体
        /// </summary>
        /// <param name="tiXianId">提现编号</param>
        /// <returns></returns>
        MZiZuTuan GetInfo(string OrderId);
        /// <summary>
        /// 获取自组团租车行程
        /// </summary>
        /// <param name="orderid">自组团id</param>
        /// <returns></returns>
        IList<EyouSoft.Model.XianLuStructure.MZiZuTuanXingCheng> GetXCList(string orderid);
        /// <summary>
        /// 设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="memberId">会员编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        int SheZhiOrderStatus(string orderId, OrderStatus status);
        /// <summary>
        /// 支付完成执行方法
        /// </summary>
        /// <param name="info">订单</param>
        /// <returns></returns>
        int SheZhiZhiFus(MZiZuTuan info);
    }
}
