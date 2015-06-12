using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit.DAL;
using EyouSoft.Toolkit;
using EyouSoft.IDAL.OtherStructure;

namespace EyouSoft.DAL.OtherStructure
{
    /// <summary>
    /// 地标
    /// </summary>
    public class DDiBiao : DALBase, IDiBiao
    {
        #region static constants
        //static constants
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DDiBiao()
        {
            _db = SystemStore;
        }
        #endregion

        #region IDiBiao 成员
        
        /// <summary>
        /// 获取城市三字码
        /// </summary>
        /// <returns></returns>
        public IList<EyouSoft.Model.HotelStructure.MHotelCity> GetCityCode()
        {
            IList<EyouSoft.Model.HotelStructure.MHotelCity> list = new List<EyouSoft.Model.HotelStructure.MHotelCity>();
             string sql = "select * from Hotel_City";
                DbCommand cmd = _db.GetSqlStringCommand(sql);
                using (IDataReader dr = DbHelper.ExecuteReader(cmd, _db))
                {
                    while (dr.Read())
                    {
                        EyouSoft.Model.HotelStructure.MHotelCity model = new EyouSoft.Model.HotelStructure.MHotelCity();
                        model.CityCode = dr.GetString(dr.GetOrdinal("CITY_CODE"));
                        list.Add(model);
                    }

                    return list;
                }
        }
        /// <summary>
        /// 增加地标
        /// </summary>
        /// <param name="model"></param>
        public void AddLandMark(EyouSoft.Model.OtherStructure.MLandMark model)
        {

            DbCommand cmd = _db.GetStoredProcCommand("proc_LandMark_ADD");
            _db.AddInParameter(cmd, "AreaCode", DbType.String, model.AreaCode);
            _db.AddInParameter(cmd, "AreaName", DbType.String, model.AreaName);
            _db.AddInParameter(cmd, "AreaPinyin", DbType.String, model.AreaPinyin);
            _db.AddInParameter(cmd, "CityCode", DbType.String, model.CityCode);
            _db.AddInParameter(cmd, "CityName", DbType.String, model.CityName);
            _db.AddInParameter(cmd, "LandMarkChildCode", DbType.String, model.LandMarkChildCode);
            _db.AddInParameter(cmd, "LandMarkChildName", DbType.String, model.LandMarkChildName);
            _db.AddInParameter(cmd, "LandMarkChildPinYin", DbType.String, model.LandMarkChildPinYin);
            _db.AddInParameter(cmd, "LandMarkName", DbType.String, model.LandMarkName);
            _db.AddInParameter(cmd, "Latitude", DbType.String, model.Latitude);
            _db.AddInParameter(cmd, "Longitude", DbType.String, model.Longitude);
            _db.AddInParameter(cmd, "MercatorX", DbType.String, model.MercatorX);
            _db.AddInParameter(cmd, "MercatorY", DbType.String, model.MercatorY);
            _db.AddInParameter(cmd, "ProviceName", DbType.String, model.ProviceName);
            DbHelper.RunProcedure(cmd, _db);
        }
        /// <summary>
        /// 根据城市三字码获取一级地标
        /// </summary>
        /// <param name="CityCode">城市三字码</param>
        /// <returns></returns>
        public IList<Model.OtherStructure.MLandMark> GetAreaName(string CityCode)
        {
            IList<Model.OtherStructure.MLandMark> list = new List<Model.OtherStructure.MLandMark>();

            string sql = "select DISTINCT CityCode,AreaCode,AreaName,CityName from    tbl_HotelLandMarks WHERE  CityCode = '" + CityCode + "' and AreaName<>'行政区'";
            DbCommand cmd = _db.GetSqlStringCommand(sql);
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (dr.Read())
                {
                    Model.OtherStructure.MLandMark model = new Model.OtherStructure.MLandMark();
                    model.CityCode = dr.GetString(dr.GetOrdinal("CityCode"));
                    model.AreaCode = dr.GetString(dr.GetOrdinal("AreaCode"));
                    model.AreaName = dr.GetString(dr.GetOrdinal("AreaName"));
                    model.CityName = dr.GetString(dr.GetOrdinal("CityName"));
                    list.Add(model);
                }
            }
            return list;
        }
        /// <summary>
        /// 根据城市三字码和一级地标获取二级地标
        /// </summary>
        /// <param name="CityCode">城市三字码</param>
        /// <param name="AreaCode">一级地标</param>
        /// <returns></returns>
        public IList<Model.OtherStructure.MLandMark> GetLandMarkName(string CityCode, string AreaCode)
        {
            IList<Model.OtherStructure.MLandMark> list = new List<Model.OtherStructure.MLandMark>();

            string sql = "select DISTINCT LandMarkName from  tbl_HotelLandMarks where citycode='" + CityCode + "' and Areacode='" + AreaCode + "'";
            DbCommand cmd = _db.GetSqlStringCommand(sql);
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (dr.Read())
                {
                    Model.OtherStructure.MLandMark model = new Model.OtherStructure.MLandMark();
                    model.LandMarkName = dr.GetString(dr.GetOrdinal("LandMarkName"));
                    list.Add(model);
                }
            }
            return list;
        }
        /// <summary>
        /// 根据城市三字码和一级地标二级地标获取三级级地标
        /// </summary>
        /// <param name="CityCode">城市三字码</param>
        /// <param name="AreaCode">一级地标</param>
        /// <param name="LandMarkName">二级地标</param>
        /// <returns></returns>
        public IList<Model.OtherStructure.MLandMark> GetLandChildName(string CityCode, string AreaCode,string LandMarkName)
        {
            IList<Model.OtherStructure.MLandMark> list = new List<Model.OtherStructure.MLandMark>();

            string sql = "select ID,LandMarkChildName from  tbl_HotelLandMarks where citycode='" + CityCode + "' and areacode='" + AreaCode + "'";
            if (!string.IsNullOrEmpty(LandMarkName))
            {
                sql += " and LandMarkName='"+LandMarkName+"'";
            }
            DbCommand cmd = _db.GetSqlStringCommand(sql);
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (dr.Read())
                {
                    Model.OtherStructure.MLandMark model = new Model.OtherStructure.MLandMark();
                    model.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    model.LandMarkChildName = dr.GetString(dr.GetOrdinal("LandMarkChildName"));
                    list.Add(model);
                }
            }
            return list;
        }
        /// <summary>
        /// 获取地标经纬度
        /// </summary>
        /// <param name="ID">地标id</param>
        /// <returns></returns>
        public IList<Model.OtherStructure.MLandMark> GetLandMark(int ID)
        {
            IList<Model.OtherStructure.MLandMark> list = new List<Model.OtherStructure.MLandMark>();

            string sql = "select * from  tbl_HotelLandMarks where ID=" + ID ;
            DbCommand cmd = _db.GetSqlStringCommand(sql);
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (dr.Read())
                {
                    Model.OtherStructure.MLandMark model = new Model.OtherStructure.MLandMark();
                    model.Latitude = dr.GetString(dr.GetOrdinal("Latitude"));
                    model.Longitude = dr.GetString(dr.GetOrdinal("Longitude"));
                    list.Add(model);
                }
            }
            return list;
        }
        #endregion
    }
}
