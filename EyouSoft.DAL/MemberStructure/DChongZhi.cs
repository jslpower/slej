/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit.DAL;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.Model.MemberStructure;
using EyouSoft.Model.Enum;

namespace EyouSoft.DAL.MemberStructure
{
    public class DChongZhi : DALBase, EyouSoft.IDAL.MemberStructure.IChongZhi
    {
        #region 初始化db

        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DChongZhi()
        {
            _db = base.SystemStore;
        }

        #endregion
        /// <summary>
        /// 写入充值记录，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MChongZhi info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_ChongZhi_Insert");



            _db.AddInParameter(cmd, "@UserId", DbType.AnsiStringFixedLength, info.UserId);
            _db.AddOutParameter(cmd, "@TransactionID", DbType.AnsiStringFixedLength, 255);
            _db.AddInParameter(cmd, "@Amounts", DbType.Decimal, info.Amounts);
            _db.AddInParameter(cmd, "@balance", DbType.Decimal, info.balance);
            _db.AddInParameter(cmd, "@TransactionTime", DbType.DateTime, info.TransactionTime);
            _db.AddInParameter(cmd, "@TransactionWay", DbType.Byte, info.TransactionWay);
            _db.AddInParameter(cmd, "@TransactionCate", DbType.Byte, info.TransactionCate);
            _db.AddInParameter(cmd, "@TransactionState", DbType.Byte, info.TransactionState);
            _db.AddInParameter(cmd, "@TransactionDesc", DbType.String, info.TransactionDesc);
            _db.AddInParameter(cmd, "@OrderType", DbType.Byte, info.DingDanType);

            _db.AddOutParameter(cmd, "@RetCode", DbType.Int32, 4);

            int sqlExceptionCode = 0;

            try
            {
                DbHelper.RunProcedure(cmd, _db);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                sqlExceptionCode = 0 - e.Number;
            }

            if (sqlExceptionCode < 0) return sqlExceptionCode;
            info.TransactionID = this._db.GetParameterValue(cmd, "TransactionID").ToString();
            return Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));
        }
        ///// <summary>
        ///// 修改充值数据，返回1成功，其它失败
        ///// </summary>
        ///// <param name="info">实体</param>
        ///// <returns></returns>
        //public int Update(MChongZhi info)
        //{

        //}
        /// <summary>
        /// 获取地址列表
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <returns></returns>
        public IList<MChongZhi> GetList(int pageSize, int pageIndex, ref int recordCount, MChongZhiSer chaXun)
        {
            IList<MChongZhi> list = new List<MChongZhi>();


            string tableName = "tbl_JA_Account";
            string fileds = "ID,USerId,TransactionID,Amounts,balance,TransactionTime,TransactionWay,TransactionCate,TransactionState,TransactionDesc";
            string orderByString = "TransactionTime desc";

            StringBuilder query = new StringBuilder();
            query.Append(" 1=1 ");

            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.UserID))
                {
                    query.AppendFormat(" and  TransactionID = '{0}' ", chaXun.UserID);
                }

            }


            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref recordCount, tableName, fileds, query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {

                    MChongZhi info = new MChongZhi();
                    info.ID = dr.GetString(dr.GetOrdinal("ID")); ;
                    info.UserId = dr.GetString(dr.GetOrdinal("USerId")); ;
                    info.TransactionID = dr.GetString(dr.GetOrdinal("TransactionID")); ;
                    info.Amounts = dr.GetDecimal(dr.GetOrdinal("Amounts")); ;
                    info.balance = dr.GetDecimal(dr.GetOrdinal("balance")); ;
                    info.TransactionTime = dr.GetDateTime(dr.GetOrdinal("TransactionTime")); ;
                    info.TransactionWay = (ChongZhiWay)dr.GetByte(dr.GetOrdinal("TransactionWay")); ;
                    info.TransactionCate = (ChongZhiLeiBie)dr.GetByte(dr.GetOrdinal("TransactionCate")); ;
                    info.TransactionState = (ChongZhiState)dr.GetByte(dr.GetOrdinal("TransactionState")); ;
                    info.TransactionDesc = dr.GetString(dr.GetOrdinal("TransactionDesc")); ;




                    list.Add(info);
                }
            }
            return list;
        }
    }
}
*/