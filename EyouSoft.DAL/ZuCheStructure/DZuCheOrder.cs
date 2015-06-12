using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.ZuCheStructure;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit.DAL;
using EyouSoft.Toolkit;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.IDAL.ZuCheStructure;

namespace EyouSoft.DAL.ZuCheStructure
{
    public class DZuCheOrder : DALBase, IZuCheOrder
    {
        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DZuCheOrder()
        {
            _db = SystemStore;
        }
        #endregion

        /// <summary>
        /// 写入订单信息，返回1成功，其它失败
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public int Add(MZuCheOrder model)
        {
            DbCommand dbCommand = _db.GetStoredProcCommand("proc_JA_ZuCheOrder_ADD");
            _db.AddInParameter(dbCommand, "@OrderId", DbType.AnsiString, model.OrderId);
            _db.AddInParameter(dbCommand, "@ZuCheID", DbType.AnsiString, model.ZuCheID);
            _db.AddInParameter(dbCommand, "@ZuCheType", DbType.Int32, model.ZuCheType);
            _db.AddInParameter(dbCommand, "@CarType", DbType.Int32, model.CarType);
            _db.AddInParameter(dbCommand, "@GongLiShu", DbType.Decimal, model.GongLiShu);
            _db.AddInParameter(dbCommand, "@ZuCheTianShu", DbType.Int32, model.ZuCheTianShu);
            _db.AddInParameter(dbCommand, "@ZuJin", DbType.Currency, model.ZuJin);
            _db.AddInParameter(dbCommand, "@Status", DbType.Byte, model.Status);
            _db.AddInParameter(dbCommand, "@FuKuanStatus", DbType.Byte, model.FuKuanStatus);
            _db.AddInParameter(dbCommand, "@LDate", DbType.DateTime, model.LDate);
            _db.AddInParameter(dbCommand, "@XiaDanBeiZhu", DbType.String, model.XiaDanBeiZhu);
            _db.AddInParameter(dbCommand, "@LxrName", DbType.String, model.LxrName);
            _db.AddInParameter(dbCommand, "@LxrTelephone", DbType.String, model.LxrTelephone);
            _db.AddInParameter(dbCommand, "@OperatorId", DbType.AnsiString, model.OperatorId);
            _db.AddInParameter(dbCommand, "@IssueTime", DbType.DateTime, model.IssueTime);
            _db.AddInParameter(dbCommand, "@TuanGouId", DbType.AnsiString, model.TuanGouId);
            _db.AddOutParameter(dbCommand, "@OrderCode", DbType.AnsiString, 255);
            _db.AddInParameter(dbCommand, "@YuDingRName", DbType.String, model.YuDingRName);
            _db.AddInParameter(dbCommand, "@YuDingRTelephone", DbType.String, model.YuDingRTelephone);
            _db.AddInParameter(dbCommand, "@Number", DbType.Int32, model.Number);
            _db.AddInParameter(dbCommand, "@EDate", DbType.DateTime, model.EDate);
            _db.AddInParameter(dbCommand, "@ZuCheXingCheng", DbType.String, CreateLxrXml(model.Xingcheng));
            _db.AddInParameter(dbCommand, "@AgencyId", DbType.String, model.AgencyId);
            _db.AddInParameter(dbCommand, "@AgencyJinE", DbType.Currency, model.AgencyJinE);
            _db.AddInParameter(dbCommand, "@OrderSite", DbType.Int32, model.OrderSite);
            //_db.AddInParameter(dbCommand, "@ApiOrderId", DbType.Currency, model.);

            _db.AddOutParameter(dbCommand, "@Result", DbType.Int32, 4);
            int sqlExceptionCode = 0;

            try
            {
                DbHelper.RunProcedure(dbCommand, _db);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                sqlExceptionCode = 0 - e.Number;
            }

            if (sqlExceptionCode < 0) return sqlExceptionCode;

            model.OrderCode = _db.GetParameterValue(dbCommand, "OrderCode").ToString();
            return Convert.ToInt32(_db.GetParameterValue(dbCommand, "Result"));
        }
        /// <summary>
        /// 更新订单信息，返回1成功，其它失败
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(MZuCheOrder model)
        {
            DbCommand dbCommand = _db.GetStoredProcCommand("proc_JA_ZuCheOrder_Update");
            _db.AddInParameter(dbCommand, "@OrderId", DbType.AnsiString, model.OrderId);
            _db.AddInParameter(dbCommand, "@ZuCheID", DbType.AnsiString, model.ZuCheID);
            _db.AddInParameter(dbCommand, "@ZuCheType", DbType.Int32, model.ZuCheType);
            _db.AddInParameter(dbCommand, "@CarType", DbType.Int32, model.CarType);
            _db.AddInParameter(dbCommand, "@GongLiShu", DbType.Decimal, model.GongLiShu);
            _db.AddInParameter(dbCommand, "@ZuCheTianShu", DbType.Int32, model.ZuCheTianShu);
            _db.AddInParameter(dbCommand, "@ZuJin", DbType.Currency, model.ZuJin);
            _db.AddInParameter(dbCommand, "@Status", DbType.Byte, model.Status);
            _db.AddInParameter(dbCommand, "@FuKuanStatus", DbType.Byte, model.FuKuanStatus);
            _db.AddInParameter(dbCommand, "@LDate", DbType.DateTime, model.LDate);
            _db.AddInParameter(dbCommand, "@XiaDanBeiZhu", DbType.String, model.XiaDanBeiZhu);
            _db.AddInParameter(dbCommand, "@LxrName", DbType.String, model.LxrName);
            _db.AddInParameter(dbCommand, "@LxrTelephone", DbType.String, model.LxrTelephone);
            _db.AddInParameter(dbCommand, "@OperatorId", DbType.AnsiString, model.OperatorId);
            _db.AddInParameter(dbCommand, "@IssueTime", DbType.DateTime, model.IssueTime);
            _db.AddInParameter(dbCommand, "@TuanGouId", DbType.AnsiString, model.TuanGouId);
            _db.AddOutParameter(dbCommand, "@Result", DbType.Int32, 4);
            _db.AddOutParameter(dbCommand, "@OrderCode", DbType.AnsiString, 4);
            _db.AddInParameter(dbCommand, "@YuDingRName", DbType.String, model.YuDingRName);
            _db.AddInParameter(dbCommand, "@YuDingRTelephone", DbType.String, model.YuDingRTelephone);
            _db.AddInParameter(dbCommand, "@AgencyId", DbType.String, model.AgencyId);
            _db.AddInParameter(dbCommand, "@AgencyJinE", DbType.String, model.AgencyJinE);
            _db.AddInParameter(dbCommand, "@Number", DbType.Int32, model.Number);

            _db.AddInParameter(dbCommand, "@EDate", DbType.DateTime, model.EDate);
            _db.AddInParameter(dbCommand, "@ZuCheXingCheng", DbType.String, CreateLxrXml(model.Xingcheng));

            int sqlExceptionCode = 0;

            try
            {
                DbHelper.RunProcedure(dbCommand, _db);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                sqlExceptionCode = 0 - e.Number;
            }

            if (sqlExceptionCode < 0) return sqlExceptionCode;

            return Convert.ToInt32(_db.GetParameterValue(dbCommand, "Result"));
        }
        /// <summary>
        /// 获取订单信息实体
        /// </summary>
        /// <param name="OrderID">订单编号</param>
        /// <returns></returns>
        public MZuCheOrder GetModel(string OrderID)
        {
            MZuCheOrder model = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   ");
            strSql.Append(" OrderId,ZuCheID,ZuCheType,CarType,GongLiShu,ZuCheTianShu,ZuJin,Status,FuKuanStatus,LDate,XiaDanBeiZhu,LxrName,LxrTelephone,OperatorId,IssueTime,TuanGouId,OrderCode,CarName,Number,YuDingRName,YuDingRTelephone,EDate,AgencyId,AgencyJinE ");
            strSql.Append(" from view_JA_ZuCheOrder ");
            strSql.AppendFormat(" where OrderId=@OrderId");
            DbCommand dbCommand = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dbCommand, "@OrderId", DbType.AnsiStringFixedLength, OrderID);
            using (IDataReader dataReader = DbHelper.ExecuteReader(dbCommand, _db))
            {
                if (dataReader.Read())
                {
                    model = new MZuCheOrder();
                    object ojb;
                    model.OrderId = dataReader["OrderId"].ToString();
                    model.ZuCheID = dataReader["ZuCheID"].ToString();
                    ojb = dataReader["ZuCheType"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.ZuCheType = (int)ojb;
                    }
                    ojb = dataReader["CarName"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.CarName = dataReader["CarName"].ToString();
                    }
                    ojb = dataReader["CarType"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.CarType = (int)ojb;
                    }
                    ojb = dataReader["GongLiShu"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.GongLiShu = (decimal)ojb;
                    }
                    ojb = dataReader["ZuCheTianShu"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.ZuCheTianShu = (int)ojb;
                    }
                    ojb = dataReader["ZuJin"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.ZuJin = (decimal)ojb;
                    }
                    ojb = dataReader["Status"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.Status = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)dataReader.GetByte(dataReader.GetOrdinal("Status"));
                    }
                    ojb = dataReader["FuKuanStatus"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.FuKuanStatus = (EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus)dataReader.GetByte(dataReader.GetOrdinal("FuKuanStatus"));
                    }
                    ojb = dataReader["LDate"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.LDate = (DateTime)ojb;
                    }
                    ojb = dataReader["EDate"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.EDate = (DateTime)ojb;
                    }
                    model.XiaDanBeiZhu = dataReader["XiaDanBeiZhu"].ToString();
                    model.LxrName = dataReader["LxrName"].ToString();
                    model.LxrTelephone = dataReader["LxrTelephone"].ToString();
                    ojb = dataReader["OperatorId"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.OperatorId = ojb.ToString();
                    }
                    ojb = dataReader["IssueTime"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.IssueTime = (DateTime)ojb;
                    }
                    ojb = dataReader["Number"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.Number = (int)ojb;
                    }
                    ojb = dataReader["YuDingRName"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.YuDingRName = dataReader["YuDingRName"].ToString();
                    }
                    ojb = dataReader["YuDingRTelephone"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.YuDingRTelephone = dataReader["YuDingRTelephone"].ToString();
                    }
                    model.TuanGouId = dataReader["TuanGouId"].ToString();
                    model.OrderCode = dataReader["OrderCode"].ToString();
                    model.AgencyId = dataReader["AgencyId"].ToString();
                    ojb = dataReader["AgencyJinE"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.AgencyJinE = (decimal)ojb;
                    }

                }
            }
            if (model != null)
            {
                model.Xingcheng = GetZuCheXingCheng(OrderID);
            }
            return model;
        }
        /// <summary>
        /// 租车行程信息
        /// </summary>
        /// <param name="OrderID">订单编号</param>
        /// <returns></returns>
        IList<ZuCheXingCheng> GetZuCheXingCheng(string OrderID)
        {
            IList<ZuCheXingCheng> list = new List<ZuCheXingCheng>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OrderId,LPlace,EPlace,GongLiShu,IdentityId from tbl_JA_ZuCheXingCheng ");
            strSql.Append(" where OrderId=@OrderId ");
            DbCommand dbCommand = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dbCommand, "OrderId", DbType.AnsiStringFixedLength, OrderID);
            using (IDataReader rdr = DbHelper.ExecuteReader(dbCommand, _db))
            {
                while (rdr.Read())
                {
                    ZuCheXingCheng model = new ZuCheXingCheng();
                    object ojb;
                    model.OrderId = rdr["OrderId"].ToString();
                    model.LPlace = rdr["LPlace"].ToString();
                    model.EPlace = rdr["EPlace"].ToString();
                    ojb = rdr["GongLiShu"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.GongLiShu = (decimal)ojb;
                    }
                    ojb = rdr["IdentityId"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.IdentityId = (int)ojb;
                    }
                    list.Add(model);
                }
            }
            return list;
        }
        /// <summary>
        /// 获取订单信息集合
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<MZuCheOrder> GetOrders(int pageSize, int pageIndex, ref int recordCount, MZuCheOrderChaXun chaXun)
        {
            List<MZuCheOrder> items = new List<MZuCheOrder>();
            StringBuilder fields = new StringBuilder();
            StringBuilder query = new StringBuilder();
            string tableName = "view_JA_ZuCheOrder";
            string orderByString = " [IssueTime] DESC ";
            string sumString = "";

            #region fields
            fields.Append(" OrderId,ZuCheID,ZuCheType,CarType,GongLiShu,ZuCheTianShu,ZuJin,Status,FuKuanStatus,LDate,XiaDanBeiZhu,LxrName,LxrTelephone,OperatorId,IssueTime,TuanGouId,OrderCode,CarName,Number,YuDingRName,YuDingRTelephone,EDate,AgencyJinE,AgencyId,UserType ");
            #endregion

            #region sql where
            query.Append(" 1=1 ");

            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.AgencyId) && !string.IsNullOrEmpty(chaXun.HuiYuanId))
                {
                    query.AppendFormat(" AND ( OperatorId='{0}' or AgencyId='{1}') ", chaXun.HuiYuanId, chaXun.AgencyId);
                }
                else if (!string.IsNullOrEmpty(chaXun.HuiYuanId))
                {
                    query.AppendFormat(" AND OperatorId='{0}' ", chaXun.HuiYuanId);
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
                //if (!string.IsNullOrEmpty(chaXun.TourId))
                //{
                //    query.AppendFormat(" AND TourId='{0}' ", chaXun.TourId);
                //}
                if (!string.IsNullOrEmpty(chaXun.ZuCheId))
                {
                    query.AppendFormat(" AND ZuCheID='{0}' ", chaXun.ZuCheId);
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
                    query.AppendFormat(" AND TuanGouId='{0}' ", chaXun.TuanGouId);
                }
                if (!string.IsNullOrEmpty(chaXun.CarName))
                {
                    query.AppendFormat(" AND CarName LIKE '%{0}%' ", chaXun.CarName);
                }
                
            }
            #endregion

            using (IDataReader dataReader = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), query.ToString(), orderByString, sumString))
            {
                while (dataReader.Read())
                {
                    var model = new MZuCheOrder();
                    object ojb;
                    model.OrderId = dataReader["OrderId"].ToString();
                    model.ZuCheID = dataReader["ZuCheID"].ToString();
                    ojb = dataReader["ZuCheType"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.ZuCheType = (int)ojb;
                    }
                    ojb = dataReader["CarName"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.CarName = dataReader["CarName"].ToString();
                    }
                    ojb = dataReader["CarType"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.CarType = (int)ojb;
                    }
                    ojb = dataReader["GongLiShu"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.GongLiShu = (decimal)ojb;
                    }
                    ojb = dataReader["ZuCheTianShu"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.ZuCheTianShu = (int)ojb;
                    }
                    ojb = dataReader["ZuJin"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.ZuJin = (decimal)ojb;
                    }
                    ojb = dataReader["Status"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.Status = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)dataReader.GetByte(dataReader.GetOrdinal("Status"));
                    }
                    ojb = dataReader["FuKuanStatus"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.FuKuanStatus = (EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus)dataReader.GetByte(dataReader.GetOrdinal("FuKuanStatus"));
                    }
                    ojb = dataReader["LDate"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.LDate = (DateTime)ojb;
                    }
                    ojb = dataReader["EDate"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.EDate = (DateTime)ojb;
                    }
                    model.XiaDanBeiZhu = dataReader["XiaDanBeiZhu"].ToString();
                    model.LxrName = dataReader["LxrName"].ToString();
                    model.LxrTelephone = dataReader["LxrTelephone"].ToString();
                    ojb = dataReader["OperatorId"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.OperatorId = ojb.ToString();
                    }
                    ojb = dataReader["IssueTime"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.IssueTime = (DateTime)ojb;
                    }
                    ojb = dataReader["Number"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.Number = (int)ojb;
                    }
                    ojb = dataReader["YuDingRName"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.YuDingRName = dataReader["YuDingRName"].ToString();
                    }
                    ojb = dataReader["YuDingRTelephone"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.YuDingRTelephone = dataReader["YuDingRTelephone"].ToString();
                    }
                    model.TuanGouId = dataReader["TuanGouId"].ToString();
                    model.OrderCode = dataReader["OrderCode"].ToString();
                    ojb = dataReader["AgencyJinE"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.AgencyJinE = (decimal)ojb;
                    }
                    model.AgencyId = dataReader["AgencyId"].ToString();
                    ojb =dataReader["UserType"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.UserType = (EyouSoft.Model.Enum.MemberTypes)dataReader.GetInt32(dataReader.GetOrdinal("UserType"));
                    }
                    else
                    {
                        model.UserType = EyouSoft.Model.Enum.MemberTypes.未注册用户;
                    }
                    items.Add(model);
                }
            }
            return items;
        }

        /// <summary>
        /// 设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="memberId">会员编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int SheZhiOrderStatus(string orderId, string memberId, EyouSoft.Model.Enum.XianLuStructure.OrderStatus status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbl_JA_ZuCheOrder set ");

            strSql.Append("Status=@Status,");

            strSql.Append(" where OrderId=@OrderId ");
            strSql.Append(" OperatorId=@OperatorId ");
            DbCommand cmd = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(cmd, "Status", DbType.Byte, status);
            _db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, orderId);
            _db.AddInParameter(cmd, "OperatorId", DbType.AnsiStringFixedLength, memberId);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }
        /// <summary>
        /// 设置付款状态，返回1成功，其它失败
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="memberId">会员编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int SheZhiFuKuanStatus(string orderId, string memberId, EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbl_JA_ZuCheOrder set ");

            strSql.Append("FuKuanStatus=@FuKuanStatus,");

            strSql.Append(" where OrderId=@OrderId ");
            strSql.Append(" OperatorId=@OperatorId ");
            DbCommand cmd = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(cmd, "FuKuanStatus", DbType.Byte, status);
            _db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, orderId);
            _db.AddInParameter(cmd, "OperatorId", DbType.AnsiStringFixedLength, memberId);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }
        /// <summary>
        /// 支付完成执行方法
        /// </summary>
        /// <param name="info">订单</param>
        /// <returns></returns>
        public int SheZhiZhiFus(MZuCheOrder info)
        {
            DbCommand cmd = _db.GetSqlStringCommand("UPDATE tbl_JA_ZuCheOrder  SET FuKuanStatus=@FuKuanStatus, Status=@Status WHERE  OrderId=@OrderId ");

            _db.AddInParameter(cmd, "Status", DbType.Byte, info.Status);
            _db.AddInParameter(cmd, "FuKuanStatus", DbType.Byte, info.FuKuanStatus);
            _db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, info.OrderId);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : 0;
        }
        /// <summary>
        /// 删除未审核订单
        /// </summary>
        /// <param name="orderid">订单id</param>
        /// <returns></returns>
        public int DeleteOrder(string orderid)
        {
            DbCommand cmd = _db.GetSqlStringCommand("Delete from tbl_JA_ZuCheOrder WHERE  OrderId=@OrderId and Status=@Status   ");
            
            _db.AddInParameter(cmd, "Status", DbType.Byte, EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理);
            _db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, orderid);

            int num = DbHelper.ExecuteSql(cmd, _db);
            if(num>0)
            {
                DbCommand cmd1 = _db.GetSqlStringCommand("Delete from tbl_JA_ZuCheXingCheng WHERE  OrderId=@OrderId ");
            
                _db.AddInParameter(cmd1, "OrderId", DbType.AnsiStringFixedLength, orderid);

                DbHelper.ExecuteSql(cmd1, _db);
            }
            return num;
        }
        /// <summary>
        /// 根据订单状态获取订单数量
        /// </summary>
        /// <param name="Status">订单状态</param>
        /// <returns></returns>
        public int GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus Status)
        {
            DbCommand cmd = _db.GetSqlStringCommand("Select count(OrderId) from view_JA_ZuCheOrder WHERE Status=@Status   ");

            _db.AddInParameter(cmd, "Status", DbType.Byte, Status);

            object num = DbHelper.GetSingle(cmd, _db);
            return Convert.ToInt32(num);
        }

        #region private xml
        string CreateLxrXml(IList<ZuCheXingCheng> items)
        {
            StringBuilder s = new StringBuilder();
            s.Append("<root>");
            foreach (var item in items)
            {
                s.Append("<info ");
                s.AppendFormat(" LPlace=\"{0}\"", Utils.ReplaceXmlSpecialCharacter(item.LPlace));
                s.AppendFormat(" EPlace=\"{0}\"", Utils.ReplaceXmlSpecialCharacter(item.EPlace));
                s.AppendFormat(" GongLiShu=\"{0}\"", Utils.ReplaceXmlSpecialCharacter(item.GongLiShu.ToString()));
                s.Append(" />");
            }
            s.Append("</root>");
            return s.ToString();
        }
        #endregion
    }
}
