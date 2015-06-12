using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using EyouSoft.Toolkit.DAL;
using System.Data;

namespace EyouSoft.DAL.OtherStructure
{
    public class DSysLogHandle : EyouSoft.Toolkit.DAL.DALBase, EyouSoft.IDAL.OtherStructure.ISysLogHandle
    {
        #region 初始化db
        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DSysLogHandle()
        {
            _db = base.SystemStore;
        }
        #endregion



        #region ISysLogHandle 成员
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(EyouSoft.Model.MSysLogHandle model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbl_SysLogHandle(");
            strSql.Append("Id,OperatorId,EventCode,EventMessage,EventTitle,EventTime,EventIp");
            strSql.Append(") values (");
            strSql.Append("@Id,@OperatorId,@EventCode,@EventMessage,@EventTitle,@EventTime,@EventIp");
            strSql.Append(") ");


            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "Id", DbType.String, model.Id);
            this._db.AddInParameter(cmd, "OperatorId", DbType.Int32, model.OperatorId);
            this._db.AddInParameter(cmd, "EventCode", DbType.Int32, model.EventCode);
            this._db.AddInParameter(cmd, "EventMessage", DbType.String, model.EventMessage);
            this._db.AddInParameter(cmd, "EventTitle", DbType.String, model.EventTitle);
            this._db.AddInParameter(cmd, "EventTime", DbType.DateTime, model.EventTime);
            this._db.AddInParameter(cmd, "EventIp", DbType.String, model.EventIp);

            return DbHelper.ExecuteSql(cmd, this._db);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(EyouSoft.Model.MSysLogHandle model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbl_SysLogHandle set ");

            strSql.Append(" Id = @Id , ");
            strSql.Append(" OperatorId = @OperatorId , ");
            strSql.Append(" EventCode = @EventCode , ");
            strSql.Append(" EventMessage = @EventMessage , ");
            strSql.Append(" EventTitle = @EventTitle , ");
            strSql.Append(" EventTime = @EventTime , ");
            strSql.Append(" EventIp = @EventIp  ");
            strSql.Append(" where Id=@Id  ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "Id", DbType.String, model.Id);
            this._db.AddInParameter(cmd, "OperatorId", DbType.Int32, model.OperatorId);
            this._db.AddInParameter(cmd, "EventCode", DbType.Int32, model.EventCode);
            this._db.AddInParameter(cmd, "EventMessage", DbType.String, model.EventMessage);
            this._db.AddInParameter(cmd, "EventTitle", DbType.String, model.EventTitle);
            this._db.AddInParameter(cmd, "EventTime", DbType.DateTime, model.EventTime);
            this._db.AddInParameter(cmd, "EventIp", DbType.String, model.EventIp);

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
            strSql.Append("delete from tbl_SysLogHandle ");
            strSql.Append(" where Id=@Id ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "Id", DbType.String, Id);

            return DbHelper.ExecuteSql(cmd, this._db);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EyouSoft.Model.MSysLogHandle GetModel(string Id)
        {
            EyouSoft.Model.MSysLogHandle model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, OperatorId, EventCode, EventMessage, EventTitle, EventTime, EventIp,  ");
            strSql.Append("(select RealName from tbl_Webmaster where Id=tbl_SysLogHandle.OperatorId) as OperatorName");
            strSql.Append("  from tbl_SysLogHandle ");
            strSql.Append(" where Id=@Id ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "Id", DbType.String, Id);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new EyouSoft.Model.MSysLogHandle();
                    model.Id = dr.GetString(dr.GetOrdinal("Id"));
                    model.OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"));
                    model.OperatorName = !dr.IsDBNull(dr.GetOrdinal("OperatorName")) ? dr.GetString(dr.GetOrdinal("OperatorName")) : null;
                    model.EventCode = !dr.IsDBNull(dr.GetOrdinal("EventCode")) ? dr.GetInt32(dr.GetOrdinal("EventCode")) : 0;
                    model.EventMessage = !dr.IsDBNull(dr.GetOrdinal("EventMessage")) ? dr.GetString(dr.GetOrdinal("EventMessage")) : null;
                    model.EventTitle = !dr.IsDBNull(dr.GetOrdinal("EventMessage")) ? dr.GetString(dr.GetOrdinal("EventMessage")) : null;
                    model.EventTime = dr.GetDateTime(dr.GetOrdinal("EventTime"));
                    model.EventIp = !dr.IsDBNull(dr.GetOrdinal("EventIp")) ? dr.GetString(dr.GetOrdinal("EventIp")) : null;
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
        public IList<EyouSoft.Model.MSysLogHandle> GetList(int PageSize, int PageIndex, ref int RecordCount, EyouSoft.Model.MSearchSysLogHandle Search)
        {
            IList<EyouSoft.Model.MSysLogHandle> list = new List<EyouSoft.Model.MSysLogHandle>();

            string tableName = "tbl_SysLogHandle";

            StringBuilder fields = new StringBuilder();
            fields.Append("Id, OperatorId, EventCode, EventMessage, EventTitle, EventTime, EventIp,  ");
            fields.Append("(select RealName from tbl_Webmaster where Id=tbl_SysLogHandle.OperatorId) as OperatorName");

            StringBuilder query = new StringBuilder();
            query.Append(" 1=1 ");

            if (Search != null)
            {
                if (!string.IsNullOrEmpty(Search.OperatorName))
                {
                    query.AppendFormat(" and  exists(select 1 from tbl_Webmaster  where Id=tbl_SysLogHandle.OperatorId where RealName like '%{0}%') ", Search.OperatorName);
                }

                if (Search.BeginEventTime.HasValue)
                {
                    query.AppendFormat(" and  datediff(day,EventTime,'{0}')<=0 ", Search.BeginEventTime.Value);
                }


                if (Search.EndEventTime.HasValue)
                {
                    query.AppendFormat(" and  datediff(day,EventTime,'{0}')>=0 ", Search.EndEventTime.Value);
                }
            }


            string orderByString = " EventTime desc";

            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fields.ToString(), query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.MSysLogHandle model = new EyouSoft.Model.MSysLogHandle();
                    model.Id = dr.GetString(dr.GetOrdinal("Id"));
                    model.OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"));
                    model.OperatorName = !dr.IsDBNull(dr.GetOrdinal("OperatorName")) ? dr.GetString(dr.GetOrdinal("OperatorName")) : null;
                    model.EventCode = !dr.IsDBNull(dr.GetOrdinal("EventCode")) ? dr.GetInt32(dr.GetOrdinal("EventCode")) : 0;
                    model.EventMessage = !dr.IsDBNull(dr.GetOrdinal("EventMessage")) ? dr.GetString(dr.GetOrdinal("EventMessage")) : null;
                    model.EventTitle = !dr.IsDBNull(dr.GetOrdinal("EventMessage")) ? dr.GetString(dr.GetOrdinal("EventMessage")) : null;
                    model.EventTime = dr.GetDateTime(dr.GetOrdinal("EventTime"));
                    model.EventIp = !dr.IsDBNull(dr.GetOrdinal("EventIp")) ? dr.GetString(dr.GetOrdinal("EventIp")) : null;
                    list.Add(model);
                }
            }

            return list;


        }

        #endregion
    }
}
