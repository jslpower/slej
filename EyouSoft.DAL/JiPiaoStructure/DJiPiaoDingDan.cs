/*//机票订单相关 汪奇志 2013-12-03
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit.DAL;
using EyouSoft.Toolkit;

namespace EyouSoft.DAL.JiPiaoStructure
{
    /// <summary>
    /// 机票订单相关
    /// </summary>
    public class DJiPiaoDingDan : DALBase, EyouSoft.IDAL.JiPiaoStructure.IJiPiaoDingDan
    {
        #region static constants
        //static constants
        const string SQL_INSERT_InsertHangBan = "INSERT INTO [tbl_JiPiaoHangBan]([HangBanId],[ArrAirportCode],[ArrTime],[HangKongGongSiCode],[BanCi],[DepAirportCode],[DepTime],[RanYouFei],[JiaGe],[IsHanCan],[JiJianFei],[JiXing],[ArrHangZhanLou],[DepHangZhanLou],[IssueTime],[ApiHangBanId]) VALUES (@HangBanId,@ArrAirportCode,@ArrTime,@HangKongGongSiCode,@BanCi,@DepAirportCode,@DepTime,@RanYouFei,@JiaGe,@IsHanCan,@JiJianFei,@JiXing,@ArrHangZhanLou,@DepHangZhanLou,@IssueTime,@ApiHangBanId);INSERT INTO [tbl_JiPiaoCangWei]([HangBanId],[CangWeiCode],[JiaGe],[ZheKou],[TeXuZhengCe]) VALUES (@HangBanId,@CangWeiCode,@JiaGe1,@ZheKou,@TeXuZhengCe);";
        const string SQL_UPDATE_SheZhiDingDanStatus = "UPDATE [tbl_JiPiaoDingDan] SET [DingDanStatus]=@DingDanStatus WHERE [DingDanId]=@DingDanId AND [XiaDanRenId]=@XiaDanRenId";
        const string SQL_UPDATE_SheZhiFuKuanStatus = "UPDATE [tbl_JiPiaoDingDan] SET [FuKuanStatus]=@FuKuanStatus,[FuKuanTime]=@FuKuanTime WHERE [DingDanId]=@DingDanId AND [XiaDanRenId]=@XiaDanRenId";
        const string SQL_UPDATE_SheZhiChuPiaoStatus = "UPDATE [tbl_JiPiaoDingDan] SET [ChuPiaoStatus]=@ChuPiaoStatus WHERE [DingDanId]=@DingDanId AND [XiaDanRenId]=@XiaDanRenId";
        const string SQL_SELECT_GetInfo = "SELECT * FROM [tbl_JiPiaoDingDan] WHERE [DingDanId]=@DingDanId";
        const string SQL_SELECT_GetChengJiRens = "SELECT * FROM [tbl_JiPiaoChengJiRen] WHERE [DingDanId]=@DingDanId ORDER BY [IdentityId] ASC";
        const string SQL_SELECT_GetHangBanInfo = "SELECT * FROM [tbl_JiPiaoHangBan] WHERE [HangBanId]=@HangBanId";
        const string SQL_SELECT_GetCangWeis = "SELECT * FROM [tbl_JiPiaoCangWei] WHERE [HangBanId]=@HangBanId ORDER BY [CangWeiId] ASC";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DJiPiaoDingDan()
        {
            _db = SystemStore;
        }
        #endregion

        #region private members
        /// <summary>
        /// get chengjirens
        /// </summary>
        /// <param name="dingDanId"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.JiPiaoStructure.MJiPiaoChengJiRenInfo> GetChengJiRens(string dingDanId)
        {
            IList<EyouSoft.Model.JiPiaoStructure.MJiPiaoChengJiRenInfo> items = new List<EyouSoft.Model.JiPiaoStructure.MJiPiaoChengJiRenInfo>();
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetChengJiRens);
            _db.AddInParameter(cmd, "DingDanId", DbType.AnsiStringFixedLength, dingDanId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.JiPiaoStructure.MJiPiaoChengJiRenInfo();

                    item.DianHua = rdr["DianHua"].ToString();
                    item.IdentityId = rdr.GetInt32(rdr.GetOrdinal("IdentityId"));
                    item.IsDuanXin = rdr["IsDuanXin"].ToString() == "1";
                    item.LeiXing = (EyouSoft.Model.Enum.YouKeType)rdr.GetByte(rdr.GetOrdinal("LeiXing"));
                    item.ShenFenZhengHaoMa = rdr["ShenFenZhengHaoMa"].ToString();
                    item.XingMing = rdr["XingMing"].ToString();
                    item.YanWuXian = rdr.GetInt32(rdr.GetOrdinal("YanWuXian"));
                    item.YanWuXianJiaGe = rdr.GetDecimal(rdr.GetOrdinal("YanWuXianJiaGe"));
                    item.YiWaiXian = rdr.GetInt32(rdr.GetOrdinal("YiWaiXian"));
                    item.YiWaiXianJiaGe = rdr.GetDecimal(rdr.GetOrdinal("YiWaiXianJiaGe"));
                    item.ZhengJianHaoMa = rdr["ZhengJianHaoMa"].ToString();
                    item.ZhengJianLeiXing = (EyouSoft.Model.Enum.CardType)rdr.GetByte(rdr.GetOrdinal("ZhengJianLeiXing"));

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// get hangbans
        /// </summary>
        /// <param name="hangBanId"></param>
        /// <returns></returns>
        IList<EyouSoft.Model.JiPiaoStructure.MCangWeiInfo> GetCangWeis(string hangBanId)
        {
            IList<EyouSoft.Model.JiPiaoStructure.MCangWeiInfo> items = new List<EyouSoft.Model.JiPiaoStructure.MCangWeiInfo>();
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetCangWeis);
            _db.AddInParameter(cmd, "HangBanId", DbType.AnsiStringFixedLength, hangBanId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.JiPiaoStructure.MCangWeiInfo();

                    item.CangWeiCode = rdr["CangWeiCode"].ToString();
                    item.JiaGe = rdr.GetDecimal(rdr.GetOrdinal("JiaGe"));
                    item.TeXuZhengCe = rdr.GetDecimal(rdr.GetOrdinal("TeXuZhengCe"));
                    item.ZheKou = rdr.GetDecimal(rdr.GetOrdinal("ZheKou"));

                    items.Add(item);
                }
            }

            return items;
        }
        #endregion

        #region IJiPiaoDingDan 成员
        /// <summary>
        /// 写入机票航班信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int InsertHangBan(EyouSoft.Model.JiPiaoStructure.MHangBanInfo info)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_INSERT_InsertHangBan);
            _db.AddInParameter(cmd, "HangBanId", DbType.AnsiStringFixedLength, info.HangBanId);
            _db.AddInParameter(cmd, "ArrAirportCode", DbType.String, info.ArrAirportCode);
            _db.AddInParameter(cmd, "ArrTime", DbType.String, info.ArrTime);
            _db.AddInParameter(cmd, "HangKongGongSiCode", DbType.String, info.HangKongGongSiCode);
            _db.AddInParameter(cmd, "BanCi", DbType.String, info.BanCi);
            _db.AddInParameter(cmd, "DepAirportCode", DbType.String, info.DepAirportCode);
            _db.AddInParameter(cmd, "DepTime", DbType.String, info.DepTime);
            _db.AddInParameter(cmd, "RanYouFei", DbType.Decimal, info.RanYouFei);
            _db.AddInParameter(cmd, "JiaGe", DbType.Decimal, info.JiaGe);
            _db.AddInParameter(cmd, "IsHanCan", DbType.AnsiStringFixedLength, info.IsHanCan ? "1" : "0");
            _db.AddInParameter(cmd, "JiJianFei", DbType.Decimal, info.JiJianFei);
            _db.AddInParameter(cmd, "JiXing", DbType.String, info.JiXing);
            _db.AddInParameter(cmd, "ArrHangZhanLou", DbType.String, info.ArrHangZhanLou);
            _db.AddInParameter(cmd, "DepHangZhanLou", DbType.String, info.DepHangZhanLou);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, DateTime.Now);
            _db.AddInParameter(cmd, "ApiHangBanId", DbType.String, info.ApiHangBanId);

            _db.AddInParameter(cmd, "CangWeiCode", DbType.String, info.CangWeis[0].CangWeiCode);
            _db.AddInParameter(cmd, "JiaGe1", DbType.Decimal, info.CangWeis[0].JiaGe);
            _db.AddInParameter(cmd, "ZheKou", DbType.Decimal, info.CangWeis[0].ZheKou);
            _db.AddInParameter(cmd, "TeXuZhengCe", DbType.Decimal, info.CangWeis[0].TeXuZhengCe);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }

        /// <summary>
        /// 写入机票订单信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(EyouSoft.Model.JiPiaoStructure.MJiPiaoDingDanInfo info)
        {
            DbCommand cmd = _db.GetSqlStringCommand("SELECT 1");
            StringBuilder sql = new StringBuilder();
            sql.Append("DECLARE @RetCode INT;");
            sql.Append("SET @RetCode=-100;");
            sql.Append("DECLARE @DingDanHao NVARCHAR(50);");
            sql.Append("SET @DingDanHao=dbo.fn_CreateJiPiaoDingDanHao();");
            sql.Append("INSERT INTO [tbl_JiPiaoDingDan]([DingDanId],[HangBanId],[DingDanHao],[ChuFaRiQi],[LxrXingMing],[LxrDianHua],[LxrYouXiang],[LxrDiZhi],[BeiZhu],[JinE],[XiaDanRenId],[IssueTime],[ApiDingDanId],[IsBaoXiaoPingZheng],[PzXingMing],[PzShengFenId],[PzChengShiId],[PzXianQuId],[PzDiZhi],[PzDianHua],[PzYouBian],[QueRenFangShi],[ChuPiaoFangShi],[DingDanStatus],[FuKuanStatus],[ChuPiaoStatus],[LatestTime],[ApiFanDianJinE],[ApiJinE]) VALUES (@DingDanId,@HangBanId,@DingDanHao,@ChuFaRiQi,@LxrXingMing,@LxrDianHua,@LxrYouXiang,@LxrDiZhi,@BeiZhu,@JinE,@XiaDanRenId,@IssueTime,@ApiDingDanId,@IsBaoXiaoPingZheng,@PzXingMing,@PzShengFenId,@PzChengShiId,@PzXianQuId,@PzDiZhi,@PzDianHua,@PzYouBian,@QueRenFangShi,@ChuPiaoFangShi,@DingDanStatus,@FuKuanStatus,@ChuPiaoStatus,@LatestTime,@ApiFanDianJinE,@ApiJinE);");
            _db.AddInParameter(cmd, "DingDanId", DbType.AnsiStringFixedLength, info.DingDanId);
            _db.AddInParameter(cmd, "HangBanId", DbType.AnsiStringFixedLength, info.HangBanId);
            _db.AddInParameter(cmd, "ChuFaRiQi", DbType.DateTime, info.ChuFaRiQi);
            _db.AddInParameter(cmd, "LxrXingMing", DbType.String, info.LxrXingMing);
            _db.AddInParameter(cmd, "LxrDianHua", DbType.String, info.LxrDianHua);
            _db.AddInParameter(cmd, "LxrYouXiang", DbType.String, info.LxrYouXiang);
            _db.AddInParameter(cmd, "LxrDiZhi", DbType.String, info.LxrDiZhi);
            _db.AddInParameter(cmd, "BeiZhu", DbType.String, info.BeiZhu);
            _db.AddInParameter(cmd, "JinE", DbType.Decimal, info.JinE);
            _db.AddInParameter(cmd, "XiaDanRenId", DbType.AnsiStringFixedLength, info.XiaDanRenId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "ApiDingDanId", DbType.String, info.ApiDingDanId);
            _db.AddInParameter(cmd, "IsBaoXiaoPingZheng", DbType.AnsiStringFixedLength, info.IsBaoXiaoPingZheng ? "1" : "0");
            _db.AddInParameter(cmd, "PzXingMing", DbType.String, info.PzXingMing);
            _db.AddInParameter(cmd, "PzShengFenId", DbType.Int32, info.PzShengFenId);
            _db.AddInParameter(cmd, "PzChengShiId", DbType.Int32, info.PzChengShiId);
            _db.AddInParameter(cmd, "PzXianQuId", DbType.Int32, info.PzXianQuId);
            _db.AddInParameter(cmd, "PzDiZhi", DbType.String, info.PzDiZhi);
            _db.AddInParameter(cmd, "PzDianHua", DbType.String, info.PzDianHua);
            _db.AddInParameter(cmd, "PzYouBian", DbType.String, info.PzYouBian);
            _db.AddInParameter(cmd, "QueRenFangShi", DbType.Byte, info.QueRenFangShi);
            _db.AddInParameter(cmd, "ChuPiaoFangShi", DbType.Byte, info.ChuPiaoFangShi);
            _db.AddInParameter(cmd, "DingDanStatus", DbType.Byte, info.DingDanStatus);
            _db.AddInParameter(cmd, "FuKuanStatus", DbType.Byte, info.FuKuanStatus);
            _db.AddInParameter(cmd, "ChuPiaoStatus", DbType.Byte, info.ChuPiaoStatus);
            _db.AddInParameter(cmd, "LatestTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "ApiFanDianJinE", DbType.Decimal, info.ApiFaDianJinE);
            _db.AddInParameter(cmd, "ApiJinE", DbType.Decimal, info.ApiJinE);

            if (info.ChengJiRens != null && info.ChengJiRens.Count > 0)
            {
                int i = 0;
                foreach (var item in info.ChengJiRens)
                {
                    sql.AppendFormat("INSERT INTO [tbl_JiPiaoChengJiRen]([DingDanId],[HangBanId],[XingMing],[DianHua],[LeiXing],[ShenFenZhengHaoMa],[ZhengJianLeiXing],[ZhengJianHaoMa],[YiWaiXian],[YanWuXian],[YiWaiXianJiaGe],[YanWuXianJiaGe],[IsDuanXin]) VALUES (@DingDanId,@HangBanId,@XingMing{0},@DianHua{0},@LeiXing{0},@ShenFenZhengHaoMa{0},@ZhengJianLeiXing{0},@ZhengJianHaoMa{0},@YiWaiXian{0},@YanWuXian{0},@YiWaiXianJiaGe{0},@YanWuXianJiaGe{0},@IsDuanXin{0});", i);
                    _db.AddInParameter(cmd, "XingMing" + i, DbType.String, item.XingMing);
                    _db.AddInParameter(cmd, "DianHua" + i, DbType.String, item.DianHua);
                    _db.AddInParameter(cmd, "LeiXing" + i, DbType.Byte, item.LeiXing);
                    _db.AddInParameter(cmd, "ShenFenZhengHaoMa" + i, DbType.String, item.ShenFenZhengHaoMa);
                    _db.AddInParameter(cmd, "ZhengJianLeiXing" + i, DbType.Byte, item.ZhengJianLeiXing);
                    _db.AddInParameter(cmd, "ZhengJianHaoMa" + i, DbType.String, item.ZhengJianHaoMa);
                    _db.AddInParameter(cmd, "YiWaiXian" + i, DbType.Int32, item.YiWaiXian);
                    _db.AddInParameter(cmd, "YanWuXian" + i, DbType.Int32, item.YanWuXian);
                    _db.AddInParameter(cmd, "YiWaiXianJiaGe" + i, DbType.Decimal, item.YiWaiXianJiaGe);
                    _db.AddInParameter(cmd, "YanWuXianJiaGe" + i, DbType.Decimal, item.YanWuXianJiaGe);
                    _db.AddInParameter(cmd, "IsDuanXin" + i, DbType.AnsiStringFixedLength, item.IsDuanXin ? "1" : "0");

                    i++;
                }
            }

            sql.Append("SET @RetCode=1;");
            sql.AppendFormat("SELECT @DingDanHao AS DingDanHao,@RetCode AS RetCode;");

            cmd.CommandText = sql.ToString();

            int retCode = 0;
            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info.DingDanHao = rdr["DingDanHao"].ToString();
                    retCode = Utils.GetInt(rdr["RetCode"].ToString());
                }
            }

            return retCode;
        }

        /// <summary>
        /// 更新机票订单信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(EyouSoft.Model.JiPiaoStructure.MJiPiaoDingDanInfo info)
        {
            DbCommand cmd = _db.GetSqlStringCommand("SELECT 1;");
            StringBuilder sql = new StringBuilder();
            sql.Append("DECLARE @HangBanId CHAR(36);");
            sql.Append("SELECT @HangBanId=HangBanId FROM [tbl_JiPiaoDingDan] WHERE [DingDanId]=@DingDanId;");
            sql.Append("UPDATE [tbl_JiPiaoDingDan] SET [LxrXingMing]=@LxrXingMing,[LxrDianHua]=@LxrDianHua,[LxrYouXiang]=@LxrYouXiang,[LxrDiZhi]=@LxrDiZhi,[BeiZhu]=@BeiZhu,[JinE]=@JinE,[IsBaoXiaoPingZheng]=@IsBaoXiaoPingZheng,[PzXingMing]=@PzXingMing,[PzShengFenId]=@PzShengFenId,[PzChengShiId]=@PzChengShiId,[PzXianQuId]=@PzXianQuId,[PzDiZhi]=@PzDiZhi,[PzDianHua]=@PzDianHua,[PzYouBian]=@PzYouBian,[QueRenFangShi]=@QueRenFangShi,[ChuPiaoFangShi]=@ChuPiaoFangShi,[LatestTime]=@LatestTime WHERE [DingDanId]=@DingDanId;");
            _db.AddInParameter(cmd, "DingDanId", DbType.AnsiStringFixedLength, info.DingDanId);
            _db.AddInParameter(cmd, "LxrXingMing", DbType.String, info.LxrXingMing);
            _db.AddInParameter(cmd, "LxrDianHua", DbType.String, info.LxrDianHua);
            _db.AddInParameter(cmd, "LxrYouXiang", DbType.String, info.LxrYouXiang);
            _db.AddInParameter(cmd, "LxrDiZhi", DbType.String, info.LxrDiZhi);
            _db.AddInParameter(cmd, "BeiZhu", DbType.String, info.BeiZhu);
            _db.AddInParameter(cmd, "JinE", DbType.Decimal, info.JinE);
            _db.AddInParameter(cmd, "IsBaoXiaoPingZheng", DbType.AnsiStringFixedLength, info.IsBaoXiaoPingZheng ? "1" : "0");
            _db.AddInParameter(cmd, "PzXingMing", DbType.String, info.PzXingMing);
            _db.AddInParameter(cmd, "PzShengFenId", DbType.Int32, info.PzShengFenId);
            _db.AddInParameter(cmd, "PzChengShiId", DbType.Int32, info.DingDanId);
            _db.AddInParameter(cmd, "PzXianQuId", DbType.Int32, info.PzXianQuId);
            _db.AddInParameter(cmd, "PzDiZhi", DbType.String, info.PzDiZhi);
            _db.AddInParameter(cmd, "PzDianHua", DbType.String, info.PzDianHua);
            _db.AddInParameter(cmd, "PzYouBian", DbType.String, info.PzYouBian);
            _db.AddInParameter(cmd, "QueRenFangShi", DbType.Byte, info.QueRenFangShi);
            _db.AddInParameter(cmd, "ChuPiaoFangShi", DbType.Byte, info.ChuPiaoFangShi);
            _db.AddInParameter(cmd, "LatestTime", DbType.DateTime, DateTime.Now);
            sql.Append("DELETE FROM [tbl_JiPiaoChengJiRen] WHERE [DingDanId]=@DingDanId;");

            if (info.ChengJiRens != null && info.ChengJiRens.Count > 0)
            {
                int i = 0;
                foreach (var item in info.ChengJiRens)
                {
                    sql.AppendFormat("INSERT INTO [tbl_JiPiaoChengJiRen]([DingDanId],[HangBanId],[XingMing],[DianHua],[LeiXing],[ShenFenZhengHaoMa],[ZhengJianLeiXing],[ZhengJianHaoMa],[YiWaiXian],[YanWuXian],[YiWaiXianJiaGe],[YanWuXianJiaGe],[IsDuanXin]) VALUES (@DingDanId,@HangBanId,@XingMing{0},@DianHua{0},@LeiXing{0},@ShenFenZhengHaoMa{0},@ZhengJianLeiXing{0},@ZhengJianHaoMa{0},@YiWaiXian{0},@YanWuXian{0},@YiWaiXianJiaGe{0},@YanWuXianJiaGe{0},@IsDuanXin{0});", i);
                    _db.AddInParameter(cmd, "XingMing" + i, DbType.String, item.XingMing);
                    _db.AddInParameter(cmd, "DianHua" + i, DbType.String, item.DianHua);
                    _db.AddInParameter(cmd, "LeiXing" + i, DbType.Byte, item.LeiXing);
                    _db.AddInParameter(cmd, "ShenFenZhengHaoMa" + i, DbType.String, item.ShenFenZhengHaoMa);
                    _db.AddInParameter(cmd, "ZhengJianLeiXing" + i, DbType.Byte, item.ZhengJianLeiXing);
                    _db.AddInParameter(cmd, "ZhengJianHaoMa" + i, DbType.String, item.ZhengJianHaoMa);
                    _db.AddInParameter(cmd, "YiWaiXian" + i, DbType.Int32, item.YiWaiXian);
                    _db.AddInParameter(cmd, "YanWuXian" + i, DbType.Int32, item.YanWuXian);
                    _db.AddInParameter(cmd, "YiWaiXianJiaGe" + i, DbType.Decimal, item.YiWaiXianJiaGe);
                    _db.AddInParameter(cmd, "YanWuXianJiaGe" + i, DbType.Decimal, item.YanWuXianJiaGe);
                    _db.AddInParameter(cmd, "IsDuanXin" + i, DbType.AnsiStringFixedLength, item.IsDuanXin ? "1" : "0");

                    i++;
                }
            }

            cmd.CommandText = sql.ToString();

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }

        /// <summary>
        /// 设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="xiaDanRenId">下单人编号</param>
        /// <param name="dingDanStatus">订单状态</param>
        /// <returns></returns>
        public int SheZhiDingDanStatus(string dingDanId, string xiaDanRenId, EyouSoft.Model.Enum.XianLuStructure.OrderStatus dingDanStatus)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_SheZhiDingDanStatus);
            _db.AddInParameter(cmd, "DingDanId", DbType.AnsiStringFixedLength, dingDanId);
            _db.AddInParameter(cmd, "XiaDanRenId", DbType.AnsiStringFixedLength, xiaDanRenId);
            _db.AddInParameter(cmd, "DingDanStatus", DbType.Byte, dingDanStatus);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }

        /// <summary>
        /// 设置付款状态，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="xiaDanRenId">下单人编号</param>
        /// <param name="fuKuanStatus">付款状态</param>
        /// <returns></returns>
        public int SheZhiFuKuanStatus(string dingDanId, string xiaDanRenId, EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus fuKuanStatus)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_SheZhiFuKuanStatus);
            _db.AddInParameter(cmd, "DingDanId", DbType.AnsiStringFixedLength, dingDanId);
            _db.AddInParameter(cmd, "XiaDanRenId", DbType.AnsiStringFixedLength, xiaDanRenId);
            _db.AddInParameter(cmd, "FuKuanStatus", DbType.Byte, fuKuanStatus);
            _db.AddInParameter(cmd, "FuKuanTime", DbType.DateTime, DateTime.Now);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }

        /// <summary>
        /// 设置出票状态，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="xiaDanRenId">下单人编号</param>
        /// <param name="chuPiaoStatus">出票状态</param>
        /// <returns></returns>
        public int SheZhiChuPiaoStatus(string dingDanId, string xiaDanRenId, EyouSoft.Model.Enum.JiPiaoStructure.ChuPiaoStatus chuPiaoStatus)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_SheZhiChuPiaoStatus);
            _db.AddInParameter(cmd, "DingDanId", DbType.AnsiStringFixedLength, dingDanId);
            _db.AddInParameter(cmd, "XiaDanRenId", DbType.AnsiStringFixedLength, xiaDanRenId);
            _db.AddInParameter(cmd, "ChuPiaoStatus", DbType.Byte, chuPiaoStatus);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }

        /// <summary>
        /// 获取订单信息业务实体
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <returns></returns>
        public EyouSoft.Model.JiPiaoStructure.MJiPiaoDingDanInfo GetInfo(string dingDanId)
        {
            EyouSoft.Model.JiPiaoStructure.MJiPiaoDingDanInfo info = null;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetInfo);
            _db.AddInParameter(cmd, "DingDanId", DbType.AnsiStringFixedLength, dingDanId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new EyouSoft.Model.JiPiaoStructure.MJiPiaoDingDanInfo();

                    info.ApiDingDanId = rdr["ApiDingDanId"].ToString();
                    info.ApiFaDianJinE = rdr.GetDecimal(rdr.GetOrdinal("ApiFanDianJinE"));
                    info.ApiJinE = rdr.GetDecimal(rdr.GetOrdinal("ApiJinE"));
                    info.BeiZhu = rdr["BeiZhu"].ToString();
                    info.ChengJiRens = null;
                    info.ChuFaRiQi = rdr.GetDateTime(rdr.GetOrdinal("ChuFaRiQi"));
                    info.ChuPiaoFangShi = (EyouSoft.Model.Enum.JiPiaoStructure.ChuPiaoFangShi)rdr.GetByte(rdr.GetOrdinal("ChuPiaoFangShi"));
                    info.ChuPiaoStatus = (EyouSoft.Model.Enum.JiPiaoStructure.ChuPiaoStatus)rdr.GetByte(rdr.GetOrdinal("ChuPiaoStatus"));
                    info.DingDanHao = rdr["DingDanHao"].ToString();
                    info.DingDanId = dingDanId;
                    info.DingDanStatus = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)rdr.GetByte(rdr.GetOrdinal("DingDanStatus"));
                    info.FuKuanStatus = (EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus)rdr.GetByte(rdr.GetOrdinal("FuKuanStatus"));
                    info.HangBanId = rdr["HangBanId"].ToString();
                    info.IsBaoXiaoPingZheng = rdr["IsBaoXiaoPingZheng"].ToString() == "1";
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.JinE = rdr.GetDecimal(rdr.GetOrdinal("JinE"));
                    info.LxrDianHua = rdr["LxrDianHua"].ToString();
                    info.LxrDiZhi = rdr["LxrDiZhi"].ToString();
                    info.LxrXingMing = rdr["LxrXingMing"].ToString();
                    info.LxrYouXiang = rdr["LxrYouXiang"].ToString();
                    info.PzChengShiId = rdr.GetInt32(rdr.GetOrdinal("PzChengShiId"));
                    info.PzDianHua = rdr["PzDianHua"].ToString();
                    info.PzDiZhi = rdr["PzDiZhi"].ToString();
                    info.PzShengFenId = rdr.GetInt32(rdr.GetOrdinal("PzShengFenId"));
                    info.PzXianQuId = rdr.GetInt32(rdr.GetOrdinal("PzXianQuId"));
                    info.PzXingMing = rdr["PzXingMing"].ToString();
                    info.PzYouBian = rdr["PzYouBian"].ToString();
                    info.QueRenFangShi = (EyouSoft.Model.Enum.JiPiaoStructure.QueRenFangShi)rdr.GetByte(rdr.GetOrdinal("QueRenFangShi"));
                    info.XiaDanRenId = rdr["XiaDanRenId"].ToString();
                    info.FuKuanTime = rdr.GetDateTime(rdr.GetOrdinal("FuKuanTime"));
                }
            }

            if (info != null)
            {
                info.ChengJiRens = GetChengJiRens(dingDanId);
            }

            return info;
        }

        /// <summary>
        /// 获取航班信息业务实体
        /// </summary>
        /// <param name="hangBanId">航班编号</param>
        /// <returns></returns>
        public EyouSoft.Model.JiPiaoStructure.MHangBanInfo GetHangBanInfo(string hangBanId)
        {
            EyouSoft.Model.JiPiaoStructure.MHangBanInfo info = null;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetHangBanInfo);
            _db.AddInParameter(cmd, "HangBanId", DbType.AnsiStringFixedLength, hangBanId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new EyouSoft.Model.JiPiaoStructure.MHangBanInfo();

                    info.ApiHangBanId = rdr["ApiHangBanId"].ToString();
                    info.ArrAirportCode = rdr["ArrAirportCode"].ToString();
                    info.ArrHangZhanLou = rdr["ArrHangZhanLou"].ToString();
                    info.ArrTime = rdr["ArrTime"].ToString();
                    info.BanCi = rdr["BanCi"].ToString();
                    info.CangWeis = null;
                    info.DepAirportCode = rdr["DepAirportCode"].ToString();
                    info.DepHangZhanLou = rdr["DepHangZhanLou"].ToString();
                    info.DepTime = rdr["DepTime"].ToString();
                    info.HangBanId = hangBanId;
                    info.HangKongGongSiCode = rdr["HangKongGongSiCode"].ToString();
                    info.IsHanCan = rdr["IsHanCan"].ToString() == "1";
                    info.JiaGe = rdr.GetDecimal(rdr.GetOrdinal("JiaGe"));
                    info.JiJianFei = rdr.GetDecimal(rdr.GetOrdinal("JiJianFei"));
                    info.JiXing = rdr["JiXing"].ToString();
                    info.RanYouFei = rdr.GetDecimal(rdr.GetOrdinal("RanYouFei"));
                }
            }

            if (info != null)
            {
                info.CangWeis = GetCangWeis(hangBanId);
            }

            return info;
        }

        /// <summary>
        /// 获取订单信息集合
        /// </summary>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.JiPiaoStructure.MJiPiaoDingDanInfo> GetDingDans(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.JiPiaoStructure.MJiPiaoDingDanChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.JiPiaoStructure.MJiPiaoDingDanInfo> items = new List<EyouSoft.Model.JiPiaoStructure.MJiPiaoDingDanInfo>();

            StringBuilder fields = new StringBuilder();
            StringBuilder sql = new StringBuilder();
            string tableName = "tbl_JiPiaoDingDan";
            string orderByString = "LatestTime DESC";
            string sumString = "";

            #region fields
            fields.Append(" DingDanId,DingDanHao,HangBanId,XiaDanRenId,IssueTime,JinE,DingDanStatus,FuKuanStatus,ChuPiaoStatus,QueRenFangShi,ChuPiaoFangShi,ChuFaRiQi ");
            #endregion

            #region sql where
            sql.Append(" 1=1 ");
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.DingDanHao))
                {
                    sql.AppendFormat(" AND DingDanHao LIKE '%{0}%' ", chaXun.DingDanHao);
                }
                if (!string.IsNullOrEmpty(chaXun.XiaDanRenId))
                {
                    sql.AppendFormat(" AND XiaDanRenId='{0}' ", chaXun.XiaDanRenId);
                }
                if (chaXun.XiaDanETime.HasValue)
                {
                    sql.AppendFormat(" AND IssueTime<'{0}' ", chaXun.XiaDanETime.Value.AddDays(1));
                }
                if (chaXun.XiaDanSTime.HasValue)
                {
                    sql.AppendFormat(" AND IssueTime>'{0}' ", chaXun.XiaDanSTime.Value.AddDays(-1));
                }
                if (chaXun.ChuFaERiQi.HasValue)
                {
                    sql.AppendFormat(" AND ChuFaRiQi<'{0}' ", chaXun.ChuFaERiQi.Value.AddDays(1));
                }
                if (chaXun.ChuFaSRiQi.HasValue)
                {
                    sql.AppendFormat(" AND ChuFaRiQi>'{0}' ",chaXun.ChuFaSRiQi.Value.AddDays(-1));
                }
                if (!string.IsNullOrEmpty(chaXun.CjrXingMing))
                {
                    sql.AppendFormat(" AND EXISTS(SELECT 1 FROM tbl_JiPiaoChengJiRen AS A WHERE A.DingDanId=tbl_JiPiaoDingDan.DingDanId AND A.XingMing LIKE '%{0}%') ", chaXun.CjrXingMing);
                }
                if (!string.IsNullOrEmpty(chaXun.LxrXingMing))
                {
                    sql.AppendFormat(" AND LxrXingMing LIKE '%{0}%' ", chaXun.LxrXingMing);
                }
                if (chaXun.DingDanStatus.HasValue)
                {
                    sql.AppendFormat(" AND DingDanStatus={0} ", (int)chaXun.DingDanStatus.Value);
                }
                if (chaXun.FuKuanStatus.HasValue)
                {
                    sql.AppendFormat(" AND FuKuanStatus={0} ", (int)chaXun.FuKuanStatus.Value);
                }
                if (chaXun.ChuPiaoStatus.HasValue)
                {
                    sql.AppendFormat(" AND ChuPiaoStatus={0} ", (int)chaXun.ChuPiaoStatus.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.DingDanId))
                {
                    sql.AppendFormat(" AND DingDanId='{0}' ", chaXun.DingDanId);
                }
                if (chaXun.IsFeiHuiYuan)
                {
                    sql.Append(" AND LEN(XiaDanRenId)<>36 ");
                    sql.AppendFormat(" AND DingDanHao='{0}' ", chaXun.FeiHuiYuanDingDanHao);
                    sql.AppendFormat(" AND LxrXingMing='{0}' ", chaXun.FeiHuiYuanXingMing);
                    sql.AppendFormat(" AND LxrDianHua='{0}' ", chaXun.FeiHuiYuanDianHua);
                }
            }
            #endregion
            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), sql.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.JiPiaoStructure.MJiPiaoDingDanInfo();

                    item.DingDanId = rdr["DingDanId"].ToString();
                    item.DingDanHao = rdr["DingDanHao"].ToString();
                    item.HangBanId = rdr["HangBanId"].ToString();
                    item.XiaDanRenId = rdr["XiaDanRenId"].ToString();
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.JinE = rdr.GetDecimal(rdr.GetOrdinal("JinE"));
                    item.DingDanStatus = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)rdr.GetByte(rdr.GetOrdinal("DingDanStatus"));
                    item.FuKuanStatus = (EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus)rdr.GetByte(rdr.GetOrdinal("FuKuanStatus"));
                    item.ChuPiaoStatus = (EyouSoft.Model.Enum.JiPiaoStructure.ChuPiaoStatus)rdr.GetByte(rdr.GetOrdinal("ChuPiaoStatus"));
                    item.QueRenFangShi = (EyouSoft.Model.Enum.JiPiaoStructure.QueRenFangShi)rdr.GetByte(rdr.GetOrdinal("QueRenFangShi"));
                    item.ChuPiaoFangShi = (EyouSoft.Model.Enum.JiPiaoStructure.ChuPiaoFangShi)rdr.GetByte(rdr.GetOrdinal("ChuPiaoFangShi"));
                    item.ChuFaRiQi = rdr.GetDateTime(rdr.GetOrdinal("ChuFaRiQi"));

                    items.Add(item);
                }
            }

            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    item.ChengJiRens = GetChengJiRens(item.DingDanId);
                }
            }

            return items;
        }

        #endregion
    }
}
*/