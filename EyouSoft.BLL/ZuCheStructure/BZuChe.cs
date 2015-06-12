using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.ZuCheStructure;
using EyouSoft.Model.Enum.XianLuStructure;
using EyouSoft.Model.XianLuStructure;

namespace EyouSoft.BLL.ZuCheStructure
{
    public class BZuChe
    {
        private readonly EyouSoft.IDAL.ZuCheStructure.IZuChe dal = new EyouSoft.DAL.ZuCheStructure.DZuChe();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MZuCheInfo info)
        {
            if (info == null || info.OperatorId == 0) return false;
            info.ZuCheID = Guid.NewGuid().ToString();
            info.IssueTime = DateTime.Now;
            info.LatestId = info.OperatorId;
            info.LatestTime = info.IssueTime;
            info.State = EyouSoft.Model.Enum.ZuCheStates.启用;
            return dal.Add(info) > 0 ? true : false;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MZuCheInfo model)
        {
            if (string.IsNullOrEmpty(model.ZuCheID)) return false;
            model.LatestId = model.OperatorId;
            model.LatestTime = model.IssueTime;
            return dal.Update(model) > 0 ? true : false;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="LinkID"></param>
        /// <returns></returns>
        public bool Delete(string ZuCheID)
        {
            if (string.IsNullOrEmpty(ZuCheID)) return false;
            return dal.Delete(ZuCheID) > 0 ? true : false;
        }
        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public IList<MZuCheInfo> GetList(int PageSize, int PageIndex, ref int RecordCount, MZuCheInfoChaXun ChaXun)
        {
            return dal.GetList(PageSize, PageIndex, ref RecordCount, ChaXun);
        }
         /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MZuCheInfo GetModel(string ZuCheID)
        {
            if (string.IsNullOrEmpty(ZuCheID)) return null;
            return dal.GetModel(ZuCheID);
        }

        /// <summary>
        /// 更改状态
        /// </summary>
        /// <param name="ZuCheID"></param>
        /// <param name="en"></param>
        /// <returns></returns>
        public bool updageState(string ZuCheID, EyouSoft.Model.Enum.ZuCheStates en)
        {
            if (string.IsNullOrEmpty(ZuCheID) && en == null) return false;
            return dal.updageState(ZuCheID, en) > 0 ? true : false;
        }
        /// <summary>
        /// 设置首页显示
        /// </summary>
        /// <param name="ZuCheID"></param>
        /// <param name="isbool"></param>
        /// <returns></returns>
        public bool updageIsIndex(string ZuCheID,XianLuZT isbool)
        {
            if (string.IsNullOrEmpty(ZuCheID) && isbool == null) return false;
            return dal.updageIsIndex(ZuCheID, isbool) > 0 ? true : false;
        }
         /// <summary>
        /// 获得前几条数据列表集合
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        public IList<MZuCheInfo> GetList(int Top, MZuCheInfoChaXun chaXun)
        {
            if (Top < 1) Top = 1;
            return dal.GetList(Top, chaXun);
        }
        /// <summary>
        /// 设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="memberId">会员编号</param>
        /// <param name="status">状态</param>
        /// <param name="history">订单变更记录信息</param>
        /// <returns></returns>
        public int SheZhiOrderStatus(string orderId, OrderStatus status)
        {
            if (string.IsNullOrEmpty(orderId)) return 0;

            int dalRetCode = dal.SheZhiOrderStatus(orderId, status);

            return dalRetCode;
        }
    }
}
