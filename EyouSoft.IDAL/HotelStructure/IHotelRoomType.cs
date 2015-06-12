using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.HotelStructure
{
    public interface IHotelRoomType
    {


        /// <summary>
        /// 添加酒店房型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddHotelRoomType(EyouSoft.Model.HotelStructure.MHotelRoomType model);

        /// <summary>
        /// 修改酒店房型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdateHotelRoomType(EyouSoft.Model.HotelStructure.MHotelRoomType model);

        /// <summary>
        /// 修改房型的状态
        /// </summary>
        /// <param name="RoomTypeId"></param>
        /// <returns></returns>
        bool UpdateHotelRoomType(string RoomTypeId, EyouSoft.Model.Enum.RoomStatus RoomStatus);

        /// <summary>
        /// 删除房型
        /// </summary>
        /// <param name="RoomTypeId"></param>
        /// <returns>
        ///  -1:房型存在订单不允许删除
        ///   1:成功
        ///	  0:失败
        /// </returns>
        int DeleteHotelRoomType(string RoomTypeId);

        /// <summary>
        /// 根据酒店编号获取酒店房型
        /// </summary>
        /// <param name="HotelId"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.HotelStructure.MHotelRoomType> GetHotelRoomTypeListByHotelId(string HotelId);

        /// <summary>
        /// 根据房型的编码获取实体
        /// </summary>
        /// <param name="RoomTypeId"></param>
        /// <returns></returns>
        EyouSoft.Model.HotelStructure.MHotelRoomType GetHotelRoomTypeModel(string RoomTypeId);

        /// <summary>
        /// 获取酒店房型的分页列表
        /// </summary>
        /// <param name="pageSieze"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.HotelStructure.MHotelRoomType> GetHotelRoomTypeList(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.HotelStructure.MHotelRoomTypeSearch search);

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
        int AddHotelRoomRate(EyouSoft.Model.HotelStructure.MHotelRoomRate model);

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
        int UpdateHotelRoomRate(EyouSoft.Model.HotelStructure.MHotelRoomRate model);

        /// <summary>
        /// 删除房型价格
        /// </summary>
        /// <param name="RoomRateId"></param>
        /// <returns>
        ///  -1:存在订单不允许修改
        ///  1:成功
        ///  0:失败
        /// </returns>
        int DeleteHotelRoomRate(int RoomRateId);

        /// <summary>
        /// 获取房型价格的实体
        /// </summary>
        /// <param name="RoomRateId"></param>
        /// <returns></returns>
        EyouSoft.Model.HotelStructure.MHotelRoomRate GetHotelRoomRateModel(string RoomRateId);


        /// <summary>
        /// 根据房型编号获取房型的价格
        /// </summary>
        /// <param name="RoomTypeId"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.HotelStructure.MHotelRoomRate> GetHotelRoomRateList(string HotelId, string RoomTypeId);

        /// <summary>
        /// 获取价格的分页列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.HotelStructure.MHotelRoomRate> GetHotelRoomRateList(int pageSize, int pageIndex, ref int RecordCount, EyouSoft.Model.HotelStructure.MHotelRoomRateSearch search);

        /// <summary>
        /// 根据酒店编号获取酒店房型
        /// </summary>
        /// <param name="search"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        IList<Model.HotelStructure.MHotelRoomType> GetHotelRoomTypeListByHotelId(
            int top, Model.HotelStructure.MHotelRoomTypeSearch search);

    }
}
