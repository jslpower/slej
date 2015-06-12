using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit.DAL;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.Model.SystemStructure;
namespace EyouSoft.DAL.SystemStructure
{
    public class DSupplier : DALBase, EyouSoft.IDAL.SystemStructure.ISupplier
    {
        #region 初始化db

        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DSupplier()
        {
            _db = base.SystemStore;
        }

        #endregion


        /// <summary>
        /// 验证用户名是否存在
        /// </summary>
        /// <param name="accountName">用户名</param>
        /// <returns></returns>
        public bool ExistsName(string accountName)
        {
            var strSql = new StringBuilder();
            strSql.Append(" select count(Id) from tbl_Supplier where SuppName = @SuppName ");
            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dc, "SuppName", DbType.String, accountName);

            object obj = DbHelper.GetSingle(dc, _db);
            if (obj == null) return false;

            if (Toolkit.Utils.GetInt(obj.ToString()) > 0) return true;

            return false;
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        public int Insert(MSupplier model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO tbl_Supplier (ID,SupplierType,CardPath,AccountPaht,VisitPath,OtherPath,FormPath,IssueTime,OperatorID,OperatorName,SupplierName,Qualifications,SuppULR,SuppAddress,MapX,MapY,ContactName,ContactPhone,ContactMobile,ContactQQ,ContactMail,SuppName,SuppPwd)     VALUES           (@ID,@SupplierType,@CardPath,@AccountPaht,@VisitPath,@OtherPath,@FormPath,@IssueTime,@OperatorID,@OperatorName,@SupplierName,@Qualifications,@SuppULR,@SuppAddress,@MapX,@MapY,@ContactName,@ContactPhone,@ContactMobile,@ContactQQ,@ContactMail,@SuppName,@SuppPwd)");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ID", System.Data.DbType.AnsiStringFixedLength, model.ID);
            this._db.AddInParameter(cmd, "SupplierType", System.Data.DbType.Byte, (byte)model.SupplierType);
            this._db.AddInParameter(cmd, "CardPath", System.Data.DbType.String, model.CardPath);
            this._db.AddInParameter(cmd, "AccountPaht", System.Data.DbType.String, model.AccountPaht);
            this._db.AddInParameter(cmd, "VisitPath", System.Data.DbType.String, model.VisitPath);
            this._db.AddInParameter(cmd, "OtherPath", System.Data.DbType.String, model.OtherPath);
            this._db.AddInParameter(cmd, "FormPath", System.Data.DbType.String, model.FormPath);
            this._db.AddInParameter(cmd, "IssueTime", System.Data.DbType.DateTime, model.IssueTime);
            this._db.AddInParameter(cmd, "OperatorID", System.Data.DbType.AnsiStringFixedLength, model.OperatorID);
            this._db.AddInParameter(cmd, "OperatorName", System.Data.DbType.String, model.OperatorName);
            this._db.AddInParameter(cmd, "SupplierName", System.Data.DbType.String, model.SupplierName);
            this._db.AddInParameter(cmd, "Qualifications", System.Data.DbType.String, model.Qualifications);
            this._db.AddInParameter(cmd, "SuppULR", System.Data.DbType.String, model.SuppULR);
            this._db.AddInParameter(cmd, "SuppAddress", System.Data.DbType.String, model.SuppAddress);
            this._db.AddInParameter(cmd, "MapX", System.Data.DbType.String, model.MapX);
            this._db.AddInParameter(cmd, "MapY", System.Data.DbType.String, model.MapY);
            this._db.AddInParameter(cmd, "ContactName", System.Data.DbType.String, model.ContactName);
            this._db.AddInParameter(cmd, "ContactPhone", System.Data.DbType.String, model.ContactPhone);
            this._db.AddInParameter(cmd, "ContactMobile", System.Data.DbType.String, model.ContactMobile);
            this._db.AddInParameter(cmd, "ContactQQ", System.Data.DbType.String, model.ContactQQ);
            this._db.AddInParameter(cmd, "ContactMail", System.Data.DbType.String, model.ContactMail);
            this._db.AddInParameter(cmd, "SuppName", System.Data.DbType.String, model.SuppName);
            this._db.AddInParameter(cmd, "SuppPwd", System.Data.DbType.String, model.SuppPwd);

            return DbHelper.ExecuteSql(cmd, this._db);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(MSupplier model)
        {
            StringBuilder strSql = new StringBuilder();
            if (!string.IsNullOrEmpty(model.SuppPwd))
            {
                strSql.Append("UPDATE tbl_Webmaster   SET  Password = @SuppPwd,MD5Password=@MD5Password WHERE GysId=@ID;");
            }
            strSql.Append("UPDATE tbl_Supplier   SET  SupplierType = @SupplierType,CardPath = @CardPath,AccountPaht = @AccountPaht,VisitPath = @VisitPath,OtherPath = @OtherPath,FormPath = @FormPath      ,SupplierName = @SupplierName,Qualifications = @Qualifications,SuppULR = @SuppULR,SuppAddress = @SuppAddress,MapX = @MapX,MapY = @MapY,ContactName = @ContactName,ContactPhone = @ContactPhone,ContactMobile = @ContactMobile,ContactQQ = @ContactQQ,ContactMail = @ContactMail");
            if (!string.IsNullOrEmpty(model.SuppPwd))
            {
                strSql.Append(" ,SuppPwd=@SuppPwd ");
            }
            strSql.Append(" WHERE ID =@ID ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ID", System.Data.DbType.AnsiStringFixedLength, model.ID);
            this._db.AddInParameter(cmd, "SupplierType", System.Data.DbType.Byte, (byte)model.SupplierType);
            this._db.AddInParameter(cmd, "CardPath", System.Data.DbType.String, model.CardPath);
            this._db.AddInParameter(cmd, "AccountPaht", System.Data.DbType.String, model.AccountPaht);
            this._db.AddInParameter(cmd, "VisitPath", System.Data.DbType.String, model.VisitPath);
            this._db.AddInParameter(cmd, "OtherPath", System.Data.DbType.String, model.OtherPath);
            this._db.AddInParameter(cmd, "FormPath", System.Data.DbType.String, model.FormPath);
            this._db.AddInParameter(cmd, "SupplierName", System.Data.DbType.String, model.SupplierName);
            this._db.AddInParameter(cmd, "Qualifications", System.Data.DbType.String, model.Qualifications);
            this._db.AddInParameter(cmd, "SuppULR", System.Data.DbType.String, model.SuppULR);
            this._db.AddInParameter(cmd, "SuppAddress", System.Data.DbType.String, model.SuppAddress);
            this._db.AddInParameter(cmd, "MapX", System.Data.DbType.String, model.MapX);
            this._db.AddInParameter(cmd, "MapY", System.Data.DbType.String, model.MapY);
            this._db.AddInParameter(cmd, "ContactName", System.Data.DbType.String, model.ContactName);
            this._db.AddInParameter(cmd, "ContactPhone", System.Data.DbType.String, model.ContactPhone);
            this._db.AddInParameter(cmd, "ContactMobile", System.Data.DbType.String, model.ContactMobile);
            this._db.AddInParameter(cmd, "ContactQQ", System.Data.DbType.String, model.ContactQQ);
            this._db.AddInParameter(cmd, "ContactMail", System.Data.DbType.String, model.ContactMail);
            if (!string.IsNullOrEmpty(model.SuppPwd))
            {
                this._db.AddInParameter(cmd, "SuppPwd", System.Data.DbType.String, model.SuppPwd);
                this._db.AddInParameter(cmd, "MD5Password", System.Data.DbType.String, new EyouSoft.Toolkit.DataProtection.HashCrypto().MD5Encrypt(model.SuppPwd));

            }

            return DbHelper.ExecuteSql(cmd, this._db);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="LinkID"></param>
        /// <returns></returns>
        public int Delete(string supplierID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM  tbl_Supplier WHERE ID=@ID");
            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(dc, "ID", System.Data.DbType.AnsiStringFixedLength, supplierID);
            return DbHelper.ExecuteSql(dc, _db) > 0 ? 1 : 0;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="LinkID"></param>
        /// <returns></returns>
        public MSupplier GetModel(string supplierID)
        {
            MSupplier model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT SupplierType,CardPath,AccountPaht,VisitPath,OtherPath,FormPath,IssueTime,OperatorID,OperatorName,SupplierName,Qualifications,SuppULR,SuppAddress,MapX,MapY,ContactName,ContactPhone,ContactMobile,ContactQQ,ContactMail,SuppName,SuppPwd  FROM tbl_Supplier  WHERE ID=@ID ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ID", System.Data.DbType.AnsiStringFixedLength, supplierID);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new MSupplier();
                    model.ID = supplierID;
                    model.SupplierType = (EyouSoft.Model.Enum.SupplierType)dr.GetByte(dr.GetOrdinal("SupplierType"));
                    model.CardPath = dr.IsDBNull(dr.GetOrdinal("CardPath")) ? "" : dr.GetString(dr.GetOrdinal("CardPath"));
                    model.AccountPaht = dr.IsDBNull(dr.GetOrdinal("AccountPaht")) ? "" : dr.GetString(dr.GetOrdinal("AccountPaht"));
                    model.VisitPath = dr.IsDBNull(dr.GetOrdinal("VisitPath")) ? "" : dr.GetString(dr.GetOrdinal("VisitPath"));
                    model.OtherPath = dr.IsDBNull(dr.GetOrdinal("OtherPath")) ? "" : dr.GetString(dr.GetOrdinal("OtherPath"));
                    model.FormPath = dr.IsDBNull(dr.GetOrdinal("FormPath")) ? "" : dr.GetString(dr.GetOrdinal("FormPath"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.OperatorID = dr.GetString(dr.GetOrdinal("OperatorID"));
                    model.OperatorName = dr.GetString(dr.GetOrdinal("OperatorName"));
                    model.SupplierName = dr.GetString(dr.GetOrdinal("SupplierName"));
                    model.Qualifications = dr.GetString(dr.GetOrdinal("Qualifications"));
                    model.SuppULR = dr.GetString(dr.GetOrdinal("SuppULR"));
                    model.SuppAddress = dr.GetString(dr.GetOrdinal("SuppAddress"));
                    model.MapX = dr.GetString(dr.GetOrdinal("MapX"));
                    model.MapY = dr.GetString(dr.GetOrdinal("MapY"));
                    model.ContactName = dr.GetString(dr.GetOrdinal("ContactName"));
                    model.ContactPhone = dr.GetString(dr.GetOrdinal("ContactPhone"));
                    model.ContactMobile = dr.GetString(dr.GetOrdinal("ContactMobile"));
                    model.ContactQQ = dr.GetString(dr.GetOrdinal("ContactQQ"));
                    model.ContactMail = dr.GetString(dr.GetOrdinal("ContactMail"));
                    model.SuppName = dr.GetString(dr.GetOrdinal("SuppName"));
                    model.SuppPwd = dr.GetString(dr.GetOrdinal("SuppPwd"));
                }
            }

            return model;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="LinkID"></param>
        /// <returns></returns>
        public MSupplier GetSupplierModel(string supplierName)
        {
            MSupplier model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ID,SupplierType,CardPath,AccountPaht,VisitPath,OtherPath,FormPath,IssueTime,OperatorID,OperatorName,SupplierName,Qualifications,SuppULR,SuppAddress,MapX,MapY,ContactName,ContactPhone,ContactMobile,ContactQQ,ContactMail,SuppName,SuppPwd  FROM tbl_Supplier  WHERE SuppName=@SuppName ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "SuppName", System.Data.DbType.AnsiStringFixedLength, supplierName);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new MSupplier();
                    model.ID = dr.GetString(dr.GetOrdinal("ID"));
                    model.SupplierType = (EyouSoft.Model.Enum.SupplierType)dr.GetByte(dr.GetOrdinal("SupplierType"));
                    model.CardPath = dr.IsDBNull(dr.GetOrdinal("CardPath")) ? "" : dr.GetString(dr.GetOrdinal("CardPath"));
                    model.AccountPaht = dr.IsDBNull(dr.GetOrdinal("AccountPaht")) ? "" : dr.GetString(dr.GetOrdinal("AccountPaht"));
                    model.VisitPath = dr.IsDBNull(dr.GetOrdinal("VisitPath")) ? "" : dr.GetString(dr.GetOrdinal("VisitPath"));
                    model.OtherPath = dr.IsDBNull(dr.GetOrdinal("OtherPath")) ? "" : dr.GetString(dr.GetOrdinal("OtherPath"));
                    model.FormPath = dr.IsDBNull(dr.GetOrdinal("FormPath")) ? "" : dr.GetString(dr.GetOrdinal("FormPath"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.OperatorID = dr.GetString(dr.GetOrdinal("OperatorID"));
                    model.OperatorName = dr.GetString(dr.GetOrdinal("OperatorName"));
                    model.SupplierName = dr.GetString(dr.GetOrdinal("SupplierName"));
                    model.Qualifications = dr.GetString(dr.GetOrdinal("Qualifications"));
                    model.SuppULR = dr.GetString(dr.GetOrdinal("SuppULR"));
                    model.SuppAddress = dr.GetString(dr.GetOrdinal("SuppAddress"));
                    model.MapX = dr.GetString(dr.GetOrdinal("MapX"));
                    model.MapY = dr.GetString(dr.GetOrdinal("MapY"));
                    model.ContactName = dr.GetString(dr.GetOrdinal("ContactName"));
                    model.ContactPhone = dr.GetString(dr.GetOrdinal("ContactPhone"));
                    model.ContactMobile = dr.GetString(dr.GetOrdinal("ContactMobile"));
                    model.ContactQQ = dr.GetString(dr.GetOrdinal("ContactQQ"));
                    model.ContactMail = dr.GetString(dr.GetOrdinal("ContactMail"));
                    model.SuppName = dr.GetString(dr.GetOrdinal("SuppName"));
                    model.SuppPwd = dr.GetString(dr.GetOrdinal("SuppPwd"));
                }
            }

            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <returns></returns>
        public IList<MSupplier> GetList(int pageSize, int pageIndex, ref int recordCount, MSupplierSer serch)
        {
            IList<MSupplier> list = new List<MSupplier>();


            string tableName = "tbl_Supplier";
            string fileds = "ID,SupplierType,CardPath,AccountPaht,VisitPath,OtherPath,FormPath,IssueTime,OperatorID,OperatorName,SupplierName,Qualifications,SuppULR,SuppAddress,MapX,MapY,ContactName,ContactPhone,ContactMobile,ContactQQ,ContactMail,SuppName,SuppPwd   ";
            string orderByString = "Issuetime desc";

            StringBuilder query = new StringBuilder();
            query.Append(" 1=1 ");
            if (serch != null)
            {
                if (!string.IsNullOrEmpty(serch.SupplierName)) query.AppendFormat("  and  SupplierName like '%{0}%'", serch.SupplierName);
                if (!string.IsNullOrEmpty(serch.SupplierMoblie)) query.AppendFormat("  and  ContactMobile like '%{0}%'", serch.SupplierMoblie);
            }

            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref recordCount, tableName, fileds, query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {
                    MSupplier model = new MSupplier();
                    model.ID = dr.GetString(dr.GetOrdinal("ID"));
                    model.SupplierType = (EyouSoft.Model.Enum.SupplierType)dr.GetByte(dr.GetOrdinal("SupplierType"));
                    model.CardPath = dr.IsDBNull(dr.GetOrdinal("CardPath")) ? "" : dr.GetString(dr.GetOrdinal("CardPath"));
                    model.AccountPaht = dr.IsDBNull(dr.GetOrdinal("AccountPaht")) ? "" : dr.GetString(dr.GetOrdinal("AccountPaht"));
                    model.VisitPath = dr.IsDBNull(dr.GetOrdinal("VisitPath")) ? "" : dr.GetString(dr.GetOrdinal("VisitPath"));
                    model.OtherPath = dr.IsDBNull(dr.GetOrdinal("OtherPath")) ? "" : dr.GetString(dr.GetOrdinal("OtherPath"));
                    model.FormPath = dr.IsDBNull(dr.GetOrdinal("FormPath")) ? "" : dr.GetString(dr.GetOrdinal("FormPath"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.OperatorID = dr.GetString(dr.GetOrdinal("OperatorID"));
                    model.OperatorName = dr.GetString(dr.GetOrdinal("OperatorName"));
                    model.SupplierName = dr.GetString(dr.GetOrdinal("SupplierName"));
                    model.Qualifications = dr.GetString(dr.GetOrdinal("Qualifications"));
                    model.SuppULR = dr.GetString(dr.GetOrdinal("SuppULR"));
                    model.SuppAddress = dr.GetString(dr.GetOrdinal("SuppAddress"));
                    model.MapX = dr.GetString(dr.GetOrdinal("MapX"));
                    model.MapY = dr.GetString(dr.GetOrdinal("MapY"));
                    model.ContactName = dr.GetString(dr.GetOrdinal("ContactName"));
                    model.ContactPhone = dr.GetString(dr.GetOrdinal("ContactPhone"));
                    model.ContactMobile = dr.GetString(dr.GetOrdinal("ContactMobile"));
                    model.ContactQQ = dr.GetString(dr.GetOrdinal("ContactQQ"));
                    model.ContactMail = dr.GetString(dr.GetOrdinal("ContactMail"));
                    model.SuppName = dr.GetString(dr.GetOrdinal("SuppName"));
                    model.SuppPwd = dr.GetString(dr.GetOrdinal("SuppPwd"));

                    list.Add(model);
                }
            }
            return list;
        }

    }
}
