//机票公共信息相关DAL 汪奇志 2014-11-14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit.DAL;
using EyouSoft.Toolkit;

namespace EyouSoft.DAL.JPStructure
{
    /// <summary>
    /// 机票公共信息相关DAL
    /// </summary>
    public class DJiPiao : DALBase, EyouSoft.IDAL.JPStructure.IJiPiao
    {
        #region static constants
        //static constants
        #endregion

        #region constructor
        /// <summary>
        /// database
        /// </summary>
        Database _db = null;

        /// <summary>
        /// default constructor
        /// </summary>
        public DJiPiao()
        {
            _db = SystemStore;
        }
        #endregion

        #region private members
        #endregion

        #region IJiPiao 成员
        /// <summary>
        /// 写入通知信息业务实体，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Notify_C(EyouSoft.Model.JPStructure.MNotifyInfo info)
        {
            var cmd = _db.GetSqlStringCommand("INSERT INTO [tbl_JiPiaoNotify]([NotifyId],[URL],[LeiXing],[JSON],[IssueTime],[GuanLianLeiXing],[GuanLianId],[HandlerRetCode]) VALUES (@NotifyId,@URL,@LeiXing,@JSON,@IssueTime,@GuanLianLeiXing,@GuanLianId,@HandlerRetCode)");
            _db.AddInParameter(cmd, "NotifyId", DbType.AnsiStringFixedLength, info.NotifyId);
            _db.AddInParameter(cmd, "URL", DbType.String, info.URL);
            _db.AddInParameter(cmd, "LeiXing", DbType.String, info.LeiXing);
            _db.AddInParameter(cmd, "JSON", DbType.String, info.JSON);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "GuanLianLeiXing", DbType.String, info.GuanLianLeiXing);
            _db.AddInParameter(cmd, "GuanLianId", DbType.AnsiStringFixedLength, info.GuanLianId);
            _db.AddInParameter(cmd, "HandlerRetCode", DbType.String, info.HandlerRetCode);

            DbHelper.ExecuteSql(cmd, _db);

            return 1;
        }

        /// <summary>
        /// 获取通知处理成功次数
        /// </summary>
        /// <param name="leiXing">通知类型</param>
        /// <param name="guanLianLeiXing">关联类型</param>
        /// <param name="guanLianId">关联编号</param>
        /// <returns></returns>
        public int Notify_GetChuLiCiShu(string leiXing,string guanLianLeiXing,string guanLianId)
        {
            var cmd = _db.GetSqlStringCommand("SELECT COUNT(*) FROM tbl_JiPiaoNotify WHERE LeiXing=@LeiXing AND GuanLianLeiXing=@GuanLianLeiXing AND GuanLianId=@GuanLianId AND HandlerRetCode=@HandlerRetCode");
            _db.AddInParameter(cmd, "LeiXing", DbType.String, leiXing);
            _db.AddInParameter(cmd, "GuanLianLeiXing", DbType.String, guanLianLeiXing);
            _db.AddInParameter(cmd, "GuanLianId", DbType.AnsiStringFixedLength, guanLianId);
            _db.AddInParameter(cmd, "HandlerRetCode", DbType.String, "1");
            int chuLiCiShu = 0;
            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    chuLiCiShu = rdr.GetInt32(0);
                }
            }
            return chuLiCiShu;
        }
        #endregion
    }
}
