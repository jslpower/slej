using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit.DAL;
using EyouSoft.IDAL.OtherStructure;
using System.Data.SqlClient;
using System.Xml.Linq;
using EyouSoft.Toolkit;

namespace EyouSoft.DAL
{
   public class DPayMents:DALBase,IPayMents
    {
       
        #region static constants
        //static constants
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DPayMents()
        {
            _db = SystemStore;
        }
        #endregion

        public int AddInterestRate(decimal Interest)
        {
            string StrSql = " insert into tbl_InterestRate values (@Interest) ";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            _db.AddInParameter(dc, "Interest", DbType.Decimal, Interest);
            return DbHelper.ExecuteSql(dc, _db);
        }

        public int UpdateInterestRate(decimal Interest)
        {
            string StrSql = " update tbl_InterestRate set Interest=@Interest";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            _db.AddInParameter(dc, "Interest", DbType.Decimal, Interest);
            return DbHelper.ExecuteSql(dc, _db);
        
        }

        public bool ExistsData()
        {
            string StrSql = " select RateID,Interest from tbl_InterestRate ";
            DbCommand dc = _db.GetSqlStringCommand(StrSql);
            object obj = DbHelper.GetSingle(dc, _db);
            if (obj == null) return false;

            if (Toolkit.Utils.GetInt(obj.ToString()) > 0) return true;

            return false;
        }

        public EyouSoft.Model.OtherStructure.MInterestRate Get()
        {
            EyouSoft.Model.OtherStructure.MInterestRate model = null;
            string StrSql = " select RateID,Interest from tbl_InterestRate";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            using (IDataReader dr = DbHelper.ExecuteReader(dc, _db))
            {
                if (dr.Read())
                {
                    model = new EyouSoft.Model.OtherStructure.MInterestRate();
                    model.RateID = dr.IsDBNull(dr.GetOrdinal("RateID")) ? 0 : dr.GetInt32(dr.GetOrdinal("RateID"));
                    model.Interest = dr.IsDBNull(dr.GetOrdinal("Interest")) ? 0 : dr.GetDecimal(dr.GetOrdinal("Interest"));
                }
            };
            return model;
        
        }

        public IList<EyouSoft.Model.OtherStructure.MPayMentsInfo> GetList(int pageSize, int pageIndex, ref int RecordCount,EyouSoft.Model.OtherStructure.MPaySearch search)
        {
            IList<EyouSoft.Model.OtherStructure.MPayMentsInfo> info = null;
            string tableName = "tbl_payments";
            StringBuilder sbfields = new StringBuilder();
            StringBuilder strWhere = new StringBuilder();
            sbfields.Append("  PayID, MemID, Account,InterestRate,DayInCome,DealDate ");

            strWhere.Append(" 1=1");

            if (search!=null)
            {
                if (!string.IsNullOrEmpty(search.MemID))
                {
                    strWhere.AppendFormat(" and MemID='{0}'", search.MemID);
                }
                if (!string.IsNullOrEmpty(search.Mname))
                {
                    strWhere.AppendFormat(" and MemID in ( select memberID from tbl_member where membername like '%{0}%')", search.Mname);
                }
                if (search.StartDate.HasValue)
                {
                    strWhere.AppendFormat(" and DealDate>='{0}'", search.StartDate);
                }
                if (search.EndDate.HasValue)
                {
                    strWhere.AppendFormat(" and DealDate<='{0}'", search.EndDate);
                }
            }

            string orderByString = " DealDate desc";
            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref RecordCount, tableName, sbfields.ToString(),strWhere.ToString(), orderByString, null))
            {
                info = new List<EyouSoft.Model.OtherStructure.MPayMentsInfo>();
                while (dr.Read())
                {
                    EyouSoft.Model.OtherStructure.MPayMentsInfo model = new EyouSoft.Model.OtherStructure.MPayMentsInfo();
                    model.PID = dr.IsDBNull(dr.GetOrdinal("PayID")) ? 0 : dr.GetInt32(dr.GetOrdinal("PayID"));
                    model.MemID = dr.IsDBNull(dr.GetOrdinal("MemID")) ? "" : dr.GetString(dr.GetOrdinal("MemID"));
                    model.Account = dr.IsDBNull(dr.GetOrdinal("Account")) ? 0 : dr.GetDecimal(dr.GetOrdinal("Account"));
                    model.IntersetRate = dr.IsDBNull(dr.GetOrdinal("InterestRate")) ? 0 : dr.GetDecimal(dr.GetOrdinal("InterestRate"));
                    model.DayInCome = dr.IsDBNull(dr.GetOrdinal("DayInCome")) ? 0 : dr.GetDecimal(dr.GetOrdinal("DayInCome"));
                    model.DealDate = dr.IsDBNull(dr.GetOrdinal("DealDate")) ? DateTime.Now : dr.GetDateTime(dr.GetOrdinal("DealDate"));
                    info.Add(model);
                    model = null;
                }
            };
            return info;
            }

        public decimal GetHistoryRate(string memberID)
        {
            decimal historyRate=0;
            string StrSql = " select isnull(sum(DayIncome),0) as HistoryRate from tbl_payments where memID=@memID ";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            _db.AddInParameter(dc, "memID", DbType.String, memberID);
            using(IDataReader dr=DbHelper.ExecuteReader(dc,_db))
            {
                if (dr.Read())
                {
                    historyRate = dr.IsDBNull(dr.GetOrdinal("HistoryRate")) ? 0 : dr.GetDecimal(dr.GetOrdinal("HistoryRate"));
                }
            };
            return historyRate;
        }



    }
}
