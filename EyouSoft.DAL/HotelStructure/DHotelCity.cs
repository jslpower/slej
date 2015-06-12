using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.HotelStructure;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using EyouSoft.Toolkit;
using EyouSoft.Toolkit.DAL;
using System.Data;
namespace EyouSoft.DAL.HotelStructure
{
    public class DHotelCity : EyouSoft.Toolkit.DAL.DALBase, EyouSoft.IDAL.HotelStructure.IHotelCity
    {
        #region 初始化db
        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DHotelCity()
        {
            _db = base.SystemStore;
        }
        #endregion


        #region IHotelCity 成员

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        public bool Add(MHotelCity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbl_HotelCity(");
            strSql.Append("CityName,Spelling,SimpleSpelling,CityCode,IsHot");
            strSql.Append(") values (");
            strSql.Append("@CityName,@Spelling,@SimpleSpelling,@CityCode,@IsHot");
            strSql.Append(") ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "CityName", System.Data.DbType.String, model.CityName);
            this._db.AddInParameter(cmd, "Spelling", System.Data.DbType.String, model.Spelling);
            this._db.AddInParameter(cmd, "SimpleSpelling", System.Data.DbType.String, model.SimpleSpelling);
            this._db.AddInParameter(cmd, "CityCode", System.Data.DbType.AnsiString, model.CityCode);
            this._db.AddInParameter(cmd, "IsHot", System.Data.DbType.AnsiStringFixedLength, GetBooleanToStr(model.IsHot));
            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(MHotelCity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbl_HotelCity set ");
            strSql.Append(" CityName = @CityName , ");
            strSql.Append(" Spelling = @Spelling , ");
            strSql.Append(" SimpleSpelling = @SimpleSpelling ,  ");
            strSql.Append(" CityCode = @CityCode  , ");
            strSql.Append(" IsHot = @IsHot   ");
            strSql.Append(" where ID=@ID  ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "CityName", System.Data.DbType.String, model.CityName);
            this._db.AddInParameter(cmd, "Spelling", System.Data.DbType.String, model.Spelling);
            this._db.AddInParameter(cmd, "SimpleSpelling", System.Data.DbType.String, model.SimpleSpelling);
            this._db.AddInParameter(cmd, "CityCode", System.Data.DbType.AnsiString, model.CityCode);
            this._db.AddInParameter(cmd, "IsHot", System.Data.DbType.AnsiStringFixedLength, GetBooleanToStr(model.IsHot));
            this._db.AddInParameter(cmd, "ID", System.Data.DbType.Int32, model.ID);

            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool Delete(params int[] Ids)
        {
            StringBuilder sId = new StringBuilder();
            for (int i = 0; i < Ids.Length; i++)
            {
                sId.AppendFormat("{0},", Ids[i]);
            }
            sId.Remove(sId.Length - 1, 1);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbl_HotelCity where ID in (" + sId + ")");
            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            return DbHelper.ExecuteSql(dc, _db) > 0 ? true : false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="LinkID"></param>
        /// <returns></returns>
        public MHotelCity GetModel(int ID)
        {
            MHotelCity model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, CityName, Spelling, SimpleSpelling,CityCode,IsHot  ");
            strSql.Append("  from tbl_HotelCity ");
            strSql.Append(" where ID=@ID ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ID", System.Data.DbType.Int32, ID);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new MHotelCity();
                    model.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    model.CityName = !dr.IsDBNull(dr.GetOrdinal("CityName")) ? dr.GetString(dr.GetOrdinal("CityName")) : "";
                    model.Spelling = !dr.IsDBNull(dr.GetOrdinal("Spelling")) ? dr.GetString(dr.GetOrdinal("Spelling")) : "";
                    model.SimpleSpelling = !dr.IsDBNull(dr.GetOrdinal("SimpleSpelling")) ? dr.GetString(dr.GetOrdinal("SimpleSpelling")) : "";
                    model.CityCode = !dr.IsDBNull(dr.GetOrdinal("CityCode")) ? dr.GetString(dr.GetOrdinal("CityCode")) : "";
                    model.IsHot = this.GetBoolean(dr.IsDBNull(dr.GetOrdinal("IsHot")) ? "" : dr.GetString(dr.GetOrdinal("IsHot")));
                }
            }

            return model;
        }

        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public IList<MHotelCity> GetList(int PageSize, int PageIndex, ref int RecordCount)
        {
            IList<MHotelCity> list = new List<MHotelCity>();

            string tableName = "tbl_HotelCity";
            string fileds = "ID, CityName, Spelling, SimpleSpelling,CityCode,IsHot";
            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, null, "ID desc ", null))
            {
                while (dr.Read())
                {
                    MHotelCity model = new MHotelCity();
                    model.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    model.CityName = !dr.IsDBNull(dr.GetOrdinal("CityName")) ? dr.GetString(dr.GetOrdinal("CityName")) : "";
                    model.Spelling = !dr.IsDBNull(dr.GetOrdinal("Spelling")) ? dr.GetString(dr.GetOrdinal("Spelling")) : "";
                    model.SimpleSpelling = !dr.IsDBNull(dr.GetOrdinal("SimpleSpelling")) ? dr.GetString(dr.GetOrdinal("SimpleSpelling")) : "";
                    model.CityCode = !dr.IsDBNull(dr.GetOrdinal("CityCode")) ? dr.GetString(dr.GetOrdinal("CityCode")) : "";
                    model.IsHot = this.GetBoolean(dr.IsDBNull(dr.GetOrdinal("IsHot")) ? "" : dr.GetString(dr.GetOrdinal("IsHot")));
                    list.Add(model);
                }
            }

            return list;

        }


        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public IList<MHotelCity> GetList(int Top)
        {
            IList<MHotelCity> list = new List<MHotelCity>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID, CityName, Spelling, SimpleSpelling,CityCode,IsHot ");
            strSql.Append(" FROM tbl_HotelCity ");
            strSql.Append(" Order By ID desc ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    MHotelCity model = new MHotelCity();
                    model.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    model.CityName = !dr.IsDBNull(dr.GetOrdinal("CityName")) ? dr.GetString(dr.GetOrdinal("CityName")) : "";
                    model.Spelling = !dr.IsDBNull(dr.GetOrdinal("Spelling")) ? dr.GetString(dr.GetOrdinal("Spelling")) : "";
                    model.SimpleSpelling = !dr.IsDBNull(dr.GetOrdinal("SimpleSpelling")) ? dr.GetString(dr.GetOrdinal("SimpleSpelling")) : "";
                    model.CityCode = !dr.IsDBNull(dr.GetOrdinal("CityCode")) ? dr.GetString(dr.GetOrdinal("CityCode")) : "";
                    model.IsHot = this.GetBoolean(dr.IsDBNull(dr.GetOrdinal("IsHot")) ? "" : dr.GetString(dr.GetOrdinal("IsHot")));
                    list.Add(model);
                }
            }

            return list;

        }


        /// <summary>
        /// 获得城市三字码
        /// </summary>
        public IList<MHotelCityAreas> GetCitySZMList(string ProviceName)
        {
            IList<MHotelCityAreas> list = new List<MHotelCityAreas>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if(!string.IsNullOrEmpty(ProviceName))
            {
            strSql.Append(" CITY_CODE,PROVINCE,CITY_NAME ");
            }
            else
            {
                strSql.Append(" distinct PROVINCE ");
            }
            strSql.Append(" FROM Hotel_City ");
            if (!string.IsNullOrEmpty(ProviceName))
            {
                strSql.AppendFormat(" where PROVINCE ='{0}' ",ProviceName);
            }

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    MHotelCityAreas model = new MHotelCityAreas();
                    if (!string.IsNullOrEmpty(ProviceName))
                    {
                        model.AreaName = !dr.IsDBNull(dr.GetOrdinal("CITY_NAME")) ? dr.GetString(dr.GetOrdinal("CITY_NAME")) : "";
                        model.CityCode = !dr.IsDBNull(dr.GetOrdinal("CITY_CODE")) ? dr.GetString(dr.GetOrdinal("CITY_CODE")) : "";
                    }
                    else
                    {
                        model.AreaName = !dr.IsDBNull(dr.GetOrdinal("PROVINCE")) ? dr.GetString(dr.GetOrdinal("PROVINCE")) : "";
                        model.CityCode = !dr.IsDBNull(dr.GetOrdinal("PROVINCE")) ? dr.GetString(dr.GetOrdinal("PROVINCE")) : "";
                    }
                    list.Add(model);
                }
            }

            return list;

        }

        /// <summary>
        /// 根据三字码获取省份
        /// </summary>
        /// <param name="SZM"></param>
        /// <returns></returns>
        public IList<MHotelCityAreas> GetHoteCityList(string SZM)
        {
            IList<MHotelCityAreas> list = new List<MHotelCityAreas>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (!string.IsNullOrEmpty(SZM))
            {
                strSql.Append(" CITY_CODE,PROVINCE,CITY_NAME ");
            }
            strSql.Append(" FROM Hotel_City ");
            if (!string.IsNullOrEmpty(SZM))
            {
                strSql.AppendFormat(" where CITY_CODE ='{0}' ", SZM);
            }

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    MHotelCityAreas model = new MHotelCityAreas();
                    model.AreaName = !dr.IsDBNull(dr.GetOrdinal("PROVINCE")) ? dr.GetString(dr.GetOrdinal("PROVINCE")) : "";
                    model.CityCode = !dr.IsDBNull(dr.GetOrdinal("PROVINCE")) ? dr.GetString(dr.GetOrdinal("PROVINCE")) : "";
                    list.Add(model);
                }
            }

            return list;

        }

        #endregion
    }
}
