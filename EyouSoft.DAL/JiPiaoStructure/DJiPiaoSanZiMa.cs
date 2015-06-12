/*//机票-城市三字码信息 汪奇志 2013-11-05
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
    /// 机票-城市三字码信息
    /// </summary>
    public class DJiPiaoSanZiMa : DALBase, EyouSoft.IDAL.JiPiaoStructure.IJiPiaoSanZiMa
    {
        #region static constants
        //static constants
        const string SQL_SELECT_GetSanZiMas = "SELECT * FROM [Hotel_City]";
        const string SQL_SELECT_GetSanZiMaInfo = "SELECT * FROM [tbl_JiPiaoSanZiMa] WHERE Code=@Code ";
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DJiPiaoSanZiMa()
        {
            _db = SystemStore;
        }
        #endregion

        #region private members

        #endregion

        #region IJiPiaoSanZiMa 成员
        /// <summary>
        /// 获取三字码信息集合
        /// </summary>
        /// <returns></returns>
        public IList<EyouSoft.Model.JiPiaoStructure.MJiPiaoSanZiMaInfo> GetSanZiMas()
        {

            System.Collections.ArrayList list = new System.Collections.ArrayList();
            IList<EyouSoft.Model.JiPiaoStructure.MJiPiaoSanZiMaInfo> items1 = new List<EyouSoft.Model.JiPiaoStructure.MJiPiaoSanZiMaInfo>();
            DbCommand cmd1 = _db.GetSqlStringCommand("SELECT * FROM [tbl_JiPiaoSanZiMa] where isredian=1");

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd1, _db))
            {
                while (rdr.Read())
                {
                    list.Add(rdr["CityName"].ToString());
                }
            }


            IList<EyouSoft.Model.JiPiaoStructure.MJiPiaoSanZiMaInfo> items = new List<EyouSoft.Model.JiPiaoStructure.MJiPiaoSanZiMaInfo>();
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetSanZiMas);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                int i = 1;
                while (rdr.Read())
                {
                    var item = new EyouSoft.Model.JiPiaoStructure.MJiPiaoSanZiMaInfo();

                    item.AirportName = "";// rdr["AirportName"].ToString();
                    item.CityName = rdr["CITY_NAME"].ToString();
                    item.Code = rdr["CITY_CODE"].ToString();
                    item.IdentityId = i;//rdr.GetInt32(rdr.GetOrdinal("IdentityId"));
                    item.ProvinceName = rdr["PROVINCE"].ToString();
                    item.PY1 = rdr["CITY_PINYIN"].ToString();
                    item.PY2 = rdr["CITY_PYFW"].ToString();
                    item.PY3 = rdr["CITY_PYFW"].ToString().Substring(0, 1);// "";// rdr["PY3"].ToString();
                    item.IsReDian = list.Contains(rdr["CITY_NAME"].ToString() + "市");// rdr.GetString(rdr.GetOrdinal("IsReDian")) == "1";
                    i++;
                    items.Add(item);
                }
            }

            return items;
        }

        /// <summary>
        /// 获取三字码信息业务实体
        /// </summary>
        /// <param name="code">三字码</param>
        /// <returns></returns>
        public EyouSoft.Model.JiPiaoStructure.MJiPiaoSanZiMaInfo GetSanZiMaInfo(string code)
        {
            EyouSoft.Model.JiPiaoStructure.MJiPiaoSanZiMaInfo item = null;
            DbCommand cmd = _db.GetSqlStringCommand(SQL_SELECT_GetSanZiMaInfo);
            _db.AddInParameter(cmd, "Code", DbType.String, code);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    item = new EyouSoft.Model.JiPiaoStructure.MJiPiaoSanZiMaInfo();

                    item.AirportName = rdr["AirportName"].ToString();
                    item.CityName = rdr["CityName"].ToString();
                    item.Code = rdr["Code"].ToString();
                    item.IdentityId = rdr.GetInt32(rdr.GetOrdinal("IdentityId"));
                    item.ProvinceName = rdr["ProvinceName"].ToString();
                    item.PY1 = rdr["PY1"].ToString();
                    item.PY2 = rdr["PY2"].ToString();
                }
            }

            return item;
        }

        #endregion
    }
}
*/