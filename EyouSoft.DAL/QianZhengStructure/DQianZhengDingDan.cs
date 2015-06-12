//签证订单信息 汪奇志 2013-11-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit.DAL;
using EyouSoft.Toolkit;

namespace EyouSoft.DAL.QianZhengStructure
{
    /// <summary>
    /// 签证订单信息
    /// </summary>
    public class DQianZhengDingDan : DALBase, EyouSoft.IDAL.QianZhengStructure.IQianZhengDingDan
    {
        #region static constants
        //static constants
        const string SQL_INSERT_Insert = "DECLARE @DingDanHao NVARCHAR(50);SET @DingDanHao=dbo.fn_CreateQianZhengDingDanHao();INSERT INTO [tbl_QianZhengDingDan]([DingDanId],[QianZhengId],[YuDingShiJian],[YuDingShuLiang],[LxrXingMing],[LxrDianHua],[LxrYouXiang],[LxrDiZhi],[BeiZhu],[DanJia],[JinE],[IssueTime],[DingDanStatus],[FuKuanStatus],[XiaDanRenId],[LaiYuan],[LatestTime],[DingDanHao],[AgencyId],[AgencyJinE]) VALUES (@DingDanId,@QianZhengId,@YuDingShiJian,@YuDingShuLiang,@LxrXingMing,@LxrDianHua,@LxrYouXiang,@LxrDiZhi,@BeiZhu,@DanJia,@JinE,@IssueTime,@DingDanStatus,@FuKuanStatus,@XiaDanRenId,@LaiYuan,@LatestTime,@DingDanHao,@AgencyId,@AgencyJinE);SELECT @DingDanHao";
        const string SQL_UPDATE_Update = "UPDATE [tbl_QianZhengDingDan] SET [YuDingShiJian]=@YuDingShiJian,[YuDingShuLiang]=@YuDingShuLiang,[LxrXingMing]=@LxrXingMing,[LxrDianHua]=@LxrDianHua,[LxrYouXiang]=@LxrYouXiang,[LxrDiZhi]=@LxrDiZhi,[BeiZhu]=@BeiZhu,[DanJia]=@DanJia,[JinE]=@JinE,[LatestTime]=@LatestTime WHERE [DingDanId]=@DingDanId";
        const string SQL_DELETE_Delete = "DELETE FROM [tbl_QianZhengDingDan] WHERE [DingDanId]=@DingDanId AND [XiaDanRenId]=@XiaDanRenId";
        const string SQL_SELECT_GetInfo = "SELECT A.*,(SELECT A1.Name FROM tbl_QianZheng AS A1 WHERE A1.QianZhengId=A.QianZhengId) AS QianZhengName,(SELECT A1.GuoJiaId FROM tbl_QianZheng AS A1 WHERE A1.QianZhengId=A.QianZhengId) AS QianZhengGuoJiaId FROM [tbl_QianZhengDingDan] AS A WHERE A.[DingDanId]=@DingDanId";
        const string SQL_UPDATE_SheZhiDingDanStatus = "UPDATE [tbl_QianZhengDingDan] SET [DingDanStatus]=@DingDanStatus WHERE [DingDanId]=@DingDanId AND [XiaDanRenId]=@XiaDanRenId";
        const string SQL_UPDATE_SheZhiFuKuanStatus = "UPDATE [tbl_QianZhengDingDan] SET [FuKuanStatus]=@FuKuanStatus,FuKuanTime=@FuKuanTime WHERE [DingDanId]=@DingDanId AND [XiaDanRenId]=@XiaDanRenId";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DQianZhengDingDan()
        {
            _db = SystemStore;
        }
        #endregion

        #region private members

        #endregion

        #region IQianZhengDingDan 成员
        /// <summary>
        /// 写入订单信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(EyouSoft.Model.QianZhengStructure.MQianZhengDingDanInfo info)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_INSERT_Insert);

            _db.AddInParameter(cmd, "DingDanId", DbType.AnsiStringFixedLength, info.DingDanId);
            _db.AddInParameter(cmd, "QianZhengId", DbType.AnsiStringFixedLength, info.QianZhengId);
            _db.AddInParameter(cmd, "YuDingShiJian", DbType.DateTime, info.YuDingShiJian);
            _db.AddInParameter(cmd, "YuDingShuLiang", DbType.Int32, info.YuDingShuLiang);
            _db.AddInParameter(cmd, "LxrXingMing", DbType.String, info.LxrXingMing);
            _db.AddInParameter(cmd, "LxrDianHua", DbType.String, info.LxrDianHua);
            _db.AddInParameter(cmd, "LxrYouXiang", DbType.String, info.LxrYouXiang);
            _db.AddInParameter(cmd, "LxrDiZhi", DbType.String, info.LxrDiZhi);
            _db.AddInParameter(cmd, "BeiZhu", DbType.String, info.BeiZhu);
            _db.AddInParameter(cmd, "DanJia", DbType.Decimal, info.DanJia);
            _db.AddInParameter(cmd, "JinE", DbType.Decimal, info.JinE);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "DingDanStatus", DbType.Byte, info.DingDanStatus);
            _db.AddInParameter(cmd, "FuKuanStatus", DbType.Byte, info.FuKuanStatus);
            _db.AddInParameter(cmd, "XiaDanRenId", DbType.String, info.XiaDanRenId);
            _db.AddInParameter(cmd, "LaiYuan", DbType.Byte, info.LaiYuan);
            _db.AddInParameter(cmd, "LatestTime", DbType.DateTime, info.LatestTime);
            _db.AddInParameter(cmd, "AgencyId", DbType.String, info.AgencyId);
            _db.AddInParameter(cmd, "AgencyJinE", DbType.Decimal, info.AgencyJinE);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info.DingDanHao = rdr[0].ToString();
                }
            }

            return !string.IsNullOrEmpty(info.DingDanHao) ? 1 : -100;
        }

        /// <summary>
        /// 更新订单信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(EyouSoft.Model.QianZhengStructure.MQianZhengDingDanInfo info)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_Update);

            _db.AddInParameter(cmd, "DingDanId", DbType.AnsiStringFixedLength, info.DingDanId);
            _db.AddInParameter(cmd, "YuDingShiJian", DbType.DateTime, info.YuDingShiJian);
            _db.AddInParameter(cmd, "YuDingShuLiang", DbType.Int32, info.YuDingShuLiang);
            _db.AddInParameter(cmd, "LxrXingMing", DbType.String, info.LxrXingMing);
            _db.AddInParameter(cmd, "LxrDianHua", DbType.String, info.LxrDianHua);
            _db.AddInParameter(cmd, "LxrYouXiang", DbType.String, info.LxrYouXiang);
            _db.AddInParameter(cmd, "LxrDiZhi", DbType.String, info.LxrDiZhi);
            _db.AddInParameter(cmd, "BeiZhu", DbType.String, info.BeiZhu);
            _db.AddInParameter(cmd, "DanJia", DbType.Decimal, info.DanJia);
            _db.AddInParameter(cmd, "JinE", DbType.Decimal, info.JinE);
            _db.AddInParameter(cmd, "LatestTime", DbType.DateTime, info.LatestTime);

            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }

        /// <summary>
        /// 删除订单信息，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="xiaDanRenId">下单人编号</param>
        /// <returns></returns>
        public int Delete(string dingDanId, string xiaDanRenId)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_DELETE_Delete);

            _db.AddInParameter(cmd, "DingDanId", DbType.AnsiStringFixedLength, dingDanId);
            _db.AddInParameter(cmd, "XiaDanRenId", DbType.AnsiStringFixedLength, xiaDanRenId);

            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }

        /// <summary>
        /// 获取订单信息实体
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <returns></returns>
        public EyouSoft.Model.QianZhengStructure.MQianZhengDingDanInfo GetInfo(string dingDanId)
        {
            EyouSoft.Model.QianZhengStructure.MQianZhengDingDanInfo item = null;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetInfo);

            _db.AddInParameter(cmd, "DingDanId", DbType.AnsiStringFixedLength, dingDanId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    item = new EyouSoft.Model.QianZhengStructure.MQianZhengDingDanInfo();

                    item.BeiZhu = rdr["BeiZhu"].ToString();
                    item.DanJia = rdr.GetDecimal(rdr.GetOrdinal("DanJia"));
                    item.LxrDianHua = rdr["LxrDianHua"].ToString();
                    item.DingDanId = rdr["DingDanId"].ToString();
                    item.DingDanStatus = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)rdr.GetByte(rdr.GetOrdinal("DingDanStatus"));
                    item.LxrDiZhi = rdr["LxrDiZhi"].ToString();
                    item.FuKuanStatus = (EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus)rdr.GetByte(rdr.GetOrdinal("FuKuanStatus"));
                    item.FuKuanTime = rdr.GetDateTime(rdr.GetOrdinal("FuKuanTime"));
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.JinE = rdr.GetDecimal(rdr.GetOrdinal("JinE"));
                    item.LaiYuan = (EyouSoft.Model.Enum.QianZhengStructure.DingDanLaiYuan)rdr.GetByte(rdr.GetOrdinal("LaiYuan"));
                    item.LatestTime = rdr.GetDateTime(rdr.GetOrdinal("LatestTime"));
                    item.QianZhengId = rdr["QianZhengId"].ToString();
                    item.XiaDanRenId = rdr["XiaDanRenId"].ToString();
                    item.LxrXingMing = rdr["LxrXingMing"].ToString();
                    item.LxrYouXiang = rdr["LxrYouXiang"].ToString();
                    item.YuDingShiJian = rdr.GetDateTime(rdr.GetOrdinal("YuDingShiJian"));
                    item.YuDingShuLiang = rdr.GetInt32(rdr.GetOrdinal("YuDingShuLiang"));
                    item.DingDanHao = rdr["DingDanHao"].ToString();

                    item.AgencyId = rdr["AgencyId"].ToString();
                    item.AgencyJinE = rdr.GetDecimal(rdr.GetOrdinal("AgencyJinE"));

                    item.QianZhengGuoJiaId = rdr.GetInt32(rdr.GetOrdinal("QianZhengGuoJiaId"));
                    item.QianZhengName = rdr["QianZhengName"].ToString();
                }
            }

            return item;
        }

        /// <summary>
        /// 获取订单信息集合
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.QianZhengStructure.MQianZhengDingDanInfo> GetDingDans(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.QianZhengStructure.MQianZhengDingDanChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.QianZhengStructure.MQianZhengDingDanInfo> items = new List<EyouSoft.Model.QianZhengStructure.MQianZhengDingDanInfo>();

            StringBuilder fields = new StringBuilder();
            StringBuilder query = new StringBuilder();
            string tableName = "tbl_QianZhengDingDan";
            string orderByString = "IssueTime DESC";
            string sumString = "";

            #region fields
            fields.Append(" * ");
            fields.Append(" ,(SELECT A.Name FROM tbl_QianZheng AS A WHERE A.QianZhengId=tbl_QianZhengDingDan.QianZhengId) AS QianZhengName ");
            fields.Append(" ,(SELECT A.GuoJiaId FROM tbl_QianZheng AS A WHERE A.QianZhengId=tbl_QianZhengDingDan.QianZhengId) AS QianZhengGuoJiaId ");
            #endregion

            #region sql where
            query.Append(" 1=1 ");
            if (chaXun != null)
            {

                if (!string.IsNullOrEmpty(chaXun.XiaDanRenId) && !string.IsNullOrEmpty(chaXun.AgencyId))
                {
                    query.AppendFormat(" AND ( XiaDanRenId='{0}' or  AgencyId='{1}')", chaXun.XiaDanRenId,chaXun.AgencyId);
                }
                else if (!string.IsNullOrEmpty(chaXun.XiaDanRenId))
                {
                    query.AppendFormat(" AND XiaDanRenId='{0}' ", chaXun.XiaDanRenId);
                }
                else if (!string.IsNullOrEmpty(chaXun.AgencyId))
                {
                    if (chaXun.AgencyId == "0")
                    {
                        query.Append(" AND AgencyId is null ");
                    }
                    else
                    {
                        query.AppendFormat(" AND AgencyId = '{0}' ", chaXun.AgencyId);
                    }
                }
                if (!string.IsNullOrEmpty(chaXun.GysId) || !string.IsNullOrEmpty(chaXun.QianZhengName) || chaXun.QianZhengGuoJiaId.HasValue)
                {
                    query.Append(" AND EXISTS(SELECT 1 FROM tbl_QianZheng AS A WHERE A.QianZhengId=tbl_QianZhengDingDan.QianZhengId ");
                    if (!string.IsNullOrEmpty(chaXun.GysId))
                    {
                        query.AppendFormat(" AND A.GysId='{0}' ", chaXun.GysId);
                    }
                    if (!string.IsNullOrEmpty(chaXun.QianZhengName))
                    {
                        query.AppendFormat(" AND A.Name LIKE '%{0}%' ", chaXun.QianZhengName);
                    }
                    if (chaXun.QianZhengGuoJiaId.HasValue)
                    {
                        query.AppendFormat(" AND A.GuoJiaId={0} ", chaXun.QianZhengGuoJiaId.Value);
                    }
                    query.Append(" ) ");
                }
                if (!string.IsNullOrEmpty(chaXun.LxrXingMing))
                {
                    query.AppendFormat(" AND LxrXingMing LIKE '%{0}%' ", chaXun.LxrXingMing);
                }
                if (chaXun.XiaDanSTime.HasValue)
                {
                    query.AppendFormat(" AND IssueTime>'{0}' ", chaXun.XiaDanSTime.Value.AddMilliseconds(1));
                }
                if (chaXun.XiaDanETime.HasValue)
                {
                    query.AppendFormat(" AND IssueTime<'{0}' ", chaXun.XiaDanETime.Value.AddDays(1));
                }
                if (chaXun.DingDanStatus.HasValue)
                {
                    query.AppendFormat(" AND DingDanStatus={0} ", (int)chaXun.DingDanStatus.Value);
                }
                if (chaXun.FuKuanStatus.HasValue)
                {
                    query.AppendFormat(" AND FuKuanStatus={0} ", (int)chaXun.FuKuanStatus.Value);
                }
                if (chaXun.LaiYuan.HasValue)
                {
                    query.AppendFormat(" AND LaiYuan={0} ", (int)chaXun.LaiYuan.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.QianZhengId))
                {
                    query.AppendFormat(" AND QianZhengId='{0}' ", chaXun.QianZhengId);
                }
                if (!string.IsNullOrEmpty(chaXun.DingDanHao))
                {
                    query.AppendFormat(" AND DingDanHao LIKE '%{0}%' ", chaXun.DingDanHao);
                }
                if (!string.IsNullOrEmpty(chaXun.DingDanHaoUniqueID))
                {
                    query.AppendFormat(" AND DingDanHao='{0}' ", chaXun.DingDanHaoUniqueID);
                }
                

                if (chaXun.IsFeiHuiYuan)
                {
                    query.Append(" AND LEN(XiaDanRenId)<>36 ");
                    query.AppendFormat(" AND DingDanHao='{0}' ", chaXun.FeiHuiYuanDingDanHao);
                    query.AppendFormat(" AND LxrXingMing='{0}' ", chaXun.FeiHuiYuanXingMing);
                    query.AppendFormat(" AND LxrDianHua='{0}' ", chaXun.FeiHuiYuanDianHua);
                }
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.QianZhengStructure.MQianZhengDingDanInfo();

                    item.BeiZhu = rdr["BeiZhu"].ToString();
                    item.DanJia = rdr.GetDecimal(rdr.GetOrdinal("DanJia"));
                    item.LxrDianHua = rdr["LxrDianHua"].ToString();
                    item.DingDanId = rdr["DingDanId"].ToString();
                    item.DingDanStatus = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)rdr.GetByte(rdr.GetOrdinal("DingDanStatus"));
                    item.LxrDiZhi = rdr["LxrDiZhi"].ToString();
                    item.FuKuanStatus = (EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus)rdr.GetByte(rdr.GetOrdinal("FuKuanStatus"));
                    item.FuKuanTime = rdr.GetDateTime(rdr.GetOrdinal("FuKuanTime"));
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.JinE = rdr.GetDecimal(rdr.GetOrdinal("JinE"));
                    item.LaiYuan = (EyouSoft.Model.Enum.QianZhengStructure.DingDanLaiYuan)rdr.GetByte(rdr.GetOrdinal("LaiYuan"));
                    item.LatestTime = rdr.GetDateTime(rdr.GetOrdinal("LatestTime"));
                    item.QianZhengId = rdr["QianZhengId"].ToString();
                    item.XiaDanRenId = rdr["XiaDanRenId"].ToString();
                    item.LxrXingMing = rdr["LxrXingMing"].ToString();
                    item.LxrYouXiang = rdr["LxrYouXiang"].ToString();
                    item.YuDingShiJian = rdr.GetDateTime(rdr.GetOrdinal("YuDingShiJian"));
                    item.YuDingShuLiang = rdr.GetInt32(rdr.GetOrdinal("YuDingShuLiang"));
                    item.DingDanHao = rdr["DingDanHao"].ToString();

                    item.AgencyJinE = rdr.GetDecimal(rdr.GetOrdinal("AgencyJinE"));
                    item.AgencyId = rdr["AgencyId"].ToString();

                    item.QianZhengGuoJiaId = rdr.GetInt32(rdr.GetOrdinal("QianZhengGuoJiaId"));
                    item.QianZhengName = rdr["QianZhengName"].ToString();

                    items.Add(item);
                }

                rdr.NextResult();

                if (rdr.Read())
                {

                }
            }

            return items;
        }

        /// <summary>
        /// 设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="xiaDanRenId">下单人编号</param>
        /// <param name="dingDanStatus">状态</param>
        /// <returns></returns>
        public int SheZhiDingDanStatus(string dingDanId, string xiaDanRenId, EyouSoft.Model.Enum.XianLuStructure.OrderStatus dingDanStatus)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_SheZhiDingDanStatus);

            _db.AddInParameter(cmd, "DingDanStatus", DbType.Byte, dingDanStatus);
            _db.AddInParameter(cmd, "DingDanId", DbType.AnsiStringFixedLength, dingDanId);
            _db.AddInParameter(cmd, "XiaDanRenId", DbType.AnsiStringFixedLength, xiaDanRenId);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }

        /// <summary>
        /// 设置付款状态，返回1成功，其它失败
        /// </summary>
        /// <param name="dingDanId">订单编号</param>
        /// <param name="xiaDanRenId">下单人编号</param>
        /// <param name="fuKuanStatus">状态</param>
        /// <param name="fuKuanTime">付款时间</param>
        /// <returns></returns>
        public int SheZhiFuKuanStatus(string dingDanId, string xiaDanRenId, EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus fuKuanStatus, DateTime fuKuanTime)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_SheZhiFuKuanStatus);

            _db.AddInParameter(cmd, "FuKuanStatus", DbType.Byte, fuKuanStatus);
            _db.AddInParameter(cmd, "DingDanId", DbType.AnsiStringFixedLength, dingDanId);
            _db.AddInParameter(cmd, "XiaDanRenId", DbType.AnsiStringFixedLength, xiaDanRenId);
            _db.AddInParameter(cmd, "FuKuanTime", DbType.DateTime, fuKuanTime);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }
        /// <summary>
        /// 支付完成执行方法
        /// </summary>
        /// <param name="info">订单</param>
        /// <returns></returns>
        public int SheZhiZhiFus(EyouSoft.Model.QianZhengStructure.MQianZhengDingDanInfo info)
        {
            DbCommand cmd = _db.GetSqlStringCommand("UPDATE dbo.tbl_QianZhengDingDan SET   FuKuanStatus=@FuKuanStatus,DingDanStatus=@DingDanStatus  WHERE DingDanId=@DingDanId ");

            _db.AddInParameter(cmd, "FuKuanStatus", DbType.Byte, info.FuKuanStatus);
            _db.AddInParameter(cmd, "DingDanStatus", DbType.Byte, info.DingDanStatus);
            _db.AddInParameter(cmd, "DingDanId", DbType.AnsiStringFixedLength, info.DingDanId);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : 0;
        }
        /// <summary>
        /// 根据订单状态获取订单数量
        /// </summary>
        /// <param name="Status">订单状态</param>
        /// <returns></returns>
        public int GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus Status)
        {
            DbCommand cmd = _db.GetSqlStringCommand("Select count(DingDanId) from tbl_QianZhengDingDan WHERE DingDanStatus=@Status   ");

            _db.AddInParameter(cmd, "Status", DbType.Byte, Status);

            object num = DbHelper.GetSingle(cmd, _db);
            return Convert.ToInt32(num);
        }
        #endregion
    }
}
