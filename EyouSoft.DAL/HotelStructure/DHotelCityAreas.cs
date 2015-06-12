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
    public class DHotelCityAreas : EyouSoft.Toolkit.DAL.DALBase, EyouSoft.IDAL.HotelStructure.IHotelCityAreas
    {
        #region 初始化db
        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DHotelCityAreas()
        {
            _db = base.SystemStore;
        }
        #endregion


        #region IHotelCityAreas 成员

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        public bool Add(MHotelCityAreas model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbl_HotelCityAreas(");
            strSql.Append("CityCode,AreaName");
            strSql.Append(") values (");
            strSql.Append("@CityCode,@AreaName");
            strSql.Append(") ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "CityCode", System.Data.DbType.AnsiString, model.CityCode);
            this._db.AddInParameter(cmd, "AreaName", System.Data.DbType.String, model.AreaName);
            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(MHotelCityAreas model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbl_HotelCityAreas set ");
            strSql.Append(" CityCode = @CityCode , ");
            strSql.Append(" AreaName = @AreaName ");
            strSql.Append(" where Id=@Id  ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "CityCode", System.Data.DbType.AnsiString, model.CityCode);
            this._db.AddInParameter(cmd, "AreaName", System.Data.DbType.String, model.AreaName);
            this._db.AddInParameter(cmd, "Id", System.Data.DbType.Int32, model.Id);

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
            strSql.Append("delete from tbl_HotelCityAreas where Id in (" + sId + ")");
            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            return DbHelper.ExecuteSql(dc, _db) > 0 ? true : false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="LinkID"></param>
        /// <returns></returns>
        public MHotelCityAreas GetModel(int ID)
        {
            MHotelCityAreas model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, CityCode, AreaName  ");
            strSql.Append("  from tbl_HotelCityAreas ");
            strSql.Append(" where Id=@Id ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "Id", System.Data.DbType.Int32, ID);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new MHotelCityAreas();
                    model.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                    model.CityCode = !dr.IsDBNull(dr.GetOrdinal("CityCode")) ? dr.GetString(dr.GetOrdinal("CityCode")) : "";
                    model.AreaName = !dr.IsDBNull(dr.GetOrdinal("AreaName")) ? dr.GetString(dr.GetOrdinal("AreaName")) : "";
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
        public IList<MHotelCityAreas> GetList(int PageSize, int PageIndex, ref int RecordCount)
        {
            IList<MHotelCityAreas> list = new List<MHotelCityAreas>();

            string tableName = "tbl_HotelCityAreas";
            string fileds = "Id, CityCode, AreaName";
            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, null, "Id desc ", null))
            {
                while (dr.Read())
                {
                    MHotelCityAreas model = new MHotelCityAreas();
                    model.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                    model.CityCode = !dr.IsDBNull(dr.GetOrdinal("CityCode")) ? dr.GetString(dr.GetOrdinal("CityCode")) : "";
                    model.AreaName = !dr.IsDBNull(dr.GetOrdinal("AreaName")) ? dr.GetString(dr.GetOrdinal("AreaName")) : "";
                    list.Add(model);
                }
            }

            return list;

        }


        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public IList<MHotelCityAreas> GetList(int Top)
        {
            IList<MHotelCityAreas> list = new List<MHotelCityAreas>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Id, CityCode, AreaName ");
            strSql.Append(" FROM tbl_HotelCityAreas ");
            strSql.Append(" Order By Id desc ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    MHotelCityAreas model = new MHotelCityAreas();
                    model.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                    model.CityCode = !dr.IsDBNull(dr.GetOrdinal("CityCode")) ? dr.GetString(dr.GetOrdinal("CityCode")) : "";
                    model.AreaName = !dr.IsDBNull(dr.GetOrdinal("AreaName")) ? dr.GetString(dr.GetOrdinal("AreaName")) : "";
                    list.Add(model);
                }
            }

            return list;

        }

        #endregion
    }
}
