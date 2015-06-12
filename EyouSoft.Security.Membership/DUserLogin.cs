//2011-09-23 汪奇志
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.Toolkit.DAL;
using EyouSoft.Toolkit;
using EyouSoft.Model.SSOStructure;
using EyouSoft.Model.CompanyStructure;
using System.Xml.Linq;

namespace EyouSoft.Security.Membership
{
   using EyouSoft.Model.Enum;

   /// <summary>
   /// 系统用户登录数据访问类
   /// </summary>
   internal class DUserLogin : DALBase, IUserLogin
   {
      #region static constants
      //static constants

      private const string SqlSelectLogin =
          @"SELECT [MemberID],[Account],[PassWord],[MD5Password],[ZhiFuPassword],[TotalMoney],[MemberName],[Gender],[NickName],[UserType],[CardType],[CardNo],[Contact],[Mobile],[qq],[Email],[Fax],[Address],[RegisterTime],[Photo],[BirthDate],[LoginTime],[LoginIP],[LoginNum],[MemberState],[OnlineStatus],[OnlineSessionId]  FROM [tbl_Member] ";

      private const string SqlInsertLoginLogwr = @" INSERT INTO [tbl_SysLogLogin] ([Id],[OperatorId],[IssueTime],[LoginIp],[AllHttp]) VALUES (@Id,@OperatorId,@IssueTime,@LoginIp,@AllHttp); ";

      private const string SqlUpdateSetOnlineStatus = " UPDATE [tbl_Member] SET [OnlineStatus]=@OnlineStatus,[OnlineSessionId]=@OnlineSessionId WHERE [MemberID]=@UserId";

      #endregion

      #region constructor
      /// <summary>
      /// database
      /// </summary>
      Database _db = null;

      /// <summary>
      /// default constructor
      /// </summary>
      public DUserLogin()
      {
         _db = SystemStore;
      }

      #endregion

      #region private members
      /// <summary>
      /// 获取用户信息
      /// </summary>
      /// <param name="cmd"></param>
      /// <returns></returns>
      private MUserInfo ReadUserInfo(DbCommand cmd)
      {
         MUserInfo info = null;
         using (IDataReader dr = DbHelper.ExecuteReader(cmd, SystemStore))
         {
            if (dr.Read())
            {
               info = new MUserInfo
                   {
                      UserId = dr.IsDBNull(dr.GetOrdinal("MemberID")) ? string.Empty : dr.GetString(dr.GetOrdinal("MemberID")),
                      Username =
                          dr.IsDBNull(dr.GetOrdinal("Account"))
                              ? string.Empty
                              : dr.GetString(dr.GetOrdinal("Account")),
                      MemberName =
                          dr.IsDBNull(dr.GetOrdinal("MemberName"))
                              ? string.Empty
                              : dr.GetString(dr.GetOrdinal("MemberName")),
                      NickName =
                          dr.IsDBNull(dr.GetOrdinal("NickName"))
                              ? string.Empty
                              : dr.GetString(dr.GetOrdinal("NickName")),
                      CardNo =
                          dr.IsDBNull(dr.GetOrdinal("CardNo"))
                              ? string.Empty
                              : dr.GetString(dr.GetOrdinal("CardNo")),
                      Contact =
                          dr.IsDBNull(dr.GetOrdinal("Contact"))
                              ? string.Empty
                              : dr.GetString(dr.GetOrdinal("Contact")),
                      Mobile =
                          dr.IsDBNull(dr.GetOrdinal("Mobile"))
                              ? string.Empty
                              : dr.GetString(dr.GetOrdinal("Mobile")),
                      qq = dr.IsDBNull(dr.GetOrdinal("qq")) ? string.Empty : dr.GetString(dr.GetOrdinal("qq")),
                      Email =
                          dr.IsDBNull(dr.GetOrdinal("Email")) ? string.Empty : dr.GetString(dr.GetOrdinal("Email")),
                      Fax = dr.IsDBNull(dr.GetOrdinal("Fax")) ? string.Empty : dr.GetString(dr.GetOrdinal("Fax")),
                      Address =
                          dr.IsDBNull(dr.GetOrdinal("Address"))
                              ? string.Empty
                              : dr.GetString(dr.GetOrdinal("Address")),
                      Photo =
                          dr.IsDBNull(dr.GetOrdinal("Photo")) ? string.Empty : dr.GetString(dr.GetOrdinal("Photo")),
                      LoginIP =
                          dr.IsDBNull(dr.GetOrdinal("LoginIP"))
                              ? string.Empty
                              : dr.GetString(dr.GetOrdinal("LoginIP")),
                      LoginNum = dr.IsDBNull(dr.GetOrdinal("LoginNum")) ? 0 : dr.GetInt32(dr.GetOrdinal("LoginNum")),
                      OnlineSessionId =
                          dr.IsDBNull(dr.GetOrdinal("OnlineSessionId"))
                              ? string.Empty
                              : dr.GetString(dr.GetOrdinal("OnlineSessionId")),
                      ZhiFuPassword = dr.IsDBNull(dr.GetOrdinal("ZhiFuPassword"))
                       ? string.Empty
                       : dr.GetString(dr.GetOrdinal("ZhiFuPassword")),

                      TotalMoney = dr.IsDBNull(dr.GetOrdinal("TotalMoney"))
                     ? 0
                     : dr.GetDecimal(dr.GetOrdinal("TotalMoney")),
                      UserType = dr.IsDBNull(dr.GetOrdinal("UserType"))
                    ? MemberTypes.未注册用户
                    : (MemberTypes)dr.GetInt32(dr.GetOrdinal("UserType")),
                   };


               if (!dr.IsDBNull(dr.GetOrdinal("Gender")))
               {
                  info.Gender = (Model.Enum.Gender)dr.GetInt32(dr.GetOrdinal("Gender"));
               }
               if (!dr.IsDBNull(dr.GetOrdinal("CardType")))
               {
                  info.CardType = (Model.Enum.CardType)dr.GetInt32(dr.GetOrdinal("CardType"));
               }
               if (!dr.IsDBNull(dr.GetOrdinal("MemberState")))
               {
                  info.MemberState = (Model.Enum.UserStatus)dr.GetByte(dr.GetOrdinal("MemberState"));
               }
               if (!dr.IsDBNull(dr.GetOrdinal("OnlineStatus")))
               {
                  info.OnlineStatus = (Model.Enum.UserOnlineStatus)dr.GetByte(dr.GetOrdinal("OnlineStatus"));
               }
               if (!dr.IsDBNull(dr.GetOrdinal("RegisterTime")))
               {
                  info.RegisterTime = dr.GetDateTime(dr.GetOrdinal("RegisterTime"));
               }
               if (!dr.IsDBNull(dr.GetOrdinal("BirthDate")))
               {
                  info.BirthDate = dr.GetDateTime(dr.GetOrdinal("BirthDate"));
               }
               if (!dr.IsDBNull(dr.GetOrdinal("LoginTime")))
               {
                  info.LoginTime = dr.GetDateTime(dr.GetOrdinal("LoginTime"));
               }
            }
         }

         return info;
      }

      #endregion

      #region IUserLogin 成员

      /// <summary>
      /// 用户登录，根据系统公司编号、用户名、用户密码获取用户信息
      /// </summary>
      /// <param name="username">登录账号</param>
      /// <param name="pwd">登录密码</param>
      /// <returns></returns>
      public MUserInfo Login(string username, PassWord pwd)
      {
         DbCommand cmd =
             _db.GetSqlStringCommand(
                 string.Format(
                     " {0} WHERE [Account]=@UN AND [MD5Password]=@MD5PWD ", SqlSelectLogin));
         _db.AddInParameter(cmd, "UN", DbType.String, username);
         _db.AddInParameter(cmd, "MD5PWD", DbType.String, pwd.MD5Password);

         return ReadUserInfo(cmd);
      }

      /// <summary>
      /// 用户登录，根据用户编号获取用户信息
      /// </summary>
      /// <param name="userid">用户编号</param>
      /// <returns></returns>
      public MUserInfo LoginById(string userid)
      {
         DbCommand cmd = _db.GetSqlStringCommand(SqlSelectLogin + " WHERE [MemberID]=@UID ");
         _db.AddInParameter(cmd, "UID", DbType.AnsiStringFixedLength, userid);

         return ReadUserInfo(cmd);
      }

      /// <summary>
      /// 用户登录，根据系统公司编号、用户名获取用户信息
      /// </summary>
      /// <param name="username">登录账号</param>
      /// <returns></returns>
      public MUserInfo LoginByName(string username)
      {
         DbCommand cmd = _db.GetSqlStringCommand(SqlSelectLogin + " WHERE [Account]=@UN ");
         _db.AddInParameter(cmd, "UN", DbType.String, username);

         return ReadUserInfo(cmd);
      }

      /// <summary>
      /// 写登录日志，用户登录时更新最后登录时间、在线状态、会话标识
      /// </summary>
      /// <param name="info">登录用户信息</param>
      /// <param name="loginType">登录类型</param>
      public void LoginLogwr(MUserInfo info, Model.Enum.UserLoginType loginType)
      {
         string cmdText = SqlInsertLoginLogwr;

         if (loginType == Model.Enum.UserLoginType.用户登录)
         {
            cmdText = SqlInsertLoginLogwr + " UPDATE [tbl_Member] SET [LoginTime]=@IssueTime,[OnlineStatus]=@OnlineStatus,[OnlineSessionId]=@OnlineSessionId,[LoginIP] = @LoginIp,[LoginNum] = isnull(LoginNum,0) + 1 WHERE [MemberId]=@OperatorId;";
         }

         DbCommand cmd = _db.GetSqlStringCommand(cmdText);

         _db.AddInParameter(cmd, "Id", DbType.AnsiStringFixedLength, Guid.NewGuid().ToString());
         _db.AddInParameter(cmd, "OperatorId", DbType.AnsiStringFixedLength, info.UserId);
         _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, DateTime.Now);
         _db.AddInParameter(cmd, "LoginIp", DbType.String, Utils.GetRemoteIP());
         _db.AddInParameter(cmd, "AllHttp", DbType.String, new EyouSoft.Toolkit.BrowserInfo().ToJsonString());
         _db.AddInParameter(cmd, "OnlineStatus", DbType.Byte, info.OnlineStatus);
         _db.AddInParameter(cmd, "OnlineSessionId", DbType.AnsiString, info.OnlineSessionId);

         DbHelper.ExecuteSql(cmd, _db);
      }

      /// <summary>
      /// 设置用户在线状态
      /// </summary>
      /// <param name="userId">用户编号</param>
      /// <param name="status">在线状态</param>
      /// <param name="onlineSessionId">用户会话状态标识</param>
      /// <returns></returns>
      public bool SetOnlineStatus(string userId, Model.Enum.UserOnlineStatus status, string onlineSessionId)
      {
         DbCommand cmd = _db.GetSqlStringCommand(SqlUpdateSetOnlineStatus);
         _db.AddInParameter(cmd, "OnlineStatus", DbType.Byte, status);
         _db.AddInParameter(cmd, "UserId", DbType.AnsiStringFixedLength, userId);
         _db.AddInParameter(cmd, "OnlineSessionId", DbType.AnsiString, onlineSessionId);
         return DbHelper.ExecuteSql(cmd, _db) > 0;
      }

      #endregion
   }
}
