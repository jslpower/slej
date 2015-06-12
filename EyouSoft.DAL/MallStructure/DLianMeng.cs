using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.MallStructure;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.Toolkit.DAL;
using System.Data;
using System.Data.Common;
using EyouSoft.Toolkit;

namespace EyouSoft.DAL.MallStructure
{
    public class DLianMeng : DALBase, EyouSoft.IDAL.MallStructure.ILianMeng
    {
        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DLianMeng()
        {
            _db = SystemStore;
        }
        #endregion

        #region 联盟类别
        /// <summary>
        /// 判断类别名是否存在
        /// </summary>
        /// <param name="XiLieMingCheng">系列名称</param>
        /// <returns></returns>
        public bool ExistsXLName(string MingCheng)
        {

            var strSql = new StringBuilder();

            strSql.Append(" select count(1) from tbl_LianMengLeiBie where MingCheng = @MingCheng ");


            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dc, "MingCheng", DbType.String, MingCheng);

            object obj = DbHelper.GetSingle(dc, _db);
            if (obj == null) return false;

            if (Toolkit.Utils.GetInt(obj.ToString()) > 0) return true;

            return false;
        }
        /// <summary>
        /// 写入类别表，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MLianMengLeiBie info)
        {
            DbCommand cmd = _db.GetSqlStringCommand("INSERT INTO tbl_LianMengLeiBie (MingCheng,ModelType) VALUES (@MingCheng,@ModelType)");
            _db.AddInParameter(cmd, "@MingCheng", DbType.String, info.LeiBieMingCheng);
            _db.AddInParameter(cmd, "@ModelType", DbType.Byte, info.modelTp);

            return DbHelper.ExecuteSql(cmd, this._db);
        }
        /// <summary>
        /// 删除类别
        /// </summary>
        /// <param name="ChanPinBianHao">类别编号</param>
        /// <returns>-99：产品下有订单 1：成功 其他返回值：失败</returns>
        public int DeleteLB(string ChanPinBianHao)
        {
            DbCommand cmd = _db.GetSqlStringCommand("DELETE FROM tbl_LianMengLeiBie      WHERE LieBieID=@LieBieID");
            _db.AddInParameter(cmd, "@LieBieID", DbType.Int32, Utils.GetInt(ChanPinBianHao));

            return DbHelper.ExecuteSql(cmd, this._db);
        }
        /// <summary>
        /// 获取类别信息实体
        /// </summary>
        /// <param name="LeiBieID">类别编号</param>
        /// <returns></returns>
        public MLianMengLeiBie GetModelLB(int LeiBieID)
        {
            MLianMengLeiBie model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  *  FROM tbl_LianMengLeiBie  WHERE LieBieID=@LieBieID ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "LieBieID", System.Data.DbType.Int32, LeiBieID);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new MLianMengLeiBie();
                    model.LeiBieID = LeiBieID;
                    model.LeiBieMingCheng = dr.GetString(dr.GetOrdinal("MingCheng"));
                    model.modelTp = (EyouSoft.Model.Enum.ModelTypes)dr.GetByte(dr.GetOrdinal("ModelType"));
                }
            }

            return model;
        }
        /// <summary>
        /// 更新商品，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Update(MLianMengLeiBie info)
        {
            DbCommand cmd = _db.GetSqlStringCommand("UPDATE  tbl_LianMengLeiBie SET  MingCheng  =  @MingCheng  WHERE LieBieID=@LieBieID");
            _db.AddInParameter(cmd, "@MingCheng", DbType.String, info.LeiBieMingCheng);
            _db.AddInParameter(cmd, "@LieBieID", DbType.Int32, info.LeiBieID);

            return DbHelper.ExecuteSql(cmd, this._db);
        }
        /// <summary>
        /// 获取商品集合
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<MLianMengLeiBie> GetList(int pageSize, int pageIndex, ref int recordCount, MLianMengLeiBieSer chaXun)
        {
            IList<MLianMengLeiBie> list = new List<MLianMengLeiBie>();
            string tableName = "tbl_LianMengLeiBie";
            string fileds = "*  ";
            string orderByString = "LieBieID desc";

            StringBuilder query = new StringBuilder();
            query.Append(" 1=1 ");
            if (chaXun != null)
            {
                if (chaXun.modelTp.HasValue && chaXun.modelTp.Value > 0)
                {
                    query.AppendFormat("  and ModelType = '{0}' ", (int)chaXun.modelTp.Value);
                }
            }
            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref recordCount, tableName, fileds, query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {
                    MLianMengLeiBie model = new MLianMengLeiBie();
                    model.LeiBieID = dr.GetInt32(dr.GetOrdinal("LieBieID"));
                    model.LeiBieMingCheng = dr.GetString(dr.GetOrdinal("MingCheng"));
                    model.modelTp = (EyouSoft.Model.Enum.ModelTypes)dr.GetByte(dr.GetOrdinal("ModelType"));
                    list.Add(model);
                }
            }
            return list;
        }
        #endregion

        #region 链接
        /// <summary>
        /// 写入链接表，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MLianMeng info)
        {
            DbCommand cmd = _db.GetSqlStringCommand("INSERT INTO tbl_LianMeng (LieBieID ,SiteName ,SiteUrl ,ImgFile ,IssueTime ,OperatorID ,KeyWord) VALUES (@LieBieID ,@SiteName ,@SiteUrl ,@ImgFile ,@IssueTime ,@OperatorID ,@KeyWord )");
            _db.AddInParameter(cmd, "@LieBieID", DbType.Int32, info.LieBieID);
            _db.AddInParameter(cmd, "@SiteName", DbType.String, info.SiteName);
            _db.AddInParameter(cmd, "@SiteUrl", DbType.String, info.SiteUrl);
            _db.AddInParameter(cmd, "@ImgFile", DbType.String, info.ImgFile);
            _db.AddInParameter(cmd, "@IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "@OperatorID", DbType.String, info.OperatorID);
            _db.AddInParameter(cmd, "@KeyWord", DbType.String, info.KeyWord);

            return DbHelper.ExecuteSql(cmd, this._db);
        }
        /// <summary>
        /// 删除链接
        /// </summary>
        /// <param name="ChanPinBianHao"></param>
        /// <returns> 1：成功 其他返回值：失败</returns>
        public int Delete(string ChanPinBianHao)
        {
            DbCommand cmd = _db.GetSqlStringCommand("DELETE FROM tbl_LianMeng      WHERE ID=@ID");
            _db.AddInParameter(cmd, "@ID", DbType.Int32, Utils.GetInt(ChanPinBianHao));

            return DbHelper.ExecuteSql(cmd, this._db);
        }
        /// <summary>
        /// 获取商品信息实体
        /// </summary>
        /// <param name="LeiBieID">订单编号</param>
        /// <returns></returns>
        public MLianMeng GetModel(int LeiBieID)
        {
            MLianMeng model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  *  FROM  View_LianMeng  WHERE ID=@ID ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ID", System.Data.DbType.Int32, LeiBieID);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new MLianMeng();
                    model.ID = LeiBieID;
                    model.LieBieID = dr.GetInt32(dr.GetOrdinal("LieBieID"));
                    model.LeiBieMingCheng = dr.GetString(dr.GetOrdinal("MingCheng"));
                    model.SiteName = dr.GetString(dr.GetOrdinal("SiteName"));
                    model.SiteUrl = dr.GetString(dr.GetOrdinal("SiteUrl"));
                    model.ImgFile = dr.GetString(dr.GetOrdinal("ImgFile"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.OperatorID = dr.GetString(dr.GetOrdinal("OperatorID"));
                    model.KeyWord = dr.GetString(dr.GetOrdinal("KeyWord"));
                    model.modelTp = (EyouSoft.Model.Enum.ModelTypes)dr.GetByte(dr.GetOrdinal("ModelType"));
                }
            }

            return model;
        }
        /// <summary>
        /// 更新链接信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Update(MLianMeng info)
        {
            DbCommand cmd = _db.GetSqlStringCommand("UPDATE tbl_LianMeng SET LieBieID = @LieBieID ,SiteName = @SiteName ,SiteUrl = @SiteUrl ,ImgFile = @ImgFile ,KeyWord = @KeyWord WHERE ID=@ID");
            _db.AddInParameter(cmd, "@LieBieID", DbType.Int32, info.LieBieID);
            _db.AddInParameter(cmd, "@SiteName", DbType.String, info.SiteName);
            _db.AddInParameter(cmd, "@SiteUrl", DbType.String, info.SiteUrl);
            _db.AddInParameter(cmd, "@ImgFile", DbType.String, info.ImgFile);
            _db.AddInParameter(cmd, "@KeyWord", DbType.String, info.KeyWord);
            _db.AddInParameter(cmd, "@ID", DbType.Int32, info.ID);

            return DbHelper.ExecuteSql(cmd, this._db);
        }
        /// <summary>
        /// 获取商链接集合
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<MLianMeng> GetList(int pageSize, int pageIndex, ref int recordCount, MLianMengSer chaXun)
        {
            IList<MLianMeng> list = new List<MLianMeng>();
            string tableName = "View_LianMeng";
            string fileds = "*";
            string orderByString = "IssueTime desc";

            StringBuilder query = new StringBuilder();
            query.Append(" 1=1 ");
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.LeiBieMingCheng))
                {
                    query.AppendFormat("  and MingCheng LIKE '%{0}%' ", chaXun.LeiBieMingCheng);
                }
                if (!string.IsNullOrEmpty(chaXun.SiteName))
                {
                    query.AppendFormat("  and SiteName LIKE '%{0}%' ", chaXun.SiteName);
                }
                if (chaXun.LieBieID.HasValue && chaXun.LieBieID.Value > 0)
                {
                    query.AppendFormat("  and LieBieID = '{0}' ", chaXun.LieBieID.Value);
                }
                if (chaXun.modelTp.HasValue && chaXun.modelTp.Value > 0)
                {
                    query.AppendFormat("  and ModelType = '{0}' ", (int)chaXun.modelTp.Value);
                }
            }
            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref recordCount, tableName, fileds, query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {
                    MLianMeng model = new MLianMeng();

                    model.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                    model.LieBieID = dr.GetInt32(dr.GetOrdinal("LieBieID"));
                    model.LeiBieMingCheng = dr.GetString(dr.GetOrdinal("MingCheng"));
                    model.SiteName = dr.GetString(dr.GetOrdinal("SiteName"));
                    model.SiteUrl = dr.GetString(dr.GetOrdinal("SiteUrl"));
                    model.ImgFile = dr.GetString(dr.GetOrdinal("ImgFile"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.OperatorID = dr.GetString(dr.GetOrdinal("OperatorID"));
                    model.KeyWord = dr.GetString(dr.GetOrdinal("KeyWord"));
                    model.modelTp = (EyouSoft.Model.Enum.ModelTypes)dr.GetByte(dr.GetOrdinal("ModelType"));
                    list.Add(model);
                }
            }
            return list;
        }
        #endregion
    }
}
