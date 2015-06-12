using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace EyouSoft.DAL.OtherStructure
{
    public class DYuMing : DALBase, EyouSoft.IDAL.OtherStructure.IYuMing
    {
        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DYuMing()
        {
            _db = SystemStore;
        }
        #endregion
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EyouSoft.Model.OtherStructure.MYuMing GetYuMing(string URL)
        {
            var info = new EyouSoft.Model.OtherStructure.MYuMing();
            info.HOSTURL = URL;
            info.GYSID = "-1";
            info.UserType = EyouSoft.Model.Enum.MemberTypes.未注册用户;//为总网站下的单，提价比为0

            DbCommand cmd = _db.GetSqlStringCommand("SELECT ID,WebSite,DengJi   FROM  tbl_JA_Sellers WHERE WebSite=@WebSite");
            _db.AddInParameter(cmd, "WebSite", DbType.String, URL);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info.GYSID = rdr.GetString(rdr.GetOrdinal("ID"));
                    info.UserType = (EyouSoft.Model.Enum.MemberTypes)rdr.GetInt32(rdr.GetOrdinal("DengJi"));
                }
            }

            return info;
        }
    }
}
