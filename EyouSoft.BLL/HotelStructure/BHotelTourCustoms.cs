using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.HotelStructure;
using EyouSoft.Toolkit;
namespace EyouSoft.BLL.HotelStructure
{
    
    public class BHotelTourCustoms
    {
        private readonly EyouSoft.IDAL.HotelStructure.IHotelTourCustoms dal = new EyouSoft.DAL.HotelStructure.DHotelTourCustoms();

        #region 酒店团队定制
        /// <summary>
        /// 增加一条酒店团队定制数据
        /// </summary>
        /// <param name="model"></param>
        public bool Add(MHotelTourCustoms model)
        {
            if (model != null && !string.IsNullOrEmpty(model.ContacterName) && !string.IsNullOrEmpty(model.ContacterMobile) && !string.IsNullOrEmpty(model.HotelId)
                    && !string.IsNullOrEmpty(model.HotelCode) && !string.IsNullOrEmpty(model.HotelName) && (int)model.HotelStar > 0
                    && (int)model.Payment > 0 && (int)model.GuestType > 0 && (int)model.TourType > 0 && (int)model.TreatState > 0 && (int)model.Source > 0)
            {
                return dal.Add(model);
            }
            return false;
        }

        /// <summary>
        /// 更新一条酒店团队定制数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(MHotelTourCustoms model)
        {
            if (model != null && model.Id > 0 && !string.IsNullOrEmpty(model.ContacterName) && !string.IsNullOrEmpty(model.ContacterMobile) && !string.IsNullOrEmpty(model.HotelId)
                    && !string.IsNullOrEmpty(model.HotelCode) && !string.IsNullOrEmpty(model.HotelName) && (int)model.HotelStar > 0
                    && (int)model.Payment > 0 && (int)model.GuestType > 0 && (int)model.TourType > 0 && (int)model.TreatState > 0 && (int)model.Source > 0)
            {
                return dal.Update(model);
            }
            return false;
        }

        /// <summary>
        /// 批量删除酒店团队定制
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool Delete(params int[] Ids)
        {
            if (Ids != null && Ids.Length > 0)
                return dal.Delete(Ids);
            return false;
        }

        /// <summary>
        /// 得到一个酒店团队定制对象实体
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        public MHotelTourCustoms GetModel(int Id)
        {
            if (Id > 0)
                return dal.GetModel(Id);
            return null;
        }

        /// <summary>
        /// 获得酒店团队定制数据列表集合，分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="Seach"></param>
        /// <returns></returns>
        public IList<MHotelTourCustoms> GetList(int PageSize, int PageIndex, ref int RecordCount, MHotelTourCustomsSeach Seach)
        {
            if (!Utils.ValidPaging(PageSize, PageIndex))
                return null;
            return dal.GetList(PageSize, PageIndex, ref RecordCount, Seach);
        }

        /// <summary>
        /// 获得酒店团队定制前几行数据(top<=0获取所有数据)
        /// </summary>
        public IList<MHotelTourCustoms> GetList(int Top, MHotelTourCustomsSeach Seach)
        {
            return dal.GetList((Top < 0 ? 0 : Top), Seach);
        }

        #endregion

        #region 酒店团队订单回复
        /// <summary>
        /// 增加一条酒店团队订单回复数据
        /// </summary>
        /// <param name="model"></param>
        public bool AddAsk(MHotelTourCustomsAsk model)
        {
            if (model != null && model.TourOrderID > 0 && !string.IsNullOrEmpty(model.AskName))
                return dal.AddAsk(model);
            return false;
        }

        /// <summary>
        /// 更新一条酒店团队订单回复数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateAsk(MHotelTourCustomsAsk model)
        {
            if (model != null && model.ID > 0 && model.TourOrderID > 0 && !string.IsNullOrEmpty(model.AskName))
                return dal.UpdateAsk(model);
            return false;
        }

        /// <summary>
        /// 批量删除酒店团队订单回复
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool DeleteAsk(params int[] Ids)
        {
            if (Ids != null && Ids.Length > 0)
                return dal.DeleteAsk(Ids);
            return false;
        }

        /// <summary>
        /// 根据团队定制编号删除酒店团队订单回复
        /// </summary>
        /// <param name="TourOrderID"></param>
        /// <returns></returns>
        public bool DeleteAsk(int TourOrderID)
        {
            if (TourOrderID > 0)
                return dal.DeleteAsk(TourOrderID);
            return false;
        }

        /// <summary>
        /// 得到一个对象酒店团队订单回复实体
        /// </summary>
        /// <param name="LinkID"></param>
        /// <returns></returns>
        public MHotelTourCustomsAsk GetModelAsk(int ID)
        {
            if (ID > 0)
                return dal.GetModelAsk(ID);
            return null;
        }

        /// <summary>
        /// 获得酒店团队订单回复分页数据列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="TourOrderID">团队定制编号</param>
        /// <returns></returns>
        public IList<MHotelTourCustomsAsk> GetListAsk(int PageSize, int PageIndex, ref int RecordCount, int TourOrderID)
        {
            if (!Utils.ValidPaging(PageSize, PageIndex))
                return null;
            return dal.GetListAsk(PageSize, PageIndex, ref RecordCount, TourOrderID);
        }


        /// <summary>
        /// 获得酒店团队订单回复前几行数据(top<=0取所有数据)
        /// </summary>
        /// <param name="TourOrderID">团队定制编号</param>
        public IList<MHotelTourCustomsAsk> GetListAsk(int Top, int TourOrderID)
        {
            return dal.GetListAsk((Top < 0 ? 0 : Top), TourOrderID);
        }

        #endregion
    }
}
