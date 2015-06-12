using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.IDAL.OtherStructure
{
    /// <summary>
    /// 地标
    /// </summary>
    public interface IDiBiao
    {
        
        /// <summary>
        /// 获取城市三字码
        /// </summary>
        /// <returns></returns>
        IList<EyouSoft.Model.HotelStructure.MHotelCity> GetCityCode();
        /// <summary>
        /// 增加地标
        /// </summary>
        /// <param name="model"></param>
        void AddLandMark(EyouSoft.Model.OtherStructure.MLandMark model);
        /// <summary>
        /// 根据城市三字码获取一级地标
        /// </summary>
        /// <param name="CityCode">城市三字码</param>
        /// <returns></returns>
        IList<Model.OtherStructure.MLandMark> GetAreaName(string CityCode);
        /// <summary>
        /// 根据城市三字码和一级地标获取二级地标
        /// </summary>
        /// <param name="CityCode">城市三字码</param>
        /// <param name="AreaCode">一级地标</param>
        /// <returns></returns>
        IList<Model.OtherStructure.MLandMark> GetLandMarkName(string CityCode, string AreaCode);
        /// <summary>
        /// 根据城市三字码和一级地标二级地标获取三级级地标
        /// </summary>
        /// <param name="CityCode">城市三字码</param>
        /// <param name="AreaCode">一级地标</param>
        /// <param name="LandMarkName">二级地标</param>
        /// <returns></returns>
        IList<Model.OtherStructure.MLandMark> GetLandChildName(string CityCode, string AreaCode, string LandMarkName);
        /// <summary>
        /// 获取地标经纬度
        /// </summary>
        /// <param name="ID">地标id</param>
        /// <returns></returns>
        IList<Model.OtherStructure.MLandMark> GetLandMark(int ID);
    }
}
