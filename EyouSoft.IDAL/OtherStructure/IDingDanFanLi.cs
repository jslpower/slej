//订单返利信息interface 汪奇志 2014-11-06
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.OtherStructure
{
    public interface IDingDanFanLi
    {
        /// <summary>
        /// 订单返利信息新增，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        int DingDanFanLi_C(EyouSoft.Model.OtherStructure.MDingDanFanLiInfo info);
        /// <summary>
        /// 获取订单返利信息集合
        /// </summary>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        IList<EyouSoft.Model.OtherStructure.MDingDanFanLiInfo> GetDingDanFanLis(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.OtherStructure.MDingDanFanLiChaXunInfo chaXun);
    }
}
