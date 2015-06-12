//2011-09-23 汪奇志
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.Toolkit.DAL;
using EyouSoft.Model.SSOStructure;
using EyouSoft.Model.Enum;

namespace EyouSoft.Security.Membership
{
    /// <summary>
    /// webmaster登录数据访问类
    /// </summary>
    internal class DWebmasterLogin : DALBase, IWebmasterLogin
    {
        #region static constants
        //static constants
        const string SQL_SELECT_Login = "SELECT [Id],[Username],[Password],[MD5Password],[Realname],[Telephone],[Fax],[Mobile],[Permissions],[IsEnable],[IsAdmin],[CreateTime],[LeiXing],[GysId] FROM [tbl_Webmaster] WHERE [Username]=@UN AND [MD5Password]=@MD5PWD and [IsEnable] = 1 ";
        const string SQL_SELECT_LoginByIdOrName = "SELECT [Id],[Username],[Password],[MD5Password],[Realname],[Telephone],[Fax],[Mobile],[Permissions],[IsEnable],[IsAdmin],[CreateTime],[LeiXing],[GysId] FROM [tbl_Webmaster] ";

        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DWebmasterLogin()
        {
            _db = SystemStore;
        }
        #endregion

        #region IWebmasterLogin 成员
        /// <summary>
        /// webmaster登录，根据用户名、用户密码获取用户信息
        /// </summary>
        /// <param name="username">登录账号</param>
        /// <param name="pwd">登录密码</param>
        /// <returns></returns>
        public MWebmasterInfo Login(string username, Model.CompanyStructure.PassWord pwd)
        {
            MWebmasterInfo info = null;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_Login);
            _db.AddInParameter(cmd, "UN", DbType.String, username);
            _db.AddInParameter(cmd, "MD5PWD", DbType.String, pwd.MD5Password);
            info = ReadUserInfo(cmd);
            return info;
        }

        /// <summary>
        /// 用户登录，根据用户编号获取用户信息
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <returns></returns>
        public MWebmasterInfo LoginById(string userid)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_LoginByIdOrName + " WHERE Id=@Id ");
            _db.AddInParameter(cmd, "Id", DbType.AnsiStringFixedLength, userid);
            return ReadUserInfo(cmd);
        }
        /// <summary>
        /// 用户登录，根据系统公司编号、用户名获取用户信息
        /// </summary>
        /// <param name="username">登录账号</param>
        /// <returns></returns>
        public MWebmasterInfo LoginByName(string username)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_LoginByIdOrName + " WHERE Username=@Username ");
            _db.AddInParameter(cmd, "Username", DbType.String, username);
            return ReadUserInfo(cmd);
        }


        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        private MWebmasterInfo ReadUserInfo(DbCommand cmd)
        {
            MWebmasterInfo info = null;
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, SystemStore))
            {
                if (dr.Read())
                {
                    info = new MWebmasterInfo
                    {
                        UserId = dr.GetInt32(0),
                        Username = dr.GetString(1),
                        Permissions = dr.IsDBNull(dr.GetOrdinal("Permissions"))
                                ? string.Empty
                                : dr.GetString(dr.GetOrdinal("Permissions")),
                        ContactName =
                            dr.IsDBNull(dr.GetOrdinal("Realname"))
                                ? string.Empty
                                : dr.GetString(dr.GetOrdinal("Realname")),
                        Fax = dr.IsDBNull(dr.GetOrdinal("Fax")) ? string.Empty : dr.GetString(dr.GetOrdinal("Fax")),
                        Telephone =
                            dr.IsDBNull(dr.GetOrdinal("Telephone"))
                                ? string.Empty
                                : dr.GetString(dr.GetOrdinal("Telephone")),
                        Mobile =
                            dr.IsDBNull(dr.GetOrdinal("Mobile"))
                                ? string.Empty
                                : dr.GetString(dr.GetOrdinal("Mobile")),
                        IsEnable = dr.IsDBNull(dr.GetOrdinal("IsEnable")) ? Is.否 : (Is)dr["IsEnable"],
                        IsAdmin = dr.IsDBNull(dr.GetOrdinal("IsAdmin")) ? Is.否 : (Is)dr["IsAdmin"],
                    };
                    if (!dr.IsDBNull(dr.GetOrdinal("CreateTime")))
                        info.CreateTime = dr.GetDateTime(dr.GetOrdinal("CreateTime"));

                    info.LeiXing = (WebmasterUserType)dr.GetByte(dr.GetOrdinal("LeiXing"));
                    info.GysId = dr["GysId"].ToString();
                }
            }

            return info;
        }
        #endregion
    }
}
