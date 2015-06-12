using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit.DAL;
using EyouSoft.Toolkit;
using EyouSoft.IDAL.OtherStructure;


namespace EyouSoft.DAL.OtherStructure
{
    /*
    /// <summary>
    /// 短信
    /// </summary>
    public class DSms : DALBase, ISms
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
        public DSms()
        {
            _db = SystemStore;
        }
        #endregion

        #region ISms 成员
        /// <summary>
        /// 写入发送的短信信息
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(EyouSoft.Model.OtherStructure.MSmsInfo info)
        {
            string sql = "INSERT INTO [tbl_SysSms]([DingDanLeiXing],[DingDanId],[IssueTime],[FaSongStatus],[JieShouRenLeiXing],[HaoMa],[NeiRong],[FaSongLeiXing]) VALUES (@DingDanLeiXing,@DingDanId,@IssueTime,@FaSongStatus,@JieShouRenLeiXing,@HaoMa,@NeiRong,@FaSongLeiXing)";
            DbCommand cmd = _db.GetSqlStringCommand(sql);

            _db.AddInParameter(cmd, "DingDanLeiXing", DbType.Byte, info.DingDanLeiXing);
            _db.AddInParameter(cmd, "DingDanId", DbType.AnsiStringFixedLength, info.DingDanId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "FaSongStatus", DbType.Int32, info.FaSongStatus);
            _db.AddInParameter(cmd, "JieShouRenLeiXing", DbType.Byte, info.JieShouRenLeiXing);
            _db.AddInParameter(cmd, "HaoMa", DbType.String, info.HaoMa);
            _db.AddInParameter(cmd, "NeiRong", DbType.String, info.NeiRong);
            _db.AddInParameter(cmd, "FaSongLeiXing", DbType.Byte, info.FaSongLeiXing);

            return DbHelper.ExecuteSql(cmd, _db);
        }

        /// <summary>
        /// 根据订单类型、编号获取将要发送的短信信息集合
        /// </summary>
        /// <param name="dingDanLeiXing">订单类型</param>
        /// <param name="dingDanId">订单编号</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.OtherStructure.MDingDanDuanXinInfo> GetDingDanDuanXins(int dingDanLeiXing, string dingDanId)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_DingDan_GetDuanXinInfo");
            _db.AddInParameter(cmd, "DingDanLeiXing", DbType.Int32, dingDanLeiXing);
            _db.AddInParameter(cmd, "DingDanId", DbType.AnsiStringFixedLength, dingDanId);

            IList<EyouSoft.Model.OtherStructure.MDingDanDuanXinInfo> items = new List<EyouSoft.Model.OtherStructure.MDingDanDuanXinInfo>();

            using (IDataReader rdr = DbHelper.RunReaderProcedure(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.OtherStructure.MDingDanDuanXinInfo();
                    item.HaoMa = rdr["HaoMa"].ToString();
                    item.JieShouRenLeiXing = (EyouSoft.Model.Enum.SmsJieShouRenLeiXing)rdr.GetInt32(rdr.GetOrdinal("LeiXing"));
                    item.DingDanHao = rdr["DingDanHao"].ToString();

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanLeiXing">订单类型</param>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="status">订单状态</param>
        /// <param name="leiXing">设置类型</param>
        /// <returns></returns>
        public int SetDingDanStatus(int dingDanLeiXing, string dingDanId, int status, EyouSoft.Model.Enum.SetDingDanStatusLeiXing leiXing)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_DingDan_SetStatus");
            _db.AddInParameter(cmd, "DingDanLeiXing", DbType.Int32, dingDanLeiXing);
            _db.AddInParameter(cmd, "DingDanId", DbType.AnsiStringFixedLength, dingDanId);
            _db.AddInParameter(cmd, "Status", DbType.Byte, status);
            _db.AddInParameter(cmd, "SetLeiXing", DbType.Byte, leiXing);
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
    */
}
