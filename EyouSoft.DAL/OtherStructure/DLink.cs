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
    public class DLink : EyouSoft.Toolkit.DAL.DALBase, EyouSoft.IDAL.OtherStructure.ILink
    {
        #region 初始化db
        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DLink()
        {
            _db = base.SystemStore;
        }
        #endregion


        #region ILink 成员

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        public int Add(EyouSoft.Model.MLink model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbl_Link(");
            strSql.Append("LinkID,LinkText,ImgPath,LinkAddre,SortRule,IssueTime");
            strSql.Append(") values (");
            strSql.Append("@LinkID,@LInkText,@ImgPath,@LinkAddre,@SortRule,@IssueTime");
            strSql.Append(") ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "LinkID", System.Data.DbType.AnsiStringFixedLength, model.LinkID);
            this._db.AddInParameter(cmd, "LinkText", System.Data.DbType.String, model.LinkText);
            this._db.AddInParameter(cmd, "ImgPath", System.Data.DbType.String, model.ImgPath);
            this._db.AddInParameter(cmd, "LinkAddre", System.Data.DbType.String, model.LinkAddre);
            this._db.AddInParameter(cmd, "SortRule", System.Data.DbType.String, model.SortRule);
            this._db.AddInParameter(cmd, "IssueTime", System.Data.DbType.DateTime, model.IssueTime);
            return DbHelper.ExecuteSql(cmd, this._db);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(EyouSoft.Model.MLink model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbl_Link set ");
            strSql.Append(" LinkText = @LinkText , ");
            strSql.Append(" ImgPath = @ImgPath , ");
            strSql.Append(" LinkAddre = @LinkAddre ,  ");
            strSql.Append(" SortRule = @SortRule  , ");
            strSql.Append(" IssueTime = @IssueTime   ");
            strSql.Append(" where LinkID=@LinkID  ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "LinkID", System.Data.DbType.AnsiStringFixedLength, model.LinkID);
            this._db.AddInParameter(cmd, "LinkText", System.Data.DbType.String, model.LinkText);
            this._db.AddInParameter(cmd, "ImgPath", System.Data.DbType.String, model.ImgPath);
            this._db.AddInParameter(cmd, "LinkAddre", System.Data.DbType.String, model.LinkAddre);
            this._db.AddInParameter(cmd, "SortRule", System.Data.DbType.String, model.SortRule);
            this._db.AddInParameter(cmd, "IssueTime", System.Data.DbType.DateTime, model.IssueTime);

            return DbHelper.ExecuteSql(cmd, this._db);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="LinkID"></param>
        /// <returns></returns>
        public int Delete(string LinkID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbl_Link where ");
            string[] str = LinkID.Split(',');
            string Link = "";
            if (str.Length > 1)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    Link += ",'" + str[i].Trim() + "'";
                }
                strSql.AppendFormat(" LinkID in ({0}) ", Link.Substring(1));
            }
            else
            {
                strSql.AppendFormat(" LinkID = '{0}' ", LinkID.Trim());
            }
            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            return DbHelper.ExecuteSql(dc, _db) > 0 ? 1 : 0;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="LinkID"></param>
        /// <returns></returns>
        public EyouSoft.Model.MLink GetModel(string LinkID)
        {
            EyouSoft.Model.MLink model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select LinkID, LinkText, ImgPath, LinkAddre,SortRule,IssueTime  ");
            strSql.Append("  from tbl_Link ");
            strSql.Append(" where LinkID=@LinkID ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "LinkID", System.Data.DbType.AnsiStringFixedLength, LinkID);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new EyouSoft.Model.MLink();
                    model.LinkID = dr.GetString(dr.GetOrdinal("LinkID"));
                    model.LinkText = !dr.IsDBNull(dr.GetOrdinal("LinkText")) ? dr.GetString(dr.GetOrdinal("LinkText")) : null;
                    model.ImgPath = !dr.IsDBNull(dr.GetOrdinal("ImgPath")) ? dr.GetString(dr.GetOrdinal("ImgPath")) : null;
                    model.LinkAddre = !dr.IsDBNull(dr.GetOrdinal("LinkAddre")) ? dr.GetString(dr.GetOrdinal("LinkAddre")) : null;
                    model.SortRule = !dr.IsDBNull(dr.GetOrdinal("SortRule")) ? dr.GetInt32(dr.GetOrdinal("SortRule")) : 0;
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                    {
                        model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    }
                }
            }

            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <returns></returns>
        public IList<EyouSoft.Model.MLink> GetList()
        {
            IList<EyouSoft.Model.MLink> list = new List<EyouSoft.Model.MLink>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select LinkID, LinkText, ImgPath, LinkAddre,SortRule,IssueTime  ");
            strSql.Append("  from tbl_Link order by SortRule desc ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.MLink model = new EyouSoft.Model.MLink();
                    model.LinkID = dr.GetString(dr.GetOrdinal("LinkID"));
                    model.LinkText = !dr.IsDBNull(dr.GetOrdinal("LinkText")) ? dr.GetString(dr.GetOrdinal("LinkText")) : null;
                    model.ImgPath = !dr.IsDBNull(dr.GetOrdinal("ImgPath")) ? dr.GetString(dr.GetOrdinal("ImgPath")) : null;
                    model.LinkAddre = !dr.IsDBNull(dr.GetOrdinal("LinkAddre")) ? dr.GetString(dr.GetOrdinal("LinkAddre")) : null;
                    model.SortRule = !dr.IsDBNull(dr.GetOrdinal("SortRule")) ? dr.GetInt32(dr.GetOrdinal("SortRule")) : 0;
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                    {
                        model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    }
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.MLink> GetList(int PageSize, int PageIndex, ref int RecordCount)
        {
            IList<EyouSoft.Model.MLink> list = new List<EyouSoft.Model.MLink>();

            string tableName = "tbl_Link";
            string fileds = "LinkID, LinkText, ImgPath, LinkAddre,SortRule,IssueTime";
            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, null, "SortRule desc,IssueTime desc ", null))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.MLink model = new EyouSoft.Model.MLink();
                    model.LinkID = dr.GetString(dr.GetOrdinal("LinkID"));
                    model.LinkText = !dr.IsDBNull(dr.GetOrdinal("LinkText")) ? dr.GetString(dr.GetOrdinal("LinkText")) : null;
                    model.ImgPath = !dr.IsDBNull(dr.GetOrdinal("ImgPath")) ? dr.GetString(dr.GetOrdinal("ImgPath")) : null;
                    model.LinkAddre = !dr.IsDBNull(dr.GetOrdinal("LinkAddre")) ? dr.GetString(dr.GetOrdinal("LinkAddre")) : null;
                    model.SortRule = !dr.IsDBNull(dr.GetOrdinal("SortRule")) ? dr.GetInt32(dr.GetOrdinal("SortRule")) : 0;
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                    {
                        model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    }
                    list.Add(model);
                }
            }

            return list;

        }


        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public IList<EyouSoft.Model.MLink> GetList(int Top)
        {
            IList<EyouSoft.Model.MLink> list = new List<EyouSoft.Model.MLink>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM tbl_Link ");
            strSql.Append(" Order By SortRule desc,IssueTime desc ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.MLink model = new EyouSoft.Model.MLink();
                    model.LinkID = dr.GetString(dr.GetOrdinal("LinkID"));
                    model.LinkText = !dr.IsDBNull(dr.GetOrdinal("LinkText")) ? dr.GetString(dr.GetOrdinal("LinkText")) : null;
                    model.ImgPath = !dr.IsDBNull(dr.GetOrdinal("ImgPath")) ? dr.GetString(dr.GetOrdinal("ImgPath")) : null;
                    model.LinkAddre = !dr.IsDBNull(dr.GetOrdinal("LinkAddre")) ? dr.GetString(dr.GetOrdinal("LinkAddre")) : null;
                    model.SortRule = !dr.IsDBNull(dr.GetOrdinal("SortRule")) ? dr.GetInt32(dr.GetOrdinal("SortRule")) : 0;
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                    {
                        model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    }
                    list.Add(model);
                }
            }

            return list;

        }

        #endregion
    }
}
