using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.Enum.ScenicStructure;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.Toolkit.DAL;
using EyouSoft.Toolkit;
using EyouSoft.IDAL.ScenicStructure;
using EyouSoft.Model.ScenicStructure;
using Linq.DAL;
using EyouSoft.Model.ScenicStructure.WebModel;
namespace EyouSoft.DAL.ScenicStructure
{
   public class DScenicTickets : DALBase, IScenicTickets
   {
      #region 初始化db
      private Database _db = null;

      /// <summary>
      /// 初始化_db
      /// </summary>
      public DScenicTickets()
      {
         _db = base.SystemStore;
      }
      #endregion

      #region IScenicTickets 成员

      /// <summary>
      /// 验证门票名称是否存在
      /// </summary>
      /// <param name="typeName">门票名称</param>
      /// <param name="ticketId">要排除的门票Id</param>
      /// <param name="scenicId">景区编号</param>
      /// <returns></returns>
      public bool ExistsTypeName(string typeName, string ticketId, string scenicId)
      {
         if (string.IsNullOrEmpty(typeName)) return false;

         var strSql = new StringBuilder(" select count(*) from tbl_ScenicTickets where TypeName = @TypeName and ScenicId=@ScenicId");
         if (!string.IsNullOrEmpty(ticketId))
         {
            strSql.AppendFormat(" and TicketsId <> '{0}' ", Utils.ToSqlLike(ticketId));
         }

         DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
         _db.AddInParameter(dc, "TypeName", DbType.String, typeName);
         _db.AddInParameter(dc, "ScenicId", DbType.AnsiStringFixedLength, scenicId);

         object obj = DbHelper.GetSingle(dc, _db);

         if (obj == null) return false;

         return Utils.GetInt(obj.ToString()) > 0;
      }

      public int Add(EyouSoft.Model.ScenicStructure.MScenicTickets model)
      {
         StringBuilder strSql = new StringBuilder();
         strSql.Append("insert into tbl_ScenicTickets(");
         strSql.Append("[TicketsId],[ScenicId],[TypeName],[EnName],[RetailPrice],[WebsitePrices],[MarketPrice],[DistributionPrice],[Limit],[StartTime],[EndTime],[Description],[SaleDescription],[Status],[CustomOrder],[IssueTime],[OperatorId],[LastUpdateTime],[IsFenXiao],[Number]");
         strSql.Append(") values (");
         strSql.Append("@TicketsId,@ScenicId,@TypeName,@EnName,@RetailPrice,@WebsitePrices,@MarketPrice,@DistributionPrice,@Limit,@StartTime,@EndTime,@Description,@SaleDescription,@Status,@CustomOrder,@IssueTime,@OperatorId,@LastUpdateTime,@IsFenXiao,@Number");
         strSql.Append(") ");
         DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
         this._db.AddInParameter(cmd, "TicketsId", System.Data.DbType.AnsiStringFixedLength, model.TicketsId);
         this._db.AddInParameter(cmd, "ScenicId", System.Data.DbType.AnsiStringFixedLength, model.ScenicId);
         this._db.AddInParameter(cmd, "TypeName", System.Data.DbType.String, model.TypeName);
         this._db.AddInParameter(cmd, "EnName", System.Data.DbType.AnsiString, model.EnName);
         this._db.AddInParameter(cmd, "RetailPrice", System.Data.DbType.Currency, model.RetailPrice);
         this._db.AddInParameter(cmd, "WebsitePrices", System.Data.DbType.Currency, model.WebsitePrices);
         this._db.AddInParameter(cmd, "MarketPrice", System.Data.DbType.Currency, 0);
         this._db.AddInParameter(cmd, "DistributionPrice", System.Data.DbType.Currency, model.DistributionPrice);
         this._db.AddInParameter(cmd, "Limit", System.Data.DbType.Int32, model.Limit);
         this._db.AddInParameter(cmd, "StartTime", System.Data.DbType.DateTime, model.StartTime);
         this._db.AddInParameter(cmd, "EndTime", System.Data.DbType.DateTime, model.EndTime);
         this._db.AddInParameter(cmd, "Description", System.Data.DbType.String, model.Description);
         this._db.AddInParameter(cmd, "SaleDescription", System.Data.DbType.String, model.SaleDescription);
         this._db.AddInParameter(cmd, "Status", System.Data.DbType.Byte, model.Status);
         this._db.AddInParameter(cmd, "CustomOrder", System.Data.DbType.Int32, model.CustomOrder);
         this._db.AddInParameter(cmd, "IssueTime", System.Data.DbType.DateTime, model.IssueTime);
         this._db.AddInParameter(cmd, "OperatorId", System.Data.DbType.AnsiStringFixedLength, model.OperatorId);
         this._db.AddInParameter(cmd, "LastUpdateTime", System.Data.DbType.DateTime, model.LastUpdateTime);
         this._db.AddInParameter(cmd, "IsFenXiao", System.Data.DbType.AnsiStringFixedLength, model.IsFenXiao ? "1" : "0");
         this._db.AddInParameter(cmd, "Number", System.Data.DbType.Int32, model.Number);
         return DbHelper.ExecuteSql(cmd, this._db);
      }

      public int Update(EyouSoft.Model.ScenicStructure.MScenicTickets model)
      {
         StringBuilder strSql = new StringBuilder();
         strSql.Append("update tbl_ScenicTickets set ");
         strSql.Append(" ScenicId = @ScenicId , ");
         strSql.Append(" TypeName = @TypeName , ");
         strSql.Append(" EnName = @EnName , ");
         strSql.Append(" RetailPrice = @RetailPrice , ");
         strSql.Append(" WebsitePrices = @WebsitePrices , ");
         strSql.Append(" MarketPrice = @MarketPrice , ");
         strSql.Append(" DistributionPrice = @DistributionPrice , ");
         strSql.Append(" Limit = @Limit , ");
         strSql.Append(" StartTime = @StartTime , ");
         strSql.Append(" EndTime = @EndTime , ");
         strSql.Append(" Description = @Description , ");
         strSql.Append(" SaleDescription = @SaleDescription , ");
         strSql.Append(" Status = @Status , ");
         strSql.Append(" CustomOrder = @CustomOrder , ");
         strSql.Append(" OperatorId = @OperatorId , ");
         strSql.Append(" LastUpdateTime = @LastUpdateTime ");
         strSql.Append(" ,IsFenXiao = @IsFenXiao ");
         strSql.Append(" ,Number = @Number ");
         strSql.Append(" where TicketsId=@TicketsId  ");
         DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
         this._db.AddInParameter(cmd, "TicketsId", System.Data.DbType.AnsiStringFixedLength, model.TicketsId);
         this._db.AddInParameter(cmd, "ScenicId", System.Data.DbType.AnsiStringFixedLength, model.ScenicId);
         this._db.AddInParameter(cmd, "TypeName", System.Data.DbType.String, model.TypeName);
         this._db.AddInParameter(cmd, "EnName", System.Data.DbType.AnsiString, model.EnName);
         this._db.AddInParameter(cmd, "RetailPrice", System.Data.DbType.Currency, model.RetailPrice);
         this._db.AddInParameter(cmd, "WebsitePrices", System.Data.DbType.Currency, model.WebsitePrices);
         this._db.AddInParameter(cmd, "MarketPrice", System.Data.DbType.Currency, model.MarketPrice);
         this._db.AddInParameter(cmd, "DistributionPrice", System.Data.DbType.Currency, model.DistributionPrice);
         this._db.AddInParameter(cmd, "Limit", System.Data.DbType.Int32, model.Limit);
         this._db.AddInParameter(cmd, "StartTime", System.Data.DbType.DateTime, model.StartTime);
         this._db.AddInParameter(cmd, "EndTime", System.Data.DbType.DateTime, model.EndTime);
         this._db.AddInParameter(cmd, "Description", System.Data.DbType.String, model.Description);
         this._db.AddInParameter(cmd, "SaleDescription", System.Data.DbType.String, model.SaleDescription);
         this._db.AddInParameter(cmd, "Status", System.Data.DbType.Byte, model.Status);
         this._db.AddInParameter(cmd, "CustomOrder", System.Data.DbType.Int32, model.CustomOrder);
         this._db.AddInParameter(cmd, "OperatorId", System.Data.DbType.AnsiStringFixedLength, model.OperatorId);
         this._db.AddInParameter(cmd, "LastUpdateTime", System.Data.DbType.DateTime, model.LastUpdateTime);
         this._db.AddInParameter(cmd, "IsFenXiao", System.Data.DbType.AnsiStringFixedLength, model.IsFenXiao ? "1" : "0");
         this._db.AddInParameter(cmd, "Number", System.Data.DbType.Int32, model.Number);
         return DbHelper.ExecuteSql(cmd, this._db);
      }

      ///// <summary>
      ///// 删除数据
      ///// </summary>
      ///// <param name="TicketsIds"></param>
      ///// <returns></returns>
      //public bool Delete(params string[] TicketsIds)
      //{
      //    StringBuilder sId = new StringBuilder();
      //    for (int i = 0; i < TicketsIds.Length; i++)
      //    {
      //        sId.AppendFormat("'{0}',", TicketsIds[i]);
      //    }
      //    sId.Remove(sId.Length - 1, 1);
      //    StringBuilder strSql = new StringBuilder();
      //    strSql.Append("delete from tbl_ScenicTickets where TicketsId in (" + sId + ") AND NOT EXISTS(SELECT 1 FROM tbl_ScenicAreaOrder WHERE [TicketsId] IN (" + sId + "))");
      //    DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
      //    return DbHelper.ExecuteSql(dc, _db) > 0 ? true : false;
      //}

      public int DeleteMenPiao(string menPiaoId)
      {
         string sql = "DECLARE @RetCode INT;";
         sql += "IF EXISTS(SELECT 1 FROM tbl_ScenicAreaOrder WHERE TicketsId=@MenPiaoId) BEGIN; SET @RetCode=-99; END;";
         sql += "ELSE BEGIN; delete from tbl_ScenicTickets where TicketsId=@MenPiaoId;SET @RetCode=1 END;";
         sql += "SELECT @RetCode";

         DbCommand cmd = _db.GetSqlStringCommand(sql);
         _db.AddInParameter(cmd, "MenPiaoId", DbType.AnsiStringFixedLength, menPiaoId);

         using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
         {
            if (rdr.Read()) return rdr.GetInt32(0);
         }

         return -100;
      }

      public EyouSoft.Model.ScenicStructure.MScenicTickets GetModel(string TicketsId)
      {
         EyouSoft.Model.ScenicStructure.MScenicTickets model = null;

         StringBuilder strSql = new StringBuilder();
         strSql.Append("select [TicketsId],[ScenicId],[TypeName],[EnName],[RetailPrice],[WebsitePrices],[MarketPrice],[DistributionPrice],[Limit],[StartTime],[EndTime],[Description],[SaleDescription],[Status],[CustomOrder],[IssueTime],[OperatorId],[LastUpdateTime],[IsFenXiao],[Number]  ");
         strSql.Append(",(select top 1 ScenicName from tbl_ScenicArea where ScenicId=tbl_ScenicTickets.ScenicId) as ScenicName ");
         strSql.Append("  from tbl_ScenicTickets ");
         strSql.Append(" where TicketsId=@TicketsId ");
         DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
         this._db.AddInParameter(cmd, "TicketsId", System.Data.DbType.AnsiStringFixedLength, TicketsId);

         using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
         {
            while (dr.Read())
            {
               model = new EyouSoft.Model.ScenicStructure.MScenicTickets();
               model.TicketsId = !dr.IsDBNull(dr.GetOrdinal("TicketsId")) ? dr.GetString(dr.GetOrdinal("TicketsId")) : "";
               model.ScenicId = !dr.IsDBNull(dr.GetOrdinal("ScenicId")) ? dr.GetString(dr.GetOrdinal("ScenicId")) : "";
               model.TypeName = !dr.IsDBNull(dr.GetOrdinal("TypeName")) ? dr.GetString(dr.GetOrdinal("TypeName")) : "";
               model.EnName = !dr.IsDBNull(dr.GetOrdinal("EnName")) ? dr.GetString(dr.GetOrdinal("EnName")) : "";
               model.RetailPrice = !dr.IsDBNull(dr.GetOrdinal("RetailPrice")) ? dr.GetDecimal(dr.GetOrdinal("RetailPrice")) : 0;
               model.WebsitePrices = !dr.IsDBNull(dr.GetOrdinal("WebsitePrices")) ? dr.GetDecimal(dr.GetOrdinal("WebsitePrices")) : 0;
               model.MarketPrice = !dr.IsDBNull(dr.GetOrdinal("MarketPrice")) ? dr.GetDecimal(dr.GetOrdinal("MarketPrice")) : 0;
               model.DistributionPrice = !dr.IsDBNull(dr.GetOrdinal("DistributionPrice")) ? dr.GetDecimal(dr.GetOrdinal("DistributionPrice")) : 0;
               model.Limit = !dr.IsDBNull(dr.GetOrdinal("Limit")) ? dr.GetInt32(dr.GetOrdinal("Limit")) : 0;
               model.Number = !dr.IsDBNull(dr.GetOrdinal("Number")) ? dr.GetInt32(dr.GetOrdinal("Number")) : 0;
               if (!dr.IsDBNull(dr.GetOrdinal("StartTime")))
               {
                  model.StartTime = dr.GetDateTime(dr.GetOrdinal("StartTime"));
               }
               if (!dr.IsDBNull(dr.GetOrdinal("EndTime")))
               {
                  model.EndTime = dr.GetDateTime(dr.GetOrdinal("EndTime"));
               }
               model.Description = !dr.IsDBNull(dr.GetOrdinal("Description")) ? dr.GetString(dr.GetOrdinal("Description")) : "";
               model.SaleDescription = !dr.IsDBNull(dr.GetOrdinal("SaleDescription")) ? dr.GetString(dr.GetOrdinal("SaleDescription")) : "";
               if (!dr.IsDBNull(dr.GetOrdinal("Status")))
               {
                  model.Status = (Model.Enum.ScenicStructure.ScenicTicketsStatus)dr.GetByte(dr.GetOrdinal("Status"));
               }
               model.CustomOrder = !dr.IsDBNull(dr.GetOrdinal("CustomOrder")) ? dr.GetInt32(dr.GetOrdinal("CustomOrder")) : 0;
               model.LastUpdateTime = dr.GetDateTime(dr.GetOrdinal("LastUpdateTime"));
               model.OperatorId = !dr.IsDBNull(dr.GetOrdinal("OperatorId")) ? dr.GetString(dr.GetOrdinal("OperatorId")) : "";
               model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
               model.ScenicName = !dr.IsDBNull(dr.GetOrdinal("ScenicName")) ? dr.GetString(dr.GetOrdinal("ScenicName")) : "";
               model.IsFenXiao = dr["IsFenXiao"].ToString() == "1";
            }
         }

         return model;
      }

      public IList<MScenicTickets> GetList(int PageSize, int PageIndex, ref int RecordCount,MScenicTicketsSearchModel Search)
      {
         IList<EyouSoft.Model.ScenicStructure.MScenicTickets> list = new List<EyouSoft.Model.ScenicStructure.MScenicTickets>();

         string tableName = "tbl_ScenicTickets";
         string fileds = "[TicketsId],[ScenicId],[TypeName],[EnName],[RetailPrice],[WebsitePrices],[MarketPrice],[DistributionPrice],[Limit],[StartTime],[EndTime],[Description],[SaleDescription],[Status],[CustomOrder],[IssueTime],[OperatorId],[LastUpdateTime],[Number],[InterafaceTicketId],[InterafaceScenicId]";
         fileds += ",(select top 1 ScenicName from tbl_ScenicArea where ScenicId=tbl_ScenicTickets.ScenicId) as ScenicName ";
         string query = " 1=1 ";
         if (Search != null)
         {
            if (!string.IsNullOrEmpty(Search.ScenicId))
            {
               query = query + string.Format(" AND ScenicId = '{0}' ", Search.ScenicId);
            }
            if (!string.IsNullOrEmpty(Search.TypeName))
            {
               query = query + string.Format(" AND TypeName like '%{0}%' ", Search.TypeName);
            }
            if (!string.IsNullOrEmpty(Search.EnName))
            {
               query = query + string.Format(" AND EnName like '%{0}%' ", Search.EnName);
            }
            if (Search.StartTimeS != null)
            {
               query = query + string.Format(" AND StartTime>='{0}' ", Search.StartTimeS.Value.ToShortDateString() + " 00:00:00");
            }
            if (Search.StartTimeE != null)
            {
               query = query + string.Format(" AND StartTime<='{0}' ", Search.StartTimeE.Value.ToShortDateString() + " 23:59:59");
            }
            if (Search.EndTimeS != null)
            {
               query = query + string.Format(" AND EndTime>='{0}' ", Search.EndTimeS.Value.ToShortDateString() + " 00:00:00");
            }
            if (Search.EndTimeE != null)
            {
               query = query + string.Format(" AND EndTime<='{0}' ", Search.EndTimeE.Value.ToShortDateString() + " 23:59:59");
            }
            if (Search.LastUpdateTimeS != null)
            {
               query = query + string.Format(" AND LastUpdateTime>='{0}' ", Search.LastUpdateTimeS.Value.ToShortDateString() + " 00:00:00");
            }
            if (Search.LastUpdateTimeE != null)
            {
               query = query + string.Format(" AND LastUpdateTime<='{0}' ", Search.LastUpdateTimeE.Value.ToShortDateString() + " 23:59:59");
            }
            if (Search.Status.HasValue)
            {
               query = query + string.Format(" AND Status ={0} ", (int)Search.Status);
            }
            if (!string.IsNullOrEmpty(Search.ScenicName))
            {
               query = query + string.Format(" AND exists(select 1 from tbl_ScenicArea where ScenicId=tbl_ScenicTickets.ScenicId and ScenicName like '%{0}%') ", Search.ScenicName);
            }
         }

         using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query, "IssueTime desc ", null))
         {
            while (dr.Read())
            {
               EyouSoft.Model.ScenicStructure.MScenicTickets model = new EyouSoft.Model.ScenicStructure.MScenicTickets();
               model.TicketsId = !dr.IsDBNull(dr.GetOrdinal("TicketsId")) ? dr.GetString(dr.GetOrdinal("TicketsId")) : "";
               model.ScenicId = !dr.IsDBNull(dr.GetOrdinal("ScenicId")) ? dr.GetString(dr.GetOrdinal("ScenicId")) : "";
               model.TypeName = !dr.IsDBNull(dr.GetOrdinal("TypeName")) ? dr.GetString(dr.GetOrdinal("TypeName")) : "";
               model.EnName = !dr.IsDBNull(dr.GetOrdinal("EnName")) ? dr.GetString(dr.GetOrdinal("EnName")) : "";
               model.RetailPrice = !dr.IsDBNull(dr.GetOrdinal("RetailPrice")) ? dr.GetDecimal(dr.GetOrdinal("RetailPrice")) : 0;
               model.WebsitePrices = !dr.IsDBNull(dr.GetOrdinal("WebsitePrices")) ? dr.GetDecimal(dr.GetOrdinal("WebsitePrices")) : 0;
               model.MarketPrice = !dr.IsDBNull(dr.GetOrdinal("MarketPrice")) ? dr.GetDecimal(dr.GetOrdinal("MarketPrice")) : 0;
               model.DistributionPrice = !dr.IsDBNull(dr.GetOrdinal("DistributionPrice")) ? dr.GetDecimal(dr.GetOrdinal("DistributionPrice")) : 0;
               model.Limit = !dr.IsDBNull(dr.GetOrdinal("Limit")) ? dr.GetInt32(dr.GetOrdinal("Limit")) : 0;
               model.Number = !dr.IsDBNull(dr.GetOrdinal("Number")) ? dr.GetInt32(dr.GetOrdinal("Number")) : 0;
               if (!dr.IsDBNull(dr.GetOrdinal("StartTime")))
               {
                  model.StartTime = dr.GetDateTime(dr.GetOrdinal("StartTime"));
               }
               if (!dr.IsDBNull(dr.GetOrdinal("EndTime")))
               {
                  model.EndTime = dr.GetDateTime(dr.GetOrdinal("EndTime"));
               }
               model.Description = !dr.IsDBNull(dr.GetOrdinal("Description")) ? dr.GetString(dr.GetOrdinal("Description")) : "";
               model.SaleDescription = !dr.IsDBNull(dr.GetOrdinal("SaleDescription")) ? dr.GetString(dr.GetOrdinal("SaleDescription")) : "";
               if (!dr.IsDBNull(dr.GetOrdinal("Status")))
               {
                  model.Status = (Model.Enum.ScenicStructure.ScenicTicketsStatus)dr.GetByte(dr.GetOrdinal("Status"));
               }
               model.CustomOrder = !dr.IsDBNull(dr.GetOrdinal("CustomOrder")) ? dr.GetInt32(dr.GetOrdinal("CustomOrder")) : 0;
               model.LastUpdateTime = dr.GetDateTime(dr.GetOrdinal("LastUpdateTime"));
               model.OperatorId = !dr.IsDBNull(dr.GetOrdinal("OperatorId")) ? dr.GetString(dr.GetOrdinal("OperatorId")) : "";
               model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
               model.ScenicName = !dr.IsDBNull(dr.GetOrdinal("ScenicName")) ? dr.GetString(dr.GetOrdinal("ScenicName")) : "";

               model.InterafaceScenicId = !dr.IsDBNull(dr.GetOrdinal("InterafaceScenicId")) ? dr.GetString(dr.GetOrdinal("InterafaceScenicId")) : "";
               model.InterafaceTicketId = !dr.IsDBNull(dr.GetOrdinal("InterafaceTicketId")) ? dr.GetString(dr.GetOrdinal("InterafaceTicketId")) : "";
               list.Add(model);
               model = null;
            }
         }

         return list;
      }

      public IList<MScenicTickets> GetTopList(int Top,MScenicTicketsSearchModel Search)
      {
         IList<EyouSoft.Model.ScenicStructure.MScenicTickets> ResultList = null;
         string StrSql = string.Format("SELECT {0} [TicketsId],[ScenicId],[TypeName],[EnName],[RetailPrice],[WebsitePrices],[MarketPrice],[DistributionPrice],[Limit],[StartTime],[EndTime],[Description],[SaleDescription],[Status],[CustomOrder],[IssueTime],[OperatorId],[Number],[LastUpdateTime],(select top 1 ScenicName from tbl_ScenicArea where ScenicId=tbl_ScenicTickets.ScenicId) as ScenicName FROM tbl_ScenicTickets WHERE 1=1 ", (Top > 0 ? " TOP " + Top + " " : ""));
         if (Search != null)
         {
            if (!string.IsNullOrEmpty(Search.ScenicId))
            {
               StrSql = StrSql + string.Format(" AND ScenicId = '{0}' ", Search.ScenicId);
            }
            if (!string.IsNullOrEmpty(Search.TypeName))
            {
               StrSql = StrSql + string.Format(" AND TypeName like '%{0}%' ", Search.TypeName);
            }
            if (!string.IsNullOrEmpty(Search.EnName))
            {
               StrSql = StrSql + string.Format(" AND EnName like '%{0}%' ", Search.EnName);
            }
            if (Search.StartTimeS != null)
            {
               StrSql = StrSql + string.Format(" AND StartTime>='{0}' ", Search.StartTimeS.Value.ToShortDateString() + " 00:00:00");
            }
            if (Search.StartTimeE != null)
            {
               StrSql = StrSql + string.Format(" AND StartTime<='{0}' ", Search.StartTimeE.Value.ToShortDateString() + " 23:59:59");
            }
            if (Search.EndTimeS != null)
            {
               StrSql = StrSql + string.Format(" AND EndTime>='{0}' ", Search.EndTimeS.Value.ToShortDateString() + " 00:00:00");
            }
            if (Search.EndTimeE != null)
            {
               StrSql = StrSql + string.Format(" AND EndTime<='{0}' ", Search.EndTimeE.Value.ToShortDateString() + " 23:59:59");
            }
            if (Search.LastUpdateTimeS != null)
            {
               StrSql = StrSql + string.Format(" AND LastUpdateTime>='{0}' ", Search.LastUpdateTimeS.Value.ToShortDateString() + " 00:00:00");
            }
            if (Search.LastUpdateTimeE != null)
            {
               StrSql = StrSql + string.Format(" AND LastUpdateTime<='{0}' ", Search.LastUpdateTimeE.Value.ToShortDateString() + " 23:59:59");
            }
            if (Search.Status.HasValue)
            {
               StrSql = StrSql + string.Format(" AND Status ={0} ", (int)Search.Status);
            }
            if (!string.IsNullOrEmpty(Search.ScenicName))
            {
               StrSql = StrSql + string.Format(" AND exists(select 1 from tbl_ScenicArea where ScenicId=tbl_ScenicTickets.ScenicId and ScenicName like '%{0}%') ", Search.ScenicName);
            }
            if (Search.IsFenXiao.HasValue)
            {
               StrSql += string.Format(" AND IsFenXiao='{0}' ", Search.IsFenXiao.Value ? "1" : "0");
            }
         }
         StrSql = StrSql + " ORDER BY CustomOrder DESC,LastUpdateTime DESC";
         DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
         using (IDataReader dr = EyouSoft.Toolkit.DAL.DbHelper.ExecuteReader(dc, this._db))
         {
            ResultList = new List<EyouSoft.Model.ScenicStructure.MScenicTickets>();
            while (dr.Read())
            {
               EyouSoft.Model.ScenicStructure.MScenicTickets model = new EyouSoft.Model.ScenicStructure.MScenicTickets();

               model.TicketsId = !dr.IsDBNull(dr.GetOrdinal("TicketsId")) ? dr.GetString(dr.GetOrdinal("TicketsId")) : "";
               model.ScenicId = !dr.IsDBNull(dr.GetOrdinal("ScenicId")) ? dr.GetString(dr.GetOrdinal("ScenicId")) : "";
               model.TypeName = !dr.IsDBNull(dr.GetOrdinal("TypeName")) ? dr.GetString(dr.GetOrdinal("TypeName")) : "";
               model.EnName = !dr.IsDBNull(dr.GetOrdinal("EnName")) ? dr.GetString(dr.GetOrdinal("EnName")) : "";
               model.RetailPrice = !dr.IsDBNull(dr.GetOrdinal("RetailPrice")) ? dr.GetDecimal(dr.GetOrdinal("RetailPrice")) : 0;
               model.WebsitePrices = !dr.IsDBNull(dr.GetOrdinal("WebsitePrices")) ? dr.GetDecimal(dr.GetOrdinal("WebsitePrices")) : 0;
               model.MarketPrice = !dr.IsDBNull(dr.GetOrdinal("MarketPrice")) ? dr.GetDecimal(dr.GetOrdinal("MarketPrice")) : 0;
               model.DistributionPrice = !dr.IsDBNull(dr.GetOrdinal("DistributionPrice")) ? dr.GetDecimal(dr.GetOrdinal("DistributionPrice")) : 0;
               model.Limit = !dr.IsDBNull(dr.GetOrdinal("Limit")) ? dr.GetInt32(dr.GetOrdinal("Limit")) : 0;
               model.Number = !dr.IsDBNull(dr.GetOrdinal("Number")) ? dr.GetInt32(dr.GetOrdinal("Number")) : 0;
               if (!dr.IsDBNull(dr.GetOrdinal("StartTime")))
               {
                  model.StartTime = dr.GetDateTime(dr.GetOrdinal("StartTime"));
               }
               if (!dr.IsDBNull(dr.GetOrdinal("EndTime")))
               {
                  model.EndTime = dr.GetDateTime(dr.GetOrdinal("EndTime"));
               }
               model.Description = !dr.IsDBNull(dr.GetOrdinal("Description")) ? dr.GetString(dr.GetOrdinal("Description")) : "";
               model.SaleDescription = !dr.IsDBNull(dr.GetOrdinal("SaleDescription")) ? dr.GetString(dr.GetOrdinal("SaleDescription")) : "";
               if (!dr.IsDBNull(dr.GetOrdinal("Status")))
               {
                  model.Status = (Model.Enum.ScenicStructure.ScenicTicketsStatus)dr.GetByte(dr.GetOrdinal("Status"));
               }
               model.CustomOrder = !dr.IsDBNull(dr.GetOrdinal("CustomOrder")) ? dr.GetInt32(dr.GetOrdinal("CustomOrder")) : 0;
               model.LastUpdateTime = dr.GetDateTime(dr.GetOrdinal("LastUpdateTime"));
               model.OperatorId = !dr.IsDBNull(dr.GetOrdinal("OperatorId")) ? dr.GetString(dr.GetOrdinal("OperatorId")) : "";
               model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
               model.ScenicName = !dr.IsDBNull(dr.GetOrdinal("ScenicName")) ? dr.GetString(dr.GetOrdinal("ScenicName")) : "";

               ResultList.Add(model);
               model = null;
            }

         }
         return ResultList;
      }

      /// <summary>
      /// 修改状态（上架，下架）
      /// </summary>
      /// <param name="Status"></param>
      /// <param name="TicketsIds"></param>
      /// <returns></returns>
      public bool SetStatus(ScenicTicketsStatus Status, params string[] TicketsIds)
      {
         StringBuilder sId = new StringBuilder();
         for (int i = 0; i < TicketsIds.Length; i++)
         {
            sId.AppendFormat("'{0}',", TicketsIds[i]);
         }
         sId.Remove(sId.Length - 1, 1);
         string strSql = "UPDATE tbl_ScenicTickets SET Status=@Status Where TicketsId in (" + sId + ")";
         DbCommand cmd = this._db.GetSqlStringCommand(strSql);
         this._db.AddInParameter(cmd, "Status", DbType.Byte, (int)Status);
         return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
      }
      #endregion
   }
}
