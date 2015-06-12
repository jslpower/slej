using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EyouSoft.BLL.OtherStructure
{
    /// <summary>
    /// 地标
    /// </summary>
    public class BDiBiao
    {
        private readonly EyouSoft.IDAL.OtherStructure.IDiBiao dal = new EyouSoft.DAL.OtherStructure.DDiBiao();

        #region constructure
        /// <summary>
        /// default constructor
        /// </summary>
        public BDiBiao() { }
        #endregion

        #region public members
       
        /// <summary>
        /// 获取城市三字码
        /// </summary>
        /// <returns></returns>
        public IList<EyouSoft.Model.HotelStructure.MHotelCity> GetCityCode()
        {
            return dal.GetCityCode();
        }
        /// <summary>
        /// 增加地标
        /// </summary>
        /// <param name="model"></param>
        public void AddLandMark(EyouSoft.Model.OtherStructure.MLandMark model)
        {
            dal.AddLandMark(model);
        }
        /// <summary>
        /// 根据城市三字码获取一级地标
        /// </summary>
        /// <param name="CityCode">城市三字码</param>
        /// <returns></returns>
        public IList<Model.OtherStructure.MLandMark> GetAreaName(string CityCode)
        {
            if (string.IsNullOrEmpty(CityCode)) return null;
            return dal.GetAreaName(CityCode);
        }
        /// <summary>
        /// 根据城市三字码和一级地标获取二级三级地标
        /// </summary>
        /// <param name="CityCode">城市三字码</param>
        /// <param name="AreaCode">一级地标</param>
        /// <returns></returns>
        public IList<Model.OtherStructure.MLandMark> GetLandMarkName(string CityCode, string AreaCode)
        {
            if (string.IsNullOrEmpty(CityCode)|| string.IsNullOrEmpty(AreaCode)) return null;
            return dal.GetLandMarkName(CityCode,AreaCode);
        }
        /// <summary>
        /// 根据城市三字码和一级地标二级地标获取三级级地标
        /// </summary>
        /// <param name="CityCode">城市三字码</param>
        /// <param name="AreaCode">一级地标</param>
        /// <param name="LandMarkName">二级地标</param>
        /// <returns></returns>
        public IList<Model.OtherStructure.MLandMark> GetLandChildName(string CityCode, string AreaCode, string LandMarkName)
        {
            if (string.IsNullOrEmpty(CityCode) || string.IsNullOrEmpty(AreaCode)) return null;
            return dal.GetLandChildName(CityCode, AreaCode, LandMarkName);
        }
        /// <summary>
        /// 获取地标经纬度
        /// </summary>
        /// <param name="ID">地标id</param>
        /// <returns></returns>
        public IList<Model.OtherStructure.MLandMark> GetLandMark(int ID)
        {
            if (ID==0) return null;
            return dal.GetLandMark(ID);
        }
        #endregion
    }
}
