using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.OtherStructure;
using EyouSoft.Model.Enum;

namespace EyouSoft.BLL.OtherStructure
{
    public class BJiFen
    {
        private readonly EyouSoft.IDAL.OtherStructure.IJiFen dal = new EyouSoft.DAL.OtherStructure.DJiFen();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        public bool Add(MJiFen model)
        {
            return dal.Add(model) == 0 ? false : true;
        }
        /// <summary>
        /// 累计兑换的积分总值
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        public int GetSumJiFen(string memberID,JiFenDuiHuanStatus DHStatus)
        {
            if (string.IsNullOrEmpty(memberID)) return 0;
            return dal.GetSumJiFen(memberID, DHStatus);
        }
        /// <summary>
        /// 分页获取积分兑换记录
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public IList<MJiFen> GetList(int pageSize, int pageIndex, ref int RecordCount, MJiFenSer search)
        {
            return dal.GetList(pageSize, pageIndex, ref RecordCount, search);
        }
        /// <summary>
        /// 设置审核状态，返回1成功，其它失败
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int SheZhiStatus(string orderId, EyouSoft.Model.Enum.JiFenDuiHuanStatus status)
        {
            if (string.IsNullOrEmpty(orderId)) return 0;

            int dalRetCode = dal.SheZhiStatus(orderId, status);

            return dalRetCode;
        }
    }
}
