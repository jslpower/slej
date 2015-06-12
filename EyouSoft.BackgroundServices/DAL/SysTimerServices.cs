using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using EyouSoft.Toolkit;
using EyouSoft.Toolkit.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace EyouSoft.BackgroundServices.DAL
{
    /// <summary>
    /// 系统定时服务数据访问
    /// </summary>
    public class SysTimerServices : DALBase, EyouSoft.BackgroundServices.IDAL.ISysTimerServices
    {
        #region constructor
        /// <summary>
        /// database
        /// </summary>
        private readonly Database _db;

        /// <summary>
        /// 构造函数
        /// </summary>
        public SysTimerServices()
        {
            _db = SystemStore;
        }
        #endregion

        #region ISysTimerServices 成员
        /// <summary>
        /// 获取需要自动处理订单状态的订单信息集合
        /// </summary>
        /// <returns></returns>
        public IList<EyouSoft.BackgroundServices.Model.MDingDanInfo> GetDingDans()
        {
            IList<EyouSoft.BackgroundServices.Model.MDingDanInfo> items = new List<EyouSoft.BackgroundServices.Model.MDingDanInfo>();
            DbCommand cmd = _db.GetStoredProcCommand("proc_Timer_GetDingDans");

            using (IDataReader rdr = DbHelper.RunReaderProcedure(cmd, _db))
            {
                while (rdr.Read())
                {
                    var item = new EyouSoft.BackgroundServices.Model.MDingDanInfo();

                    item.DingDanId = rdr["DingDanId"].ToString();
                    item.DingDanLeiXing = Utils.GetInt(rdr["DingDanLeiXing"].ToString());

                    items.Add(item);
                }
            }

            return items;
        }

        #endregion
    }
}
