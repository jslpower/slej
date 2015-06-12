using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.HotelStructure
{
    public class BHotelRoomType
    {
        EyouSoft.IDAL.HotelStructure.IHotelRoomType dal = new EyouSoft.DAL.HotelStructure.DHotelRoomType();

        #region 房型

        /// <summary>
        /// 添加酒店房型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddHotelRoomType(EyouSoft.Model.HotelStructure.MHotelRoomType model)
        {
            if (string.IsNullOrEmpty(model.HotelId)) return false;

            model.RoomTypeId = Guid.NewGuid().ToString();

            return dal.AddHotelRoomType(model);
        }

        /// <summary>
        /// 修改酒店房型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateHotelRoomType(EyouSoft.Model.HotelStructure.MHotelRoomType model)
        {

            if (string.IsNullOrEmpty(model.HotelId) || string.IsNullOrEmpty(model.RoomTypeId)) return false;
            return dal.UpdateHotelRoomType(model);

        }

        /// <summary>
        /// 修改房型的状态
        /// </summary>
        /// <param name="RoomTypeId"></param>
        /// <returns></returns>
        public bool UpdateHotelRoomType(string RoomTypeId, EyouSoft.Model.Enum.RoomStatus? RoomStatus)
        {
            if (string.IsNullOrEmpty(RoomTypeId) || !RoomStatus.HasValue) return false;

            return dal.UpdateHotelRoomType(RoomTypeId, RoomStatus.Value);
        }

        /// <summary>
        /// 删除房型
        /// </summary>
        /// <param name="RoomTypeId"></param>
        /// <returns>
        ///  -1:房型存在订单不允许删除
        ///   1:成功
        ///	  0:失败
        /// </returns>
        public int DeleteHotelRoomType(string RoomTypeId)
        {
            if (string.IsNullOrEmpty(RoomTypeId)) return 0;
            return dal.DeleteHotelRoomType(RoomTypeId);
        }

        /// <summary>
        /// 根据房型的编码获取实体
        /// </summary>
        /// <param name="RoomTypeId"></param>
        /// <returns></returns>
        public EyouSoft.Model.HotelStructure.MHotelRoomType GetHotelRoomTypeModel(string RoomTypeId)
        {
            if (string.IsNullOrEmpty(RoomTypeId)) return null;

            return dal.GetHotelRoomTypeModel(RoomTypeId);

        }

        /// <summary>
        /// 根据酒店编号获取酒店房型
        /// </summary>
        /// <param name="HotelId"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.HotelStructure.MHotelRoomType> GetHotelRoomTypeListByHotelId(string HotelId) {
            if (string.IsNullOrEmpty(HotelId)) return null;
            return dal.GetHotelRoomTypeListByHotelId(HotelId);
        }

        /// <summary>
        /// 获取酒店房型的分页列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.HotelStructure.MHotelRoomType> GetHotelRoomTypeList(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.HotelStructure.MHotelRoomTypeSearch search)
        {
            return dal.GetHotelRoomTypeList(pageSize, pageIndex, ref recordCount, search);
        }

        /// <summary>
        /// 根据酒店编号获取酒店房型
        /// </summary>
        /// <param name="search"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public IList<Model.HotelStructure.MHotelRoomType> GetHotelRoomTypeListByHotelId(int top,
            Model.HotelStructure.MHotelRoomTypeSearch search)
        {
            return dal.GetHotelRoomTypeListByHotelId(top, search);
        }


        #endregion

        #region 房型价格

        /// <summary>
        /// 添加房型价格
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// -1:开始时间已存在价格
        /// -2:结束时间已存在价格
        ///  1:成功
        ///  0:失败
        /// </returns>
        public int AddHotelRoomRate(EyouSoft.Model.HotelStructure.MHotelRoomRate model)
        {
            if (string.IsNullOrEmpty(model.HotelId) || string.IsNullOrEmpty(model.RoomTypeId)) return 0;
            return dal.AddHotelRoomRate(model);
        }

        /// <summary>
        /// 修改房型价格
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// -1:开始时间已存在价格
        /// -2:结束时间已存在价格
        /// -3:存在订单不允许修改
        ///  1:成功
        ///  0:失败
        /// </returns>
        public int UpdateHotelRoomRate(EyouSoft.Model.HotelStructure.MHotelRoomRate model)
        {
            if (model.RoomRateId == 0 || string.IsNullOrEmpty(model.HotelId) || string.IsNullOrEmpty(model.RoomTypeId)) return 0;
            return dal.UpdateHotelRoomRate(model);
        }

        /// <summary>
        /// 删除房型价格
        /// </summary>
        /// <param name="RoomRateId"></param>
        /// <returns>
        /// -1:存在订单不允许修改
        ///  1:成功
        ///  0:失败
        /// </returns>
        public int DeleteHotelRoomRate(int RoomRateId)
        {
            if (RoomRateId == 0) return 0;
            return dal.DeleteHotelRoomRate(RoomRateId);
        }

        /// <summary>
        /// 获取房型价格的实体
        /// </summary>
        /// <param name="RoomRateId"></param>
        /// <returns></returns>
        public EyouSoft.Model.HotelStructure.MHotelRoomRate GetHotelRoomRateModel(string RoomRateId)
        {
            if (string.IsNullOrEmpty(RoomRateId)) return null;
            return dal.GetHotelRoomRateModel(RoomRateId);
        }


        /// <summary>
        /// 根据房型编号获取房型的价格
        /// </summary>
        /// <param name="RoomTypeId"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.HotelStructure.MHotelRoomRate> GetHotelRoomRateList(string HotelId, string RoomTypeId)
        {
            if (string.IsNullOrEmpty(RoomTypeId)) return null;
            return dal.GetHotelRoomRateList(HotelId, RoomTypeId);
        }

        /// <summary>
        /// 获取价格的分页列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.HotelStructure.MHotelRoomRate> GetHotelRoomRateList(int pageSize, int pageIndex, ref int RecordCount, EyouSoft.Model.HotelStructure.MHotelRoomRateSearch search)
        {
            return dal.GetHotelRoomRateList(pageSize, pageIndex, ref  RecordCount, search);
        }


        #endregion
    }
}
