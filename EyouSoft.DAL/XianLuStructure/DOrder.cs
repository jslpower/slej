//线路产品订单相关信息数据访问类 汪奇志 2013-03-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.Model.Enum.XianLuStructure;
using EyouSoft.Model.XianLuStructure;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit;

namespace EyouSoft.DAL.XianLuStructure
{
    /// <summary>
    /// 线路产品订单相关信息数据访问类
    /// </summary>
    public class DOrder : DALBase, EyouSoft.IDAL.XianLuStructure.IOrder
    {
        #region static constants
        //static constants
        const string SQL_SELECT_GetInfo = "SELECT * FROM [view_XianLuTourOrder] WHERE [OrderId]=@OrderId";
        const string SQL_SELECT_GetYouKes = "SELECT * FROM [tbl_XianLuTourOrderYouKe] WHERE [OrderId]=@OrderId ORDER BY [IdentityId] ASC";
        const string SQL_UPDATE_SheZhiOrderStatus = "UPDATE [tbl_XianLuTourOrder] SET [Status]=@Status WHERE [OrderId]=@OrderId ";
        const string SQL_INSERT_InsertOrderHistory = "INSERT INTO [tbl_XianLuTourOrderHistory]([OrderId],[Status],[BeiZhu],[LeiXing],[OperatorId],[IssueTime]) VALUES (@OrderId,@Status,@BeiZhu,@LeiXing,@OperatorId,@IssueTime)";
        const string SQL_UPDATE_SheZhiFuKuanStatus = "UPDATE [tbl_XianLuTourOrder] SET [FuKuanStatus]=@FuKuanStatus WHERE [OrderId]=@OrderId AND [OperatorId]=@MemberId";
        const string SQL_SELECT_GetOrderHistorys = "SELECT * FROM [view_XianLuTour_OrderHistory] WHERE [OrderId]=@OrderId";
        const string SQL_SELECT_GetTraffice = "SELECT * FROM [tbl_XianLuTourTraffice] WHERE [TrafficId]=@TrafficeId and [XianLuId]=@XianluId";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DOrder()
        {
            _db = SystemStore;
        }
        #endregion

        #region private members
        /// <summary>
        /// 创建订单联系人信息XML
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        string CreateLxrXml(MOrderInfo info)
        {
            //联系人MXL:<root><info LxrName="" LxrTelephone="" LxrGender="" LxrZhengJianType="" LxrZhengJianCode="" /></root>
            StringBuilder s = new StringBuilder();
            s.Append("<root>");
            s.AppendFormat("<info LxrName=\"{0}\" LxrTelephone=\"{1}\" LxrGender=\"{2}\" LxrZhengJianType=\"{3}\" LxrZhengJianCode=\"{4}\" />", Utils.ReplaceXmlSpecialCharacter(info.LxrName)
                , Utils.ReplaceXmlSpecialCharacter(info.LxrTelephone)
                , (int)info.LxrGender
                , (int)info.LxrZhengJianType
                , Utils.ReplaceXmlSpecialCharacter(info.LxrZhengJianCode));
            s.Append("</root>");
            return s.ToString();
        }

        /// <summary>
        /// 创建订单游客信息XML
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        string CreateYouKeXml(IList<MOrderYouKeInfo> items)
        {
            //游客XML:<root><info YouKeId="" Name="" Telephone="" Mobile="" Gender="" LeiXing="" IdCode="" ZhengJianType="" ZhengJianCode="" BeiZhu="" /></root>
            if (items == null || items.Count == 0) return string.Empty;

            StringBuilder s = new StringBuilder();
            s.Append("<root>");

            foreach (var item in items)
            {
                s.Append("<info ");
                s.AppendFormat(" YouKeId=\"{0}\"", item.YouKeId);
                s.AppendFormat(" Name=\"{0}\"", Utils.ReplaceXmlSpecialCharacter(item.Name));
                s.AppendFormat(" Telephone=\"{0}\"", Utils.ReplaceXmlSpecialCharacter(item.Telephone));
                s.AppendFormat(" Mobile=\"{0}\"", Utils.ReplaceXmlSpecialCharacter(item.Mobile));
                s.AppendFormat(" Gender=\"{0}\"", (int)item.Gender);
                s.AppendFormat(" LeiXing=\"{0}\"", (int)item.LeiXing);
                s.AppendFormat(" IdCode=\"{0}\"", Utils.ReplaceXmlSpecialCharacter(item.IdCode));
                s.AppendFormat(" ZhengJianType=\"{0}\"", (int)item.ZhengJianType);
                s.AppendFormat(" ZhengJianCode=\"{0}\"", Utils.ReplaceXmlSpecialCharacter(item.ZhengJianCode));
                s.AppendFormat(" BeiZhu=\"{0}\"", Utils.ReplaceXmlSpecialCharacter(item.BeiZhu));
                s.Append(" />");
            }
            s.Append("</root>");

            return s.ToString();
        }

        /// <summary>
        /// 获取订单游客信息集合
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <returns></returns>
        IList<MOrderYouKeInfo> GetYouKes(string orderId)
        {
            IList<MOrderYouKeInfo> items = new List<MOrderYouKeInfo>();
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetYouKes);
            _db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, orderId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new MOrderYouKeInfo();

                    item.BeiZhu = rdr["BeiZhu"].ToString();
                    item.Gender = (EyouSoft.Model.Enum.Gender)rdr.GetByte(rdr.GetOrdinal("Gender"));
                    item.IdCode = rdr["IdCode"].ToString();
                    item.IdentityId = rdr.GetInt32(rdr.GetOrdinal("IdentityId"));
                    item.LeiXing = (EyouSoft.Model.Enum.YouKeType)rdr.GetByte(rdr.GetOrdinal("LeiXing"));
                    item.Mobile = rdr["Mobile"].ToString();
                    item.Name = rdr["Name"].ToString();
                    item.Telephone = rdr["Telephone"].ToString();
                    item.YouKeId = rdr.GetString(rdr.GetOrdinal("YouKeId"));
                    item.ZhengJianCode = rdr["ZhengJianCode"].ToString();
                    item.ZhengJianType = (EyouSoft.Model.Enum.CardType)rdr.GetByte(rdr.GetOrdinal("ZhengJianType"));

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取订单游客信息集合
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <returns></returns>
        IList<MXianLuTourTraffice> GetTraffice(string TrafficeId,string XianluId)
        {
            IList<MXianLuTourTraffice> items = new List<MXianLuTourTraffice>();
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetTraffice);
            _db.AddInParameter(cmd, "XianluId", DbType.String, XianluId);
            _db.AddInParameter(cmd, "TrafficeId", DbType.String, TrafficeId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new MXianLuTourTraffice();

                    item.Traffic_01 = rdr["Traffic_01"].ToString();
                    item.Traffic_02 = rdr["Traffic_02"].ToString();
                    items.Add(item);
                }
            }

            return items;
        }
        /// <summary>
        /// 获取订单变更历史记录信息
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <returns></returns>
        IList<MOrderHistoryInfo> GetOrderHistorys(string orderId)
        {
            IList<MOrderHistoryInfo> items = new List<MOrderHistoryInfo>();
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetOrderHistorys);
            _db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, orderId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new MOrderHistoryInfo();

                    item.BeiZhu = rdr["BeiZhu"].ToString();
                    item.IdentityId = rdr.GetInt32(rdr.GetOrdinal("IdentityId"));
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.LeiXing = (OrderHistoryLeiXing)rdr.GetByte(rdr.GetOrdinal("LeiXing"));
                    item.OperatorId = rdr["OperatorId"].ToString();
                    item.OperatorLeiXing = (EyouSoft.Model.Enum.OperatorLeiXing)rdr.GetInt32(rdr.GetOrdinal("T"));
                    item.OperatorName = rdr["OperatorName"].ToString();
                    item.OrderId = orderId;
                    item.Status = (OrderStatus)rdr.GetByte(rdr.GetOrdinal("Status"));

                    items.Add(item);
                }
            }

            return items;
        }
        #endregion

        #region EyouSoft.IDAL.XianLuStructure.IOrder 成员
        /// <summary>
        /// 写入订单信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MOrderInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_XianLuOrder_Insert");

            _db.AddInParameter(cmd, "@OrderId", DbType.AnsiStringFixedLength, info.OrderId);
            _db.AddInParameter(cmd, "@XianLuId", DbType.AnsiStringFixedLength, info.XianLuId);
            _db.AddInParameter(cmd, "@TourId", DbType.AnsiStringFixedLength, info.TourId);
            _db.AddOutParameter(cmd, "@OrderCode", DbType.String, 255);
            _db.AddInParameter(cmd, "@Status", DbType.Byte, info.Status);
            _db.AddInParameter(cmd, "@ChengRenShu", DbType.Int32, info.ChengRenShu);
            _db.AddInParameter(cmd, "@ErTongShu", DbType.Int32, info.ErTongShu);
            _db.AddInParameter(cmd, "@JSJCR", DbType.Decimal, info.JSJCR);
            _db.AddInParameter(cmd, "@JSJER", DbType.Decimal, info.JSJER);
            _db.AddInParameter(cmd, "@JinE", DbType.Decimal, info.JinE);
            _db.AddInParameter(cmd, "@FuKuanStatus", DbType.Byte, info.FuKuanStatus);
            _db.AddInParameter(cmd, "@LDate", DbType.DateTime, DateTime.Today);
            _db.AddInParameter(cmd, "@QiTaBeiZhu", DbType.String, info.QiTaBeiZhu);
            _db.AddInParameter(cmd, "@XiaDanBeiZhu", DbType.String, info.XiaDanBeiZhu);
            _db.AddInParameter(cmd, "@LxrXml", DbType.String, CreateLxrXml(info));
            _db.AddInParameter(cmd, "@OperatorId", DbType.AnsiStringFixedLength, info.OperatorId);
            _db.AddInParameter(cmd, "@IssueTime", DbType.Date, info.IssueTime);
            _db.AddInParameter(cmd, "@YouKeXml", DbType.String, CreateYouKeXml(info.YouKes));
            _db.AddInParameter(cmd, "@TuanGouid", DbType.AnsiStringFixedLength, info.TuanGouId);
            _db.AddInParameter(cmd, "@AgencyId", DbType.AnsiStringFixedLength, info.AgencyId);
            _db.AddInParameter(cmd, "@AgencyJinE", DbType.Decimal, info.AgencyJinE);
            _db.AddInParameter(cmd, "@Traffice", DbType.String, info.TrafficId);
            _db.AddInParameter(cmd, "@OrderSite", DbType.Int32, info.OrderSite);

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

            info.OrderCode = _db.GetParameterValue(cmd, "OrderCode").ToString();
            return Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));
        }

        /// <summary>
        /// 获取订单信息实体
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <returns></returns>
        public MOrderInfo GetInfo(string orderId)
        {
            MOrderInfo info = null;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetInfo);
            _db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, orderId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new MOrderInfo();

                    info.ChengRenShu = rdr.GetInt32(rdr.GetOrdinal("ChengRenShu"));
                    info.ErTongShu = rdr.GetInt32(rdr.GetOrdinal("ErTongShu"));
                    info.FuKuanStatus = (FuKuanStatus)rdr.GetByte(rdr.GetOrdinal("FuKuanStatus"));
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.JinE = rdr.GetDecimal(rdr.GetOrdinal("JinE"));
                    info.JSJCR = rdr.GetDecimal(rdr.GetOrdinal("JSJCR"));
                    info.JSJER = rdr.GetDecimal(rdr.GetOrdinal("JSJET"));
                    info.SCJCR = rdr.GetDecimal(rdr.GetOrdinal("SCJCR"));
                    info.SCJET = rdr.GetDecimal(rdr.GetOrdinal("SCJET"));
                    info.LDate = rdr.GetDateTime(rdr.GetOrdinal("LDate"));
                    info.LxrGender = (EyouSoft.Model.Enum.Gender)rdr.GetByte(rdr.GetOrdinal("LxrGender"));
                    info.LxrName = rdr["LxrName"].ToString();
                    info.LxrTelephone = rdr["LxrTelephone"].ToString();
                    info.LxrZhengJianCode = rdr["LxrZhengJianCode"].ToString();
                    info.LxrZhengJianType = (EyouSoft.Model.Enum.CardType)rdr.GetByte(rdr.GetOrdinal("LxrZhengJianType"));
                    info.OperatorId = rdr.GetString(rdr.GetOrdinal("OperatorId"));
                    info.OrderCode = rdr["OrderCode"].ToString();
                    info.OrderId = orderId;
                    info.QiTaBeiZhu = rdr["QiTaBeiZhu"].ToString();
                    info.Status = (OrderStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    info.TourId = rdr.GetString(rdr.GetOrdinal("TourId"));
                    info.TuanGouId = rdr["TuanGouId"].ToString();
                    info.XiaDanBeiZhu = rdr["XiaDanBeiZhu"].ToString();
                    info.XianLuId = rdr.GetString(rdr.GetOrdinal("XianLuId"));
                    info.YouKes = null;
                    info.XianLuName = rdr["RouteName"].ToString();
                    info.AgencyId = rdr["AgencyId"].ToString();
                    info.AgencyJinE = rdr.GetDecimal(rdr.GetOrdinal("AgencyJinE"));
                    info.RouteType = (EyouSoft.Model.Enum.AreaType)rdr.GetByte(rdr.GetOrdinal("RouteType"));
                    info.TrafficId = rdr["Traffice"].ToString();
                    if (rdr["UserType"] != null && rdr["UserType"] != DBNull.Value)
                    {
                        info.UserType = (EyouSoft.Model.Enum.MemberTypes)rdr.GetInt32(rdr.GetOrdinal("UserType"));
                    }
                    else
                    {
                        info.UserType = EyouSoft.Model.Enum.MemberTypes.未注册用户;
                    }
                }
            }

            if (info != null)
            {
                info.YouKes = GetYouKes(orderId);
                info.Historys = GetOrderHistorys(orderId);
                info.Traffice = GetTraffice(info.TrafficId, info.XianLuId);
            }

            return info;
        }

        /// <summary>
        /// 更新订单信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Update(MOrderInfo info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_XianLuOrder_Update");

            _db.AddInParameter(cmd, "@OrderId", DbType.AnsiStringFixedLength, info.OrderId);
            _db.AddInParameter(cmd, "@XianLuId", DbType.AnsiStringFixedLength, info.XianLuId);
            _db.AddInParameter(cmd, "@TourId", DbType.AnsiStringFixedLength, info.TourId);
            _db.AddOutParameter(cmd, "@OrderCode", DbType.String, 255);
            _db.AddInParameter(cmd, "@Status", DbType.Byte, info.Status);
            _db.AddInParameter(cmd, "@ChengRenShu", DbType.Int32, info.ChengRenShu);
            _db.AddInParameter(cmd, "@ErTongShu", DbType.Int32, info.ErTongShu);
            _db.AddInParameter(cmd, "@JSJCR", DbType.Decimal, info.JSJCR);
            _db.AddInParameter(cmd, "@JSJER", DbType.Decimal, info.JSJER);
            _db.AddInParameter(cmd, "@JinE", DbType.Decimal, info.JinE);
            _db.AddInParameter(cmd, "@FuKuanStatus", DbType.Byte, info.FuKuanStatus);
            _db.AddInParameter(cmd, "@LDate", DbType.DateTime, DateTime.Today);
            _db.AddInParameter(cmd, "@QiTaBeiZhu", DbType.String, info.QiTaBeiZhu);
            _db.AddInParameter(cmd, "@XiaDanBeiZhu", DbType.String, info.XiaDanBeiZhu);
            _db.AddInParameter(cmd, "@LxrXml", DbType.String, CreateLxrXml(info));
            _db.AddInParameter(cmd, "@OperatorId", DbType.AnsiStringFixedLength, info.OperatorId);
            _db.AddInParameter(cmd, "@IssueTime", DbType.Date, info.IssueTime);
            _db.AddInParameter(cmd, "@YouKeXml", DbType.String, CreateYouKeXml(info.YouKes));
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
        /// 设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="memberId">会员编号</param>
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
        /// 写入订单变更历史记录，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int InsertOrderHistory(MOrderHistoryInfo info)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_INSERT_InsertOrderHistory);
            _db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, info.OrderId);
            _db.AddInParameter(cmd, "Status", DbType.Byte, info.Status);
            _db.AddInParameter(cmd, "BeiZhu", DbType.String, info.BeiZhu);
            _db.AddInParameter(cmd, "LeiXing", DbType.Byte, info.LeiXing);
            _db.AddInParameter(cmd, "OperatorId", DbType.AnsiStringFixedLength, info.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }

        /// <summary>
        /// 设置付款状态，返回1成功，其它失败
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="memberId">会员编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int SheZhiFuKuanStatus(string orderId, string memberId, FuKuanStatus status)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_SheZhiFuKuanStatus);

            _db.AddInParameter(cmd, "FuKuanStatus", DbType.Byte, status);
            _db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, orderId);
            _db.AddInParameter(cmd, "MemberId", DbType.AnsiStringFixedLength, memberId);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }

        /// <summary>
        /// 获取订单信息集合
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<MOrderInfo> GetOrders(int pageSize, int pageIndex, ref int recordCount, MOrderChaXunInfo chaXun)
        {
            IList<MOrderInfo> items = new List<MOrderInfo>();

            StringBuilder fields = new StringBuilder();
            StringBuilder query = new StringBuilder();
            string tableName = "view_XianLuTourOrder";
            string orderByString = " [IssueTime] DESC ";
            string sumString = "";

            #region fields
            fields.Append(" * ");
            #endregion

            #region sql where
            query.Append(" 1=1 ");
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.HuiYuanId) && !string.IsNullOrEmpty(chaXun.AgencyId))
                {
                    query.AppendFormat(" AND ( OperatorId='{0}' or  AgencyId='{1}')", chaXun.HuiYuanId, chaXun.AgencyId);
                }
                else if (!string.IsNullOrEmpty(chaXun.HuiYuanId))
                {
                    query.AppendFormat(" AND OperatorId='{0}' ", chaXun.HuiYuanId);
                }
                else if (!string.IsNullOrEmpty(chaXun.AgencyId))
                {
                    if (chaXun.AgencyId == "0")
                    {
                        query.Append(" AND (AgencyId is null or  AgencyId = '')");
                    }
                    else
                    {
                        query.AppendFormat(" AND AgencyId = '{0}' ", chaXun.AgencyId);
                    }
                }
                if (!string.IsNullOrEmpty(chaXun.TourId))
                {
                    query.AppendFormat(" AND TourId='{0}' ", chaXun.TourId);
                }
                if (!string.IsNullOrEmpty(chaXun.XianLuId))
                {
                    query.AppendFormat(" AND XianLuId='{0}' ", chaXun.XianLuId);
                }
                if (!string.IsNullOrEmpty(chaXun.OrderCode))
                {
                    query.AppendFormat(" AND OrderCode LIKE '%{0}%' ", chaXun.OrderCode);
                }
                if (!string.IsNullOrEmpty(chaXun.XiaDanRenName))
                {
                    query.AppendFormat(" AND OperatorId IN(SELECT A.MemberID FROM tbl_Member AS A WHERE A.MemberName LIKE '%{0}%') ", chaXun.XiaDanRenName);
                }
                if (chaXun.SXiaDanTime.HasValue)
                {
                    query.AppendFormat(" AND IssueTime>='{0}' ", chaXun.SXiaDanTime.Value);
                }
                if (chaXun.EXiaDanTime.HasValue)
                {
                    query.AppendFormat(" AND IssueTime<='{0}' ", chaXun.EXiaDanTime.Value);
                }
                if (chaXun.OrderStatus.HasValue)
                {
                    query.AppendFormat(" AND Status={0} ", (int)chaXun.OrderStatus.Value);
                }
                if (chaXun.FuKuanStatus.HasValue)
                {
                    query.AppendFormat(" AND FuKuanStatus={0} ", (int)chaXun.FuKuanStatus.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.TuanGouId))
                {
                    query.AppendFormat(" AND TuanGouid='{0}' ", chaXun.TuanGouId);
                }
                if (!string.IsNullOrEmpty(chaXun.RouteName))
                {
                    query.AppendFormat(" AND RouteName LIKE '%{0}%' ", chaXun.RouteName);
                }
                if (chaXun.RouteType.HasValue)
                {
                    query.AppendFormat(" AND RouteType={0} ", (int)chaXun.RouteType.Value);
                }
                
                

                if (chaXun.IsFeiHuiYuan)
                {
                    query.Append(" AND LEN(OperatorId)<>36 ");
                    if (!string.IsNullOrEmpty(chaXun.FeiHuiYuanDingDanHao.Trim()))
                        query.AppendFormat(" AND OrderCode='{0}' ", chaXun.FeiHuiYuanDingDanHao);
                    query.AppendFormat(" AND LxrName='{0}' ", chaXun.FeiHuiYuanXingMing);
                    query.AppendFormat(" AND LxrTelephone='{0}' ", chaXun.FeiHuiYuanDianHua);
                }
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new MOrderInfo();

                    item.ChengRenShu = rdr.GetInt32(rdr.GetOrdinal("ChengRenShu"));
                    item.ErTongShu = rdr.GetInt32(rdr.GetOrdinal("ErTongShu"));
                    item.FuKuanStatus = (FuKuanStatus)rdr.GetByte(rdr.GetOrdinal("FuKuanStatus"));
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.JinE = rdr.GetDecimal(rdr.GetOrdinal("JinE"));
                    item.JSJCR = rdr.GetDecimal(rdr.GetOrdinal("JSJCR"));
                    item.JSJER = rdr.GetDecimal(rdr.GetOrdinal("JSJET"));
                    item.SCJCR = rdr.GetDecimal(rdr.GetOrdinal("SCJCR"));
                    item.SCJET = rdr.GetDecimal(rdr.GetOrdinal("SCJET"));
                    item.LDate = rdr.GetDateTime(rdr.GetOrdinal("LDate"));
                    item.LxrGender = (EyouSoft.Model.Enum.Gender)rdr.GetByte(rdr.GetOrdinal("LxrGender"));
                    item.LxrName = rdr["LxrName"].ToString();
                    item.LxrTelephone = rdr["LxrTelephone"].ToString();
                    item.LxrZhengJianCode = rdr["LxrZhengJianCode"].ToString();
                    item.LxrZhengJianType = (EyouSoft.Model.Enum.CardType)rdr.GetByte(rdr.GetOrdinal("LxrZhengJianType"));
                    item.OperatorId = rdr.GetString(rdr.GetOrdinal("OperatorId"));
                    item.OrderCode = rdr["OrderCode"].ToString();
                    item.OrderId = rdr.GetString(rdr.GetOrdinal("OrderId"));
                    item.QiTaBeiZhu = rdr["QiTaBeiZhu"].ToString();
                    item.Status = (OrderStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    item.TourId = rdr.GetString(rdr.GetOrdinal("TourId"));
                    item.XiaDanBeiZhu = rdr["XiaDanBeiZhu"].ToString();
                    item.XianLuId = rdr.GetString(rdr.GetOrdinal("XianLuId"));
                    item.XianLuName = rdr["RouteName"].ToString();
                    item.AgencyJinE = rdr.GetDecimal(rdr.GetOrdinal("AgencyJinE"));
                    item.AgencyId = rdr["AgencyId"].ToString();
                    item.Line_Source = (LineSource)rdr.GetByte(rdr.GetOrdinal("Line_Source"));
                    item.RouteType = (EyouSoft.Model.Enum.AreaType)rdr.GetByte(rdr.GetOrdinal("RouteType"));
                    if (rdr["UserType"] != null && rdr["UserType"] != DBNull.Value)
                    {
                        item.UserType = (EyouSoft.Model.Enum.MemberTypes)rdr.GetInt32(rdr.GetOrdinal("UserType"));
                    }
                    else
                    {
                        item.UserType = EyouSoft.Model.Enum.MemberTypes.未注册用户;
                    }
                    item.MemberName = rdr["MemberName"].ToString();
                    item.Mobile = rdr["Mobile"].ToString();

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
        /// 支付完成执行方法
        /// </summary>
        /// <param name="info">订单</param>
        /// <returns></returns>
        public int SheZhiZhiFus(MOrderInfo info)
        {
            DbCommand cmd = _db.GetSqlStringCommand("UPDATE tbl_XianLuTourOrder SET FuKuanStatus=@FuKuanStatus ,Status=@Status WHERE [OrderId]=@OrderId ");

            _db.AddInParameter(cmd, "FuKuanStatus", DbType.Byte, info.FuKuanStatus);
            _db.AddInParameter(cmd, "Status", DbType.Byte, info.Status);
            _db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, info.OrderId);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : 0;
        }
        /// <summary>
        /// 根据订单状态获取订单数量
        /// </summary>
        /// <param name="Status">订单状态</param>
        /// <returns></returns>
        public int GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus Status)
        {
            DbCommand cmd = _db.GetSqlStringCommand("Select count(OrderId) from view_XianLuTourOrder WHERE Status=@Status   ");

            _db.AddInParameter(cmd, "Status", DbType.Byte, Status);

            object num = DbHelper.GetSingle(cmd, _db);
            return Convert.ToInt32(num);
        }
        #endregion
    }
}
