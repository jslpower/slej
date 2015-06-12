using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit.DAL;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.Model.WeiXin;

namespace EyouSoft.DAL.WeiXin
{
    public class DWeiXin : DALBase, EyouSoft.IDAL.WeiXin.IDWeiXin
    {
        #region 初始化db

        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DWeiXin()
        {
            _db = base.SystemStore;
        }

        #endregion



        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        public int Insert(MWinXin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO tbl_WeiXinBind ( OpenID , MemberID , MemberName , AccountNum , ShopUrl , BindTime , NickName ) VALUES ( @OpenID , @MemberID , @MemberName , @AccountNum , @ShopUrl , @BindTime , @NickName)");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "OpenID", System.Data.DbType.String, model.OpenID);
            this._db.AddInParameter(cmd, "MemberID", System.Data.DbType.AnsiStringFixedLength, model.MemberID);
            this._db.AddInParameter(cmd, "MemberName", System.Data.DbType.String, model.MemberName);
            this._db.AddInParameter(cmd, "AccountNum", System.Data.DbType.String, model.AccountNum);
            this._db.AddInParameter(cmd, "ShopUrl", System.Data.DbType.String, model.ShopUrl);
            this._db.AddInParameter(cmd, "BindTime", System.Data.DbType.DateTime, model.BindTime);
            this._db.AddInParameter(cmd, "NickName", System.Data.DbType.String, model.NickName);


            return DbHelper.ExecuteSql(cmd, this._db);

        }





        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public MWinXin GetModel(string openid)
        {
            MWinXin model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  id       , OpenID       , MemberID       , MemberName       , AccountNum       , ShopUrl       , BindTime       , NickName   FROM   tbl_WeiXinBind  WHERE OpenID=@OpenID ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "OpenID", System.Data.DbType.AnsiStringFixedLength, openid);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new MWinXin();
                    model.id = dr.GetInt32(dr.GetOrdinal("id"));
                    model.OpenID = dr.GetString(dr.GetOrdinal("OpenID"));
                    model.MemberID = dr.GetString(dr.GetOrdinal("MemberID"));
                    model.MemberName = dr.GetString(dr.GetOrdinal("MemberName"));
                    model.AccountNum = dr.GetString(dr.GetOrdinal("AccountNum"));
                    model.ShopUrl = dr.GetString(dr.GetOrdinal("ShopUrl"));
                    model.BindTime = dr.GetDateTime(dr.GetOrdinal("BindTime"));
                    model.NickName = dr.GetString(dr.GetOrdinal("NickName"));

                }
            }

            return model;
        }


    }
}
