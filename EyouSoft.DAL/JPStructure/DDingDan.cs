//机票订单信息相关DAL 汪奇志 2014-11-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit.DAL;
using EyouSoft.Toolkit;
using EyouSoft.Model.JPStructure;

namespace EyouSoft.DAL.JPStructure
{
    /// <summary>
    /// 机票订单信息相关DAL
    /// </summary>
    public class DDingDan : DALBase, EyouSoft.IDAL.JPStructure.IDingDan
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
        public DDingDan()
        {
            _db = SystemStore;
        }
        #endregion

        #region private members
        /// <summary>
        /// create chengke xml
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        string CreateChengKeXml(IList<EyouSoft.Model.JPStructure.MChengKeInfo> items)
        {
            if (items == null || items.Count == 0) return string.Empty;
            StringBuilder s = new StringBuilder();

            s.Append("<root>");
            foreach (var item in items)
            {
                if (string.IsNullOrEmpty(item.XingMing) || string.IsNullOrEmpty(item.ZhengJianHao)) continue;

                s.Append("<info ");
                s.AppendFormat(" ChengKeId=\"{0}\" ", item.ChengKeId);
                s.AppendFormat(" ZhengJianLeiXing=\"{0}\" ", (int)item.ZhengJianLeiXing);
                s.AppendFormat(" ChengKeLeiXing=\"{0}\" ", (int)item.ChengKeLeiXing);
                s.AppendFormat(" ChuShengRiQi=\"{0}\" ", item.ChuShengRiQi);
                s.Append(">");
                s.AppendFormat("<XingMing><![CDATA[{0}]]></XingMing>", item.XingMing);
                s.AppendFormat("<ZhengJianHao><![CDATA[{0}]]></ZhengJianHao>", item.ZhengJianHao);
                s.Append("</info>");
            }
            s.Append("</root>");

            return s.ToString();
        }

        /// <summary>
        /// read dingdan info
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        EyouSoft.Model.JPStructure.MDingDanInfo ReadDingDanInfo(DbCommand cmd)
        {
            EyouSoft.Model.JPStructure.MDingDanInfo info = null;
            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new EyouSoft.Model.JPStructure.MDingDanInfo();

                    info.ApiDingDanId = rdr["ApiDingDanId"].ToString();
                    info.ApiJieShouFangShi = (EyouSoft.Model.JPStructure.ApiJieShouFangShi)rdr.GetInt32(rdr.GetOrdinal("ApiJieShouFangShi"));
                    info.CaiGouFanDian = rdr.GetDecimal(rdr.GetOrdinal("CaiGouFanDian"));
                    info.CangWei = rdr["CangWei"].ToString();
                    info.ChengKeLeiXing = (EyouSoft.Model.JPStructure.ChengKeLeiXing)rdr.GetInt32(rdr.GetOrdinal("ChengKeLeiXing"));
                    info.ChengKes = null;
                    info.ChengRenDingDanId = rdr["ChengRenDingDanId"].ToString();
                    info.ChuFaChengShiSanZiMa = rdr["ChuFaChengShiSanZiMa"].ToString();
                    info.ChuFaRiQi = rdr.GetDateTime(rdr.GetOrdinal("ChuFaRiQi"));
                    info.DaoDaChengShiSanZiMa = rdr["DaoDaChengShiSanZiMa"].ToString();
                    info.DaoDaShiJian = rdr["DaoDaShiJian"].ToString();
                    info.DingDanId = rdr["DingDanId"].ToString();
                    info.DingDanStatus = (EyouSoft.Model.JPStructure.DingDanStatus)rdr.GetInt32(rdr.GetOrdinal("DingDanStatus"));
                    info.DingPiaoRenShu = rdr.GetInt32(rdr.GetOrdinal("DingPiaoRenShu"));
                    info.FuKuanStatus = (EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus)rdr.GetInt32(rdr.GetOrdinal("FuKuanStatus"));
                    info.FuKuanShiJian = rdr.GetDateTime(rdr.GetOrdinal("FuKuanShiJian"));
                    info.GongPiaoShangId = rdr["GongPiaoShangId"].ToString();
                    info.HangBanHao = rdr["HangBanHao"].ToString();
                    info.HangXianLeiXing = (EyouSoft.Model.JPStructure.HangXianLeiXing)rdr.GetInt32(rdr.GetOrdinal("HangXianLeiXing"));
                    info.HuiYuanId = rdr["HuiYuanId"].ToString();
                    info.JinE = rdr.GetDecimal(rdr.GetOrdinal("JinE"));
                    info.JingXiaoShangLiRun = rdr.GetDecimal(rdr.GetOrdinal("JingXiaoShangLiRun"));
                    info.JingXiaoShangLiRunDian = rdr.GetDecimal(rdr.GetOrdinal("JingXiaoShangLiRunDian"));
                    info.KeHuYouHuiDian = rdr.GetDecimal(rdr.GetOrdinal("KeHuYouHuiDian"));
                    info.PiaoMianJiaGe = rdr.GetDecimal(rdr.GetOrdinal("PiaoMianJiaGe"));
                    info.PNR = rdr["PNR"].ToString();
                    info.QiFeiShiJian = rdr["QiFeiShiJian"].ToString();
                    info.ShiFouYunXuGengHuanPnr = (EyouSoft.Model.JPStructure.ShiFouYunXuGengHuanPnr)rdr.GetInt32(rdr.GetOrdinal("ShiFouYunXuGengHuanPnr"));
                    info.ShiFouZiDongDaiKou = (EyouSoft.Model.JPStructure.ShiFouZiDongDaiKou)rdr.GetInt32(rdr.GetOrdinal("ShiFouZiDongDaiKou"));
                    info.ShiFuDaYinXingChengDan = (EyouSoft.Model.JPStructure.ShiFuDaYinXingChengDan)rdr.GetInt32(rdr.GetOrdinal("ShiFuDaYinXingChengDan"));
                    info.ShuiFeiJinE = rdr.GetDecimal(rdr.GetOrdinal("ShuiFeiJinE"));
                    info.XiaDanShiJian = rdr.GetDateTime(rdr.GetOrdinal("XiaDanShiJian"));
                    info.ZhengCeId = rdr["ZhengCeId"].ToString();
                    info.ZhengCeLeiXing = (EyouSoft.Model.JPStructure.ZhengCeLeiXing)rdr.GetInt32(rdr.GetOrdinal("ZhengCeLeiXing"));

                    info.XiangApiFuKuanShiJian = rdr.GetDateTime(rdr.GetOrdinal("XiangApiFuKuanShiJian"));
                    info.XiangApiFuKuanStatus = (EyouSoft.Model.JPStructure.XiangApiFuKuanStatus)rdr.GetInt32(rdr.GetOrdinal("XiangApiFuKuanStatus"));
                    info.JiaoYiHao = rdr["JiaoYiHao"].ToString();
                    info.ErTongDingDanId = rdr["ErTongDingDanId"].ToString();
                }
            }

            return info;
        }
        /// <summary>
        /// 获取机票订单乘客信息
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.JPStructure.MChengKeInfo> ReadDingDanCKs(DbCommand cmd)
        {
            IList<MChengKeInfo> list = new List<MChengKeInfo>();
           
            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    EyouSoft.Model.JPStructure.MChengKeInfo info = new EyouSoft.Model.JPStructure.MChengKeInfo();

                    info.ChengKeId = rdr["ChengKeId"].ToString();
                    info.ChengKeLeiXing = (EyouSoft.Model.JPStructure.ChengKeLeiXing)rdr.GetInt32(rdr.GetOrdinal("ChengKeLeiXing"));
                    info.ChuShengRiQi = rdr.GetDateTime(rdr.GetOrdinal("ChuShengRiQi"));
                    info.XingMing = rdr["XingMing"].ToString();
                    info.ZhengJianHao = rdr["ZhengJianHao"].ToString();
                    info.ZhengJianLeiXing = (EyouSoft.Model.JPStructure.ZhengJianLeiXing)rdr.GetInt32(rdr.GetOrdinal("ZhengJianLeiXing"));
                    list.Add(info);
                }
            }

            return list;
        }
        #endregion

        #region IDingDan 成员
        /// <summary>
        /// 创建订单，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int DingDan_C(EyouSoft.Model.JPStructure.MDingDanInfo info)
        {
            var cmd = _db.GetStoredProcCommand("proc_JiPiaoDingDan_C");

            _db.AddInParameter(cmd, "@DingDanId", DbType.AnsiStringFixedLength, info.DingDanId);
            _db.AddInParameter(cmd, "@ApiDingDanId", DbType.String, info.ApiDingDanId);
            _db.AddInParameter(cmd, "@GongPiaoShangId", DbType.String, info.GongPiaoShangId);
            _db.AddInParameter(cmd, "@ZhengCeId", DbType.String, info.ZhengCeId);
            _db.AddInParameter(cmd, "@CangWei", DbType.String, info.CangWei);
            _db.AddInParameter(cmd, "@HangBanHao", DbType.String, info.HangBanHao);
            _db.AddInParameter(cmd, "@ChuFaChengShiSanZiMa", DbType.String, info.ChuFaChengShiSanZiMa);
            _db.AddInParameter(cmd, "@DaoDaChengShiSanZiMa", DbType.String, info.DaoDaChengShiSanZiMa);
            _db.AddInParameter(cmd, "@ChuFaRiQi", DbType.DateTime, info.ChuFaRiQi);
            _db.AddInParameter(cmd, "@CaiGouFanDian", DbType.Currency, info.CaiGouFanDian);
            _db.AddInParameter(cmd, "@ShiFuDaYinXingChengDan", DbType.Int32, info.ShiFuDaYinXingChengDan);
            _db.AddInParameter(cmd, "@ZhengCeLeiXing", DbType.Int32, info.ZhengCeLeiXing);
            _db.AddInParameter(cmd, "@HangXianLeiXing", DbType.Int32, info.HangXianLeiXing);
            _db.AddInParameter(cmd, "@XiaDanShiJian", DbType.DateTime, info.XiaDanShiJian);
            _db.AddInParameter(cmd, "@DingDanStatus", DbType.Int32, info.DingDanStatus);
            _db.AddInParameter(cmd, "@FuKuanStatus", DbType.Int32, info.FuKuanStatus);
            _db.AddInParameter(cmd, "@FuKuanShiJian", DbType.DateTime, info.FuKuanShiJian);
            _db.AddInParameter(cmd, "@PNR", DbType.String, info.PNR);
            _db.AddInParameter(cmd, "@KeHuYouHuiDian", DbType.Currency, info.KeHuYouHuiDian);
            _db.AddInParameter(cmd, "@JingXiaoShangLiRunDian", DbType.Currency, info.JingXiaoShangLiRunDian);
            _db.AddInParameter(cmd, "@JinE", DbType.Currency, info.JiLuJiaGe);
            _db.AddInParameter(cmd, "@JingXiaoShangLiRun", DbType.Currency, info.JingXiaoShangLiRun);
            _db.AddInParameter(cmd, "@QiFeiShiJian", DbType.String, info.QiFeiShiJian);
            _db.AddInParameter(cmd, "@DaoDaShiJian", DbType.String, info.DaoDaShiJian);
            _db.AddInParameter(cmd, "@PiaoMianJiaGe", DbType.Currency, info.PiaoMianJiaGe);
            _db.AddInParameter(cmd, "@ShuiFeiJinE", DbType.Currency, info.ShuiFeiJinE);
            _db.AddInParameter(cmd, "@DingPiaoRenShu", DbType.Int32, info.DingPiaoRenShu);
            _db.AddInParameter(cmd, "@ChengRenDingDanId", DbType.AnsiStringFixedLength, info.ChengRenDingDanId);
            _db.AddInParameter(cmd, "@ErTongDingDanId", DbType.AnsiStringFixedLength, info.ErTongDingDanId);
            _db.AddInParameter(cmd, "@HuiYuanId", DbType.AnsiStringFixedLength, info.HuiYuanId);
            _db.AddInParameter(cmd, "@ChengKeXml", DbType.String,CreateChengKeXml(info.ChengKes));
            _db.AddInParameter(cmd, "@ChengKeLeiXing", DbType.Int32, info.ChengKeLeiXing);
            _db.AddInParameter(cmd, "@ApiJieShouFangShi", DbType.Int32, info.ApiJieShouFangShi);
            _db.AddInParameter(cmd, "@ShiFouYunXuGengHuanPnr", DbType.Int32, info.ShiFouYunXuGengHuanPnr);
            _db.AddInParameter(cmd, "@ShiFouZiDongDaiKou", DbType.Int32, info.ShiFouZiDongDaiKou);
            _db.AddInParameter(cmd, "@XiangApiFuKuanStatus", DbType.Int32, info.XiangApiFuKuanStatus);
            _db.AddInParameter(cmd, "@XiangApiFuKuanShiJian", DbType.DateTime, info.XiangApiFuKuanShiJian);

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

            return dbRetCode;
        }

        /// <summary>
        /// 删除订单，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <returns></returns>
        public int DingDan_D(string dingDanId)
        {
            var cmd = _db.GetStoredProcCommand("proc_JiPiaoDingDan_D");

            _db.AddInParameter(cmd, "@DingDanId", DbType.AnsiStringFixedLength, dingDanId);
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

            return dbRetCode;
        }

        /// <summary>
        /// 获取订单信息业务实体
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <returns></returns>
        public EyouSoft.Model.JPStructure.MDingDanInfo GetInfo(string dingDanId)
        {
            EyouSoft.Model.JPStructure.MDingDanInfo info = null;
            var cmd = _db.GetSqlStringCommand("SELECT * FROM tbl_JiPiaoDingDan WHERE DingDanId=@DingDanId");
            var cmd1 = _db.GetSqlStringCommand("SELECT * FROM tbl_JiPiaoDingDanChengKe WHERE DingDanId=@DingDanId");
            _db.AddInParameter(cmd, "DingDanId", DbType.AnsiStringFixedLength, dingDanId);
            _db.AddInParameter(cmd1, "DingDanId", DbType.AnsiStringFixedLength, dingDanId);

            info = ReadDingDanInfo(cmd);
            info.ChengKes = ReadDingDanCKs(cmd1);
            return info;
        }

        /// <summary>
        /// 写入订单相关信息，返回1成功，其它失败
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public int DingDanXiangGuan_C(IList<EyouSoft.Model.JPStructure.MDingDanXiangGuanInfo> items)
        {
            #region sql
            string s = "INSERT INTO [tbl_JiPiaoDingDanXiangGuan]([DingDanId],[LeiXing],[JSON]) VALUES(@DingDanId{0},@LeiXing{0},@JSON{0});";
            StringBuilder sql = new StringBuilder();
            int i = 0;

            var cmd = _db.GetSqlStringCommand("SELECT 1");

            foreach (var item in items)
            {
                sql.AppendFormat(s, i);
                _db.AddInParameter(cmd, "DingDanId" + i, DbType.AnsiStringFixedLength, item.DingDanId);
                _db.AddInParameter(cmd, "LeiXing" + i, DbType.AnsiStringFixedLength, item.LeiXing);
                _db.AddInParameter(cmd, "JSON" + i, DbType.AnsiStringFixedLength, item.JSON);
                i++;
            }

            cmd.CommandText = sql.ToString();
            #endregion

            DbHelper.ExecuteSql(cmd, _db);

            return 1;
        }

        /// <summary>
        /// 设置订单付款状态（只允许传递成人订单编号，儿童订单会根据成人订单一起处理），返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="huiYuanId">下单人会员编号</param>
        /// <param name="fuKuanStatus">付款状态</param>
        /// <param name="fuKuanShiJian">付款时间</param>
        /// <param name="dingDanStatus">订单状态 null时订单状态原值不变</param>
        /// <returns></returns>
        public int SheZhiDingDanFuKuanStatus(string dingDanId,string huiYuanId,EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus fuKuanStatus,DateTime fuKuanShiJian,EyouSoft.Model.JPStructure.DingDanStatus? dingDanStatus)
        {
            var cmd = _db.GetStoredProcCommand("proc_JiPiaoDingDan_SheZhiFuKuanStatus");

            _db.AddInParameter(cmd, "@DingDanId", DbType.AnsiStringFixedLength, dingDanId);
            _db.AddInParameter(cmd, "@HuiYuanId", DbType.AnsiStringFixedLength, huiYuanId);
            _db.AddInParameter(cmd, "@FuKuanStatus", DbType.Int32, fuKuanStatus);
            _db.AddInParameter(cmd, "@FuKuanShiJian", DbType.DateTime, fuKuanShiJian);
            if (dingDanStatus.HasValue)
            {
                _db.AddInParameter(cmd, "@DingDanStatus", DbType.Int32, dingDanStatus);
            }
            else
            {
                _db.AddInParameter(cmd, "@DingDanStatus", DbType.Int32, DBNull.Value);
            }
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

            return dbRetCode;

        }

        /// <summary>
        /// 设置订单向API付款状态，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="xiangApiFuKuanStatus">向API付款状态</param>
        /// <param name="xiangApiFuKuanShiJian">向API付款时间</param>
        /// <param name="dingDanStatus">订单状态 null时订单状态原值不变</param>
        /// <returns></returns>
        public int SheZhiDingDanXiangApiFuKuanStatus(string dingDanId, EyouSoft.Model.JPStructure.XiangApiFuKuanStatus xiangApiFuKuanStatus, DateTime xiangApiFuKuanShiJian, EyouSoft.Model.JPStructure.DingDanStatus? dingDanStatus)
        {
            var cmd = _db.GetStoredProcCommand("proc_JiPiaoDingDan_SheZhiXiangApiFuKuanStatus");

            _db.AddInParameter(cmd, "@DingDanId", DbType.AnsiStringFixedLength, dingDanId);
            _db.AddInParameter(cmd, "@XiangApiFuKuanStatus", DbType.Int32, xiangApiFuKuanStatus);
            _db.AddInParameter(cmd, "@XiangApiFuKuanShiJian", DbType.DateTime, xiangApiFuKuanShiJian);
            if (dingDanStatus.HasValue)
            {
                _db.AddInParameter(cmd, "@DingDanStatus", DbType.Int32, dingDanStatus);
            }
            else
            {
                _db.AddInParameter(cmd, "@DingDanStatus", DbType.Int32, DBNull.Value);
            }
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

            return dbRetCode;
        }

        /// <summary>
        /// 设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="huiYuanId">会员编号</param>
        /// <param name="dingDanStatus">订单状态</param>
        /// <returns></returns>
        public int SheZhiDingDanStatus(string dingDanId, string huiYuanId, EyouSoft.Model.JPStructure.DingDanStatus dingDanStatus)
        {
            var cmd = _db.GetStoredProcCommand("proc_JiPiaoDingDan_SheZhiDingDanStatus");

            _db.AddInParameter(cmd, "@DingDanId", DbType.AnsiStringFixedLength, dingDanId);
            _db.AddInParameter(cmd, "@HuiYuanId", DbType.AnsiStringFixedLength, huiYuanId);
            _db.AddInParameter(cmd, "@DingDanStatus", DbType.Int32, dingDanStatus);
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

            return dbRetCode;
        }

        /// <summary>
        /// 获取订单信息业务实体-根据API订单编号
        /// </summary>
        /// <param name="apiDingDanId">API订单编号</param>
        /// <returns></returns>
        public EyouSoft.Model.JPStructure.MDingDanInfo GetInfoByApiDingDanId(string apiDingDanId)
        {
            EyouSoft.Model.JPStructure.MDingDanInfo info = null;
            var cmd = _db.GetSqlStringCommand("SELECT * FROM tbl_JiPiaoDingDan WHERE ApiDingDanId=@ApiDingDanId");
            _db.AddInParameter(cmd, "ApiDingDanId", DbType.String, apiDingDanId);

            info = ReadDingDanInfo(cmd);

            return info;
        }
        #endregion
    }
}
