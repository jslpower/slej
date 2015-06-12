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
   public class DMember : EyouSoft.Toolkit.DAL.DALBase, EyouSoft.IDAL.OtherStructure.IMember
   {
      #region 初始化db
      private Database _db = null;

      /// <summary>
      /// 初始化_db
      /// </summary>
      public DMember()
      {
         _db = base.SystemStore;
      }
      #endregion

      #region IMember 成员

      /// <summary>
      /// 验证会员账号是否存在
      /// </summary>
      /// <param name="Account">会员账号</param>
      /// <param name="MemberID">要排除的会员编号</param>
      /// <returns></returns>
      public bool ExistsUserName(string Account, string MemberID)
      {
         if (string.IsNullOrEmpty(Account)) return false;

         var strSql = new StringBuilder();

         strSql.Append(" select count(MemberID) from tbl_Member where Account = @Account ");
         if (!string.IsNullOrEmpty(MemberID))
         {
            strSql.AppendFormat(" and MemberID <> '{0}' ", MemberID);
         }

         DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
         _db.AddInParameter(dc, "Account", DbType.String, Account);

         object obj = DbHelper.GetSingle(dc, _db);
         if (obj == null) return false;

         if (Toolkit.Utils.GetInt(obj.ToString()) > 0) return true;

         return false;
      }

      /// <summary>
      /// 验证用证件号码是否存在
      /// </summary>
      /// <param name="CardType">证件类型</param>
      /// <param name="CardNo">证件号</param>
      /// <param name="MemberID">要排除的用户编号</param>
      /// <returns></returns>
      public bool ExistsUserName(EyouSoft.Model.Enum.CardType CardType, string CardNo, string MemberID)
      {
         if ((int)CardType < 1 || string.IsNullOrEmpty(CardNo)) return false;

         var strSql = new StringBuilder();

         strSql.Append(" select count(MemberID) from tbl_Member where CardType = @CardType AND CardNo=@CardNo ");
         if (!string.IsNullOrEmpty(MemberID))
         {
            strSql.AppendFormat(" and MemberID <> '{0}' ", MemberID);
         }

         DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
         _db.AddInParameter(dc, "CardType", DbType.Int32, (int)CardType);
         _db.AddInParameter(dc, "CardNo", DbType.String, CardNo);

         object obj = DbHelper.GetSingle(dc, _db);
         if (obj == null) return false;

         if (Toolkit.Utils.GetInt(obj.ToString()) > 0) return true;

         return false;
      }

      /// <summary>
      /// 增加一条数据
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>
      public int Add(EyouSoft.Model.MMember model)
      {
         StringBuilder strSql = new StringBuilder();
         strSql.Append("insert into tbl_Member(");
         strSql.Append("MemberID,Contact,Mobile,qq,Email,Fax,Address,RegisterTime,Photo,BirthDate,LoginTime,Account,LoginIP,LoginNum,MemberState,PassWord,MD5Password,MemberName,Gender,NickName,CardType,CardNo,IsCar,CarInfo,OnlineSessionId,UserType ");
         strSql.Append(") values (");
         strSql.Append("@MemberID,@Contact,@Mobile,@qq,@Email,@Fax,@Address,@RegisterTime,@Photo,@BirthDate,@LoginTime,@Account,@LoginIP,@LoginNum,@MemberState,@PassWord,@MD5Password,@MemberName,@Gender,@NickName,@CardType,@CardNo,@IsCar,@CarInfo,@OnlineSessionId,@UserType ");
         strSql.Append(") ");

         DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
         this._db.AddInParameter(cmd, "MemberID", DbType.AnsiStringFixedLength, model.MemberID);
         this._db.AddInParameter(cmd, "Contact", DbType.String, model.Contact);
         this._db.AddInParameter(cmd, "Mobile", DbType.String, model.Mobile);
         this._db.AddInParameter(cmd, "qq", DbType.String, model.qq);
         this._db.AddInParameter(cmd, "Email", DbType.String, model.Email);
         this._db.AddInParameter(cmd, "Fax", DbType.String, model.Fax);
         this._db.AddInParameter(cmd, "Address", DbType.String, model.Address);
         this._db.AddInParameter(cmd, "RegisterTime", DbType.DateTime, model.RegisterTime);
         this._db.AddInParameter(cmd, "Photo", DbType.String, model.Photo);
         this._db.AddInParameter(cmd, "BirthDate", DbType.DateTime, model.BirthDate);
         this._db.AddInParameter(cmd, "LoginTime", DbType.DateTime, model.LoginTime);
         this._db.AddInParameter(cmd, "LoginIP", DbType.String, model.LoginIP);
         this._db.AddInParameter(cmd, "Account", DbType.String, model.Account);
         this._db.AddInParameter(cmd, "LoginNum", DbType.Int32, model.LoginNum);
         this._db.AddInParameter(cmd, "MemberState", DbType.Byte, (int)model.MemberState);
         this._db.AddInParameter(cmd, "PassWord", DbType.String, model.PassWord.NoEncryptPassword);
         this._db.AddInParameter(cmd, "MD5Password", DbType.String, model.PassWord.MD5Password);
         this._db.AddInParameter(cmd, "MemberName", DbType.String, model.MemberName);
         this._db.AddInParameter(cmd, "Gender", DbType.Int32, (int)model.Gender);
         this._db.AddInParameter(cmd, "NickName", DbType.String, model.NickName);
         this._db.AddInParameter(cmd, "CardType", DbType.Int32, (int)model.CardType);
         this._db.AddInParameter(cmd, "CardNo", DbType.String, model.CardNo);
         this._db.AddInParameter(cmd, "IsCar", DbType.AnsiStringFixedLength, this.GetBooleanToStr(model.IsCar));
         this._db.AddInParameter(cmd, "CarInfo", DbType.String, model.CarInfo);
         this._db.AddInParameter(cmd, "OnlineSessionId", DbType.String, "00000000-0000-0000-0000-000000000000");
         this._db.AddInParameter(cmd, "UserType", DbType.Int32, (int)model.UserType);
         return DbHelper.ExecuteSql(cmd, this._db);

      }

      /// <summary>
      /// 更新一条数据
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>
      public int Update(EyouSoft.Model.MMember model)
      {
         StringBuilder strSql = new StringBuilder();
         strSql.Append("update tbl_Member set ");

         //strSql.Append(" MemberID = @MemberID , ");
         strSql.Append(" Contact = @Contact , ");
         strSql.Append(" Mobile = @Mobile , ");
         strSql.Append(" qq = @qq , ");
         strSql.Append(" Email = @Email , ");
         strSql.Append(" Fax = @Fax , ");
         strSql.Append(" Address = @Address , ");
         //strSql.Append(" RegisterTime = @RegisterTime , ");
         strSql.Append(" Photo = @Photo , ");
         strSql.Append(" BirthDate = @BirthDate , ");
         //strSql.Append(" LoginTime = @LoginTime , ");
         //strSql.Append(" Account = @Account , ");
         //strSql.Append(" LoginIP = @LoginIP , ");
         //strSql.Append(" LoginNum = @LoginNum , ");
         //strSql.Append(" MemberState = @MemberState , ");

         if (model.PassWord != null && !string.IsNullOrEmpty(model.PassWord.NoEncryptPassword))
         {
            strSql.Append(" PassWord = @PassWord , ");
            strSql.Append(" MD5Password = @MD5Password , ");
         }

         strSql.Append(" MemberName = @MemberName , ");
         strSql.Append(" Gender = @Gender , ");
         strSql.Append(" NickName = @NickName , ");
         strSql.Append(" CardType = @CardType , ");
         strSql.Append(" CardNo = @CardNo,  ");
         strSql.Append(" IsCar = @IsCar,  ");
         strSql.Append(" CarInfo = @CarInfo  ");
         strSql.Append(" where MemberID=@MemberID  ");

         DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
         this._db.AddInParameter(cmd, "MemberID", DbType.AnsiStringFixedLength, model.MemberID);
         this._db.AddInParameter(cmd, "Contact", DbType.String, model.Contact);
         this._db.AddInParameter(cmd, "Mobile", DbType.String, model.Mobile);
         this._db.AddInParameter(cmd, "qq", DbType.String, model.qq);
         this._db.AddInParameter(cmd, "Email", DbType.String, model.Email);
         this._db.AddInParameter(cmd, "Fax", DbType.String, model.Fax);
         this._db.AddInParameter(cmd, "Address", DbType.String, model.Address);
         this._db.AddInParameter(cmd, "RegisterTime", DbType.DateTime, model.RegisterTime);
         this._db.AddInParameter(cmd, "Photo", DbType.String, model.Photo);
         this._db.AddInParameter(cmd, "BirthDate", DbType.DateTime, model.BirthDate);
         this._db.AddInParameter(cmd, "LoginTime", DbType.DateTime, model.LoginTime);
         this._db.AddInParameter(cmd, "LoginIP", DbType.String, model.LoginIP);
         this._db.AddInParameter(cmd, "Account", DbType.String, model.Account);
         this._db.AddInParameter(cmd, "LoginNum", DbType.Int32, model.LoginNum);
         this._db.AddInParameter(cmd, "MemberState", DbType.Byte, (int)model.MemberState);
         if (model.PassWord != null && !string.IsNullOrEmpty(model.PassWord.NoEncryptPassword))
         {
            this._db.AddInParameter(cmd, "PassWord", DbType.String, model.PassWord.NoEncryptPassword);
            this._db.AddInParameter(cmd, "MD5Password", DbType.String, model.PassWord.MD5Password);
         }
         this._db.AddInParameter(cmd, "MemberName", DbType.String, model.MemberName);
         this._db.AddInParameter(cmd, "Gender", DbType.Int32, (int)model.Gender);
         this._db.AddInParameter(cmd, "NickName", DbType.String, model.NickName);
         this._db.AddInParameter(cmd, "CardType", DbType.Int32, (int)model.CardType);
         this._db.AddInParameter(cmd, "CardNo", DbType.String, model.CardNo);
         this._db.AddInParameter(cmd, "IsCar", DbType.AnsiStringFixedLength, this.GetBooleanToStr(model.IsCar));
         this._db.AddInParameter(cmd, "CarInfo", DbType.String, model.CarInfo);

         return DbHelper.ExecuteSql(cmd, this._db);
      }

      /// <summary>
      /// 删除一条数据
      /// </summary>
      /// <param name="MemberID"></param>
      /// <returns></returns>
      public int Delete(string MemberID)
      {
         StringBuilder strSql = new StringBuilder();
         strSql.Append("delete from tbl_Member ");
         strSql.Append(" where MemberID=@MemberID ");

         DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
         this._db.AddInParameter(cmd, "MemberID", DbType.AnsiStringFixedLength, MemberID);

         return DbHelper.ExecuteSql(cmd, this._db);
      }

      /// <summary>
      /// 获取实体
      /// </summary>
      /// <param name="MemberID"></param>
      /// <returns></returns>
      public EyouSoft.Model.MMember GetModel(string MemberID)
      {
         EyouSoft.Model.MMember model = null;

         StringBuilder strSql = new StringBuilder();
         strSql.Append("select MemberID, Contact, Mobile, qq, Email, Fax, Address, RegisterTime, Photo, BirthDate, LoginTime, Account, LoginIP, LoginNum, MemberState, PassWord, MD5Password, MemberName, Gender, NickName, CardType, CardNo,IsCar,CarInfo,TotalMoney,UserType  ");
         strSql.Append("  from tbl_Member ");
         strSql.Append(" where MemberID=@MemberID ");

         DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
         this._db.AddInParameter(cmd, "MemberID", DbType.AnsiStringFixedLength, MemberID);

         using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
         {

            while (dr.Read())
            {
               model = new EyouSoft.Model.MMember();
               model.MemberID = dr.GetString(dr.GetOrdinal("MemberID"));
               model.Contact = !dr.IsDBNull(dr.GetOrdinal("Contact")) ? dr.GetString(dr.GetOrdinal("Contact")) : null;
               model.Mobile = !dr.IsDBNull(dr.GetOrdinal("Mobile")) ? dr.GetString(dr.GetOrdinal("Mobile")) : null;
               model.qq = !dr.IsDBNull(dr.GetOrdinal("qq")) ? dr.GetString(dr.GetOrdinal("qq")) : null;
               model.Email = !dr.IsDBNull(dr.GetOrdinal("Email")) ? dr.GetString(dr.GetOrdinal("Email")) : null;
               model.Fax = !dr.IsDBNull(dr.GetOrdinal("Fax")) ? dr.GetString(dr.GetOrdinal("Fax")) : null;
               model.Address = !dr.IsDBNull(dr.GetOrdinal("Address")) ? dr.GetString(dr.GetOrdinal("Address")) : null;
               model.RegisterTime = !dr.IsDBNull(dr.GetOrdinal("RegisterTime")) ? (DateTime?)dr.GetDateTime(dr.GetOrdinal("RegisterTime")) : null;
               model.Photo = !dr.IsDBNull(dr.GetOrdinal("Photo")) ? dr.GetString(dr.GetOrdinal("Photo")) : null;
               model.BirthDate = !dr.IsDBNull(dr.GetOrdinal("BirthDate")) ? (DateTime?)dr.GetDateTime(dr.GetOrdinal("BirthDate")) : null;
               model.LoginTime = !dr.IsDBNull(dr.GetOrdinal("LoginTime")) ? (DateTime?)dr.GetDateTime(dr.GetOrdinal("LoginTime")) : null;
               model.Account = !dr.IsDBNull(dr.GetOrdinal("Account")) ? dr.GetString(dr.GetOrdinal("Account")) : null;
               model.LoginIP = !dr.IsDBNull(dr.GetOrdinal("LoginIP")) ? dr.GetString(dr.GetOrdinal("LoginIP")) : null;
               model.LoginNum = !dr.IsDBNull(dr.GetOrdinal("LoginNum")) ? dr.GetInt32(dr.GetOrdinal("LoginNum")) : 0;
               model.MemberState = (EyouSoft.Model.Enum.UserStatus)dr.GetByte(dr.GetOrdinal("MemberState"));
               model.PassWord = new Model.CompanyStructure.PassWord(dr.IsDBNull(dr.GetOrdinal("PassWord")) ? "" : dr.GetString(dr.GetOrdinal("PassWord")));
               model.MemberName = !dr.IsDBNull(dr.GetOrdinal("MemberName")) ? dr.GetString(dr.GetOrdinal("MemberName")) : null;
               model.Gender = !dr.IsDBNull(dr.GetOrdinal("Gender")) ? (EyouSoft.Model.Enum.Gender)dr.GetInt32(dr.GetOrdinal("Gender")) : EyouSoft.Model.Enum.Gender.男;
               model.NickName = !dr.IsDBNull(dr.GetOrdinal("NickName")) ? dr.GetString(dr.GetOrdinal("NickName")) : null;
               model.CardType = !dr.IsDBNull(dr.GetOrdinal("CardType")) ? (EyouSoft.Model.Enum.CardType)dr.GetInt32(dr.GetOrdinal("CardType")) : EyouSoft.Model.Enum.CardType.请选择;
               model.CardNo = !dr.IsDBNull(dr.GetOrdinal("CardNo")) ? dr.GetString(dr.GetOrdinal("CardNo")) : null;
               model.IsCar = this.GetBoolean(dr.IsDBNull(dr.GetOrdinal("IsCar")) ? "" : dr.GetString(dr.GetOrdinal("IsCar")));
               model.CarInfo = !dr.IsDBNull(dr.GetOrdinal("CarInfo")) ? dr.GetString(dr.GetOrdinal("CarInfo")) : null;
               if (!dr.IsDBNull(dr.GetOrdinal("TotalMoney"))) model.TotalMoney = dr.GetDecimal(dr.GetOrdinal("TotalMoney"));
               model.UserType = (EyouSoft.Model.Enum.MemberTypes)dr.GetInt32(dr.GetOrdinal("UserType"));
            }
         }

         return model;
      }


      /// <summary>
      /// 获取分页列表
      /// </summary>
      /// <param name="PageSize"></param>
      /// <param name="PageIndex"></param>
      /// <param name="RecordCount"></param>
      /// <param name="Search"></param>
      /// <returns></returns>
      public IList<EyouSoft.Model.MMember> GetList(int PageSize, int PageIndex, ref int RecordCount, EyouSoft.Model.MSearchMember Search)
      {
         IList<EyouSoft.Model.MMember> list = new List<EyouSoft.Model.MMember>();


         string tableName = "tbl_Member";
         string fileds = "MemberID, Contact, Mobile, qq, Email, Fax, Address, RegisterTime, Photo, BirthDate, LoginTime, Account, LoginIP, LoginNum, MemberState, PassWord, MD5Password, MemberName, Gender, NickName, CardType, CardNo,IsCar,CarInfo  ";
         string orderByString = "RegisterTime desc";

         StringBuilder query = new StringBuilder();
         query.Append(" 1=1 ");

         if (Search != null)
         {
            if (!string.IsNullOrEmpty(Search.Account))
            {
               query.AppendFormat(" and  Account like '%{0}%' ", Search.Account);
            }

            if (!string.IsNullOrEmpty(Search.Contact))
            {

               query.AppendFormat(" and  Contact like '%{0}%' ", Search.Contact);
            }

            if (!string.IsNullOrEmpty(Search.Email))
            {
               query.AppendFormat(" and  Email like '%{0}%' ", Search.Email);
            }


            if (!string.IsNullOrEmpty(Search.MemberName))
            {
               query.AppendFormat(" and  MemberName like '%{0}%' ", Search.MemberName);
            }

            if (!string.IsNullOrEmpty(Search.Mobile))
            {
               query.AppendFormat(" and  Mobile like '%{0}%' ", Search.Mobile);
            }

            if (!string.IsNullOrEmpty(Search.NickName))
            {
               query.AppendFormat(" and  NickName like '%{0}%' ", Search.NickName);
            }
         }


         using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query.ToString(), orderByString, null))
         {
            while (dr.Read())
            {

               EyouSoft.Model.MMember model = new EyouSoft.Model.MMember();
               model.MemberID = dr.GetString(dr.GetOrdinal("MemberID"));
               model.Contact = !dr.IsDBNull(dr.GetOrdinal("Contact")) ? dr.GetString(dr.GetOrdinal("Contact")) : null;
               model.Mobile = !dr.IsDBNull(dr.GetOrdinal("Mobile")) ? dr.GetString(dr.GetOrdinal("Mobile")) : null;
               model.qq = !dr.IsDBNull(dr.GetOrdinal("qq")) ? dr.GetString(dr.GetOrdinal("qq")) : null;
               model.Email = !dr.IsDBNull(dr.GetOrdinal("Email")) ? dr.GetString(dr.GetOrdinal("Email")) : null;
               model.Fax = !dr.IsDBNull(dr.GetOrdinal("Fax")) ? dr.GetString(dr.GetOrdinal("Fax")) : null;
               model.Address = !dr.IsDBNull(dr.GetOrdinal("Address")) ? dr.GetString(dr.GetOrdinal("Address")) : null;
               model.RegisterTime = !dr.IsDBNull(dr.GetOrdinal("RegisterTime")) ? (DateTime?)dr.GetDateTime(dr.GetOrdinal("RegisterTime")) : null;
               model.Photo = !dr.IsDBNull(dr.GetOrdinal("Photo")) ? dr.GetString(dr.GetOrdinal("Photo")) : null;
               model.BirthDate = (dr["BirthDate"] == DBNull.Value || dr["BirthDate"] == null || dr["BirthDate"].ToString() == "") ? null : (DateTime?)dr["BirthDate"];
               model.LoginTime = !dr.IsDBNull(dr.GetOrdinal("LoginTime")) ? (DateTime?)dr.GetDateTime(dr.GetOrdinal("LoginTime")) : null;
               model.Account = !dr.IsDBNull(dr.GetOrdinal("Account")) ? dr.GetString(dr.GetOrdinal("Account")) : null;
               model.LoginIP = !dr.IsDBNull(dr.GetOrdinal("LoginIP")) ? dr.GetString(dr.GetOrdinal("LoginIP")) : null;
               model.LoginNum = !dr.IsDBNull(dr.GetOrdinal("LoginNum")) ? dr.GetInt32(dr.GetOrdinal("LoginNum")) : 0;
               model.MemberState = (EyouSoft.Model.Enum.UserStatus)dr.GetByte(dr.GetOrdinal("MemberState"));
               model.PassWord = new Model.CompanyStructure.PassWord(dr.IsDBNull(dr.GetOrdinal("PassWord")) ? "" : dr.GetString(dr.GetOrdinal("PassWord")));
               model.MemberName = !dr.IsDBNull(dr.GetOrdinal("MemberName")) ? dr.GetString(dr.GetOrdinal("MemberName")) : null;
               model.Gender = !dr.IsDBNull(dr.GetOrdinal("Gender")) ? (EyouSoft.Model.Enum.Gender)dr.GetInt32(dr.GetOrdinal("Gender")) : EyouSoft.Model.Enum.Gender.男;
               model.NickName = !dr.IsDBNull(dr.GetOrdinal("NickName")) ? dr.GetString(dr.GetOrdinal("NickName")) : null;
               model.CardType = !dr.IsDBNull(dr.GetOrdinal("CardType")) ? (EyouSoft.Model.Enum.CardType)dr.GetInt32(dr.GetOrdinal("CardType")) : EyouSoft.Model.Enum.CardType.请选择;
               model.CardNo = !dr.IsDBNull(dr.GetOrdinal("CardNo")) ? dr.GetString(dr.GetOrdinal("CardNo")) : null;
               model.IsCar = this.GetBoolean(dr.IsDBNull(dr.GetOrdinal("IsCar")) ? "" : dr.GetString(dr.GetOrdinal("IsCar")));
               model.CarInfo = !dr.IsDBNull(dr.GetOrdinal("CarInfo")) ? dr.GetString(dr.GetOrdinal("CarInfo")) : null;

               list.Add(model);
            }
         }
         return list;
      }

      /// <summary>
      /// 前台会员修改密码
      /// </summary>
      /// <param name="userId">用户编号</param>
      /// <param name="oldPassWord">旧的明文密码</param>
      /// <param name="newPassWord">新的密码</param>
      /// <returns></returns>
      public int UpdatePassWord(string userId, string oldPassWord, Model.CompanyStructure.PassWord newPassWord)
      {
         if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(oldPassWord)
             || newPassWord == null || string.IsNullOrEmpty(newPassWord.NoEncryptPassword)) return 0;

         var strSql = new StringBuilder();
         strSql.Append("update tbl_Member set ");

         strSql.Append(" PassWord = @PassWord , ");
         strSql.Append(" MD5Password = @MD5Password ");

         strSql.Append(" where MemberID = @MemberID and PassWord = @OldPassWord  ");

         DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
         this._db.AddInParameter(cmd, "MemberID", DbType.AnsiStringFixedLength, userId);
         this._db.AddInParameter(cmd, "PassWord", DbType.String, newPassWord.NoEncryptPassword);
         this._db.AddInParameter(cmd, "MD5Password", DbType.String, newPassWord.MD5Password);
         this._db.AddInParameter(cmd, "OldPassWord", DbType.String, oldPassWord);

         return DbHelper.ExecuteSql(cmd, this._db) > 0 ? 1 : -2;
      }

      /// <summary>
      /// 修改会员状态
      /// </summary>
      /// <param name="MemberState">会员状态</param>
      /// <param name="ids"></param>
      /// <returns></returns>
      public bool SetMemberState(EyouSoft.Model.Enum.UserStatus MemberState, params string[] Ids)
      {
         StringBuilder sId = new StringBuilder();
         for (int i = 0; i < Ids.Length; i++)
         {
            sId.AppendFormat("'{0}',", Ids[i]);
         }
         sId.Remove(sId.Length - 1, 1);
         string strSql = "UPDATE tbl_Member SET MemberState=@MemberState Where MemberID in (" + sId + ")";
         DbCommand cmd = this._db.GetSqlStringCommand(strSql);
         this._db.AddInParameter(cmd, "MemberState", DbType.Byte, (int)MemberState);
         return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
      }

      /// <summary>
      /// 根据会员编号获取指定会员的上级代理商信息
      /// </summary>
      /// <param name="huiYuanId">会员编号</param>
      /// <returns></returns>
      public EyouSoft.Model.MShangJiDaiLiShangInfo GetShangJiDaiLiShangInfoByHuiYuanId(string huiYuanId)
      {
          EyouSoft.Model.MShangJiDaiLiShangInfo info = null;
          var cmd = _db.GetSqlStringCommand("SELECT A.ShangJiDaiLiShangId,C.MemberId AS ShangJiDaiLiShangHuiYuanId,B.WebSite AS ShangJiDaiLiShangYuMing,C.MemberName AS ShangJiDaiLiShangHuiYuanXingMing FROM tbl_Member AS A INNER JOIN tbl_JA_Sellers AS B ON A.ShangJiDaiLiShangId=B.Id INNER JOIN tbl_Member AS C ON A.ShangJiDaiLiShangHuiYuanId=C.MemberId WHERE A.MemberID=@HuiYuanId");
          _db.AddInParameter(cmd, "HuiYuanId", DbType.AnsiStringFixedLength, huiYuanId);

          using (var rdr = DbHelper.ExecuteReader(cmd, _db))
          {
              if (rdr.Read())
              {
                  info = new EyouSoft.Model.MShangJiDaiLiShangInfo();
                  info.DaiLiShangId = rdr["ShangJiDaiLiShangId"].ToString();
                  info.HuiYuanId = rdr["ShangJiDaiLiShangHuiYuanId"].ToString();
                  info.HuiYuanXingMing = rdr["ShangJiDaiLiShangHuiYuanXingMing"].ToString();
                  info.YuMing = rdr["ShangJiDaiLiShangYuMing"].ToString();
              }
          }

          return info;
      }

       /// <summary>
       /// 获取粉丝信息集合
       /// </summary>
       /// <param name="huiYuanId">会员编号</param>
       /// <param name="pageSize">页记录数</param>
       /// <param name="pageIndex">页序号</param>
       /// <param name="recordCount">总记录数</param>
       /// <param name="chaXun">查询</param>
       /// <returns></returns>
      public IList<EyouSoft.Model.MFenSiInfo> GetFenSis(string huiYuanId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.MFenSiChaXunInfo chaXun)
      {
          IList<EyouSoft.Model.MFenSiInfo> items = new List<EyouSoft.Model.MFenSiInfo>();

          string fields = "*";
          StringBuilder sql = new StringBuilder();
          string tableName = "view_FenSi";
          string orderByString = " RegisterTime DESC ";
          string sumString = "";

          sql.AppendFormat(" ShangJiDaiLiShangHuiYuanId='{0}' ", huiYuanId);

          if (chaXun != null)
          {
              if (!string.IsNullOrEmpty(chaXun.FenSiId))
              {
                  sql.AppendFormat(" AND HuiYuanId='{0}' ", chaXun.FenSiId);
              }
          }

          using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), sql.ToString(), orderByString, sumString))
          {
              while (rdr.Read())
              {
                  var info = new EyouSoft.Model.MFenSiInfo();

                  info.HuiYuanId = rdr["HuiYuanId"].ToString();
                  info.HuiYuanWangZhanName = rdr["HuiYuanWangZhanName"].ToString();
                  info.HuiYuanXingMing = rdr["HuiYuanXingMing"].ToString();
                  info.HuiYuanYuMing = rdr["HuiYuanYuMing"].ToString();
                  info.HuiYuanYongHuMing = rdr["HuiYuanYongHuMing"].ToString();
                  info.HuiYuanShouJi = rdr["HuiYuanShouJi"].ToString();
                  info.ZhuCeShiJian = rdr.GetDateTime(rdr.GetOrdinal("ZhuCeShiJian"));
                  if (!rdr.IsDBNull(rdr.GetOrdinal("DaoQiShiJian"))) info.DaoQiShiJian = rdr.GetDateTime(rdr.GetOrdinal("DaoQiShiJian"));
                  info.HuiYuanDaiLiShangId = rdr["HuiYuanDaiLiShangId"].ToString();

                  items.Add(info);
              }
          }

          return items;
      }

       /// <summary>
       /// 获取粉丝交易信息集合
       /// </summary>
      /// <param name="huiYuanId">会员编号</param>
      /// <param name="pageSize">页记录数</param>
      /// <param name="pageIndex">页序号</param>
      /// <param name="recordCount">总记录数</param>
      /// <param name="chaXun">查询</param>
       /// <returns></returns>
      public IList<EyouSoft.Model.MFenSiJiaoYiInfo> GetFenSiJiaoYis(string huiYuanId, int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.MFenSiJiaoYiChaXunInfo chaXun)
      {
          IList<EyouSoft.Model.MFenSiJiaoYiInfo> items = new List<EyouSoft.Model.MFenSiJiaoYiInfo>();
          string fields = "*";
          StringBuilder sql = new StringBuilder();
          string tableName = "view_FenSiJiaoYi";
          string orderByString = " XiaDanShiJian DESC ";
          string sumString = "";

          sql.AppendFormat(" DaiLiShangShangJiDaiLiShangHuiYuanId='{0}' ", huiYuanId);

          if (chaXun != null)
          {
              if (!string.IsNullOrEmpty(chaXun.FenSiId))
              {
                  sql.AppendFormat(" AND DaiLiShangHuiYuanId='{0}' ", chaXun.FenSiId);
              }
          }

          using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), sql.ToString(), orderByString, sumString))
          {
              while (rdr.Read())
              {
                  var info = new EyouSoft.Model.MFenSiJiaoYiInfo();

                  info.CPName = rdr["CPName"].ToString();
                  info.DaiLiShangId = rdr["DaiLiShangId"].ToString();
                  info.DaiLiShangJinE = rdr.GetDecimal(rdr.GetOrdinal("DaiLiShangJinE"));
                  info.DingDanId = rdr["DingDanId"].ToString();
                  info.DingDanJinE = rdr.GetDecimal(rdr.GetOrdinal("DingDanJinE"));
                  info.DingDanLeiXing = (EyouSoft.Model.OtherStructure.DingDanType)rdr.GetInt32(rdr.GetOrdinal("DingDanLeiXing"));
                  info.DingDanStatus = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)rdr.GetByte(rdr.GetOrdinal("DingDanStatus"));
                  info.FuKuanStatus = (EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus)rdr.GetByte(rdr.GetOrdinal("FuKuanStatus"));
                  info.KeRenName = rdr["KeRenName"].ToString();
                  info.ShangJiDaiLiShangHuiYuanId = rdr["ShangJiDaiLiShangHuiYuanId"].ToString();
                  info.ShangJiDaiLiShangId = rdr["ShangJiDaiLiShangId"].ToString();
                  info.XiaDanRenName = rdr["XiaDanRenName"].ToString();
                  info.XiaDanShiJian = rdr.GetDateTime(rdr.GetOrdinal("XiaDanShiJian"));
                  info.XianDanRenId = rdr["XianDanRenId"].ToString();
                  info.DaiLiShangHuiYuanId = rdr["DaiLiShangHuiYuanId"].ToString();
                  info.JiangLiBi = rdr.IsDBNull(rdr.GetOrdinal("JiangLiBiLi")) ? 0 : rdr.GetDecimal(rdr.GetOrdinal("JiangLiBiLi"));

                  items.Add(info);
              }
          }

          return items;
      }

       /// <summary>
       /// 设置上级代理商，返回1成功，其它失败
       /// </summary>
       /// <param name="huiYuanId">会员编号（需要设定上级代理商的会员编号）</param>
       /// <param name="shangJiDaiLiShangId">上级代理商编号</param>
       /// <returns></returns>
      public int SheZhiShangJiDaiLiShang(string huiYuanId, string shangJiDaiLiShangId)
      {
          DbCommand cmd = _db.GetStoredProcCommand("proc_HuiYuan_SheZhiShangJiDaiLiShang");

          _db.AddInParameter(cmd, "@HuiYuanId", DbType.AnsiStringFixedLength, huiYuanId);
          _db.AddInParameter(cmd, "@ShangJiDaiLiShangId", DbType.AnsiStringFixedLength, shangJiDaiLiShangId);
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
       /// 获取下级代理数量
       /// </summary>
       /// <param name="huiYuanId">会员编号</param>
       /// <returns></returns>
      public int GetXiaJiDaiLiShuLiang(string huiYuanId)
      {
          var cmd = _db.GetSqlStringCommand("SELECT COUNT(*) FROM tbl_Member WHERE ShangJiDaiLiShangHuiYuanId=@HuiYuanId");
          _db.AddInParameter(cmd, "HuiYuanId", DbType.AnsiStringFixedLength, huiYuanId);
          int shuLiang = 0;

          using (var rdr = DbHelper.ExecuteReader(cmd, _db))
          {
              if (rdr.Read())
              {
                  shuLiang = rdr.GetInt32(0);
              }
          }

          return shuLiang;
      }

       /// <summary>
       /// 获取会员代理商信息
       /// </summary>
       /// <param name="huiYuanId">会员编号</param>
       /// <returns></returns>
      public EyouSoft.Model.MHuiYuanDaiLiShangInfo GetHuiYuanDaiLiShangInfoByHuiYuanId(string huiYuanId)
      {
          EyouSoft.Model.MHuiYuanDaiLiShangInfo info = null;
          var cmd = _db.GetSqlStringCommand("SELECT Id,MemberId FROM tbl_JA_Sellers WHERE MemberId=@HuiYuanId");
          _db.AddInParameter(cmd, "HuiYuanId", DbType.AnsiStringFixedLength, huiYuanId);

          using (var rdr = DbHelper.ExecuteReader(cmd, _db))
          {
              if (rdr.Read())
              {
                  info = new EyouSoft.Model.MHuiYuanDaiLiShangInfo();
                  info.HuiYuanId = huiYuanId;
                  info.DaiLiShangId = rdr["Id"].ToString();
              }
          }

          return info;
      }

      /// <summary>
      /// 获取会员代理商信息
      /// </summary>
      /// <param name="daiLiShangId">代理商编号</param>
      /// <returns></returns>
      public EyouSoft.Model.MHuiYuanDaiLiShangInfo GetHuiYuanDaiLiShangInfoByDaiLiShangId(string daiLiShangId)
      {
          EyouSoft.Model.MHuiYuanDaiLiShangInfo info = null;
          var cmd = _db.GetSqlStringCommand("SELECT Id,MemberId FROM tbl_JA_Sellers WHERE Id=@DaiLiShangId");
          _db.AddInParameter(cmd, "DaiLiShangId", DbType.AnsiStringFixedLength, daiLiShangId);

          using (var rdr = DbHelper.ExecuteReader(cmd, _db))
          {
              if (rdr.Read())
              {
                  info = new EyouSoft.Model.MHuiYuanDaiLiShangInfo();
                  info.HuiYuanId = rdr["MemberId"].ToString();
                  info.DaiLiShangId = daiLiShangId;                  
              }
          }

          return info;
      }
      #endregion
   }
}
