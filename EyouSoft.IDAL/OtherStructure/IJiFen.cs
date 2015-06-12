using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.OtherStructure;
using EyouSoft.Model.Enum;


namespace EyouSoft.IDAL.OtherStructure
{
    public interface IJiFen
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(MJiFen model);
        /// <summary>
        /// 累计兑换的积分总值
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        int GetSumJiFen(string memberID, JiFenDuiHuanStatus DHStatus);
        /// <summary>
        /// 分页获取积分兑换记录
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        IList<MJiFen> GetList(int pageSize, int pageIndex, ref int RecordCount, MJiFenSer search);
        /// <summary>
        /// 设置审核状态，返回1成功，其它失败
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        int SheZhiStatus(string orderId, EyouSoft.Model.Enum.JiFenDuiHuanStatus status);
    }
}
