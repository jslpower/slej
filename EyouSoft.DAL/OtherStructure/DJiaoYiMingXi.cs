//交易明细信息相关DAL 汪奇志 2014-11-06
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
    public class DJiaoYiMingXi : DALBase, EyouSoft.IDAL.OtherStructure.IJiaoYiMingXi
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
        public DJiaoYiMingXi()
        {
            _db = SystemStore;
        }
        #endregion

        #region private members
        #endregion

        #region IJiaoYiMingXi 成员
        /// <summary>
        /// 写入交易明细信息业务实体，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int JiaoYiMingXi_C(EyouSoft.Model.OtherStructure.MJiaoYiMingXiInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_JiaoYiMingXi_C");

            _db.AddInParameter(cmd, "MingXiId", DbType.AnsiStringFixedLength, info.MingXiId);
            _db.AddInParameter(cmd, "HuiYuanId", DbType.AnsiStringFixedLength, info.HuiYuanId);
            _db.AddInParameter(cmd, "JiaoYiHao", DbType.String, info.JiaoYiHao);
            _db.AddInParameter(cmd, "JiaoYiJinE", DbType.Decimal, info.JiaoYiJinE);
            _db.AddInParameter(cmd, "JiaoYiShiJian", DbType.DateTime, info.JiaoYiShiJian);
            _db.AddInParameter(cmd, "ZhiFuFangShi", DbType.Byte, info.ZhiFuFangShi);
            _db.AddInParameter(cmd, "JiaoYiLeiBie", DbType.Byte, info.JiaoYiLeiBie);
            _db.AddInParameter(cmd, "JiaoYiStatus", DbType.Byte, info.JiaoYiStatus);
            _db.AddInParameter(cmd, "JiaoYiMiaoShu", DbType.String, info.JiaoYiMiaoShu);
            _db.AddInParameter(cmd, "DingDanId", DbType.AnsiStringFixedLength, info.DingDanId);
            _db.AddInParameter(cmd, "DingDanLeiXing", DbType.Byte, info.DingDanLeiXing);
            _db.AddInParameter(cmd, "ApiJiaoYiHao", DbType.String, info.ApiJiaoYiHao);
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
        /// 获取交易明细信息集合
        /// </summary>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.OtherStructure.MJiaoYiMingXiInfo> GetJiaoYiMingXis(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.OtherStructure.MJiaoYiMingXiChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.OtherStructure.MJiaoYiMingXiInfo> items = new List<EyouSoft.Model.OtherStructure.MJiaoYiMingXiInfo>();

            string fields = "*";
            StringBuilder sql = new StringBuilder();
            string tableName = "view_JiaoYiMingXi";
            string orderByString = " JiaoYiShiJian DESC ";
            string sumString = "";

            sql.AppendFormat(" 1=1 ");

            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.HuiYuanId))
                {
                    sql.AppendFormat(" AND HuiYuanId='{0}' ", chaXun.HuiYuanId);
                }
                if (chaXun.ZhiFuFangShi.HasValue)
                {
                    sql.AppendFormat(" AND ZhiFuFangShi={0} ", (int)chaXun.ZhiFuFangShi);
                }
                if (chaXun.JiaoYiShiJian1.HasValue)
                {
                    sql.AppendFormat(" AND JiaoYiShiJian>='{0}' ", chaXun.JiaoYiShiJian1.Value);
                }
                if (chaXun.JiaoYiShiJian2.HasValue)
                {
                    sql.AppendFormat(" AND JiaoYiShiJian<'{0}' ", chaXun.JiaoYiShiJian2.Value.AddDays(1));
                }
            }

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), sql.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.OtherStructure.MJiaoYiMingXiInfo();

                    info.ApiJiaoYiHao = rdr["ApiJiaoYiHao"].ToString();
                    info.DingDanId = rdr["DingDanId"].ToString();
                    info.DingDanLeiXing = (EyouSoft.Model.Enum.DingDanLeiBie)rdr.GetInt32(rdr.GetOrdinal("DingDanLeiXing"));
                    info.HuiYuanEYuE = rdr.GetDecimal(rdr.GetOrdinal("HuiYuanEYuE"));
                    info.HuiYuanId = rdr["HuiYuanId"].ToString();
                    info.HuiYuanName = rdr["HuiYuanName"].ToString();
                    info.HuiYuanYongHuMing = rdr["HuiYuanYongHuMing"].ToString();
                    info.JiaoYiHao = rdr["JiaoYiHao"].ToString();
                    info.JiaoYiJinE = rdr.GetDecimal(rdr.GetOrdinal("JiaoYiJinE"));
                    info.JiaoYiLeiBie = (EyouSoft.Model.Enum.JiaoYiLeiBie)rdr.GetByte(rdr.GetOrdinal("JiaoYiLeiBie"));
                    info.JiaoYiMiaoShu = rdr["JiaoYiMiaoShu"].ToString();
                    info.JiaoYiShiJian = rdr.GetDateTime(rdr.GetOrdinal("JiaoYiShiJian"));
                    info.JiaoYiStatus = (EyouSoft.Model.Enum.JiaoYiStatus)rdr.GetByte(rdr.GetOrdinal("JiaoYiStatus"));
                    info.MingXiId = rdr["MingXiId"].ToString();
                    info.ZhiFuFangShi = (EyouSoft.Model.Enum.ZhiFuFangShi)rdr.GetByte(rdr.GetOrdinal("ZhiFuFangShi"));

                    items.Add(info);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取系统余额信息业务实体
        /// </summary>
        /// <returns></returns>
        public EyouSoft.Model.OtherStructure.MYuEInfo GetYuEInfo()
        {
            var info = new EyouSoft.Model.OtherStructure.MYuEInfo();
            var cmd = _db.GetSqlStringCommand("SELECT * FROM tbl_YuE");

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info.EEBaoYuE = rdr.GetDecimal(rdr.GetOrdinal("EEBaoYuE"));
                    info.KuaiQianYuE = rdr.GetDecimal(rdr.GetOrdinal("KuaiQianYuE"));
                    info.YuE = rdr.GetDecimal(rdr.GetOrdinal("YuE"));
                }
            }

            return info;
        }
        

        /// <summary>
        /// 设置明细状态，返回1成功，其它失败
        /// </summary>
        /// <param name="huiYuanId">会员编号</param>
        /// <param name="dingDanId">交易订单编号</param>
        /// <param name="dingDanLeiXing">交易订单类型</param>
        /// <param name="jiaoYiLeiBie">交易类别</param>
        /// <param name="zhiFuFangShi">交易支付方式</param>
        /// <param name="jiaoYiStatus">交易状态</param>
        /// <returns></returns>
        public int SheZhiMingXiStatus(string huiYuanId, string dingDanId, EyouSoft.Model.Enum.DingDanLeiBie dingDanLeiXing, EyouSoft.Model.Enum.JiaoYiLeiBie jiaoYiLeiBie, EyouSoft.Model.Enum.ZhiFuFangShi zhiFuFangShi, EyouSoft.Model.Enum.JiaoYiStatus jiaoYiStatus)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_JiaoYiMingXi_SheZhiStatus");

            _db.AddInParameter(cmd, "@HuiYuanId", DbType.AnsiStringFixedLength, huiYuanId);
            _db.AddInParameter(cmd, "@ZhiFuFangShi", DbType.Byte, zhiFuFangShi);
            _db.AddInParameter(cmd, "@JiaoYiLeiBie", DbType.Byte, jiaoYiLeiBie);
            _db.AddInParameter(cmd, "@JiaoYiStatus", DbType.Byte, jiaoYiStatus);
            _db.AddInParameter(cmd, "@DingDanId", DbType.AnsiStringFixedLength, dingDanId);
            _db.AddInParameter(cmd, "@DingDanLeiXing", DbType.Byte, dingDanLeiXing);
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
        /// 是否支付，返回1已支付，返回0未支付，其它为异常
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="dingDanLeiXing">订单类型</param>
        /// <returns></returns>
        public int IsZhiFu(string dingDanId, EyouSoft.Model.Enum.DingDanLeiBie dingDanLeiXing)
        {
            int dalRetCode = 0;
            var cmd = _db.GetSqlStringCommand("SELECT COUNT(*) FROM tbl_JA_Account WHERE OrderID=@DingDanId AND OrderType=@DingDanLeiXing AND TransactionState=@JiaoYiStatus");
            _db.AddInParameter(cmd, "DingDanId", DbType.AnsiStringFixedLength, dingDanId);
            _db.AddInParameter(cmd, "DingDanLeiXing", DbType.Byte, dingDanLeiXing);
            _db.AddInParameter(cmd, "JiaoYiStatus", DbType.Byte, EyouSoft.Model.Enum.JiaoYiStatus.交易成功);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    dalRetCode = rdr.GetInt32(0);
                }
            }

            return dalRetCode;
        }
        #endregion
    }
}
