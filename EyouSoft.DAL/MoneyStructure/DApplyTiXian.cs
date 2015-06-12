using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model;
using EyouSoft.Toolkit.DAL;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using EyouSoft.IDAL.MoneyStructure;
using EyouSoft.Model.MoneyStructure;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.Model.Enum;

namespace EyouSoft.DAL.MoneyStructure
{
    public class DApplyTiXian : DALBase, IApplyTiXian
    {
        #region
        #endregion

         #region 初始化db
        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DApplyTiXian()
        {
            _db = base.SystemStore;
        }
        #endregion

        #region  方法
        /// <summary>
        /// 增加提现申请
        /// </summary>
        /// <param name="model">提现model</param>
        /// <returns>返回1成功，0-失败</returns>
        public int Add(MApplyTiXian model)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_JA_ApplyTiXian_ADD");
            _db.AddInParameter(cmd, "ApplyStatus", DbType.Int32, model.ApplyStatus);
            _db.AddInParameter(cmd, "BankNum", DbType.String, model.BankNum);
            _db.AddInParameter(cmd, "JinE", DbType.Decimal, model.JinE);
            _db.AddInParameter(cmd, "KaiHuBank", DbType.String, model.KaiHuBank);
            _db.AddInParameter(cmd, "KaiHuName", DbType.String, model.KaiHuName);
            _db.AddInParameter(cmd, "TiXianStatus", DbType.Int32, model.TiXianStatus);
            _db.AddInParameter(cmd, "TiXianTime", DbType.DateTime, model.TiXianTime);
            _db.AddInParameter(cmd, "UserId", DbType.String, model.UserId);
            _db.AddInParameter(cmd, "BeiZhu", DbType.String, model.BeiZhu);
            _db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            _db.AddInParameter(cmd, "TiXianId", DbType.AnsiStringFixedLength, model.TiXianId);
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

            return Convert.ToInt32(_db.GetParameterValue(cmd, "Result"));
        }

        /// <summary>
        /// 获取用户提现金额
        /// </summary>
        /// <returns></returns>
        public decimal GetDongJieJinE(string userid)
        {
            decimal jinE=0M;
            string sql = "select sum(JinE) from dbo.tbl_JA_ApplyTiXian where ApplyStatus in(" + (int)EyouSoft.Model.Enum.TiXianShenHe.未审核 + "," + (int)EyouSoft.Model.Enum.TiXianShenHe.已审核 + ") and TiXianStatus =" + (int)EyouSoft.Model.Enum.TiXianState.未提现 + " and UserId='"+ userid +"'";
            DbCommand cmd = this._db.GetSqlStringCommand(sql);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(0)) jinE = rdr.GetDecimal(0);
                }
            }

            return jinE;
        }

        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.MoneyStructure.MApplyTiXian> GetList(int PageSize, int PageIndex, string OrderBy, ref int RecordCount, EyouSoft.Model.MoneyStructure.MApplyTiXianSer serModel)
        {
            IList<EyouSoft.Model.MoneyStructure.MApplyTiXian> list = new List<EyouSoft.Model.MoneyStructure.MApplyTiXian>();

            string tableName = "tbl_JA_ApplyTiXian";
            string fileds = " * ";
            string orderByString = "TiXianTime desc";
            if (OrderBy != null)
            {
                orderByString = OrderBy;
            }
            StringBuilder query = new StringBuilder();
            query.Append(" 1=1 ");

            #region 查询条件
            if (serModel != null)
            {
                if (serModel.ApplyStatus.HasValue)
                {
                    query.AppendFormat(" and  ApplyStatus = {0}", (int)serModel.ApplyStatus);
                }
                if (serModel.TiXianStatus.HasValue)
                {
                    query.AppendFormat(" and  TiXianStatus = {0}", (int)serModel.TiXianStatus);
                }
                if (serModel.TiXianStartTime.HasValue && serModel.TiXianEndTime.HasValue)
                {
                    query.AppendFormat(" and  TiXianTime >= '{0}' and TiXianTime <= '{1}'", serModel.TiXianStartTime, serModel.TiXianEndTime);
                }
                else
                {
                    if (serModel.TiXianStartTime.HasValue)
                    {
                        if (serModel.TiXianStartTime > DateTime.Now)
                        {
                            query.AppendFormat(" and  TiXianTime >= '{0}' and TiXianTime <= '{1}'", DateTime.Now.ToString("yyyy-MM-dd"), serModel.TiXianStartTime);
                        }
                        else
                        {
                            query.AppendFormat(" and  TiXianTime >= '{0}' and TiXianTime <= '{1}'", serModel.TiXianStartTime, DateTime.Now.ToString("yyyy-MM-dd"));
                        }
                    }
                    if (serModel.TiXianStartTime.HasValue && serModel.TiXianEndTime.HasValue)
                    {
                        if (serModel.TiXianEndTime > DateTime.Now)
                        {
                            query.AppendFormat(" and  TiXianTime >= '{0}' and TiXianTime <= '{1}'", DateTime.Now.ToString("yyyy-MM-dd"), serModel.TiXianEndTime);
                        }
                        else
                        {
                            query.AppendFormat(" and  TiXianTime >= '{0}' and TiXianTime <= '{1}'", serModel.TiXianEndTime, DateTime.Now.ToString("yyyy-MM-dd"));
                        }
                    }
                }
                if (!string.IsNullOrEmpty(serModel.UserId))
                {
                    query.AppendFormat(" and  UserId = '{0}'", serModel.UserId);
                }

            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query.ToString(), orderByString, null))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.MoneyStructure.MApplyTiXian();
                    info.ApplyStatus = (TiXianShenHe)rdr.GetByte(rdr.GetOrdinal("ApplyStatus"));
                    info.BankNum = rdr["BankNum"].ToString();
                    info.BeiZhu = rdr["BeiZhu"].ToString();
                    info.Id = rdr.GetInt32(rdr.GetOrdinal("Id"));
                    info.JinE = rdr.GetDecimal(rdr.GetOrdinal("JinE"));
                    info.KaiHuBank = rdr["KaiHuBank"].ToString();
                    info.KaiHuName = rdr["KaiHuName"].ToString();
                    info.ShenHeBeiZhu = rdr["ShenHeBeiZhu"].ToString();
                    info.TiXianId = rdr["TiXianId"].ToString();
                    info.TiXianStatus = (TiXianState)rdr.GetByte(rdr.GetOrdinal("TiXianStatus"));
                    info.TiXianTime = rdr.GetDateTime(rdr.GetOrdinal("TiXianTime"));
                    info.TransactionID = rdr["TransactionID"].ToString();
                    info.UserId = rdr["UserID"].ToString();
                    list.Add(info);
                }
            }

            return list;
        }
        
        /*/// <summary>
        /// 获得提现实体Model
        /// </summary>
        /// <param name="TiXianID">提现id</param>
        /// <returns></returns>
        public MApplyTiXian GetModel(string TiXianID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from tbl_JA_ApplyTiXian ");
            strSql.Append(" where Id=@TiXianID");
            DbCommand dbCommand = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dbCommand, "TiXianID", DbType.AnsiString, TiXianID);
            MApplyTiXian model = null;
            using (IDataReader dr = DbHelper.ExecuteReader(dbCommand, this._db))
            {
                while (dr.Read())
                {
                    model = new MApplyTiXian();
                    model.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                    model.ApplyStatus = (TiXianShenHe)dr.GetByte(dr.GetOrdinal("ApplyStatus"));
                    model.BankNum = dr.GetString(dr.GetOrdinal("BankNum"));
                    model.BeiZhu = dr["BeiZhu"].ToString();
                    model.JinE = dr.GetDecimal(dr.GetOrdinal("JinE"));
                    model.KaiHuBank = dr.GetString(dr.GetOrdinal("KaiHuBank"));
                    model.KaiHuName = dr.GetString(dr.GetOrdinal("KaiHuName"));                    
                    model.ShenHeBeiZhu = dr["ShenHeBeiZhu"].ToString();
                    model.TiXianStatus = (TiXianState)dr.GetByte(dr.GetOrdinal("TiXianStatus"));
                    model.TiXianTime = dr.GetDateTime(dr.GetOrdinal("TiXianTime"));
                    model.UserId = dr.GetString(dr.GetOrdinal("UserId"));
                    model.TransactionID = dr.GetString(dr.GetOrdinal("TransactionID"));
                }
            }
            return model;
        }

        /// <summary>
        /// 更新提现状态
        /// </summary>
        /// <param name="id">提现表主id</param>
        /// <param name="tixianstate">状态</param>
        /// <returns></returns>
        public int UpdateTiXianStatus(int id,EyouSoft.Model.Enum.TiXianState tixianstate)
        {
            string sql = "update tbl_JA_ApplyTiXian set TiXianStatus=@TiXianStatus where Id=@Id";
            DbCommand cmd = this._db.GetSqlStringCommand(sql);

            this._db.AddInParameter(cmd, "Id", DbType.Int32, id);
            this._db.AddInParameter(cmd, "TiXianStatus", DbType.Int32, (int)tixianstate);

            int count = DbHelper.ExecuteSql(cmd, this._db);
            return count;
        }
        /// <summary>
        /// 更新审核状态
        /// </summary>
        /// <param name="id">提现id</param>
        /// <param name="applystate">状态</param>
        /// <returns></returns>
        public int UpdateShenHeStatus(int id, EyouSoft.Model.Enum.TiXianShenHe applystate)
        {
            string sql = "update tbl_JA_ApplyTiXian set ApplyStatus=@ApplyStatus where Id=@Id";
            DbCommand cmd = this._db.GetSqlStringCommand(sql);

            this._db.AddInParameter(cmd, "Id", DbType.Int32, id);
            this._db.AddInParameter(cmd, "ApplyStatus", DbType.Int32, (int)applystate);

            int count = DbHelper.ExecuteSql(cmd, this._db);
            return count;
        }
        /// <summary>
        /// 提现失败更新提现状态及原因
        /// </summary>
        /// <param name="id">提现表主id</param>
        /// <param name="tixianstate">状态</param>
        /// <param name="ShenHeBeiZhu">审核备注</param>
        /// <returns></returns>
        public int UpdateTiXianSB(int id, EyouSoft.Model.Enum.TiXianState tixianstate, string ShenHeBeiZhu)
        {
            string sql = "update tbl_JA_ApplyTiXian set TiXianStatus=@TiXianStatus,ShenHeBeiZhu=@ShenHeBeiZhu where Id=@Id";
            DbCommand cmd = this._db.GetSqlStringCommand(sql);

            this._db.AddInParameter(cmd, "Id", DbType.Int32, id);
            this._db.AddInParameter(cmd, "TiXianStatus", DbType.Int32, (int)tixianstate);
            this._db.AddInParameter(cmd, "ShenHeBeiZhu", DbType.String, ShenHeBeiZhu);

            int count = DbHelper.ExecuteSql(cmd, this._db);
            return count;
        }
        /// <summary>
        /// 审核失败更新审核状态及原因
        /// </summary>
        /// <param name="id">提现id</param>
        /// <param name="applystate">状态</param>
        /// <param name="ShenHeBeiZhu">审核备注</param>
        /// <returns></returns>
        public int UpdateShenHeSB(int id, EyouSoft.Model.Enum.TiXianShenHe applystate, string ShenHeBeiZhu)
        {
            string sql = "update tbl_JA_ApplyTiXian set ApplyStatus=@ApplyStatus,ShenHeBeiZhu=@ShenHeBeiZhu where Id=@Id";
            DbCommand cmd = this._db.GetSqlStringCommand(sql);

            this._db.AddInParameter(cmd, "Id", DbType.Int32, id);
            this._db.AddInParameter(cmd, "ApplyStatus", DbType.Int32, (int)applystate);
            this._db.AddInParameter(cmd, "ShenHeBeiZhu", DbType.String, ShenHeBeiZhu);

            int count = DbHelper.ExecuteSql(cmd, this._db);
            return count;
        }
        */

        /// <summary>
        /// 获取提现信息业务实体
        /// </summary>
        /// <param name="tiXianId">提现编号</param>
        /// <returns></returns>
        public MApplyTiXian GetInfo(string tiXianId)
        {
            MApplyTiXian info = new MApplyTiXian();
            var cmd = _db.GetSqlStringCommand("SELECT * FROM tbl_JA_ApplyTiXian WHERE TiXianId=@TiXianId");
            _db.AddInParameter(cmd, "TiXianId", DbType.AnsiStringFixedLength, tiXianId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new MApplyTiXian();

                    info.ApplyStatus = (TiXianShenHe)rdr.GetByte(rdr.GetOrdinal("ApplyStatus"));
                    info.BankNum = rdr["BankNum"].ToString();
                    info.BeiZhu = rdr["BeiZhu"].ToString();
                    info.Id = rdr.GetInt32(rdr.GetOrdinal("Id"));
                    info.JinE = rdr.GetDecimal(rdr.GetOrdinal("JinE"));
                    info.KaiHuBank = rdr["KaiHuBank"].ToString();
                    info.KaiHuName = rdr["KaiHuName"].ToString();
                    info.ShenHeBeiZhu = rdr["ShenHeBeiZhu"].ToString();
                    info.TiXianId = tiXianId;
                    info.TiXianStatus = (TiXianState)rdr.GetByte(rdr.GetOrdinal("TiXianStatus"));
                    info.TiXianTime = rdr.GetDateTime(rdr.GetOrdinal("TiXianTime"));
                    info.TransactionID = rdr["TransactionID"].ToString();
                    info.UserId = rdr["UserID"].ToString();
                }
            }

            return info;
        }

        /// <summary>
        /// 设置提现状态，返回1成功，其它失败
        /// </summary>
        /// <param name="tiXianId">提现编号</param>
        /// <param name="fs">0:审核 1:提现</param>
        /// <param name="status">(int)状态</param>
        /// <param name="beiZhu">备注</param>
        /// <returns></returns>
        public int SheZhiTiXianStatus(string tiXianId, int fs, int status, string beiZhu)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_TiXian_SheZhiStatus");
            _db.AddInParameter(cmd, "TiXianId", DbType.AnsiStringFixedLength, tiXianId);
            _db.AddInParameter(cmd, "ShiJian", DbType.DateTime, DateTime.Now);
            _db.AddInParameter(cmd, "Status", DbType.Byte, status);
            _db.AddInParameter(cmd, "FS", DbType.Byte, fs);
            _db.AddInParameter(cmd, "YuanYin", DbType.String, beiZhu);
            _db.AddOutParameter(cmd, "RetCode", DbType.Int32, 4);
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

            return Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));
        }
        #endregion
    }
}
