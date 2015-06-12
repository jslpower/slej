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
    public class DHotelTourCustoms : EyouSoft.Toolkit.DAL.DALBase, EyouSoft.IDAL.HotelStructure.IHotelTourCustoms
    {
        #region 初始化db
        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DHotelTourCustoms()
        {
            _db = base.SystemStore;
        }
        #endregion

        #region 酒店团队定制
        #region IHotelTourCustoms 成员

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MHotelTourCustoms model)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_HotelTourCustoms_Add");
            this._db.AddInParameter(cmd, "UserID", DbType.AnsiStringFixedLength, model.UserID);
            this._db.AddInParameter(cmd, "ContacterName", DbType.String, model.ContacterName);
            this._db.AddInParameter(cmd, "ContacterMobile", DbType.AnsiString, model.ContacterMobile);
            this._db.AddInParameter(cmd, "ContacterTelephone", DbType.AnsiString, model.ContacterTelephone);
            this._db.AddInParameter(cmd, "HotelId", DbType.AnsiStringFixedLength, model.HotelId);
            this._db.AddInParameter(cmd, "HotelCode", DbType.AnsiString, model.HotelCode);
            this._db.AddInParameter(cmd, "HotelName", DbType.String, model.HotelName);
            this._db.AddInParameter(cmd, "HotelStar", DbType.Byte, (int)model.HotelStar);
            this._db.AddInParameter(cmd, "CityCode", DbType.AnsiString, model.CityCode);
            this._db.AddInParameter(cmd, "LocationAsk", DbType.String, model.LocationAsk);
            this._db.AddInParameter(cmd, "RoomAsk", DbType.String, model.RoomAsk);
            this._db.AddInParameter(cmd, "LiveStartDate", DbType.DateTime, model.LiveStartDate);
            this._db.AddInParameter(cmd, "LiveEndDate", DbType.DateTime, model.LiveEndDate);
            this._db.AddInParameter(cmd, "RoomCount", DbType.Int32, model.RoomCount);
            this._db.AddInParameter(cmd, "PeopleCount", DbType.Int32, model.PeopleCount);
            this._db.AddInParameter(cmd, "BudgetMin", DbType.Currency, model.BudgetMin);
            this._db.AddInParameter(cmd, "BudgetMax", DbType.Currency, model.BudgetMax);
            this._db.AddInParameter(cmd, "Payment", DbType.Byte, (int)model.Payment);
            this._db.AddInParameter(cmd, "GuestType", DbType.Byte, (int)model.GuestType);
            this._db.AddInParameter(cmd, "TourType", DbType.Byte, (int)model.TourType);
            this._db.AddInParameter(cmd, "OtherRemark", DbType.String, model.OtherRemark);
            this._db.AddInParameter(cmd, "IssueTime", DbType.DateTime, model.IssueTime);
            this._db.AddInParameter(cmd, "TreatState", DbType.Byte, (int)model.TreatState);
            this._db.AddInParameter(cmd, "TreateTime", DbType.DateTime, model.TreateTime);
            this._db.AddInParameter(cmd, "OperatorId", DbType.Int32, model.OperatorId);
            this._db.AddInParameter(cmd, "Source", DbType.Byte, (int)model.Source);
            this._db.AddInParameter(cmd, "AskListXML", DbType.Xml, CreateAskListXML(model.AskList));
            this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);

            DbHelper.RunProcedureWithResult(cmd, this._db);

            return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result")) > 0 ? true : false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MHotelTourCustoms model)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_HotelTourCustoms_Update");

            this._db.AddInParameter(cmd, "Id", DbType.Int32, model.Id);
            this._db.AddInParameter(cmd, "UserID", DbType.AnsiStringFixedLength, model.UserID);
            this._db.AddInParameter(cmd, "ContacterName", DbType.String, model.ContacterName);
            this._db.AddInParameter(cmd, "ContacterMobile", DbType.AnsiString, model.ContacterMobile);
            this._db.AddInParameter(cmd, "ContacterTelephone", DbType.AnsiString, model.ContacterTelephone);
            this._db.AddInParameter(cmd, "HotelId", DbType.AnsiStringFixedLength, model.HotelId);
            this._db.AddInParameter(cmd, "HotelCode", DbType.AnsiString, model.HotelCode);
            this._db.AddInParameter(cmd, "HotelName", DbType.String, model.HotelName);
            this._db.AddInParameter(cmd, "HotelStar", DbType.Byte, (int)model.HotelStar);
            this._db.AddInParameter(cmd, "CityCode", DbType.AnsiString, model.CityCode);
            this._db.AddInParameter(cmd, "LocationAsk", DbType.String, model.LocationAsk);
            this._db.AddInParameter(cmd, "RoomAsk", DbType.String, model.RoomAsk);
            this._db.AddInParameter(cmd, "LiveStartDate", DbType.DateTime, model.LiveStartDate);
            this._db.AddInParameter(cmd, "LiveEndDate", DbType.DateTime, model.LiveEndDate);
            this._db.AddInParameter(cmd, "RoomCount", DbType.Int32, model.RoomCount);
            this._db.AddInParameter(cmd, "PeopleCount", DbType.Int32, model.PeopleCount);
            this._db.AddInParameter(cmd, "BudgetMin", DbType.Currency, model.BudgetMin);
            this._db.AddInParameter(cmd, "BudgetMax", DbType.Currency, model.BudgetMax);
            this._db.AddInParameter(cmd, "Payment", DbType.Byte, (int)model.Payment);
            this._db.AddInParameter(cmd, "GuestType", DbType.Byte, (int)model.GuestType);
            this._db.AddInParameter(cmd, "TourType", DbType.Byte, (int)model.TourType);
            this._db.AddInParameter(cmd, "OtherRemark", DbType.String, model.OtherRemark);
            this._db.AddInParameter(cmd, "IssueTime", DbType.DateTime, model.IssueTime);
            this._db.AddInParameter(cmd, "TreatState", DbType.Byte, (int)model.TreatState);
            this._db.AddInParameter(cmd, "TreateTime", DbType.DateTime, model.TreateTime);
            this._db.AddInParameter(cmd, "OperatorId", DbType.Int32, model.OperatorId);
            this._db.AddInParameter(cmd, "Source", DbType.Byte, (int)model.Source);
            this._db.AddInParameter(cmd, "AskListXML", DbType.Xml, CreateAskListXML(model.AskList));
            this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);

            DbHelper.RunProcedureWithResult(cmd, this._db);

            return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result")) > 0 ? true : false;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool Delete(params int[] Ids)
        {
            StringBuilder sId = new StringBuilder();
            for (int i = 0; i < Ids.Length; i++)
            {
                sId.AppendFormat("{0},", Ids[i]);
            }
            sId.Remove(sId.Length - 1, 1);
            DbCommand dc = this._db.GetStoredProcCommand("proc_HotelTourCustoms_Delete");
            this._db.AddInParameter(dc, "IDs", DbType.AnsiString, sId.ToString());
            this._db.AddOutParameter(dc, "Result", DbType.Int32, 4);
            EyouSoft.Toolkit.DAL.DbHelper.RunProcedure(dc, this._db);
            object Result = this._db.GetParameterValue(dc, "Result");
            if (!Result.Equals(null))
            {
                return int.Parse(Result.ToString()) == 0 ? false : true;
            }
            return false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        public MHotelTourCustoms GetModel(int Id)
        {
            MHotelTourCustoms model = null;
            string StrSql = "SELECT [Id],[UserID],[ContacterName],[ContacterMobile],[ContacterTelephone],[HotelId],[HotelCode],[HotelName],[HotelStar],[CityCode],[LocationAsk],[RoomAsk],[LiveStartDate],[LiveEndDate],[RoomCount],[PeopleCount],[BudgetMin],[BudgetMax],[Payment],[GuestType],[TourType],[OtherRemark],[IssueTime],[TreatState],[TreateTime],[OperatorId],[Source]";
            StrSql += ",(SELECT top 1 Account from tbl_Member where MemberID=tbl_HotelTourCustoms.UserID) as UserName";
            StrSql += ",(SELECT ID,TourOrderID,AskName,AskTime,AskContent FROM tbl_HotelTourCustomsAsk WHERE TourOrderID=tbl_HotelTourCustoms.Id FOR XML RAW,ROOT('ROOT'))AS AskListXML FROM tbl_HotelTourCustoms WHERE Id=@Id";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
            this._db.AddInParameter(dc, "Id", DbType.Int32, Id);
            using (IDataReader dr = EyouSoft.Toolkit.DAL.DbHelper.ExecuteReader(dc, this._db))
            {
                if (dr.Read())
                {
                    model = new MHotelTourCustoms();

                    model.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                    model.UserID = dr.IsDBNull(dr.GetOrdinal("UserID")) ? "" : dr.GetString(dr.GetOrdinal("UserID"));
                    model.UserName = dr.IsDBNull(dr.GetOrdinal("UserName")) ? "" : dr.GetString(dr.GetOrdinal("UserName"));
                    model.ContacterName = dr.IsDBNull(dr.GetOrdinal("ContacterName")) ? "" : dr.GetString(dr.GetOrdinal("ContacterName"));
                    model.ContacterMobile = dr.IsDBNull(dr.GetOrdinal("ContacterMobile")) ? "" : dr.GetString(dr.GetOrdinal("ContacterMobile"));
                    model.ContacterTelephone = dr.IsDBNull(dr.GetOrdinal("ContacterTelephone")) ? "" : dr.GetString(dr.GetOrdinal("ContacterTelephone"));
                    model.HotelId = dr.IsDBNull(dr.GetOrdinal("HotelId")) ? "" : dr.GetString(dr.GetOrdinal("HotelId"));
                    model.HotelCode = dr.IsDBNull(dr.GetOrdinal("HotelCode")) ? "" : dr.GetString(dr.GetOrdinal("HotelCode"));
                    model.HotelName = dr.IsDBNull(dr.GetOrdinal("HotelName")) ? "" : dr.GetString(dr.GetOrdinal("HotelName"));
                    if (!dr.IsDBNull(dr.GetOrdinal("HotelStar")))
                    {
                        model.HotelStar = (EyouSoft.Model.Enum.HotelStar)dr.GetByte(dr.GetOrdinal("HotelStar"));
                    }
                    model.CityCode = dr.IsDBNull(dr.GetOrdinal("CityCode")) ? "" : dr.GetString(dr.GetOrdinal("CityCode"));
                    model.LocationAsk = dr.IsDBNull(dr.GetOrdinal("LocationAsk")) ? "" : dr.GetString(dr.GetOrdinal("LocationAsk"));
                    model.RoomAsk = dr.IsDBNull(dr.GetOrdinal("RoomAsk")) ? "" : dr.GetString(dr.GetOrdinal("RoomAsk"));
                    if (!dr.IsDBNull(dr.GetOrdinal("LiveStartDate")))
                    {
                        model.LiveStartDate = dr.GetDateTime(dr.GetOrdinal("LiveStartDate"));
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("LiveEndDate")))
                    {
                        model.LiveEndDate = dr.GetDateTime(dr.GetOrdinal("LiveEndDate"));
                    }
                    model.RoomCount = dr.IsDBNull(dr.GetOrdinal("RoomCount")) ? 0 : dr.GetInt32(dr.GetOrdinal("RoomCount"));
                    model.PeopleCount = dr.IsDBNull(dr.GetOrdinal("PeopleCount")) ? 0 : dr.GetInt32(dr.GetOrdinal("PeopleCount"));
                    model.BudgetMin = dr.IsDBNull(dr.GetOrdinal("BudgetMin")) ? 0 : dr.GetDecimal(dr.GetOrdinal("BudgetMin"));
                    model.BudgetMax = dr.IsDBNull(dr.GetOrdinal("BudgetMax")) ? 0 : dr.GetDecimal(dr.GetOrdinal("BudgetMax"));
                    if (!dr.IsDBNull(dr.GetOrdinal("Payment")))
                    {
                        model.Payment = (EyouSoft.Model.Enum.Payment)dr.GetByte(dr.GetOrdinal("Payment"));
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("GuestType")))
                    {
                        model.GuestType = (EyouSoft.Model.Enum.GuestType)dr.GetByte(dr.GetOrdinal("GuestType"));
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("TourType")))
                    {
                        model.TourType = (EyouSoft.Model.Enum.TourType)dr.GetByte(dr.GetOrdinal("TourType"));
                    }
                    model.OtherRemark = dr.IsDBNull(dr.GetOrdinal("OtherRemark")) ? "" : dr.GetString(dr.GetOrdinal("OtherRemark"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                    {
                        model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("TreatState")))
                    {
                        model.TreatState = (EyouSoft.Model.Enum.TreatState)dr.GetByte(dr.GetOrdinal("TreatState"));
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("TreateTime")))
                    {
                        model.TreateTime = dr.GetDateTime(dr.GetOrdinal("TreateTime"));
                    }
                    model.OperatorId = dr.IsDBNull(dr.GetOrdinal("OperatorId")) ? 0 : dr.GetInt32(dr.GetOrdinal("OperatorId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("Source")))
                    {
                        model.Source = (EyouSoft.Model.Enum.ScenicStructure.ScenicAreaOrderSource)dr.GetByte(dr.GetOrdinal("Source"));
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("AskListXML")))
                    {
                        model.AskList = GetAskList(dr.GetString(dr.GetOrdinal("AskListXML")));
                    }
                }
            };
            return model;
        }

        /// <summary>
        /// 获得数据列表集合，分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="Seach"></param>
        /// <returns></returns>
        public IList<MHotelTourCustoms> GetList(int pageSize, int pageIndex, ref int recordCount, MHotelTourCustomsSeach Seach)
        {
            IList<MHotelTourCustoms> ResultList = null;
            string tableName = "tbl_HotelTourCustoms";
            StringBuilder fields = new StringBuilder();
            fields.Append("[Id],[UserID],[ContacterName],[ContacterMobile],[ContacterTelephone],[HotelId],[HotelCode],[HotelName],[HotelStar],[CityCode],[LocationAsk],[RoomAsk],[LiveStartDate],[LiveEndDate],[RoomCount],[PeopleCount],[BudgetMin],[BudgetMax],[Payment],[GuestType],[TourType],[OtherRemark],[IssueTime],[TreatState],[TreateTime],[OperatorId],[Source]");
            fields.Append(",(SELECT top 1 Account from tbl_Member where MemberID=tbl_HotelTourCustoms.UserID) as UserName");
            fields.Append(",(SELECT ID,TourOrderID,AskName,AskTime,AskContent FROM tbl_HotelTourCustomsAsk WHERE TourOrderID=tbl_HotelTourCustoms.Id FOR XML RAW,ROOT('ROOT'))AS AskListXML");
            StringBuilder query = new StringBuilder();
            query.Append(" 1=1 ");
            if (Seach != null)
            {
                if (Seach.LiveStartDateS.HasValue)
                {
                    query.AppendFormat(" AND LiveStartDate>='{0}' ", Seach.LiveStartDateS.Value.ToShortDateString() + " 00:00:00");
                }
                if (Seach.LiveStartDateE.HasValue)
                {
                    query.AppendFormat(" AND LiveStartDate<='{0}' ", Seach.LiveStartDateE.Value.ToShortDateString() + " 23:59:59");
                }
                if (Seach.LiveEndDateS.HasValue)
                {
                    query.AppendFormat(" AND LiveEndDate>='{0}' ", Seach.LiveEndDateS.Value.ToShortDateString() + " 00:00:00");
                }
                if (Seach.LiveEndDateE.HasValue)
                {
                    query.AppendFormat(" AND LiveEndDate<='{0}' ", Seach.LiveEndDateE.Value.ToShortDateString() + " 23:59:59");
                }
                if (Seach.TreateTimeS.HasValue)
                {
                    query.AppendFormat(" AND TreateTime>='{0}' ", Seach.TreateTimeS.Value.ToShortDateString() + " 00:00:00");
                }
                if (Seach.TreateTimeE.HasValue)
                {
                    query.AppendFormat(" AND TreateTime<='{0}' ", Seach.TreateTimeE.Value.ToShortDateString() + " 23:59:59");
                }
                if (Seach.TreatState.HasValue)
                {
                    query.AppendFormat(" AND TreatState='{0}' ", (int)Seach.TreatState);
                }
            }
            string orderByString = "IssueTime DESC";
            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), query.ToString(), orderByString, null))
            {
                ResultList = new List<MHotelTourCustoms>();
                while (dr.Read())
                {
                    MHotelTourCustoms model = new MHotelTourCustoms();
                    model.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                    model.UserID = dr.IsDBNull(dr.GetOrdinal("UserID")) ? "" : dr.GetString(dr.GetOrdinal("UserID"));
                    model.UserName = dr.IsDBNull(dr.GetOrdinal("UserName")) ? "" : dr.GetString(dr.GetOrdinal("UserName"));
                    model.ContacterName = dr.IsDBNull(dr.GetOrdinal("ContacterName")) ? "" : dr.GetString(dr.GetOrdinal("ContacterName"));
                    model.ContacterMobile = dr.IsDBNull(dr.GetOrdinal("ContacterMobile")) ? "" : dr.GetString(dr.GetOrdinal("ContacterMobile"));
                    model.ContacterTelephone = dr.IsDBNull(dr.GetOrdinal("ContacterTelephone")) ? "" : dr.GetString(dr.GetOrdinal("ContacterTelephone"));
                    model.HotelId = dr.IsDBNull(dr.GetOrdinal("HotelId")) ? "" : dr.GetString(dr.GetOrdinal("HotelId"));
                    model.HotelCode = dr.IsDBNull(dr.GetOrdinal("HotelCode")) ? "" : dr.GetString(dr.GetOrdinal("HotelCode"));
                    model.HotelName = dr.IsDBNull(dr.GetOrdinal("HotelName")) ? "" : dr.GetString(dr.GetOrdinal("HotelName"));
                    if (!dr.IsDBNull(dr.GetOrdinal("HotelStar")))
                    {
                        model.HotelStar = (EyouSoft.Model.Enum.HotelStar)dr.GetByte(dr.GetOrdinal("HotelStar"));
                    }
                    model.CityCode = dr.IsDBNull(dr.GetOrdinal("CityCode")) ? "" : dr.GetString(dr.GetOrdinal("CityCode"));
                    model.LocationAsk = dr.IsDBNull(dr.GetOrdinal("LocationAsk")) ? "" : dr.GetString(dr.GetOrdinal("LocationAsk"));
                    model.RoomAsk = dr.IsDBNull(dr.GetOrdinal("RoomAsk")) ? "" : dr.GetString(dr.GetOrdinal("RoomAsk"));
                    if (!dr.IsDBNull(dr.GetOrdinal("LiveStartDate")))
                    {
                        model.LiveStartDate = dr.GetDateTime(dr.GetOrdinal("LiveStartDate"));
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("LiveEndDate")))
                    {
                        model.LiveEndDate = dr.GetDateTime(dr.GetOrdinal("LiveEndDate"));
                    }
                    model.RoomCount = dr.IsDBNull(dr.GetOrdinal("RoomCount")) ? 0 : dr.GetInt32(dr.GetOrdinal("RoomCount"));
                    model.PeopleCount = dr.IsDBNull(dr.GetOrdinal("PeopleCount")) ? 0 : dr.GetInt32(dr.GetOrdinal("PeopleCount"));
                    model.BudgetMin = dr.IsDBNull(dr.GetOrdinal("BudgetMin")) ? 0 : dr.GetDecimal(dr.GetOrdinal("BudgetMin"));
                    model.BudgetMax = dr.IsDBNull(dr.GetOrdinal("BudgetMax")) ? 0 : dr.GetDecimal(dr.GetOrdinal("BudgetMax"));
                    if (!dr.IsDBNull(dr.GetOrdinal("Payment")))
                    {
                        model.Payment = (EyouSoft.Model.Enum.Payment)dr.GetByte(dr.GetOrdinal("Payment"));
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("GuestType")))
                    {
                        model.GuestType = (EyouSoft.Model.Enum.GuestType)dr.GetByte(dr.GetOrdinal("GuestType"));
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("TourType")))
                    {
                        model.TourType = (EyouSoft.Model.Enum.TourType)dr.GetByte(dr.GetOrdinal("TourType"));
                    }
                    model.OtherRemark = dr.IsDBNull(dr.GetOrdinal("OtherRemark")) ? "" : dr.GetString(dr.GetOrdinal("OtherRemark"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                    {
                        model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("TreatState")))
                    {
                        model.TreatState = (EyouSoft.Model.Enum.TreatState)dr.GetByte(dr.GetOrdinal("TreatState"));
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("TreateTime")))
                    {
                        model.TreateTime = dr.GetDateTime(dr.GetOrdinal("TreateTime"));
                    }
                    model.OperatorId = dr.IsDBNull(dr.GetOrdinal("OperatorId")) ? 0 : dr.GetInt32(dr.GetOrdinal("OperatorId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("Source")))
                    {
                        model.Source = (EyouSoft.Model.Enum.ScenicStructure.ScenicAreaOrderSource)dr.GetByte(dr.GetOrdinal("Source"));
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("AskListXML")))
                    {
                        model.AskList = GetAskList(dr.GetString(dr.GetOrdinal("AskListXML")));
                    }
                    ResultList.Add(model);
                    model = null;
                }
            };
            return ResultList;
        }

        /// <summary>
        /// 获得前几行数据集合
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="Seach"></param>
        /// <returns></returns>
        public IList<MHotelTourCustoms> GetList(int Top, MHotelTourCustomsSeach Seach)
        {
            IList<MHotelTourCustoms> ResultList = null;
            StringBuilder StrSql = new StringBuilder();
            StrSql.AppendFormat("SELECT {0} [Id],[UserID],[ContacterName],[ContacterMobile],[ContacterTelephone],[HotelId],[HotelCode],[HotelName],[HotelStar],[CityCode],[LocationAsk],[RoomAsk],[LiveStartDate],[LiveEndDate],[RoomCount],[PeopleCount],[BudgetMin],[BudgetMax],[Payment],[GuestType],[TourType],[OtherRemark],[IssueTime],[TreatState],[TreateTime],[OperatorId],[Source],(SELECT top 1 Account from tbl_Member where MemberID=tbl_HotelTourCustoms.UserID) as UserName,(SELECT ID,TourOrderID,AskName,AskTime,AskContent FROM tbl_HotelTourCustomsAsk WHERE TourOrderID=tbl_HotelTourCustoms.Id FOR XML RAW,ROOT('ROOT'))AS AskListXML FROM tbl_HotelTourCustoms WHERE 1=1 ", (Top > 0 ? " TOP " + Top + " " : ""));
            if (Seach != null)
            {
                if (Seach.LiveStartDateS.HasValue)
                {
                    StrSql.AppendFormat(" AND LiveStartDate>='{0}' ", Seach.LiveStartDateS.Value.ToShortDateString() + " 00:00:00");
                }
                if (Seach.LiveStartDateE.HasValue)
                {
                    StrSql.AppendFormat(" AND LiveStartDate<='{0}' ", Seach.LiveStartDateE.Value.ToShortDateString() + " 23:59:59");
                }
                if (Seach.LiveEndDateS.HasValue)
                {
                    StrSql.AppendFormat(" AND LiveEndDate>='{0}' ", Seach.LiveEndDateS.Value.ToShortDateString() + " 00:00:00");
                }
                if (Seach.LiveEndDateE.HasValue)
                {
                    StrSql.AppendFormat(" AND LiveEndDate<='{0}' ", Seach.LiveEndDateE.Value.ToShortDateString() + " 23:59:59");
                }
                if (Seach.TreateTimeS.HasValue)
                {
                    StrSql.AppendFormat(" AND TreateTime>='{0}' ", Seach.TreateTimeS.Value.ToShortDateString() + " 00:00:00");
                }
                if (Seach.TreateTimeE.HasValue)
                {
                    StrSql.AppendFormat(" AND TreateTime<='{0}' ", Seach.TreateTimeE.Value.ToShortDateString() + " 23:59:59");
                }
                if (Seach.TreatState.HasValue)
                {
                    StrSql.AppendFormat(" AND TreatState='{0}' ", (int)Seach.TreatState);
                }
            }
            StrSql.Append(" ORDER BY IssueTime DESC ");
            DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
            using (IDataReader dr = EyouSoft.Toolkit.DAL.DbHelper.ExecuteReader(dc, this._db))
            {
                ResultList = new List<MHotelTourCustoms>();
                while (dr.Read())
                {
                    MHotelTourCustoms model = new MHotelTourCustoms();
                    model.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                    model.UserID = dr.IsDBNull(dr.GetOrdinal("UserID")) ? "" : dr.GetString(dr.GetOrdinal("UserID"));
                    model.UserName = dr.IsDBNull(dr.GetOrdinal("UserName")) ? "" : dr.GetString(dr.GetOrdinal("UserName"));
                    model.ContacterName = dr.IsDBNull(dr.GetOrdinal("ContacterName")) ? "" : dr.GetString(dr.GetOrdinal("ContacterName"));
                    model.ContacterMobile = dr.IsDBNull(dr.GetOrdinal("ContacterMobile")) ? "" : dr.GetString(dr.GetOrdinal("ContacterMobile"));
                    model.ContacterTelephone = dr.IsDBNull(dr.GetOrdinal("ContacterTelephone")) ? "" : dr.GetString(dr.GetOrdinal("ContacterTelephone"));
                    model.HotelId = dr.IsDBNull(dr.GetOrdinal("HotelId")) ? "" : dr.GetString(dr.GetOrdinal("HotelId"));
                    model.HotelCode = dr.IsDBNull(dr.GetOrdinal("HotelCode")) ? "" : dr.GetString(dr.GetOrdinal("HotelCode"));
                    model.HotelName = dr.IsDBNull(dr.GetOrdinal("HotelName")) ? "" : dr.GetString(dr.GetOrdinal("HotelName"));
                    if (!dr.IsDBNull(dr.GetOrdinal("HotelStar")))
                    {
                        model.HotelStar = (EyouSoft.Model.Enum.HotelStar)dr.GetByte(dr.GetOrdinal("HotelStar"));
                    }
                    model.CityCode = dr.IsDBNull(dr.GetOrdinal("CityCode")) ? "" : dr.GetString(dr.GetOrdinal("CityCode"));
                    model.LocationAsk = dr.IsDBNull(dr.GetOrdinal("LocationAsk")) ? "" : dr.GetString(dr.GetOrdinal("LocationAsk"));
                    model.RoomAsk = dr.IsDBNull(dr.GetOrdinal("RoomAsk")) ? "" : dr.GetString(dr.GetOrdinal("RoomAsk"));
                    if (!dr.IsDBNull(dr.GetOrdinal("LiveStartDate")))
                    {
                        model.LiveStartDate = dr.GetDateTime(dr.GetOrdinal("LiveStartDate"));
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("LiveEndDate")))
                    {
                        model.LiveEndDate = dr.GetDateTime(dr.GetOrdinal("LiveEndDate"));
                    }
                    model.RoomCount = dr.IsDBNull(dr.GetOrdinal("RoomCount")) ? 0 : dr.GetInt32(dr.GetOrdinal("RoomCount"));
                    model.PeopleCount = dr.IsDBNull(dr.GetOrdinal("PeopleCount")) ? 0 : dr.GetInt32(dr.GetOrdinal("PeopleCount"));
                    model.BudgetMin = dr.IsDBNull(dr.GetOrdinal("BudgetMin")) ? 0 : dr.GetDecimal(dr.GetOrdinal("BudgetMin"));
                    model.BudgetMax = dr.IsDBNull(dr.GetOrdinal("BudgetMax")) ? 0 : dr.GetDecimal(dr.GetOrdinal("BudgetMax"));
                    if (!dr.IsDBNull(dr.GetOrdinal("Payment")))
                    {
                        model.Payment = (EyouSoft.Model.Enum.Payment)dr.GetByte(dr.GetOrdinal("Payment"));
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("GuestType")))
                    {
                        model.GuestType = (EyouSoft.Model.Enum.GuestType)dr.GetByte(dr.GetOrdinal("GuestType"));
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("TourType")))
                    {
                        model.TourType = (EyouSoft.Model.Enum.TourType)dr.GetByte(dr.GetOrdinal("TourType"));
                    }
                    model.OtherRemark = dr.IsDBNull(dr.GetOrdinal("OtherRemark")) ? "" : dr.GetString(dr.GetOrdinal("OtherRemark"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                    {
                        model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("TreatState")))
                    {
                        model.TreatState = (EyouSoft.Model.Enum.TreatState)dr.GetByte(dr.GetOrdinal("TreatState"));
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("TreateTime")))
                    {
                        model.TreateTime = dr.GetDateTime(dr.GetOrdinal("TreateTime"));
                    }
                    model.OperatorId = dr.IsDBNull(dr.GetOrdinal("OperatorId")) ? 0 : dr.GetInt32(dr.GetOrdinal("OperatorId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("Source")))
                    {
                        model.Source = (EyouSoft.Model.Enum.ScenicStructure.ScenicAreaOrderSource)dr.GetByte(dr.GetOrdinal("Source"));
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("AskListXML")))
                    {
                        model.AskList = GetAskList(dr.GetString(dr.GetOrdinal("AskListXML")));
                    }
                    ResultList.Add(model);
                    model = null;
                }

            }
            return ResultList;
        }

        /// <summary>
        /// 修改处理状态
        /// </summary>
        /// <param name="TreatState"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool UpdateTreatState(EyouSoft.Model.Enum.TreatState TreatState, params int[] Ids)
        {
            StringBuilder sId = new StringBuilder();
            for (int i = 0; i < Ids.Length; i++)
            {
                sId.AppendFormat("{0},", Ids[i]);
            }
            sId.Remove(sId.Length - 1, 1);
            string strSql = "UPDATE tbl_HotelTourCustoms SET TreatState=@TreatState Where Id in (" + sId + ")";
            DbCommand cmd = this._db.GetSqlStringCommand(strSql);
            this._db.AddInParameter(cmd, "TreatState", DbType.Byte, TreatState);
            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }

        #endregion

        #region  private xml
        /// <summary>
        /// 创建酒店系统订单旅客的Xml
        /// </summary>
        /// <param name="ThemeList"></param>
        /// <returns></returns>
        private string CreateAskListXML(IList<MHotelTourCustomsAsk> list)
        {
            if (list == null && list.Count == 0) return null;
            StringBuilder xmlDoc = new StringBuilder();
            xmlDoc.Append("<Root>");
            foreach (MHotelTourCustomsAsk model in list)
            {
                xmlDoc.Append("<HotelTourCustomsAsk ");
                xmlDoc.AppendFormat("AskName=\"{0}\" ", model.AskName);
                xmlDoc.AppendFormat("AskTime=\"{0}\" ", model.AskTime);
                xmlDoc.AppendFormat("AskContent=\"{0}\" ", model.AskContent);
                xmlDoc.Append(" />");
            }
            xmlDoc.Append("</Root>");
            return xmlDoc.ToString();
        }

        /// <summary>
        /// 生成附件集合List
        /// </summary>
        /// <param name="ComAttachXML">附件信息</param>
        /// <returns></returns>
        private IList<MHotelTourCustomsAsk> GetAskList(string AskListXML)
        {
            if (string.IsNullOrEmpty(AskListXML)) return null;
            IList<MHotelTourCustomsAsk> ResultList = new List<MHotelTourCustomsAsk>();
            XElement root = XElement.Parse(AskListXML);
            IEnumerable<XElement> xRow = root.Elements("row");
            foreach (XElement tmp1 in xRow)
            {
                MHotelTourCustomsAsk model = new MHotelTourCustomsAsk();
                model.ID = Utils.GetInt(tmp1.Attribute("ID").Value);
                model.TourOrderID = !string.IsNullOrEmpty(tmp1.Attribute("TourOrderID").Value) ? Utils.GetInt(tmp1.Attribute("TourOrderID").Value) : 0;
                model.AskName = !string.IsNullOrEmpty(tmp1.Attribute("AskName").Value) ? tmp1.Attribute("AskName").Value : "";
                if (!string.IsNullOrEmpty(tmp1.Attribute("AskTime").Value))
                {
                    model.AskTime = Utils.GetDateTime(tmp1.Attribute("AskTime").Value);
                }
                model.AskContent = !string.IsNullOrEmpty(tmp1.Attribute("AskContent").Value) ? tmp1.Attribute("AskContent").Value : "";
                ResultList.Add(model);
                model = null;
            }
            return ResultList;
        }

        #endregion
        #endregion

        #region 酒店团队订单回复
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        public bool AddAsk(MHotelTourCustomsAsk model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbl_HotelTourCustomsAsk(");
            strSql.Append("TourOrderID,AskName,AskTime,AskContent");
            strSql.Append(") values (");
            strSql.Append("@TourOrderID,@AskName,@AskTime,@AskContent");
            strSql.Append(") ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "TourOrderID", System.Data.DbType.Int32, model.TourOrderID);
            this._db.AddInParameter(cmd, "AskName", System.Data.DbType.String, model.AskName);
            this._db.AddInParameter(cmd, "AskTime", System.Data.DbType.DateTime, model.AskTime);
            this._db.AddInParameter(cmd, "AskContent", System.Data.DbType.String, model.AskContent);
            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateAsk(MHotelTourCustomsAsk model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbl_HotelTourCustomsAsk set ");
            strSql.Append(" TourOrderID = @TourOrderID , ");
            strSql.Append(" AskName = @AskName , ");
            strSql.Append(" AskTime = @AskTime ,  ");
            strSql.Append(" AskContent = @AskContent ");
            strSql.Append(" where ID=@ID  ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "TourOrderID", System.Data.DbType.Int32, model.TourOrderID);
            this._db.AddInParameter(cmd, "AskName", System.Data.DbType.String, model.AskName);
            this._db.AddInParameter(cmd, "AskTime", System.Data.DbType.DateTime, model.AskTime);
            this._db.AddInParameter(cmd, "AskContent", System.Data.DbType.String, model.AskContent);
            this._db.AddInParameter(cmd, "ID", System.Data.DbType.Int32, model.ID);

            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool DeleteAsk(params int[] Ids)
        {
            StringBuilder sId = new StringBuilder();
            for (int i = 0; i < Ids.Length; i++)
            {
                sId.AppendFormat("{0},", Ids[i]);
            }
            sId.Remove(sId.Length - 1, 1);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbl_HotelTourCustomsAsk where ID in (" + sId + ")");
            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            return DbHelper.ExecuteSql(dc, _db) > 0 ? true : false;
        }

        /// <summary>
        /// 根据团队定制编号删除
        /// </summary>
        /// <param name="TourOrderID"></param>
        /// <returns></returns>
        public bool DeleteAsk(int TourOrderID)
        {
            string strSql = "delete from tbl_HotelTourCustomsAsk where TourOrderID=" + TourOrderID + " ";
            DbCommand dc = _db.GetSqlStringCommand(strSql);
            return DbHelper.ExecuteSql(dc, _db) > 0 ? true : false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="LinkID"></param>
        /// <returns></returns>
        public MHotelTourCustomsAsk GetModelAsk(int ID)
        {
            MHotelTourCustomsAsk model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, TourOrderID, AskName, AskTime,AskContent  ");
            strSql.Append("  from tbl_HotelTourCustomsAsk ");
            strSql.Append(" where ID=@ID ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ID", System.Data.DbType.Int32, ID);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new MHotelTourCustomsAsk();
                    model.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    model.TourOrderID = !dr.IsDBNull(dr.GetOrdinal("TourOrderID")) ? dr.GetInt32(dr.GetOrdinal("TourOrderID")) : 0;
                    model.AskName = !dr.IsDBNull(dr.GetOrdinal("AskName")) ? dr.GetString(dr.GetOrdinal("AskName")) : "";
                    if(!dr.IsDBNull(dr.GetOrdinal("AskTime")))
                    {
                        model.AskTime = dr.GetDateTime(dr.GetOrdinal("AskTime"));
                    }
                    model.AskContent = !dr.IsDBNull(dr.GetOrdinal("AskContent")) ? dr.GetString(dr.GetOrdinal("AskContent")) : "";
                }
            }

            return model;
        }

        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="TourOrderID">团队定制编号</param>
        /// <returns></returns>
        public IList<MHotelTourCustomsAsk> GetListAsk(int PageSize, int PageIndex, ref int RecordCount, int TourOrderID)
        {
            IList<MHotelTourCustomsAsk> list = new List<MHotelTourCustomsAsk>();

            string tableName = "tbl_HotelTourCustomsAsk";
            string fileds = "ID, TourOrderID, AskName, AskTime,AskContent";
            string query = " 1=1 ";
            if (TourOrderID > 0)
            {
                query += string.Format(" AND TourOrderID={0} ", TourOrderID); ;
            }
            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query, "AskTime desc ", null))
            {
                while (dr.Read())
                {
                    MHotelTourCustomsAsk model = new MHotelTourCustomsAsk();
                    model.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    model.TourOrderID = !dr.IsDBNull(dr.GetOrdinal("TourOrderID")) ? dr.GetInt32(dr.GetOrdinal("TourOrderID")) : 0;
                    model.AskName = !dr.IsDBNull(dr.GetOrdinal("AskName")) ? dr.GetString(dr.GetOrdinal("AskName")) : "";
                    if (!dr.IsDBNull(dr.GetOrdinal("AskTime")))
                    {
                        model.AskTime = dr.GetDateTime(dr.GetOrdinal("AskTime"));
                    }
                    model.AskContent = !dr.IsDBNull(dr.GetOrdinal("AskContent")) ? dr.GetString(dr.GetOrdinal("AskContent")) : "";
                    list.Add(model);
                }
            }

            return list;

        }


        /// <summary>
        /// 获得前几行数据(top<=0取所有数据)
        /// </summary>
        /// <param name="TourOrderID">团队定制编号</param>
        public IList<MHotelTourCustomsAsk> GetListAsk(int Top, int TourOrderID)
        {
            IList<MHotelTourCustomsAsk> list = new List<MHotelTourCustomsAsk>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID, TourOrderID, AskName, AskTime,AskContent ");
            strSql.Append(" FROM tbl_HotelTourCustomsAsk ");
            if (TourOrderID > 0)
            {
                strSql.AppendFormat(" WHERE TourOrderID={0} ", TourOrderID); ;
            }
            strSql.Append(" Order By AskTime desc ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    MHotelTourCustomsAsk model = new MHotelTourCustomsAsk();
                    model.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    model.TourOrderID = !dr.IsDBNull(dr.GetOrdinal("TourOrderID")) ? dr.GetInt32(dr.GetOrdinal("TourOrderID")) : 0;
                    model.AskName = !dr.IsDBNull(dr.GetOrdinal("AskName")) ? dr.GetString(dr.GetOrdinal("AskName")) : "";
                    if (!dr.IsDBNull(dr.GetOrdinal("AskTime")))
                    {
                        model.AskTime = dr.GetDateTime(dr.GetOrdinal("AskTime"));
                    }
                    model.AskContent = !dr.IsDBNull(dr.GetOrdinal("AskContent")) ? dr.GetString(dr.GetOrdinal("AskContent")) : "";
                    list.Add(model);
                }
            }
            return list;
        }

        #endregion
    }
}
