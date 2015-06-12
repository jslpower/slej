using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using EyouSoft.Toolkit.DAL;
using System.Data;
using EyouSoft.Model.MallStructure;
using EyouSoft.Toolkit;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace EyouSoft.DAL.MallStructure
{
    public class DShangChengXiLie : DALBase, EyouSoft.IDAL.MallStructure.IShangChengXiLie
    {
        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DShangChengXiLie()
        {
            _db = SystemStore;
        }
        #endregion
        /// <summary>
        /// 判断系列名是否存在
        /// </summary>
        /// <param name="XiLieMingCheng">系列名称</param>
        /// <returns></returns>
        public bool ExistsXLName(string XiLieMingCheng)
        {

            var strSql = new StringBuilder();

            strSql.Append(" select count(1) from tbl_ShangChengLeiBie where TypeName = @XiLieMingCheng ");


            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dc, "XiLieMingCheng", DbType.String, XiLieMingCheng);

            object obj = DbHelper.GetSingle(dc, _db);
            if (obj == null) return false;

            if (Toolkit.Utils.GetInt(obj.ToString()) > 0) return true;

            return false;
        }
        /// <summary>
        /// 写入商品类型表，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MShangChengLeiBie info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_ShangChengLeiXing_Insert");
            _db.AddInParameter(cmd, "@TypeName", DbType.String, info.TypeName);
            _db.AddInParameter(cmd, "@TypeDesc", DbType.String, info.TypeDesc);
            _db.AddInParameter(cmd, "@ParentID", DbType.Int32, info.ParentID);
            _db.AddInParameter(cmd, "@IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "@OperatorID", DbType.Int32, info.OperatorID);
            _db.AddInParameter(cmd, "@OperatorName", DbType.String, info.OperatorName);
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
        /// 删除商品类型
        /// </summary>
        /// <param name="ChanPinBianHao"></param>
        /// <returns>-99：类型下有产品 1：成功 其他返回值：失败</returns>
        public int Delete(string LeiXingBianHao)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_ShangChengLeiXing_Delete");

            _db.AddInParameter(cmd, "TypeID", DbType.Int32, LeiXingBianHao);
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
        /// <param name="LeiBieID">类型编号</param>
        /// <returns></returns>
        public MShangChengLeiBie GetModel(int LeiBieID)
        {
            MShangChengLeiBie info = new MShangChengLeiBie();
            StringBuilder query = new StringBuilder();

            query.Append(" SELECT  *  FROM view_ShangChengLeiBie");
            query.Append(" Where TypeID=@TypeID AND IsDelete=0");

            DbCommand cmd = this._db.GetSqlStringCommand(query.ToString());
            this._db.AddInParameter(cmd, "TypeID", DbType.AnsiStringFixedLength, LeiBieID);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    info.TypeID = LeiBieID;
                    info.TypeName = dr.GetString(dr.GetOrdinal("TypeName"));
                    info.TypeDesc = dr.GetString(dr.GetOrdinal("TypeDesc"));
                    info.ParentID = dr.GetInt32(dr.GetOrdinal("ParentID"));
                    info.OperatorID = dr.GetInt32(dr.GetOrdinal("OperatorID"));
                    info.OperatorName = dr.GetString(dr.GetOrdinal("OperatorName"));

                }
            }
            return info;
        }
        /// <summary>
        /// 更新商品，返回1成功，其它失败
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Update(MShangChengLeiBie info)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_ShangChengLeiXing_Update");
            _db.AddInParameter(cmd, "@TypeID", DbType.Int32, info.TypeID);
            _db.AddInParameter(cmd, "@TypeName", DbType.String, info.TypeName);
            _db.AddInParameter(cmd, "@TypeDesc", DbType.String, info.TypeDesc);
            _db.AddInParameter(cmd, "@ParentID", DbType.Int32, info.ParentID);
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
        /// 获取商品类型集合
        /// </summary>
        /// <param name="chaXun">查询</param>
        /// <param name="ShiFouDingJi">是否只获取顶级分类</param>
        /// <returns></returns>
        public IList<MShangChengLeiBie> GetList(MShangChengLeiBieSer chaXun, bool ShiFouDingJi)
        {
            var strSql = new StringBuilder();
            strSql.Append(" select  *  FROM view_ShangChengLeiBie Where  IsDelete=0 ");
            if (ShiFouDingJi)
            {
                strSql.AppendFormat(" AND ParentID = '0' ");
            }
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.TypeName))
                { strSql.AppendFormat(" AND TypeName  LIKE  '%{0}%' ", chaXun.TypeName); }
                if (!string.IsNullOrEmpty(chaXun.OperatorName))
                { strSql.AppendFormat(" AND TypeName =  '{0}' ", chaXun.OperatorName); }
                if (chaXun.ParentID > 0)
                { strSql.AppendFormat(" AND ParentID =  '{0}' ", chaXun.ParentID); }
            }
            strSql.Append(" Order by IssueTime desc ");

            IList<MShangChengLeiBie> list = new List<MShangChengLeiBie>();
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {

                while (dr.Read())
                {
                    var info = new MShangChengLeiBie();
                    info.TypeID = dr.GetInt32(dr.GetOrdinal("TypeID"));
                    info.TypeName = dr.GetString(dr.GetOrdinal("TypeName"));
                    info.TypeDesc = dr.GetString(dr.GetOrdinal("TypeDesc"));
                    info.ParentID = dr.GetInt32(dr.GetOrdinal("ParentID"));
                    info.OperatorID = dr.GetInt32(dr.GetOrdinal("OperatorID"));
                    info.OperatorName = dr.GetString(dr.GetOrdinal("OperatorName"));
                    info.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));

                    list.Add(info);
                }
            }

            return list;
        }
        /// <summary>
        /// 获取商品类型集合
        /// </summary>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<MShangChengLeiBie> GetList(int pageSize, int pageIndex, ref int recordCount, MShangChengLeiBieSer chaXun)
        {
            IList<MShangChengLeiBie> list = new List<MShangChengLeiBie>();


            string tableName = "view_ShangChengLeiBie";
            string fileds = "TypeID ,TypeName ,TypeDesc ,ParentID ,IssueTime ,OperatorID ,OperatorName";
            string orderByString = "IssueTime desc";

            StringBuilder query = new StringBuilder();
            query.Append(" IsDelete=0 ");

            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.TypeName))
                {
                    query.AppendFormat(" and  TypeName like '%{0}%' ", chaXun.TypeName);
                }

            }


            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref recordCount, tableName, fileds, query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {

                    MShangChengLeiBie info = new MShangChengLeiBie();
                    info.TypeID = dr.GetInt32(dr.GetOrdinal("TypeID"));
                    info.TypeName = dr.GetString(dr.GetOrdinal("TypeName"));
                    info.TypeDesc = dr.GetString(dr.GetOrdinal("TypeDesc"));
                    info.ParentID = dr.GetInt32(dr.GetOrdinal("ParentID"));
                    info.OperatorID = dr.GetInt32(dr.GetOrdinal("OperatorID"));
                    info.OperatorName = dr.GetString(dr.GetOrdinal("OperatorName"));
                    info.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));

                    list.Add(info);
                }
            }
            return list;
        }


    }
}
