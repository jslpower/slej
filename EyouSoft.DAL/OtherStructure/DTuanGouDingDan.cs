using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using EyouSoft.Toolkit;
using EyouSoft.Toolkit.DAL;
using System.Data;

namespace EyouSoft.DAL.OtherStructure
{
    public class DTuanGouDingDan : EyouSoft.Toolkit.DAL.DALBase, EyouSoft.IDAL.OtherStructure.ITuanGouDingDan
    {
        #region 初始化db
        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DTuanGouDingDan()
        {
            _db = base.SystemStore;
        }
        #endregion
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(EyouSoft.Model.OtherStructure.MTuanGouDingDan model)
        {



            DbCommand cmd = this._db.GetStoredProcCommand("proc_TuanGouDingDan_Insert");

            this._db.AddInParameter(cmd, "ProductID", System.Data.DbType.AnsiStringFixedLength, model.ProductID);
            this._db.AddInParameter(cmd, "ProductNum", System.Data.DbType.Int32, model.ProductNum);
            this._db.AddInParameter(cmd, "OrderPrice", System.Data.DbType.Decimal, model.OrderPrice);
            this._db.AddInParameter(cmd, "PeopleID", System.Data.DbType.AnsiStringFixedLength, model.PeopleID);
            this._db.AddInParameter(cmd, "PeopleName", System.Data.DbType.String, model.PeopleName);
            this._db.AddInParameter(cmd, "PeopleMobile", System.Data.DbType.String, model.PeopleMobile);
            this._db.AddInParameter(cmd, "IssueTime", System.Data.DbType.DateTime, model.IssueTime);
            this._db.AddInParameter(cmd, "OrderState", System.Data.DbType.Byte, model.OrderState);
            this._db.AddInParameter(cmd, "PayState", System.Data.DbType.Byte, model.PayState);
            this._db.AddInParameter(cmd, "SupplierID", System.Data.DbType.AnsiStringFixedLength, model.SupplierID);
            this._db.AddInParameter(cmd, "Peopleaddress", System.Data.DbType.String, model.Peopleaddress);
            this._db.AddInParameter(cmd, "OrderSite", System.Data.DbType.Int32, model.OrderSite);

            _db.AddOutParameter(cmd, "@RetCode", DbType.Int32, 4);
            _db.AddOutParameter(cmd, "@OrderCode", DbType.String, 255);
            _db.AddOutParameter(cmd, "@OrderID", DbType.Int32, 4);

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
            model.OrderCode = this._db.GetParameterValue(cmd, "OrderCode").ToString();
            model.OrderID = Convert.ToInt32(_db.GetParameterValue(cmd, "OrderID").ToString());
            return Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));

        }
        ///// <summary>
        ///// 更新一条数据
        ///// </summary>
        //public int Update(EyouSoft.Model.OtherStructure.MTuanGouDingDan model);
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_TuanGouDingDan_Delete");

            _db.AddInParameter(cmd, "ID", DbType.Int32, ID);
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
        /// 得到一个对象实体
        /// </summary>
        public EyouSoft.Model.OtherStructure.MTuanGouDingDan GetModel(int ID)
        {
            EyouSoft.Model.OtherStructure.MTuanGouDingDan model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ProductName, OrderID, ProductID, ProductNum, OrderCode, OrderPrice, OrderState, PayState, PeopleID, PeopleName, PeopleMobile, IssueTime, SupplierID,Peopleaddress FROM  View_TuanGouOrder WHERE OrderID=@ID");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ID", System.Data.DbType.Int32, ID);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new EyouSoft.Model.OtherStructure.MTuanGouDingDan();
                    model.OrderID = ID;
                    model.ProductName = dr.GetString(dr.GetOrdinal("ProductName"));
                    model.ProductID = dr.GetInt32(dr.GetOrdinal("ProductID"));
                    model.ProductNum = dr.GetInt32(dr.GetOrdinal("ProductNum"));
                    model.OrderCode = dr.GetString(dr.GetOrdinal("OrderCode"));
                    model.OrderPrice = dr.GetDecimal(dr.GetOrdinal("OrderPrice"));
                    model.OrderState = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)dr.GetByte(dr.GetOrdinal("OrderState"));
                    model.PayState = (EyouSoft.Model.Enum.PaymentState)dr.GetByte(dr.GetOrdinal("PayState"));
                    model.PeopleID = dr.GetString(dr.GetOrdinal("PeopleID"));
                    model.PeopleName = dr.GetString(dr.GetOrdinal("PeopleName"));
                    model.PeopleMobile = dr.GetString(dr.GetOrdinal("PeopleMobile"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.SupplierID = dr.GetString(dr.GetOrdinal("SupplierID"));
                    object ojb = dr["Peopleaddress"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.Peopleaddress = dr.GetString(dr.GetOrdinal("Peopleaddress"));
                    }
                    else
                    {
                        model.Peopleaddress = "";
                    }

                }
            }

            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.OtherStructure.MTuanGouDingDan> GetList(int PageSize, int PageIndex, ref int RecordCount, EyouSoft.Model.OtherStructure.MTuanGouDingDanSer serModel)
        {
            IList<EyouSoft.Model.OtherStructure.MTuanGouDingDan> list = new List<EyouSoft.Model.OtherStructure.MTuanGouDingDan>();

            string tableName = "View_TuanGouOrder";
            string fileds = " ProductName, OrderID, ProductID, ProductNum, OrderCode, OrderPrice, OrderState, PayState, PeopleID, PeopleName, PeopleMobile, IssueTime, SupplierID,Peopleaddress ";
            string orderByString = "IssueTime desc";
            StringBuilder query = new StringBuilder();
            query.Append(" 1=1 ");

            if (serModel != null)
            {
                if (!string.IsNullOrEmpty(serModel.ProductName))
                {
                    query.AppendFormat(" and  ProductName like '%{0}%' ", serModel.ProductName);
                }
                if (!string.IsNullOrEmpty(serModel.OrderCode))
                {
                    query.AppendFormat(" and  OrderCode like '%{0}%' ", serModel.OrderCode);
                }


                if (!string.IsNullOrEmpty(serModel.SupplierID) && !string.IsNullOrEmpty(serModel.PeopleID))
                {
                    query.AppendFormat(" and  (SupplierID = '{0}' or  PeopleID = '{1}' )", serModel.SupplierID, serModel.PeopleID);
                }
                else if (!string.IsNullOrEmpty(serModel.PeopleID))
                {
                    query.AppendFormat(" and  PeopleID = '{0}' ", serModel.PeopleID);
                }
            }
            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.OtherStructure.MTuanGouDingDan model = new EyouSoft.Model.OtherStructure.MTuanGouDingDan();
                    model.OrderID = dr.GetInt32(dr.GetOrdinal("OrderID")); ;
                    model.ProductName = dr.GetString(dr.GetOrdinal("ProductName"));
                    model.ProductID = dr.GetInt32(dr.GetOrdinal("ProductID"));
                    model.ProductNum = dr.GetInt32(dr.GetOrdinal("ProductNum"));
                    model.OrderCode = dr.GetString(dr.GetOrdinal("OrderCode"));
                    model.OrderPrice = dr.GetDecimal(dr.GetOrdinal("OrderPrice"));
                    model.OrderState = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)dr.GetByte(dr.GetOrdinal("OrderState"));
                    model.PayState = (EyouSoft.Model.Enum.PaymentState)dr.GetByte(dr.GetOrdinal("PayState"));
                    model.PeopleID = dr.GetString(dr.GetOrdinal("PeopleID"));
                    model.PeopleName = dr.GetString(dr.GetOrdinal("PeopleName"));
                    model.PeopleMobile = dr.GetString(dr.GetOrdinal("PeopleMobile"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.SupplierID = dr.GetString(dr.GetOrdinal("SupplierID"));
                    object ojb = dr["Peopleaddress"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        model.Peopleaddress = dr.GetString(dr.GetOrdinal("Peopleaddress"));
                    }
                    else
                    {
                        model.Peopleaddress = "";
                    }

                    list.Add(model);
                }
            }

            return list;

        }
        /// <summary>
        /// 根据产品id获取订单数量
        /// </summary>
        /// <param name="id">产品id</param>
        /// <returns></returns>
        public int GetNumById(int id)
        {
            DbCommand cmd = _db.GetSqlStringCommand(" select count(OrderID) from dbo.tbl_TuanGouDingDan where ProductID=" + id + " ");
            int count = Convert.ToInt32(DbHelper.GetSingle(cmd, _db));
            return count;
        }


        /// <summary>
        /// 设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int SheZhiOrderStatus(string orderId, EyouSoft.Model.Enum.XianLuStructure.OrderStatus status)
        {
            DbCommand cmd = _db.GetSqlStringCommand("UPDATE tbl_TuanGouDingDan SET OrderState=@OrderState WHERE OrderID=@OrderID ");

            _db.AddInParameter(cmd, "OrderState", DbType.Byte, status);
            _db.AddInParameter(cmd, "OrderID", DbType.AnsiStringFixedLength, orderId);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }
        /// <summary>
        /// 支付完成执行方法
        /// </summary>
        /// <param name="info">订单</param>
        /// <returns></returns>
        public int SheZhiZhiFus(EyouSoft.Model.OtherStructure.MTuanGouDingDan info)
        {
            DbCommand cmd = _db.GetSqlStringCommand("UPDATE tbl_TuanGouDingDan  SET OrderState=@OrderState, PayState=@PayState WHERE OrderID=@OrderID ");

            _db.AddInParameter(cmd, "OrderState", DbType.Byte, info.OrderState);
            _db.AddInParameter(cmd, "PayState", DbType.Byte, info.PayState);
            _db.AddInParameter(cmd, "OrderID", DbType.AnsiStringFixedLength, info.OrderID);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : 0;
        }
        /// <summary>
        /// 根据订单状态获取订单数量
        /// </summary>
        /// <param name="Status">订单状态</param>
        /// <returns></returns>
        public int GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus Status)
        {
            DbCommand cmd = _db.GetSqlStringCommand("Select count(OrderId) from View_TuanGouOrder WHERE OrderState=@Status   ");

            _db.AddInParameter(cmd, "Status", DbType.Byte, Status);

            object num = DbHelper.GetSingle(cmd, _db);
            return Convert.ToInt32(num);
        }

    }
}
