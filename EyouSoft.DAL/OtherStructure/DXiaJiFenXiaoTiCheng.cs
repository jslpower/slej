//下级分销提成信息相关DAL 汪奇志 2014-10-30
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
    /// 下级分销提成信息相关DAL
    /// </summary>
    public class DXiaJiFenXiaoTiCheng: DALBase, EyouSoft.IDAL.OtherStructure.IXiaJiFenXiaoTiCheng
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
        public DXiaJiFenXiaoTiCheng()
        {
            _db = SystemStore;
        }
        #endregion

        #region private members
        #endregion

        #region IXiaJiFenXiaoTiCheng 成员
        /// <summary>
        /// 下级分销提成申请，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int XiaJiFenXiaoTiCheng_C(EyouSoft.Model.OtherStructure.MXiaJiFenXiaoTiChengInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_XiaJiFenXiaoTiCheng_C");

            _db.AddInParameter(cmd, "@TiChengId", DbType.AnsiStringFixedLength, info.TiChengId);
            _db.AddInParameter(cmd, "@HuiYuanId", DbType.AnsiStringFixedLength, info.HuiYuanId);
            _db.AddInParameter(cmd, "@YongJinJinE", DbType.Decimal, info.YongJinJinE);
            _db.AddInParameter(cmd, "@BiLi", DbType.Decimal, info.BiLi);
            _db.AddInParameter(cmd, "@JinE", DbType.Decimal, info.JinE);
            _db.AddInParameter(cmd, "@ShiJian", DbType.DateTime, info.ShiJian);
            _db.AddInParameter(cmd, "@Status", DbType.Byte, info.Status);
            _db.AddOutParameter(cmd, "RetCode", DbType.Int32, 4);
            _db.AddOutParameter(cmd, "JiaoYiHao", DbType.String, 50);

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
                info.JiaoYiHao = _db.GetParameterValue(cmd, "JiaoYiHao").ToString();
            }

            return dbRetCode;
        }

        /// <summary>
        /// 获取下级分销提成实体
        /// </summary>
        /// <param name="tiChengId">提成编号</param>
        /// <returns></returns>
        public EyouSoft.Model.OtherStructure.MXiaJiFenXiaoTiChengInfo GetInfo(string tiChengId)
        {
            EyouSoft.Model.OtherStructure.MXiaJiFenXiaoTiChengInfo info = null;
            var cmd = _db.GetSqlStringCommand("SELECT * FROM [tbl_HuiYuanXiaJiFenXiaoTiCheng] WHERE TiChengId=@TiChengId");
            _db.AddInParameter(cmd, "TiChengId", DbType.AnsiStringFixedLength, tiChengId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new EyouSoft.Model.OtherStructure.MXiaJiFenXiaoTiChengInfo();

                    info.BiLi = rdr.GetDecimal(rdr.GetOrdinal("BiLi"));
                    info.HuiYuanId = rdr["HuiYuanId"].ToString();
                    info.JinE = rdr.GetDecimal(rdr.GetOrdinal("JinE"));
                    info.ShiJian = rdr.GetDateTime(rdr.GetOrdinal("ShiJian"));
                    info.Status = (EyouSoft.Model.Enum.XiaJiFenXiaoTiChengStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    info.TiChengId = tiChengId;
                    info.YongJinJinE = rdr.GetDecimal(rdr.GetOrdinal("YongJinJinE"));
                    info.ZhuanZhangCaoZuoRenId = rdr.GetInt32(rdr.GetOrdinal("ZhuanZhangCaoZuoRenId"));
                    info.ZhuanZhangShiJian = rdr.GetDateTime(rdr.GetOrdinal("ZhuanZhangShiJian"));
                    info.JiaoYiHao = rdr["JiaoYiHao"].ToString();

                }
            }

            return info;
        }

        /// <summary>
        /// 获取下级分销提成集合
        /// </summary>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.OtherStructure.MXiaJiFenXiaoTiChengInfo> GetTiChengs(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.OtherStructure.MXiaJiFenXiaoTiChengChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.OtherStructure.MXiaJiFenXiaoTiChengInfo> items = new List<EyouSoft.Model.OtherStructure.MXiaJiFenXiaoTiChengInfo>();

            string fields = "*";
            StringBuilder sql = new StringBuilder();
            string tableName = "view_HuiYuanXiaJiFenXiaoTiCheng";
            string orderByString = " ShiJian DESC ";
            string sumString = "";

            sql.AppendFormat(" 1=1 ");

            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.HuiYuanId))
                {
                    sql.AppendFormat(" AND HuiYuanId='{0}' ", chaXun.HuiYuanId);
                }
            }

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), sql.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.OtherStructure.MXiaJiFenXiaoTiChengInfo();

                    info.BiLi = rdr.GetDecimal(rdr.GetOrdinal("BiLi"));
                    info.HuiYuanId = rdr["HuiYuanId"].ToString();
                    info.JinE = rdr.GetDecimal(rdr.GetOrdinal("JinE"));
                    info.ShiJian = rdr.GetDateTime(rdr.GetOrdinal("ShiJian"));
                    info.Status = (EyouSoft.Model.Enum.XiaJiFenXiaoTiChengStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    info.TiChengId = rdr["TiChengId"].ToString();
                    info.YongJinJinE = rdr.GetDecimal(rdr.GetOrdinal("YongJinJinE"));
                    info.ZhuanZhangCaoZuoRenId = rdr.GetInt32(rdr.GetOrdinal("ZhuanZhangCaoZuoRenId"));
                    info.ZhuanZhangShiJian = rdr.GetDateTime(rdr.GetOrdinal("ZhuanZhangShiJian"));
                    info.JiaoYiHao = rdr["JiaoYiHao"].ToString();
                    info.HuiYuanYongHuMing = rdr["HuiYuanYongHuMing"].ToString();
                    info.HuiYuanXingMing = rdr["HuiYuanXingMing"].ToString();

                    items.Add(info);
                }
            }

            return items;
        }

        /// <summary>
        /// 设置下级分销提成状态，返回1成功，其它失败
        /// </summary>
        /// <param name="tiChengId">提成编号</param>
        /// <param name="status">状态</param>
        /// <param name="caoZuoRenId">操作人编号</param>
        /// <returns></returns>
        public int SheZhiTiChengStatus(string tiChengId, EyouSoft.Model.Enum.XiaJiFenXiaoTiChengStatus status, string caoZuoRenId)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_XiaJiFenXiaoTiCheng_SheZhiStatus");
            _db.AddInParameter(cmd, "@TiChengId", DbType.AnsiStringFixedLength, tiChengId);
            _db.AddInParameter(cmd, "@Status", DbType.Byte, status);
            _db.AddInParameter(cmd, "@CaoZuoRenId", DbType.AnsiStringFixedLength, caoZuoRenId);
            _db.AddInParameter(cmd, "@CaoZuoShiJian", DbType.DateTime, DateTime.Now);
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

            return Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));
        }

        /// <summary>
        /// 获取会员下级分销提成金额信息
        /// </summary>
        /// <param name="huiYuanId">会员编号</param>
        /// <returns></returns>
        public EyouSoft.Model.OtherStructure.MXiaJiFenXiaoTiChengJinEInfo GetHuiYuanXiaJiFenXiaoTiChengJinEInfo(string huiYuanId)
        {
            var info = new EyouSoft.Model.OtherStructure.MXiaJiFenXiaoTiChengJinEInfo();
            DbCommand cmd = _db.GetStoredProcCommand("proc_XiaJiFenXiaoTiCheng_GetJinE");

            _db.AddInParameter(cmd, "@HuiYuanId", DbType.AnsiStringFixedLength, huiYuanId);
            _db.AddOutParameter(cmd, "@SuoYouYongJinJinE", DbType.Currency, 16);
            _db.AddOutParameter(cmd, "@YiShenQingYongJinJinE", DbType.Currency, 16);
            _db.AddOutParameter(cmd, "@YiShenQingJinE", DbType.Currency, 16);
            _db.AddOutParameter(cmd, "@YiShenPiYongJinJinE", DbType.Currency, 16);
            _db.AddOutParameter(cmd, "@YiShenPiJinE", DbType.Currency, 16);
            _db.AddOutParameter(cmd, "@ZongJinE", DbType.Currency, 16);
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

            if (sqlExceptionCode < 0) return info;

            if (Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode")) != 1) return info;

            info.SuoYouYongJinJinE = Convert.ToDecimal(_db.GetParameterValue(cmd, "SuoYouYongJinJinE"));
            info.YiShenQingYongJinJinE = Convert.ToDecimal(_db.GetParameterValue(cmd, "YiShenQingYongJinJinE"));
            info.YiShenQingJinE = Convert.ToDecimal(_db.GetParameterValue(cmd, "YiShenQingJinE"));
            info.YiShenPiYongJinJinE = Convert.ToDecimal(_db.GetParameterValue(cmd, "YiShenPiYongJinJinE"));
            info.YiShenPiJinE = Convert.ToDecimal(_db.GetParameterValue(cmd, "YiShenPiJinE"));
            info.ZongJinE = Convert.ToDecimal(_db.GetParameterValue(cmd, "ZongJinE"));

            return info;
        }
        #endregion
    }
}
