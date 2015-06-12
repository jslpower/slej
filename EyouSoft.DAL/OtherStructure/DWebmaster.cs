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
using EyouSoft.Model.Enum;
using EyouSoft.Toolkit;

namespace EyouSoft.DAL
{
    public class DWebmaster : DALBase, IWebmaster
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
        public DWebmaster()
        {
            _db = SystemStore;
        }
        #endregion

        #region ITravelArticle 成员

        /// <summary>
        /// 验证用户名是否存在
        /// </summary>
        /// <param name="un">用户名</param>
        /// <param name="id">要排除的用户编号</param>
        /// <returns></returns>
        public bool ExistsUserName(string un, int id)
        {
            if (string.IsNullOrEmpty(un)) return false;

            var strSql = new StringBuilder();

            strSql.Append(" select count(Id) from tbl_Webmaster where Username = @Username ");
            if (id > 0)
            {
                strSql.AppendFormat(" and Id <> {0} ", id);
            }

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dc, "Username", DbType.String, un);

            object obj = DbHelper.GetSingle(dc, _db);
            if (obj == null) return false;

            if (Toolkit.Utils.GetInt(obj.ToString()) > 0) return true;

            return false;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EyouSoft.Model.MWebmaster model)
        {
            string StrSql = "INSERT INTO tbl_Webmaster(Username,Password,MD5Password,Realname";
            StrSql += ",Telephone,Fax,Mobile,Permissions,IsEnable,IsAdmin,CreateTime,LeiXing,GysId)";
            StrSql += " VALUES(@Username,@Password,@MD5Password,@Realname,@Telephone";
            StrSql += ",@Fax,@Mobile,@Permissions,@IsEnable,@IsAdmin,@CreateTime,@LeiXing,@GysId)";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            this._db.AddInParameter(dc, "Username", DbType.String, model.Username);
            this._db.AddInParameter(dc, "Password", DbType.String, model.Password);
            this._db.AddInParameter(dc, "MD5Password", DbType.String, model.MD5Password);
            this._db.AddInParameter(dc, "Realname", DbType.String, model.Realname);
            this._db.AddInParameter(dc, "Telephone", DbType.String, model.Telephone);
            this._db.AddInParameter(dc, "Fax", DbType.String, model.Fax);
            this._db.AddInParameter(dc, "Mobile", DbType.String, model.Mobile);
            this._db.AddInParameter(dc, "Permissions", DbType.String, model.Permissions);
            this._db.AddInParameter(dc, "IsEnable", DbType.Int32, model.IsEnable);
            this._db.AddInParameter(dc, "IsAdmin", DbType.Int32, model.IsAdmin);
            this._db.AddInParameter(dc, "CreateTime", DbType.DateTime, model.CreateTime);
            _db.AddInParameter(dc, "LeiXing", DbType.Int32, model.LeiXing);
            _db.AddInParameter(dc, "GysId", DbType.AnsiStringFixedLength, model.GysId);
            return DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EyouSoft.Model.MWebmaster model)
        {
            DbCommand dc = this._db.GetSqlStringCommand(" select 1 ");
            string StrSql = "UPDATE tbl_Webmaster SET ";
            StrSql += " Realname=@Realname,Telephone=@Telephone";
            StrSql += ",Fax=@Fax,Mobile=@Mobile,IsEnable=@IsEnable ";
            if (!string.IsNullOrEmpty(model.Password))
            {
                StrSql += ",Password=@Password,MD5Password=@MD5Password ";
                this._db.AddInParameter(dc, "Password", DbType.String, model.Password);
                this._db.AddInParameter(dc, "MD5Password", DbType.String, model.MD5Password);
            }

            if (!string.IsNullOrEmpty(model.Username))
            {
                StrSql += ",UserName=@UserName ";
                this._db.AddInParameter(dc, "UserName", DbType.String, model.Username);
            }

            StrSql += " WHERE Id=@Id ";
            if (!string.IsNullOrEmpty(model.Password))
            {
                StrSql += ";UPDATE tbl_Supplier SET SuppPwd=@SuppPwd WHERE ID=@ygsid";
                this._db.AddInParameter(dc, "ygsid", DbType.String, model.GysId);
                this._db.AddInParameter(dc, "SuppPwd", DbType.String, model.Password);
            }
            dc.CommandText = StrSql;
            this._db.AddInParameter(dc, "Realname", DbType.String, model.Realname);
            this._db.AddInParameter(dc, "Telephone", DbType.String, model.Telephone);
            this._db.AddInParameter(dc, "Fax", DbType.String, model.Fax);
            this._db.AddInParameter(dc, "Mobile", DbType.String, model.Mobile);
            this._db.AddInParameter(dc, "Id", DbType.Int32, model.Id);
            this._db.AddInParameter(dc, "IsEnable", DbType.Int32, model.IsEnable);

            return EyouSoft.Toolkit.DAL.DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 权限设置
        /// </summary>
        public bool UpdatePrivs(string privs, int Id)
        {
            string StrSql = "UPDATE tbl_Webmaster SET Permissions=@Permissions WHERE Id=@Id ";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            this._db.AddInParameter(dc, "Permissions", DbType.AnsiString, privs);
            this._db.AddInParameter(dc, "Id", DbType.Int32, Id);
            return EyouSoft.Toolkit.DAL.DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public bool Delete(int Id)
        {
            string StrSql = "DELETE FROM tbl_Webmaster WHERE Id=@Id";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql);
            this._db.AddInParameter(dc, "Id", DbType.Int32, Id);
            return EyouSoft.Toolkit.DAL.DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EyouSoft.Model.MWebmaster GetModel(int Id)
        {
            EyouSoft.Model.MWebmaster model = null;
            string StrSql = "SELECT Id,Username,Password,MD5Password,Realname,Telephone,Fax,Mobile,Permissions,IsEnable,IsAdmin,CreateTime,GysId FROM tbl_Webmaster WHERE Id=@Id";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
            this._db.AddInParameter(dc, "Id", DbType.Int32, Id);
            using (IDataReader dr = EyouSoft.Toolkit.DAL.DbHelper.ExecuteReader(dc, this._db))
            {
                if (dr.Read())
                {
                    model = new EyouSoft.Model.MWebmaster()
                        {
                            Id = dr.GetInt32(dr.GetOrdinal("Id")),
                            Username =
                                dr.IsDBNull(dr.GetOrdinal("Username")) ? "" : dr.GetString(dr.GetOrdinal("Username")),
                            Password = dr.IsDBNull(dr.GetOrdinal("Password")) ? "" : dr.GetString(dr.GetOrdinal("Password")),
                            Realname = dr.IsDBNull(dr.GetOrdinal("Realname")) ? "" : dr.GetString(dr.GetOrdinal("Realname")),
                            Telephone = dr.IsDBNull(dr.GetOrdinal("Telephone")) ? "" : dr.GetString(dr.GetOrdinal("Telephone")),
                            Fax = dr.IsDBNull(dr.GetOrdinal("Fax")) ? "" : dr.GetString(dr.GetOrdinal("Fax")),
                            Mobile = dr.IsDBNull(dr.GetOrdinal("Mobile")) ? "" : dr.GetString(dr.GetOrdinal("Mobile")),
                            Permissions = dr.IsDBNull(dr.GetOrdinal("Permissions")) ? "" : dr.GetString(dr.GetOrdinal("Permissions")),
                            IsEnable = (int)(dr.IsDBNull(dr.GetOrdinal("IsEnable")) ? Is.否 : (Is)dr["IsEnable"]),
                            IsAdmin = (int)(dr.IsDBNull(dr.GetOrdinal("IsAdmin")) ? Is.否 : (Is)dr["IsAdmin"]),
                            CreateTime = dr.GetDateTime(dr.GetOrdinal("CreateTime")),
                            GysId = dr.IsDBNull(dr.GetOrdinal("GysId")) ? "" : dr.GetString(dr.GetOrdinal("GysId"))

                        };
                }
            };
            return model;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EyouSoft.Model.MWebmaster GetModel(string Username)
        {
            EyouSoft.Model.MWebmaster model = null;
            string StrSql = "SELECT Id,Username,Password,MD5Password,Realname,Telephone,Fax,Mobile,Permissions,IsEnable,IsAdmin,CreateTime,GysId FROM tbl_Webmaster WHERE Username=@Username";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
            this._db.AddInParameter(dc, "Username", DbType.String, Username);
            using (IDataReader dr = EyouSoft.Toolkit.DAL.DbHelper.ExecuteReader(dc, this._db))
            {
                if (dr.Read())
                {
                    model = new EyouSoft.Model.MWebmaster()
                    {
                        Id = dr.GetInt32(dr.GetOrdinal("Id")),
                        Username =
                            dr.IsDBNull(dr.GetOrdinal("Username")) ? "" : dr.GetString(dr.GetOrdinal("Username")),
                        Password = dr.IsDBNull(dr.GetOrdinal("Password")) ? "" : dr.GetString(dr.GetOrdinal("Password")),
                        Realname = dr.IsDBNull(dr.GetOrdinal("Realname")) ? "" : dr.GetString(dr.GetOrdinal("Realname")),
                        Telephone = dr.IsDBNull(dr.GetOrdinal("Telephone")) ? "" : dr.GetString(dr.GetOrdinal("Telephone")),
                        Fax = dr.IsDBNull(dr.GetOrdinal("Fax")) ? "" : dr.GetString(dr.GetOrdinal("Fax")),
                        Mobile = dr.IsDBNull(dr.GetOrdinal("Mobile")) ? "" : dr.GetString(dr.GetOrdinal("Mobile")),
                        Permissions = dr.IsDBNull(dr.GetOrdinal("Permissions")) ? "" : dr.GetString(dr.GetOrdinal("Permissions")),
                        IsEnable = (int)(dr.IsDBNull(dr.GetOrdinal("IsEnable")) ? Is.否 : (Is)dr["IsEnable"]),
                        IsAdmin = (int)(dr.IsDBNull(dr.GetOrdinal("IsAdmin")) ? Is.否 : (Is)dr["IsAdmin"]),
                        CreateTime = dr.GetDateTime(dr.GetOrdinal("CreateTime")),
                        GysId = dr.IsDBNull(dr.GetOrdinal("GysId")) ? "" : dr.GetString(dr.GetOrdinal("GysId"))

                    };
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
        /// <returns></returns>
        public IList<EyouSoft.Model.MWebmaster> GetList(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.MWebmasterSearchModel chaXun)
        {
            IList<EyouSoft.Model.MWebmaster> ResultList = null;
            string tableName = "tbl_Webmaster";
            string fields = "Id,Username,Password,MD5Password,Realname,Telephone,Fax,Mobile,Permissions,IsEnable,IsAdmin,CreateTime,LeiXing,GysId";
            string query = " 1=1 ";
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.Username))
                {
                    query = query + string.Format(" AND Username like '%{0}%'", chaXun.Username);
                }
                if (!string.IsNullOrEmpty(chaXun.Realname))
                {
                    query = query + string.Format(" AND Realname like '%{0}%'", chaXun.Realname);
                }
                if (chaXun.IsEnable.HasValue)
                {
                    query = query + string.Format(" AND IsEnable={0}", chaXun.IsEnable.Value);
                }
                if (chaXun.IsAdmin.HasValue)
                {
                    query = query + string.Format(" AND IsAdmin={0}", chaXun.IsAdmin.Value);
                }
                if (chaXun.LeiXing.HasValue)
                {
                    query = query + string.Format(" AND LeiXing={0}", chaXun.LeiXing.Value);
                }
            }
            string orderByString = "CreateTime DESC";
            using (IDataReader dr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields
                , query, orderByString, string.Empty))
            {
                ResultList = new List<EyouSoft.Model.MWebmaster>();
                while (dr.Read())
                {
                    EyouSoft.Model.MWebmaster model = new EyouSoft.Model.MWebmaster()
                    {
                        Id = dr.GetInt32(dr.GetOrdinal("Id")),
                        Username = dr.IsDBNull(dr.GetOrdinal("Username")) ? "" : dr.GetString(dr.GetOrdinal("Username")),
                        Password = dr.IsDBNull(dr.GetOrdinal("Password")) ? "" : dr.GetString(dr.GetOrdinal("Password")),
                        Realname = dr.IsDBNull(dr.GetOrdinal("Realname")) ? "" : dr.GetString(dr.GetOrdinal("Realname")),
                        Telephone = dr.IsDBNull(dr.GetOrdinal("Telephone")) ? "" : dr.GetString(dr.GetOrdinal("Telephone")),
                        Fax = dr.IsDBNull(dr.GetOrdinal("Fax")) ? "" : dr.GetString(dr.GetOrdinal("Fax")),
                        Mobile = dr.IsDBNull(dr.GetOrdinal("Mobile")) ? "" : dr.GetString(dr.GetOrdinal("Mobile")),
                        Permissions = dr.IsDBNull(dr.GetOrdinal("Permissions")) ? "" : dr.GetString(dr.GetOrdinal("Permissions")),
                        IsAdmin = (int)(dr.IsDBNull(dr.GetOrdinal("IsEnable")) ? Is.否 : (Is)dr["IsEnable"]),
                        IsEnable = (int)(dr.IsDBNull(dr.GetOrdinal("IsEnable")) ? Is.否 : (Is)dr["IsEnable"]),
                        CreateTime = dr.GetDateTime(dr.GetOrdinal("CreateTime")),
                        LeiXing = dr.GetByte(dr.GetOrdinal("LeiXing")),
                        GysId = dr.IsDBNull(dr.GetOrdinal("GysId")) ? "" : dr.GetString(dr.GetOrdinal("GysId"))

                    };
                    ResultList.Add(model);
                    model = null;
                }
            };
            return ResultList;
        }

        /// <summary>
        /// 设置用户是否可用
        /// </summary>
        /// <param name="uid">用户编号</param>
        /// <param name="isEnable">是否可用</param>
        /// <returns></returns>
        public int SetUserSatae(int uid, bool isEnable)
        {
            if (uid <= 0) return 0;

            var strSql = new StringBuilder();

            strSql.Append(" UPDATE tbl_Webmaster SET IsEnable = @IsEnable WHERE Id=@Id ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(dc, "IsEnable", DbType.AnsiStringFixedLength, this.GetBooleanToStr(isEnable));
            this._db.AddInParameter(dc, "Id", DbType.Int32, uid);

            return DbHelper.ExecuteSql(dc, _db) > 0 ? 1 : -1;
        }

        /// <summary>
        /// 获取供应商用户信息
        /// </summary>
        public EyouSoft.Model.MWebmaster GetGysUserInfo(string gysId)
        {
            EyouSoft.Model.MWebmaster model = null;
            string StrSql = "SELECT * FROM tbl_Webmaster WHERE GysId=@GysId";
            DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
            this._db.AddInParameter(dc, "GysId", DbType.AnsiStringFixedLength, gysId);
            using (IDataReader dr = EyouSoft.Toolkit.DAL.DbHelper.ExecuteReader(dc, this._db))
            {
                if (dr.Read())
                {
                    model = new EyouSoft.Model.MWebmaster()
                    {
                        Id = dr.GetInt32(dr.GetOrdinal("Id")),
                        Username =
                            dr.IsDBNull(dr.GetOrdinal("Username")) ? "" : dr.GetString(dr.GetOrdinal("Username")),
                        Password = dr.IsDBNull(dr.GetOrdinal("Password")) ? "" : dr.GetString(dr.GetOrdinal("Password")),
                        Realname =
                            dr.IsDBNull(dr.GetOrdinal("Realname")) ? "" : dr.GetString(dr.GetOrdinal("Realname")),
                        Telephone =
                            dr.IsDBNull(dr.GetOrdinal("Telephone")) ? "" : dr.GetString(dr.GetOrdinal("Telephone")),
                        Fax = dr.IsDBNull(dr.GetOrdinal("Fax")) ? "" : dr.GetString(dr.GetOrdinal("Fax")),
                        Mobile = dr.IsDBNull(dr.GetOrdinal("Mobile")) ? "" : dr.GetString(dr.GetOrdinal("Mobile")),
                        Permissions =
                            dr.IsDBNull(dr.GetOrdinal("Permissions"))
                                ? ""
                                : dr.GetString(dr.GetOrdinal("Permissions")),
                        IsEnable = (int)(dr.IsDBNull(dr.GetOrdinal("IsEnable")) ? Is.否 : (Is)dr["IsEnable"]),
                        IsAdmin = (int)(dr.IsDBNull(dr.GetOrdinal("IsEnable")) ? Is.否 : (Is)dr["IsEnable"]),
                        CreateTime = dr.GetDateTime(dr.GetOrdinal("CreateTime"))
                    };
                }
            };
            return model;
        }
        #endregion
    }
}
