using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.ZuCheStructure;
using EyouSoft.Model.Enum.XianLuStructure;

namespace EyouSoft.IDAL.ZuCheStructure
{
    public interface IZuChe
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(MZuCheInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(MZuCheInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(string ZuCheID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        MZuCheInfo GetModel(string ZuCheID);
        /// <summary>
        /// 获得数据列表集合，分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        IList<MZuCheInfo> GetList(int pageSize, int pageIndex, ref int recordCount, MZuCheInfoChaXun chaXun);

        /// <summary>
        /// 更改状态
        /// </summary>
        /// <param name="ZuCheID"></param>
        /// <param name="en"></param>
        /// <returns></returns>
        int updageState(string ZuCheID, EyouSoft.Model.Enum.ZuCheStates en);
        /// <summary>
        /// 设置首页显示
        /// </summary>
        /// <param name="ZuCheID"></param>
        /// <param name="isbool"></param>
        /// <returns></returns>
        int updageIsIndex(string ZuCheID, XianLuZT isbool);
        /// <summary>
        /// 获得前几条数据列表集合
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        IList<MZuCheInfo> GetList(int Top, MZuCheInfoChaXun chaXun);
        /// <summary>
        /// 更新订单状态
        /// </summary>
        /// <param name="orderId">订单id</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        int SheZhiOrderStatus(string orderId, OrderStatus status);
    }
}
