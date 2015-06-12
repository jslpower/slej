using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.ZuCheStructure;
using EyouSoft.Toolkit.DAL;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EyouSoft.IDAL.ZuCheStructure;
using EyouSoft.Toolkit;
using EyouSoft.Model.Enum.XianLuStructure;
namespace EyouSoft.DAL.ZuCheStructure
{
    public class DZuChe : DALBase, IZuChe
    {
        #region
        const string SQL_UPDATE_SheZhiOrderStatus = "UPDATE [tbl_JA_ZuCheOrder] SET [Status]=@Status WHERE [OrderId]=@OrderId ";
        
        #endregion

        #region 初始化db
        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DZuChe()
        {
            _db = base.SystemStore;
        }
        #endregion

        /// <summary>
        /// 增加一条数据
        /// </summary>
        //public int Add(MZuCheInfo model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("insert into tbl_JA_ZuCheInfo(");
        //    strSql.Append("ZuCheID,CarName,XianZuoRenShu,MenShiJiaGeZuChe,MenShiJiaGeChaoShi,MenShiJiaGeChaoCheng,YouHuiJiaGeZuChe,YouHuiJiaGeChaoShi,YouHuiJiaGeChaoCheng,OperatorId,IssueTime,LatestId,LatestTime,IsRecommend,Remark,State,FilePath,MenShiJiaGeDanCheng,YouHuiJiaGeDanCheng)");

        //    strSql.Append(" values (");
        //    strSql.Append("@ZuCheID,@CarName,@XianZuoRenShu,@MenShiJiaGeZuChe,@MenShiJiaGeChaoShi,@MenShiJiaGeChaoCheng,@YouHuiJiaGeZuChe,@YouHuiJiaGeChaoShi,@YouHuiJiaGeChaoCheng,@OperatorId,@IssueTime,@LatestId,@LatestTime,@IsRecommend,@Remark,@State,@FilePath,@MenShiJiaGeDanCheng,@YouHuiJiaGeDanCheng)");
        //    DbCommand dbCommand = _db.GetSqlStringCommand(strSql.ToString());
        //    _db.AddInParameter(dbCommand, "ZuCheID", DbType.AnsiString, model.ZuCheID);
        //    _db.AddInParameter(dbCommand, "CarName", DbType.String, model.CarName);
        //    _db.AddInParameter(dbCommand, "XianZuoRenShu", DbType.Int32, model.XianZuoRenShu);
        //    _db.AddInParameter(dbCommand, "MenShiJiaGeZuChe", DbType.Currency, model.MenShiJiaGeZuChe);
        //    _db.AddInParameter(dbCommand, "MenShiJiaGeChaoShi", DbType.Currency, model.MenShiJiaGeChaoShi);
        //    _db.AddInParameter(dbCommand, "MenShiJiaGeChaoCheng", DbType.Currency, model.MenShiJiaGeChaoCheng);
        //    _db.AddInParameter(dbCommand, "YouHuiJiaGeZuChe", DbType.Currency, model.YouHuiJiaGeZuChe);
        //    _db.AddInParameter(dbCommand, "YouHuiJiaGeChaoShi", DbType.Currency, model.YouHuiJiaGeChaoShi);
        //    _db.AddInParameter(dbCommand, "YouHuiJiaGeChaoCheng", DbType.Currency, model.YouHuiJiaGeChaoCheng);
        //    _db.AddInParameter(dbCommand, "OperatorId", DbType.Int32, model.OperatorId);
        //    _db.AddInParameter(dbCommand, "IssueTime", DbType.DateTime, model.IssueTime);
        //    _db.AddInParameter(dbCommand, "LatestId", DbType.Int32, model.LatestId);
        //    _db.AddInParameter(dbCommand, "LatestTime", DbType.DateTime, model.LatestTime);
        //    _db.AddInParameter(dbCommand, "IsRecommend", DbType.AnsiString, model.IsRecommend);
        //    _db.AddInParameter(dbCommand, "Remark", DbType.String, model.Remark);
        //    _db.AddInParameter(dbCommand, "State", DbType.Byte, (int)model.State);
        //    _db.AddInParameter(dbCommand, "FilePath", DbType.String, model.FilePath);
        //    _db.AddInParameter(dbCommand, "MenShiJiaGeDanCheng", DbType.Currency, model.MenShiJiaGeDanCheng);
        //    _db.AddInParameter(dbCommand, "YouHuiJiaGeDanCheng", DbType.Currency, model.YouHuiJiaGeDanCheng);
        //    return DbHelper.ExecuteSql(dbCommand, this._db);
        //}

        public int Add(MZuCheInfo model)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_JA_ZucheInfo_ADD");
            _db.AddInParameter(cmd, "ZuCheID", DbType.AnsiString, model.ZuCheID);
            _db.AddInParameter(cmd, "CarName", DbType.String, model.CarName);
            _db.AddInParameter(cmd, "XianZuoRenShu", DbType.Int32, model.XianZuoRenShu);
            _db.AddInParameter(cmd, "MenShiJia", DbType.Currency, model.MenShiJia);
            _db.AddInParameter(cmd, "MenShiJiaGeZuChe", DbType.Currency, model.MenShiJiaGeZuChe);
            _db.AddInParameter(cmd, "MenShiChaoShi", DbType.Currency, model.MenShiChaoShi);
            _db.AddInParameter(cmd, "MenShiJiaGeChaoShi", DbType.Currency, model.MenShiJiaGeChaoShi);
            _db.AddInParameter(cmd, "MenShiChaoCheng", DbType.Currency, model.MenShiChaoCheng);
            _db.AddInParameter(cmd, "MenShiJiaGeChaoCheng", DbType.Currency, model.MenShiJiaGeChaoCheng);
            _db.AddInParameter(cmd, "YouHuiJia", DbType.Currency, model.YouHuiJia);
            _db.AddInParameter(cmd, "YouHuiJiaGeZuChe", DbType.Currency, model.YouHuiJiaGeZuChe);
            _db.AddInParameter(cmd, "YouHuiChaoShi", DbType.Currency, model.YouHuiChaoShi);
            _db.AddInParameter(cmd, "YouHuiJiaGeChaoShi", DbType.Currency, model.YouHuiJiaGeChaoShi);
            _db.AddInParameter(cmd, "YouHuiChaoCheng", DbType.Currency, model.YouHuiChaoCheng);
            _db.AddInParameter(cmd, "YouHuiJiaGeChaoCheng", DbType.Currency, model.YouHuiJiaGeChaoCheng);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, model.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, model.IssueTime);
            _db.AddInParameter(cmd, "LatestId", DbType.Int32, model.LatestId);
            _db.AddInParameter(cmd, "LatestTime", DbType.DateTime, model.LatestTime);
            _db.AddInParameter(cmd, "IsRecommend", DbType.AnsiString, model.IsRecommend);
            _db.AddInParameter(cmd, "Remark", DbType.String, model.Remark);
            _db.AddInParameter(cmd, "State", DbType.Byte, (int)model.State);
            _db.AddInParameter(cmd, "FilePath", DbType.String, model.FilePath);
            _db.AddInParameter(cmd, "MenShiJiaGeDanCheng", DbType.Currency, model.MenShiJiaGeDanCheng);
            _db.AddInParameter(cmd, "YouHuiJiaGeDanCheng", DbType.Currency, model.YouHuiJiaGeDanCheng);
            _db.AddInParameter(cmd, "ZuCheImg", DbType.String, CreateImgXml(model.ZucheInfoImg));
            _db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
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

            return Convert.ToInt32(_db.GetParameterValue(cmd, "Result"));

        }



        /// <summary>
        /// 更新一条数据
        /// </summary>
        //public int Update(MZuCheInfo model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("update tbl_JA_ZuCheInfo set ");
        //    strSql.Append("CarName=@CarName,");
        //    strSql.Append("XianZuoRenShu=@XianZuoRenShu,");
        //    strSql.Append("MenShiJiaGeZuChe=@MenShiJiaGeZuChe,");
        //    strSql.Append("MenShiJiaGeChaoShi=@MenShiJiaGeChaoShi,");
        //    strSql.Append("MenShiJiaGeChaoCheng=@MenShiJiaGeChaoCheng,");
        //    strSql.Append("YouHuiJiaGeZuChe=@YouHuiJiaGeZuChe,");
        //    strSql.Append("YouHuiJiaGeChaoShi=@YouHuiJiaGeChaoShi,");
        //    strSql.Append("YouHuiJiaGeChaoCheng=@YouHuiJiaGeChaoCheng,");
        //    strSql.Append("OperatorId=@OperatorId,");
        //    strSql.Append("IssueTime=@IssueTime,");
        //    strSql.Append("LatestId=@LatestId,");
        //    strSql.Append("LatestTime=@LatestTime,");
        //    strSql.Append("IsRecommend=@IsRecommend,");
        //    strSql.Append("Remark=@Remark,");
        //    //strSql.Append("State=@State,");
        //    strSql.Append("FilePath=@FilePath,");
        //    strSql.Append("MenShiJiaGeDanCheng=@MenShiJiaGeDanCheng,");
        //    strSql.Append("YouHuiJiaGeDanCheng=@YouHuiJiaGeDanCheng");
        //    strSql.Append(" where ZuCheID=@ZuCheID");
        //    DbCommand dbCommand = _db.GetSqlStringCommand(strSql.ToString());
        //    _db.AddInParameter(dbCommand, "ZuCheID", DbType.AnsiString, model.ZuCheID);
        //    _db.AddInParameter(dbCommand, "CarName", DbType.String, model.CarName);
        //    _db.AddInParameter(dbCommand, "XianZuoRenShu", DbType.Int32, model.XianZuoRenShu);
        //    _db.AddInParameter(dbCommand, "MenShiJiaGeZuChe", DbType.Currency, model.MenShiJiaGeZuChe);
        //    _db.AddInParameter(dbCommand, "MenShiJiaGeChaoShi", DbType.Currency, model.MenShiJiaGeChaoShi);
        //    _db.AddInParameter(dbCommand, "MenShiJiaGeChaoCheng", DbType.Currency, model.MenShiJiaGeChaoCheng);
        //    _db.AddInParameter(dbCommand, "YouHuiJiaGeZuChe", DbType.Currency, model.YouHuiJiaGeZuChe);
        //    _db.AddInParameter(dbCommand, "YouHuiJiaGeChaoShi", DbType.Currency, model.YouHuiJiaGeChaoShi);
        //    _db.AddInParameter(dbCommand, "YouHuiJiaGeChaoCheng", DbType.Currency, model.YouHuiJiaGeChaoCheng);
        //    _db.AddInParameter(dbCommand, "OperatorId", DbType.Int32, model.OperatorId);
        //    _db.AddInParameter(dbCommand, "IssueTime", DbType.DateTime, model.IssueTime);
        //    _db.AddInParameter(dbCommand, "LatestId", DbType.Int32, model.LatestId);
        //    _db.AddInParameter(dbCommand, "LatestTime", DbType.DateTime, model.LatestTime);
        //    _db.AddInParameter(dbCommand, "IsRecommend", DbType.AnsiString, model.IsRecommend);
        //    _db.AddInParameter(dbCommand, "Remark", DbType.String, model.Remark);
        //    //_db.AddInParameter(dbCommand, "State", DbType.Byte, (int)model.State);
        //    _db.AddInParameter(dbCommand, "FilePath", DbType.String, model.FilePath);
        //    _db.AddInParameter(dbCommand, "MenShiJiaGeDanCheng", DbType.Currency, model.MenShiJiaGeDanCheng);
        //    _db.AddInParameter(dbCommand, "YouHuiJiaGeDanCheng", DbType.Currency, model.YouHuiJiaGeDanCheng);
        //    return DbHelper.ExecuteSql(dbCommand, this._db);
        //}

        public int Update(MZuCheInfo model)
        {
            DbCommand cmd = _db.GetStoredProcCommand("proc_JA_ZucheInfo_Update");
            _db.AddInParameter(cmd, "ZuCheID", DbType.AnsiString, model.ZuCheID);
            _db.AddInParameter(cmd, "CarName", DbType.String, model.CarName);
            _db.AddInParameter(cmd, "XianZuoRenShu", DbType.Int32, model.XianZuoRenShu);
            _db.AddInParameter(cmd, "MenShiJia", DbType.Currency, model.MenShiJia);
            _db.AddInParameter(cmd, "MenShiJiaGeZuChe", DbType.Currency, model.MenShiJiaGeZuChe);
            _db.AddInParameter(cmd, "MenShiChaoShi", DbType.Currency, model.MenShiChaoShi);
            _db.AddInParameter(cmd, "MenShiJiaGeChaoShi", DbType.Currency, model.MenShiJiaGeChaoShi);
            _db.AddInParameter(cmd, "MenShiChaoCheng", DbType.Currency, model.MenShiChaoCheng);
            _db.AddInParameter(cmd, "MenShiJiaGeChaoCheng", DbType.Currency, model.MenShiJiaGeChaoCheng);
            _db.AddInParameter(cmd, "YouHuiJia", DbType.Currency, model.YouHuiJia);
            _db.AddInParameter(cmd, "YouHuiJiaGeZuChe", DbType.Currency, model.YouHuiJiaGeZuChe);
            _db.AddInParameter(cmd, "YouHuiChaoShi", DbType.Currency, model.YouHuiChaoShi);
            _db.AddInParameter(cmd, "YouHuiJiaGeChaoShi", DbType.Currency, model.YouHuiJiaGeChaoShi);
            _db.AddInParameter(cmd, "YouHuiChaoCheng", DbType.Currency, model.YouHuiChaoCheng);
            _db.AddInParameter(cmd, "YouHuiJiaGeChaoCheng", DbType.Currency, model.YouHuiJiaGeChaoCheng);
            _db.AddInParameter(cmd, "OperatorId", DbType.Int32, model.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, model.IssueTime);
            _db.AddInParameter(cmd, "LatestId", DbType.Int32, model.LatestId);
            _db.AddInParameter(cmd, "LatestTime", DbType.DateTime, model.LatestTime);
            _db.AddInParameter(cmd, "IsRecommend", DbType.AnsiString, model.IsRecommend);
            _db.AddInParameter(cmd, "Remark", DbType.String, model.Remark);
            _db.AddInParameter(cmd, "FilePath", DbType.String, model.FilePath);
            _db.AddInParameter(cmd, "MenShiJiaGeDanCheng", DbType.Currency, model.MenShiJiaGeDanCheng);
            _db.AddInParameter(cmd, "YouHuiJiaGeDanCheng", DbType.Currency, model.YouHuiJiaGeDanCheng);
            _db.AddInParameter(cmd, "ZuCheImg", DbType.String, CreateImgXml(model.ZucheInfoImg));
            _db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
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

            return Convert.ToInt32(_db.GetParameterValue(cmd, "Result"));
        }



        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(string ZuCheID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbl_JA_ZuCheInfo ");
            strSql.Append(" where ZuCheID=@ZuCheID");
            DbCommand dbCommand = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dbCommand, "ZuCheID", DbType.AnsiString, ZuCheID);
            return DbHelper.ExecuteSql(dbCommand, this._db) > 0 ? 1 : 0;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MZuCheInfo GetModel(string ZuCheID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ZuCheID,CarName,XianZuoRenShu,MenShiJia,MenShiJiaGeZuChe,MenShiChaoShi,MenShiChaoCheng,MenShiJiaGeChaoShi,MenShiJiaGeChaoCheng,YouHuiJia,YouHuiJiaGeZuChe,YouHuiChaoShi,YouHuiJiaGeChaoShi,YouHuiChaoCheng,YouHuiJiaGeChaoCheng,OperatorId,IssueTime,LatestId,LatestTime,IdentityId,IsRecommend,Remark,State,FilePath,MenShiJiaGeDanCheng,YouHuiJiaGeDanCheng from tbl_JA_ZuCheInfo ");
            strSql.Append(" where ZuCheID=@ZuCheID");
            DbCommand dbCommand = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dbCommand, "ZuCheID", DbType.AnsiString, ZuCheID);
            MZuCheInfo model = null;
            using (IDataReader dr = DbHelper.ExecuteReader(dbCommand, this._db))
            {
                while (dr.Read())
                {
                    model = new MZuCheInfo();
                    model.ZuCheID = dr.GetString(dr.GetOrdinal("ZuCheID"));
                    model.CarName = dr.GetString(dr.GetOrdinal("CarName"));
                    model.XianZuoRenShu = !dr.IsDBNull(dr.GetOrdinal("XianZuoRenShu")) ? dr.GetInt32(dr.GetOrdinal("XianZuoRenShu")) : 0;
                    model.MenShiJia = !dr.IsDBNull(dr.GetOrdinal("MenShiJia")) ? dr.GetDecimal(dr.GetOrdinal("MenShiJia")) : 0;
                    model.MenShiJiaGeZuChe = !dr.IsDBNull(dr.GetOrdinal("MenShiJiaGeZuChe")) ? dr.GetDecimal(dr.GetOrdinal("MenShiJiaGeZuChe")) : 0;
                    model.MenShiChaoShi = !dr.IsDBNull(dr.GetOrdinal("MenShiChaoShi")) ? dr.GetDecimal(dr.GetOrdinal("MenShiChaoShi")) : 0;
                    model.MenShiJiaGeChaoShi = !dr.IsDBNull(dr.GetOrdinal("MenShiJiaGeChaoShi")) ? dr.GetDecimal(dr.GetOrdinal("MenShiJiaGeChaoShi")) : 0;
                    model.MenShiChaoCheng = !dr.IsDBNull(dr.GetOrdinal("MenShiChaoCheng")) ? dr.GetDecimal(dr.GetOrdinal("MenShiChaoCheng")) : 0;
                    model.MenShiJiaGeChaoCheng = !dr.IsDBNull(dr.GetOrdinal("MenShiJiaGeChaoCheng")) ? dr.GetDecimal(dr.GetOrdinal("MenShiJiaGeChaoCheng")) : 0;
                    model.YouHuiJia = !dr.IsDBNull(dr.GetOrdinal("YouHuiJia")) ? dr.GetDecimal(dr.GetOrdinal("YouHuiJia")) : 0;
                    model.YouHuiJiaGeZuChe = !dr.IsDBNull(dr.GetOrdinal("YouHuiJiaGeZuChe")) ? dr.GetDecimal(dr.GetOrdinal("YouHuiJiaGeZuChe")) : 0;
                    model.YouHuiChaoCheng = !dr.IsDBNull(dr.GetOrdinal("YouHuiChaoCheng")) ? dr.GetDecimal(dr.GetOrdinal("YouHuiChaoCheng")) : 0;
                    model.YouHuiJiaGeChaoCheng = !dr.IsDBNull(dr.GetOrdinal("YouHuiJiaGeChaoCheng")) ? dr.GetDecimal(dr.GetOrdinal("YouHuiJiaGeChaoCheng")) : 0;
                    model.YouHuiChaoShi = !dr.IsDBNull(dr.GetOrdinal("YouHuiChaoShi")) ? dr.GetDecimal(dr.GetOrdinal("YouHuiChaoShi")) : 0;
                    model.YouHuiJiaGeChaoShi = !dr.IsDBNull(dr.GetOrdinal("YouHuiJiaGeChaoShi")) ? dr.GetDecimal(dr.GetOrdinal("YouHuiJiaGeChaoShi")) : 0;
                    model.OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime"))) model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.LatestId = !dr.IsDBNull(dr.GetOrdinal("LatestId")) ? dr.GetInt32(dr.GetOrdinal("LatestId")) : 0;
                    if (!dr.IsDBNull(dr.GetOrdinal("LatestTime"))) model.LatestTime = dr.GetDateTime(dr.GetOrdinal("LatestTime"));
                    model.IdentityId = !dr.IsDBNull(dr.GetOrdinal("IdentityId")) ? dr.GetInt32(dr.GetOrdinal("IdentityId")) : 0;
                    model.IsRecommend = !dr.IsDBNull(dr.GetOrdinal("IsRecommend")) ? dr.GetString(dr.GetOrdinal("IsRecommend")) : "0";
                    model.Remark = !dr.IsDBNull(dr.GetOrdinal("Remark")) ? dr.GetString(dr.GetOrdinal("Remark")) : "";
                    model.State = (Model.Enum.ZuCheStates)dr.GetOrdinal("State");
                    model.FilePath = !dr.IsDBNull(dr.GetOrdinal("FilePath")) ? dr.GetString(dr.GetOrdinal("FilePath")) : "";
                    model.MenShiJiaGeDanCheng = !dr.IsDBNull(dr.GetOrdinal("MenShiJiaGeDanCheng")) ? dr.GetDecimal(dr.GetOrdinal("MenShiJiaGeDanCheng")) : 0;
                    model.YouHuiJiaGeDanCheng = !dr.IsDBNull(dr.GetOrdinal("YouHuiJiaGeDanCheng")) ? dr.GetDecimal(dr.GetOrdinal("YouHuiJiaGeDanCheng")) : 0;
                    model.ZucheInfoImg = ZuCheImgList(model.ZuCheID);
                }
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表集合，分页
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        public IList<MZuCheInfo> GetList(int pageSize, int pageIndex, ref int recordCount, MZuCheInfoChaXun chaXun)
        {
            IList<MZuCheInfo> ResultList = new List<MZuCheInfo>();
            string tableName = "tbl_JA_ZuCheInfo";
            string fields = "ZuCheID,CarName,XianZuoRenShu,MenShiJia,MenShiJiaGeZuChe,MenShiChaoShi,MenShiChaoCheng,MenShiJiaGeChaoShi,MenShiJiaGeChaoCheng,YouHuiJia,YouHuiJiaGeZuChe,YouHuiChaoShi,YouHuiJiaGeChaoShi,YouHuiChaoCheng,YouHuiJiaGeChaoCheng,OperatorId,IssueTime,LatestId,LatestTime,IdentityId,IsRecommend,Remark,State,FilePath,MenShiJiaGeDanCheng,YouHuiJiaGeDanCheng,IsIndex,ProductSort ";
            string query = " 1=1 ";
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.CarName))
                {
                    query = query + string.Format(" AND CarName like '%{0}%'", chaXun.CarName);
                }
                if (chaXun.State.HasValue)
                {
                    query = query + string.Format(" AND State={0}", (int)chaXun.State.Value);
                }
            }
            string orderByString = "IssueTime DESC";
            using (IDataReader dr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields
               , query, orderByString, string.Empty))
            {
                //ResultList = new List<MZuCheInfo>();
                while (dr.Read())
                {
                    MZuCheInfo model = new MZuCheInfo();
                    model.ZuCheID = dr.GetString(dr.GetOrdinal("ZuCheID"));
                    model.CarName = dr.GetString(dr.GetOrdinal("CarName"));
                    model.XianZuoRenShu = !dr.IsDBNull(dr.GetOrdinal("XianZuoRenShu")) ? dr.GetInt32(dr.GetOrdinal("XianZuoRenShu")) : 0;
                    model.MenShiJia = !dr.IsDBNull(dr.GetOrdinal("MenShiJia")) ? dr.GetDecimal(dr.GetOrdinal("MenShiJia")) : 0;
                    model.MenShiJiaGeZuChe = !dr.IsDBNull(dr.GetOrdinal("MenShiJiaGeZuChe")) ? dr.GetDecimal(dr.GetOrdinal("MenShiJiaGeZuChe")) : 0;
                    model.MenShiChaoShi = !dr.IsDBNull(dr.GetOrdinal("MenShiChaoShi")) ? dr.GetDecimal(dr.GetOrdinal("MenShiChaoShi")) : 0;
                    model.MenShiJiaGeChaoShi = !dr.IsDBNull(dr.GetOrdinal("MenShiJiaGeChaoShi")) ? dr.GetDecimal(dr.GetOrdinal("MenShiJiaGeChaoShi")) : 0;
                    model.MenShiChaoCheng = !dr.IsDBNull(dr.GetOrdinal("MenShiChaoCheng")) ? dr.GetDecimal(dr.GetOrdinal("MenShiChaoCheng")) : 0;
                    model.MenShiJiaGeChaoCheng = !dr.IsDBNull(dr.GetOrdinal("MenShiJiaGeChaoCheng")) ? dr.GetDecimal(dr.GetOrdinal("MenShiJiaGeChaoCheng")) : 0;
                    model.YouHuiJia = !dr.IsDBNull(dr.GetOrdinal("YouHuiJia")) ? dr.GetDecimal(dr.GetOrdinal("YouHuiJia")) : 0;
                    model.YouHuiJiaGeZuChe = !dr.IsDBNull(dr.GetOrdinal("YouHuiJiaGeZuChe")) ? dr.GetDecimal(dr.GetOrdinal("YouHuiJiaGeZuChe")) : 0;
                    model.YouHuiChaoCheng = !dr.IsDBNull(dr.GetOrdinal("YouHuiChaoCheng")) ? dr.GetDecimal(dr.GetOrdinal("YouHuiChaoCheng")) : 0;
                    model.YouHuiJiaGeChaoCheng = !dr.IsDBNull(dr.GetOrdinal("YouHuiJiaGeChaoCheng")) ? dr.GetDecimal(dr.GetOrdinal("YouHuiJiaGeChaoCheng")) : 0;
                    model.YouHuiChaoShi = !dr.IsDBNull(dr.GetOrdinal("YouHuiChaoShi")) ? dr.GetDecimal(dr.GetOrdinal("YouHuiChaoShi")) : 0;
                    model.YouHuiJiaGeChaoShi = !dr.IsDBNull(dr.GetOrdinal("YouHuiJiaGeChaoShi")) ? dr.GetDecimal(dr.GetOrdinal("YouHuiJiaGeChaoShi")) : 0;
                    model.OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime"))) model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.LatestId = !dr.IsDBNull(dr.GetOrdinal("LatestId")) ? dr.GetInt32(dr.GetOrdinal("LatestId")) : 0;
                    if (!dr.IsDBNull(dr.GetOrdinal("LatestTime"))) model.LatestTime = dr.GetDateTime(dr.GetOrdinal("LatestTime"));
                    model.IdentityId = !dr.IsDBNull(dr.GetOrdinal("IdentityId")) ? dr.GetInt32(dr.GetOrdinal("IdentityId")) : 0;
                    model.IsRecommend = !dr.IsDBNull(dr.GetOrdinal("IsRecommend")) ? dr.GetString(dr.GetOrdinal("IsRecommend")) : "0";
                    model.Remark = !dr.IsDBNull(dr.GetOrdinal("Remark")) ? dr.GetString(dr.GetOrdinal("Remark")) : "";
                    model.State = (EyouSoft.Model.Enum.ZuCheStates)dr.GetByte(dr.GetOrdinal("State"));
                    model.FilePath = !dr.IsDBNull(dr.GetOrdinal("FilePath")) ? dr.GetString(dr.GetOrdinal("FilePath")) : "";
                    model.MenShiJiaGeDanCheng = !dr.IsDBNull(dr.GetOrdinal("MenShiJiaGeDanCheng")) ? dr.GetDecimal(dr.GetOrdinal("MenShiJiaGeDanCheng")) : 0;
                    model.YouHuiJiaGeDanCheng = !dr.IsDBNull(dr.GetOrdinal("YouHuiJiaGeDanCheng")) ? dr.GetDecimal(dr.GetOrdinal("YouHuiJiaGeDanCheng")) : 0;
                    model.ZucheInfoImg = ZuCheImgList(model.ZuCheID);
                    model.IsIndex = (XianLuZT)dr.GetByte(dr.GetOrdinal("IsIndex"));
                    model.ProductSort = dr.GetInt32(dr.GetOrdinal("ProductSort"));
                    ResultList.Add(model);
                }
            }
            return ResultList;
        }
        /// <summary>
        /// 获得前几条数据列表集合
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        public IList<MZuCheInfo> GetList(int Top, MZuCheInfoChaXun chaXun)
        {
            IList<MZuCheInfo> ResultList = new List<MZuCheInfo>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ZuCheID,CarName,XianZuoRenShu,MenShiJia,MenShiJiaGeZuChe,MenShiChaoShi,MenShiChaoCheng,MenShiJiaGeChaoShi,MenShiJiaGeChaoCheng,YouHuiJia,YouHuiJiaGeZuChe,YouHuiChaoShi,YouHuiJiaGeChaoShi,YouHuiChaoCheng,YouHuiJiaGeChaoCheng,OperatorId,IssueTime,LatestId,LatestTime,IdentityId,IsRecommend,Remark,State,FilePath,MenShiJiaGeDanCheng,YouHuiJiaGeDanCheng ");
            strSql.Append(" FROM tbl_JA_ZuCheInfo ");
            strSql.Append(" where 1=1 ");
            if (chaXun != null)
            {
                if (!string.IsNullOrEmpty(chaXun.CarName))
                {
                    strSql.AppendFormat(" AND CarName like '%{0}%'", chaXun.CarName);
                }
                if (chaXun.State.HasValue)
                {
                    strSql.AppendFormat(" AND State={0}", (int)chaXun.State.Value);
                }
                if (chaXun.IsIndex.HasValue)
                {
                    strSql.AppendFormat(" AND IsIndex={0}", (int)chaXun.IsIndex.Value);
                }
                if (chaXun.PSort > 0)
                {
                    strSql.Append(" and ProductSort>0 ");
                }
            }
            strSql.Append(" order by ProductSort Asc,IssueTime DESC ");
            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());

            using (IDataReader dr = DbHelper.ExecuteReader(dc, _db))
            {
                while (dr.Read())
                {
                    MZuCheInfo model = new MZuCheInfo();
                    model.ZuCheID = dr.GetString(dr.GetOrdinal("ZuCheID"));
                    model.CarName = dr.GetString(dr.GetOrdinal("CarName"));
                    model.MenShiJia = !dr.IsDBNull(dr.GetOrdinal("MenShiJia")) ? dr.GetDecimal(dr.GetOrdinal("MenShiJia")) : 0;
                    model.XianZuoRenShu = !dr.IsDBNull(dr.GetOrdinal("XianZuoRenShu")) ? dr.GetInt32(dr.GetOrdinal("XianZuoRenShu")) : 0;
                    model.MenShiJiaGeZuChe = !dr.IsDBNull(dr.GetOrdinal("MenShiJiaGeZuChe")) ? dr.GetDecimal(dr.GetOrdinal("MenShiJiaGeZuChe")) : 0;
                    model.MenShiChaoShi = !dr.IsDBNull(dr.GetOrdinal("MenShiChaoShi")) ? dr.GetDecimal(dr.GetOrdinal("MenShiChaoShi")) : 0;
                    model.MenShiJiaGeChaoShi = !dr.IsDBNull(dr.GetOrdinal("MenShiJiaGeChaoShi")) ? dr.GetDecimal(dr.GetOrdinal("MenShiJiaGeChaoShi")) : 0;
                    model.MenShiChaoCheng = !dr.IsDBNull(dr.GetOrdinal("MenShiChaoCheng")) ? dr.GetDecimal(dr.GetOrdinal("MenShiChaoCheng")) : 0;
                    model.MenShiJiaGeChaoCheng = !dr.IsDBNull(dr.GetOrdinal("MenShiJiaGeChaoCheng")) ? dr.GetDecimal(dr.GetOrdinal("MenShiJiaGeChaoCheng")) : 0;
                    model.YouHuiJia = !dr.IsDBNull(dr.GetOrdinal("YouHuiJia")) ? dr.GetDecimal(dr.GetOrdinal("YouHuiJia")) : 0;
                    model.YouHuiJiaGeZuChe = !dr.IsDBNull(dr.GetOrdinal("YouHuiJiaGeZuChe")) ? dr.GetDecimal(dr.GetOrdinal("YouHuiJiaGeZuChe")) : 0;
                    model.YouHuiChaoCheng = !dr.IsDBNull(dr.GetOrdinal("YouHuiChaoCheng")) ? dr.GetDecimal(dr.GetOrdinal("YouHuiChaoCheng")) : 0;
                    model.YouHuiJiaGeChaoCheng = !dr.IsDBNull(dr.GetOrdinal("YouHuiJiaGeChaoCheng")) ? dr.GetDecimal(dr.GetOrdinal("YouHuiJiaGeChaoCheng")) : 0;
                    model.YouHuiChaoShi = !dr.IsDBNull(dr.GetOrdinal("YouHuiChaoShi")) ? dr.GetDecimal(dr.GetOrdinal("YouHuiChaoShi")) : 0;
                    model.YouHuiJiaGeChaoShi = !dr.IsDBNull(dr.GetOrdinal("YouHuiJiaGeChaoShi")) ? dr.GetDecimal(dr.GetOrdinal("YouHuiJiaGeChaoShi")) : 0;
                    model.OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"));
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime"))) model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.LatestId = !dr.IsDBNull(dr.GetOrdinal("LatestId")) ? dr.GetInt32(dr.GetOrdinal("LatestId")) : 0;
                    if (!dr.IsDBNull(dr.GetOrdinal("LatestTime"))) model.LatestTime = dr.GetDateTime(dr.GetOrdinal("LatestTime"));
                    model.IdentityId = !dr.IsDBNull(dr.GetOrdinal("IdentityId")) ? dr.GetInt32(dr.GetOrdinal("IdentityId")) : 0;
                    model.IsRecommend = !dr.IsDBNull(dr.GetOrdinal("IsRecommend")) ? dr.GetString(dr.GetOrdinal("IsRecommend")) : "0";
                    model.Remark = !dr.IsDBNull(dr.GetOrdinal("Remark")) ? dr.GetString(dr.GetOrdinal("Remark")) : "";
                    model.State = (EyouSoft.Model.Enum.ZuCheStates)dr.GetByte(dr.GetOrdinal("State"));
                    model.FilePath = !dr.IsDBNull(dr.GetOrdinal("FilePath")) ? dr.GetString(dr.GetOrdinal("FilePath")) : "";
                    model.MenShiJiaGeZuChe = !dr.IsDBNull(dr.GetOrdinal("MenShiJiaGeDanCheng")) ? dr.GetDecimal(dr.GetOrdinal("MenShiJiaGeDanCheng")) : 0;
                    model.MenShiJiaGeZuChe = !dr.IsDBNull(dr.GetOrdinal("YouHuiJiaGeDanCheng")) ? dr.GetDecimal(dr.GetOrdinal("YouHuiJiaGeDanCheng")) : 0;
                    model.ZucheInfoImg = ZuCheImgList(model.ZuCheID);
                    if (model.ZucheInfoImg.Count > 0)
                        model.FilePath = model.ZucheInfoImg[0].FilePath;
                    ResultList.Add(model);
                }
            }

            return ResultList;
        }

        /// <summary>
        /// 更改状态
        /// </summary>
        /// <param name="ZuCheID"></param>
        /// <param name="en"></param>
        /// <returns></returns>
        public int updageState(string ZuCheID, EyouSoft.Model.Enum.ZuCheStates en)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbl_JA_ZuCheInfo set ");
            strSql.Append("State=@State");
            strSql.Append(" where ZuCheID=@ZuCheID");
            DbCommand dbCommand = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dbCommand, "State", DbType.Byte, (int)en);
            _db.AddInParameter(dbCommand, "ZuCheID", DbType.AnsiString, ZuCheID);
            return DbHelper.ExecuteSql(dbCommand, this._db);
        }

        /// <summary>
        /// 设置首页显示
        /// </summary>
        /// <param name="ZuCheID"></param>
        /// <param name="isbool"></param>
        /// <returns></returns>
        public int updageIsIndex(string ZuCheID,XianLuZT isbool)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbl_JA_ZuCheInfo set ");
            strSql.Append("IsIndex=@IsIndex");
            strSql.Append(" where ZuCheID=@ZuCheID");
            DbCommand dbCommand = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dbCommand, "IsIndex", DbType.Byte, (int)isbool);
            _db.AddInParameter(dbCommand, "ZuCheID", DbType.AnsiString, ZuCheID);
            return DbHelper.ExecuteSql(dbCommand, this._db);
        }

        /// <summary>
        /// 设置订单状态，返回1成功，其它失败
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int SheZhiOrderStatus(string orderId, OrderStatus status)
        {
            DbCommand cmd = _db.GetSqlStringCommand(SQL_UPDATE_SheZhiOrderStatus);

            _db.AddInParameter(cmd, "Status", DbType.Byte, status);
            _db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, orderId);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public IList<ZuCheImg> ZuCheImgList(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ImgID,ZuCheID,ImgCategory,FilePath,[Desc],IssueTime,OperatorId FROM [tbl_JA_ZuCheImg] ");
            strSql.Append(" WHERE ZuCheID=@ZuCheID order by ImgID ");
            DbCommand dbCommand = _db.GetSqlStringCommand(strSql.ToString());
            _db.AddInParameter(dbCommand, "ZuCheID", DbType.AnsiString, ID);
            IList<ZuCheImg> list = new List<ZuCheImg>();
            using (IDataReader dr = DbHelper.ExecuteReader(dbCommand, this._db))
            {
                while (dr.Read())
                {
                    ZuCheImg model = new ZuCheImg();
                    model.ZuCheID = dr.GetString(dr.GetOrdinal("ZuCheID"));
                    model.ImgID =dr.GetInt32(dr.GetOrdinal("ImgID"));
                    //model.ImgCategory = !dr.IsDBNull(dr.GetOrdinal("ImgCategory")) ? dr.GetInt32(dr.GetOrdinal("ImgCategory")) : 0;
                    model.FilePath = !dr.IsDBNull(dr.GetOrdinal("FilePath")) ? dr.GetString(dr.GetOrdinal("FilePath")) : "";
                    model.Desc = !dr.IsDBNull(dr.GetOrdinal("Desc")) ? dr.GetString(dr.GetOrdinal("Desc")) : "";
                    if (!dr.IsDBNull(dr.GetOrdinal("IssueTime"))) model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.OperatorId = !dr.IsDBNull(dr.GetOrdinal("OperatorId")) ? dr.GetString(dr.GetOrdinal("OperatorId")) : "0";
                    if (model != null) list.Add(model);
                }
            }
            return list;
        }

        #region private xml
        string CreateImgXml(IList<ZuCheImg> items)
        {
            StringBuilder s = new StringBuilder();
            s.Append("<root>");
            foreach (var item in items)
            {
                s.Append("<info ");
                s.AppendFormat(" ImgCategory=\"{0}\"", Utils.ReplaceXmlSpecialCharacter(item.ImgCategory.ToString()));
                s.AppendFormat(" FilePath=\"{0}\"", Utils.ReplaceXmlSpecialCharacter(item.FilePath));
                s.AppendFormat(" Desc=\"{0}\"", Utils.ReplaceXmlSpecialCharacter(item.Desc.ToString()!=null?item.Desc.ToString():""));
                s.AppendFormat(" IssueTime=\"{0}\"", Utils.ReplaceXmlSpecialCharacter(item.IssueTime.ToString()));
                s.AppendFormat(" OperatorId=\"{0}\"", Utils.ReplaceXmlSpecialCharacter(item.OperatorId.ToString()));
                s.Append(" />");
            }
            s.Append("</root>");
            return s.ToString();
        }
        #endregion
    }
}
