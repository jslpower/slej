using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit.DAL;
using EyouSoft.IDAL;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace EyouSoft.DAL
{
    public class DOnLinePay : DALBase, IOnLinePay
    {
        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DOnLinePay()
        {
            _db = SystemStore;
        }
        #endregion
        /// <summary>
        /// 新增支付记录
        /// </summary>
        /// <param name="model">信息实体</param>
        /// <returns></returns>
        public bool Add(EyouSoft.Model.OnLinePayRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbl_WebOnLinePay(");
            strSql.Append("OrderId,OrderType,OutTradeNo,TradeNo,Totalfee,PayType,IsPay,SuccessTime)");
            strSql.Append(" values (");
            strSql.Append("@OrderId,@OrderType,@OutTradeNo,@TradeNo,@Totalfee,@PayType,@IsPay,@SuccessTime)");
            DbCommand dc = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(dc, "OrderId", DbType.String, model.OrderId);
            this._db.AddInParameter(dc, "OrderType", DbType.Byte, model.OrderType);
            this._db.AddInParameter(dc, "OutTradeNo", DbType.String, model.OutTradeNo);
            this._db.AddInParameter(dc, "TradeNo", DbType.String, model.TradeNo);
            this._db.AddInParameter(dc, "Totalfee", DbType.Decimal, model.Totalfee);
            this._db.AddInParameter(dc, "PayType", DbType.Byte, model.PayType);
            this._db.AddInParameter(dc, "IsPay", DbType.Boolean, model.IsPay);
            this._db.AddInParameter(dc, "SuccessTime", DbType.DateTime, model.SuccessTime);
            return DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
        }
        /// <summary>
        /// 判断订单有无支付成功
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <param name="orderType">订单类型</param>
        /// <returns></returns>
        public bool IsPaySuccess(string orderId, EyouSoft.Model.OrderType orderType)
        {
            bool IsPay = false;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select IsPay from tbl_WebOnLinePay ");
            strSql.Append(" where OrderId=@orderId and OrderType=@orderType");
            DbCommand cmd = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(cmd, "orderId", DbType.AnsiStringFixedLength, orderId);
            _db.AddInParameter(cmd, "orderType", DbType.Byte, orderType);
            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    IsPay = rdr.GetBoolean(rdr.GetOrdinal("IsPay"));
                }
            }
            return IsPay;
        }
        /// <summary>
        /// 获取支付宝卖家账号
        /// </summary>
        /// <returns></returns>
        public string GetAlipayAccount()
        {
            return EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("AlipayAccount");
        }
    }
}
