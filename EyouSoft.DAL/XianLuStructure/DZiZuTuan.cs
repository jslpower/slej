using System.Text;
using EyouSoft.Model;
using EyouSoft.Toolkit.DAL;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.Model.Enum;
using EyouSoft.Model.XianLuStructure;
using System;
using EyouSoft.IDAL.XianLuStructure;
using System.Collections.Generic;
using EyouSoft.Model.Enum.XianLuStructure;

namespace EyouSoft.DAL.XianLuStructure
{
    public class DZiZuTuan : DALBase, IZiZuTuan
    {
        #region
        const string SQL_UPDATE_SheZhiOrderStatus = "UPDATE [tbl_ZiZuTuan] SET [OrderState]=@OrderState WHERE [ZuTuanId]=@ZuTuanId ";
        const string SQL_UPDATE_SheZhiFuKuanStatus = "UPDATE [tbl_ZiZuTuan] SET [FuKuanStatus]=@FuKuanStatus WHERE [ZuTuanId]=@ZuTuanId";
        #endregion

         #region 初始化db
        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DZiZuTuan()
        {
            _db = base.SystemStore;
        }
        #endregion

        #region  方法

        /// <summary>
        /// 增加自组团
        /// </summary>
        /// <param name="model">数据集</param>
        /// <returns></returns>
        public int Add(MZiZuTuan model)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_JA_ZiZuTuan_ADD");
            _db.AddInParameter(cmd, "BaoXian", DbType.String, model.BaoXian);
            _db.AddInParameter(cmd, "BaoXianDay", DbType.Int32, model.BaoXianDay);
            _db.AddInParameter(cmd, "BXJiaGe", DbType.Decimal, model.BXJiaGe);
            _db.AddInParameter(cmd, "CanWuJia", DbType.Decimal, model.CanWuJia);
            _db.AddInParameter(cmd, "CarMoney", DbType.Decimal, model.CarMoney);
            _db.AddInParameter(cmd, "ChuFaTime", DbType.DateTime, model.ChuFaTime);
            _db.AddInParameter(cmd, "CRJiage", DbType.Decimal, model.CRJiage);
            _db.AddInParameter(cmd, "ETJiage", DbType.Decimal, model.ETJiage);
            _db.AddInParameter(cmd, "DaoYouMoney", DbType.Decimal, model.DaoYouMoney);
            _db.AddInParameter(cmd, "DaoYouNum", DbType.Int32, model.DaoYouNum);
            _db.AddInParameter(cmd, "RenShu", DbType.Int32, model.RenShu);
            _db.AddInParameter(cmd, "TourId", DbType.String, model.TourId);
            _db.AddInParameter(cmd, "UserType", DbType.Int32, model.UserType);
            _db.AddInParameter(cmd, "WanCanJia", DbType.Decimal, model.WanCanJia);
            _db.AddInParameter(cmd, "WanCanNum", DbType.Int32, model.WanCanNum);
            _db.AddInParameter(cmd, "WuCanJia", DbType.Decimal, model.WuCanJia);
            _db.AddInParameter(cmd, "WuCanNum", DbType.Int32, model.WuCanNum);
            _db.AddInParameter(cmd, "XDRId", DbType.String, model.XDRId);
            _db.AddInParameter(cmd, "XianLuId", DbType.String, model.XianLuId);
            _db.AddInParameter(cmd, "XianLuName", DbType.String, model.XianLuName);
            _db.AddInParameter(cmd, "ZaoCanJia", DbType.Decimal, model.ZaoCanJia);
            _db.AddInParameter(cmd, "ZaoCanNum", DbType.Int32, model.ZaoCanNum);
            _db.AddInParameter(cmd, "ZCMoney", DbType.Decimal, model.ZCMoney);
            _db.AddInParameter(cmd, "ZongMOney", DbType.Decimal, model.ZongMOney);
            _db.AddInParameter(cmd, "ZuTuanId", DbType.String, model.ZuTuanId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, model.IssueTime);
            _db.AddInParameter(cmd, "AgencyJinE", DbType.Decimal, model.AgencyJinE);
            _db.AddInParameter(cmd, "RSBXJiaGe", DbType.Decimal, model.RSBXJiaGe);
            _db.AddInParameter(cmd, "AgencyId", DbType.String, model.AgencyId);
            _db.AddInParameter(cmd, "JTBXJiaGe", DbType.Decimal, model.JTBXJiaGe);
            _db.AddInParameter(cmd, "ETAgencyJinE", DbType.Decimal, model.ETAgencyJinE);
            _db.AddInParameter(cmd, "ChengTuanNum", DbType.Int32, model.ChengTuanNum);
            _db.AddInParameter(cmd, "ErTongNum", DbType.Int32, model.ErTongNum);
            _db.AddInParameter(cmd, "DiPeiDaoYouNum", DbType.Int32, model.DiPeiDaoYouNum);
            _db.AddInParameter(cmd, "DiPeiRJJia", DbType.Decimal, model.DiPeiRJJia);
            _db.AddInParameter(cmd, "QuanPeiRJJia", DbType.Decimal, model.QuanPeiRJJia);
            _db.AddInParameter(cmd, "HangBanId", DbType.String, model.HangBanId);
            _db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            
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

            return Convert.ToInt32(_db.GetParameterValue(cmd, "Result"));
        }
        /// <summary>
        /// 增加自组团租车行程
        /// </summary>
        /// <param name="model">数据集</param>
        /// <returns></returns>
        public void AddXC(MZiZuTuanXingCheng model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" INSERT INTO [tbl_ZiZuTuanXingCheng]([ZiZuTuanId],[ZucheId],[CheNum] ");
            strSql.Append(" ,[QiDian],[ZhongDian],[FeiYong],[GongLiShu] ");
            strSql.Append(") values (");
            strSql.Append("@ZiZuTuanId,@ZucheId ,@CheNum,@QiDian,@ZhongDian,@FeiYong,@GongLiShu)	");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(cmd, "CheNum", DbType.Int32, model.CheNum);
            _db.AddInParameter(cmd, "FeiYong", DbType.Decimal, model.FeiYong);
            _db.AddInParameter(cmd, "GongLiShu", DbType.Decimal, model.GongLiShu);
            _db.AddInParameter(cmd, "QiDian", DbType.String, model.QiDian);
            _db.AddInParameter(cmd, "ZhongDian", DbType.String, model.ZhongDian);
            _db.AddInParameter(cmd, "ZiZuTuanId", DbType.String, model.ZiZuTuanId);
            _db.AddInParameter(cmd, "ZucheId", DbType.String, model.ZucheId);
            DbHelper.ExecuteSql(cmd, this._db);
        }

        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.XianLuStructure.MZiZuTuan> GetList(int PageSize, int PageIndex, string OrderBy, ref int RecordCount,MZiZuTuanSer searhmodel)
        {

            IList<EyouSoft.Model.XianLuStructure.MZiZuTuan> list = new List<EyouSoft.Model.XianLuStructure.MZiZuTuan>();

            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("select *  from tbl_ZiZuTuan");
            //if (searhmodel != null)
            //{
            //    strSql.Append(" where 1=1 ");
            //    if (searhmodel.IssueStarTime.HasValue)
            //    {
            //        strSql.Append(" and IssueTime>='"+searhmodel.IssueStarTime+"' ");
            //    }
            //    if (searhmodel.IssueEndTime.HasValue)
            //    {
            //        strSql.Append(" and IssueTime<='" + searhmodel.IssueEndTime + "' ");
            //    }
            //    if (!string.IsNullOrEmpty(searhmodel.XDRId))
            //    {
            //        strSql.Append(" and XDRId='" + searhmodel.XDRId + "' ");
            //    }
            //}

            StringBuilder fields = new StringBuilder();
            StringBuilder query = new StringBuilder();
            string tableName = "tbl_ZiZuTuan";
            string orderByString = " [IssueTime] DESC ";
            string sumString = "";

            #region fields
            fields.Append(" * ");
            #endregion

            #region sql where
            query.Append(" 1=1 ");

            if (searhmodel != null)
            {
                if (searhmodel.IssueStarTime.HasValue)
                {
                    query.Append(" and IssueTime>='" + searhmodel.IssueStarTime + "' ");
                }
                if (searhmodel.IssueEndTime.HasValue)
                {
                    query.Append(" and IssueTime<='" + searhmodel.IssueEndTime + "' ");
                }
                if (!string.IsNullOrEmpty(searhmodel.XDRId) && !string.IsNullOrEmpty(searhmodel.AgencyId))
                {
                    query.AppendFormat(" AND ( XDRId='{0}' or  AgencyId='{1}')", searhmodel.XDRId, searhmodel.AgencyId);
                }
                else if (!string.IsNullOrEmpty(searhmodel.XDRId))
                {
                    query.AppendFormat(" AND XDRId='{0}' ", searhmodel.XDRId);
                }
                else if (!string.IsNullOrEmpty(searhmodel.AgencyId))
                {
                    if (searhmodel.AgencyId == "0")
                    {
                        query.Append(" AND (AgencyId is null or  AgencyId = '')");
                    }
                    else
                    {
                        query.AppendFormat(" AND AgencyId = '{0}' ", searhmodel.AgencyId);
                    }
                }
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, PageSize, PageIndex, ref RecordCount, tableName, fields.ToString(), query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.XianLuStructure.MZiZuTuan();

                    info.OrderCode = rdr["OrderCode"].ToString();
                    info.BaoXian = rdr["BaoXian"].ToString();
                    info.BaoXianDay = rdr.GetInt32(rdr.GetOrdinal("BaoXianDay"));
                    info.BXJiaGe = rdr.GetDecimal(rdr.GetOrdinal("BXJiaGe"));
                    info.XianLuName = rdr["XianLuName"].ToString();
                    info.CanWuJia = rdr.GetDecimal(rdr.GetOrdinal("CanWuJia"));
                    info.CarMoney = rdr.GetDecimal(rdr.GetOrdinal("CarMoney"));
                    info.CRJiage = rdr.GetDecimal(rdr.GetOrdinal("CRJiage"));
                    info.DaoYouMoney = rdr.GetDecimal(rdr.GetOrdinal("DaoYouMoney"));
                    info.DaoYouNum = rdr.GetInt32(rdr.GetOrdinal("DaoYouNum"));
                    info.ETJiage = rdr.GetDecimal(rdr.GetOrdinal("ETJiage"));
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.TourId = rdr["TourId"].ToString();
                    info.WanCanJia = rdr.GetDecimal(rdr.GetOrdinal("WanCanJia"));
                    info.WanCanNum = rdr.GetInt32(rdr.GetOrdinal("WanCanNum"));
                    info.WuCanJia = rdr.GetDecimal(rdr.GetOrdinal("WuCanJia"));
                    info.WuCanNum = rdr.GetInt32(rdr.GetOrdinal("WuCanNum"));
                    info.XDRId = rdr["XDRId"].ToString();
                    info.XianLuId = rdr["XianLuId"].ToString();
                    info.XianLuName = rdr["XianLuName"].ToString();
                    info.ZaoCanJia = rdr.GetDecimal(rdr.GetOrdinal("ZaoCanJia"));
                    info.ZaoCanNum = rdr.GetInt32(rdr.GetOrdinal("ZaoCanNum"));
                    info.ZCMoney = rdr.GetDecimal(rdr.GetOrdinal("ZCMoney"));
                    info.ZongMOney = rdr.GetDecimal(rdr.GetOrdinal("ZongMOney"));
                    info.RenShu = rdr.GetInt32(rdr.GetOrdinal("RenShu"));
                    info.ChuFaTime = rdr.GetDateTime(rdr.GetOrdinal("ChuFaTime"));
                    info.ZuTuanId = rdr["ZuTuanId"].ToString();
                    info.UserType = (MemberTypes)rdr.GetByte(rdr.GetOrdinal("UserType"));
                    info.OrderState = (OrderStatus)rdr.GetByte(rdr.GetOrdinal("OrderState"));
                    info.AgencyJinE = rdr.GetDecimal(rdr.GetOrdinal("AgencyJinE"));
                    info.RSBXJiaGe = rdr.GetDecimal(rdr.GetOrdinal("RSBXJiaGe"));
                    info.ETAgencyJinE = rdr.GetDecimal(rdr.GetOrdinal("ETAgencyJinE"));
                    info.JTBXJiaGe = rdr.GetDecimal(rdr.GetOrdinal("JTBXJiaGe"));
                    if (rdr["AgencyId"] != null && rdr["AgencyId"] != DBNull.Value)
                    {
                        info.AgencyId = rdr["AgencyId"].ToString();
                    }
                    info.DiPeiRJJia = rdr.GetDecimal(rdr.GetOrdinal("DiPeiRJJia"));
                    info.QuanPeiRJJia = rdr.GetDecimal(rdr.GetOrdinal("QuanPeiRJJia"));
                    info.ChengTuanNum = rdr.GetInt32(rdr.GetOrdinal("ChengTuanNum"));
                    info.ErTongNum = rdr.GetInt32(rdr.GetOrdinal("ErTongNum"));
                    info.DiPeiDaoYouNum = rdr.GetInt32(rdr.GetOrdinal("DiPeiDaoYouNum"));
                    info.HangBanId = rdr["HangBanId"].ToString();
 
                    list.Add(info);
                }
            }
            return list;
        }
        /// <summary>
        /// 获取提现信息业务实体
        /// </summary>
        /// <param name="tiXianId">提现编号</param>
        /// <returns></returns>
        public MZiZuTuan GetInfo(string OrderId)
        {
            MZiZuTuan info = new MZiZuTuan();
            var cmd = _db.GetSqlStringCommand("SELECT * FROM tbl_ZiZuTuan WHERE ZuTuanId=@OrderId");
            _db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, OrderId);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new MZiZuTuan();

                    info.OrderCode = rdr["OrderCode"].ToString();
                    info.BaoXian = rdr["BaoXian"].ToString();
                    info.BaoXianDay = rdr.GetInt32(rdr.GetOrdinal("BaoXianDay"));
                    info.BXJiaGe = rdr.GetDecimal(rdr.GetOrdinal("BXJiaGe"));
                    info.XianLuName = rdr["XianLuName"].ToString();
                    info.CanWuJia = rdr.GetDecimal(rdr.GetOrdinal("CanWuJia"));
                    info.CarMoney = rdr.GetDecimal(rdr.GetOrdinal("CarMoney"));
                    info.CRJiage = rdr.GetDecimal(rdr.GetOrdinal("CRJiage"));
                    info.DaoYouMoney = rdr.GetDecimal(rdr.GetOrdinal("DaoYouMoney"));
                    info.DaoYouNum = rdr.GetInt32(rdr.GetOrdinal("DaoYouNum"));
                    info.ETJiage = rdr.GetDecimal(rdr.GetOrdinal("ETJiage"));
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.TourId = rdr["TourId"].ToString();
                    info.WanCanJia = rdr.GetDecimal(rdr.GetOrdinal("WanCanJia"));
                    info.WanCanNum = rdr.GetInt32(rdr.GetOrdinal("WanCanNum"));
                    info.WuCanJia = rdr.GetDecimal(rdr.GetOrdinal("WuCanJia"));
                    info.WuCanNum = rdr.GetInt32(rdr.GetOrdinal("WuCanNum"));
                    info.XDRId = rdr["XDRId"].ToString();
                    info.XianLuId = rdr["XianLuId"].ToString();
                    info.XianLuName = rdr["XianLuName"].ToString();
                    info.ZaoCanJia = rdr.GetDecimal(rdr.GetOrdinal("ZaoCanJia"));
                    info.ZaoCanNum = rdr.GetInt32(rdr.GetOrdinal("ZaoCanNum"));
                    info.ZCMoney = rdr.GetDecimal(rdr.GetOrdinal("ZCMoney"));
                    info.ZongMOney = rdr.GetDecimal(rdr.GetOrdinal("ZongMOney"));
                    info.RenShu = rdr.GetInt32(rdr.GetOrdinal("RenShu"));
                    info.ChuFaTime = rdr.GetDateTime(rdr.GetOrdinal("ChuFaTime"));
                    info.UserType = (MemberTypes)rdr.GetByte(rdr.GetOrdinal("UserType"));
                    info.ZuTuanId = rdr["ZuTuanId"].ToString();
                    info.OrderState = (OrderStatus)rdr.GetByte(rdr.GetOrdinal("OrderState"));
                    info.AgencyJinE = rdr.GetDecimal(rdr.GetOrdinal("AgencyJinE"));
                    info.RSBXJiaGe = rdr.GetDecimal(rdr.GetOrdinal("RSBXJiaGe"));
                    info.ETAgencyJinE = rdr.GetDecimal(rdr.GetOrdinal("ETAgencyJinE"));
                    info.JTBXJiaGe = rdr.GetDecimal(rdr.GetOrdinal("JTBXJiaGe"));
                    info.ZongJinE = rdr.GetDecimal(rdr.GetOrdinal("ZongJinE"));
                    if (rdr["AgencyId"] != null && rdr["AgencyId"] != DBNull.Value)
                    {
                        info.AgencyId = rdr["AgencyId"].ToString();
                    }
                    info.DiPeiRJJia = rdr.GetDecimal(rdr.GetOrdinal("DiPeiRJJia"));
                    info.QuanPeiRJJia = rdr.GetDecimal(rdr.GetOrdinal("QuanPeiRJJia"));
                    info.ChengTuanNum = rdr.GetInt32(rdr.GetOrdinal("ChengTuanNum"));
                    info.ErTongNum = rdr.GetInt32(rdr.GetOrdinal("ErTongNum"));
                    info.DiPeiDaoYouNum = rdr.GetInt32(rdr.GetOrdinal("DiPeiDaoYouNum"));
                    info.HangBanId = rdr["HangBanId"].ToString();
                }
            }

            return info;
        }
        /// <summary>
        /// 获取自组团租车行程
        /// </summary>
        /// <param name="orderid">自组团id</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.XianLuStructure.MZiZuTuanXingCheng> GetXCList(string orderid)
        {

            IList<EyouSoft.Model.XianLuStructure.MZiZuTuanXingCheng> list = new List<EyouSoft.Model.XianLuStructure.MZiZuTuanXingCheng>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from tbl_ZiZuTuanXingCheng");
            strSql.Append(" where ZiZuTuanId='"+orderid+"' ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.XianLuStructure.MZiZuTuanXingCheng();

                    info.ZucheId = rdr["ZucheId"].ToString();
                    info.CheNum = rdr.GetInt32(rdr.GetOrdinal("CheNum"));
                    info.QiDian = rdr["QiDian"].ToString();
                    info.ZhongDian = rdr["ZhongDian"].ToString();
                    info.GongLiShu = rdr.GetDecimal(rdr.GetOrdinal("GongLiShu"));
                    info.FeiYong = rdr.GetDecimal(rdr.GetOrdinal("FeiYong"));
                    list.Add(info);
                }
            }
            return list;
        }

        /// <summary>
        /// 设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="memberId">会员编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int SheZhiOrderStatus(string orderId, OrderStatus status)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_SheZhiOrderStatus);

            _db.AddInParameter(cmd, "OrderState", DbType.Byte, status);
            _db.AddInParameter(cmd, "ZuTuanId", DbType.AnsiStringFixedLength, orderId);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }
        /// <summary>
        /// 支付完成执行方法
        /// </summary>
        /// <param name="info">订单</param>
        /// <returns></returns>
        public int SheZhiZhiFus(MZiZuTuan info)
        {
            DbCommand cmd = _db.GetSqlStringCommand("UPDATE tbl_ZiZuTuan SET FuKuanStatus=@FuKuanStatus ,OrderState=@OrderState WHERE [ZuTuanId]=@ZuTuanId ");

            _db.AddInParameter(cmd, "FuKuanStatus", DbType.Byte, info.FuKuanStatus);
            _db.AddInParameter(cmd, "OrderState", DbType.Byte, info.OrderState);
            _db.AddInParameter(cmd, "ZuTuanId", DbType.AnsiStringFixedLength, info.ZuTuanId);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : 0;
        }
        #endregion
    }
}
