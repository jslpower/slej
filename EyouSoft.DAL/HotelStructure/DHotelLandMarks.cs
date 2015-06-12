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
    public class DHotelLandMarks : EyouSoft.Toolkit.DAL.DALBase, EyouSoft.IDAL.HotelStructure.IHotelLandMarks
    {
        #region 初始化db
        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DHotelLandMarks()
        {
            _db = base.SystemStore;
        }
        #endregion


        #region IHotelLandMarks 成员

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        public bool Add(MHotelLandMarks model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbl_HotelLandMarks(");
            strSql.Append("Por,CityCode");
            strSql.Append(") values (");
            strSql.Append("@Por,@CityId,@CityCode");
            strSql.Append(") ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "Por", System.Data.DbType.String, model.Por);
            this._db.AddInParameter(cmd, "CityId", System.Data.DbType.Int32, model.CityId);
            this._db.AddInParameter(cmd, "CityCode", System.Data.DbType.AnsiString, model.CityCode);
            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(MHotelLandMarks model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbl_HotelLandMarks set ");
            strSql.Append(" Por = @Por , ");
            strSql.Append(" CityId = @CityId , ");
            strSql.Append(" CityCode = @CityCode ");
            strSql.Append(" where Id=@Id  ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "Por", System.Data.DbType.String, model.Por);
            this._db.AddInParameter(cmd, "CityId", System.Data.DbType.Int32, model.CityId);
            this._db.AddInParameter(cmd, "CityCode", System.Data.DbType.AnsiString, model.CityCode);
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
            strSql.Append("delete from tbl_HotelLandMarks where Id in (" + sId + ")");
            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            return DbHelper.ExecuteSql(dc, _db) > 0 ? true : false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="LinkID"></param>
        /// <returns></returns>
        public MHotelLandMarks GetModel(int ID)
        {
            MHotelLandMarks model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, Por,CityId, CityCode  ");
            strSql.Append("  from tbl_HotelLandMarks ");
            strSql.Append(" where Id=@Id ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "Id", System.Data.DbType.Int32, ID);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new MHotelLandMarks();
                    model.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                    model.Por = !dr.IsDBNull(dr.GetOrdinal("Por")) ? dr.GetString(dr.GetOrdinal("Por")) : "";
                    model.CityId = dr.GetInt32(dr.GetOrdinal("CityId"));
                    model.CityCode = !dr.IsDBNull(dr.GetOrdinal("CityCode")) ? dr.GetString(dr.GetOrdinal("CityCode")) : "";
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
        public IList<MHotelLandMarks> GetList(int PageSize, int PageIndex, ref int RecordCount)
        {
            IList<MHotelLandMarks> list = new List<MHotelLandMarks>();

            string tableName = "tbl_HotelLandMarks";
            string fileds = "Id, Por,CityId, CityCode";
            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, null, "Id desc ", null))
            {
                while (dr.Read())
                {
                    MHotelLandMarks model = new MHotelLandMarks();
                    model.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                    model.Por = !dr.IsDBNull(dr.GetOrdinal("Por")) ? dr.GetString(dr.GetOrdinal("Por")) : "";
                    model.CityId = dr.GetInt32(dr.GetOrdinal("CityId"));
                    model.CityCode = !dr.IsDBNull(dr.GetOrdinal("CityCode")) ? dr.GetString(dr.GetOrdinal("CityCode")) : "";
                    list.Add(model);
                }
            }

            return list;

        }


        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public IList<MHotelLandMarks> GetList(int Top, string CityCode)
        {
            IList<MHotelLandMarks> list = new List<MHotelLandMarks>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Id, Por,CityId, CityCode ");
            strSql.Append(" FROM tbl_HotelLandMarks ");
            if (!string.IsNullOrEmpty(CityCode))
            {
                if (EyouSoft.Toolkit.Utils.GetInt(CityCode, -1) > -1)
                {
                    strSql.Append(" where CityId=" + CityCode + " ");
                }
                else
                {
                    strSql.Append(" where CityCode like '%" + CityCode + "%' ");
                }
            }
            strSql.Append(" Order By Id desc ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    MHotelLandMarks model = new MHotelLandMarks();
                    model.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                    model.Por = !dr.IsDBNull(dr.GetOrdinal("Por")) ? dr.GetString(dr.GetOrdinal("Por")) : "";
                    model.CityId = dr.GetInt32(dr.GetOrdinal("CityId"));
                    model.CityCode = !dr.IsDBNull(dr.GetOrdinal("CityCode")) ? dr.GetString(dr.GetOrdinal("CityCode")) : "";
                    list.Add(model);
                }
            }

            return list;

        }

        #endregion
    }
}