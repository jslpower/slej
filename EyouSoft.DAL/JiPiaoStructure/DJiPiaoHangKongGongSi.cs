/*//机票-航空公司信息 汪奇志 2013-11-06
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit.DAL;
using EyouSoft.Toolkit;

namespace EyouSoft.DAL.JiPiaoStructure
{
    /// <summary>
    /// 机票-航空公司信息
    /// </summary>
    public class DJiPiaoHangKongGongSi : DALBase, EyouSoft.IDAL.JiPiaoStructure.IJiPiaoHangKongGongSi
    {
        #region static constants
        //static constants
        const string SQL_SELECT_GetHangKongGongSis = "SELECT * FROM [tbl_JiPiaoHangKongGongSi]";
        const string SQL_SELECT_GetHangKongGongSiInfo = "SELECT * FROM [tbl_JiPiaoHangKongGongSi] WHERE Code=@Code ";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DJiPiaoHangKongGongSi()
        {
            _db = SystemStore;
        }
        #endregion

        #region private members

        #endregion

        #region IJiPiaoHangKongGongSi 成员
        /// <summary>
        /// 获取航空公司信息集合
        /// </summary>
        /// <returns></returns>
        public IList<EyouSoft.Model.JiPiaoStructure.MJiPiaoHangKongGongSiInfo> GetHangKongGongSis()
        {
            IList<EyouSoft.Model.JiPiaoStructure.MJiPiaoHangKongGongSiInfo> items = new List<EyouSoft.Model.JiPiaoStructure.MJiPiaoHangKongGongSiInfo>();
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetHangKongGongSis);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.JiPiaoStructure.MJiPiaoHangKongGongSiInfo();
                    
                    item.Code = rdr["Code"].ToString();
                    item.IdentityId = rdr.GetInt32(rdr.GetOrdinal("IdentityId"));
                    item.Name = rdr["Name"].ToString();

                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取航空公司信息业务实体
        /// </summary>
        /// <param name="code">航空公司代码</param>
        /// <returns></returns>
        public EyouSoft.Model.JiPiaoStructure.MJiPiaoHangKongGongSiInfo GetHangKongGongSiInfo(string code)
        {
            EyouSoft.Model.JiPiaoStructure.MJiPiaoHangKongGongSiInfo item = null;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetHangKongGongSiInfo);
            _db.AddInParameter(cmd, "Code", DbType.String, code);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    item = new EyouSoft.Model.JiPiaoStructure.MJiPiaoHangKongGongSiInfo();

                    item.Code = rdr["Code"].ToString();
                    item.IdentityId = rdr.GetInt32(rdr.GetOrdinal("IdentityId"));
                    item.Name = rdr["Name"].ToString();
                }
            }

            return item;
        }

        #endregion
    }
}
*/