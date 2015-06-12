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
    public class DSysLogLogin : EyouSoft.Toolkit.DAL.DALBase, EyouSoft.IDAL.OtherStructure.ISysLogLogin
    {

        #region 初始化db
        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DSysLogLogin()
        {
            _db = base.SystemStore;
        }
        #endregion




        #region ISysLogLogin 成员
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(EyouSoft.Model.MSysLogLogin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbl_SysLogLogin(");
            strSql.Append("Id,OperatorId,LoginIp,AllHttp");
            strSql.Append(") values (");
            strSql.Append("@Id,@OperatorId,@LoginIp,@AllHttp");
            strSql.Append(") ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "Id", DbType.String, model.Id);
            this._db.AddInParameter(cmd, "OperatorId", DbType.String, model.OperatorId);
            this._db.AddInParameter(cmd, "LoginIp", DbType.String, model.LoginIp);
            this._db.AddInParameter(cmd, "AllHttp", DbType.String, model.AllHttp);
            return DbHelper.ExecuteSql(cmd, this._db);

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(EyouSoft.Model.MSysLogLogin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbl_SysLogLogin set ");

            strSql.Append(" Id = @Id , ");
            strSql.Append(" OperatorId = @OperatorId , ");
            strSql.Append(" LoginIp = @LoginIp , ");
            strSql.Append(" AllHttp = @AllHttp  ");
            strSql.Append(" where Id=@Id  ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "Id", DbType.String, model.Id);
            this._db.AddInParameter(cmd, "OperatorId", DbType.String, model.OperatorId);
            this._db.AddInParameter(cmd, "LoginIp", DbType.String, model.LoginIp);
            this._db.AddInParameter(cmd, "AllHttp", DbType.String, model.AllHttp);
            return DbHelper.ExecuteSql(cmd, this._db);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delete(string Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbl_SysLogLogin ");
            strSql.Append(" where Id=@Id ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "Id", DbType.String, Id);
            return DbHelper.ExecuteSql(cmd, this._db);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EyouSoft.Model.MSysLogLogin GetModel(string Id)
        {
            EyouSoft.Model.MSysLogLogin model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, OperatorId, IssueTime, LoginIp, AllHttp  ");
            strSql.Append("(select RealName from tbl_Webmaster where Id=tbl_SysLogLogin.OperatorId) as OperatorName");
            strSql.Append("  from tbl_SysLogLogin ");
            strSql.Append(" where Id=@Id ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "Id", DbType.String, Id);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new EyouSoft.Model.MSysLogLogin();
                    model.Id = dr.GetString(dr.GetOrdinal("Id"));
                    model.OperatorId = !dr.IsDBNull(dr.GetOrdinal("OperatorId")) ? dr.GetString(dr.GetOrdinal("OperatorId")) : null;
                    model.OperatorName = !dr.IsDBNull(dr.GetOrdinal("OperatorName")) ? dr.GetString(dr.GetOrdinal("OperatorName")) : null;
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.LoginIp = !dr.IsDBNull(dr.GetOrdinal("LoginIp")) ? dr.GetString(dr.GetOrdinal("LoginIp")) : null;
                    model.AllHttp = !dr.IsDBNull(dr.GetOrdinal("AllHttp")) ? dr.GetString(dr.GetOrdinal("AllHttp")) : null;
                }
            }
            return model;
        }
        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="Search"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.MSysLogLogin> GetList(int PageSize, int PageIndex, ref int RecordCount, EyouSoft.Model.MSearchSysLogLogin Search)
        {
            IList<EyouSoft.Model.MSysLogLogin> list = new List<EyouSoft.Model.MSysLogLogin>();

            string tableName = "tbl_SysLogLogin";
            StringBuilder fields = new StringBuilder();
            fields.Append("select Id, OperatorId, IssueTime, LoginIp, AllHttp  ");
            fields.Append("(select RealName from tbl_Webmaster where Id=tbl_SysLogLogin.OperatorId) as OperatorName ");

            StringBuilder query = new StringBuilder();
            query.Append(" 1=1 ");

            if (Search != null)
            {
                if (!string.IsNullOrEmpty(Search.OperatorName))
                {
                    query.AppendFormat(" and  exists(select 1 from tbl_Webmaster  where Id=tbl_SysLogHandle.OperatorId where RealName like '%{0}%') ", Search.OperatorName);
                }

                if (Search.BeginIssueTime.HasValue)
                {
                    query.AppendFormat(" and  datediff(day,IssueTime,'{0}')<=0 ", Search.BeginIssueTime.Value);
                }


                if (Search.EndIssueTime.HasValue)
                {
                    query.AppendFormat(" and  datediff(day,IssueTime,'{0}')>=0 ", Search.EndIssueTime.Value);
                }
            }

            string orderByString = " IssueTime desc ";
            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fields.ToString(), query.ToString(), orderByString, null))
            {

                while (dr.Read())
                {
                    EyouSoft.Model.MSysLogLogin model = new EyouSoft.Model.MSysLogLogin();
                    model.Id = dr.GetString(dr.GetOrdinal("Id"));
                    model.OperatorId = !dr.IsDBNull(dr.GetOrdinal("OperatorId")) ? dr.GetString(dr.GetOrdinal("OperatorId")) : null;
                    model.OperatorName = !dr.IsDBNull(dr.GetOrdinal("OperatorName")) ? dr.GetString(dr.GetOrdinal("OperatorName")) : null;
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.LoginIp = !dr.IsDBNull(dr.GetOrdinal("LoginIp")) ? dr.GetString(dr.GetOrdinal("LoginIp")) : null;
                    model.AllHttp = !dr.IsDBNull(dr.GetOrdinal("AllHttp")) ? dr.GetString(dr.GetOrdinal("AllHttp")) : null;
                    list.Add(model);
                }
            }

            return list;
        }

        #endregion
    }
}
