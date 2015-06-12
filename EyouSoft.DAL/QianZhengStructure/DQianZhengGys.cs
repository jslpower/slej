//签证供应商信息 汪奇志 2013-11-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit.DAL;
using EyouSoft.Toolkit;

namespace EyouSoft.DAL.QianZhengStructure
{
    public class DQianZhengGys : DALBase, EyouSoft.IDAL.QianZhengStructure.IQianZhengGys
    {
        #region static constants
        //static constants
        const string SQL_INSERT_Insert = "INSERT INTO [tbl_QianZhengGYS]([GysId],[GysName],[ShengFenId],[ChengShiId],[XianQuId],[JieShao],[IssueTime],[OperatorId],[LxrName],[LxrDianHua],[Fax],[DiZhi]) VALUES (@GysId,@GysName,@ShengFenId,@ChengShiId,@XianQuId,@JieShao,@IssueTime,@OperatorId,@LxrName,@LxrDianHua,@Fax,@DiZhi)";
        const string SQL_UPDATE_Update = "UPDATE [tbl_QianZhengGYS] SET [GysName]=@GysName,[ShengFenId]=@ShengFenId,[ChengShiId]=@ChengShiId,[XianQuId]=@XianQuId,[JieShao]=@JieShao,[LxrName]=@LxrName,[LxrDianHua]=@LxrDianHua,[Fax]=@Fax,[DiZhi]=@DiZhi WHERE [GysId]=@GysId";
        const string SQL_DELETE_Delete = "DELETE FROM [tbl_QianZhengGYS] WHERE [GysId]=@GysId";
        const string SQL_SELECT_GetInfo = "SELECT * FROM [tbl_QianZhengGYS] WHERE [GysId]=@GysId";
        const string SQL_SELECT_GetQianZhengShu = "SELECT COUNT(*) FROM [tbl_QianZheng] WHERE [GysId]=@GysId";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DQianZhengGys()
        {
            _db = SystemStore;
        }
        #endregion

        #region private members

        #endregion

        #region IQianZhengGys 成员
        /// <summary>
        /// 写入签证供应商信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(EyouSoft.Model.QianZhengStructure.MQianZhengGysInfo info)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_INSERT_Insert);

            _db.AddInParameter(cmd, "GysId", DbType.AnsiStringFixedLength, info.GysId);
            _db.AddInParameter(cmd, "GysName", DbType.String, info.GysName);
            _db.AddInParameter(cmd, "ShengFenId", DbType.Int32, info.ShengFenId);
            _db.AddInParameter(cmd, "ChengShiId", DbType.Int32, info.ChengShiId);
            _db.AddInParameter(cmd, "XianQuId", DbType.Int32, info.XianQuId);
            _db.AddInParameter(cmd, "JieShao", DbType.String, info.JieShao);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, info.OperatorId);
            _db.AddInParameter(cmd, "LxrName", DbType.String, info.LxrName);
            _db.AddInParameter(cmd, "LxrDianHua", DbType.String, info.LxrDianHua);
            _db.AddInParameter(cmd, "Fax", DbType.String, info.Fax);
            _db.AddInParameter(cmd, "DiZhi", DbType.String, info.DiZhi);

            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }

        /// <summary>
        /// 更新签证供应商信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Update(EyouSoft.Model.QianZhengStructure.MQianZhengGysInfo info)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_Update);

            _db.AddInParameter(cmd, "GysId", DbType.AnsiStringFixedLength, info.GysId);
            _db.AddInParameter(cmd, "GysName", DbType.String, info.GysName);
            _db.AddInParameter(cmd, "ShengFenId", DbType.Int32, info.ShengFenId);
            _db.AddInParameter(cmd, "ChengShiId", DbType.Int32, info.ChengShiId);
            _db.AddInParameter(cmd, "XianQuId", DbType.Int32, info.XianQuId);
            _db.AddInParameter(cmd, "JieShao", DbType.String, info.JieShao);
            _db.AddInParameter(cmd, "LxrName", DbType.String, info.LxrName);
            _db.AddInParameter(cmd, "LxrDianHua", DbType.String, info.LxrDianHua);
            _db.AddInParameter(cmd, "Fax", DbType.String, info.Fax);
            _db.AddInParameter(cmd, "DiZhi", DbType.String, info.DiZhi);

            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }

        /// <summary>
        /// 删除签证供应商信息，返回1成功，其它失败
        /// </summary>
        /// <param name="gysId">供应商编号</param>
        /// <returns></returns>
        public int Delete(string gysId)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_DELETE_Delete);

            _db.AddInParameter(cmd, "GysId", DbType.AnsiStringFixedLength, gysId);

            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }

        /// <summary>
        /// 获取签证供应商信息业务实体
        /// </summary>
        /// <param name="gysId">供应商编号</param>
        /// <returns></returns>
        public EyouSoft.Model.QianZhengStructure.MQianZhengGysInfo GetInfo(string gysId)
        {
            EyouSoft.Model.QianZhengStructure.MQianZhengGysInfo item = null;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetInfo);

            _db.AddInParameter(cmd, "GysId", DbType.AnsiStringFixedLength, gysId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    item = new EyouSoft.Model.QianZhengStructure.MQianZhengGysInfo();

                    item.ChengShiId = rdr.GetInt32(rdr.GetOrdinal("ChengShiId"));
                    item.GysId = rdr["GysId"].ToString();
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.JieShao = rdr["JieShao"].ToString();
                    item.GysName = rdr["GysName"].ToString();
                    item.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    item.ShengFenId = rdr.GetInt32(rdr.GetOrdinal("ShengFenId"));
                    item.XianQuId = rdr.GetInt32(rdr.GetOrdinal("XianQuId"));
                    item.LxrDianHua = rdr["LxrDianHua"].ToString();
                    item.LxrName = rdr["LxrName"].ToString();
                    item.Fax = rdr["Fax"].ToString();
                    item.DiZhi = rdr["DiZhi"].ToString();

                }
            }

            return item;
        }

        /// <summary>
        /// 获取签证供应商信息集合
        /// </summary>
        /// <param name="pageSize">页记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="chaXun">查询</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.QianZhengStructure.MQianZhengGysInfo> GetGyss(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.QianZhengStructure.MQianZhengGysChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.QianZhengStructure.MQianZhengGysInfo> items = new List<EyouSoft.Model.QianZhengStructure.MQianZhengGysInfo>();

            StringBuilder fields = new StringBuilder();
            StringBuilder query = new StringBuilder();
            string tableName = "tbl_QianZhengGYS";
            string orderByString = "IssueTime DESC";
            string sumString = "";

            #region fields
            fields.Append(" * ");
            #endregion

            #region sql where
            query.Append(" 1=1 ");
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.GysName))
                {
                    query.AppendFormat(" AND GysName LIKE '%{0}%' ", chaXun.GysName);
                }
            }
            #endregion

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), query.ToString(), orderByString, sumString))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.QianZhengStructure.MQianZhengGysInfo();

                    item.ChengShiId = rdr.GetInt32(rdr.GetOrdinal("ChengShiId"));
                    item.GysId = rdr["GysId"].ToString();
                    item.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    item.JieShao = rdr["JieShao"].ToString();
                    item.GysName = rdr["GysName"].ToString();
                    item.OperatorId = rdr.GetInt32(rdr.GetOrdinal("OperatorId"));
                    item.ShengFenId = rdr.GetInt32(rdr.GetOrdinal("ShengFenId"));
                    item.XianQuId = rdr.GetInt32(rdr.GetOrdinal("XianQuId"));
                    item.LxrDianHua = rdr["LxrDianHua"].ToString();
                    item.LxrName = rdr["LxrName"].ToString();
                    item.Fax = rdr["Fax"].ToString();
                    item.DiZhi = rdr["DiZhi"].ToString();

                    items.Add(item);
                }

                rdr.NextResult();

                if (rdr.Read())
                {

                }
            }

            return items;
        }

        /// <summary>
        /// 获取签证数量
        /// </summary>
        /// <param name="gysId">供应商编号</param>
        /// <returns></returns>
        public int GetQianZhengShu(string gysId)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetQianZhengShu);

            _db.AddInParameter(cmd, "GysId", DbType.AnsiStringFixedLength, gysId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    return rdr.GetInt32(0);
                }
            }

            return 1;
        }
        #endregion
    }
}
