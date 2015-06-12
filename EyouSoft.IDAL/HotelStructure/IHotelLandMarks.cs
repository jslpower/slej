using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.HotelStructure;
namespace EyouSoft.IDAL.HotelStructure
{
    public interface IHotelLandMarks
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(MHotelLandMarks model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(MHotelLandMarks model);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool Delete(params int[] Ids);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        MHotelLandMarks GetModel(int Id);
        /// <summary>
        /// 获得数据列表集合，分页
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        IList<MHotelLandMarks> GetList(int PageSize, int PageIndex, ref int RecordCount);
        /// <summary>
        /// 获得前几行数据集合
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="CityCode"></param>
        /// <returns></returns>
        IList<MHotelLandMarks> GetList(int Top, string CityCode);
    }
}
