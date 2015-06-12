using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.MemberStructure;
using EyouSoft.Toolkit.DAL;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.Toolkit;

namespace EyouSoft.DAL.MallStructure
{
    public class DDiZhi : DALBase, EyouSoft.IDAL.MallStructure.IDiZhi
    {
        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DDiZhi()
        {
            _db = SystemStore;
        }
        #endregion

        /// <summary>
        /// 写入地址表，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(MDiZhi info)
        {
            DbCommand cmd = _db.GetSqlStringCommand("INSERT INTO tbl_DiZhi (ProvinceID ,CityID ,DistrictID ,AddressInfo ,UserID ,UserName ,IssueTime ,IsDelete ,IsDefault)     VALUES (@ProvinceID ,@CityID ,@DistrictID ,@AddressInfo ,@UserID ,@UserName ,@IssueTime ,0 ,@IsDefault)");
            _db.AddInParameter(cmd, "@ProvinceID", DbType.Int32, info.ProvinceID);
            _db.AddInParameter(cmd, "@CityID", DbType.Int32, info.CityID);
            _db.AddInParameter(cmd, "@DistrictID", DbType.Int32, info.DistrictID);
            _db.AddInParameter(cmd, "@AddressInfo", DbType.String, info.AddressInfo);
            _db.AddInParameter(cmd, "@UserID", DbType.AnsiStringFixedLength, info.UserID);
            _db.AddInParameter(cmd, "@UserName", DbType.String, info.UserName);
            _db.AddInParameter(cmd, "@IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "@IsDelete", DbType.Byte, info.IsDelete);
            _db.AddInParameter(cmd, "@IsDefault", DbType.Byte, GetBooleanToStr(info.IsDefault));
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
        /// 修改地址表，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(MDiZhi info)
        {
            DbCommand cmd = _db.GetSqlStringCommand("UPDATE tbl_DiZhi SET ProvinceID =ProvinceID,CityID =CityID,DistrictID = DistrictID,AddressInfo = AddressInfo WHERE AddressID=AddressID");
            _db.AddInParameter(cmd, "@ProvinceID", DbType.Int32, info.ProvinceID);
            _db.AddInParameter(cmd, "@CityID", DbType.Int32, info.CityID);
            _db.AddInParameter(cmd, "@DistrictID", DbType.Int32, info.DistrictID);
            _db.AddInParameter(cmd, "@AddressInfo", DbType.String, info.AddressInfo);
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
        public int Delete(string dizhi)
        {
            DbCommand cmd = _db.GetSqlStringCommand("UPDATE tbl_DiZhi SET  IsDelete=1  WHERE AddressID=@AddressID");
            _db.AddInParameter(cmd, "@AddressID", DbType.Int32, dizhi);
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
        /// 获取地址
        /// </summary>
        /// <param name="id">地址编号</param>
        /// <returns></returns>
        public MDiZhi GetModel(int id)
        {
            MDiZhi info = new MDiZhi();
            StringBuilder query = new StringBuilder();

            query.Append(" SELECT  AddressID,ProvinceID,CityID,DistrictID,AddressInfo,UserID,UserName,IssueTime,IsDelete,IsDefault  FROM tbl_DiZhi Where AddressID=@AddressID AND IsDelete=0");

            DbCommand cmd = this._db.GetSqlStringCommand(query.ToString());
            this._db.AddInParameter(cmd, "AddressID", DbType.Int32, id);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    info.AddressID = dr.GetInt32(dr.GetOrdinal("AddressID"));
                    info.ProvinceID = dr.GetInt32(dr.GetOrdinal("ProvinceID"));
                    info.CityID = dr.GetInt32(dr.GetOrdinal("CityID"));
                    info.DistrictID = dr.GetInt32(dr.GetOrdinal("DistrictID"));
                    info.AddressInfo = dr.GetString(dr.GetOrdinal("AddressInfo"));
                    info.UserID = dr.GetString(dr.GetOrdinal("UserID"));
                    info.UserName = dr.GetString(dr.GetOrdinal("UserName"));
                    info.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    info.IsDefault = this.GetBoolean(dr.IsDBNull(dr.GetOrdinal("IsDefault")) ? "" : dr.GetString(dr.GetOrdinal("IsDefault")));
                }
            }
            return info;
        }
        /// <summary>
        /// 获取地址
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <returns></returns>
        public IList<MDiZhi> GetList(MDiZhiSer sermodel)
        {
            StringBuilder query = new StringBuilder();

            query.Append(" SELECT  *   FROM tbl_DiZhi Where   IsDelete=0");
            if (sermodel != null)
            {
                if (!string.IsNullOrEmpty(sermodel.UserID))
                {
                    query.AppendFormat("  AND  UserID='{0}'   ", sermodel.UserID);
                }
                if (!sermodel.IsDefault)
                {
                    query.AppendFormat("  AND  IsDefault={0}   ", GetBooleanToStr(sermodel.IsDefault));
                }
            }


            IList<MDiZhi> list = new List<MDiZhi>();
            DbCommand cmd = this._db.GetSqlStringCommand(query.ToString());


            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {

                while (dr.Read())
                {
                    MDiZhi info = new MDiZhi();
                    info.AddressID = dr.GetInt32(dr.GetOrdinal("AddressID"));
                    info.ProvinceID = dr.IsDBNull(dr.GetOrdinal("ProvinceID")) ? 0 : dr.GetInt32(dr.GetOrdinal("ProvinceID"));
                    info.CityID = dr.IsDBNull(dr.GetOrdinal("CityID")) ? 0 : dr.GetInt32(dr.GetOrdinal("CityID"));
                    info.DistrictID = dr.IsDBNull(dr.GetOrdinal("DistrictID")) ? 0 : dr.GetInt32(dr.GetOrdinal("DistrictID"));
                    info.AddressInfo = dr.IsDBNull(dr.GetOrdinal("AddressInfo")) ? "" : dr.GetString(dr.GetOrdinal("AddressInfo"));
                    info.UserID = dr.GetString(dr.GetOrdinal("UserID"));
                    info.UserName = dr.GetString(dr.GetOrdinal("UserName"));
                    info.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    info.IsDefault = this.GetBoolean(dr.IsDBNull(dr.GetOrdinal("IsDefault")) ? "" : dr.GetString(dr.GetOrdinal("IsDefault")));

                    list.Add(info);
                }
            }

            return list;
        }
    }
}
