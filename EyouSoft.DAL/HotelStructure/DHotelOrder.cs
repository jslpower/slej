using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.HotelStructure;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using EyouSoft.Toolkit;
using EyouSoft.Toolkit.DAL;
using System.Data;
using System.Xml.Linq;
namespace EyouSoft.DAL.HotelStructure
{
    public class DHotelOrder : EyouSoft.Toolkit.DAL.DALBase, EyouSoft.IDAL.HotelStructure.IHotelOrder
    {
        #region 初始化db
        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DHotelOrder()
        {
            _db = base.SystemStore;
        }
        #endregion


        #region IHotelOrder 成员

        /// <summary>
        /// 增加一条数据
        ///  -1：酒店已删除或下架
        /// -2：房型已删除或下架
        /// -3:入住时间段存在错误价格信息
        /// -4:订单预订房间数超过房型最大房间数
        /// </summary>
        public int Add(MHotelOrder model)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_HotelOrder_Add");
            this._db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, model.OrderId);
            this._db.AddInParameter(cmd, "HotelId", DbType.AnsiStringFixedLength, model.HotelId);
            this._db.AddInParameter(cmd, "RoomTypeId", DbType.AnsiStringFixedLength, model.RoomTypeId);
            this._db.AddOutParameter(cmd, "OrderCode", DbType.String, 255);
            this._db.AddInParameter(cmd, "RoomCount", DbType.Int32, model.RoomCount);
            this._db.AddInParameter(cmd, "CheckInDate", DbType.DateTime, model.CheckInDate);
            this._db.AddInParameter(cmd, "CheckOutDate", DbType.DateTime, model.CheckOutDate);
            this._db.AddInParameter(cmd, "TotalAmount", DbType.Currency, model.TotalAmount);
            this._db.AddInParameter(cmd, "ContactName", DbType.String, model.ContactName);
            this._db.AddInParameter(cmd, "ContactMobile", DbType.String, model.ContactMobile);
            this._db.AddInParameter(cmd, "Remark", DbType.String, model.Remark);
            this._db.AddInParameter(cmd, "PaymentType", DbType.Byte, (int)model.PaymentType);
            this._db.AddInParameter(cmd, "PaymentState", DbType.Byte, (int)model.PaymentState);
            this._db.AddInParameter(cmd, "OrderState", DbType.Byte, (int)model.OrderState);
            this._db.AddInParameter(cmd, "Source", DbType.Byte, (int)model.Source);
            this._db.AddInParameter(cmd, "OperatorId", DbType.AnsiStringFixedLength, model.OperatorId);
            this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            this._db.AddInParameter(cmd, "JiaGeId", DbType.Int32, model.JiaGeId);
            this._db.AddInParameter(cmd, "BuyCompanyName", DbType.String, model.BuyCompanyName);
            this._db.AddInParameter(cmd, "OrderSite", DbType.Int32, model.OrderSite);
            _db.AddInParameter(cmd, "DanJia", DbType.Decimal, model.DanJia);

            DbHelper.RunProcedureWithResult(cmd, this._db);
            model.OrderCode = this._db.GetParameterValue(cmd, "OrderCode").ToString();
            return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result"));
        }

        /// <summary>
        /// 更新一条数据
        /// -1：酒店已删除或下架
        /// -2：房型已删除或下架
        /// -3:入住时间段存在错误价格信息
        /// -4:订单预订房间数超过房型最大房间数
        /// </summary>
        public int Update(MHotelOrder model)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_HotelOrder_Update");

            this._db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, model.OrderId);
            this._db.AddInParameter(cmd, "HotelId", DbType.AnsiStringFixedLength, model.HotelId);
            this._db.AddInParameter(cmd, "RoomTypeId", DbType.AnsiStringFixedLength, model.RoomTypeId);
            this._db.AddInParameter(cmd, "OrderCode", DbType.String, model.OrderCode);
            this._db.AddInParameter(cmd, "RoomCount", DbType.Int32, model.RoomCount);
            this._db.AddInParameter(cmd, "CheckInDate", DbType.DateTime, model.CheckInDate);
            this._db.AddInParameter(cmd, "CheckOutDate", DbType.DateTime, model.CheckOutDate);
            this._db.AddInParameter(cmd, "TotalAmount", DbType.Currency, model.TotalAmount);
            this._db.AddInParameter(cmd, "ContactName", DbType.String, model.ContactName);
            this._db.AddInParameter(cmd, "ContactMobile", DbType.String, model.ContactMobile);
            this._db.AddInParameter(cmd, "Remark", DbType.String, model.Remark);
            this._db.AddInParameter(cmd, "PaymentType", DbType.Byte, (int)model.PaymentType);
            this._db.AddInParameter(cmd, "PaymentState", DbType.Byte, (int)model.PaymentState);
            this._db.AddInParameter(cmd, "OrderState", DbType.Byte, (int)model.OrderState);
            this._db.AddInParameter(cmd, "Source", DbType.Byte, (int)model.Source);
            this._db.AddInParameter(cmd, "OperatorId", DbType.AnsiStringFixedLength, model.OperatorId);

            this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            DbHelper.RunProcedureWithResult(cmd, this._db);
            return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result"));
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        public MHotelOrder GetModel(string OrderId)
        {
            MHotelOrder model = null;

            string StrSql = "select * from view_HotelOrder where OrderId=@OrderId";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            this._db.AddInParameter(dc, "OrderId", DbType.AnsiStringFixedLength, OrderId);
            using (IDataReader dr = EyouSoft.Toolkit.DAL.DbHelper.ExecuteReader(dc, this._db))
            {
                if (dr.Read())
                {
                    model = new MHotelOrder();

                    model.OrderId = dr.GetString(dr.GetOrdinal("OrderId"));

                    model.HotelId = dr.IsDBNull(dr.GetOrdinal("HotelId")) ? "" : dr.GetString(dr.GetOrdinal("HotelId"));
                    model.HotelName = dr.IsDBNull(dr.GetOrdinal("HotelName")) ? "" : dr.GetString(dr.GetOrdinal("HotelName"));
                    model.RoomTypeId = dr.IsDBNull(dr.GetOrdinal("RoomTypeId")) ? "" : dr.GetString(dr.GetOrdinal("RoomTypeId"));
                    model.RoomName = dr.IsDBNull(dr.GetOrdinal("RoomName")) ? "" : dr.GetString(dr.GetOrdinal("RoomName"));
                    model.OrderCode = dr.GetString(dr.GetOrdinal("OrderCode"));
                    model.RoomCount = dr.GetInt32(dr.GetOrdinal("RoomCount"));
                    model.CheckInDate = dr.GetDateTime(dr.GetOrdinal("CheckInDate"));
                    model.CheckOutDate = dr.GetDateTime(dr.GetOrdinal("CheckOutDate"));
                    model.TotalAmount = dr.GetDecimal(dr.GetOrdinal("TotalAmount"));
                    model.ContactName = !dr.IsDBNull(dr.GetOrdinal("ContactName")) ? dr.GetString(dr.GetOrdinal("ContactName")) : null;
                    model.ContactMobile = !dr.IsDBNull(dr.GetOrdinal("ContactMobile")) ? dr.GetString(dr.GetOrdinal("ContactMobile")) : null;
                    model.Remark = !dr.IsDBNull(dr.GetOrdinal("Remark")) ? dr.GetString(dr.GetOrdinal("Remark")) : null;
                    model.PaymentType = (EyouSoft.Model.Enum.Payment)dr.GetByte(dr.GetOrdinal("PaymentType"));
                    model.PaymentState = (EyouSoft.Model.Enum.PaymentState)dr.GetByte(dr.GetOrdinal("PaymentState"));
                    model.OrderState = (EyouSoft.Model.Enum.OrderState)dr.GetByte(dr.GetOrdinal("OrderState"));
                    model.Source = (EyouSoft.Model.Enum.ScenicStructure.ScenicAreaOrderSource)dr.GetByte(dr.GetOrdinal("Source"));
                    model.OperatorId = dr.GetString(dr.GetOrdinal("OperatorId"));
                    model.OperatorName = !dr.IsDBNull(dr.GetOrdinal("OperatorName")) ? dr.GetString(dr.GetOrdinal("OperatorName")) : string.Empty;
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.JiaGeId = dr.GetInt32(dr.GetOrdinal("JiaGeId"));
                    model.DanJia = dr.GetDecimal(dr.GetOrdinal("DanJia"));
                    model.BuyCompanyName = !dr.IsDBNull(dr.GetOrdinal("BuyCompanyName")) ? dr.GetString(dr.GetOrdinal("BuyCompanyName")) : "";
                    model.SellerID = dr.GetString(dr.GetOrdinal("SellerID"));
                    model.AgencyJinE = dr.GetDecimal(dr.GetOrdinal("AgencyJinE"));
                    model.Star = (EyouSoft.Model.Enum.HotelStar)dr.GetByte(dr.GetOrdinal("Star"));
                    model.HotelXC = dr.IsDBNull(dr.GetOrdinal("HotelXC")) ? null : dr.GetString(dr.GetOrdinal("HotelXC"));

                    if (model != null)
                    {
                        model.OrderContact = GetContent(model.OrderId);
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表集合，分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public IList<MHotelOrder> GetList(int pageSize, int pageIndex, ref int recordCount, MHotelOrderSeach seach)
        {
            IList<MHotelOrder> list = new List<MHotelOrder>();

            string tableName = "view_HotelOrder";

            string fileds = " * ";

            string orderByString = " IssueTime desc ";


            StringBuilder query = new StringBuilder();
            query.Append(" 1=1 ");

            if (seach != null)
            {
                if (!string.IsNullOrEmpty(seach.BuyCompanyName))
                {
                    query.AppendFormat(" and BuyCompanyName like '%{0}%' ", seach.BuyCompanyName);
                }
                if (!string.IsNullOrEmpty(seach.HotelId))
                {
                    query.AppendFormat(" and HotelId = '{0}' ", Utils.ToSqlLike(seach.HotelId));
                }
                if (!string.IsNullOrEmpty(seach.HotelName))
                {
                    query.AppendFormat(" and HotelName like '%{0}%' ", seach.HotelName);
                }

                if (!string.IsNullOrEmpty(seach.RoomName))
                {
                    query.AppendFormat(" and RoomName like '%{0}%' ", seach.RoomName);
                }

                if (!string.IsNullOrEmpty(seach.OrderCode))
                {

                    query.AppendFormat(" and OrderCode like '%{0}%' ", seach.OrderCode);
                }

                if (seach.BeginIssueTime.HasValue)
                {

                    query.AppendFormat(" and datediff(day, IssueTime,'{0}')<=0 ", seach.BeginIssueTime.Value.ToShortDateString());
                }

                if (seach.EndIssueTime.HasValue)
                {

                    query.AppendFormat(" and datediff(day,IssueTime,'{0}')>=0 ", seach.EndIssueTime.Value.ToShortDateString());
                }

                if (seach.BeginCheckInDate.HasValue)
                {

                    query.AppendFormat(" and datediff(day,CheckInDate,'{0}')<=0 ", seach.BeginCheckInDate.Value.ToShortDateString());
                }

                if (seach.EndCheckInDate.HasValue)
                {

                    query.AppendFormat(" and datediff(day,CheckInDate,'{0}')>=0 ", seach.EndCheckInDate.Value.ToShortDateString());
                }

                if (seach.BeginCheckOutDate.HasValue)
                {

                    query.AppendFormat(" and datediff(day,CheckOutDate,'{0}')<=0 ", seach.BeginCheckOutDate.Value.ToShortDateString());
                }

                if (seach.EndCheckOutDate.HasValue)
                {

                    query.AppendFormat(" and datediff(day,CheckOutDate,'{0}')>=0 ", seach.EndCheckOutDate.Value.ToShortDateString());
                }

                if (!string.IsNullOrEmpty(seach.OperatorId) && !string.IsNullOrEmpty(seach.SellerID))
                {

                    query.AppendFormat(" and (OperatorId='{0}' or  SellerID ='{1}')", seach.OperatorId, seach.SellerID);
                }
                else if (!string.IsNullOrEmpty(seach.OperatorId))
                {

                    query.AppendFormat(" and OperatorId='{0}' ", seach.OperatorId);
                }
                else if (!string.IsNullOrEmpty(seach.SellerID))
                {
                    if (seach.SellerID == "0")
                    {
                        query.Append(" AND (SellerID is null or  SellerID = '')");
                    }
                    else
                    {
                        query.AppendFormat(" AND SellerID = '{0}' ", seach.SellerID);
                    }
                }

                if (!string.IsNullOrEmpty(seach.OperatorName))
                {
                    query.AppendFormat(" and OperatorName like '%{0}%' ", seach.OperatorName);
                }

                if (seach.Source.HasValue)
                {
                    query.AppendFormat(" and  Source={0} ", (int)seach.Source.Value);
                }
                


                if (seach.IsFeiHuiYuan)
                {
                    query.Append(" AND LEN(OperatorId)<>36 ");
                    query.AppendFormat(" AND OrderCode='{0}' ", seach.FeiHuiYuanDingDanHao);
                    query.AppendFormat(" AND ContactName='{0}' ", seach.FeiHuiYuanXingMing);
                    query.AppendFormat(" AND ContactMobile='{0}' ", seach.FeiHuiYuanDianHua);
                }
            }



            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref recordCount, tableName
                , fileds, query.ToString(), orderByString, null))
            {

                while (dr.Read())
                {
                    MHotelOrder model = new MHotelOrder();
                    model.OrderId = dr.GetString(dr.GetOrdinal("OrderId"));

                    model.HotelId = dr.IsDBNull(dr.GetOrdinal("HotelId")) ? "" : dr.GetString(dr.GetOrdinal("HotelId"));
                    model.HotelName = dr.IsDBNull(dr.GetOrdinal("HotelName")) ? "" : dr.GetString(dr.GetOrdinal("HotelName"));
                    model.RoomTypeId = dr.IsDBNull(dr.GetOrdinal("RoomTypeId")) ? "" : dr.GetString(dr.GetOrdinal("RoomTypeId"));
                    model.RoomName = dr.IsDBNull(dr.GetOrdinal("RoomName")) ? "" : dr.GetString(dr.GetOrdinal("RoomName"));
                    model.OrderCode = dr.GetString(dr.GetOrdinal("OrderCode"));
                    model.RoomCount = dr.GetInt32(dr.GetOrdinal("RoomCount"));
                    model.CheckInDate = dr.GetDateTime(dr.GetOrdinal("CheckInDate"));
                    model.CheckOutDate = dr.GetDateTime(dr.GetOrdinal("CheckOutDate"));
                    model.TotalAmount = dr.GetDecimal(dr.GetOrdinal("TotalAmount"));
                    model.ContactName = !dr.IsDBNull(dr.GetOrdinal("ContactName")) ? dr.GetString(dr.GetOrdinal("ContactName")) : null;
                    model.ContactMobile = !dr.IsDBNull(dr.GetOrdinal("ContactMobile")) ? dr.GetString(dr.GetOrdinal("ContactMobile")) : null;
                    model.Remark = !dr.IsDBNull(dr.GetOrdinal("Remark")) ? dr.GetString(dr.GetOrdinal("Remark")) : null;
                    model.PaymentType = (EyouSoft.Model.Enum.Payment)dr.GetByte(dr.GetOrdinal("PaymentType"));
                    model.PaymentState = (EyouSoft.Model.Enum.PaymentState)dr.GetByte(dr.GetOrdinal("PaymentState"));
                    model.OrderState = (EyouSoft.Model.Enum.OrderState)dr.GetByte(dr.GetOrdinal("OrderState"));
                    model.Source = (EyouSoft.Model.Enum.ScenicStructure.ScenicAreaOrderSource)dr.GetByte(dr.GetOrdinal("Source"));
                    model.OperatorId = dr.GetString(dr.GetOrdinal("OperatorId"));
                    model.OperatorName = !dr.IsDBNull(dr.GetOrdinal("OperatorName")) ? dr.GetString(dr.GetOrdinal("OperatorName")) : string.Empty;
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.BuyCompanyName = !dr.IsDBNull(dr.GetOrdinal("BuyCompanyName")) ? dr.GetString(dr.GetOrdinal("BuyCompanyName")) : "";
                    model.OperatorMobile = !dr.IsDBNull(dr.GetOrdinal("OperatorMobile")) ? dr.GetString(dr.GetOrdinal("OperatorMobile")) : string.Empty;
                    if (dr["UserType"] != null && dr["UserType"] != DBNull.Value)
                    {
                        model.UserType = (EyouSoft.Model.Enum.MemberTypes)dr.GetInt32(dr.GetOrdinal("UserType"));
                    }
                    else
                    {
                        model.UserType = EyouSoft.Model.Enum.MemberTypes.未注册用户;
                    }
                    model.SellerID = dr.GetString(dr.GetOrdinal("SellerID"));
                    model.AgencyJinE = dr.GetDecimal(dr.GetOrdinal("AgencyJinE"));
                    model.HotelXC = dr.IsDBNull(dr.GetOrdinal("HotelXC")) ? null : dr.GetString(dr.GetOrdinal("HotelXC"));
                    list.Add(model);
                }
            };
            return list;
        }

        /// <summary>
        /// 获得前几行数据集合
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="seach"></param>
        /// <returns></returns>
        public IList<MHotelOrder> GetList(int Top, MHotelOrderSeach seach)
        {

            IList<MHotelOrder> list = new List<MHotelOrder>();

            StringBuilder query = new StringBuilder();
            query.AppendFormat(" select {0} * from view_HotelOrder ", (Top > 0 ? " TOP " + Top + " " : ""));

            query.Append(" where  1=1 ");

            if (seach != null)
            {
                if (!string.IsNullOrEmpty(seach.HotelName))
                {
                    query.AppendFormat(" and HotelName like '%{0}%' ", seach.HotelName);
                }

                if (!string.IsNullOrEmpty(seach.RoomName))
                {
                    query.AppendFormat(" and RoomName like '%{0}%' ", seach.RoomName);
                }

                if (!string.IsNullOrEmpty(seach.OrderCode))
                {

                    query.AppendFormat(" and OrderCode like '%{0}%' ", seach.OrderCode);
                }

                if (seach.BeginIssueTime.HasValue)
                {

                    query.AppendFormat(" and datediff(day,IssueTime,'{0}')>=0 ", seach.BeginIssueTime.Value);
                }

                if (seach.EndIssueTime.HasValue)
                {

                    query.AppendFormat(" and datediff(day,IssueTime,'{0}')<=0 ", seach.EndIssueTime.Value);
                }

                if (seach.BeginCheckInDate.HasValue)
                {

                    query.AppendFormat(" and datediff(day,CheckInDate,'{0}')>=0 ", seach.BeginCheckInDate.Value);
                }

                if (seach.EndCheckInDate.HasValue)
                {

                    query.AppendFormat(" and datediff(day,CheckInDate,'{0}')<=0 ", seach.EndCheckInDate.Value);
                }

                if (seach.BeginCheckOutDate.HasValue)
                {

                    query.AppendFormat(" and datediff(day,CheckOutDate,'{0}')>=0 ", seach.BeginCheckOutDate.Value);
                }

                if (seach.EndCheckOutDate.HasValue)
                {

                    query.AppendFormat(" and datediff(day,CheckOutDate,'{0}')<=0 ", seach.EndCheckOutDate.Value);
                }

                if (!string.IsNullOrEmpty(seach.OperatorId))
                {

                    query.AppendFormat(" and OperatorId='{0}' ", seach.OperatorId);
                }

                if (!string.IsNullOrEmpty(seach.OperatorName))
                {
                    query.AppendFormat(" and OperatorName like '%{0}%' ", seach.OperatorName);
                }

                if (seach.Source.HasValue)
                {
                    query.AppendFormat(" and  Source={0} ", (int)seach.Source.Value);
                }

            }
            DbCommand cmd = this._db.GetSqlStringCommand(query.ToString());


            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    MHotelOrder model = new MHotelOrder();
                    model.OrderId = dr.GetString(dr.GetOrdinal("OrderId"));

                    model.HotelId = dr.IsDBNull(dr.GetOrdinal("HotelId")) ? "" : dr.GetString(dr.GetOrdinal("HotelId"));
                    model.HotelName = dr.IsDBNull(dr.GetOrdinal("HotelName")) ? "" : dr.GetString(dr.GetOrdinal("HotelName"));
                    model.RoomTypeId = dr.IsDBNull(dr.GetOrdinal("RoomTypeId")) ? "" : dr.GetString(dr.GetOrdinal("RoomTypeId"));
                    model.RoomName = dr.IsDBNull(dr.GetOrdinal("RoomName")) ? "" : dr.GetString(dr.GetOrdinal("RoomName"));
                    model.OrderCode = dr.GetString(dr.GetOrdinal("OrderCode"));
                    model.RoomCount = dr.GetInt32(dr.GetOrdinal("RoomCount"));
                    model.CheckInDate = dr.GetDateTime(dr.GetOrdinal("CheckInDate"));
                    model.CheckOutDate = dr.GetDateTime(dr.GetOrdinal("CheckOutDate"));
                    model.TotalAmount = dr.GetDecimal(dr.GetOrdinal("TotalAmount"));
                    model.ContactName = !dr.IsDBNull(dr.GetOrdinal("ContactName")) ? dr.GetString(dr.GetOrdinal("ContactName")) : null;
                    model.ContactMobile = !dr.IsDBNull(dr.GetOrdinal("ContactMobile")) ? dr.GetString(dr.GetOrdinal("ContactMobile")) : null;
                    model.Remark = !dr.IsDBNull(dr.GetOrdinal("Remark")) ? dr.GetString(dr.GetOrdinal("Remark")) : null;
                    model.PaymentType = (EyouSoft.Model.Enum.Payment)dr.GetByte(dr.GetOrdinal("PaymentType"));
                    model.PaymentState = (EyouSoft.Model.Enum.PaymentState)dr.GetByte(dr.GetOrdinal("PaymentState"));
                    model.OrderState = (EyouSoft.Model.Enum.OrderState)dr.GetByte(dr.GetOrdinal("OrderState"));
                    model.Source = (EyouSoft.Model.Enum.ScenicStructure.ScenicAreaOrderSource)dr.GetByte(dr.GetOrdinal("Source"));
                    model.OperatorId = dr.GetString(dr.GetOrdinal("OperatorId"));
                    model.OperatorName = !dr.IsDBNull(dr.GetOrdinal("OperatorName")) ? dr.GetString(dr.GetOrdinal("OperatorName")) : string.Empty;
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));

                    list.Add(model);
                }
            }

            return list;


        }

        /// <summary>
        /// 修改订单状态
        /// </summary>
        /// <param name="OrderState"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool UpdateOrderState(EyouSoft.Model.Enum.OrderState OrderState, string OrderId)
        {
            string strSql = "UPDATE tbl_HotelOrder SET OrderState=@OrderState Where OrderId=@OrderId ";
            DbCommand cmd = this._db.GetSqlStringCommand(strSql);
            this._db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, OrderId);
            this._db.AddInParameter(cmd, "OrderState", DbType.Byte, (int)OrderState);
            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }


        /// <summary>
        /// 修改审核状态
        /// </summary>
        /// <param name="CheckState"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool UpdatePaymentState(EyouSoft.Model.Enum.PaymentState PaymentState, string OrderId)
        {
            string strSql = "UPDATE tbl_HotelOrder SET PaymentState=@PaymentState Where OrderId=@OrderId ";
            DbCommand cmd = this._db.GetSqlStringCommand(strSql);
            this._db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, OrderId);
            this._db.AddInParameter(cmd, "PaymentState", DbType.Byte, (int)PaymentState);
            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }
        /// <summary>
        /// 获取联系人
        /// </summary>
        /// <param name="OrderId">订单id</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.HotelStructure.MHotelOrderContact> GetContent(string OrderId)
        {
            IList<MHotelOrderContact> list = new List<MHotelOrderContact>();

            StringBuilder query = new StringBuilder();
            query.AppendFormat(" select * from tbl_HotelOrderContact where OrderId='{0}' ", OrderId);

            DbCommand cmd = this._db.GetSqlStringCommand(query.ToString());


            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    MHotelOrderContact model = new MHotelOrderContact();
                    model.OrderId = dr.GetString(dr.GetOrdinal("OrderId"));
                    model.ContactName = !dr.IsDBNull(dr.GetOrdinal("ContactName")) ? dr.GetString(dr.GetOrdinal("ContactName")) : null;
                    model.Mobile = !dr.IsDBNull(dr.GetOrdinal("Mobile")) ? dr.GetString(dr.GetOrdinal("Mobile")) : null;

                    list.Add(model);
                }
            }

            return list;

        }
        /// <summary>
        /// 支付完成执行方法
        /// </summary>
        /// <param name="info">订单</param>
        /// <returns></returns>
        public int SheZhiZhiFus(MHotelOrder info)
        {
            DbCommand cmd = _db.GetSqlStringCommand("UPDATE tbl_HotelOrder  SET  PaymentState=@PaymentState,OrderState=@OrderState  WHERE OrderId=@OrderId ");

            _db.AddInParameter(cmd, "PaymentState", DbType.Byte, info.PaymentState);
            _db.AddInParameter(cmd, "OrderState", DbType.Byte, info.OrderState);
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
            DbCommand cmd = _db.GetSqlStringCommand("Delete from tbl_HotelOrder WHERE  OrderId=@OrderId and OrderState=@Status   ");

            _db.AddInParameter(cmd, "Status", DbType.Byte, EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理);
            _db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, orderid);

            int num = DbHelper.ExecuteSql(cmd, _db);
            if (num > 0)
            {
                DbCommand cmd1 = _db.GetSqlStringCommand("Delete from tbl_HotelOrderContact WHERE  OrderId=@OrderId      ;    Delete from tbl_HotelOrderRoomRateId WHERE  OrderId=@OrderId");

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
            DbCommand cmd = _db.GetSqlStringCommand("Select count(OrderId) from view_HotelOrder WHERE OrderState=@Status   ");

            _db.AddInParameter(cmd, "Status", DbType.Byte, Status);

            object num = DbHelper.GetSingle(cmd, _db);
            return Convert.ToInt32(num);
        }
        #endregion

        /// <summary>
        /// 序列化返回string类型
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string getJsonStr(IList<HotelXingCheng> list)
        {

            if (list == null || list.Count == 0) return string.Empty;

            return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(list);

        }

        /// <summary>
        /// 反序列化返回list
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public static IList<HotelXingCheng> getStrJson(string jsonStr)
        {

            if (string.IsNullOrEmpty(jsonStr)) return null;


            return new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<IList<HotelXingCheng>>(jsonStr);

        }

    }
}
