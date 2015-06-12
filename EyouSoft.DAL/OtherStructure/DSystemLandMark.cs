using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using EyouSoft.Toolkit;
using EyouSoft.Toolkit.DAL;
using System.Data;

namespace EyouSoft.DAL.OtherStructure
{
    public class DSystemLandMark : EyouSoft.Toolkit.DAL.DALBase, EyouSoft.IDAL.OtherStructure.ISystemLandMark
    {
        #region 初始化db
        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DSystemLandMark()
        {
            _db = base.SystemStore;
        }
        #endregion

        #region ISystemLandMark 成员
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(EyouSoft.Model.OtherStructure.MSystemLandMark model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbl_SystemLandMark(");
            strSql.Append("Por,CityId,CityCode");
            strSql.Append(") values (");
            strSql.Append("@Por,@CityId,@CityCode");
            strSql.Append(") ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "Por", System.Data.DbType.String, model.Por);
            this._db.AddInParameter(cmd, "CityId", System.Data.DbType.Int32, model.CityId);
            this._db.AddInParameter(cmd, "CityCode", System.Data.DbType.AnsiString, model.CityCode);
            return DbHelper.ExecuteSql(cmd, this._db);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(EyouSoft.Model.OtherStructure.MSystemLandMark model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbl_SystemLandMark set ");
            strSql.Append(" Por = @Por , ");
            strSql.Append(" CityId = @CityId , ");
            strSql.Append(" CityCode = @CityCode ");
            strSql.Append(" where Id=@Id  ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "Id", System.Data.DbType.Int32, model.Id);
            this._db.AddInParameter(cmd, "Por", System.Data.DbType.String, model.Por);
            this._db.AddInParameter(cmd, "CityId", System.Data.DbType.Int32, model.CityId);
            this._db.AddInParameter(cmd, "CityCode", System.Data.DbType.AnsiString, model.CityCode);

            return DbHelper.ExecuteSql(cmd, this._db);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public bool Delete(params string[] Ids)
        {
            StringBuilder sId = new StringBuilder();
            for (int i = 0; i < Ids.Length; i++)
            {
                sId.AppendFormat("{0},", Ids[i]);
            }
            sId.Remove(sId.Length - 1, 1);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbl_SystemLandMark where Id in (" + sId + ")");
            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            return DbHelper.ExecuteSql(dc, _db) > 0 ? true : false;
        }
        
        /// <summary>
        ///  得到一个对象实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EyouSoft.Model.OtherStructure.MSystemLandMark GetModel(int Id)
        {
            EyouSoft.Model.OtherStructure.MSystemLandMark model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, Por, CityId, CityCode  ");
            strSql.Append("  from tbl_SystemLandMark ");
            strSql.Append(" where Id=@Id ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "Id", System.Data.DbType.Int32, Id);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new EyouSoft.Model.OtherStructure.MSystemLandMark();
                    model.Id = !dr.IsDBNull(dr.GetOrdinal("Id")) ? dr.GetInt32(dr.GetOrdinal("Id")) : 0;
                    model.Por = !dr.IsDBNull(dr.GetOrdinal("Por")) ? dr.GetString(dr.GetOrdinal("Por")) : null;
                    model.CityId = !dr.IsDBNull(dr.GetOrdinal("CityId")) ? dr.GetInt32(dr.GetOrdinal("CityId")) : 0;
                    model.CityCode = !dr.IsDBNull(dr.GetOrdinal("CityCode")) ? dr.GetString(dr.GetOrdinal("CityCode")) : null;
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
        /// <param name="Search"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.OtherStructure.MSystemLandMark> GetList(int PageSize, int PageIndex, ref int RecordCount, EyouSoft.Model.OtherStructure.MSystemLandMark Search)
        {
            IList<EyouSoft.Model.OtherStructure.MSystemLandMark> list = new List<EyouSoft.Model.OtherStructure.MSystemLandMark>();

            string tableName = "tbl_SystemLandMark";
            string fileds = "Id, Por, CityId, CityCode";
            string query = " 1=1 ";
            if (Search != null)
            {
                if (!string.IsNullOrEmpty(Search.Por))
                {
                    query = query + string.Format(" AND Por like '%{0}%' ", Search.Por);
                }
                if (Search.CityId > 0)
                {
                    query = query + string.Format(" AND CityId ={0} ", Search.CityId);
                }
                if (!string.IsNullOrEmpty(Search.CityCode))
                {
                    query = query + string.Format(" AND CityCode like '%{0}%' ", Search.CityCode);
                }
            }

            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query, "CityId ASC,Id desc ", null))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.OtherStructure.MSystemLandMark model = new EyouSoft.Model.OtherStructure.MSystemLandMark();
                    model.Id = !dr.IsDBNull(dr.GetOrdinal("Id")) ? dr.GetInt32(dr.GetOrdinal("Id")) : 0;
                    model.Por = !dr.IsDBNull(dr.GetOrdinal("Por")) ? dr.GetString(dr.GetOrdinal("Por")) : null;
                    model.CityId = !dr.IsDBNull(dr.GetOrdinal("CityId")) ? dr.GetInt32(dr.GetOrdinal("CityId")) : 0;
                    model.CityCode = !dr.IsDBNull(dr.GetOrdinal("CityCode")) ? dr.GetString(dr.GetOrdinal("CityCode")) : null;
                    list.Add(model);
                }
            }

            return list;
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="Search"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.OtherStructure.MSystemLandMark> GetTopList(int Top, EyouSoft.Model.OtherStructure.MSystemLandMark Search)
        {
            IList<EyouSoft.Model.OtherStructure.MSystemLandMark> list = new List<EyouSoft.Model.OtherStructure.MSystemLandMark>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Id, Por, CityId, CityCode ");
            strSql.Append(" FROM tbl_SystemLandMark ");

            if (Search != null)
            {
                strSql.Append(" WHERE 1=1 ");
                if (!string.IsNullOrEmpty(Search.Por))
                {
                    strSql.AppendFormat(" AND Por like '%{0}%' ", Search.Por);
                }
                if (Search.CityId > 0)
                {
                    strSql.AppendFormat(" AND CityId ={0} ", Search.CityId);
                }
                if (!string.IsNullOrEmpty(Search.CityCode))
                {
                    strSql.AppendFormat(" AND CityCode like '%{0}%' ", Search.CityCode);
                }
            }
            strSql.Append(" Order By CityId ASC,Id desc ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.OtherStructure.MSystemLandMark model = new EyouSoft.Model.OtherStructure.MSystemLandMark();
                    model.Id = !dr.IsDBNull(dr.GetOrdinal("Id")) ? dr.GetInt32(dr.GetOrdinal("Id")) : 0;
                    model.Por = !dr.IsDBNull(dr.GetOrdinal("Por")) ? dr.GetString(dr.GetOrdinal("Por")) : null;
                    model.CityId = !dr.IsDBNull(dr.GetOrdinal("CityId")) ? dr.GetInt32(dr.GetOrdinal("CityId")) : 0;
                    model.CityCode = !dr.IsDBNull(dr.GetOrdinal("CityCode")) ? dr.GetString(dr.GetOrdinal("CityCode")) : null;
                    list.Add(model);
                }
            }

            return list;
        }

        #endregion
    }
}
