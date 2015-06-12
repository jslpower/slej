using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit.DAL;

namespace EyouSoft.DAL.OtherStructure
{
    public class DRouteTheme : EyouSoft.Toolkit.DAL.DALBase, EyouSoft.IDAL.OtherStructure.IRouteTheme
    {
        #region 初始化db
        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DRouteTheme()
        {
            _db = base.SystemStore;
        }
        #endregion




        #region IRouteTheme 成员

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(EyouSoft.Model.MRouteTheme model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbl_RouteTheme(");
            strSql.Append("Name");
            strSql.Append(") values (");
            strSql.Append("@Name");
            strSql.Append(") ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "Name", DbType.String, model.Name);
            return DbHelper.ExecuteSql(cmd, this._db);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(EyouSoft.Model.MRouteTheme model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbl_RouteTheme set ");
            strSql.Append(" Name = @Name  ");
            strSql.Append(" where ID=@ID ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ID", DbType.Int32, model.ID);
            this._db.AddInParameter(cmd, "Name", DbType.String, model.Name);
            return DbHelper.ExecuteSql(cmd, this._db);

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbl_RouteTheme ");
            strSql.Append(" where ID=@ID");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ID", DbType.Int32, ID);

            return DbHelper.ExecuteSql(cmd, this._db);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public EyouSoft.Model.MRouteTheme GetModel(int ID)
        {
            EyouSoft.Model.MRouteTheme model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, Name  ");
            strSql.Append("  from tbl_RouteTheme ");
            strSql.Append(" where ID=@ID");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ID", DbType.Int32, ID);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new EyouSoft.Model.MRouteTheme();

                    model.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    model.Name = !dr.IsDBNull(dr.GetOrdinal("Name")) ? dr.GetString(dr.GetOrdinal("Name")) : null;

                }
            }
            return model;

        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.MRouteTheme> GetList()
        {
            IList<EyouSoft.Model.MRouteTheme> list = new List<EyouSoft.Model.MRouteTheme>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM tbl_RouteTheme ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.MRouteTheme model = new EyouSoft.Model.MRouteTheme();

                    model.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    model.Name = !dr.IsDBNull(dr.GetOrdinal("Name")) ? dr.GetString(dr.GetOrdinal("Name")) : null;
                    list.Add(model);
                }
            }

            return list;
        }

        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.MRouteTheme> GetList(int PageSize, int PageIndex, ref int RecordCount)
        {
            IList<EyouSoft.Model.MRouteTheme> list = new List<EyouSoft.Model.MRouteTheme>();

            string tableName = "tbl_RouteTheme";
            string fileds = "ID, Name";
            string orderByString = " ID desc";

            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, null, orderByString, null))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.MRouteTheme model = new EyouSoft.Model.MRouteTheme();

                    model.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    model.Name = !dr.IsDBNull(dr.GetOrdinal("Name")) ? dr.GetString(dr.GetOrdinal("Name")) : null;
                    list.Add(model);
                }
            }

            return list;
        }

        #endregion
    }

}
