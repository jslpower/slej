using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;
using System.Data;
using EyouSoft.Toolkit.DAL;
using System.Data.Common;

namespace EyouSoft.DAL
{
    public class DTravelStrategyTheme : EyouSoft.Toolkit.DAL.DALBase, EyouSoft.IDAL.ITravelStrategyTheme
    {
        #region 初始化db
        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DTravelStrategyTheme()
        {
            _db = base.SystemStore;
        }
        #endregion

        #region ITravelStrategyTheme 成员

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(EyouSoft.Model.MTravelStrategyTheme model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbl_TravelStrategyTheme(");
            strSql.Append("ClassName,SortRule");
            strSql.Append(") values (");
            strSql.Append("@ClassName,@SortRule");
            strSql.Append(") ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ClassName", System.Data.DbType.String, model.ClassName);
            this._db.AddInParameter(cmd, "SortRule", System.Data.DbType.Int32, model.SortRule);
            return DbHelper.ExecuteSql(cmd, this._db);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(EyouSoft.Model.MTravelStrategyTheme model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbl_TravelStrategyTheme set ");
            strSql.Append(" ClassName = @ClassName,SortRule=@SortRule ");
            strSql.Append(" where ThemeID=@ThemeID  ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ThemeID", System.Data.DbType.Int32, model.ThemeID);
            this._db.AddInParameter(cmd, "ClassName", System.Data.DbType.String, model.ClassName);
            this._db.AddInParameter(cmd, "SortRule", System.Data.DbType.Int32, model.SortRule);

            return DbHelper.ExecuteSql(cmd, this._db);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(string ThemeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbl_TravelStrategyTheme where ");
            string[] str = ThemeID.Split(',');
            string c = "";
            if (str.Length > 1)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    c += ",'" + str[i].Trim() + "'";
                }
                strSql.AppendFormat(" ThemeID in ({0}) ", c.Substring(1));
            }
            else
            {
                strSql.AppendFormat(" ThemeID = '{0}' ", ThemeID.Trim());
            }
            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            return DbHelper.ExecuteSql(dc, _db) > 0 ? 1 : 0;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EyouSoft.Model.MTravelStrategyTheme GetModel(int ClassId)
        {
            EyouSoft.Model.MTravelStrategyTheme model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ThemeID, ClassName,SortRule  ");
            strSql.Append("  from tbl_TravelStrategyTheme ");
            strSql.Append(" where ThemeID=@ThemeID ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ThemeID", System.Data.DbType.Int32, ClassId);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new EyouSoft.Model.MTravelStrategyTheme();
                    model.ThemeID = dr.GetInt32(dr.GetOrdinal("ThemeID"));
                    model.ClassName = !dr.IsDBNull(dr.GetOrdinal("ClassName")) ? dr.GetString(dr.GetOrdinal("ClassName")) : "";
                    model.SortRule = !dr.IsDBNull(dr.GetOrdinal("SortRule")) ? dr.GetInt32(dr.GetOrdinal("SortRule")) : 0;
                }
            }

            return model;
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public IList<EyouSoft.Model.MTravelStrategyTheme> GetList(EyouSoft.Model.MTravelStrategyTheme Search)
        {
            IList<EyouSoft.Model.MTravelStrategyTheme> list = new List<EyouSoft.Model.MTravelStrategyTheme>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ThemeID, ClassName,SortRule ");
            strSql.Append("  from tbl_TravelStrategyTheme where 1=1");
            if (Search != null)
            {
                if (!string.IsNullOrEmpty(Search.ClassName))
                {
                    strSql.AppendFormat(" and ClassName like '%{0}%' ", Search.ClassName);
                }
            }
            strSql.Append("  order by SortRule DESC  ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.MTravelStrategyTheme model = new EyouSoft.Model.MTravelStrategyTheme();
                    model.ThemeID = dr.GetInt32(dr.GetOrdinal("ThemeID"));
                    model.ClassName = !dr.IsDBNull(dr.GetOrdinal("ClassName")) ? dr.GetString(dr.GetOrdinal("ClassName")) : "";
                    model.SortRule = !dr.IsDBNull(dr.GetOrdinal("SortRule")) ? dr.GetInt32(dr.GetOrdinal("SortRule")) : 0;
                    list.Add(model);
                }
            }
            return list;
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public IList<EyouSoft.Model.MTravelStrategyTheme> GetList(int PageSize, int PageIndex, ref int RecordCount, EyouSoft.Model.MTravelStrategyTheme Search)
        {
            IList<EyouSoft.Model.MTravelStrategyTheme> list = new List<EyouSoft.Model.MTravelStrategyTheme>();

            string tableName = "tbl_TravelStrategyTheme";
            string fileds = "ThemeID, ClassName,SortRule";
            StringBuilder query = new StringBuilder();
            if (Search != null)
            {
                if (!string.IsNullOrEmpty(Search.ClassName))
                {
                    query.AppendFormat(" ClassName like '%{0}%' ", Search.ClassName);
                }
            }
            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query.ToString(), "SortRule DESC ", null))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.MTravelStrategyTheme model = new EyouSoft.Model.MTravelStrategyTheme();
                    model.ThemeID = dr.GetInt32(dr.GetOrdinal("ThemeID"));
                    model.ClassName = !dr.IsDBNull(dr.GetOrdinal("ClassName")) ? dr.GetString(dr.GetOrdinal("ClassName")) : "";
                    model.SortRule = !dr.IsDBNull(dr.GetOrdinal("SortRule")) ? dr.GetInt32(dr.GetOrdinal("SortRule")) : 0;
                    list.Add(model);
                }
            }

            return list;
        }

        #endregion
    }
}
