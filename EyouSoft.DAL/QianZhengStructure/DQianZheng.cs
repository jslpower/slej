//签证信息 汪奇志 2013-11-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit.DAL;
using EyouSoft.Toolkit;
using EyouSoft.Model.Enum.XianLuStructure;

namespace EyouSoft.DAL.QianZhengStructure
{
    /// <summary>
    /// 签证信息
    /// </summary>
    public class DQianZheng : DALBase, EyouSoft.IDAL.QianZhengStructure.IQianZheng
    {
        #region static constants
        //static constants
        const string SQL_INSERT_Insert = "INSERT INTO [tbl_QianZheng]([QianZhengId],[Name],[GuoJiaId],[JiaGe],[JiaGeMenShi],[BanLiShiJian],[YouXiaoQi],[TingLiuShiJian],[MianShi],[YaoQingHan],[SuoShuLingQu],[ShouLiFanWei],[SuoXuCaiLiao],[TeBieTiShi],[ZhuYiShiXiang],[FaBuRenId],[IssueTime],[LatestTime],[GysId],[QianZhengLeiXing],[IsFenXiao],[FileUpLoad]) VALUES (@QianZhengId,@Name,@GuoJiaId,@JiaGe,@JiaGeMenShi,@BanLiShiJian,@YouXiaoQi,@TingLiuShiJian,@MianShi,@YaoQingHan,@SuoShuLingQu,@ShouLiFanWei,@SuoXuCaiLiao,@TeBieTiShi,@ZhuYiShiXiang,@FaBuRenId,@IssueTime,@LatestTime,@GysId,@QianZhengLeiXing,@IsFenXiao,@FileUpLoad)";
        const string SQL_UPDATE_Update = "UPDATE [tbl_QianZheng] SET [Name]=@Name,[GuoJiaId]=@GuoJiaId,[JiaGe]=@JiaGe,[JiaGeMenShi]=@JiaGeMenShi,[BanLiShiJian]=@BanLiShiJian,[YouXiaoQi]=@YouXiaoQi,[TingLiuShiJian]=@TingLiuShiJian,[MianShi]=@MianShi,[YaoQingHan]=@YaoQingHan,[SuoShuLingQu]=@SuoShuLingQu,[ShouLiFanWei]=@ShouLiFanWei,[SuoXuCaiLiao]=@SuoXuCaiLiao,[TeBieTiShi]=@TeBieTiShi,[ZhuYiShiXiang]=@ZhuYiShiXiang,[LatestTime]=@LatestTime,[GysId]=@GysId,[QianZhengLeiXing]=@QianZhengLeiXing,[IsFenXiao]=@IsFenXiao,[FileUpLoad]=@FileUpLoad WHERE [QianZhengId]=@QianZhengId";
        const string SQL_DELETE_Delete = "DELETE FROM [tbl_QianZheng] WHERE [QianZhengId]=@QianZhengId AND [FaBuRenId]=@FaBuRenId";
        const string SQL_SELECT_GetInfo = "SELECT * FROM [tbl_QianZheng] WHERE [QianZhengId]=@QianZhengId";
        const string SQL_SELECT_GetDingDanShu = "SELECT COUNT(*) FROM [tbl_QianZhengDingDan] WHERE [QianZhengId]=@QianZhengId";
        const string SQL_UPDATE_SheZhiOrderStatus = "UPDATE [tbl_QianZhengDingDan] SET [DingDanStatus]=@Status WHERE [DingDanId]=@OrderId ";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DQianZheng()
        {
            _db = SystemStore;
        }
        #endregion

        #region private members

        #endregion

        #region IQianZheng 成员
        /// <summary>
        /// 写入签证信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(EyouSoft.Model.QianZhengStructure.MQianZhengInfo info)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_INSERT_Insert);

            _db.AddInParameter(cmd, "QianZhengId", DbType.AnsiStringFixedLength, info.QianZhengId);
            _db.AddInParameter(cmd, "Name", DbType.String, info.Name);
            _db.AddInParameter(cmd, "GuoJiaId", DbType.Int32, info.GuoJiaId);
            _db.AddInParameter(cmd, "JiaGe", DbType.Decimal, info.JiaGe);
            _db.AddInParameter(cmd, "JiaGeMenShi", DbType.Decimal, info.JiaGeMenShi);
            _db.AddInParameter(cmd, "BanLiShiJian", DbType.String, info.BanLiShiJian);
            _db.AddInParameter(cmd, "YouXiaoQi", DbType.Int32, info.YouXiaoQi);
            _db.AddInParameter(cmd, "TingLiuShiJian", DbType.Int32, info.TingLiuShiJian);
            _db.AddInParameter(cmd, "MianShi", DbType.String, info.MianShi);
            _db.AddInParameter(cmd, "YaoQingHan", DbType.String, info.YaoQingHan);
            _db.AddInParameter(cmd, "SuoShuLingQu", DbType.String, info.SuoShuLingQu);
            _db.AddInParameter(cmd, "ShouLiFanWei", DbType.String, info.ShouLiFanWei);
            _db.AddInParameter(cmd, "SuoXuCaiLiao", DbType.String, info.SuoXuCaiLiao);
            _db.AddInParameter(cmd, "TeBieTiShi", DbType.String, info.TeBieTiShi);
            _db.AddInParameter(cmd, "ZhuYiShiXiang", DbType.String, info.ZhuYiShiXiang);
            _db.AddInParameter(cmd, "FaBuRenId", DbType.Int32, info.FaBuRenId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "LatestTime", DbType.DateTime, info.LatestTime);
            _db.AddInParameter(cmd, "GysId", DbType.AnsiStringFixedLength, info.GysId);
            _db.AddInParameter(cmd, "QianZhengLeiXing", DbType.Byte, info.QianZhengLeiXing);
            _db.AddInParameter(cmd, "IsFenXiao", DbType.AnsiStringFixedLength, info.IsFenXiao ? "1" : "0");
            _db.AddInParameter(cmd, "FileUpLoad", DbType.String, info.FileUpLoad);

            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }

        /// <summary>
        /// 更新签证信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(EyouSoft.Model.QianZhengStructure.MQianZhengInfo info)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_Update);

            _db.AddInParameter(cmd, "QianZhengId", DbType.AnsiStringFixedLength, info.QianZhengId);
            _db.AddInParameter(cmd, "Name", DbType.String, info.Name);
            _db.AddInParameter(cmd, "GuoJiaId", DbType.Int32, info.GuoJiaId);
            _db.AddInParameter(cmd, "JiaGe", DbType.Decimal, info.JiaGe);
            _db.AddInParameter(cmd, "JiaGeMenShi", DbType.Decimal, info.JiaGeMenShi);
            _db.AddInParameter(cmd, "BanLiShiJian", DbType.String, info.BanLiShiJian);
            _db.AddInParameter(cmd, "YouXiaoQi", DbType.Int32, info.YouXiaoQi);
            _db.AddInParameter(cmd, "TingLiuShiJian", DbType.Int32, info.TingLiuShiJian);
            _db.AddInParameter(cmd, "MianShi", DbType.String, info.MianShi);
            _db.AddInParameter(cmd, "YaoQingHan", DbType.String, info.YaoQingHan);
            _db.AddInParameter(cmd, "SuoShuLingQu", DbType.String, info.SuoShuLingQu);
            _db.AddInParameter(cmd, "ShouLiFanWei", DbType.String, info.ShouLiFanWei);
            _db.AddInParameter(cmd, "SuoXuCaiLiao", DbType.String, info.SuoXuCaiLiao);
            _db.AddInParameter(cmd, "TeBieTiShi", DbType.String, info.TeBieTiShi);
            _db.AddInParameter(cmd, "ZhuYiShiXiang", DbType.String, info.ZhuYiShiXiang);
            _db.AddInParameter(cmd, "LatestTime", DbType.DateTime, info.LatestTime);
            _db.AddInParameter(cmd, "GysId", DbType.AnsiStringFixedLength, info.GysId);
            _db.AddInParameter(cmd, "QianZhengLeiXing", DbType.Byte, info.QianZhengLeiXing);
            _db.AddInParameter(cmd, "IsFenXiao", DbType.AnsiStringFixedLength, info.IsFenXiao ? "1" : "0");
            _db.AddInParameter(cmd, "FileUpLoad", DbType.String, info.FileUpLoad);
            

            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }

        /// <summary>
        /// 删除签证信息，返回1成功，其它失败
        /// </summary>
        /// <param name="qianZhengId">签证编号</param>
        /// <param name="faBuRenId">发布人编号</param>
        /// <returns></returns>
        public int Delete(string qianZhengId, int faBuRenId)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_DELETE_Delete);

            _db.AddInParameter(cmd, "QianZhengId", DbType.AnsiStringFixedLength, qianZhengId);
            _db.AddInParameter(cmd, "FaBuRenId", DbType.Int32, faBuRenId);

            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }

        /// <summary>
        /// 获取签证信息业务实体
        /// </summary>
        /// <param name="qianZhengId">签证编号</param>
        /// <returns></returns>
        public EyouSoft.Model.QianZhengStructure.MQianZhengInfo GetInfo(string qianZhengId)
        {
            EyouSoft.Model.QianZhengStructure.MQianZhengInfo item = null;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetInfo);

            _db.AddInParameter(cmd, "QianZhengId", DbType.AnsiStringFixedLength, qianZhengId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    item = new EyouSoft.Model.QianZhengStructure.MQianZhengInfo();

                    item.BanLiShiJian = rdr["BanLiShiJian"].ToString();
                    item.FaBuRenId = rdr.GetInt32(rdr.GetOrdinal("FaBuRenId"));
                    item.GuoJiaId = rdr.GetInt32(rdr.GetOrdinal("GuoJiaId"));
                    item.QianZhengId = rdr["QianZhengId"].ToString();
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.JiaGe = rdr.GetDecimal(rdr.GetOrdinal("JiaGe"));
                    item.JiaGeMenShi = rdr.GetDecimal(rdr.GetOrdinal("JiaGeMenShi"));
                    item.LatestTime = rdr.GetDateTime(rdr.GetOrdinal("LatestTime"));
                    item.MianShi = rdr["MianShi"].ToString();
                    item.Name = rdr["Name"].ToString();
                    item.ShouLiFanWei = rdr["ShouLiFanWei"].ToString();
                    item.SuoShuLingQu = rdr["SuoShuLingQu"].ToString();
                    item.SuoXuCaiLiao = rdr["SuoXuCaiLiao"].ToString();
                    item.TeBieTiShi = rdr["TeBieTiShi"].ToString();
                    item.TingLiuShiJian = rdr.GetInt32(rdr.GetOrdinal("TingLiuShiJian"));
                    item.YaoQingHan = rdr["YaoQingHan"].ToString();
                    item.YouXiaoQi = rdr.GetInt32(rdr.GetOrdinal("YouXiaoQi"));
                    item.ZhuYiShiXiang = rdr["ZhuYiShiXiang"].ToString();
                    item.GysId = rdr["GysId"].ToString();
                    item.QianZhengLeiXing = (EyouSoft.Model.Enum.QianZhengStructure.QianZhengLeiXing)rdr.GetByte(rdr.GetOrdinal("QianZhengLeiXing"));
                    item.IsFenXiao = rdr["IsFenXiao"].ToString() == "1";
                    item.FileUpLoad = rdr["FileUpLoad"].ToString();
                }
            }

            return item;
        }

        /// <summary>
        /// 获取签证信息集合
        /// </summary>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询信息</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.QianZhengStructure.MQianZhengInfo> GetQianZhengs(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.QianZhengStructure.MQianZhengChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.QianZhengStructure.MQianZhengInfo> items = new List<EyouSoft.Model.QianZhengStructure.MQianZhengInfo>();

            StringBuilder fields = new StringBuilder();
            StringBuilder query = new StringBuilder();
            string tableName = "tbl_QianZheng";
            string orderByString = "LatestTime DESC";
            string sumString = "";

            #region fields
            fields.Append(" QianZhengId,Name,JiaGe,JiaGeMenShi,GuoJiaId,GysId,FaBuRenId,SuoShuLingQu,ShouLiFanWei,QianZhengLeiXing,BanLiShiJian,YouXiaoQi,TingLiuShiJian,MianShi,YaoQingHan,IsIndex");
            #endregion

            #region sql where
            query.Append(" 1=1 ");
            if (chaXun != null)
            {
                if (chaXun.FaBuRenId.HasValue)
                {
                    query.AppendFormat(" AND FaBuRenId={0} ", chaXun.FaBuRenId.Value);
                }
                if (chaXun.GuoJiaId.HasValue)
                {
                    query.AppendFormat(" AND GuoJiaId={0} ", chaXun.GuoJiaId.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.GysId))
                {
                    query.AppendFormat(" AND GysId='{0}' ", chaXun.GysId);
                }
                if (!string.IsNullOrEmpty(chaXun.Name))
                {
                    query.AppendFormat(" AND Name LIKE '%{0}%' ", chaXun.Name);
                }
                if (!string.IsNullOrEmpty(chaXun.SuoShuLingQu))
                {
                    query.AppendFormat(" AND SuoShuLingQu LIKE '%{0}%' ", chaXun.SuoShuLingQu);
                }
                if (!string.IsNullOrEmpty(chaXun.ShouLiFanWei))
                {
                    query.AppendFormat(" AND ShouLiFanWei LIKE '%{0}%' ", chaXun.ShouLiFanWei);
                }
                if (chaXun.QianZhengLeiXing.HasValue)
                {
                    query.AppendFormat(" AND QianZhengLeiXing={0} ", (int)chaXun.QianZhengLeiXing.Value);
                }
                if (chaXun.IsFenXiao.HasValue)
                {
                    query.AppendFormat(" AND IsFenXiao='{0}' ", chaXun.IsFenXiao.Value ? "1" : "0");
                }
                if (chaXun.IsIndex != null && chaXun.IsIndex.Length > 0)
                {
                    query.Append(" AND IsIndex IN(" + Utils.GetSqlIn(chaXun.IsIndex) + ") ");
                }
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.QianZhengStructure.MQianZhengInfo();

                    item.QianZhengId = rdr["QianZhengId"].ToString();
                    item.Name = rdr["Name"].ToString();
                    item.JiaGe = rdr.GetDecimal(rdr.GetOrdinal("JiaGe"));
                    item.JiaGeMenShi = rdr.GetDecimal(rdr.GetOrdinal("JiaGeMenShi"));
                    item.GuoJiaId = rdr.GetInt32(rdr.GetOrdinal("GuoJiaId"));
                    item.GysId = rdr["GysId"].ToString();
                    item.FaBuRenId = rdr.GetInt32(rdr.GetOrdinal("FaBuRenId"));
                    item.QianZhengLeiXing = (EyouSoft.Model.Enum.QianZhengStructure.QianZhengLeiXing)rdr.GetByte(rdr.GetOrdinal("QianZhengLeiXing"));
                    item.SuoShuLingQu = rdr["SuoShuLingQu"].ToString();
                    item.BanLiShiJian = rdr["BanLiShiJian"].ToString();
                    item.YouXiaoQi = rdr.GetInt32(rdr.GetOrdinal("YouXiaoQi"));
                    item.TingLiuShiJian = rdr.GetInt32(rdr.GetOrdinal("TingLiuShiJian"));
                    item.MianShi = rdr["MianShi"].ToString();
                    item.YaoQingHan = rdr["YaoQingHan"].ToString();
                    item.IsIndex = (EyouSoft.Model.Enum.XianLuStructure.XianLuZT)rdr.GetByte(rdr.GetOrdinal("IsIndex"));
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
        /// 根据条件获取前几条数据
        /// </summary>
        /// <param name="top">数据量</param>
        /// <param name="chaXun">条件</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.QianZhengStructure.MQianZhengInfo> GetTopQianZheng(int top, EyouSoft.Model.QianZhengStructure.MQianZhengChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.QianZhengStructure.MQianZhengInfo> items = new List<EyouSoft.Model.QianZhengStructure.MQianZhengInfo>();

            #region sql
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT TOP(@TopExpression) ");
            sql.Append(" QianZhengId,Name,JiaGe,JiaGeMenShi,GuoJiaId,GysId,FaBuRenId,SuoShuLingQu,ShouLiFanWei,QianZhengLeiXing,BanLiShiJian,YouXiaoQi,TingLiuShiJian,MianShi,YaoQingHan ");
            sql.Append(" FROM tbl_QianZheng ");
            sql.Append(" WHERE 1=1 ");
            if (chaXun != null)
            {
                if (chaXun.FaBuRenId.HasValue)
                {
                    sql.AppendFormat(" AND FaBuRenId={0} ", chaXun.FaBuRenId.Value);
                }
                if (chaXun.GuoJiaId.HasValue)
                {
                    sql.AppendFormat(" AND GuoJiaId={0} ", chaXun.GuoJiaId.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.GysId))
                {
                    sql.AppendFormat(" AND GysId='{0}' ", chaXun.GysId);
                }
                if (!string.IsNullOrEmpty(chaXun.Name))
                {
                    sql.AppendFormat(" AND Name LIKE '%{0}%' ", chaXun.Name);
                }
                if (!string.IsNullOrEmpty(chaXun.SuoShuLingQu))
                {
                    sql.AppendFormat(" AND SuoShuLingQu LIKE '%{0}%' ", chaXun.SuoShuLingQu);
                }
                if (!string.IsNullOrEmpty(chaXun.ShouLiFanWei))
                {
                    sql.AppendFormat(" AND ShouLiFanWei LIKE '%{0}%' ", chaXun.ShouLiFanWei);
                }
                if (chaXun.QianZhengLeiXing.HasValue)
                {
                    sql.AppendFormat(" AND QianZhengLeiXing={0} ", (int)chaXun.QianZhengLeiXing.Value);
                }
                if (chaXun.IsFenXiao.HasValue)
                {
                    sql.AppendFormat(" AND IsFenXiao='{0}' ", chaXun.IsFenXiao.Value ? "1" : "0");
                }
                if (chaXun.IsIndex != null && chaXun.IsIndex.Length > 0)
                {
                    sql.Append(" AND IsIndex IN(" + Utils.GetSqlIn(chaXun.IsIndex) + ") ");
                }
            }


            sql.Append(" ORDER BY LatestTime DESC ");
            #endregion

            DbCommand cmd = _db.GetSqlStringCommand(sql.ToString());
            _db.AddInParameter(cmd, "TopExpression", DbType.Int32, top);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.QianZhengStructure.MQianZhengInfo();

                    item.QianZhengId = rdr["QianZhengId"].ToString();
                    item.Name = rdr["Name"].ToString();
                    item.JiaGe = rdr.GetDecimal(rdr.GetOrdinal("JiaGe"));
                    item.JiaGeMenShi = rdr.GetDecimal(rdr.GetOrdinal("JiaGeMenShi"));
                    item.GuoJiaId = rdr.GetInt32(rdr.GetOrdinal("GuoJiaId"));
                    item.GysId = rdr["GysId"].ToString();
                    item.FaBuRenId = rdr.GetInt32(rdr.GetOrdinal("FaBuRenId"));
                    item.QianZhengLeiXing = (EyouSoft.Model.Enum.QianZhengStructure.QianZhengLeiXing)rdr.GetByte(rdr.GetOrdinal("QianZhengLeiXing"));
                    item.SuoShuLingQu = rdr["SuoShuLingQu"].ToString();
                    item.BanLiShiJian = rdr["BanLiShiJian"].ToString();
                    item.YouXiaoQi = rdr.GetInt32(rdr.GetOrdinal("YouXiaoQi"));
                    item.TingLiuShiJian = rdr.GetInt32(rdr.GetOrdinal("TingLiuShiJian"));
                    item.MianShi = rdr["MianShi"].ToString();
                    item.YaoQingHan = rdr["YaoQingHan"].ToString();

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
        /// 获取签证下订单数
        /// </summary>
        /// <param name="qianZhengId">签证编号</param>
        /// <returns></returns>
        public int GetDingDanShu(string qianZhengId)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetDingDanShu);

            _db.AddInParameter(cmd, "QianZhengId", DbType.AnsiStringFixedLength, qianZhengId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    return rdr.GetInt32(0);
                }
            }

            return 1;
        }
        /// <summary>
        /// 设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int SheZhiOrderStatus(string orderId, OrderStatus status)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_SheZhiOrderStatus);

            _db.AddInParameter(cmd, "Status", DbType.Byte, status);
            _db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, orderId);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        public int UpdateState(string Id, EyouSoft.Model.Enum.XianLuStructure.XianLuZT state)
        {
            string sql = "update tbl_QianZheng set IsIndex=@IsIndex where QianZhengId=@QianZhengId";
            DbCommand cmd = this._db.GetSqlStringCommand(sql);

            this._db.AddInParameter(cmd, "QianZhengId", DbType.String, Id);
            this._db.AddInParameter(cmd, "IsIndex", DbType.Byte, (int)state);

            return DbHelper.ExecuteSql(cmd, this._db);
        }
        #endregion
    }
}
