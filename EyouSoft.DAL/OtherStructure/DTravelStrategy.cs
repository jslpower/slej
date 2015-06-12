using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit.DAL;
using EyouSoft.IDAL;
using System.Data.SqlClient;

namespace EyouSoft.DAL
{
    /// <summary>
    /// 旅游攻略
    /// </summary>
    public class DTravelStrategy : DALBase, ITravelStrategy
    {

        #region static constants
        //static constants
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DTravelStrategy()
        {
            _db = SystemStore;
        }
        #endregion

        #region ITravelStrategy 成员

        #region 旅游攻略
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EyouSoft.Model.MTravelStrategy model)
        {
            string StrSql = "INSERT INTO tbl_TravelStrategy(TravelID,ThemeID,TravelName,ImgPath,TravelDestination,TravelDate,TravelMoney";
            StrSql += ",TravelAdvice,TravelContent,IsFrontPage,IsHot,IssueTime,OperatorId,OperatorLeiXing,Click,SortRule,IsCheck)";
            StrSql += " VALUES(@TravelID,@ThemeID,@TravelName,@ImgPath,@TravelDestination,@TravelDate,@TravelMoney,@TravelAdvice,@TravelContent";
            StrSql += ",@IsFrontPage,@IsHot,@IssueTime,@OperatorId,@OperatorLeiXing,@Click,@SortRule,@IsCheck)";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            this._db.AddInParameter(dc, "TravelID", DbType.AnsiStringFixedLength, model.TravelID);
            this._db.AddInParameter(dc, "ThemeID", DbType.Int32, model.ThemeID);
            this._db.AddInParameter(dc, "TravelName", DbType.String, model.TravelName);
            this._db.AddInParameter(dc, "ImgPath", DbType.String, model.ImgPath);
            this._db.AddInParameter(dc, "TravelDestination", DbType.String, model.TravelDestination);
            this._db.AddInParameter(dc, "TravelDate", DbType.DateTime, model.TravelDate);
            this._db.AddInParameter(dc, "TravelMoney", DbType.Decimal, model.TravelMoney);
            this._db.AddInParameter(dc, "TravelAdvice", DbType.String, model.TravelAdvice);
            this._db.AddInParameter(dc, "TravelContent", DbType.String, model.TravelContent);
            this._db.AddInParameter(dc, "IsFrontPage", DbType.AnsiStringFixedLength, model.IsFrontPage.Value ? 1 : 0);
            this._db.AddInParameter(dc, "IsHot", DbType.AnsiStringFixedLength, model.IsHot.Value ? 1 : 0);
            this._db.AddInParameter(dc, "IssueTime", DbType.DateTime, model.IssueTime);
            this._db.AddInParameter(dc, "OperatorLeiXing", DbType.Byte, (int)model.OperatorLeiXing);
            this._db.AddInParameter(dc, "OperatorId", DbType.AnsiStringFixedLength, model.OperatorId);
            this._db.AddInParameter(dc, "IsCheck", DbType.AnsiStringFixedLength, model.IsCheck.Value ? 1 : 0);
            this._db.AddInParameter(dc, "Click", DbType.Int32, model.Click);
            this._db.AddInParameter(dc, "SortRule", DbType.Int32, model.SortRule);
            return DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EyouSoft.Model.MTravelStrategy model)
        {
            string StrSql = "UPDATE tbl_TravelStrategy SET ";
            StrSql += "ThemeID=@ThemeID,TravelName=@TravelName,ImgPath=@ImgPath,TravelDestination=@TravelDestination,TravelDate=@TravelDate,TravelMoney=@TravelMoney";
            StrSql += ",TravelAdvice=@TravelAdvice,TravelContent=@TravelContent,IsFrontPage=@IsFrontPage,IsHot=@IsHot,IssueTime=@IssueTime";
            StrSql += ",OperatorId=@OperatorId,OperatorLeiXing=@OperatorLeiXing,SortRule=@SortRule,IsCheck=@IsCheck ";
            StrSql += " WHERE TravelID=@TravelID";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            this._db.AddInParameter(dc, "TravelID", DbType.AnsiStringFixedLength, model.TravelID);
            this._db.AddInParameter(dc, "ThemeID", DbType.Int32, model.ThemeID);
            this._db.AddInParameter(dc, "TravelName", DbType.String, model.TravelName);
            this._db.AddInParameter(dc, "ImgPath", DbType.String, model.ImgPath);
            this._db.AddInParameter(dc, "TravelDestination", DbType.String, model.TravelDestination);
            this._db.AddInParameter(dc, "TravelDate", DbType.DateTime, model.TravelDate);
            this._db.AddInParameter(dc, "TravelMoney", DbType.Decimal, model.TravelMoney);
            this._db.AddInParameter(dc, "TravelAdvice", DbType.String, model.TravelAdvice);
            this._db.AddInParameter(dc, "TravelContent", DbType.String, model.TravelContent);
            this._db.AddInParameter(dc, "IsFrontPage", DbType.AnsiStringFixedLength, model.IsFrontPage.Value ? 1 : 0);
            this._db.AddInParameter(dc, "IsHot", DbType.AnsiStringFixedLength, model.IsHot.Value ? 1 : 0);
            this._db.AddInParameter(dc, "IssueTime", DbType.DateTime, model.IssueTime);
            this._db.AddInParameter(dc, "OperatorLeiXing", DbType.Byte, (int)model.OperatorLeiXing);
            this._db.AddInParameter(dc, "OperatorId", DbType.AnsiStringFixedLength, model.OperatorId);
            this._db.AddInParameter(dc, "IsCheck", DbType.AnsiStringFixedLength, model.IsCheck.Value ? 1 : 0);
            this._db.AddInParameter(dc, "SortRule", DbType.Int32, model.SortRule);
            return EyouSoft.Toolkit.DAL.DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public bool Delete(string ArticleID)
        {
            string StrSql = "DELETE FROM tbl_TravelStrategy WHERE TravelID=@TravelID";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            this._db.AddInParameter(dc, "TravelID", DbType.AnsiStringFixedLength, ArticleID);
            return EyouSoft.Toolkit.DAL.DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool Delete(params string[] Ids)
        {
            StringBuilder StrSql = new StringBuilder();
            foreach (var id in Ids)
            {
                if (!string.IsNullOrEmpty(id))
                {
                    StrSql.AppendFormat(" DELETE FROM tbl_TravelStrategy WHERE TravelID='{0}' ", id);
                }
            }

            DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
            return EyouSoft.Toolkit.DAL.DbHelper.ExecuteSqlTrans(dc, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EyouSoft.Model.MTravelStrategy GetModel(string TravelID)
        {
            EyouSoft.Model.MTravelStrategy model = null;
            string StrSql = "SELECT TravelID,ThemeID,(select top 1 ClassName from tbl_TravelStrategyTheme where ThemeID=tbl_TravelStrategy.ThemeID) as ClassName";
            StrSql += ",TravelName,ImgPath,TravelDestination,TravelDate,TravelMoney,TravelAdvice,TravelContent,IsFrontPage,IsHot,IssueTime,OperatorId,OperatorLeiXing,Click,SortRule,IsCheck";
            StrSql += ",(CASE WHEN OperatorLeiXing = 1 THEN (SELECT TOP 1 Username FROM tbl_Webmaster WHERE  Id = tbl_TravelStrategy.OperatorId) ";
            StrSql += "WHEN OperatorLeiXing = 0 THEN (SELECT TOP 1 Account FROM tbl_Member WHERE  MemberID = tbl_TravelStrategy.OperatorId) ELSE '' END) AS OperatorName ";
            StrSql += " FROM tbl_TravelStrategy WHERE TravelID=@TravelID";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
            this._db.AddInParameter(dc, "TravelID", DbType.AnsiStringFixedLength, TravelID);
            using (IDataReader dr = EyouSoft.Toolkit.DAL.DbHelper.ExecuteReader(dc, this._db))
            {
                if (dr.Read())
                {
                    model = new EyouSoft.Model.MTravelStrategy();

                    model.TravelID = dr.GetString(dr.GetOrdinal("TravelID"));
                    model.ThemeID = dr.IsDBNull(dr.GetOrdinal("ThemeID")) ? 0 : dr.GetInt32(dr.GetOrdinal("ThemeID"));
                    model.ClassName = dr.IsDBNull(dr.GetOrdinal("ClassName")) ? "" : dr.GetString(dr.GetOrdinal("ClassName"));
                    model.TravelName = dr.IsDBNull(dr.GetOrdinal("TravelName")) ? "" : dr.GetString(dr.GetOrdinal("TravelName"));
                    model.ImgPath = dr.IsDBNull(dr.GetOrdinal("ImgPath")) ? "" : dr.GetString(dr.GetOrdinal("ImgPath"));
                    model.TravelDestination = dr.IsDBNull(dr.GetOrdinal("TravelDestination")) ? "" : dr.GetString(dr.GetOrdinal("TravelDestination"));
                    if (!dr.IsDBNull(dr.GetOrdinal("TravelDate")))
                    {
                        model.TravelDate = dr.GetDateTime(dr.GetOrdinal("TravelDate"));
                    }
                    model.TravelMoney = dr.IsDBNull(dr.GetOrdinal("TravelMoney")) ? 0 : dr.GetDecimal(dr.GetOrdinal("TravelMoney"));
                    model.TravelAdvice = dr.IsDBNull(dr.GetOrdinal("TravelAdvice")) ? "" : dr.GetString(dr.GetOrdinal("TravelAdvice"));
                    model.TravelContent = dr.IsDBNull(dr.GetOrdinal("TravelContent")) ? "" : dr.GetString(dr.GetOrdinal("TravelContent"));
                    model.IsFrontPage = dr.GetString(dr.GetOrdinal("IsFrontPage")) == "1" ? true : false;
                    model.IsHot = dr.GetString(dr.GetOrdinal("IsHot")) == "1" ? true : false;
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.OperatorId = dr.IsDBNull(dr.GetOrdinal("OperatorId")) ? "" : dr.GetString(dr.GetOrdinal("OperatorId"));
                    model.OperatorName = dr.IsDBNull(dr.GetOrdinal("OperatorName")) ? "" : dr.GetString(dr.GetOrdinal("OperatorName"));
                    model.OperatorLeiXing = (EyouSoft.Model.Enum.OperatorLeiXing)dr.GetInt32(dr.GetOrdinal("OperatorLeiXing"));
                    model.Click = dr.IsDBNull(dr.GetOrdinal("Click")) ? 0 : dr.GetInt32(dr.GetOrdinal("Click"));
                    model.SortRule = dr.IsDBNull(dr.GetOrdinal("SortRule")) ? 0 : dr.GetInt32(dr.GetOrdinal("SortRule"));
                    model.IsCheck = dr.GetString(dr.GetOrdinal("IsCheck")) == "1" ? true : false;
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
        /// <param name="chaXun"></param>
        /// <param name="filedOrder">排序</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.MTravelStrategy> GetList(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.MTravelStrategyCX chaXun, IList<EyouSoft.Model.TravelArticleOrderBy> FiledOrder)
        {
            IList<EyouSoft.Model.MTravelStrategy> ResultList = null;
            string tableName = "tbl_TravelStrategy";
            StringBuilder fields = new StringBuilder();
            fields.Append("TravelID,ThemeID,TravelName,ImgPath,TravelDestination,TravelDate,TravelMoney,TravelAdvice,TravelContent,IsFrontPage,IsHot,IssueTime,OperatorId,OperatorLeiXing,Click,SortRule,IsCheck");
            fields.Append(",(select top 1 ClassName from tbl_TravelStrategyTheme where ThemeID=tbl_TravelStrategy.ThemeID) as ClassName");
            fields.Append(",(CASE  WHEN OperatorLeiXing = 1 THEN (SELECT TOP 1 Username FROM tbl_Webmaster WHERE  Id = tbl_TravelStrategy.OperatorId) ");
            fields.Append("WHEN OperatorLeiXing = 0 THEN (SELECT TOP 1 Account FROM tbl_Member WHERE  MemberID = tbl_TravelStrategy.OperatorId) ELSE '' END) AS OperatorName ");
            string query = " 1=1 ";
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.TravelName))
                {
                    query = query + string.Format(" AND TravelName like '%{0}%'", chaXun.TravelName);
                }
                if (!string.IsNullOrEmpty(chaXun.TravelDestination))
                {
                    query = query + string.Format(" AND TravelDestination like '%{0}%'", chaXun.TravelDestination);
                }
                if (chaXun.ThemeID > 0)
                {
                    query = query + string.Format(" AND ThemeID={0}", chaXun.ThemeID);
                }
                if (chaXun.IsFrontPage.HasValue)
                {
                    query = query + string.Format(" AND IsFrontPage='{0}'", chaXun.IsFrontPage.Value ? 1 : 0);
                }
                if (chaXun.IsHot.HasValue)
                {
                    query = query + string.Format(" AND IsHot='{0}'", chaXun.IsHot.Value ? 1 : 0);
                }
                if (chaXun.IssueTimeBegin != null)
                {
                    query = query + string.Format(" AND IssueTime>='{0}' ", chaXun.IssueTimeBegin.Value.ToShortDateString() + " 00:00:00");
                }
                if (chaXun.IssueTimeEnd != null)
                {
                    query = query + string.Format(" AND IssueTime<='{0}' ", chaXun.IssueTimeEnd.Value.ToShortDateString() + " 23:59:59");
                }
                if (chaXun.TravelDateBegin != null)
                {
                    query = query + string.Format(" AND TravelDate>='{0}' ", chaXun.TravelDateBegin.Value.ToShortDateString() + " 00:00:00");
                }
                if (chaXun.TravelDateEnd != null)
                {
                    query = query + string.Format(" AND TravelDate<='{0}' ", chaXun.TravelDateEnd.Value.ToShortDateString() + " 23:59:59");
                }
                if (!string.IsNullOrEmpty(chaXun.OperatorId))
                {
                    query = query + string.Format(" AND OperatorId='{0}'", chaXun.OperatorId);
                }
                if (chaXun.IsCheck.HasValue)
                {
                    query = query + string.Format(" AND IsCheck='{0}'", chaXun.IsCheck.Value ? 1 : 0);
                }
                if (chaXun.OperatorLeiXing.HasValue)
                {
                    query = query + string.Format(" AND OperatorLeiXing={0}", (int)chaXun.OperatorLeiXing);
                }
            }
            string orderByString = "";
            if (FiledOrder != null && FiledOrder.Count > 0)
            {
                for (int i = 0; i < FiledOrder.Count; i++)
                {
                    orderByString += "," + FiledOrder[i].FiledOrder.ToString() + " " + FiledOrder[i].OrderBy.ToString();
                }
                orderByString = orderByString.Substring(1);
            }
            else
            {
                orderByString = "IsCheck ASC,SortRule DESC,IssueTime DESC";
            }
            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), query, orderByString, null))
            {
                ResultList = new List<EyouSoft.Model.MTravelStrategy>();
                while (dr.Read())
                {
                    EyouSoft.Model.MTravelStrategy model = new EyouSoft.Model.MTravelStrategy();
                    model.TravelID = dr.GetString(dr.GetOrdinal("TravelID"));
                    model.ThemeID = dr.IsDBNull(dr.GetOrdinal("ThemeID")) ? 0 : dr.GetInt32(dr.GetOrdinal("ThemeID"));
                    model.ClassName = dr.IsDBNull(dr.GetOrdinal("ClassName")) ? "" : dr.GetString(dr.GetOrdinal("ClassName"));
                    model.TravelName = dr.IsDBNull(dr.GetOrdinal("TravelName")) ? "" : dr.GetString(dr.GetOrdinal("TravelName"));
                    model.ImgPath = dr.IsDBNull(dr.GetOrdinal("ImgPath")) ? "" : dr.GetString(dr.GetOrdinal("ImgPath"));
                    model.TravelDestination = dr.IsDBNull(dr.GetOrdinal("TravelDestination")) ? "" : dr.GetString(dr.GetOrdinal("TravelDestination"));
                    if (!dr.IsDBNull(dr.GetOrdinal("TravelDate")))
                    {
                        model.TravelDate = dr.GetDateTime(dr.GetOrdinal("TravelDate"));
                    }
                    model.TravelMoney = dr.IsDBNull(dr.GetOrdinal("TravelMoney")) ? 0 : dr.GetDecimal(dr.GetOrdinal("TravelMoney"));
                    model.TravelAdvice = dr.IsDBNull(dr.GetOrdinal("TravelAdvice")) ? "" : dr.GetString(dr.GetOrdinal("TravelAdvice"));
                    model.TravelContent = dr.IsDBNull(dr.GetOrdinal("TravelContent")) ? "" : dr.GetString(dr.GetOrdinal("TravelContent"));
                    model.IsFrontPage = dr.GetString(dr.GetOrdinal("IsFrontPage")) == "1" ? true : false;
                    model.IsHot = dr.GetString(dr.GetOrdinal("IsHot")) == "1" ? true : false;
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.OperatorId = dr.IsDBNull(dr.GetOrdinal("OperatorId")) ? "" : dr.GetString(dr.GetOrdinal("OperatorId"));
                    model.OperatorName = dr.IsDBNull(dr.GetOrdinal("OperatorName")) ? "" : dr.GetString(dr.GetOrdinal("OperatorName"));
                    model.OperatorLeiXing = (EyouSoft.Model.Enum.OperatorLeiXing)dr.GetInt32(dr.GetOrdinal("OperatorLeiXing"));
                    model.Click = dr.IsDBNull(dr.GetOrdinal("Click")) ? 0 : dr.GetInt32(dr.GetOrdinal("Click"));
                    model.SortRule = dr.IsDBNull(dr.GetOrdinal("SortRule")) ? 0 : dr.GetInt32(dr.GetOrdinal("SortRule"));
                    model.IsCheck = dr.GetString(dr.GetOrdinal("IsCheck")) == "1" ? true : false;
                    ResultList.Add(model);
                    model = null;
                }
            };
            return ResultList;
        }

        /// <summary>
        /// 获得前几行数据集合
        /// </summary>
        /// <param name="Top">0:所有</param>
        /// <param name="chaXun"></param>
        /// <param name="filedOrder">排序</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.MTravelStrategy> GetTopList(int Top, EyouSoft.Model.MTravelStrategyCX chaXun, IList<EyouSoft.Model.TravelArticleOrderBy> FiledOrder)
        {
            IList<EyouSoft.Model.MTravelStrategy> ResultList = null;
            string StrSql = string.Format("SELECT {0} TravelID,ThemeID,(select top 1 ClassName from tbl_TravelStrategyTheme where ThemeID=tbl_TravelStrategy.ThemeID) as ClassName,TravelName,ImgPath,TravelDestination,TravelDate,TravelMoney,TravelAdvice,TravelContent,IsFrontPage,IsHot,IssueTime,OperatorId,OperatorLeiXing,Click,SortRule,IsCheck ", (Top > 0 ? " TOP " + Top + " " : ""));
            StrSql += string.Format(",(CASE  WHEN OperatorLeiXing = 1 THEN (SELECT TOP 1 Username FROM tbl_Webmaster WHERE  Id = tbl_TravelStrategy.OperatorId)");
            StrSql += string.Format(" WHEN OperatorLeiXing = 0 THEN (SELECT TOP 1 Account FROM tbl_Member WHERE  MemberID = tbl_TravelStrategy.OperatorId) ELSE '' END) AS OperatorName");
            StrSql += string.Format(" FROM tbl_TravelStrategy WHERE 1=1 ", (Top > 0 ? " TOP " + Top + " " : ""));
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.TravelName))
                {
                    StrSql = StrSql + string.Format(" AND TravelName like '%{0}%'", chaXun.TravelName);
                }
                if (!string.IsNullOrEmpty(chaXun.TravelDestination))
                {
                    StrSql = StrSql + string.Format(" AND TravelDestination like '%{0}%'", chaXun.TravelDestination);
                }
                if (chaXun.ThemeID > 0)
                {
                    StrSql = StrSql + string.Format(" AND ThemeID={0}", chaXun.ThemeID);
                }
                if (chaXun.IsFrontPage.HasValue)
                {
                    StrSql = StrSql + string.Format(" AND IsFrontPage='{0}'", chaXun.IsFrontPage.Value ? 1 : 0);
                }
                if (chaXun.IsHot.HasValue)
                {
                    StrSql = StrSql + string.Format(" AND IsHot='{0}'", chaXun.IsHot.Value ? 1 : 0);
                }
                if (chaXun.IsImg.HasValue)
                {
                    StrSql = StrSql + string.Format(" AND LEN(ImgPath){0}0 ", chaXun.IsImg.Value ? ">" : "=");
                }
                if (chaXun.IssueTimeBegin != null)
                {
                    StrSql = StrSql + string.Format(" AND IssueTime>='{0}' ", chaXun.IssueTimeBegin.Value.ToShortDateString() + " 00:00:00");
                }
                if (chaXun.IssueTimeEnd != null)
                {
                    StrSql = StrSql + string.Format(" AND IssueTime<='{0}' ", chaXun.IssueTimeEnd.Value.ToShortDateString() + " 23:59:59");
                }
                if (chaXun.TravelDateBegin != null)
                {
                    StrSql = StrSql + string.Format(" AND TravelDate>='{0}' ", chaXun.TravelDateBegin.Value.ToShortDateString() + " 00:00:00");
                }
                if (chaXun.TravelDateEnd != null)
                {
                    StrSql = StrSql + string.Format(" AND TravelDate<='{0}' ", chaXun.TravelDateEnd.Value.ToShortDateString() + " 23:59:59");
                }
                if (chaXun.OperatorLeiXing.HasValue)
                {
                    StrSql = StrSql + string.Format(" AND OperatorLeiXing={0}", (int)chaXun.OperatorLeiXing.Value);
                }
                if (!string.IsNullOrEmpty(chaXun.OperatorId))
                {
                    StrSql = StrSql + string.Format(" AND OperatorId='{0}'", chaXun.OperatorId);
                }
                if (chaXun.IsCheck.HasValue)
                {
                    StrSql = StrSql + string.Format(" AND IsCheck='{0}'", chaXun.IsCheck.Value ? 1 : 0);
                }
                if (chaXun.OperatorLeiXing.HasValue)
                {
                    StrSql = StrSql + string.Format(" AND OperatorLeiXing={0}", (int)chaXun.OperatorLeiXing);
                }
            }
            string orderByString = "";
            if (FiledOrder != null && FiledOrder.Count > 0)
            {
                for (int i = 0; i < FiledOrder.Count; i++)
                {
                    orderByString += "," + FiledOrder[i].FiledOrder.ToString() + " " + FiledOrder[i].OrderBy.ToString();
                }
                orderByString = orderByString.Substring(1);
            }
            else
            {
                orderByString = "IsCheck ASC,SortRule DESC,IssueTime DESC";
            }
            StrSql = StrSql + " ORDER BY " + orderByString;
            DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
            using (IDataReader dr = EyouSoft.Toolkit.DAL.DbHelper.ExecuteReader(dc, this._db))
            {
                ResultList = new List<EyouSoft.Model.MTravelStrategy>();
                while (dr.Read())
                {
                    EyouSoft.Model.MTravelStrategy model = new EyouSoft.Model.MTravelStrategy();

                    model.TravelID = dr.GetString(dr.GetOrdinal("TravelID"));
                    model.ThemeID = dr.IsDBNull(dr.GetOrdinal("ThemeID")) ? 0 : dr.GetInt32(dr.GetOrdinal("ThemeID"));
                    model.ClassName = dr.IsDBNull(dr.GetOrdinal("ClassName")) ? "" : dr.GetString(dr.GetOrdinal("ClassName"));
                    model.TravelName = dr.IsDBNull(dr.GetOrdinal("TravelName")) ? "" : dr.GetString(dr.GetOrdinal("TravelName"));
                    model.ImgPath = dr.IsDBNull(dr.GetOrdinal("ImgPath")) ? "" : dr.GetString(dr.GetOrdinal("ImgPath"));
                    model.TravelDestination = dr.IsDBNull(dr.GetOrdinal("TravelDestination")) ? "" : dr.GetString(dr.GetOrdinal("TravelDestination"));
                    if (!dr.IsDBNull(dr.GetOrdinal("TravelDate")))
                    {
                        model.TravelDate = dr.GetDateTime(dr.GetOrdinal("TravelDate"));
                    }
                    model.TravelMoney = dr.IsDBNull(dr.GetOrdinal("TravelMoney")) ? 0 : dr.GetDecimal(dr.GetOrdinal("TravelMoney"));
                    model.TravelAdvice = dr.IsDBNull(dr.GetOrdinal("TravelAdvice")) ? "" : dr.GetString(dr.GetOrdinal("TravelAdvice"));
                    model.TravelContent = dr.IsDBNull(dr.GetOrdinal("TravelContent")) ? "" : dr.GetString(dr.GetOrdinal("TravelContent"));
                    model.IsFrontPage = dr.GetString(dr.GetOrdinal("IsFrontPage")) == "1" ? true : false;
                    model.IsHot = dr.GetString(dr.GetOrdinal("IsHot")) == "1" ? true : false;
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.OperatorId = dr.IsDBNull(dr.GetOrdinal("OperatorId")) ? "" : dr.GetString(dr.GetOrdinal("OperatorId"));
                    model.OperatorName = dr.IsDBNull(dr.GetOrdinal("OperatorName")) ? "" : dr.GetString(dr.GetOrdinal("OperatorName"));
                    model.OperatorLeiXing = (EyouSoft.Model.Enum.OperatorLeiXing)dr.GetInt32(dr.GetOrdinal("OperatorLeiXing"));
                    model.Click = dr.IsDBNull(dr.GetOrdinal("Click")) ? 0 : dr.GetInt32(dr.GetOrdinal("Click"));
                    model.SortRule = dr.IsDBNull(dr.GetOrdinal("SortRule")) ? 0 : dr.GetInt32(dr.GetOrdinal("SortRule"));
                    model.IsCheck = dr.GetString(dr.GetOrdinal("IsCheck")) == "1" ? true : false;
                    ResultList.Add(model);
                    model = null;
                }

            }
            return ResultList;
        }
        #endregion

        /// <summary>
        /// 点击量+1
        /// </summary>
        /// <param name="Id"></param>
        public bool SetClick(string Id)
        {
            string strSql = "UPDATE tbl_TravelStrategy SET Click=Click+1 Where TravelID=@TravelID";
            DbCommand cmd = this._db.GetSqlStringCommand(strSql);
            this._db.AddInParameter(cmd, "ArticleID", DbType.AnsiStringFixedLength, Id);
            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="Id">编号</param>
        /// <param name="flag">状态</param>
        public bool SetCheck(bool flag, string Id)
        {
            string strSql = "UPDATE tbl_TravelStrategy SET IsCheck=@IsCheck Where TravelID=@TravelID";
            DbCommand cmd = this._db.GetSqlStringCommand(strSql);
            this._db.AddInParameter(cmd, "IsCheck", DbType.AnsiStringFixedLength, flag ? 1 : 0);
            this._db.AddInParameter(cmd, "TravelID", DbType.AnsiStringFixedLength, Id);
            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 批量审核
        /// </summary>
        /// <param name="flag">状态</param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool SetCheck(bool flag, params string[] Ids)
        {
            StringBuilder sId = new StringBuilder();
            for (int i = 0; i < Ids.Length; i++)
            {
                sId.AppendFormat("'{0}',", Ids[i]);
            }
            sId.Remove(sId.Length - 1, 1);
            string strSql = "UPDATE tbl_TravelStrategy SET IsCheck=@IsCheck Where TravelID in (" + sId + ")";
            DbCommand cmd = this._db.GetSqlStringCommand(strSql);
            this._db.AddInParameter(cmd, "IsCheck", DbType.AnsiStringFixedLength, flag ? 1 : 0);
            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }

        #endregion
    }
}
