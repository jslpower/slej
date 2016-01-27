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
    public class DChongZhi : EyouSoft.Toolkit.DAL.DALBase, EyouSoft.IDAL.OtherStructure.IChongZhi
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
        /// 写入充值信息，返回1成功，其它失败
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public int Add(EyouSoft.Model.OtherStructure.MChongZhi model)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_ChongZhi_C");

            _db.AddInParameter(cmd, "@DingDanId", DbType.AnsiStringFixedLength, model.DingDanId);
            _db.AddInParameter(cmd, "@HuiYuanId", DbType.AnsiStringFixedLength, model.HuiYuanId);
            _db.AddInParameter(cmd, "@JinE", DbType.Currency, model.JinE);
            _db.AddInParameter(cmd, "@Issuetime", DbType.DateTime, model.Issuetime);
            _db.AddInParameter(cmd, "@ZhiFuStatus", DbType.Byte, model.ZhiFuStatus);
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

            int dbRetCode = Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));

            return dbRetCode;
        }

        /// <summary>
        /// 获取充值信息业务实体
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <returns></returns>
        public EyouSoft.Model.OtherStructure.MChongZhi GetInfo(string dingDanId)
        {
            EyouSoft.Model.OtherStructure.MChongZhi info = null;
            DbCommand cmd = this._db.GetSqlStringCommand("SELECT  *  FROM view_ChongZhi WHERE DingDanId=@DingDanId");
            this._db.AddInParameter(cmd, "DingDanId", DbType.AnsiStringFixedLength, dingDanId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, this._db))
            {
                if (rdr.Read())
                {
                    info = new EyouSoft.Model.OtherStructure.MChongZhi();

                    info.DingDanId = rdr["DingDanId"].ToString();
                    info.HuiYuanId = rdr.GetString(rdr.GetOrdinal("HuiYuanId"));
                    info.JinE = rdr.GetDecimal(rdr.GetOrdinal("JinE"));
                    info.Issuetime = rdr.GetDateTime(rdr.GetOrdinal("Issuetime"));
                    info.JiaoYiHao = rdr.GetString(rdr.GetOrdinal("JiaoYiHao"));
                    info.ZhiFuStatus = (EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus)rdr.GetByte(rdr.GetOrdinal("ZhiFuStatus"));

                    int zhiFuFangShi = rdr.GetInt32(rdr.GetOrdinal("ZhiFuFangShi"));
                    if (zhiFuFangShi > -1 && info.ZhiFuStatus == EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.已付款) info.ZhiFuFangShi = (EyouSoft.Model.Enum.ZhiFuFangShi)zhiFuFangShi;

                    info.HuiYuanName = rdr["HuiYuanName"].ToString();
                    info.HuiYuanYongHuMing = rdr["HuiYuanYongHuMing"].ToString();
                }
            }

            return info;
        }

        /// <summary>
        /// 获取充值信息业务实体
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <returns></returns>
        public EyouSoft.Model.OtherStructure.MChongZhi GetInfoByCode(string orderCode)
        {
            EyouSoft.Model.OtherStructure.MChongZhi info = null;
            DbCommand cmd = this._db.GetSqlStringCommand("SELECT  *  FROM view_ChongZhi WHERE JiaoYiHao=@ordercode");
            this._db.AddInParameter(cmd, "ordercode", DbType.String, orderCode);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, this._db))
            {
                if (rdr.Read())
                {
                    info = new EyouSoft.Model.OtherStructure.MChongZhi();

                    info.DingDanId = rdr["DingDanId"].ToString();
                    info.HuiYuanId = rdr.GetString(rdr.GetOrdinal("HuiYuanId"));
                    info.JinE = rdr.GetDecimal(rdr.GetOrdinal("JinE"));
                    info.Issuetime = rdr.GetDateTime(rdr.GetOrdinal("Issuetime"));
                    info.JiaoYiHao = rdr.GetString(rdr.GetOrdinal("JiaoYiHao"));
                    info.ZhiFuStatus = (EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus)rdr.GetByte(rdr.GetOrdinal("ZhiFuStatus"));

                    int zhiFuFangShi = rdr.GetInt32(rdr.GetOrdinal("ZhiFuFangShi"));
                    if (zhiFuFangShi > -1 && info.ZhiFuStatus == EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.已付款) info.ZhiFuFangShi = (EyouSoft.Model.Enum.ZhiFuFangShi)zhiFuFangShi;

                    info.HuiYuanName = rdr["HuiYuanName"].ToString();
                    info.HuiYuanYongHuMing = rdr["HuiYuanYongHuMing"].ToString();
                }
            }

            return info;
        }     /// <summary>
        /// 设置支付状态，返回1成功，其它失败
        /// </summary>
        /// <param name="DingDanId">订单编号</param>
        /// <param name="zhiFuStatus">支付状态</param>
        /// <param name="zhiFuFangShi">支付方式</param>
        /// <returns></returns>
        public int SheZhiZhiFuStatus(string DingDanId, EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus zhiFuStatus, EyouSoft.Model.Enum.ZhiFuFangShi zhiFuFangShi)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_ChongZhi_SheZhiStatus");

            _db.AddInParameter(cmd, "@DingDanId", DbType.AnsiStringFixedLength, DingDanId);
            _db.AddInParameter(cmd, "@ZhiFuStatus", DbType.Byte, zhiFuStatus);
            _db.AddInParameter(cmd, "@ZhiFuFangShi", DbType.Byte, zhiFuFangShi);
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

            int dbRetCode = Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));

            return dbRetCode;
        }

        /// <summary>
        /// 获取充值信息集合
        /// </summary>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.OtherStructure.MChongZhi> GetChongZhis(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.OtherStructure.MChongZhiChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.OtherStructure.MChongZhi> items = new List<EyouSoft.Model.OtherStructure.MChongZhi>();

            string fields = "*";
            StringBuilder sql = new StringBuilder();
            string tableName = "view_ChongZhi";
            string orderByString = " IssueTime DESC ";
            string sumString = "";

            sql.AppendFormat(" 1=1 ");

            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.HuiYuanId))
                {
                    sql.AppendFormat(" AND HuiYuanId='{0}' ", chaXun.HuiYuanId);
                }
                if (chaXun.ChongZhiShiJian1.HasValue)
                {
                    sql.AppendFormat(" AND Issuetime>'{0}' ", chaXun.ChongZhiShiJian1.Value);
                }
                if (chaXun.ChongZhiShiJian2.HasValue)
                {
                    sql.AppendFormat(" AND Issuetime<'{0}' ", chaXun.ChongZhiShiJian2.Value.AddDays(1));
                }
                if (chaXun.JinE1.HasValue)
                {
                    sql.AppendFormat(" AND JinE>={0} ", chaXun.JinE1.Value);
                }
                if (chaXun.JinE2.HasValue)
                {
                    sql.AppendFormat(" AND JinE<={0} ", chaXun.JinE2.Value);
                }
            }

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), sql.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.OtherStructure.MChongZhi();

                    info.DingDanId = rdr["DingDanId"].ToString();
                    info.HuiYuanId = rdr.GetString(rdr.GetOrdinal("HuiYuanId"));
                    info.JinE = rdr.GetDecimal(rdr.GetOrdinal("JinE"));
                    info.Issuetime = rdr.GetDateTime(rdr.GetOrdinal("Issuetime"));
                    info.JiaoYiHao = rdr.GetString(rdr.GetOrdinal("JiaoYiHao"));
                    info.ZhiFuStatus = (EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus)rdr.GetByte(rdr.GetOrdinal("ZhiFuStatus"));

                    int zhiFuFangShi = rdr.GetInt32(rdr.GetOrdinal("ZhiFuFangShi"));
                    if (zhiFuFangShi > -1 && info.ZhiFuStatus == EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.已付款) info.ZhiFuFangShi = (EyouSoft.Model.Enum.ZhiFuFangShi)zhiFuFangShi;

                    info.HuiYuanName = rdr["HuiYuanName"].ToString();
                    info.HuiYuanYongHuMing = rdr["HuiYuanYongHuMing"].ToString();

                    items.Add(info);
                }
            }

            return items;
        }
    }
}
