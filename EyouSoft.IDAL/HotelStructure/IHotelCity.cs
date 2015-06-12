using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.HotelStructure;
namespace EyouSoft.IDAL.HotelStructure
{
    public interface IHotelCity
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(MHotelCity model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(MHotelCity model);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool Delete(params int[] Ids);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        MHotelCity GetModel(int ID);
        /// <summary>
        /// 获得数据列表集合，分页
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        IList<MHotelCity> GetList(int PageSize, int PageIndex, ref int RecordCount);
        /// <summary>
        /// 获得前几行数据集合
        /// </summary>
        /// <param name="Top"></param>
        /// <returns></returns>
        IList<MHotelCity> GetList(int Top);
        /// <summary>
        /// 获得城市三字码
        /// </summary>
        IList<MHotelCityAreas> GetCitySZMList(string ProviceName);
        /// <summary>
        /// 根据三字码获得省份
        /// </summary>
        IList<MHotelCityAreas> GetHoteCityList(string SZM);
        
    }
}
