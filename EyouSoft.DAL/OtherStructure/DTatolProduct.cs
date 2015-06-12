using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.OtherStructure;
using EyouSoft.Toolkit.DAL;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.Toolkit;
using System.Xml.Linq;

namespace EyouSoft.DAL.OtherStructure
{
    public class DTatolProduct : EyouSoft.Toolkit.DAL.DALBase, EyouSoft.IDAL.OtherStructure.ITatolProduct
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
        public DTatolProduct()
        {
            _db = SystemStore;
        }
        #endregion

        #region 积分产品

        /// <summary>
        /// 得到会员累计积分
        /// </summary>
        /// <param name="MemberID">会员ID</param>
        /// <returns></returns>
        public MTatolProduct GetMemberTatal(string MemberID)
        {
            MTatolProduct model = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  SUM(Total) as SumTotal");
            strSql.Append(",(select SUM(Total) from tbl_TotalToProduct where MemberID=@MemberID) as ExchangeTotal");
            strSql.Append(" FROM tbl_MemberTotal WHERE MemberId=@MemberID");
            DbCommand dc = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(dc, "MemberID", DbType.AnsiStringFixedLength, MemberID);
            using (IDataReader dr = EyouSoft.Toolkit.DAL.DbHelper.ExecuteReader(dc, this._db))
            {
                if (dr.Read())
                {
                    model = new MTatolProduct();
                    model.SumTotal = dr.IsDBNull(dr.GetOrdinal("SumTotal")) ? 0 : dr.GetInt32(dr.GetOrdinal("SumTotal"));
                    model.ExchangeTotal = dr.IsDBNull(dr.GetOrdinal("ExchangeTotal")) ? 0 : dr.GetInt32(dr.GetOrdinal("ExchangeTotal"));
                }
            };
            return model;
        }

        /// <summary>
        /// 增加一个积分产品
        /// </summary>
        public bool AddProduct(MTatolProduct model)
        {
            bool IsTrue = false;
            DbCommand dc = this._db.GetStoredProcCommand("proc_TatolProduct_Add");
            this._db.AddInParameter(dc, "ProductName", DbType.String, model.ProductName);
            this._db.AddInParameter(dc, "ProductClass", DbType.Byte, (int)model.ProductClass);
            this._db.AddInParameter(dc, "Num", DbType.Int32, model.Num);
            this._db.AddInParameter(dc, "Total", DbType.Int32, model.Total);
            this._db.AddInParameter(dc, "Price", DbType.Decimal, model.Price);
            this._db.AddInParameter(dc, "ProductInfo", DbType.String, model.ProductInfo);
            this._db.AddInParameter(dc, "OperatorId", DbType.AnsiStringFixedLength, model.OperatorId);
            this._db.AddInParameter(dc, "PicXML", DbType.Xml, CreatePicListToXML(model.PicList));
            this._db.AddOutParameter(dc, "Result", DbType.Int32, 4);
            DbHelper.RunProcedure(dc, this._db);
            object Result = this._db.GetParameterValue(dc, "Result");
            if (!Result.Equals(null))
            {
                IsTrue = int.Parse(Result.ToString()) > 0 ? true : false;
            }
            return IsTrue;
        }
        /// <summary>
        /// 更新一个积分产品
        /// </summary>
        public bool UpdateProduct(MTatolProduct model)
        {
            bool IsTrue = false;
            DbCommand dc = this._db.GetStoredProcCommand("proc_TatolProduct_Update");
            this._db.AddInParameter(dc, "ProductID", DbType.Int32, model.ProductID);
            this._db.AddInParameter(dc, "ProductName", DbType.String, model.ProductName);
            this._db.AddInParameter(dc, "ProductClass", DbType.Byte, (int)model.ProductClass);
            this._db.AddInParameter(dc, "Num", DbType.Int32, model.Num);
            this._db.AddInParameter(dc, "Total", DbType.Int32, model.Total);
            this._db.AddInParameter(dc, "Price", DbType.Decimal, model.Price);
            this._db.AddInParameter(dc, "ProductInfo", DbType.String, model.ProductInfo);
            this._db.AddInParameter(dc, "OperatorId", DbType.AnsiStringFixedLength, model.OperatorId);
            this._db.AddInParameter(dc, "PicXML", DbType.Xml, CreatePicListToXML(model.PicList));
            this._db.AddOutParameter(dc, "Result", DbType.Int32, 4);
            DbHelper.RunProcedure(dc, this._db);
            object Result = this._db.GetParameterValue(dc, "Result");
            if (!Result.Equals(null))
            {
                IsTrue = int.Parse(Result.ToString()) > 0 ? true : false;
            }
            return IsTrue;
        }
        /// <summary>
        /// 批量删除积分产品
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool DeleteProduct(params string[] ids)
        {
            StringBuilder StrSql = new StringBuilder();
            foreach (var id in ids)
            {
                if (id != null && Utils.GetInt(id) > 0)
                {
                    StrSql.AppendFormat(" DELETE FROM tbl_TatolProduct WHERE ProductID={0} ", id);
                    StrSql.AppendFormat(" DELETE FROM tbl_TatolProductPic WHERE ProductID={0} ", id);
                }
            }
            DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
            return EyouSoft.Toolkit.DAL.DbHelper.ExecuteSqlTrans(dc, this._db) > 0 ? true : false;
        }
        /// <summary>
        /// 得到一个积分产品
        /// </summary>
        /// <param name="id">产品编号</param>
        /// <param name="MemberID">会员编号</param>
        /// <returns></returns>
        public MTatolProduct GetProductModel(int id, string MemberID)
        {
            MTatolProduct model = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [ProductID],[ProductName],[ProductClass],[Num],[Total],[Price],[ProductInfo],[IssueTime],[OperatorId]");
            strSql.Append(",(SELECT PicID,ProductID,FilePath,[Desc] FROM tbl_TatolProductPic WHERE ProductID=@ProductID FOR XML RAW,ROOT('ROOT')) AS PicXml ");
            if (!string.IsNullOrEmpty(MemberID))
            {
                strSql.Append(",(select SUM(Total) from tbl_MemberTotal where MemberID=@MemberID) as SumTotal");
                strSql.Append(",(select SUM(Total) from tbl_TotalToProduct where MemberID=@MemberID) as ExchangeTotal");
            }
            strSql.Append(",(select SUM(Num) from tbl_TotalToProduct where ProductID=@ProductID) as ExchangeNum");
            strSql.Append(",(select top 1 RealName from tbl_Webmaster where Id=tbl_TatolProduct.OperatorId) as OperatorName ");
            strSql.Append(" FROM tbl_TatolProduct WHERE ProductID=@ProductID");
            DbCommand dc = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(dc, "ProductID", DbType.Int32, id);
            if (!string.IsNullOrEmpty(MemberID))
            {
                this._db.AddInParameter(dc, "MemberID", DbType.AnsiStringFixedLength, MemberID);
            }
            using (IDataReader dr = EyouSoft.Toolkit.DAL.DbHelper.ExecuteReader(dc, this._db))
            {
                if (dr.Read())
                {
                    model = new MTatolProduct();
                    model.ProductID = dr.GetInt32(dr.GetOrdinal("ProductID"));
                    model.ProductName = dr["ProductName"].ToString();
                    model.ProductClass = (EyouSoft.Model.Enum.ProductClass)dr.GetByte(dr.GetOrdinal("ProductClass"));
                    model.Num = dr.GetInt32(dr.GetOrdinal("Num"));
                    model.Total = dr.GetInt32(dr.GetOrdinal("Total"));
                    model.Price = dr.GetDecimal(dr.GetOrdinal("Price"));
                    model.ProductInfo = dr["ProductInfo"].ToString();
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.OperatorId = dr["OperatorId"].ToString();
                    if (!string.IsNullOrEmpty(MemberID))
                    {
                        model.SumTotal = dr.IsDBNull(dr.GetOrdinal("SumTotal")) ? 0 : dr.GetInt32(dr.GetOrdinal("SumTotal"));
                        model.ExchangeTotal = dr.IsDBNull(dr.GetOrdinal("ExchangeTotal")) ? 0 : dr.GetInt32(dr.GetOrdinal("ExchangeTotal"));
                    }
                    model.ExchangeNum = !dr.IsDBNull(dr.GetOrdinal("ExchangeNum")) ? dr.GetInt32(dr.GetOrdinal("ExchangeNum")) : 0;
                    model.OperatorName = dr["OperatorName"].ToString();
                    model.PicList = GetPicXMLToList(dr["PicXml"].ToString());
                }
            };
            return model;
        }
        /// <summary>
        /// 获得积分产品列表集合，分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        public IList<MTatolProduct> GetProductList(int pageSize, int pageIndex, ref int recordCount, MTatolProductCX chaXun)
        {
            IList<MTatolProduct> ResultList = null;
            string tableName = "tbl_TatolProduct";
            StringBuilder fields = new StringBuilder();
            fields.Append("[ProductID],[ProductName],[ProductClass],[Num],[Total],[Price],[ProductInfo],[IssueTime],[OperatorId]");
            //fields.Append(",(SELECT PicID,ProductID,FilePath,[Desc] FROM tbl_TatolProductPic WHERE ProductID=tbl_TatolProduct.ProductID FOR XML RAW,ROOT('ROOT')) AS PicXml ");
            fields.Append(",(SELECT top 1 FilePath FROM tbl_TatolProductPic WHERE ProductID=tbl_TatolProduct.ProductID) AS FilePath ");
            fields.Append(",(select SUM(Num) from tbl_TotalToProduct where ProductID=tbl_TatolProduct.ProductID) as ExchangeNum");
            fields.Append(",(select top 1 RealName from tbl_Webmaster where Id=tbl_TatolProduct.OperatorId) as OperatorName ");
            string query = " 1=1 ";
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.ProductName))
                {
                    query = query + string.Format(" AND ProductName like '%{0}%'", chaXun.ProductName);
                }
                if (chaXun.ProductClass.HasValue)
                {
                    query = query + string.Format(" AND ProductClass={0}", (int)chaXun.ProductClass);
                }
                if (chaXun.TotalS > 0)
                {
                    query = query + string.Format(" AND Total>={0}", chaXun.TotalS);
                }
                if (chaXun.TotalE > 0)
                {
                    query = query + string.Format(" AND Total<={0}", chaXun.TotalE);
                }
                if (chaXun.IssueTimeS.HasValue)
                {
                    query = query + string.Format(" AND IssueTime>='{0}' ", chaXun.IssueTimeS.Value.ToShortDateString() + " 00:00:00");
                }
                if (chaXun.IssueTimeE.HasValue)
                {
                    query = query + string.Format(" AND IssueTime<='{0}' ", chaXun.IssueTimeE.Value.ToShortDateString() + " 23:59:59");
                }
            }
            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), query, "IssueTime DESC", null))
            {
                ResultList = new List<MTatolProduct>();
                while (dr.Read())
                {
                    MTatolProduct model = new MTatolProduct();
                    model.ProductID = dr.GetInt32(dr.GetOrdinal("ProductID"));
                    model.ProductName = dr["ProductName"].ToString();
                    model.ProductClass = (EyouSoft.Model.Enum.ProductClass)dr.GetByte(dr.GetOrdinal("ProductClass"));
                    model.Num = dr.GetInt32(dr.GetOrdinal("Num"));
                    model.Total = dr.GetInt32(dr.GetOrdinal("Total"));
                    model.Price = dr.GetDecimal(dr.GetOrdinal("Price"));
                    model.ProductInfo = dr["ProductInfo"].ToString();
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.OperatorId = dr["OperatorId"].ToString();
                    model.ExchangeNum = !dr.IsDBNull(dr.GetOrdinal("ExchangeNum")) ? dr.GetInt32(dr.GetOrdinal("ExchangeNum")) : 0;
                    model.OperatorName = dr["OperatorName"].ToString();
                    //model.PicList = GetPicXMLToList(dr["PicXml"].ToString());
                    model.Pic = dr["FilePath"].ToString();
                    ResultList.Add(model);
                    model = null;
                }
            };
            return ResultList;
        }
        /// <summary>
        /// 获得积分产品前几行数据集合
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        public IList<MTatolProduct> GetProductTopList(int Top, MTatolProductCX chaXun)
        {
            IList<MTatolProduct> ResultList = null;
            StringBuilder StrSql = new StringBuilder();
            StrSql.AppendFormat("SELECT {0} [ProductID],[ProductName],[ProductClass],[Num],[Total],[Price],[ProductInfo],[IssueTime],[OperatorId] ", (Top > 0 ? " TOP " + Top + " " : ""));
            //StrSql.Append(",(SELECT PicID,ProductID,FilePath,[Desc] FROM tbl_TatolProductPic WHERE ProductID=tbl_TatolProduct.ProductID FOR XML RAW,ROOT('ROOT')) AS PicXml ");
            StrSql.Append(",(SELECT top 1 FilePath FROM tbl_TatolProductPic WHERE ProductID=tbl_TatolProduct.ProductID) AS FilePath ");
            StrSql.Append(",(select SUM(Num) from tbl_TotalToProduct where ProductID=tbl_TatolProduct.ProductID) as ExchangeNum");
            StrSql.Append(",(select top 1 RealName from tbl_Webmaster where Id=tbl_TatolProduct.OperatorId) as OperatorName ");
            StrSql.Append(" FROM tbl_TatolProduct WHERE 1=1 ");
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.ProductName))
                {
                    StrSql.AppendFormat(" AND ProductName like '%{0}%'", chaXun.ProductName);
                }
                if (chaXun.ProductClass.HasValue)
                {
                    StrSql.AppendFormat(" AND ProductClass={0}", (int)chaXun.ProductClass);
                }
                if (chaXun.TotalS > 0)
                {
                    StrSql.AppendFormat(" AND Total>={0}", chaXun.TotalS);
                }
                if (chaXun.TotalE > 0)
                {
                    StrSql.AppendFormat(" AND Total<={0}", chaXun.TotalE);
                }
                if (chaXun.IssueTimeS.HasValue)
                {
                    StrSql.AppendFormat(" AND IssueTime>='{0}' ", chaXun.IssueTimeS.Value.ToShortDateString() + " 00:00:00");
                }
                if (chaXun.IssueTimeE.HasValue)
                {
                    StrSql.AppendFormat(" AND IssueTime<='{0}' ", chaXun.IssueTimeE.Value.ToShortDateString() + " 23:59:59");
                }
            }
            StrSql.Append(" ORDER BY IssueTime DESC ");
            DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
            using (IDataReader dr = EyouSoft.Toolkit.DAL.DbHelper.ExecuteReader(dc, this._db))
            {
                ResultList = new List<MTatolProduct>();
                while (dr.Read())
                {
                    MTatolProduct model = new MTatolProduct();
                    model.ProductID = dr.GetInt32(dr.GetOrdinal("ProductID"));
                    model.ProductName = dr["ProductName"].ToString();
                    model.ProductClass = (EyouSoft.Model.Enum.ProductClass)dr.GetByte(dr.GetOrdinal("ProductClass"));
                    model.Num = dr.GetInt32(dr.GetOrdinal("Num"));
                    model.Total = dr.GetInt32(dr.GetOrdinal("Total"));
                    model.Price = dr.GetDecimal(dr.GetOrdinal("Price"));
                    model.ProductInfo = dr["ProductInfo"].ToString();
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.OperatorId = dr["OperatorId"].ToString();
                    model.ExchangeNum = !dr.IsDBNull(dr.GetOrdinal("ExchangeNum")) ? dr.GetInt32(dr.GetOrdinal("ExchangeNum")) : 0;
                    model.OperatorName = dr["OperatorName"].ToString();
                    //model.PicList = GetPicXMLToList(dr["PicXml"].ToString());
                    model.Pic = dr["FilePath"].ToString();
                    ResultList.Add(model);
                    model = null;
                }
            }
            return ResultList;
        }
        #endregion

        #region 积分兑换信息
        /// <summary>
        /// 增加一条积分兑换信息
        /// </summary>
        public bool AddTotalToProduct(MTotalToProduct model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO tbl_TotalToProduct([MemberID],[ProductID],[Num],[Total],[Status])");
            strSql.Append(" VALUES(@MemberID,@ProductID,@Num,@Total,@Status)");
            DbCommand dc = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(dc, "MemberID", DbType.AnsiStringFixedLength, model.MemberID);
            this._db.AddInParameter(dc, "ProductID", DbType.Int32, model.ProductID);
            this._db.AddInParameter(dc, "Num", DbType.Int32, model.Num);
            this._db.AddInParameter(dc, "Total", DbType.Int32, model.Total);
            this._db.AddInParameter(dc, "Status", DbType.Byte, (int)model.Status);
            return DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
        }
        /// <summary>
        /// 更新一条积分兑换信息
        /// </summary>
        public bool UpdateTotalToProduct(MTotalToProduct model)
        {
            string strSql = "UPDATE tbl_TotalToProduct Set [Status]=@Status,[OperatorId]=@OperatorId,[IssueTime]=@IssueTime WHERE ID=@ID";
            DbCommand dc = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(dc, "ID", DbType.Int32, model.ID);
            this._db.AddInParameter(dc, "Status", DbType.Byte, (int)model.Status);
            this._db.AddInParameter(dc, "OperatorId", DbType.AnsiStringFixedLength, model.OperatorId);
            this._db.AddInParameter(dc, "IssueTime", DbType.DateTime, model.IssueTime);
            return DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
        }
        /// <summary>
        /// 批量删除积分兑换信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool DeleteTotalToProduct(params string[] ids)
        {
            StringBuilder StrSql = new StringBuilder();
            foreach (var id in ids)
            {
                if (id != null && Utils.GetInt(id) > 0)
                {
                    StrSql.AppendFormat(" DELETE FROM tbl_TotalToProduct WHERE ID={0} ", id);
                }
            }
            DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
            return EyouSoft.Toolkit.DAL.DbHelper.ExecuteSqlTrans(dc, this._db) > 0 ? true : false;
        }
        /// <summary>
        /// 得到一条积分兑换信息
        /// </summary>
        public MTotalToProduct GetTotalToProductModel(int id)
        {
            MTotalToProduct model = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [ID],[MemberID],[ProductID],[Num],[Total],[ExchangeTime],[Status],[OperatorId],[IssueTime]");
            strSql.Append(",(select top 1 ProductName from tbl_TatolProduct where ProductID=tbl_TotalToProduct.ProductID) as ProductName");
            strSql.Append(",(select top 1 Account from tbl_Member where MemberID=tbl_TotalToProduct.MemberID) as Account");
            strSql.Append(",(select top 1 MemberName from tbl_Member where MemberID=tbl_TotalToProduct.MemberID) as MemberName");
            strSql.Append(",(select top 1 RealName from tbl_Webmaster where Id=tbl_TotalToProduct.OperatorId) as OperatorName ");
            strSql.Append(" FROM tbl_TotalToProduct WHERE ID=@ID");
            DbCommand dc = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(dc, "ID", DbType.Int32, id);
            using (IDataReader dr = EyouSoft.Toolkit.DAL.DbHelper.ExecuteReader(dc, this._db))
            {
                if (dr.Read())
                {
                    model = new MTotalToProduct();
                    model.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    model.MemberID = dr["MemberID"].ToString();
                    model.ProductID = dr.GetInt32(dr.GetOrdinal("ProductID"));
                    model.Num = dr.GetInt32(dr.GetOrdinal("Num"));
                    model.Total = dr.GetInt32(dr.GetOrdinal("Total"));
                    model.ExchangeTime = dr.GetDateTime(dr.GetOrdinal("ExchangeTime"));
                    model.Status = (EyouSoft.Model.Enum.ExchangeStatus)dr.GetByte(dr.GetOrdinal("Status"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                    {
                        model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    }
                    model.OperatorId = dr["OperatorId"].ToString();
                    model.ProductName = dr["ProductName"].ToString();
                    model.Account = dr["Account"].ToString();
                    model.MemberName = dr["MemberName"].ToString();
                    model.OperatorName = dr["OperatorName"].ToString();
                }
            };
            return model;
        }
        /// <summary>
        /// 获得积分兑换信息列表集合，分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        public IList<MTotalToProduct> GetTotalToProductList(int pageSize, int pageIndex, ref int recordCount, MTotalToProductCX chaXun)
        {
            IList<MTotalToProduct> ResultList = null;
            string tableName = "tbl_TotalToProduct";
            StringBuilder fields = new StringBuilder();
            fields.Append("[ID],[MemberID],[ProductID],[Num],[Total],[ExchangeTime],[Status],[OperatorId],[IssueTime]");
            fields.Append(",(select top 1 ProductName from tbl_TatolProduct where ProductID=tbl_TotalToProduct.ProductID) as ProductName");
            fields.Append(",(select top 1 Account from tbl_Member where MemberID=tbl_TotalToProduct.MemberID) as Account");
            fields.Append(",(select top 1 MemberName from tbl_Member where MemberID=tbl_TotalToProduct.MemberID) as MemberName ");
            fields.Append(",(select top 1 RealName from tbl_Webmaster where Id=tbl_TotalToProduct.OperatorId) as OperatorName ");
            string query = " 1=1 ";
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.ProductName))
                {
                    query = query + string.Format(" AND exists(select 1 from tbl_TatolProduct where ProductID=tbl_TotalToProduct.ProductID and ProductName like '%{0}%') ", chaXun.ProductName);
                }
                if (!string.IsNullOrEmpty(chaXun.Account))
                {
                    query = query + string.Format(" AND exists(select 1 from tbl_Member where MemberID=tbl_TotalToProduct.MemberID and Account like '%{0}%') ", chaXun.Account);
                }
                if (!string.IsNullOrEmpty(chaXun.MemberName))
                {
                    query = query + string.Format(" AND exists(select 1 from tbl_Member where MemberID=tbl_TotalToProduct.MemberID and MemberName like '%{0}%') ", chaXun.MemberName);
                }
                if (chaXun.TotalS > 0)
                {
                    query = query + string.Format(" AND Total>={0}", chaXun.TotalS);
                }
                if (chaXun.TotalE > 0)
                {
                    query = query + string.Format(" AND Total<={0}", chaXun.TotalE);
                }
                if (chaXun.ExchangeTimeS.HasValue)
                {
                    query = query + string.Format(" AND ExchangeTime>='{0}' ", chaXun.ExchangeTimeS.Value.ToShortDateString() + " 00:00:00");
                }
                if (chaXun.ExchangeTimeE.HasValue)
                {
                    query = query + string.Format(" AND ExchangeTime<='{0}' ", chaXun.ExchangeTimeE.Value.ToShortDateString() + " 23:59:59");
                }
                if (chaXun.Status.HasValue)
                {
                    query = query + string.Format(" AND Status={0}", (int)chaXun.Status);
                }
                if (chaXun.IssueTimeS.HasValue)
                {
                    query = query + string.Format(" AND IssueTime>='{0}' ", chaXun.IssueTimeS.Value.ToShortDateString() + " 00:00:00");
                }
                if (chaXun.IssueTimeE.HasValue)
                {
                    query = query + string.Format(" AND IssueTime<='{0}' ", chaXun.IssueTimeE.Value.ToShortDateString() + " 23:59:59");
                }
            }
            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), query, "ExchangeTime DESC,IssueTime DESC", null))
            {
                ResultList = new List<MTotalToProduct>();
                while (dr.Read())
                {
                    MTotalToProduct model = new MTotalToProduct();
                    model.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    model.MemberID = dr["MemberID"].ToString();
                    model.ProductID = dr.GetInt32(dr.GetOrdinal("ProductID"));
                    model.Num = dr.GetInt32(dr.GetOrdinal("Num"));
                    model.Total = dr.GetInt32(dr.GetOrdinal("Total"));
                    model.ExchangeTime = dr.GetDateTime(dr.GetOrdinal("ExchangeTime"));
                    model.Status = (EyouSoft.Model.Enum.ExchangeStatus)dr.GetByte(dr.GetOrdinal("Status"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                    {
                        model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    }
                    model.OperatorId = dr["OperatorId"].ToString();
                    model.ProductName = dr["ProductName"].ToString();
                    model.Account = dr["Account"].ToString();
                    model.MemberName = dr["MemberName"].ToString();
                    model.OperatorName = dr["OperatorName"].ToString();
                    ResultList.Add(model);
                    model = null;
                }
            };
            return ResultList;
        }
        /// <summary>
        /// 获得积分兑换信息前几行数据集合
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        public IList<MTotalToProduct> GetTotalToProductTopList(int Top, MTotalToProductCX chaXun)
        {
            IList<MTotalToProduct> ResultList = null;
            StringBuilder StrSql = new StringBuilder();
            StrSql.AppendFormat("SELECT {0} [ID],[MemberID],[ProductID],[Num],[Total],[ExchangeTime],[Status],[OperatorId],[IssueTime] ", (Top > 0 ? " TOP " + Top + " " : ""));
            StrSql.Append(",(select top 1 ProductName from tbl_TatolProduct where ProductID=tbl_TotalToProduct.ProductID) as ProductName");
            StrSql.Append(",(select top 1 Account from tbl_Member where MemberID=tbl_TotalToProduct.MemberID) as Account");
            StrSql.Append(",(select top 1 MemberName from tbl_Member where MemberID=tbl_TotalToProduct.MemberID) as MemberName ");
            StrSql.Append(",(select top 1 RealName from tbl_Webmaster where Id=tbl_TotalToProduct.OperatorId) as OperatorName ");
            StrSql.Append(" FROM tbl_TotalToProduct WHERE 1=1 ");
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.ProductName))
                {
                    StrSql.AppendFormat(" AND exists(select 1 from tbl_TatolProduct where ProductID=tbl_TotalToProduct.ProductID and ProductName like '%{0}%') ", chaXun.ProductName);
                }
                if (!string.IsNullOrEmpty(chaXun.Account))
                {
                    StrSql.AppendFormat(" AND exists(select 1 from tbl_Member where MemberID=tbl_TotalToProduct.MemberID and Account like '%{0}%') ", chaXun.Account);
                }
                if (!string.IsNullOrEmpty(chaXun.MemberName))
                {
                    StrSql.AppendFormat(" AND exists(select 1 from tbl_Member where MemberID=tbl_TotalToProduct.MemberID and MemberName like '%{0}%') ", chaXun.MemberName);
                }
                if (chaXun.ExchangeTimeS.HasValue)
                {
                    StrSql.AppendFormat(" AND ExchangeTime>='{0}' ", chaXun.ExchangeTimeS.Value.ToShortDateString() + " 00:00:00");
                }
                if (chaXun.ExchangeTimeE.HasValue)
                {
                    StrSql.AppendFormat(" AND ExchangeTime<='{0}' ", chaXun.ExchangeTimeE.Value.ToShortDateString() + " 23:59:59");
                }
                if (chaXun.Status.HasValue)
                {
                    StrSql.AppendFormat(" AND Status={0}", (int)chaXun.Status);
                }
                if (chaXun.IssueTimeS.HasValue)
                {
                    StrSql.AppendFormat(" AND IssueTime>='{0}' ", chaXun.IssueTimeS.Value.ToShortDateString() + " 00:00:00");
                }
                if (chaXun.IssueTimeE.HasValue)
                {
                    StrSql.AppendFormat(" AND IssueTime<='{0}' ", chaXun.IssueTimeE.Value.ToShortDateString() + " 23:59:59");
                }
            }
            StrSql.Append(" ORDER BY ExchangeTime DESC,IssueTime DESC ");
            DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
            using (IDataReader dr = EyouSoft.Toolkit.DAL.DbHelper.ExecuteReader(dc, this._db))
            {
                ResultList = new List<MTotalToProduct>();
                while (dr.Read())
                {
                    MTotalToProduct model = new MTotalToProduct();
                    model.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    model.MemberID = dr["MemberID"].ToString();
                    model.ProductID = dr.GetInt32(dr.GetOrdinal("ProductID"));
                    model.Num = dr.GetInt32(dr.GetOrdinal("Num"));
                    model.Total = dr.GetInt32(dr.GetOrdinal("Total"));
                    model.ExchangeTime = dr.GetDateTime(dr.GetOrdinal("ExchangeTime"));
                    model.Status = (EyouSoft.Model.Enum.ExchangeStatus)dr.GetByte(dr.GetOrdinal("Status"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime")))
                    {
                        model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    }
                    model.OperatorId = dr["OperatorId"].ToString();
                    model.ProductName = dr["ProductName"].ToString();
                    model.Account = dr["Account"].ToString();
                    model.MemberName = dr["MemberName"].ToString();
                    model.OperatorName = dr["OperatorName"].ToString();
                    ResultList.Add(model);
                    model = null;
                }
            }
            return ResultList;
        }
        /// <summary>
        /// 改变兑换状态
        /// </summary>
        /// <param name="status">改变的状态</param>
        /// <param name="ids">改变的ids</param>
        /// <returns></returns>
        public bool SetExchange(EyouSoft.Model.Enum.ExchangeStatus status, int OperatorId, params string[] ids)
        {
            StringBuilder sId = new StringBuilder();
            for (int i = 0; i < ids.Length; i++)
            {
                sId.AppendFormat("{0},", ids[i]);
            }
            sId.Remove(sId.Length - 1, 1);
            string strSql = "UPDATE tbl_TotalToProduct SET Status=@Status,OperatorId=@OperatorId,IssueTime=@IssueTime Where ID in (" + sId + ")";
            DbCommand cmd = this._db.GetSqlStringCommand(strSql);
            this._db.AddInParameter(cmd, "Status", DbType.Byte, (int)status);
            this._db.AddInParameter(cmd, "OperatorId", DbType.Int32, OperatorId);
            this._db.AddInParameter(cmd, "IssueTime", DbType.DateTime, System.DateTime.Now);
            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }
        #endregion

        #region 积分获取信息
        /// <summary>
        /// 验证会员积分是否添加
        /// </summary>
        /// <param name="OrderId">订单编号</param>
        /// <param name="MemberID">会员编号</param>
        /// <returns></returns>
        public bool ExistsMemberTotal(string OrderId, string MemberID)
        {
            if (string.IsNullOrEmpty(OrderId) || string.IsNullOrEmpty(MemberID)) return false;

            var strSql = new StringBuilder();

            strSql.Append(" select count(ID) from tbl_MemberTotal where OrderId = @OrderId and  MemberID=@MemberID");
            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(dc, "MemberID", DbType.AnsiStringFixedLength, MemberID);
            this._db.AddInParameter(dc, "OrderId", DbType.AnsiStringFixedLength, OrderId);
            object obj = DbHelper.GetSingle(dc, _db);
            if (obj == null) return false;

            if (Toolkit.Utils.GetInt(obj.ToString()) > 0) return true;

            return false;
        }
        /// <summary>
        /// 增加一条积分获取信息
        /// </summary>
        public bool AddMemberTotal(MMemberTotal model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO tbl_MemberTotal([MemberID],[OrderId],[OrderType],[Total])");
            strSql.Append(" VALUES(@MemberID,@OrderId,@OrderType,@Total)");
            DbCommand dc = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(dc, "MemberID", DbType.AnsiStringFixedLength, model.MemberID);
            this._db.AddInParameter(dc, "OrderId", DbType.AnsiStringFixedLength, model.OrderId);
            this._db.AddInParameter(dc, "OrderType", DbType.Byte, (int)model.OrderType);
            this._db.AddInParameter(dc, "Total", DbType.Int32, model.Total);
            return DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
        }
        /// <summary>
        /// 更新一条积分获取信息
        /// </summary>
        public bool UpdateMemberTotal(MMemberTotal model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE tbl_MemberTotal Set [Total]=@Total,[IssueTime]=@IssueTime,[ValidTime]=@ValidTime WHERE ID=@ID");
            DbCommand dc = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(dc, "ID", DbType.Int32, model.ID);
            this._db.AddInParameter(dc, "Total", DbType.Int32, model.Total);
            this._db.AddInParameter(dc, "ValidTime", DbType.String, model.ValidTime);
            return DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
        }
        /// <summary>
        /// 根据会员编号和订单编号删除积分获取信息
        /// </summary>
        /// <returns></returns>
        public bool DeleteMemberTotal(string MemberID, string OrderId)
        {
            string sql = "";
            if (!string.IsNullOrEmpty(MemberID))
            {
                sql += " MemberID=@MemberID ";
            }
            if (!string.IsNullOrEmpty(OrderId))
            {
                sql += sql != "" ? " and OrderId=@OrderId " : " OrderId=@OrderId ";
            }
            if (sql == "")
                return false;
            else
            {
                sql = "DELETE FROM tbl_MemberTotal WHERE " + sql;
                DbCommand dc = this._db.GetSqlStringCommand(sql);
                this._db.AddInParameter(dc, "MemberID", DbType.AnsiStringFixedLength, MemberID);
                this._db.AddInParameter(dc, "OrderId", DbType.AnsiStringFixedLength, OrderId);
                return EyouSoft.Toolkit.DAL.DbHelper.ExecuteSqlTrans(dc, this._db) > 0 ? true : false;
            }
        }
        /// <summary>
        /// 批量删除积分获取信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool DeleteMemberTotal(params string[] ids)
        {
            StringBuilder StrSql = new StringBuilder();
            foreach (var id in ids)
            {
                if (id != null && Utils.GetInt(id) > 0)
                {
                    StrSql.AppendFormat(" DELETE FROM tbl_MemberTotal WHERE ID={0} ", id);
                }
            }
            DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
            return EyouSoft.Toolkit.DAL.DbHelper.ExecuteSqlTrans(dc, this._db) > 0 ? true : false;
        }
        /// <summary>
        /// 得到一条积分获取信息
        /// </summary>
        public MMemberTotal GetMemberTotalModel(int id)
        {
            MMemberTotal model = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [ID],[MemberID],[OrderId],[OrderType],[Total],[IssueTime],[ValidTime]");
            strSql.Append(",(select top 1 Account from tbl_Member where MemberID=tbl_MemberTotal.MemberID) as Account");
            strSql.Append(",(select top 1 MemberName from tbl_Member where MemberID=tbl_MemberTotal.MemberID) as MemberName");
            strSql.Append(",(CASE ");
            strSql.AppendFormat("WHEN tbl_MemberTotal.OrderType={0} then (select top 1 OrderCode from tbl_HotelOrder where OrderId=tbl_MemberTotal.OrderId) ", (int)EyouSoft.Model.Enum.OrderClass.酒店);
            strSql.AppendFormat("WHEN tbl_MemberTotal.OrderType={0} then (select top 1 OrderCode from tbl_ScenicAreaOrder where OrderId=tbl_MemberTotal.OrderId) ", (int)EyouSoft.Model.Enum.OrderClass.门票);
            strSql.AppendFormat("WHEN tbl_MemberTotal.OrderType={0} then (select top 1 OrderCode from tbl_XianLuTourOrder where OrderId=tbl_MemberTotal.OrderId) ", (int)EyouSoft.Model.Enum.OrderClass.线路);
            strSql.Append(" ELSE '' END) as OrderCode ");
            strSql.Append(" FROM tbl_MemberTotal WHERE ID=@ID");
            DbCommand dc = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(dc, "ID", DbType.Int32, id);
            using (IDataReader dr = EyouSoft.Toolkit.DAL.DbHelper.ExecuteReader(dc, this._db))
            {
                if (dr.Read())
                {
                    model = new MMemberTotal();
                    model.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    model.MemberID = dr["MemberID"].ToString();
                    model.OrderId = dr["OrderId"].ToString();
                    model.OrderType = (EyouSoft.Model.Enum.OrderClass)dr.GetByte(dr.GetOrdinal("OrderType"));
                    model.Total = dr.GetInt32(dr.GetOrdinal("Total"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    if (!dr.IsDBNull(dr.GetOrdinal("ValidTime")))
                    {
                        model.ValidTime = dr.GetDateTime(dr.GetOrdinal("ValidTime"));
                    }
                    model.Account = dr["Account"].ToString();
                    model.MemberName = dr["MemberName"].ToString();
                    model.OrderCode = dr["OrderCode"].ToString();
                }
            };
            return model;
        }
        /// <summary>
        /// 获得积分获取信息列表集合，分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        public IList<MMemberTotal> GetMemberTotalList(int pageSize, int pageIndex, ref int recordCount, MMemberTotalCX chaXun)
        {
            IList<MMemberTotal> ResultList = null;
            string tableName = "tbl_MemberTotal";
            StringBuilder fields = new StringBuilder();
            fields.Append("[ID],[MemberID],[OrderId],[OrderType],[Total],[IssueTime],[ValidTime]");
            fields.Append(",(select top 1 Account from tbl_Member where MemberID=tbl_MemberTotal.MemberID) as Account");
            fields.Append(",(select top 1 MemberName from tbl_Member where MemberID=tbl_MemberTotal.MemberID) as MemberName");
            fields.Append(",(CASE ");
            fields.AppendFormat("WHEN tbl_MemberTotal.OrderType={0} then (select top 1 OrderCode from tbl_HotelOrder where OrderId=tbl_MemberTotal.OrderId) ", (int)EyouSoft.Model.Enum.OrderClass.酒店);
            fields.AppendFormat("WHEN tbl_MemberTotal.OrderType={0} then (select top 1 OrderCode from tbl_ScenicAreaOrder where OrderId=tbl_MemberTotal.OrderId) ", (int)EyouSoft.Model.Enum.OrderClass.门票);
            fields.AppendFormat("WHEN tbl_MemberTotal.OrderType={0} then (select top 1 OrderCode from tbl_XianLuTourOrder where OrderId=tbl_MemberTotal.OrderId) ", (int)EyouSoft.Model.Enum.OrderClass.线路);
            fields.AppendFormat("WHEN tbl_MemberTotal.OrderType={0} then (select top 1 DingDanHao from tbl_QianZhengDingDan where DingDanId=tbl_MemberTotal.OrderId) ", (int)EyouSoft.Model.Enum.OrderClass.签证);
            fields.Append(" ELSE '' END) as OrderCode ");
            string query = " 1=1 ";
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.OrderCode))
                {
                    StringBuilder s = new StringBuilder();
                    s.Append(" (CASE ");
                    s.AppendFormat("WHEN tbl_MemberTotal.OrderType={0} then (select top 1 OrderCode from tbl_HotelOrder where OrderId=tbl_MemberTotal.OrderId and OrderCode like '%{1}%') ", (int)EyouSoft.Model.Enum.OrderClass.酒店, chaXun.OrderCode);
                    s.AppendFormat("WHEN tbl_MemberTotal.OrderType={0} then (select top 1 OrderCode from tbl_ScenicAreaOrder where OrderId=tbl_MemberTotal.OrderId and OrderCode like '%{1}%') ", (int)EyouSoft.Model.Enum.OrderClass.门票, chaXun.OrderCode);
                    s.AppendFormat("WHEN tbl_MemberTotal.OrderType={0} then (select top 1 OrderCode from tbl_XianLuTourOrder where OrderId=tbl_MemberTotal.OrderId and OrderCode like '%{1}%') ", (int)EyouSoft.Model.Enum.OrderClass.线路, chaXun.OrderCode);
                    s.AppendFormat("WHEN tbl_MemberTotal.OrderType={0} then (select top 1 OrderCode from tbl_QianZhengDingDan where DingDanId=tbl_MemberTotal.OrderId and DingDanHao like '%{1}%') ", (int)EyouSoft.Model.Enum.OrderClass.线路, chaXun.OrderCode);
                    s.Append(" ELSE NULL END) IS NOT NULL ");
                    query = query + string.Format(" AND {0}", s.ToString());
                }
                if (!string.IsNullOrEmpty(chaXun.Account))
                {
                    query = query + string.Format(" AND exists(select 1 from tbl_Member where MemberID=tbl_MemberTotal.MemberID and Account like '%{0}%') ", chaXun.Account);
                }
                if (!string.IsNullOrEmpty(chaXun.MemberName))
                {
                    query = query + string.Format(" AND exists(select 1 from tbl_Member where MemberID=tbl_MemberTotal.MemberID and MemberName like '%{0}%') ", chaXun.MemberName);
                }
                if (chaXun.OrderType.HasValue)
                {
                    query = query + string.Format(" AND OrderType={0}", (int)chaXun.OrderType);
                }
                if (chaXun.TotalS > 0)
                {
                    query = query + string.Format(" AND Total>={0}", chaXun.TotalS);
                }
                if (chaXun.TotalE > 0)
                {
                    query = query + string.Format(" AND Total<={0}", chaXun.TotalE);
                }
                if (chaXun.IssueTimeS.HasValue)
                {
                    query = query + string.Format(" AND IssueTime>='{0}' ", chaXun.IssueTimeS.Value.ToShortDateString() + " 00:00:00");
                }
                if (chaXun.IssueTimeE.HasValue)
                {
                    query = query + string.Format(" AND IssueTime<='{0}' ", chaXun.IssueTimeE.Value.ToShortDateString() + " 23:59:59");
                }
                if (chaXun.ValidTimeS.HasValue)
                {
                    query = query + string.Format(" AND ValidTime>='{0}' ", chaXun.ValidTimeS.Value.ToShortDateString() + " 00:00:00");
                }
                if (chaXun.ValidTimeE.HasValue)
                {
                    query = query + string.Format(" AND ValidTime<='{0}' ", chaXun.ValidTimeE.Value.ToShortDateString() + " 23:59:59");
                }
            }
            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), query, "IssueTime DESC", null))
            {
                ResultList = new List<MMemberTotal>();
                while (dr.Read())
                {
                    MMemberTotal model = new MMemberTotal();
                    model.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    model.MemberID = dr["MemberID"].ToString();
                    model.OrderId = dr["OrderId"].ToString();
                    model.OrderType = (EyouSoft.Model.Enum.OrderClass)dr.GetByte(dr.GetOrdinal("OrderType"));
                    model.Total = dr.GetInt32(dr.GetOrdinal("Total"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    if (!dr.IsDBNull(dr.GetOrdinal("ValidTime")))
                    {
                        model.ValidTime = dr.GetDateTime(dr.GetOrdinal("ValidTime"));
                    }
                    model.Account = dr["Account"].ToString();
                    model.MemberName = dr["MemberName"].ToString();
                    model.OrderCode = dr["OrderCode"].ToString();
                    ResultList.Add(model);
                    model = null;
                }
            };
            return ResultList;
        }
        ///// <summary>
        ///// 获得积分获取信息前几行数据集合
        ///// </summary>
        ///// <param name="Top"></param>
        ///// <param name="chaXun"></param>
        ///// <returns></returns>
        //public IList<MMemberTotal> GetMemberTotalTopList(int Top, MMemberTotalCX chaXun)
        //{
        //    IList<MMemberTotal> ResultList = null;
        //    StringBuilder StrSql = new StringBuilder();
        //    StrSql.AppendFormat("SELECT {0} [ID],[MemberID],[OrderId],[OrderType],[Total],[IssueTime],[ValidTime] ", (Top > 0 ? " TOP " + Top + " " : ""));
        //    StrSql.Append(",(select top 1 Account from tbl_Member where MemberID=tbl_MemberTotal.MemberID) as Account");
        //    StrSql.Append(",(select top 1 MemberName from tbl_Member where MemberID=tbl_MemberTotal.MemberID) as MemberName");
        //    StrSql.Append(",(CASE ");
        //    StrSql.AppendFormat("WHEN tbl_MemberTotal.OrderType={0} then (select top 1 OrderCode from tbl_HotelOrder where OrderId=tbl_MemberTotal.OrderId) ", (int)EyouSoft.Model.Enum.OrderClass.酒店);
        //    StrSql.AppendFormat("WHEN tbl_MemberTotal.OrderType={0} then (select top 1 OrderCode from tbl_ScenicAreaOrder where OrderId=tbl_MemberTotal.OrderId) ", (int)EyouSoft.Model.Enum.OrderClass.门票);
        //    StrSql.AppendFormat("WHEN tbl_MemberTotal.OrderType={0} then (select top 1 OrderCode from tbl_XianLuTourOrder where OrderId=tbl_MemberTotal.OrderId) ", (int)EyouSoft.Model.Enum.OrderClass.线路);
        //    StrSql.AppendFormat("WHEN tbl_MemberTotal.OrderType={0} then (select top 1 OrderCode from tbl_XianLuTourOrder where OrderId=tbl_MemberTotal.OrderId) ", (int)EyouSoft.Model.Enum.OrderClass.线路);
        //    StrSql.Append(" ELSE '' END) as OrderCode ");
        //    StrSql.Append(" FROM tbl_MemberTotal WHERE 1=1 ");
        //    if (chaXun != null)
        //    {
        //        if (!string.IsNullOrEmpty(chaXun.OrderCode))
        //        {
        //            StringBuilder s = new StringBuilder();
        //            s.Append(" (CASE ");
        //            s.AppendFormat("WHEN tbl_MemberTotal.OrderType={0} then (select top 1 OrderCode from tbl_HotelOrder where OrderId=tbl_MemberTotal.OrderId and OrderCode like '%{1}%') ", (int)EyouSoft.Model.Enum.OrderClass.酒店, chaXun.OrderCode);
        //            s.AppendFormat("WHEN tbl_MemberTotal.OrderType={0} then (select top 1 OrderCode from tbl_ScenicAreaOrder where OrderId=tbl_MemberTotal.OrderId and OrderCode like '%{1}%') ", (int)EyouSoft.Model.Enum.OrderClass.门票, chaXun.OrderCode);
        //            s.AppendFormat("WHEN tbl_MemberTotal.OrderType={0} then (select top 1 OrderCode from tbl_XianLuTourOrder where OrderId=tbl_MemberTotal.OrderId and OrderCode like '%{1}%') ", (int)EyouSoft.Model.Enum.OrderClass.线路, chaXun.OrderCode);
        //            s.Append(" ELSE NULL END) IS NOT NULL ");
        //            StrSql.AppendFormat(" AND {0}", s.ToString());
        //        }
        //        if (!string.IsNullOrEmpty(chaXun.Account))
        //        {
        //            StrSql.AppendFormat(" AND exists(select 1 from tbl_Member where MemberID=tbl_MemberTotal.MemberID and Account like '%{0}%') ", chaXun.Account);
        //        }
        //        if (!string.IsNullOrEmpty(chaXun.MemberName))
        //        {
        //            StrSql.AppendFormat(" AND exists(select 1 from tbl_Member where MemberID=tbl_MemberTotal.MemberID and MemberName like '%{0}%') ", chaXun.MemberName);
        //        }
        //        if (chaXun.OrderType.HasValue)
        //        {
        //            StrSql.AppendFormat(" AND OrderType={0}", (int)chaXun.OrderType);
        //        }
        //        if (chaXun.TotalS > 0)
        //        {
        //            StrSql.AppendFormat(" AND Total>={0}", chaXun.TotalS);
        //        }
        //        if (chaXun.TotalE > 0)
        //        {
        //            StrSql.AppendFormat(" AND Total<={0}", chaXun.TotalE);
        //        }
        //        if (chaXun.IssueTimeS.HasValue)
        //        {
        //            StrSql.AppendFormat(" AND IssueTime>='{0}' ", chaXun.IssueTimeS.Value.ToShortDateString() + " 00:00:00");
        //        }
        //        if (chaXun.IssueTimeE.HasValue)
        //        {
        //            StrSql.AppendFormat(" AND IssueTime<='{0}' ", chaXun.IssueTimeE.Value.ToShortDateString() + " 23:59:59");
        //        }
        //        if (chaXun.ValidTimeS.HasValue)
        //        {
        //            StrSql.AppendFormat(" AND ValidTime>='{0}' ", chaXun.ValidTimeS.Value.ToShortDateString() + " 00:00:00");
        //        }
        //        if (chaXun.ValidTimeE.HasValue)
        //        {
        //            StrSql.AppendFormat(" AND ValidTime<='{0}' ", chaXun.ValidTimeE.Value.ToShortDateString() + " 23:59:59");
        //        }
        //    }
        //    StrSql.Append(" ORDER BY IssueTime DESC ");
        //    DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
        //    using (IDataReader dr = EyouSoft.Toolkit.DAL.DbHelper.ExecuteReader(dc, this._db))
        //    {
        //        ResultList = new List<MMemberTotal>();
        //        while (dr.Read())
        //        {
        //            MMemberTotal model = new MMemberTotal();
        //            model.ID = dr.GetInt32(dr.GetOrdinal("ID"));
        //            model.MemberID = dr["MemberID"].ToString();
        //            model.OrderId = dr["OrderId"].ToString();
        //            model.OrderType = (EyouSoft.Model.Enum.OrderClass)dr.GetByte(dr.GetOrdinal("OrderType"));
        //            model.Total = dr.GetInt32(dr.GetOrdinal("Total"));
        //            model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
        //            if (!dr.IsDBNull(dr.GetOrdinal("ValidTime")))
        //            {
        //                model.ValidTime = dr.GetDateTime(dr.GetOrdinal("ValidTime"));
        //            }
        //            model.Account = dr["Account"].ToString();
        //            model.MemberName = dr["MemberName"].ToString();
        //            model.OrderCode = dr["OrderCode"].ToString();
        //            ResultList.Add(model);
        //            model = null;
        //        }
        //    }
        //    return ResultList;
        //}
        #endregion

        #region 会员联系信息
        /// <summary>
        /// 增加一条会员联系信息
        /// </summary>
        public bool AddMemberContact(MMemberContact model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO tbl_MemberContact([MemberID],[MemberName],[ContactTel],[Mobile],[Address],[Code],[BenZhu])");
            strSql.Append(" VALUES(@MemberID,@MemberName,@ContactTel,@Mobile,@Address,@Code,@BenZhu)");
            DbCommand dc = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(dc, "MemberID", DbType.AnsiStringFixedLength, model.MemberID);
            this._db.AddInParameter(dc, "MemberName", DbType.String, model.MemberName);
            this._db.AddInParameter(dc, "ContactTel", DbType.String, model.ContactTel);
            this._db.AddInParameter(dc, "Mobile", DbType.String, model.Mobile);
            this._db.AddInParameter(dc, "Address", DbType.String, model.Address);
            this._db.AddInParameter(dc, "Code", DbType.String, model.Code);
            this._db.AddInParameter(dc, "BenZhu", DbType.String, model.BenZhu);
            return DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
        }
        /// <summary>
        /// 更新一条会员联系信息
        /// </summary>
        public bool UpdateMemberContact(MMemberContact model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE tbl_MemberContact Set [MemberName]=@MemberName,[ContactTel]=@ContactTel,[Mobile]=@Mobile,[Address]=@Address,[Code]=@Code,[BenZhu]=@BenZhu WHERE ID=@ID");
            DbCommand dc = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(dc, "ID", DbType.Int32, model.ID);
            this._db.AddInParameter(dc, "MemberName", DbType.String, model.MemberName);
            this._db.AddInParameter(dc, "ContactTel", DbType.String, model.ContactTel);
            this._db.AddInParameter(dc, "Mobile", DbType.String, model.Mobile);
            this._db.AddInParameter(dc, "Address", DbType.String, model.Address);
            this._db.AddInParameter(dc, "Code", DbType.String, model.Code);
            this._db.AddInParameter(dc, "BenZhu", DbType.String, model.BenZhu);
            return DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
        }
        /// <summary>
        /// 根据联系信息编号或会员编号删除会员联系信息
        /// </summary>
        /// <returns></returns>
        public bool DeleteMemberContact(int Id, string MemberID)
        {
            string sql = "";
            if (Id > 0)
                sql = " ID=@ID ";
            else if (!string.IsNullOrEmpty(MemberID))
                sql = " MemberID=@MemberID ";
            else
            {
                return false;
            }
            if (sql == "")
                return false;
            else
            {
                sql = "DELETE FROM tbl_MemberContact WHERE " + sql;
                DbCommand dc = this._db.GetSqlStringCommand(sql);
                if (Id > 0)
                    this._db.AddInParameter(dc, "ID", DbType.Int32, Id);
                else
                    this._db.AddInParameter(dc, "MemberID", DbType.AnsiStringFixedLength, MemberID);
                return EyouSoft.Toolkit.DAL.DbHelper.ExecuteSqlTrans(dc, this._db) > 0 ? true : false;
            }
        }
        /// <summary>
        /// 批量删除会员联系信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool DeleteMemberContact(params string[] ids)
        {
            StringBuilder StrSql = new StringBuilder();
            foreach (var id in ids)
            {
                if (id != null && Utils.GetInt(id) > 0)
                {
                    StrSql.AppendFormat(" DELETE FROM tbl_MemberContact WHERE ID={0} ", id);
                }
            }
            DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
            return EyouSoft.Toolkit.DAL.DbHelper.ExecuteSqlTrans(dc, this._db) > 0 ? true : false;
        }
        /// <summary>
        /// 得到一条会员联系信息
        /// </summary>
        public MMemberContact GetMemberContact(int id)
        {
            MMemberContact model = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [ID],[MemberID],[MemberName],[ContactTel],[Mobile],[Address],[Code],[BenZhu]");
            strSql.Append(" FROM tbl_MemberContact WHERE ID=@ID");
            DbCommand dc = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(dc, "ID", DbType.Int32, id);
            using (IDataReader dr = EyouSoft.Toolkit.DAL.DbHelper.ExecuteReader(dc, this._db))
            {
                if (dr.Read())
                {
                    model = new MMemberContact();
                    model.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    model.MemberID = dr["MemberID"].ToString();
                    model.MemberName = dr["MemberName"].ToString();
                    model.ContactTel = dr["ContactTel"].ToString();
                    model.Mobile = dr["Mobile"].ToString();
                    model.Address = dr["Address"].ToString();
                    model.Code = dr["Code"].ToString();
                    model.BenZhu = dr["BenZhu"].ToString();
                }
            };
            return model;
        }
        /// <summary>
        /// 根据会员编号获得会员联系信息前几行数据集合
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        public IList<MMemberContact> GetMemberContactTopList(int Top, string MemberID)
        {
            IList<MMemberContact> ResultList = null;
            StringBuilder StrSql = new StringBuilder();
            StrSql.AppendFormat("SELECT {0} [ID],[MemberID],[MemberName],[ContactTel],[Mobile],[Address],[Code],[BenZhu] ", (Top > 0 ? " TOP " + Top + " " : ""));
            StrSql.Append(" FROM tbl_MemberContact ");
            if (!string.IsNullOrEmpty(MemberID))
                StrSql.AppendFormat(" WHERE MemberID='{0}' ", MemberID);
            StrSql.Append(" ORDER BY ID DESC ");
            DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
            using (IDataReader dr = EyouSoft.Toolkit.DAL.DbHelper.ExecuteReader(dc, this._db))
            {
                ResultList = new List<MMemberContact>();
                while (dr.Read())
                {
                    MMemberContact model = new MMemberContact();
                    model.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    model.MemberID = dr["MemberID"].ToString();
                    model.MemberName = dr["MemberName"].ToString();
                    model.ContactTel = dr["ContactTel"].ToString();
                    model.Mobile = dr["Mobile"].ToString();
                    model.Address = dr["Address"].ToString();
                    model.Code = dr["Code"].ToString();
                    model.BenZhu = dr["BenZhu"].ToString();
                    ResultList.Add(model);
                    model = null;
                }
            }
            return ResultList;
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 积分产品图片转换XML
        /// </summary>
        /// <param name="Lists">积分产品图片集合</param>
        /// <returns></returns>
        private string CreatePicListToXML(IList<MTatolProductPic> list)
        {
            if (list == null) return null;
            StringBuilder StrBuild = new StringBuilder();
            StrBuild.Append("<ROOT>");
            foreach (MTatolProductPic model in list)
            {
                StrBuild.AppendFormat("<Pic ProductID=\"{0}\"", model.ProductID);
                StrBuild.AppendFormat(" FilePath=\"{0}\"", Utils.ReplaceXmlSpecialCharacter(model.FilePath));
                StrBuild.AppendFormat(" Desc=\"{0}\" />", Utils.ReplaceXmlSpecialCharacter(model.Desc));
            }
            StrBuild.Append("</ROOT>");
            return StrBuild.ToString();
        }

        /// <summary>
        ///  积分产品图片转换List
        /// </summary>
        /// <param name="PicXml">要分析的XML字符串</param>
        /// <returns></returns>
        private IList<MTatolProductPic> GetPicXMLToList(string PicXml)
        {
            if (string.IsNullOrEmpty(PicXml)) return null;
            IList<MTatolProductPic> ResultList = null;
            ResultList = new List<MTatolProductPic>();
            XElement root = XElement.Parse(PicXml);
            var xRow = root.Elements("row");
            foreach (var tmp1 in xRow)
            {
                MTatolProductPic model = new MTatolProductPic()
                {
                    PicID = Utils.GetInt(tmp1.Attribute("PicID").Value),
                    ProductID = Utils.GetInt(tmp1.Attribute("ProductID").Value),
                    FilePath = tmp1.Attribute("FilePath") != null ? tmp1.Attribute("FilePath").Value : "",
                    Desc = tmp1.Attribute("Desc") != null ? tmp1.Attribute("Desc").Value : ""
                };
                ResultList.Add(model);
                model = null;
            }
            return ResultList;
        }

        #endregion
    }
}
