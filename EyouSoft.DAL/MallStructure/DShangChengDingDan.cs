using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit.DAL;
using System.Data;
using System.Data.Common;
using EyouSoft.Toolkit;
using EyouSoft.Model.MallStructure;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.Model.Enum.XianLuStructure;

namespace EyouSoft.DAL.MallStructure
{
    public class DShangChengDingDan : DALBase, EyouSoft.IDAL.MallStructure.IShangChengDingDan
    {
        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DShangChengDingDan()
        {
            _db = SystemStore;
        }
        #endregion
        /// <summary>
        /// 写入商品表，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MShangChengDingDan info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_ShangChengDingDan_Insert");
            _db.AddInParameter(cmd, "@OrderID", DbType.AnsiStringFixedLength, info.OrderID);
            _db.AddInParameter(cmd, "@ProductID", DbType.AnsiStringFixedLength, info.ProductID);
            _db.AddInParameter(cmd, "@ProductNum", DbType.Int32, info.ProductNum);
            _db.AddInParameter(cmd, "@OrderPrice", DbType.Decimal, info.OrderPrice);
            _db.AddInParameter(cmd, "@OrderState", DbType.Byte, (byte)info.OrderState);
            _db.AddInParameter(cmd, "@PayState", DbType.Byte, (byte)info.PayState);
            _db.AddInParameter(cmd, "@ContactID", DbType.AnsiStringFixedLength, info.ContactID);
            _db.AddInParameter(cmd, "@ContactName", DbType.String, info.ContactName);
            _db.AddInParameter(cmd, "@ContactPhone", DbType.String, info.ContactPhone);
            _db.AddInParameter(cmd, "@IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "@Remark", DbType.String, info.Remark);
            _db.AddInParameter(cmd, "@SupplierID", DbType.String, info.SupplierID);
            _db.AddInParameter(cmd, "@SupplierMoney", DbType.Decimal, info.SupplierMoney);

            _db.AddInParameter(cmd, "@AddressID", DbType.Int32, info.Address.AddressID);
            _db.AddInParameter(cmd, "@ProvinceID", DbType.Int32, info.Address.ProvinceID);
            _db.AddInParameter(cmd, "@CityID", DbType.Int32, info.Address.CityID);
            _db.AddInParameter(cmd, "@DistrictID", DbType.Int32, info.Address.DistrictID);
            _db.AddInParameter(cmd, "@AddressInfo", DbType.String, info.Address.AddressInfo);
            _db.AddInParameter(cmd, "@UserID", DbType.AnsiStringFixedLength, info.Address.UserID);
            _db.AddInParameter(cmd, "@UserName", DbType.String, info.Address.UserName);
            _db.AddInParameter(cmd, "@IsDefault", DbType.Byte, GetBooleanToStr(info.Address.IsDefault));
            _db.AddInParameter(cmd, "@OrderSite", DbType.Int32, info.OrderSite);

            _db.AddOutParameter(cmd, "@RetCode", DbType.Int32, 4);
            _db.AddOutParameter(cmd, "@OrderCode", DbType.String, 255);

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
            info.OrderCode = this._db.GetParameterValue(cmd, "OrderCode").ToString();
            return Convert.ToInt32(_db.GetParameterValue(cmd, "RetCode"));
        }
        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="ChanPinBianHao"></param>
        /// <returns>-99：产品下有订单 1：成功 其他返回值：失败</returns>
        public int Delete(string ChanPinBianHao)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_ShangCheng_Delete");

            _db.AddInParameter(cmd, "ProductID", DbType.AnsiStringFixedLength, ChanPinBianHao);
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
        /// 获取商品信息实体
        /// </summary>
        /// <param name="ShangPinID">订单编号</param>
        /// <returns></returns>
        public MShangChengDingDan GetModel(string OrderID)
        {
            MShangChengDingDan info = new MShangChengDingDan();
            EyouSoft.Model.MemberStructure.MDiZhi dizhi = new EyouSoft.Model.MemberStructure.MDiZhi();
            StringBuilder query = new StringBuilder();

            query.Append(" SELECT  *  FROM View_ShangChengOrder");
            query.Append(" Where OrderID=@OrderID");

            DbCommand cmd = this._db.GetSqlStringCommand(query.ToString());
            this._db.AddInParameter(cmd, "OrderID", DbType.AnsiStringFixedLength, OrderID);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    info.ProductID = dr.GetString(dr.GetOrdinal("ProductID")); ;
                    info.ProductName = dr.GetString(dr.GetOrdinal("ProductName"));
                    info.ProductNum = dr.GetInt32(dr.GetOrdinal("ProductNum"));
                    info.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    info.OrderID = dr.GetString(dr.GetOrdinal("OrderID")); ;
                    info.OrderState = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)dr.GetByte(dr.GetOrdinal("OrderState"));
                    info.OrderCode = dr.GetString(dr.GetOrdinal("OrderCode"));
                    info.OrderPrice = dr.GetDecimal(dr.GetOrdinal("OrderPrice"));
                    info.ContactName = dr.GetString(dr.GetOrdinal("ContactName"));
                    info.ContactPhone = dr.GetString(dr.GetOrdinal("ContactPhone"));
                    info.Remark = dr.GetString(dr.GetOrdinal("Remark"));
                    info.ContactID = dr.GetString(dr.GetOrdinal("ContactID"));
                    info.PayState = (EyouSoft.Model.Enum.PaymentState)dr.GetByte(dr.GetOrdinal("PayState"));
                    info.SupplierID = dr.GetString(dr.GetOrdinal("SupplierID"));
                    info.SupplierMoney = dr.GetDecimal(dr.GetOrdinal("SupplierMoney"));
                    dizhi.ProvinceName = dr.GetString(dr.GetOrdinal("ProvinceName"));
                    dizhi.CityName = dr.GetString(dr.GetOrdinal("CityName"));
                    dizhi.DistrictName = dr.GetString(dr.GetOrdinal("DistrictName"));
                    dizhi.AddressInfo = dr.GetString(dr.GetOrdinal("Addressinfo"));
                }
            }
            info.Address = dizhi;
            return info;
        }
        /// <summary>
        /// 更新商品，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Update(MShangChengDingDan info)
        {

            DbCommand cmd = _db.GetSqlStringCommand("UPDATE tbl_ShangChengDingDan   SET       ProductNum = @ProductNum      ,OrderPrice = @OrderPrice      ,OrderState = @OrderState     ,ContactPhone = @ContactPhone      ,Remark = @Remark      WHERE OrderID=@OrderID");
            _db.AddInParameter(cmd, "@ProductNum", DbType.Int32, info.ProductNum);
            _db.AddInParameter(cmd, "@OrderPrice", DbType.Decimal, info.OrderPrice);
            _db.AddInParameter(cmd, "@OrderState", DbType.Byte, (byte)info.OrderState);
            _db.AddInParameter(cmd, "@ContactName", DbType.String, info.ContactName);
            _db.AddInParameter(cmd, "@ContactPhone", DbType.String, info.ContactPhone);
            _db.AddInParameter(cmd, "@Remark", DbType.String, info.Remark);
            _db.AddInParameter(cmd, "@OrderID", DbType.String, info.OrderID);
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
            return DbHelper.ExecuteSql(cmd, this._db);
        }
        /// <summary>
        /// 获取商品集合
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<MShangChengDingDan> GetList(int pageSize, int pageIndex, ref int recordCount, MShangChengDingDanSer chaXun)
        {
            IList<MShangChengDingDan> list = new List<MShangChengDingDan>();


            string tableName = "view_ShangChengOrder";
            string fileds = "OrderID,ProductID,ProductName,ProductNum,IssueTime,ContactName,OrderState,OrderPrice,OrderCode,PayState,SupplierID,ContactPhone,UserType,OperatorName,OperatorMobile,SupplierMoney,JiaoYiLv,SalePrice";
            string orderByString = "IssueTime desc";

            StringBuilder query = new StringBuilder();
            query.Append(" 1=1 ");

            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.OrderCode))
                {
                    query.AppendFormat(" and  OrderCode like '%{0}%' ", chaXun.OrderCode);
                }
                if (chaXun.OrderState != null)
                {
                    query.AppendFormat(" and  OrderState = '{0}' ", (int)chaXun.OrderState.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.ProductName))
                {
                    query.AppendFormat(" and  ProductName like '%{0}%' ", chaXun.ProductName);
                }
                if (!string.IsNullOrEmpty(chaXun.ContactID) && !string.IsNullOrEmpty(chaXun.SupplierID))
                {
                    query.AppendFormat(" AND ( ContactID='{0}' or SupplierID='{1}') ", chaXun.ContactID, chaXun.SupplierID);
                }
                else if (!string.IsNullOrEmpty(chaXun.ContactID))
                {
                    query.AppendFormat(" and  ContactID = '{0}' ", chaXun.ContactID);
                }
                else if(!string.IsNullOrEmpty(chaXun.SupplierID))
                {
                    if (chaXun.SupplierID == "0")
                    {
                        query.Append(" AND (SupplierID is null or  SupplierID = '')");
                    }
                    else
                    {
                        query.AppendFormat(" AND SupplierID = '{0}' ", chaXun.SupplierID);
                    }
                }
                if (!string.IsNullOrEmpty(chaXun.GYSid))
                {
                    query.AppendFormat(" and  GYSid = '{0}' ", chaXun.GYSid);
                }
                if (!string.IsNullOrEmpty(chaXun.IsTeYue))
                {
                    if (chaXun.IsTeYue == "1")//表示是查询特约订单，但是没有指定某个特约商户
                    {
                        query.Append(" and  IsTeYue<>'0' ");
                    }
                    else
                    {
                        query.AppendFormat(" and  IsTeYue='" + chaXun.IsTeYue + "' ", chaXun.IsTeYue);
                    }
                }
                if (chaXun.XiaDanBeginTime > Convert.ToDateTime("1990-01-01"))
                {
                    query.AppendFormat(" AND IssueTime>='{0}' ", chaXun.XiaDanBeginTime);
                }
                if (chaXun.XiaDanEndTime > Convert.ToDateTime("1990-01-01"))
                {
                    query.AppendFormat(" AND IssueTime<='{0}' ", chaXun.XiaDanEndTime);
                }
            }


            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref recordCount, tableName, fileds, query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {

                    MShangChengDingDan info = new MShangChengDingDan();
                    info.ProductID = dr.GetString(dr.GetOrdinal("ProductID")); ;
                    info.ProductName = dr.GetString(dr.GetOrdinal("ProductName"));
                    info.ProductNum = dr.GetInt32(dr.GetOrdinal("ProductNum"));
                    info.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    info.OrderID = dr.GetString(dr.GetOrdinal("OrderID")); ;
                    info.OrderState = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)dr.GetByte(dr.GetOrdinal("OrderState"));
                    info.OrderCode = dr.GetString(dr.GetOrdinal("OrderCode"));
                    info.OrderPrice = dr.GetDecimal(dr.GetOrdinal("OrderPrice"));
                    info.ContactName = dr.GetString(dr.GetOrdinal("ContactName"));
                    info.PayState = (EyouSoft.Model.Enum.PaymentState)dr.GetByte(dr.GetOrdinal("PayState"));
                    info.SupplierID = dr["SupplierID"].ToString();
                    info.SupplierMoney = dr.GetDecimal(dr.GetOrdinal("SupplierMoney"));
                    info.ContactPhone = dr["ContactPhone"].ToString();
                    info.OperatorMobile = dr["OperatorMobile"].ToString();
                    info.OperatorName = dr["OperatorName"].ToString();
                    info.JiaoYiLv = dr.GetDecimal(dr.GetOrdinal("JiaoYiLv"));
                    info.SalePrice = dr.GetDecimal(dr.GetOrdinal("SalePrice"));
                    
                    if (dr["UserType"] != null && dr["UserType"] != DBNull.Value)
                    {
                        info.UserType = (EyouSoft.Model.Enum.MemberTypes)dr.GetInt32(dr.GetOrdinal("UserType"));
                    }
                    else
                    {
                        info.UserType = EyouSoft.Model.Enum.MemberTypes.未注册用户;
                    }

                    list.Add(info);
                }
            }
            return list;
        }
        /// <summary>
        /// 设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int SheZhiOrderStatus(string orderId, OrderStatus status)
        {
            DbCommand cmd = _db.GetSqlStringCommand("UPDATE tbl_ShangChengDingDan SET OrderState=@OrderState WHERE OrderId=@OrderId ");

            _db.AddInParameter(cmd, "OrderState", DbType.Byte, status);
            _db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, orderId);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : 0;
        }

        /// <summary>
        /// 支付完成执行方法
        /// </summary>
        /// <param name="info">订单</param>
        /// <returns></returns>
        public int SheZhiZhiFus(MShangChengDingDan info)
        {
            DbCommand cmd = _db.GetSqlStringCommand("UPDATE tbl_ShangChengDingDan  SET PayState=@PayState, OrderState=@OrderState WHERE OrderId=@OrderId ");

            _db.AddInParameter(cmd, "PayState", DbType.Byte, info.PayState);
            _db.AddInParameter(cmd, "OrderState", DbType.Byte, info.OrderState);
            _db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, info.OrderID);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : 0;
        }
        /// <summary>
        /// 根据订单状态获取订单数量
        /// </summary>
        /// <param name="Status">订单状态</param>
        /// <returns></returns>
        public int GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus Status)
        {
            DbCommand cmd = _db.GetSqlStringCommand("Select count(OrderId) from View_ShangChengOrder WHERE OrderState=@Status   ");

            _db.AddInParameter(cmd, "Status", DbType.Byte, Status);

            object num = DbHelper.GetSingle(cmd, _db);
            return Convert.ToInt32(num);
        }
        //        #region 私有方法


        //        /// <summary>
        //        /// 创建XML
        //        /// </summary>
        //        /// <param name="items"></param>
        //        /// <returns></returns>
        //        string CreateTuPianXml(IList<MChanPinTuPian> items)
        //        {
        //            if (items == null || items.Count == 0) return string.Empty;
        //            StringBuilder s = new StringBuilder();
        //            s.Append("<root>");

        //            foreach (var item in items)
        //            {
        //                s.Append("<info ");
        //                s.AppendFormat(" ProductID=\"{0}\"", item.ProductID);
        //                s.AppendFormat(" FilePath=\"{0}\"", Utils.ReplaceXmlSpecialCharacter(item.FilePath));
        //                s.AppendFormat(" FileDesc=\"{0}\"", Utils.ReplaceXmlSpecialCharacter(item.FileDesc));
        //                s.Append(" />");
        //            }
        //            s.Append("</root>");

        //            return s.ToString();
        //        }

        //        /// <summary>
        //        /// 获取图片集合
        //        /// </summary>
        //        /// <returns></returns>
        //        IList<MChanPinTuPian> GetImgList(string xml)
        //        {
        //            if (string.IsNullOrEmpty(xml)) return null;
        //            IList<MChanPinTuPian> list = new List<MChanPinTuPian>();
        //            System.Xml.Linq.XElement xRoot = System.Xml.Linq.XElement.Parse(xml);
        //            var xRows = Utils.GetXElements(xRoot, "Root");
        //            foreach (var xRow in xRows)
        //            {
        //                MChanPinTuPian item = new MChanPinTuPian()
        //                {
        //                    ID = Utils.GetInt(Utils.GetXAttributeValue(xRow, "ID")),
        //                    ProductID = Utils.GetXAttributeValue(xRow, "ProductID"),
        //                    FilePath = Utils.GetXAttributeValue(xRow, "FilePath"),
        //                    FileDesc = Utils.GetXAttributeValue(xRow, "FileDesc")

        //                };

        //                list.Add(item);
        //            }
        //            return list;
        //        }
        //        #endregion
    }
}
