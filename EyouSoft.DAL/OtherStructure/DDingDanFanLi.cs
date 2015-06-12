//订单返利信息DAL 汪奇志 2014-11-06
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit.DAL;
using EyouSoft.Toolkit;

namespace EyouSoft.DAL.OtherStructure
{
    /// <summary>
    /// 订单返利信息DAL 
    /// </summary>
    public class DDingDanFanLi : DALBase, EyouSoft.IDAL.OtherStructure.IDingDanFanLi
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
        public DDingDanFanLi()
        {
            _db = SystemStore;
        }
        #endregion

        #region private members
        #endregion

        #region IDingDanFanLi 成员
        /// <summary>
        /// 订单返利信息新增，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int DingDanFanLi_C(EyouSoft.Model.OtherStructure.MDingDanFanLiInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_DingDanFanLi_C");

            _db.AddInParameter(cmd, "@FanLiId", DbType.AnsiStringFixedLength, info.FanLiId);
            _db.AddInParameter(cmd, "@HuiYuanId", DbType.AnsiStringFixedLength, info.HuiYuanId);
            _db.AddInParameter(cmd, "@DingDanId", DbType.AnsiStringFixedLength, info.DingDanId);
            _db.AddInParameter(cmd, "@DingDanLeiXing", DbType.Byte, info.DingDanLeiXing);
            _db.AddInParameter(cmd, "@DingDanJinE", DbType.Currency, info.DingDanJinE);
            _db.AddInParameter(cmd, "@FenXiaoJinE", DbType.Currency, info.FenXiaoJinE);
            _db.AddInParameter(cmd, "@FanLiJinE", DbType.Currency, info.FanLiJinE);
            _db.AddInParameter(cmd, "@IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddOutParameter(cmd, "@FanLiJiaoYiHao", DbType.String, 50);
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

            int dbRetCode = Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));

            if (dbRetCode == 1)
            {
                info.FanLiJiaoYiHao = _db.GetParameterValue(cmd, "FanLiJiaoYiHao").ToString();
            }

            return dbRetCode;
        }

        /// <summary>
        /// 获取订单返利信息集合
        /// </summary>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.OtherStructure.MDingDanFanLiInfo> GetDingDanFanLis(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.OtherStructure.MDingDanFanLiChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.OtherStructure.MDingDanFanLiInfo> items = new List<EyouSoft.Model.OtherStructure.MDingDanFanLiInfo>();
            string fields = "*";
            StringBuilder sql = new StringBuilder();
            string tableName = "view_DingDanFanLi";
            string orderByString = " IssueTime DESC ";
            string sumString = "";

            sql.AppendFormat(" 1=1 ");

            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.HuiYuanId))
                {
                    sql.AppendFormat(" AND HuiYuanId='{0}' ", chaXun.HuiYuanId);
                }
                if (chaXun.FanLiShiJian1.HasValue)
                {
                    sql.AppendFormat(" AND IssueTime>='{0}' ", chaXun.FanLiShiJian1.Value);
                }
                if (chaXun.FanLiShiJian2.HasValue)
                {
                    sql.AppendFormat(" AND IssueTime<'{0}' ", chaXun.FanLiShiJian2.Value.AddDays(1));
                }
                if (chaXun.DingDanLeiXing.HasValue)
                {
                    sql.AppendFormat(" AND DingDanLeiXing={0} ", (int)chaXun.DingDanLeiXing.Value);
                }
            }

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), sql.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.OtherStructure.MDingDanFanLiInfo();

                    info.DingDanId = rdr["DingDanId"].ToString();
                    info.DingDanJinE = rdr.GetDecimal(rdr.GetOrdinal("DingDanJinE"));
                    info.DingDanLeiXing = (EyouSoft.Model.OtherStructure.DingDanType)rdr.GetByte(rdr.GetOrdinal("DingDanLeiXing"));
                    info.FanLiId = rdr["FanLiId"].ToString();
                    info.FanLiJiaoYiHao = rdr["FanLiJiaoYiHao"].ToString();
                    info.FanLiJinE = rdr.GetDecimal(rdr.GetOrdinal("FanLiJinE"));
                    info.FenXiaoJinE = rdr.GetDecimal(rdr.GetOrdinal("FenXiaoJinE"));
                    info.HuiYuanDaiLiShangId = rdr["HuiYuanDaiLiShangId"].ToString();
                    info.HuiYuanDaiLiShangWangZhanName = rdr["HuiYuanDaiLiShangWangZhanName"].ToString();
                    info.HuiYuanId = rdr["HuiYuanId"].ToString();
                    info.HuiYuanName = rdr["HuiYuanName"].ToString();
                    info.HuiYuanYongHuMing = rdr["HuiYuanYongHuMing"].ToString();
                    info.HuiYuanYuE = rdr.GetDecimal(rdr.GetOrdinal("HuiYuanYuE"));
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.YuE = rdr.GetDecimal(rdr.GetOrdinal("YuE"));

                    items.Add(info);
                }
            }
            return items;
        }

        #endregion
    }
}
