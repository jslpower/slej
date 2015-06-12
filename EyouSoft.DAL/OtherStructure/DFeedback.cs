using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace EyouSoft.DAL.OtherStructure
{
    public class DFeedback : EyouSoft.Toolkit.DAL.DALBase, EyouSoft.IDAL.OtherStructure.IFeedback
    {
          #region 初始化db
        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DFeedback()
        {
            _db = base.SystemStore;
        }
        #endregion

        #region 方法
        /// <summary>
        /// 添加一条反馈信息
        /// </summary>
        /// <param name="motal"></param>
        /// <returns></returns>
        public int add(EyouSoft.Model.OtherStructure.MFeedback motal)
        {
            StringBuilder StringBuilder = new StringBuilder();
            StringBuilder.Append("insert into tb1_Feedback(");
            StringBuilder.Append("MessageType,MsgContent,Name,Email,Tel,submittime");
            StringBuilder.Append(") values (");
            StringBuilder.Append("@MessageType,@MsgContent,@Name,@Email,@Tel");
            StringBuilder.Append(",getdate()");
            StringBuilder.Append(")");
            DbCommand cmd = this._db.GetSqlStringCommand(StringBuilder.ToString());
            this._db.AddInParameter(cmd, "MessageType", DbType.String, motal.MessageType);
            this._db.AddInParameter(cmd, "MsgContent", DbType.String, motal.MsgContent);
            this._db.AddInParameter(cmd, "Name", DbType.String, motal.Name);
            this._db.AddInParameter(cmd, "Email", DbType.String, motal.Email);
            this._db.AddInParameter(cmd, "Tel", DbType.String, motal.Tel);

            return DbHelper.ExecuteSql(cmd, this._db);

        }
        /// <summary>
        /// 更新一条反馈信息
        /// </summary>
        /// <param name="motal"></param>
        /// <returns></returns>
        public int update(EyouSoft.Model.OtherStructure.MFeedback motal)
        {
            StringBuilder StringBuilder = new StringBuilder();
            StringBuilder.Append("update tb1_Feedback set ");
            StringBuilder.Append("MessageType=@MessageType,");
            StringBuilder.Append("MsgContent=@MsgContent,");
            StringBuilder.Append("Name=@Name,");
            StringBuilder.Append("Email=@Email,");
            StringBuilder.Append("Tel=@Tel");
            StringBuilder.Append(" where ID=@ID");
            DbCommand cmd = this._db.GetSqlStringCommand(StringBuilder.ToString());
            this._db.AddInParameter(cmd, "MessageType", DbType.String, motal.MessageType);
            this._db.AddInParameter(cmd, "MsgContent", DbType.String, motal.MsgContent);
            this._db.AddInParameter(cmd, "Name", DbType.String, motal.Name);
            this._db.AddInParameter(cmd, "Email", DbType.String, motal.Email);
            this._db.AddInParameter(cmd, "Tel", DbType.String, motal.Tel);
            this._db.AddInParameter(cmd, "ID", DbType.Int32, motal.ID);

            return DbHelper.ExecuteSql(cmd, this._db);
        }

        /// <summary>
        /// 删除一条反馈信息
        /// </summary>
        /// <param name="motal"></param>
        /// <returns></returns>
        public int Delete(string MemberID)
        {
            StringBuilder StringBuilder = new StringBuilder();
            StringBuilder.Append("delete from tb1_Feedback");
            StringBuilder.Append(" where ID=@ID");
            DbCommand cmd = this._db.GetSqlStringCommand(StringBuilder.ToString());
            this._db.AddInParameter(cmd, "ID", DbType.Int32, MemberID);

            return DbHelper.ExecuteSql(cmd, this._db);
        }

        /// <summary>
        /// 获得一个实体对象
        /// </summary>
        /// <param name="MemberID"></param>
        /// <returns></returns>
        public EyouSoft.Model.OtherStructure.MFeedback GetModel(string MemberID)
        {
            EyouSoft.Model.OtherStructure.MFeedback MFeedback = null;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select ID,MessageType,MsgContent,Name,Email,Tel,submittime from tb1_Feedback where ID=@ID");
            DbCommand cmd = this._db.GetSqlStringCommand(stringBuilder.ToString());
            this._db.AddInParameter(cmd, "ID", DbType.Int32, MemberID);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {

                while (dr.Read())
                {
                    MFeedback = new EyouSoft.Model.OtherStructure.MFeedback();
                    MFeedback.ID = dr.GetOrdinal("ID");
                    MFeedback.MessageType = dr.GetString(dr.GetOrdinal("MessageType"));
                    MFeedback.MsgContent = dr.GetString(dr.GetOrdinal("MsgContent"));
                    MFeedback.Name = !dr.IsDBNull(dr.GetOrdinal("Name")) ? dr.GetString(dr.GetOrdinal("Name")) : null;
                    MFeedback.Email = !dr.IsDBNull(dr.GetOrdinal("Email")) ? dr.GetString(dr.GetOrdinal("Email")) : null;
                    MFeedback.Tel = !dr.IsDBNull(dr.GetOrdinal("Tel")) ? dr.GetString(dr.GetOrdinal("Tel")) : null;
                    MFeedback.submittime = !dr.IsDBNull(dr.GetOrdinal("submittime")) ? (DateTime?)dr.GetDateTime(dr.GetOrdinal("submittime")) : null;
                }

            }
            return MFeedback;
        }


        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="Search"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.OtherStructure.MFeedback> GetList(int PageSize, int PageIndex, ref int RecordCount, EyouSoft.Model.OtherStructure.MSearchFeedback Search)
        {
            IList<EyouSoft.Model.OtherStructure.MFeedback> list = new List<EyouSoft.Model.OtherStructure.MFeedback>();

            string tablename = "tb1_Feedback";
            string fileds = "ID,MessageType,MsgContent,Name,Email,Tel,submittime ";
            string orderByString = "submittime desc";

            StringBuilder query = new StringBuilder();
            query.Append(" 1=1 ");

            if (Search != null)
            {
                if (!string.IsNullOrEmpty(Search.MessageType))
                {
                    query.AppendFormat(" and  MessageType = '{0}' ", Search.MessageType);
                }

                if (!string.IsNullOrEmpty(Search.MsgContent))
                {

                    query.AppendFormat(" and  MsgContent like '%{0}%' ", Search.MsgContent);
                }

                if (!string.IsNullOrEmpty(Search.Name))
                {
                    query.AppendFormat(" and  Name like '%{0}%' ", Search.Name);
                }
                if (Search.starttime!=null)
                {
                    query.AppendFormat(" and  submittime > '{0}' ", Search.starttime);
                }
                if (Search.endtime != null)
                {
                    query.AppendFormat(" and  submittime <='{0}' ", Search.endtime);
                }
            }


            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tablename, fileds, query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.OtherStructure.MFeedback MFeedback = new EyouSoft.Model.OtherStructure.MFeedback();
                    MFeedback.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    MFeedback.MessageType = dr.GetString(dr.GetOrdinal("MessageType"));
                    MFeedback.MsgContent = dr.GetString(dr.GetOrdinal("MsgContent"));
                    MFeedback.Name = !dr.IsDBNull(dr.GetOrdinal("Name")) ? dr.GetString(dr.GetOrdinal("Name")) : null;
                    MFeedback.Email = !dr.IsDBNull(dr.GetOrdinal("Email")) ? dr.GetString(dr.GetOrdinal("Email")) : null;
                    MFeedback.Tel = !dr.IsDBNull(dr.GetOrdinal("Tel")) ? dr.GetString(dr.GetOrdinal("Tel")) : null;
                    MFeedback.submittime = !dr.IsDBNull(dr.GetOrdinal("submittime")) ? (DateTime?)dr.GetDateTime(dr.GetOrdinal("submittime")) : null;

                    list.Add(MFeedback);
                }
            }
            return list;
        }

        #endregion
    }
}
