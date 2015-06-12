using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.OtherStructure;

namespace EyouSoft.IDAL.OtherStructure
{
    public interface IDingDan
    {
        /// <summary>
        /// 获取订单集合
        /// </summary>
        /// <param name="pageSize">页面显示几条记录</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="recordCount">总数</param>
        /// <param name="chaXun">查询集合</param>
        /// <returns></returns>
        IList<MDingDan> GetOrders(int pageSize, int pageIndex, ref int recordCount, MSearchDingDan chaXun);

        /// <summary>
        /// 查询实体
        /// </summary>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        MDingDan GetOrderByCodeOrID(MSearchDingDan chaXun);
    }
}
