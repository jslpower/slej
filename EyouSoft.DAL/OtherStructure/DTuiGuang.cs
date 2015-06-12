//返联盟推广信息相关DAL 汪奇志 2014-11-04
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
    /// 返联盟推广信息相关DAL
    /// </summary>
    public class DTuiGuang : DALBase,EyouSoft.IDAL.OtherStructure.ITuiGuang
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
        public DTuiGuang()
        {
            _db = SystemStore;
        }
        #endregion

        #region private members
        #endregion

        #region ITuiGuang 成员
        /// <summary>
        /// 写入返联盟推广来源信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int TuiGuangLaiYuan_C(EyouSoft.Model.OtherStructure.MTuiGuangLaiYuanInfo info)
        {
            var cmd = _db.GetSqlStringCommand("INSERT INTO [tbl_TuiGuangLaiYuan]([XinXiId],[TuiGuangId],[IssueTime],[LaiYuan])VALUES(@XinXiId,@TuiGuangId,@IssueTime,@LaiYuan)");
            _db.AddInParameter(cmd, "XinXiId", DbType.AnsiStringFixedLength, info.XinXiId);
            _db.AddInParameter(cmd, "TuiGuangId", DbType.AnsiStringFixedLength, info.TuiGuangId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "LaiYuan", DbType.String, info.LaiYuan);

            DbHelper.ExecuteSql(cmd, _db);

            return 1;
        }

        /// <summary>
        /// 写入返联盟推广返利信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int TuiGuangFanLi_C(EyouSoft.Model.OtherStructure.MTuiGuangFanLiInfo info)
        {
            var cmd = _db.GetStoredProcCommand("proc_FanLianMengTuiGuangFanLi_C");

            _db.AddInParameter(cmd, "@FanLiId", DbType.AnsiStringFixedLength, info.FanLiId);
            _db.AddInParameter(cmd, "@TuiGuangId", DbType.AnsiStringFixedLength, info.TuiGuangId);
            _db.AddInParameter(cmd, "@DingDanId", DbType.AnsiStringFixedLength, info.DingDanId);
            _db.AddInParameter(cmd, "@DingDanLeiXing", DbType.Byte, info.DingDanLeiXing);
            _db.AddInParameter(cmd, "@XiaDanRenId", DbType.AnsiStringFixedLength, info.XiaDanRenId);
            _db.AddInParameter(cmd, "@FanLiBiLi", DbType.Currency, info.FanLiBiLi);
            _db.AddInParameter(cmd, "@IssueTime", DbType.DateTime, info.IssueTime);
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

        /// <summary>
        /// 设置返联盟推广返利比例，返回1成功，其它失败
        /// </summary>
        /// <param name="items">集合</param>
        /// <returns></returns>
        public int SheZhiTuiGuangFanLiBiLi(IList<EyouSoft.Model.OtherStructure.MTuiGuangFanLiBiLiInfo> items)
        {
            var cmd=_db.GetSqlStringCommand("SELECT 1");

            StringBuilder s = new StringBuilder();
            s.Append("DELETE FROM tbl_TuiGuangFanLiBiLi;");
            if (items != null && items.Count > 0)
            {
                int i=0;
                foreach (var item in items)
                {
                    s.AppendFormat(" INSERT INTO tbl_TuiGuangFanLiBiLi(JinE,BiLi)VALUES(@JinE{0},@BiLi{0}) ",i);

                    _db.AddInParameter(cmd, "JinE" + i, DbType.Currency, item.JinE);
                    _db.AddInParameter(cmd, "BiLi" + i, DbType.Currency, item.BiLi);

                    i++;
                }
            }
            cmd.CommandText = s.ToString();

            DbHelper.ExecuteSql(cmd, _db);

            return 1;
        }

        /// <summary>
        /// 获取返联盟推广返利比例集合
        /// </summary>
        /// <returns></returns>
        public IList<EyouSoft.Model.OtherStructure.MTuiGuangFanLiBiLiInfo> GetTuiGuangFanLiBiLis()
        {
            IList<EyouSoft.Model.OtherStructure.MTuiGuangFanLiBiLiInfo> items = new List<EyouSoft.Model.OtherStructure.MTuiGuangFanLiBiLiInfo>();
            var cmd = _db.GetSqlStringCommand("SELECT * FROM tbl_TuiGuangFanLiBiLi ORDER BY JinE ASC");

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.OtherStructure.MTuiGuangFanLiBiLiInfo();

                    item.BiLi = rdr.GetDecimal(rdr.GetOrdinal("BiLi"));
                    item.IdentityId = rdr.GetInt32(rdr.GetOrdinal("IdentityId"));
                    item.JinE = rdr.GetDecimal(rdr.GetOrdinal("JinE"));

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取会员推广信息业务实体
        /// </summary>
        /// <param name="huiYuanId">会员编号</param>
        /// <returns></returns>
        public EyouSoft.Model.OtherStructure.MHuiYuanTuiGuangInfo GetHuiYuanTuiGuangInfo(string huiYuanId)
        {
            EyouSoft.Model.OtherStructure.MHuiYuanTuiGuangInfo info = null;
            var cmd = _db.GetSqlStringCommand("SELECT A.TuiGuangId,B.WebSite AS YuMing FROM tbl_Member AS A LEFT OUTER JOIN tbl_JA_Sellers AS B ON A.MemberID=B.MemberID WHERE A.MemberID=@HuiYuanId");
            _db.AddInParameter(cmd, "HuiYuanId", DbType.AnsiStringFixedLength, huiYuanId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new EyouSoft.Model.OtherStructure.MHuiYuanTuiGuangInfo();
                    info.TuiGuangId = rdr["TuiGuangId"].ToString();
                    info.TuiGuangYuMing = rdr["YuMing"].ToString();
                }
            }

            return info;
        }

        /// <summary>
        /// 获取返联盟推广返利信息集合
        /// </summary>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.OtherStructure.MTuiGuangFanLiInfo> GetTuiGuangFanLis(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.OtherStructure.MTuiGuangFanLiChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.OtherStructure.MTuiGuangFanLiInfo> items = new List<EyouSoft.Model.OtherStructure.MTuiGuangFanLiInfo>();

            string fields = "*";
            StringBuilder sql = new StringBuilder();
            string tableName = "view_TuiGuangFanLi";
            string orderByString = " IssueTime DESC ";
            string sumString = "";

            sql.AppendFormat(" 1=1 ");

            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.TuiGuanRenHuiYuanId))
                {
                    sql.AppendFormat(" AND TuiGuangRenHuiYuanId='{0}' ", chaXun.TuiGuanRenHuiYuanId);
                }
                if (chaXun.FanLiStatus.HasValue)
                {
                    sql.AppendFormat(" AND FanLiStatus={0} ", (int)chaXun.FanLiStatus.Value);
                }
                if (chaXun.XiaDanShiJian1.HasValue)
                {
                    sql.AppendFormat(" AND XiaDanShiJian>'{0}' ", chaXun.XiaDanShiJian1.Value);
                }
                if (chaXun.XiaDanShiJian2.HasValue)
                {
                    sql.AppendFormat(" AND XiaDanShiJian<'{0}' ", chaXun.XiaDanShiJian2.Value.AddDays(1));
                }
            }

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), sql.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.OtherStructure.MTuiGuangFanLiInfo();

                    item.CPName = rdr["CPName"].ToString();
                    item.DingDanDaiLiShangId = rdr["DingDanDaiLiShangId"].ToString();
                    item.DingDanDaiLiShangWangZhanName = rdr["DingDanDaiLiShangWangZhanName"].ToString();
                    item.DingDanFuKuanStatus = (EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus)rdr.GetByte(rdr.GetOrdinal("DingDanFuKuanStatus"));
                    item.DingDanId = rdr["DingDanId"].ToString();
                    item.DingDanJinE = rdr.GetDecimal(rdr.GetOrdinal("DingDanJinE"));
                    item.DingDanLeiXing = (EyouSoft.Model.OtherStructure.DingDanType)rdr.GetByte(rdr.GetOrdinal("DingDanLeiXing"));
                    item.DingDanStatus = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)rdr.GetByte(rdr.GetOrdinal("DingDanStatus"));
                    item.FanLiBiLi = rdr.GetDecimal(rdr.GetOrdinal("FanLiBiLi"));
                    item.FanLiId = rdr["FanLiId"].ToString();
                    item.FanLiJinE = rdr.GetDecimal(rdr.GetOrdinal("FanLiJinE"));
                    item.FanLiStatus = (EyouSoft.Model.Enum.FanLianMengTuiGuangFanLiStatus)rdr.GetByte(rdr.GetOrdinal("FanLiStatus"));
                    item.FanLiShiJian = rdr.GetDateTime(rdr.GetOrdinal("FanLiShiJian"));
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("FanLiShiJian"));
                    item.TuiGuangId = rdr["TuiGuangId"].ToString();
                    item.TuiGuangRenHuiYuanId = rdr["TuiGuangRenHuiYuanId"].ToString();
                    item.XiaDanRenId = rdr["XiaDanRenId"].ToString();
                    item.XiaDanRenName = rdr["XiaDanRenName"].ToString();
                    item.XiaDanShiJian = rdr.GetDateTime(rdr.GetOrdinal("XiaDanShiJian"));
                    item.FanLiJiaoYiHao = rdr["FanLiJiaoYiHao"].ToString();
                    item.TuiGuangRenName = rdr["TuiGuangRenName"].ToString();

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 设置返联盟推广返利状态，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="dingDanLeiXing">订单类型</param>
        /// <param name="fanLiSatus">返利状态</param>
        /// <param name="shiJian">操作时间</param>
        /// <param name="fanLiId">返利编号（OUTPUT）</param>
        /// <returns></returns>
        public int SheZhiTuiGuangFanLiStatus(string dingDanId, EyouSoft.Model.OtherStructure.DingDanType dingDanLeiXing, EyouSoft.Model.Enum.FanLianMengTuiGuangFanLiStatus fanLiSatus, DateTime shiJian,out string fanLiId)
        {
            fanLiId = string.Empty;
            var cmd = _db.GetStoredProcCommand("proc_FanLianMengTuiGuangFanLi_ShiZhiStatus");

            _db.AddInParameter(cmd, "DingDanId", DbType.AnsiStringFixedLength, dingDanId);
            _db.AddInParameter(cmd, "DingDanLeiXing", DbType.Byte, dingDanLeiXing);
            _db.AddInParameter(cmd, "FanLiStatus", DbType.Byte, fanLiSatus);
            _db.AddInParameter(cmd, "FanLiShiJian", DbType.DateTime, shiJian);
            _db.AddOutParameter(cmd, "RetCode", DbType.Int32, 4);
            _db.AddOutParameter(cmd, "FanLiId", DbType.String, 36);

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
                fanLiId = _db.GetParameterValue(cmd, "FanLiId").ToString();
            }

            return dbRetCode;
        }

        /// <summary>
        /// 获取推广返利信息
        /// </summary>
        /// <param name="fanLiId">返利编号</param>
        /// <returns></returns>
        public EyouSoft.Model.OtherStructure.MTuiGuangFanLiInfo GetTuiGuangFanLiInfo(string fanLiId)
        {
            EyouSoft.Model.OtherStructure.MTuiGuangFanLiInfo item = null;
            var cmd = _db.GetSqlStringCommand("SELECT * FROM view_TuiGuangFanLi WHERE FanLiId=@FanLiId");
            _db.AddInParameter(cmd, "FanLiId", DbType.AnsiStringFixedLength, fanLiId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    item = new EyouSoft.Model.OtherStructure.MTuiGuangFanLiInfo();

                    item.CPName = rdr["CPName"].ToString();
                    item.DingDanDaiLiShangId = rdr["DingDanDaiLiShangId"].ToString();
                    item.DingDanDaiLiShangWangZhanName = rdr["DingDanDaiLiShangWangZhanName"].ToString();
                    item.DingDanFuKuanStatus = (EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus)rdr.GetByte(rdr.GetOrdinal("DingDanFuKuanStatus"));
                    item.DingDanId = rdr["DingDanId"].ToString();
                    item.DingDanJinE = rdr.GetDecimal(rdr.GetOrdinal("DingDanJinE"));
                    item.DingDanLeiXing = (EyouSoft.Model.OtherStructure.DingDanType)rdr.GetByte(rdr.GetOrdinal("DingDanLeiXing"));
                    item.DingDanStatus = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)rdr.GetByte(rdr.GetOrdinal("DingDanStatus"));
                    item.FanLiBiLi = rdr.GetDecimal(rdr.GetOrdinal("FanLiBiLi"));
                    item.FanLiId = rdr["FanLiId"].ToString();
                    item.FanLiJinE = rdr.GetDecimal(rdr.GetOrdinal("FanLiJinE"));
                    item.FanLiStatus = (EyouSoft.Model.Enum.FanLianMengTuiGuangFanLiStatus)rdr.GetByte(rdr.GetOrdinal("FanLiStatus"));
                    item.FanLiShiJian = rdr.GetDateTime(rdr.GetOrdinal("FanLiShiJian"));
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("FanLiShiJian"));
                    item.TuiGuangId = rdr["TuiGuangId"].ToString();
                    item.TuiGuangRenHuiYuanId = rdr["TuiGuangRenHuiYuanId"].ToString();
                    item.XiaDanRenId = rdr["XiaDanRenId"].ToString();
                    item.XiaDanRenName = rdr["XiaDanRenName"].ToString();
                    item.XiaDanShiJian = rdr.GetDateTime(rdr.GetOrdinal("XiaDanShiJian"));
                    item.FanLiJiaoYiHao = rdr["FanLiJiaoYiHao"].ToString();
                    item.TuiGuangRenName = rdr["TuiGuangRenName"].ToString();

                }
            }

            return item;
        }
        #endregion

        #region
        /// <summary>
        /// 写入分销奖励比，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int FenXiaoJiangli_C(EyouSoft.Model.OtherStructure.MJiangJiBi info)
        {
            var cmd = _db.GetSqlStringCommand("INSERT INTO [tbl_JiangLiBi]([DingDanId],[OrderType],[JiangLiBiLi])VALUES(@DingDanId,@OrderType,@JiangLiBiLi)");
            _db.AddInParameter(cmd, "DingDanId", DbType.AnsiStringFixedLength, info.DingDanId);
            _db.AddInParameter(cmd, "OrderType", DbType.Int32, info.OrderType);
            _db.AddInParameter(cmd, "JiangLiBiLi", DbType.Decimal, info.JiangLiBiLi);

            DbHelper.ExecuteSql(cmd, _db);

            return 1;
        }

        #endregion
    }
}
