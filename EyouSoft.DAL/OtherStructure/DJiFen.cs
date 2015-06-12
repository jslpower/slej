using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.OtherStructure;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit.DAL;
using EyouSoft.Toolkit;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.IDAL.OtherStructure;
using EyouSoft.Model.Enum;

namespace EyouSoft.DAL.OtherStructure
{
    public class DJiFen : DALBase, IJiFen
    {
        #region
        const string SQL_UPDATE_SheZhiOrderStatus = "UPDATE [tbl_JiFen] SET [DuiHuanStatus]=@DuiHuanStatus WHERE [DuiHuanId]=@DuiHuanId ";

        #endregion
        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DJiFen()
        {
            _db = SystemStore;
        }
        #endregion
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MJiFen model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbl_JiFen(");
            strSql.Append("DuiHuanId,DuiHuanJinE,ShengYuJinE,IssueTime,UserId,DuiHuanStatus)");
            strSql.Append(" values (");
            strSql.Append("@DuiHuanId,@DuiHuanJinE,@ShengYuJinE,@IssueTime,@UserId,@DuiHuanStatus)");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "DuiHuanId", System.Data.DbType.String, model.DuiHuanId);
            this._db.AddInParameter(cmd, "DuiHuanJinE", System.Data.DbType.Int32, model.DuiHuanJinE);
            this._db.AddInParameter(cmd, "ShengYuJinE", System.Data.DbType.Int32, model.ShengYuJinE);
            this._db.AddInParameter(cmd, "IssueTime", System.Data.DbType.DateTime, model.IssueTime);
            this._db.AddInParameter(cmd, "UserId", System.Data.DbType.String, model.UserId);
            this._db.AddInParameter(cmd, "DuiHuanStatus", System.Data.DbType.Int32, (int)model.DuiHuanStatus);
            return DbHelper.ExecuteSql(cmd, this._db);

        }
        /// <summary>
        /// 累计兑换的积分总值
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        public int GetSumJiFen(string memberID,JiFenDuiHuanStatus DHStatus)
        {
            int SumJiFen = 0;
            string StrSql = " select isnull(sum(DuiHuanJinE),0) as SumJiFen from tbl_JiFen where UserId=@memID and DuiHuanStatus=" + (int)DHStatus;
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            _db.AddInParameter(dc, "memID", DbType.String, memberID);
            using (IDataReader dr = DbHelper.ExecuteReader(dc, _db))
            {
                if (dr.Read())
                {
                    SumJiFen = dr.IsDBNull(dr.GetOrdinal("SumJiFen")) ? 0 : dr.GetInt32(dr.GetOrdinal("SumJiFen"));
                }
            };
            return SumJiFen;
        }
        /// <summary>
        /// 分页获取积分兑换记录
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public IList<MJiFen> GetList(int pageSize, int pageIndex, ref int RecordCount, MJiFenSer search)
        {
            IList<MJiFen> info = null;
            string tableName = "tbl_JiFen";
            StringBuilder sbfields = new StringBuilder();
            StringBuilder strWhere = new StringBuilder();
            sbfields.Append("  * ");

            strWhere.Append(" 1=1");

            if (search != null)
            {
                if (search.StartTime.HasValue)
                {
                    strWhere.AppendFormat(" and IssueTime>='{0}'", search.StartTime);
                }
                if (search.EndTime.HasValue)
                {
                    strWhere.AppendFormat(" and IssueTime<='{0}'", search.EndTime);
                }
                if (search.DuiHuanStatus.HasValue)
                {
                    strWhere.AppendFormat(" and DuiHuanStatus='{0}'", (int)search.DuiHuanStatus);
                }
                if (!string.IsNullOrEmpty(search.UserId))
                {
                    strWhere.AppendFormat(" and UserId='{0}'", search.UserId);
                }
            }

            string orderByString = " IssueTime desc";
            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref RecordCount, tableName, sbfields.ToString(), strWhere.ToString(), orderByString, null))
            {
                info = new List<MJiFen>();
                while (dr.Read())
                {
                    MJiFen model = new MJiFen();
                    model.DuiHuanId = dr.IsDBNull(dr.GetOrdinal("DuiHuanId")) ? "" : dr.GetString(dr.GetOrdinal("DuiHuanId"));
                    model.DuiHuanJinE = dr.IsDBNull(dr.GetOrdinal("DuiHuanJinE")) ? 0 : dr.GetInt32(dr.GetOrdinal("DuiHuanJinE"));
                    model.DuiHuanStatus = (EyouSoft.Model.Enum.JiFenDuiHuanStatus)dr.GetInt32(dr.GetOrdinal("DuiHuanStatus"));
                    model.IssueTime = dr.IsDBNull(dr.GetOrdinal("IssueTime")) ? DateTime.Now : dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.ShengYuJinE = dr.IsDBNull(dr.GetOrdinal("ShengYuJinE")) ? 0 : dr.GetDecimal(dr.GetOrdinal("ShengYuJinE"));
                    model.UserId = dr.IsDBNull(dr.GetOrdinal("UserId")) ? "" : dr.GetString(dr.GetOrdinal("UserId"));
                    info.Add(model);
                    model = null;
                }
            };
            return info;
        }
        // 设置审核状态，返回1成功，其它失败
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int SheZhiStatus(string orderId, EyouSoft.Model.Enum.JiFenDuiHuanStatus status)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_SheZhiOrderStatus);

            _db.AddInParameter(cmd, "DuiHuanStatus", DbType.Byte, status);
            _db.AddInParameter(cmd, "DuiHuanId", DbType.AnsiStringFixedLength, orderId);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }

    }
}
