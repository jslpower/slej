using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using EyouSoft.Toolkit;
using EyouSoft.Toolkit.DAL;
using System.Data;
using EyouSoft.Model.Enum;

namespace EyouSoft.DAL.OtherStructure
{
    public class DTuanGou : EyouSoft.Toolkit.DAL.DALBase, EyouSoft.IDAL.OtherStructure.ITuanGou
    {
        #region 初始化db
        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DTuanGou()
        {
            _db = base.SystemStore;
        }
        #endregion
        #region DTuanGou 成员

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        public int Add(EyouSoft.Model.OtherStructure.MTuanGouChanPin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO  tbl_TuanGouChanPin (ProductName,SaleType,ProductType,SimpleInfo,DetailInfo,MarketPrice,GroupPrice,ProductNum,ValiDate,IssueTime,OperatorID,OperatorName,SupplierID,ProductImg,XianShiWeiZhi,ProductSort)     ");
            strSql.Append("VALUES            ");
            strSql.Append("(@ProductName,@SaleType,@ProductType,@SimpleInfo,@DetailInfo,@MarketPrice,@GroupPrice,@ProductNum,@ValiDate,@IssueTime,@OperatorID,@OperatorName,@SupplierID,@ProductImg,@XianShiWeiZhi,@ProductSort)  DECLARE @PID int  select @PID=@@identity ");

            strSql.Append(" INSERT INTO [tbl_Seller_TuanGou]([MemberId],[ProductId],[ProductStatus] ");
            strSql.Append(") values (");
            strSql.Append("@SupplierID,@PID ,@ProductStatus)	");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ProductName", System.Data.DbType.String, model.ProductName);
            this._db.AddInParameter(cmd, "SaleType", System.Data.DbType.Byte, model.SaleType);
            this._db.AddInParameter(cmd, "ProductType", System.Data.DbType.Byte, model.ProductType);
            this._db.AddInParameter(cmd, "SimpleInfo", System.Data.DbType.String, model.SimpleInfo);
            this._db.AddInParameter(cmd, "DetailInfo", System.Data.DbType.String, model.DetailInfo);
            this._db.AddInParameter(cmd, "MarketPrice", System.Data.DbType.Decimal, model.MarketPrice);
            this._db.AddInParameter(cmd, "GroupPrice", System.Data.DbType.Decimal, model.GroupPrice);
            this._db.AddInParameter(cmd, "ProductNum", System.Data.DbType.Int32, model.ProductNum);
            this._db.AddInParameter(cmd, "ValiDate", System.Data.DbType.DateTime, model.ValiDate);
            this._db.AddInParameter(cmd, "IssueTime", System.Data.DbType.DateTime, model.IssueTime);
            this._db.AddInParameter(cmd, "OperatorID", System.Data.DbType.AnsiStringFixedLength, model.OperatorID);
            this._db.AddInParameter(cmd, "OperatorName", System.Data.DbType.String, model.OperatorName);
            this._db.AddInParameter(cmd, "SupplierID", System.Data.DbType.AnsiStringFixedLength, model.SupplierID);
            this._db.AddInParameter(cmd, "ProductImg", System.Data.DbType.String, model.ProductImg);
            this._db.AddInParameter(cmd, "XianShiWeiZhi", System.Data.DbType.Byte, model.WeiZhi);
            this._db.AddInParameter(cmd, "ProductSort", System.Data.DbType.Int32, model.ProductSort);
            this._db.AddInParameter(cmd, "ProductStatus", DbType.Int32, 0);

            return DbHelper.ExecuteSql(cmd, this._db);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(EyouSoft.Model.OtherStructure.MTuanGouChanPin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE tbl_TuanGouChanPin   SET ProductName = @ProductName      ,SaleType = @SaleType      ,ProductType = @ProductType      ,SimpleInfo = @SimpleInfo      ,DetailInfo = @DetailInfo      ,MarketPrice = @MarketPrice      ,GroupPrice = @GroupPrice      ,ProductNum = @ProductNum      ,ValiDate = @ValiDate,ProductImg=@ProductImg,XianShiWeiZhi=@XianShiWeiZhi,ProductSort=@ProductSort  WHERE ID=@ID");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ProductName", System.Data.DbType.String, model.ProductName);
            this._db.AddInParameter(cmd, "SaleType", System.Data.DbType.Byte, model.SaleType);
            this._db.AddInParameter(cmd, "ProductType", System.Data.DbType.Byte, model.ProductType);
            this._db.AddInParameter(cmd, "SimpleInfo", System.Data.DbType.String, model.SimpleInfo);
            this._db.AddInParameter(cmd, "DetailInfo", System.Data.DbType.String, model.DetailInfo);
            this._db.AddInParameter(cmd, "MarketPrice", System.Data.DbType.Decimal, model.MarketPrice);
            this._db.AddInParameter(cmd, "GroupPrice", System.Data.DbType.Decimal, model.GroupPrice);
            this._db.AddInParameter(cmd, "ProductNum", System.Data.DbType.Int32, model.ProductNum);
            this._db.AddInParameter(cmd, "ValiDate", System.Data.DbType.DateTime, model.ValiDate);
            this._db.AddInParameter(cmd, "ProductImg", System.Data.DbType.String, model.ProductImg);
            this._db.AddInParameter(cmd, "XianShiWeiZhi", System.Data.DbType.Byte, model.WeiZhi);
            this._db.AddInParameter(cmd, "ID", System.Data.DbType.Int16, model.ID);
            this._db.AddInParameter(cmd, "ProductSort", System.Data.DbType.Int32, model.ProductSort);


            return DbHelper.ExecuteSql(cmd, this._db);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="LinkID"></param>
        /// <returns></returns>
        public int Delete(int ID)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_TuanGou_Delete");

            _db.AddInParameter(cmd, "ID", DbType.Int32, ID);
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
        /// 得到一个对象实体
        /// </summary>
        /// <param name="LinkID"></param>
        /// <returns></returns>
        public EyouSoft.Model.OtherStructure.MTuanGouChanPin GetModel(int ID)
        {
            EyouSoft.Model.OtherStructure.MTuanGouChanPin model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ID,ProductName,SaleType,ProductType,SimpleInfo,DetailInfo,MarketPrice,GroupPrice,ProductNum,ValiDate,IssueTime,OperatorID,OperatorName,SupplierID,ProductImg,Salevolume,XianShiWeiZhi,GouMaiRenShu,ProductSort  FROM  View_TuanGou WHERE ID=@ID");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ID", System.Data.DbType.Int32, ID);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new EyouSoft.Model.OtherStructure.MTuanGouChanPin();
                    model.ID = ID;
                    model.ProductName = dr.GetString(dr.GetOrdinal("ProductName"));
                    model.SaleType = (EyouSoft.Model.Enum.CuXiaoLeiXing)dr.GetByte(dr.GetOrdinal("SaleType"));
                    model.ProductType = (EyouSoft.Model.Enum.ChanPinLeiXing)dr.GetByte(dr.GetOrdinal("ProductType"));
                    model.SimpleInfo = dr.GetString(dr.GetOrdinal("SimpleInfo"));
                    model.DetailInfo = dr.GetString(dr.GetOrdinal("DetailInfo"));
                    model.MarketPrice = dr.GetDecimal(dr.GetOrdinal("MarketPrice"));
                    model.GroupPrice = dr.GetDecimal(dr.GetOrdinal("GroupPrice"));
                    model.ProductNum = dr.GetInt32(dr.GetOrdinal("ProductNum"));
                    model.ValiDate = dr.GetDateTime(dr.GetOrdinal("ValiDate"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.OperatorID = dr.GetString(dr.GetOrdinal("OperatorID"));
                    model.OperatorName = dr.GetString(dr.GetOrdinal("OperatorName"));
                    model.SupplierID = dr.GetString(dr.GetOrdinal("SupplierID"));
                    model.Salevolume = !dr.IsDBNull(dr.GetOrdinal("Salevolume")) ? dr.GetInt32(dr.GetOrdinal("Salevolume")) : 0;
                    model.ProductImg = !dr.IsDBNull(dr.GetOrdinal("ProductImg")) ? dr.GetString(dr.GetOrdinal("ProductImg")) : "";
                    model.WeiZhi = (EyouSoft.Model.Enum.XianShiWeiZhi)dr.GetByte(dr.GetOrdinal("XianShiWeiZhi"));
                    model.GouMaiRenShu = dr.GetInt32(dr.GetOrdinal("GouMaiRenShu"));
                    model.ProductSort = dr.GetInt32(dr.GetOrdinal("ProductSort"));
                }
            }

            return model;
        }
        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.OtherStructure.MTuanGouChanPin> GetList(int PageSize, int PageIndex, string OrderBy, ref int RecordCount, EyouSoft.Model.OtherStructure.MTuanGouChanPinSer serModel)
        {
            IList<EyouSoft.Model.OtherStructure.MTuanGouChanPin> list = new List<EyouSoft.Model.OtherStructure.MTuanGouChanPin>();

            string tableName = "View_TuanGou";
            string fileds = " ID,ProductName,SaleType,ProductType,SimpleInfo,DetailInfo,MarketPrice,GroupPrice,ProductNum,ValiDate,IssueTime,OperatorID,OperatorName,SupplierID,ProductImg,Salevolume,XianShiWeiZhi,IsIndex,ProductSort";
            string orderByString = "IssueTime desc";
            if (OrderBy != null)
            {
                orderByString = OrderBy;
            }
            StringBuilder query = new StringBuilder();
            query.Append(" 1=1 ");

            if (serModel != null)
            {
                if (!string.IsNullOrEmpty(serModel.ProductName))
                {
                    query.AppendFormat(" and  ProductName like '%{0}%' ", serModel.ProductName);
                }
                if (serModel.SaleType.HasValue)
                {
                    query.AppendFormat(" and  SaleType = '{0}' ", (byte)serModel.SaleType.Value);
                }
                if (serModel.ProductType.HasValue)
                {
                    query.AppendFormat(" and  ProductType = '{0}' ", (byte)serModel.ProductType.Value);
                }
                if (!string.IsNullOrEmpty(serModel.SupplierID))
                {
                    query.AppendFormat(" and  SupplierID = '{0}' ", serModel.SupplierID);
                }
                else
                {                   
                    if (serModel.IsWebmaster==false)
                        query.Append(" and SupplierID ='dc99f4fe-6690-4b65-8e9d-c9336077cdf7' ");
                }
                if (serModel.ValiDate.HasValue)
                {
                    query.AppendFormat(" and ValiDate>'{0}'", serModel.ValiDate);
                }
                if (serModel.IsIndex != null && serModel.IsIndex.Length > 0)
                {
                    query.Append(" AND IsIndex IN(" + Utils.GetSqlIn(serModel.IsIndex) + ") ");
                }
                if(!string.IsNullOrEmpty(serModel.CompanyName))
                {
                    query.Append(" and SupplierID in (select ID from tbl_JA_Sellers where CompanyName like '%"+serModel.CompanyName+"%' )");
                }
                if (!string.IsNullOrEmpty(serModel.sqlWhere))
                {
                    query.AppendFormat(" and ID not in (SELECT ProductId from tbl_Seller_TuanGou where MemberId='{0}' and ProductStatus in(1,3))", serModel.sqlWhere);
                }
            }
            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, PageSize, PageIndex, ref RecordCount, tableName, fileds, query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.OtherStructure.MTuanGouChanPin model = new EyouSoft.Model.OtherStructure.MTuanGouChanPin();
                    model.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    model.ProductName = dr.GetString(dr.GetOrdinal("ProductName"));
                    model.SaleType = (EyouSoft.Model.Enum.CuXiaoLeiXing)dr.GetByte(dr.GetOrdinal("SaleType"));
                    model.ProductType = (EyouSoft.Model.Enum.ChanPinLeiXing)dr.GetByte(dr.GetOrdinal("ProductType"));
                    model.SimpleInfo = dr.GetString(dr.GetOrdinal("SimpleInfo"));
                    model.DetailInfo = dr.GetString(dr.GetOrdinal("DetailInfo"));
                    model.MarketPrice = dr.GetDecimal(dr.GetOrdinal("MarketPrice"));
                    model.GroupPrice = dr.GetDecimal(dr.GetOrdinal("GroupPrice"));
                    model.ProductNum = dr.GetInt32(dr.GetOrdinal("ProductNum"));
                    model.ValiDate = dr.GetDateTime(dr.GetOrdinal("ValiDate"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.OperatorID = dr.GetString(dr.GetOrdinal("OperatorID"));
                    model.OperatorName = dr.GetString(dr.GetOrdinal("OperatorName"));
                    model.SupplierID = dr.GetString(dr.GetOrdinal("SupplierID"));
                    model.ProductImg = !dr.IsDBNull(dr.GetOrdinal("ProductImg")) ? dr.GetString(dr.GetOrdinal("ProductImg")) : "";
                    model.Salevolume = !dr.IsDBNull(dr.GetOrdinal("Salevolume")) ? dr.GetInt32(dr.GetOrdinal("Salevolume")) : 0;
                    model.WeiZhi = (EyouSoft.Model.Enum.XianShiWeiZhi)dr.GetByte(dr.GetOrdinal("XianShiWeiZhi"));
                    model.IsIndex = (EyouSoft.Model.Enum.XianLuStructure.XianLuZT)dr.GetByte(dr.GetOrdinal("IsIndex"));
                    model.ProductSort = dr.GetInt32(dr.GetOrdinal("ProductSort"));
                    list.Add(model);
                }
            }

            return list;

        }


        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public IList<EyouSoft.Model.OtherStructure.MTuanGouChanPin> GetList(int Top, EyouSoft.Model.OtherStructure.MTuanGouChanPinSer serModel)
        {
            IList<EyouSoft.Model.OtherStructure.MTuanGouChanPin> list = new List<EyouSoft.Model.OtherStructure.MTuanGouChanPin>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM tbl_TuanGouChanPin WHERE ValiDate>='"+ DateTime.Now.ToShortDateString() +"'");
            if (serModel != null)
            {
                if (!string.IsNullOrEmpty(serModel.SupplierID))
                {
                    strSql.AppendFormat(" and  SupplierID = '{0}' ", serModel.SupplierID);
                }
                else
                {
                    strSql.Append(" and SupplierID ='dc99f4fe-6690-4b65-8e9d-c9336077cdf7' ");
                }
                
                if (serModel.SaleType.HasValue)
                {
                    strSql.AppendFormat(" AND SaleType='{0}' ", (int)serModel.SaleType);
                }
                if (serModel.ValiDate.HasValue)
                {
                    strSql.AppendFormat(" and ValiDate>'{0}'", serModel.ValiDate);
                }
                if (serModel.WeiZhi.Count > 0)
                {
                    IList<string> wl = new List<string>();
                    foreach(EyouSoft.Model.Enum.XianShiWeiZhi item in serModel.WeiZhi)
                    {
                        wl.Add(((int)item).ToString());
                    }

                    strSql.AppendFormat(" AND XianShiWeiZhi IN ({0}) ", string.Join(",", wl.ToArray()));
                }
                if (serModel.IsIndex != null && serModel.IsIndex.Length > 0)
                {
                    strSql.Append(" AND IsIndex IN(" + Utils.GetSqlIn(serModel.IsIndex) + ") ");
                }
                if (serModel.ProductSort.HasValue)
                {
                    strSql.Append(" AND ProductSort >= 0 ");
                }
            }
            strSql.Append(" Order By ");
            if (serModel.ProductSort.HasValue)
            {
                strSql.Append(" ProductSort asc, ");
            }
            strSql.Append(" IssueTime desc ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.OtherStructure.MTuanGouChanPin model = new EyouSoft.Model.OtherStructure.MTuanGouChanPin();
                    model.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    model.ProductName = dr.GetString(dr.GetOrdinal("ProductName"));
                    model.SaleType = (EyouSoft.Model.Enum.CuXiaoLeiXing)dr.GetByte(dr.GetOrdinal("SaleType"));
                    model.ProductType = (EyouSoft.Model.Enum.ChanPinLeiXing)dr.GetByte(dr.GetOrdinal("ProductType"));
                    model.SimpleInfo = dr.GetString(dr.GetOrdinal("SimpleInfo"));
                    model.DetailInfo = dr.GetString(dr.GetOrdinal("DetailInfo"));
                    model.MarketPrice = dr.GetDecimal(dr.GetOrdinal("MarketPrice"));
                    model.GroupPrice = dr.GetDecimal(dr.GetOrdinal("GroupPrice"));
                    model.ProductNum = dr.GetInt32(dr.GetOrdinal("ProductNum"));
                    model.ValiDate = dr.GetDateTime(dr.GetOrdinal("ValiDate"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.OperatorID = dr.GetString(dr.GetOrdinal("OperatorID"));
                    model.OperatorName = dr.GetString(dr.GetOrdinal("OperatorName"));
                    model.SupplierID = dr.GetString(dr.GetOrdinal("SupplierID"));
                    model.ProductImg = !dr.IsDBNull(dr.GetOrdinal("ProductImg")) ? dr.GetString(dr.GetOrdinal("ProductImg")) : "";
                    model.ProductSort = dr.GetInt32(dr.GetOrdinal("ProductSort"));
                    list.Add(model);
                }
            }

            return list;

        }

        /// <summary>
        /// 修改状态
        /// </summary>
        public int UpdateState(string Id, EyouSoft.Model.Enum.XianLuStructure.XianLuZT state)
        {
            string sql = "update tbl_TuanGouChanPin set IsIndex=@IsIndex where ID=@ID";
            DbCommand cmd = this._db.GetSqlStringCommand(sql);

            this._db.AddInParameter(cmd, "ID", DbType.String, Id);
            this._db.AddInParameter(cmd, "IsIndex", DbType.Byte, (int)state);

            return DbHelper.ExecuteSql(cmd, this._db);
        }

        /// <summary>
        /// 更新产品排序
        /// </summary>
        /// <param name="type">类别(租车，酒店，景区，线路，商城)</param>
        /// <param name="id">产品主id</param>
        /// <param name="xuhao">序号</param>
        /// <returns></returns>
        public int UpdateProductSort(string type, string id, int xuhao)
        {
            string TableName = "";
            string strwhere = "";
            switch (type)
            {
                case "zuche":
                    TableName = "tbl_JA_ZuCheInfo";
                    strwhere = " ZuCheID='" + id+"'";
                    break;
                case "xianlu":
                    TableName = "tbl_XianLu";
                    strwhere = " XianLuId='" + id + "'";
                    break;
                case "jiudian":
                    TableName = "tbl_Hotel";
                    strwhere = " HotelId='" + id + "'";
                    break;
                case "jingqu":
                    TableName = "tbl_ScenicArea";
                    strwhere = " ScenicId='" + id + "'";
                    break;
                //case "shangcheng":
                //    TableName = "tbl_ShangChengChanPin";
                //    strwhere = " ProductID='" + id + "'";
                //    break;
                default:
                    TableName = "";
                    break;
            }
            if (TableName != "")
            {
                string sql = "update "+TableName+" set ProductSort=@XuHao where "+strwhere;
                DbCommand cmd = this._db.GetSqlStringCommand(sql);
                this._db.AddInParameter(cmd, "XuHao", DbType.Int32, xuhao);

                return DbHelper.ExecuteSql(cmd, this._db);
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 根据表获取产品的排序
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetProductSort(string type, string id)
        {
            string TableName = "";
            string strwhere = "";
            switch (type)
            {
                case "zuche":
                    TableName = "tbl_JA_ZuCheInfo";
                    strwhere = " ZuCheID='" + id + "'";
                    break;
                case "xianlu":
                    TableName = "tbl_XianLu";
                    strwhere = " XianLuId='" + id + "'";
                    break;
                case "jiudian":
                    TableName = "tbl_Hotel";
                    strwhere = " HotelId='" + id + "'";
                    break;
                case "jingqu":
                    TableName = "tbl_ScenicArea";
                    strwhere = " ScenicId='" + id + "'";
                    break;
                case "shangcheng":
                    TableName = "tbl_ShangChengChanPin";
                    strwhere = " ProductID='" + id + "'";
                    break;
                default:
                    TableName = "";
                    break;
            }
            if (TableName != "")
            {
                string sql = "select ProductSort from "+ TableName +" where " + strwhere;
                DbCommand cmd = this._db.GetSqlStringCommand(sql);
                try
                {
                    return Convert.ToInt32(DbHelper.GetSingle(cmd, this._db));
                }
                catch { return 0; }
            }
            else
            {
                return 0;
            }
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
            string SQL_UPDATE_Update = "UPDATE [tbl_Seller_TuanGou] SET [ProductStatus]=@ProductStatus WHERE [ProductId]=@ProductID and [MemberId]=@MemberId ";
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_Update);

            _db.AddInParameter(cmd, "ProductStatus", DbType.Int32, (int)isup);
            _db.AddInParameter(cmd, "ProductID", DbType.String, ShangPinID);
            _db.AddInParameter(cmd, "MemberId", DbType.String, MemberId);


            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }

        /// <summary>
        /// 根据代理商id和商品id获取该商品在代理商网站的状态
        /// </summary>
        /// <param name="ShangPinID">商品id</param>
        /// <param name="MemberId">代理商id</param>
        /// <returns></returns>
        public int GetDaiLiPro(string ShangPinID, string MemberId)
        {
            string SQL_Select = "Select ProductStatus from [tbl_Seller_TuanGou] WHERE [ProductId]=@ProductID and [MemberId]=@MemberId";
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
            strSql.Append(" INSERT INTO [tbl_Seller_TuanGou]([MemberId],[ProductId],[ProductStatus] ");
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
            strSql.AppendFormat(" DELETE tbl_Seller_TuanGou WHERE ProductId='{0}'", ProductId);

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
        public IList<EyouSoft.Model.OtherStructure.MTuanGouChanPin> GetDaiLiList(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.OtherStructure.MDaiLiTuanGouSer chaXun)
        {
            IList<EyouSoft.Model.OtherStructure.MTuanGouChanPin> list = new List<EyouSoft.Model.OtherStructure.MTuanGouChanPin>();


            string tableName = "View_DaiLiTuanGou";
            string fileds = "[Id],[MemberId],[ProductId],[SaleType],[ProductName],[ProductType],[SimpleInfo],[DetailInfo],[MarketPrice],[GroupPrice],[ProductNum],[ValiDate],[IssueTime],[OperatorID],[OperatorName],[SupplierID],[ProductImg],[SupplierName],[StockNum]";
            string orderByString = "IssueTime desc";

            StringBuilder query = new StringBuilder();
            query.Append(" 1=1 ");

            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.ProductName))
                {
                    query.AppendFormat(" and  ProductName like '%{0}%' ", chaXun.ProductName);
                }
                if (chaXun.ProductType > 0)
                {
                    query.AppendFormat(" and  (ProductType = {0})", (int)chaXun.ProductType);
                }
                if (chaXun.SaleType > 0)
                {
                    query.AppendFormat(" and  (SaleType = {0})", (int)chaXun.SaleType);
                }
                if (chaXun.isGetTrue)
                {
                    query.AppendFormat(" and  ValiDate >= '{0}'", DateTime.Today);
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

                    EyouSoft.Model.OtherStructure.MTuanGouChanPin info = new EyouSoft.Model.OtherStructure.MTuanGouChanPin();
                    info.ID = Convert.ToInt32(dr.GetString(dr.GetOrdinal("ProductId")));
                    info.SaleType = (CuXiaoLeiXing)dr.GetByte(dr.GetOrdinal("SaleType"));
                    info.ProductType = (ChanPinLeiXing)dr.GetByte(dr.GetOrdinal("ProductType"));
                    info.ProductName = dr.GetString(dr.GetOrdinal("ProductName"));
                    info.ProductNum = dr.GetInt32(dr.GetOrdinal("ProductNum"));
                    info.MarketPrice = dr.GetDecimal(dr.GetOrdinal("MarketPrice"));
                    info.GroupPrice = dr.GetDecimal(dr.GetOrdinal("GroupPrice"));
                    info.SimpleInfo = dr.GetString(dr.GetOrdinal("SimpleInfo"));
                    info.DetailInfo = dr.GetString(dr.GetOrdinal("DetailInfo"));
                    info.OperatorID = dr.GetString(dr.GetOrdinal("OperatorID"));
                    info.OperatorName = dr.GetString(dr.GetOrdinal("OperatorName"));
                    if (!dr.IsDBNull(dr.GetOrdinal("ValiDate"))) info.ValiDate = dr.GetDateTime(dr.GetOrdinal("ValiDate"));
                    info.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    info.StockNum = dr.GetInt32(dr.GetOrdinal("StockNum"));
                    info.ProductImg = dr.IsDBNull(dr.GetOrdinal("ProductImg")) ? null : dr.GetString(dr.GetOrdinal("ProductImg"));

                    info.SupplierID = dr.IsDBNull(dr.GetOrdinal("SupplierID")) ? "" : dr.GetString(dr.GetOrdinal("SupplierID"));
                    info.SupplierName = dr.IsDBNull(dr.GetOrdinal("SupplierName")) ? "" : dr.GetString(dr.GetOrdinal("SupplierName"));
                    list.Add(info);
                }
            }
            return list;
        }

        #endregion

    }
}
