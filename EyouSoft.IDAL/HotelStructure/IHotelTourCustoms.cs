using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.HotelStructure;
namespace EyouSoft.IDAL.HotelStructure
{
    public interface IHotelTourCustoms
    {
        #region 酒店团队定制
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(MHotelTourCustoms model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(MHotelTourCustoms model);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool Delete(params int[] Ids);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        MHotelTourCustoms GetModel(int Id);
        /// <summary>
        /// 获得数据列表集合，分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="Seach"></param>
        /// <returns></returns>
        IList<MHotelTourCustoms> GetList(int pageSize, int pageIndex, ref int recordCount, MHotelTourCustomsSeach Seach);
        /// <summary>
        /// 获得前几行数据集合
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="Seach"></param>
        /// <returns></returns>
        IList<MHotelTourCustoms> GetList(int Top, MHotelTourCustomsSeach Seach);

        /// <summary>
        /// 修改处理状态
        /// </summary>
        /// <param name="TreatState"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool UpdateTreatState(EyouSoft.Model.Enum.TreatState TreatState, params int[] Ids);

        #endregion

        #region 酒店团队订单回复
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        bool AddAsk(MHotelTourCustomsAsk model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdateAsk(MHotelTourCustomsAsk model);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool DeleteAsk(params int[] Ids);

        /// <summary>
        /// 根据团队定制编号删除
        /// </summary>
        /// <param name="TourOrderID"></param>
        /// <returns></returns>
        bool DeleteAsk(int TourOrderID);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="LinkID"></param>
        /// <returns></returns>
        MHotelTourCustomsAsk GetModelAsk(int ID);

        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="TourOrderID">团队定制编号</param>
        /// <returns></returns>
        IList<MHotelTourCustomsAsk> GetListAsk(int PageSize, int PageIndex, ref int RecordCount,int TourOrderID);

        /// <summary>
        /// 获得前几行数据(top<=0取所有数据)
        /// </summary>
        /// <param name="TourOrderID">团队定制编号</param>
        IList<MHotelTourCustomsAsk> GetListAsk(int Top, int TourOrderID);

        #endregion
    }
}
