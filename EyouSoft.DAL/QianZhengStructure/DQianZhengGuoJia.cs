//签证国家信息 汪奇志 2013-11-14
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
    /// <summary>
    /// 签证国家信息
    /// </summary>
    public class DQianZhengGuoJia : DALBase, EyouSoft.IDAL.QianZhengStructure.IQianZhengGuoJia
    {
        #region static constants
        //static constants
        const string SQL_SELECT_GetInfo = "SELECT * FROM [tbl_QianZhengGuoJia] WHERE [IdentityId]=@IdentityId";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DQianZhengGuoJia()
        {
            _db = SystemStore;
        }
        #endregion

        #region private members

        #endregion

        #region IQianZhengGuoJia 成员
        /// <summary>
        /// 获取签证国家信息集合
        /// </summary>
        /// <param name="chaXun">查询信息</param>
        /// <returns></returns>
        public IList<EyouSoft.Model.QianZhengStructure.MQianZhengGuoJiaInfo> GetGuoJias(EyouSoft.Model.QianZhengStructure.MQianZhengGuoJiaChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.QianZhengStructure.MQianZhengGuoJiaInfo> items = new List<EyouSoft.Model.QianZhengStructure.MQianZhengGuoJiaInfo>();
            #region sql
            string sql = " SELECT * FROM [tbl_QianZhengGuoJia] WHERE 1=1 ";
            if (chaXun != null)
            {
                if (chaXun.Zhou.HasValue)
                {
                    sql += string.Format(" AND [Zhou]={0} ", (int)chaXun.Zhou);
                }
                if (chaXun.IsReiMen.HasValue)
                {
                    sql += string.Format(" AND [IsReiMen]={0} ", chaXun.IsReiMen.Value ? "1" : "0");
                }
            }
            #endregion
            DbCommand cmd=_db.GetSqlStringCommand(sql);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.QianZhengStructure.MQianZhengGuoJiaInfo();

                    item.Code = rdr["Code"].ToString();
                    item.FilePath = rdr["FilePath"].ToString();
                    item.IdentityId = rdr.GetInt32(rdr.GetOrdinal("IdentityId"));
                    item.IsReiMen = rdr["IsReiMen"].ToString() == "1";
                    item.Name1 = rdr["Name1"].ToString();
                    item.Name2 = rdr["Name2"].ToString();
                    item.PY1 = rdr["PY1"].ToString();
                    item.PY2 = rdr["PY2"].ToString();
                    item.Zhou = (EyouSoft.Model.Enum.QianZhengStructure.Zhou)rdr.GetByte(rdr.GetOrdinal("Zhou"));                    

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取签证国家信息实体
        /// </summary>
        /// <param name="guoJiaId">国家编号</param>
        /// <returns></returns>
        public EyouSoft.Model.QianZhengStructure.MQianZhengGuoJiaInfo GetInfo(int guoJiaId)
        {
            EyouSoft.Model.QianZhengStructure.MQianZhengGuoJiaInfo item = null;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetInfo);
            _db.AddInParameter(cmd, "IdentityId", DbType.Int32, guoJiaId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    item = new EyouSoft.Model.QianZhengStructure.MQianZhengGuoJiaInfo();

                    item.Code = rdr["Code"].ToString();
                    item.FilePath = rdr["FilePath"].ToString();
                    item.IdentityId = rdr.GetInt32(rdr.GetOrdinal("IdentityId"));
                    item.IsReiMen = rdr["IsReiMen"].ToString() == "1";
                    item.Name1 = rdr["Name1"].ToString();
                    item.Name2 = rdr["Name2"].ToString();
                    item.PY1 = rdr["PY1"].ToString();
                    item.PY2 = rdr["PY2"].ToString();
                    item.Zhou = (EyouSoft.Model.Enum.QianZhengStructure.Zhou)rdr.GetByte(rdr.GetOrdinal("Zhou"));
                }
            }

            return item;
        }
        #endregion
    }
}
