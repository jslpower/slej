using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.OtherStructure;
using EyouSoft.Toolkit;

namespace EyouSoft.BLL.OtherStructure
{
    public class BDingDan
    {
        private readonly EyouSoft.IDAL.OtherStructure.IDingDan dal = new EyouSoft.DAL.OtherStructure.DDingDan();

        public BDingDan()
        {

        }
        /// <summary>
        /// 获取订单集合
        /// </summary>
        /// <param name="pageSize">页面显示几条记录</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="recordCount">总数</param>
        /// <param name="chaXun">查询集合</param>
        /// <returns></returns>
        public IList<MDingDan> GetOrders(int pageSize, int pageIndex, ref int recordCount, MSearchDingDan chaXun)
        {
            if (!Utils.ValidPaging(pageSize, pageIndex)) return null;

            return dal.GetOrders(pageSize, pageIndex, ref recordCount, chaXun);
        }
        /// <summary>
        /// 查询实体
        /// </summary>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        public MDingDan GetOrderByCodeOrID(MSearchDingDan chaXun)
        {
            return dal.GetOrderByCodeOrID(chaXun);
        }
    }
}
