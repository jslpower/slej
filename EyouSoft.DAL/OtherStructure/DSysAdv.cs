using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit.DAL;

namespace EyouSoft.DAL.OtherStructure
{
    public class DSysAdv : EyouSoft.Toolkit.DAL.DALBase, EyouSoft.IDAL.OtherStructure.ISysAdv
    {
        #region 初始化db
        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DSysAdv()
        {
            _db = base.SystemStore;
        }
        #endregion

        #region ISysAdv 成员
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(EyouSoft.Model.MSysAdv model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbl_SysAdv(");
            strSql.Append("AreaId,ImgPath,AdvLink,AdvTitle,Click,SortId,AgencyId");
            strSql.Append(") values (");
            strSql.Append("@AreaId,@ImgPath,@AdvLink,@AdvTitle,@Click,@SortId,@AgencyId");
            strSql.Append(") ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "AreaId", DbType.Int32, (int)model.AreaId);
            this._db.AddInParameter(cmd, "ImgPath", DbType.String, model.ImgPath);
            this._db.AddInParameter(cmd, "AdvLink", DbType.String, model.AdvLink);
            this._db.AddInParameter(cmd, "AdvTitle", DbType.String, model.AdvTitle);
            this._db.AddInParameter(cmd, "Click", DbType.Int32, model.Click);
            this._db.AddInParameter(cmd, "SortId", DbType.Int32, model.SortId);
            this._db.AddInParameter(cmd, "AgencyId", DbType.String, model.AgencyId);

            return DbHelper.ExecuteSql(cmd, this._db);

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(EyouSoft.Model.MSysAdv model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbl_SysAdv set ");

            strSql.Append(" AreaId = @AreaId , ");
            strSql.Append(" ImgPath = @ImgPath , ");
            strSql.Append(" AdvLink = @AdvLink , ");
            strSql.Append(" AdvTitle = @AdvTitle , ");
            strSql.Append(" Click = @Click , ");
            strSql.Append(" SortId = @SortId, ");
            strSql.Append(" AgencyId = @AgencyId ");
            strSql.Append(" where AdvID=@AdvID ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "AdvID", DbType.Int32, model.AdvID);
            this._db.AddInParameter(cmd, "AreaId", DbType.Int32, (int)model.AreaId);
            this._db.AddInParameter(cmd, "ImgPath", DbType.String, model.ImgPath);
            this._db.AddInParameter(cmd, "AdvLink", DbType.String, model.AdvLink);
            this._db.AddInParameter(cmd, "AdvTitle", DbType.String, model.AdvTitle);
            this._db.AddInParameter(cmd, "Click", DbType.Int32, model.Click);
            this._db.AddInParameter(cmd, "SortId", DbType.Int32, model.SortId);
            this._db.AddInParameter(cmd, "AgencyId", DbType.String, model.AgencyId);


            return DbHelper.ExecuteSql(cmd, this._db);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="AdvID"></param>
        /// <returns></returns>
        public int Delete(string AdvID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbl_SysAdv where ");
            if (AdvID.Contains(","))
            {
                strSql.AppendFormat(" AdvID in ({0}) ", AdvID);
            }
            else
            {
                strSql.AppendFormat(" AdvID ={0} ", AdvID.Trim());
            }
            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            return DbHelper.ExecuteSql(dc, _db) > 0 ? 1 : 0;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="AdvID"></param>
        /// <returns></returns>
        public EyouSoft.Model.MSysAdv GetModel(int AdvID)
        {
            EyouSoft.Model.MSysAdv model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AdvID, AreaId, ImgPath, AdvLink, AdvTitle, Click, SortId  ");
            strSql.Append("  from tbl_SysAdv ");
            strSql.Append(" where AdvID=@AdvID");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "AdvID", DbType.Int32, AdvID);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new EyouSoft.Model.MSysAdv();
                    model.AdvID = dr.GetInt32(dr.GetOrdinal("AdvID"));
                    model.AreaId = !dr.IsDBNull(dr.GetOrdinal("AreaId")) ? (EyouSoft.Model.Enum.AdvArea)dr.GetInt32(dr.GetOrdinal("AreaId")) : (EyouSoft.Model.Enum.AdvArea)0;
                    model.ImgPath = !dr.IsDBNull(dr.GetOrdinal("ImgPath")) ? dr.GetString(dr.GetOrdinal("ImgPath")) : null;
                    model.AdvLink = !dr.IsDBNull(dr.GetOrdinal("AdvLink")) ? dr.GetString(dr.GetOrdinal("AdvLink")) : null;
                    model.AdvTitle = !dr.IsDBNull(dr.GetOrdinal("AdvTitle")) ? dr.GetString(dr.GetOrdinal("AdvTitle")) : null;
                    model.Click = !dr.IsDBNull(dr.GetOrdinal("Click")) ? dr.GetInt32(dr.GetOrdinal("Click")) : 0;
                    model.SortId = !dr.IsDBNull(dr.GetOrdinal("SortId")) ? dr.GetInt32(dr.GetOrdinal("SortId")) : 0;

                }
            }
            return model;
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="Search"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.MSysAdv> GetList(EyouSoft.Model.MSearchSysAdv Search)
        {
            IList<EyouSoft.Model.MSysAdv> list = new List<EyouSoft.Model.MSysAdv>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM tbl_SysAdv Where  1=1 ");

            if (Search != null)
            {
                if (Search.AreaIds != null && Search.AreaIds.Any())
                {
                    strSql.AppendFormat(
                        " and AreaId in ({0}) ",
                        Toolkit.Utils.GetSqlIdStrByArray(Search.AreaIds.Select(t => (int)t).ToArray()));
                }
                if (!string.IsNullOrEmpty(Search.AdvTitle))
                {
                    strSql.AppendFormat(" and AdvTitle like '%{0}%' ", Search.AdvTitle);
                }
                if (!string.IsNullOrEmpty(Search.AgencyId))
                {
                    strSql.AppendFormat(" and AgencyId = '{0}' ", Search.AgencyId);
                }
            }

            strSql.Append(" Order by SortId desc,IssueTime desc ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.MSysAdv model = new EyouSoft.Model.MSysAdv();
                    model.AdvID = dr.GetInt32(dr.GetOrdinal("AdvID"));
                    model.AreaId = !dr.IsDBNull(dr.GetOrdinal("AreaId")) ? (EyouSoft.Model.Enum.AdvArea)dr.GetInt32(dr.GetOrdinal("AreaId")) : (EyouSoft.Model.Enum.AdvArea)0;
                    model.ImgPath = !dr.IsDBNull(dr.GetOrdinal("ImgPath")) ? dr.GetString(dr.GetOrdinal("ImgPath")) : null;
                    model.AdvLink = !dr.IsDBNull(dr.GetOrdinal("AdvLink")) ? dr.GetString(dr.GetOrdinal("AdvLink")) : null;
                    model.AdvTitle = !dr.IsDBNull(dr.GetOrdinal("AdvTitle")) ? dr.GetString(dr.GetOrdinal("AdvTitle")) : null;
                    model.Click = !dr.IsDBNull(dr.GetOrdinal("Click")) ? dr.GetInt32(dr.GetOrdinal("Click")) : 0;
                    model.SortId = !dr.IsDBNull(dr.GetOrdinal("SortId")) ? dr.GetInt32(dr.GetOrdinal("SortId")) : 0;
                    list.Add(model);
                }
            }

            return list;
        }
        /// <summary>
        /// 分页获取列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="Search"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.MSysAdv> GetList(int PageSize, int PageIndex, ref int RecordCount, EyouSoft.Model.MSearchSysAdv Search)
        {
            IList<EyouSoft.Model.MSysAdv> list = new List<EyouSoft.Model.MSysAdv>();

            string tableName = "tbl_SysAdv";
            string fileds = "AdvID, AreaId, ImgPath, AdvLink, AdvTitle, Click, SortId,AgencyId,(select WebSite from tbl_JA_Sellers where ID=tbl_SysAdv.AgencyId) AS WebSiteUrl";
            string orderByString = " SortId desc,IssueTime desc ";

            StringBuilder query = new StringBuilder();
            query.Append(" 1=1 ");
            if (Search != null)
            {
                if (Search.ZongFaBol)
                {
                    query.AppendFormat(
                                          " and (AgencyId='{0}' OR AgencyId='{1}' )", "", "-1");
                }
                if (Search.AreaIds != null && Search.AreaIds.Any())
                {
                    query.AppendFormat(
                        " and AreaId in ({0}) ",
                        Toolkit.Utils.GetSqlIdStrByArray(Search.AreaIds.Select(t => (int)t).ToArray()));
                }
                if (!string.IsNullOrEmpty(Search.AdvTitle))
                {
                    query.AppendFormat(" and AdvTitle like '%{0}%' ", Search.AdvTitle);
                }
                if (!string.IsNullOrEmpty(Search.AgencyId))
                {
                    query.AppendFormat(" and AgencyId = '{0}' ", Search.AgencyId);
                }
                if (!string.IsNullOrEmpty(Search.FaBuRen))
                {
                    query.AppendFormat(" and AgencyId in (select ID from tbl_JA_Sellers where CompanyJC LIKE '%{0}%' OR WebsiteName LIKE '%{0}%' OR ([CompanyJC]+[WebsiteName]) LIKE '%{0}%')", Search.FaBuRen);
                }
                if (!string.IsNullOrEmpty(Search.WebSiteName))
                {
                    query.AppendFormat(" and AgencyId in (select ID from tbl_JA_Sellers where WebsiteName LIKE '%{0}%')", Search.WebSiteName);
                }
            }

            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.MSysAdv model = new EyouSoft.Model.MSysAdv();
                    model.AdvID = dr.GetInt32(dr.GetOrdinal("AdvID"));
                    model.AreaId = !dr.IsDBNull(dr.GetOrdinal("AreaId")) ? (EyouSoft.Model.Enum.AdvArea)dr.GetInt32(dr.GetOrdinal("AreaId")) : (EyouSoft.Model.Enum.AdvArea)0;
                    model.ImgPath = !dr.IsDBNull(dr.GetOrdinal("ImgPath")) ? dr.GetString(dr.GetOrdinal("ImgPath")) : null;
                    model.AdvLink = !dr.IsDBNull(dr.GetOrdinal("AdvLink")) ? dr.GetString(dr.GetOrdinal("AdvLink")) : null;
                    model.AdvTitle = !dr.IsDBNull(dr.GetOrdinal("AdvTitle")) ? dr.GetString(dr.GetOrdinal("AdvTitle")) : null;
                    model.Click = !dr.IsDBNull(dr.GetOrdinal("Click")) ? dr.GetInt32(dr.GetOrdinal("Click")) : 0;
                    model.SortId = !dr.IsDBNull(dr.GetOrdinal("SortId")) ? dr.GetInt32(dr.GetOrdinal("SortId")) : 0;
                    model.AgencyId = !dr.IsDBNull(dr.GetOrdinal("AgencyId")) ? dr.GetString(dr.GetOrdinal("AgencyId")) : null;
                    model.WebSiteUrl = !dr.IsDBNull(dr.GetOrdinal("WebSiteUrl")) ? dr.GetString(dr.GetOrdinal("WebSiteUrl")) : null;
                    list.Add(model);
                }
            }

            return list;
        }

        /// <summary>
        /// 根据广告位置获取广告信息
        /// </summary>
        /// <param name="advArea">广告位置</param>
        /// <returns></returns>
        public Model.MSysAdv GetModel(Model.Enum.AdvArea advArea)
        {
            var strSql = new StringBuilder();
            strSql.AppendFormat(" select * FROM tbl_SysAdv Where AreaId = {0} ", (int)advArea);
            strSql.Append(" Order by SortId desc,IssueTime desc ");

            Model.MSysAdv model = null;
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new Model.MSysAdv
                        {
                            AdvID = dr.GetInt32(dr.GetOrdinal("AdvID")),
                            AreaId =
                                !dr.IsDBNull(dr.GetOrdinal("AreaId"))
                                    ? (Model.Enum.AdvArea)dr.GetInt32(dr.GetOrdinal("AreaId"))
                                    : 0,
                            ImgPath =
                                !dr.IsDBNull(dr.GetOrdinal("ImgPath")) ? dr.GetString(dr.GetOrdinal("ImgPath")) : null,
                            AdvLink =
                                !dr.IsDBNull(dr.GetOrdinal("AdvLink")) ? dr.GetString(dr.GetOrdinal("AdvLink")) : null,
                            AdvTitle =
                                !dr.IsDBNull(dr.GetOrdinal("AdvTitle")) ? dr.GetString(dr.GetOrdinal("AdvTitle")) : null,
                            Click = !dr.IsDBNull(dr.GetOrdinal("Click")) ? dr.GetInt32(dr.GetOrdinal("Click")) : 0,
                            SortId = !dr.IsDBNull(dr.GetOrdinal("SortId")) ? dr.GetInt32(dr.GetOrdinal("SortId")) : 0
                        };
                }
            }

            return model;
        }

        /// <summary>
        /// 根据广告位置获取广告信息
        /// </summary>
        /// <param name="top">广告数量</param>
        /// <param name="advArea">广告位置</param>
        /// <returns></returns>
        public IList<Model.MSysAdv> GetList(int top, Model.Enum.AdvArea advArea, string AgencyId)
        {
            var strSql = new StringBuilder();
            strSql.AppendFormat(
                " select {1} * FROM tbl_SysAdv Where AreaId = {0} ",
                (int)advArea,
                top > 0 ? string.Format(" top {0} ", top) : string.Empty);
            if (!string.IsNullOrEmpty(AgencyId))
            {
                strSql.Append(" and AgencyId='" + AgencyId + "'");
            }
            else
            {
                strSql.Append(" And LEN(AgencyId)<10 ");
            }
            strSql.Append(" Order by SortId asc,IssueTime desc ");

            IList<Model.MSysAdv> list = new List<Model.MSysAdv>();
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    var model = new Model.MSysAdv
                    {
                        AdvID = dr.GetInt32(dr.GetOrdinal("AdvID")),
                        AreaId =
                            !dr.IsDBNull(dr.GetOrdinal("AreaId"))
                                ? (Model.Enum.AdvArea)dr.GetInt32(dr.GetOrdinal("AreaId"))
                                : 0,
                        ImgPath =
                            !dr.IsDBNull(dr.GetOrdinal("ImgPath")) ? dr.GetString(dr.GetOrdinal("ImgPath")) : null,
                        AdvLink =
                            !dr.IsDBNull(dr.GetOrdinal("AdvLink")) ? dr.GetString(dr.GetOrdinal("AdvLink")) : null,
                        AdvTitle =
                            !dr.IsDBNull(dr.GetOrdinal("AdvTitle")) ? dr.GetString(dr.GetOrdinal("AdvTitle")) : null,
                        Click = !dr.IsDBNull(dr.GetOrdinal("Click")) ? dr.GetInt32(dr.GetOrdinal("Click")) : 0,
                        SortId = !dr.IsDBNull(dr.GetOrdinal("SortId")) ? dr.GetInt32(dr.GetOrdinal("SortId")) : 0
                    };

                    list.Add(model);
                }
            }

            return list;
        }

        /// <summary>
        /// 获取首页所有广告信息
        /// </summary>
        /// <returns></returns>
        public IList<Model.MSysAdv> GetHeadAdvList()
        {
            var strSql = new StringBuilder();

            //strSql.AppendFormat(
            //    " select top 5 * FROM tbl_SysAdv Where AreaId = {0} Order by SortId desc,IssueTime desc; ",
            //    (int)Model.Enum.AdvArea.首页五张轮换广告);
            //strSql.AppendFormat(
            //    " select top 1 * FROM tbl_SysAdv Where AreaId = {0} Order by SortId desc,IssueTime desc; ",
            //    (int)Model.Enum.AdvArea.首页热门线路通栏banner广告);
            //strSql.AppendFormat(
            //    " select top 1 * FROM tbl_SysAdv Where AreaId = {0} Order by SortId desc,IssueTime desc; ",
            //    (int)Model.Enum.AdvArea.首页线路通栏banner2广告);
            //strSql.AppendFormat(
            //    " select top 1 * FROM tbl_SysAdv Where AreaId = {0} Order by SortId desc,IssueTime desc; ",
            //    (int)Model.Enum.AdvArea.首页公告下方三张广告1);
            //strSql.AppendFormat(
            //    " select top 1 * FROM tbl_SysAdv Where AreaId = {0} Order by SortId desc,IssueTime desc; ",
            //    (int)Model.Enum.AdvArea.首页公告下方三张广告2);
            //strSql.AppendFormat(
            //    " select top 1 * FROM tbl_SysAdv Where AreaId = {0} Order by SortId desc,IssueTime desc; ",
            //    (int)Model.Enum.AdvArea.首页公告下方三张广告3);
            //strSql.AppendFormat(
            //    " select top 1 * FROM tbl_SysAdv Where AreaId = {0} Order by SortId desc,IssueTime desc; ",
            //    (int)Model.Enum.AdvArea.首页旅游点评广告);

            IList<Model.MSysAdv> list = new List<Model.MSysAdv>();
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    var model = new Model.MSysAdv
                    {
                        AdvID = dr.GetInt32(dr.GetOrdinal("AdvID")),
                        AreaId =
                            !dr.IsDBNull(dr.GetOrdinal("AreaId"))
                                ? (Model.Enum.AdvArea)dr.GetInt32(dr.GetOrdinal("AreaId"))
                                : 0,
                        ImgPath =
                            !dr.IsDBNull(dr.GetOrdinal("ImgPath")) ? dr.GetString(dr.GetOrdinal("ImgPath")) : null,
                        AdvLink =
                            !dr.IsDBNull(dr.GetOrdinal("AdvLink")) ? dr.GetString(dr.GetOrdinal("AdvLink")) : null,
                        AdvTitle =
                            !dr.IsDBNull(dr.GetOrdinal("AdvTitle")) ? dr.GetString(dr.GetOrdinal("AdvTitle")) : null,
                        Click = !dr.IsDBNull(dr.GetOrdinal("Click")) ? dr.GetInt32(dr.GetOrdinal("Click")) : 0,
                        SortId = !dr.IsDBNull(dr.GetOrdinal("SortId")) ? dr.GetInt32(dr.GetOrdinal("SortId")) : 0
                    };

                    list.Add(model);
                }

                dr.NextResult();
                while (dr.Read())
                {
                    var model = new Model.MSysAdv
                    {
                        AdvID = dr.GetInt32(dr.GetOrdinal("AdvID")),
                        AreaId =
                            !dr.IsDBNull(dr.GetOrdinal("AreaId"))
                                ? (Model.Enum.AdvArea)dr.GetInt32(dr.GetOrdinal("AreaId"))
                                : 0,
                        ImgPath =
                            !dr.IsDBNull(dr.GetOrdinal("ImgPath")) ? dr.GetString(dr.GetOrdinal("ImgPath")) : null,
                        AdvLink =
                            !dr.IsDBNull(dr.GetOrdinal("AdvLink")) ? dr.GetString(dr.GetOrdinal("AdvLink")) : null,
                        AdvTitle =
                            !dr.IsDBNull(dr.GetOrdinal("AdvTitle")) ? dr.GetString(dr.GetOrdinal("AdvTitle")) : null,
                        Click = !dr.IsDBNull(dr.GetOrdinal("Click")) ? dr.GetInt32(dr.GetOrdinal("Click")) : 0,
                        SortId = !dr.IsDBNull(dr.GetOrdinal("SortId")) ? dr.GetInt32(dr.GetOrdinal("SortId")) : 0
                    };

                    list.Add(model);
                }

                dr.NextResult();
                while (dr.Read())
                {
                    var model = new Model.MSysAdv
                    {
                        AdvID = dr.GetInt32(dr.GetOrdinal("AdvID")),
                        AreaId =
                            !dr.IsDBNull(dr.GetOrdinal("AreaId"))
                                ? (Model.Enum.AdvArea)dr.GetInt32(dr.GetOrdinal("AreaId"))
                                : 0,
                        ImgPath =
                            !dr.IsDBNull(dr.GetOrdinal("ImgPath")) ? dr.GetString(dr.GetOrdinal("ImgPath")) : null,
                        AdvLink =
                            !dr.IsDBNull(dr.GetOrdinal("AdvLink")) ? dr.GetString(dr.GetOrdinal("AdvLink")) : null,
                        AdvTitle =
                            !dr.IsDBNull(dr.GetOrdinal("AdvTitle")) ? dr.GetString(dr.GetOrdinal("AdvTitle")) : null,
                        Click = !dr.IsDBNull(dr.GetOrdinal("Click")) ? dr.GetInt32(dr.GetOrdinal("Click")) : 0,
                        SortId = !dr.IsDBNull(dr.GetOrdinal("SortId")) ? dr.GetInt32(dr.GetOrdinal("SortId")) : 0
                    };

                    list.Add(model);
                }

                dr.NextResult();
                while (dr.Read())
                {
                    var model = new Model.MSysAdv
                    {
                        AdvID = dr.GetInt32(dr.GetOrdinal("AdvID")),
                        AreaId =
                            !dr.IsDBNull(dr.GetOrdinal("AreaId"))
                                ? (Model.Enum.AdvArea)dr.GetInt32(dr.GetOrdinal("AreaId"))
                                : 0,
                        ImgPath =
                            !dr.IsDBNull(dr.GetOrdinal("ImgPath")) ? dr.GetString(dr.GetOrdinal("ImgPath")) : null,
                        AdvLink =
                            !dr.IsDBNull(dr.GetOrdinal("AdvLink")) ? dr.GetString(dr.GetOrdinal("AdvLink")) : null,
                        AdvTitle =
                            !dr.IsDBNull(dr.GetOrdinal("AdvTitle")) ? dr.GetString(dr.GetOrdinal("AdvTitle")) : null,
                        Click = !dr.IsDBNull(dr.GetOrdinal("Click")) ? dr.GetInt32(dr.GetOrdinal("Click")) : 0,
                        SortId = !dr.IsDBNull(dr.GetOrdinal("SortId")) ? dr.GetInt32(dr.GetOrdinal("SortId")) : 0
                    };

                    list.Add(model);
                }

                dr.NextResult();
                while (dr.Read())
                {
                    var model = new Model.MSysAdv
                    {
                        AdvID = dr.GetInt32(dr.GetOrdinal("AdvID")),
                        AreaId =
                            !dr.IsDBNull(dr.GetOrdinal("AreaId"))
                                ? (Model.Enum.AdvArea)dr.GetInt32(dr.GetOrdinal("AreaId"))
                                : 0,
                        ImgPath =
                            !dr.IsDBNull(dr.GetOrdinal("ImgPath")) ? dr.GetString(dr.GetOrdinal("ImgPath")) : null,
                        AdvLink =
                            !dr.IsDBNull(dr.GetOrdinal("AdvLink")) ? dr.GetString(dr.GetOrdinal("AdvLink")) : null,
                        AdvTitle =
                            !dr.IsDBNull(dr.GetOrdinal("AdvTitle")) ? dr.GetString(dr.GetOrdinal("AdvTitle")) : null,
                        Click = !dr.IsDBNull(dr.GetOrdinal("Click")) ? dr.GetInt32(dr.GetOrdinal("Click")) : 0,
                        SortId = !dr.IsDBNull(dr.GetOrdinal("SortId")) ? dr.GetInt32(dr.GetOrdinal("SortId")) : 0
                    };

                    list.Add(model);
                }

                dr.NextResult();
                while (dr.Read())
                {
                    var model = new Model.MSysAdv
                    {
                        AdvID = dr.GetInt32(dr.GetOrdinal("AdvID")),
                        AreaId =
                            !dr.IsDBNull(dr.GetOrdinal("AreaId"))
                                ? (Model.Enum.AdvArea)dr.GetInt32(dr.GetOrdinal("AreaId"))
                                : 0,
                        ImgPath =
                            !dr.IsDBNull(dr.GetOrdinal("ImgPath")) ? dr.GetString(dr.GetOrdinal("ImgPath")) : null,
                        AdvLink =
                            !dr.IsDBNull(dr.GetOrdinal("AdvLink")) ? dr.GetString(dr.GetOrdinal("AdvLink")) : null,
                        AdvTitle =
                            !dr.IsDBNull(dr.GetOrdinal("AdvTitle")) ? dr.GetString(dr.GetOrdinal("AdvTitle")) : null,
                        Click = !dr.IsDBNull(dr.GetOrdinal("Click")) ? dr.GetInt32(dr.GetOrdinal("Click")) : 0,
                        SortId = !dr.IsDBNull(dr.GetOrdinal("SortId")) ? dr.GetInt32(dr.GetOrdinal("SortId")) : 0
                    };

                    list.Add(model);
                }

                dr.NextResult();
                while (dr.Read())
                {
                    var model = new Model.MSysAdv
                    {
                        AdvID = dr.GetInt32(dr.GetOrdinal("AdvID")),
                        AreaId =
                            !dr.IsDBNull(dr.GetOrdinal("AreaId"))
                                ? (Model.Enum.AdvArea)dr.GetInt32(dr.GetOrdinal("AreaId"))
                                : 0,
                        ImgPath =
                            !dr.IsDBNull(dr.GetOrdinal("ImgPath")) ? dr.GetString(dr.GetOrdinal("ImgPath")) : null,
                        AdvLink =
                            !dr.IsDBNull(dr.GetOrdinal("AdvLink")) ? dr.GetString(dr.GetOrdinal("AdvLink")) : null,
                        AdvTitle =
                            !dr.IsDBNull(dr.GetOrdinal("AdvTitle")) ? dr.GetString(dr.GetOrdinal("AdvTitle")) : null,
                        Click = !dr.IsDBNull(dr.GetOrdinal("Click")) ? dr.GetInt32(dr.GetOrdinal("Click")) : 0,
                        SortId = !dr.IsDBNull(dr.GetOrdinal("SortId")) ? dr.GetInt32(dr.GetOrdinal("SortId")) : 0
                    };

                    list.Add(model);
                }
            }

            return list;
        }


        #endregion
    }
}
