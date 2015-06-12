using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit.DAL;
using EyouSoft.Toolkit;

namespace EyouSoft.DAL.OtherStructure
{
    /// <summary>
    /// 验证码相关
    /// </summary>
    public class DYanZhengMa : DALBase, EyouSoft.IDAL.OtherStructure.IYanZhengMa
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
        public DYanZhengMa()
        {
            _db = SystemStore;
        }
        #endregion

        #region private members

        #endregion

        #region IYanZhengMa 成员
        /// <summary>
        /// 写入验证码信息，返回1成功，其它失败
        /// </summary>
        /// <param name="info">实体</param>
        /// <returns></returns>
        public int Insert(EyouSoft.Model.OtherStructure.MYanZhengMaInfo info)
        {
            string sql = "UPDATE tbl_YanZhengMa SET [Status]=1 WHERE ShouJi=@ShouJi AND LeiXing=@LeiXing AND [Status]=0;INSERT INTO [tbl_YanZhengMa]([ShouJi],[YanZhengMa],[LeiXing],[IssueTime],[Status])VALUES(@ShouJi,@YanZhengMa,@LeiXing,@IssueTime,@Status)";
            var cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "ShouJi", DbType.String, info.ShouJi);
            _db.AddInParameter(cmd, "YanZhengMa", DbType.String, info.YanZhengMa);
            _db.AddInParameter(cmd, "LeiXing", DbType.Byte, info.LeiXing);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);
            _db.AddInParameter(cmd, "Status", DbType.Byte, info.Status);

            DbHelper.ExecuteSql(cmd, _db);

            return 1;
        }

        /// <summary>
        /// 获取验证码信息
        /// </summary>
        /// <param name="shouJi">手机号码</param>
        /// <param name="yanZhengMa">验证码</param>
        /// <param name="leiXing">类型</param>
        /// <returns></returns>
        public EyouSoft.Model.OtherStructure.MYanZhengMaInfo GetInfo(string shouJi, string yanZhengMa, EyouSoft.Model.Enum.YanZhengMaLeiXing leiXing)
        {
            EyouSoft.Model.OtherStructure.MYanZhengMaInfo info = null;
            string sql = "SELECT TOP(1) * FROM [tbl_YanZhengMa] WHERE ShouJi=@ShouJi AND [YanZhengMa]=@YanZhengMa AND LeiXing=@LeiXing AND [Status]=0 ORDER BY IdentityId DESC";
            var cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "ShouJi", DbType.String, shouJi);
            _db.AddInParameter(cmd, "YanZhengMa", DbType.String, yanZhengMa);
            _db.AddInParameter(cmd, "LeiXing", DbType.Byte, leiXing);

            using (var rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new EyouSoft.Model.OtherStructure.MYanZhengMaInfo();

                    info.IdentityId = rdr.GetInt32(rdr.GetOrdinal("IdentityId"));
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.LeiXing = leiXing;
                    info.ShouJi = shouJi;
                    info.Status = (EyouSoft.Model.Enum.YanZhengMaStatus)rdr.GetByte(rdr.GetOrdinal("Status"));
                    info.YanZhengMa = yanZhengMa;
                }
            }

            return info;
        }

        /// <summary>
        /// 设置验证码状态，返回1成功，其它失败
        /// </summary>
        /// <param name="identityId">验证码编号[自增编号]</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int SetStatus(int identityId, EyouSoft.Model.Enum.YanZhengMaStatus status)
        {
            string sql = "UPDATE tbl_YanZhengMa SET [Status]=@Status WHERE IdentityId=@IdentityId";
            var cmd=_db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "Status", DbType.Byte, status);
            _db.AddInParameter(cmd, "IdentityId", DbType.Int32, identityId);

            DbHelper.ExecuteSql(cmd, _db);

            return 1;
        }

        #endregion
    }
}
