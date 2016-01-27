using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.MallStructure;
using EyouSoft.Toolkit.DAL;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.Model.Enum.XianLuStructure;
using EyouSoft.Model.Enum;

namespace EyouSoft.DAL.MallStructure
{
    public class DShangChengShangPin : DALBase, EyouSoft.IDAL.MallStructure.IShangCheng
    {
        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DShangChengShangPin()
        {
            _db = SystemStore;
        }
        #endregion
        /// <summary>
        /// 写入商品表，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MShangChengShangPin info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_ShangCheng_Insert");
            _db.AddInParameter(cmd, "@ProductID", DbType.AnsiStringFixedLength, info.ProductID);
            _db.AddInParameter(cmd, "@TypeID", DbType.Int16, info.TypeID);
            _db.AddInParameter(cmd, "@GYSid", DbType.String, info.GYSid);
            _db.AddInParameter(cmd, "@ProductName", DbType.String, info.ProductName);
            _db.AddInParameter(cmd, "@ProductNum", DbType.Int32, info.ProductNum);
            _db.AddInParameter(cmd, "@MarketPrice", DbType.Decimal, info.MarketPrice);
            _db.AddInParameter(cmd, "@SalePrice", DbType.Decimal, info.SalePrice);
            _db.AddInParameter(cmd, "@ContentService", DbType.String, info.ContentService);
            _db.AddInParameter(cmd, "@UnContentService", DbType.String, info.UnContentService);
            _db.AddInParameter(cmd, "@UseRule", DbType.String, info.UseRule);
            _db.AddInParameter(cmd, "@NoticeKnow", DbType.String, info.NoticeKnow);
            _db.AddInParameter(cmd, "@ProductionDate", DbType.DateTime, info.ProductionDate);
            _db.AddInParameter(cmd, "@EffectDate", DbType.DateTime, info.EffectDate);
            _db.AddInParameter(cmd, "@ShelfDate", DbType.Int32, info.ShelfDate);
            _db.AddInParameter(cmd, "@IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "@Remark", DbType.String, info.Remark);
            _db.AddInParameter(cmd, "@ModelDesc", DbType.String, info.ModelDesc);
            _db.AddInParameter(cmd, "@ColorDesc", DbType.String, info.ColorDesc);
            _db.AddInParameter(cmd, "@StylesDesc", DbType.String, info.StylesDesc);
            _db.AddInParameter(cmd, "@MailWay", DbType.String, info.MailWay);
            _db.AddInParameter(cmd, "@Unit", DbType.String, info.Unit);
            _db.AddInParameter(cmd, "@ProductImgs", DbType.String, CreateTuPianXml(info.ProductImgs));

            _db.AddOutParameter(cmd, "@RetCode", DbType.Int32, 4);

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
        /// 删除商品
        /// </summary>
        /// <param name="ChanPinBianHao"></param>
        /// <returns>-99：产品下有订单 1：成功 其他返回值：失败</returns>
        public int Delete(string ChanPinBianHao)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_ShangCheng_Delete");

            _db.AddInParameter(cmd, "ProductID", DbType.AnsiStringFixedLength, ChanPinBianHao);
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
        /// 获取商品信息实体
        /// </summary>
        /// <param name="ShangPinID">订单编号</param>
        /// <returns></returns>
        public MShangChengShangPin GetModel(string ShangPinID)
        {
            MShangChengShangPin info = null;

            StringBuilder query = new StringBuilder();

            query.Append(" SELECT  *  FROM view_ShangCheng");
            query.Append(" Where ProductID=@ProductID");

            DbCommand cmd = this._db.GetSqlStringCommand(query.ToString());
            this._db.AddInParameter(cmd, "ProductID", DbType.AnsiStringFixedLength, ShangPinID);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    info = new MShangChengShangPin();
                    info.ProductID = dr.GetString(dr.GetOrdinal("ProductID"));
                    info.TypeID = dr.GetInt32(dr.GetOrdinal("TypeID"));
                    info.ProductName = dr.GetString(dr.GetOrdinal("ProductName"));
                    info.ProductNum = dr.GetInt32(dr.GetOrdinal("ProductNum"));
                    info.MarketPrice = dr.GetDecimal(dr.GetOrdinal("MarketPrice"));
                    info.SalePrice = dr.GetDecimal(dr.GetOrdinal("SalePrice"));
                    info.ContentService = dr.GetString(dr.GetOrdinal("ContentService"));
                    info.UnContentService = dr.GetString(dr.GetOrdinal("UnContentService"));
                    info.UseRule = dr.GetString(dr.GetOrdinal("UseRule"));
                    info.NoticeKnow = dr.GetString(dr.GetOrdinal("NoticeKnow"));
                    info.ProductionDate = dr.GetDateTime(dr.GetOrdinal("ProductionDate"));
                    if (!dr.IsDBNull(dr.GetOrdinal("EffectDate"))) info.EffectDate = dr.GetDateTime(dr.GetOrdinal("EffectDate"));
                    info.ShelfDate = dr.GetInt32(dr.GetOrdinal("ShelfDate"));
                    info.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    info.Remark = dr.GetString(dr.GetOrdinal("Remark"));
                    info.ModelDesc = dr.GetString(dr.GetOrdinal("ModelDesc"));
                    info.ColorDesc = dr.GetString(dr.GetOrdinal("ColorDesc"));
                    info.StylesDesc = dr.GetString(dr.GetOrdinal("StylesDesc"));
                    info.MailWay = dr.GetString(dr.GetOrdinal("MailWay"));
                    info.ProductImgs = dr.IsDBNull(dr.GetOrdinal("ProductImgs")) ? null : GetImgList(dr.GetString(dr.GetOrdinal("ProductImgs")));
                    info.TypeName = dr.GetString(dr.GetOrdinal("TypeName"));
                    info.StockNum = dr.GetInt32(dr.GetOrdinal("StockNum"));
                    info.GYSid = dr.IsDBNull(dr.GetOrdinal("GYSid")) ? "" : dr.GetString(dr.GetOrdinal("GYSid"));
                    info.Unit = dr.IsDBNull(dr.GetOrdinal("Unit")) ? "" : dr.GetString(dr.GetOrdinal("Unit"));
                }
            }
            return info;
        }
        /// <summary>
        /// 更新商品，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Update(MShangChengShangPin info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_ShangCheng_Update");


            _db.AddInParameter(cmd, "@ProductID", DbType.AnsiStringFixedLength, info.ProductID);
            _db.AddInParameter(cmd, "@TypeID", DbType.Int16, info.TypeID);
            _db.AddInParameter(cmd, "@ProductName", DbType.String, info.ProductName);
            _db.AddInParameter(cmd, "@ProductNum", DbType.Int32, info.ProductNum);
            _db.AddInParameter(cmd, "@MarketPrice", DbType.Decimal, info.MarketPrice);
            _db.AddInParameter(cmd, "@SalePrice", DbType.Decimal, info.SalePrice);
            _db.AddInParameter(cmd, "@ContentService", DbType.String, info.ContentService);
            _db.AddInParameter(cmd, "@UnContentService", DbType.String, info.UnContentService);
            _db.AddInParameter(cmd, "@UseRule", DbType.String, info.UseRule);
            _db.AddInParameter(cmd, "@NoticeKnow", DbType.String, info.NoticeKnow);
            _db.AddInParameter(cmd, "@ProductionDate", DbType.DateTime, info.ProductionDate);
            _db.AddInParameter(cmd, "@EffectDate", DbType.DateTime, info.EffectDate);
            _db.AddInParameter(cmd, "@ShelfDate", DbType.Int32, info.ShelfDate);
            _db.AddInParameter(cmd, "@Remark", DbType.String, info.Remark);
            _db.AddInParameter(cmd, "@ModelDesc", DbType.String, info.ModelDesc);
            _db.AddInParameter(cmd, "@ColorDesc", DbType.String, info.ColorDesc);
            _db.AddInParameter(cmd, "@StylesDesc", DbType.String, info.StylesDesc);
            _db.AddInParameter(cmd, "@MailWay", DbType.String, info.MailWay);
            _db.AddInParameter(cmd, "@ProductImgs", DbType.String, CreateTuPianXml(info.ProductImgs));
            _db.AddInParameter(cmd, "@Unit", DbType.String, info.Unit);
            _db.AddOutParameter(cmd, "@RetCode", DbType.Int32, 4);

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
        /// 获取商品集合
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<MShangChengShangPin> GetList(int pageSize, int pageIndex, ref int recordCount, MShangChengShangPinSer chaXun)
        {
            IList<MShangChengShangPin> list = new List<MShangChengShangPin>();


            string tableName = "view_ShangCheng";
            string fileds = "ProductID,TypeID,ProductName,ProductNum,MarketPrice,SalePrice,ContentService,UnContentService,UseRule,NoticeKnow,ProductionDate,EffectDate,ShelfDate,IssueTime,Remark,ModelDesc,ColorDesc,StylesDesc,MailWay,StockNum,TypeName,ProductImgs,ParentID,GYSid,Unit,SupplierName,IsTrue";
            string orderByString = "ProductSort desc,IssueTime desc";

            StringBuilder query = new StringBuilder();
            query.Append(" 1=1 ");

            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.ProductName))
                {
                    query.AppendFormat(" and  ProductName like '%{0}%' ", chaXun.ProductName);
                }
                if (chaXun.TypeID > 0)
                {
                    query.AppendFormat(" and  (TypeID = {0} or ParentID = {0} )", chaXun.TypeID);
                }
                if (!string.IsNullOrEmpty(chaXun.GYSid))
                {
                    query.AppendFormat(" and  GYSid = '{0}'", chaXun.GYSid);
                }
                if (chaXun.isGetTrue)
                {
                    query.AppendFormat(" and  EffectDate >= '{0}'", DateTime.Today);
                }
                if (chaXun.isTrue != null && chaXun.isTrue.Length > 0)
                {
                    query.Append(" AND isTrue IN(" + Utils.GetSqlIn(chaXun.isTrue) + ") ");
                }
                //if (chaXun.isTrue)
                //{
                //    query.Append(" and  (IsTrue = 0 OR IsTrue IS NULL) ");
                //}
                if (!string.IsNullOrEmpty(chaXun.GYSName))
                {
                    query.AppendFormat(" and  SupplierName = '{0}'", chaXun.GYSName);
                }
                if (!string.IsNullOrEmpty(chaXun.CompanyName))
                {
                    query.Append(" and GYSid in (select ID from tbl_JA_Sellers where CompanyName like '%" + chaXun.CompanyName + "%' )");
                }
                if (!string.IsNullOrEmpty(chaXun.sqlWhere))
                {
                    query.AppendFormat(" and ProductID not in (SELECT ProductId from tbl_Seller_ShangCheng where MemberId='{0}' and ProductStatus in(1,3))", chaXun.sqlWhere);
                }
                if (chaXun.Sort > 0)
                {
                    query.Append(" and  ProductSort>0");
                }
            }


            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref recordCount, tableName, fileds, query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {

                    MShangChengShangPin info = new MShangChengShangPin();
                    info.ProductID = dr.GetString(dr.GetOrdinal("ProductID")); ;
                    info.TypeID = dr.GetInt32(dr.GetOrdinal("TypeID"));
                    info.ProductName = dr.GetString(dr.GetOrdinal("ProductName"));
                    info.ProductNum = dr.GetInt32(dr.GetOrdinal("ProductNum"));
                    info.MarketPrice = dr.GetDecimal(dr.GetOrdinal("MarketPrice"));
                    info.SalePrice = dr.GetDecimal(dr.GetOrdinal("SalePrice"));
                    info.ContentService = dr.GetString(dr.GetOrdinal("ContentService"));
                    info.UnContentService = dr.GetString(dr.GetOrdinal("UnContentService"));
                    info.UseRule = dr.GetString(dr.GetOrdinal("UseRule"));
                    info.NoticeKnow = dr.GetString(dr.GetOrdinal("NoticeKnow"));
                    if (!dr.IsDBNull(dr.GetOrdinal("ProductionDate"))) info.ProductionDate = dr.GetDateTime(dr.GetOrdinal("ProductionDate"));
                    if (!dr.IsDBNull(dr.GetOrdinal("EffectDate"))) info.EffectDate = dr.GetDateTime(dr.GetOrdinal("EffectDate"));
                    info.ShelfDate = dr.GetInt32(dr.GetOrdinal("ShelfDate"));
                    info.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    info.Remark = dr.GetString(dr.GetOrdinal("Remark"));
                    info.ModelDesc = dr.GetString(dr.GetOrdinal("ModelDesc"));
                    info.ColorDesc = dr.GetString(dr.GetOrdinal("ColorDesc"));
                    info.StylesDesc = dr.GetString(dr.GetOrdinal("StylesDesc"));
                    info.MailWay = dr.GetString(dr.GetOrdinal("MailWay"));
                    info.TypeName = dr.GetString(dr.GetOrdinal("TypeName"));
                    info.StockNum = dr.GetInt32(dr.GetOrdinal("StockNum"));
                    info.ProductImgs = dr.IsDBNull(dr.GetOrdinal("ProductImgs")) ? null : GetImgList(dr.GetString(dr.GetOrdinal("ProductImgs")));
                    info.GYSid = dr.IsDBNull(dr.GetOrdinal("GYSid")) ? "" : dr.GetString(dr.GetOrdinal("GYSid"));
                    info.Unit = dr.IsDBNull(dr.GetOrdinal("Unit")) ? "" : dr.GetString(dr.GetOrdinal("Unit"));
                    info.SupplierName = dr.IsDBNull(dr.GetOrdinal("SupplierName")) ? "" : dr.GetString(dr.GetOrdinal("SupplierName"));
                    object ojb = dr["IsTrue"];
                    if (ojb != null && ojb != DBNull.Value)
                    {
                        info.IsTrue = (XianLuZT)dr.GetByte(dr.GetOrdinal("IsTrue"));
                    }
                    else
                    {
                        info.IsTrue = 0;
                    }
                    list.Add(info);
                }
            }
            return list;
        }

        /// <summary>
        /// 更新商品上下架
        /// </summary>
        /// <param name="ShangPinID">订单编号</param>
        /// <param name="isup">上架or下架（0-上架，1-下架）</param>
        /// <returns></returns>
        public int UpDateUp(string ShangPinID, XianLuZT isup)
        {
            string SQL_UPDATE_Update = "UPDATE [tbl_ShangChengChanPin] SET [IsTrue]=@IsTrue WHERE [ProductID]=@ProductID ";
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_Update);

            _db.AddInParameter(cmd, "IsTrue", DbType.Int32, (int)isup);
            _db.AddInParameter(cmd, "ProductID", DbType.String, ShangPinID);


            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }
        /// <summary>
        /// 更新商品上下架
        /// </summary>
        /// <param name="ShangPinID">商品id</param>
        /// <param name="isup">上架or下架（0-上架，1-下架）</param>
        /// <param name="MemberId">代理商id</param>
        /// <returns></returns>
        public int UpDateDaiLiUp(string ShangPinID, ProductZT isup, string MemberId)
        {
            string SQL_UPDATE_Update = "UPDATE [tbl_Seller_ShangCheng] SET [ProductStatus]=@ProductStatus WHERE [ProductId]=@ProductID and [MemberId]=@MemberId ";
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_Update);

            _db.AddInParameter(cmd, "ProductStatus", DbType.Int32, (int)isup);
            _db.AddInParameter(cmd, "ProductID", DbType.String, ShangPinID);
            _db.AddInParameter(cmd, "MemberId", DbType.String, MemberId);


            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }

        /// <summary>
        /// 更新商品上下架
        /// </summary>
        /// <param name="ShangPinID">商品[]id</param>
        /// <param name="isup">上架or下架（0-上架，1-下架）</param>
        /// <param name="MemberId">代理商id</param>
        /// <returns></returns>
        public int UpDateDaiLiUp(string[] ShangPinID, ProductZT isup, string MemberId)
        {
            StringBuilder SQL_UPDATE_Update = new StringBuilder();
            SQL_UPDATE_Update.AppendFormat(" DELETE tbl_Seller_ShangCheng WHERE ProductId in ({0}) ;", Utils.GetSqlInExpression(ShangPinID));
            for (int i = 0; i < ShangPinID.Length; i++)
            {
                SQL_UPDATE_Update.AppendFormat("INSERT INTO [tbl_Seller_ShangCheng]([MemberId],[ProductId],[ProductStatus] ) values ('{0}','{1}','{2}')	;", MemberId, ShangPinID[i], (int)isup);
            }

            //string SQL_UPDATE_Update = string.Format(" DELETE tbl_Seller_ShangCheng WHERE ProductId in ({0}) ;", Utils.GetSqlInExpression(ShangPinID));
            //SQL_UPDATE_Update += string.Format("UPDATE [tbl_Seller_ShangCheng] SET [ProductStatus]='{2}' WHERE [ProductId] in ({0}) and [MemberId]='{1}' ", Utils.GetSqlInExpression(ShangPinID), MemberId, (int)isup);

            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_Update.ToString());



            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }

        /// <summary>
        /// 根据代理商id和商品id获取该商品在代理商网站的状态
        /// </summary>
        /// <param name="ShangPinID">商品id</param>
        /// <param name="MemberId">代理商id</param>
        /// <returns></returns>
        public int GetDaiLiPro(string ShangPinID, string MemberId)
        {
            string SQL_Select = "Select ProductStatus from [tbl_Seller_ShangCheng] WHERE [ProductId]=@ProductID and [MemberId]=@MemberId";
            DbCommand cmd = _db.GetSqlStringCommand(SQL_Select);

            _db.AddInParameter(cmd, "MemberId", DbType.String, MemberId);
            _db.AddInParameter(cmd, "ProductID", DbType.String, ShangPinID);


            object obj = DbHelper.GetSingle(cmd, _db);
            if (obj != null)
            {
                return (int)obj;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 增加代理商产品
        /// </summary>
        /// <param name="ProductId">商品id</param>
        /// <param name="MemberId">代理商id</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        public int AddDaiLiPro(string MemberId, string ProductId, int state)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" INSERT INTO [tbl_Seller_ShangCheng]([MemberId],[ProductId],[ProductStatus] ");
            strSql.Append(") values (");
            strSql.Append("@MemberId,@ProductId ,@ProductStatus)	");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(cmd, "ProductStatus", DbType.Int32, state);
            _db.AddInParameter(cmd, "MemberId", DbType.String, MemberId);
            _db.AddInParameter(cmd, "ProductId", DbType.String, ProductId);
            return DbHelper.ExecuteSql(cmd, this._db);
        }

        /// <summary>
        /// 删除代理商产品
        /// </summary>
        /// <param name="ProductId">商品id</param>
        /// <returns></returns>
        public int DelDaiLiPro(string ProductId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" DELETE tbl_Seller_ShangCheng WHERE ProductId='{0}'", ProductId);

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            return DbHelper.ExecuteSql(cmd, this._db);
        }


        /// <summary>
        /// 获取代理商商品集合
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<MShangChengShangPin> GetDaiLiList(int pageSize, int pageIndex, ref int recordCount, MDaiLiShangChanPinSer chaXun)
        {
            IList<MShangChengShangPin> list = new List<MShangChengShangPin>();


            string tableName = "View_DaiLiChanPin";
            string fileds = "ProductID,TypeID,ProductName,ProductNum,MarketPrice,SalePrice,ContentService,UnContentService,UseRule,NoticeKnow,ProductionDate,EffectDate,ShelfDate,IssueTime,Remark,ModelDesc,ColorDesc,StylesDesc,MailWay,StockNum,TypeName,ProductImgs,ParentID,GYSid,Unit,SupplierName";
            string orderByString = " PSort asc,IssueTime desc ";

            StringBuilder query = new StringBuilder();
            query.Append(" 1=1 and PSort>0 ");

            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.ProductName))
                {
                    query.AppendFormat(" and  ProductName like '%{0}%' ", chaXun.ProductName);
                }
                if (chaXun.TypeID > 0)
                {
                    query.AppendFormat(" and  (TypeID = {0} or ParentID = {0} )", chaXun.TypeID);
                }
                if (chaXun.isGetTrue)
                {
                    query.AppendFormat(" and  EffectDate >= '{0}'", DateTime.Today);
                }
                if (chaXun.ProductStatus != null && chaXun.ProductStatus.Length > 0)
                {
                    query.Append(" AND ProductStatus IN(" + Utils.GetSqlIn(chaXun.ProductStatus) + ") ");
                }
                if (!string.IsNullOrEmpty(chaXun.MemberId))
                {
                    query.AppendFormat(" and  MemberId = '{0}'", chaXun.MemberId);
                }
            }


            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref recordCount, tableName, fileds, query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {

                    MShangChengShangPin info = new MShangChengShangPin();
                    info.ProductID = dr.GetString(dr.GetOrdinal("ProductID")); ;
                    info.TypeID = dr.GetInt32(dr.GetOrdinal("TypeID"));
                    info.ProductName = dr.GetString(dr.GetOrdinal("ProductName"));
                    info.ProductNum = dr.GetInt32(dr.GetOrdinal("ProductNum"));
                    info.MarketPrice = dr.GetDecimal(dr.GetOrdinal("MarketPrice"));
                    info.SalePrice = dr.GetDecimal(dr.GetOrdinal("SalePrice"));
                    info.ContentService = dr.GetString(dr.GetOrdinal("ContentService"));
                    info.UnContentService = dr.GetString(dr.GetOrdinal("UnContentService"));
                    info.UseRule = dr.GetString(dr.GetOrdinal("UseRule"));
                    info.NoticeKnow = dr.GetString(dr.GetOrdinal("NoticeKnow"));
                    info.ProductionDate = dr.GetDateTime(dr.GetOrdinal("ProductionDate"));
                    if (!dr.IsDBNull(dr.GetOrdinal("EffectDate"))) info.EffectDate = dr.GetDateTime(dr.GetOrdinal("EffectDate"));
                    info.ShelfDate = dr.GetInt32(dr.GetOrdinal("ShelfDate"));
                    info.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    info.Remark = dr.GetString(dr.GetOrdinal("Remark"));
                    info.ModelDesc = dr.GetString(dr.GetOrdinal("ModelDesc"));
                    info.ColorDesc = dr.GetString(dr.GetOrdinal("ColorDesc"));
                    info.StylesDesc = dr.GetString(dr.GetOrdinal("StylesDesc"));
                    info.MailWay = dr.GetString(dr.GetOrdinal("MailWay"));
                    info.TypeName = dr.GetString(dr.GetOrdinal("TypeName"));
                    info.StockNum = dr.GetInt32(dr.GetOrdinal("StockNum"));
                    info.ProductImgs = dr.IsDBNull(dr.GetOrdinal("ProductImgs")) ? null : GetImgList(dr.GetString(dr.GetOrdinal("ProductImgs")));
                    info.GYSid = dr.IsDBNull(dr.GetOrdinal("GYSid")) ? "" : dr.GetString(dr.GetOrdinal("GYSid"));
                    info.Unit = dr.IsDBNull(dr.GetOrdinal("Unit")) ? "" : dr.GetString(dr.GetOrdinal("Unit"));
                    info.SupplierName = dr.IsDBNull(dr.GetOrdinal("SupplierName")) ? "" : dr.GetString(dr.GetOrdinal("SupplierName"));
                    list.Add(info);
                }
            }
            return list;
        }

        /// <summary>
        /// 更新产品排序
        /// </summary>
        /// <param name="DaiLiId">代理id</param>
        /// <param name="id">产品主id</param>
        /// <param name="xuhao">序号</param>
        /// <returns></returns>
        public int UpdateProductSort(string DaiLiId, string id, int xuhao)
        {
            string TableName = "";
            string strwhere = " ProductId ='" + id + "' and MemberId='" + DaiLiId + "' and ProductStatus=2";
            string sql = "update tbl_Seller_ShangCheng set PSort=@XuHao where " + strwhere;
            DbCommand cmd = this._db.GetSqlStringCommand(sql);
            this._db.AddInParameter(cmd, "XuHao", DbType.Int32, xuhao);

            return DbHelper.ExecuteSql(cmd, this._db);
        }

        /// <summary>
        /// 根据表获取产品的排序
        /// </summary>
        /// <param name="dailiid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetProductSort(string dailiid, string id)
        {
            string TableName = "";
            string strwhere = "";
            string sql = "select PSort from tbl_Seller_ShangCheng where  ProductId ='" + id + "' and MemberId='" + dailiid + "' and ProductStatus=2";
            DbCommand cmd = this._db.GetSqlStringCommand(sql);
            return Convert.ToInt32(DbHelper.GetSingle(cmd, this._db));
        }

        #region 私有方法


        /// <summary>
        /// 创建XML
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        string CreateTuPianXml(IList<MChanPinTuPian> items)
        {
            if (items == null || items.Count == 0) return string.Empty;
            StringBuilder s = new StringBuilder();
            s.Append("<root>");

            foreach (var item in items)
            {
                s.Append("<info ");
                s.AppendFormat(" ProductID=\"{0}\"", item.ProductID);
                s.AppendFormat(" FilePath=\"{0}\"", Utils.ReplaceXmlSpecialCharacter(item.FilePath));
                s.AppendFormat(" FileDesc=\"{0}\"", Utils.ReplaceXmlSpecialCharacter(item.FileDesc));
                s.Append(" />");
            }
            s.Append("</root>");

            return s.ToString();
        }

        /// <summary>
        /// 获取图片集合
        /// </summary>
        /// <returns></returns>
        List<MChanPinTuPian> GetImgList(string xml)
        {
            if (string.IsNullOrEmpty(xml)) return null;
            List<MChanPinTuPian> list = new List<MChanPinTuPian>();
            System.Xml.Linq.XElement xRoot = System.Xml.Linq.XElement.Parse(xml);
            var xRows = Utils.GetXElements(xRoot, "row");
            foreach (var xRow in xRows)
            {
                MChanPinTuPian item = new MChanPinTuPian()
                {
                    ID = Utils.GetInt(Utils.GetXAttributeValue(xRow, "ID")),
                    ProductID = Utils.GetXAttributeValue(xRow, "ProductID"),
                    FilePath = Utils.GetXAttributeValue(xRow, "FilePath"),
                    FileDesc = Utils.GetXAttributeValue(xRow, "FileDesc")

                };

                list.Add(item);
            }
            return list;
        }
        #endregion
    }
}
