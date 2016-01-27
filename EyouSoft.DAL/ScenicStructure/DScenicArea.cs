using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using EyouSoft.Toolkit;
using EyouSoft.Toolkit.DAL;
using System.Data;
using System.Xml.Linq;
using EyouSoft.Model.ScenicStructure;
using EyouSoft.Model.Enum;
using EyouSoft.Model.ScenicStructure.WebModel;
using EyouSoft.Model.Enum.ScenicStructure;
using EyouSoft.Model.Enum.XianLuStructure;

namespace EyouSoft.DAL.ScenicStructure
{

    public class DScenicArea : DALBase, EyouSoft.IDAL.ScenicStructure.IScenicArea
    {
        #region
        const string SQL_UPDATE_SheZhiOrderStatus = "UPDATE [tbl_ScenicAreaOrder] SET [Status]=@Status WHERE [OrderId]=@OrderId ";

        #endregion
        #region 初始化db
        private Database _db = null;

        /// <summary>
        /// 初始化_db
        /// </summary>
        public DScenicArea()
        {
            _db = base.SystemStore;
        }
        #endregion

        #region IScenicArea 景区

        /// <summary>
        /// 添加景点
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddScenicArea(EyouSoft.Model.ScenicStructure.MScenicArea model)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_ScenicArea_Add");

            this._db.AddInParameter(cmd, "ScenicId", DbType.AnsiStringFixedLength, model.ScenicId);
            this._db.AddInParameter(cmd, "IsRecommend", DbType.AnsiStringFixedLength, model.IsRecommend ? 1 : 0);
            this._db.AddInParameter(cmd, "ScenicName", DbType.AnsiStringFixedLength, model.ScenicName);
            this._db.AddInParameter(cmd, "EnName", DbType.AnsiStringFixedLength, model.EnName);
            this._db.AddInParameter(cmd, "X", DbType.AnsiStringFixedLength, model.X);
            this._db.AddInParameter(cmd, "Y", DbType.AnsiStringFixedLength, model.Y);
            this._db.AddInParameter(cmd, "ServiceTel", DbType.String, model.ServiceTel);
            this._db.AddInParameter(cmd, "EnAddress", DbType.String, model.EnAddress);
            this._db.AddInParameter(cmd, "Contact", DbType.String, model.Contact);
            this._db.AddInParameter(cmd, "ContactTel", DbType.String, model.ContactTel);
            this._db.AddInParameter(cmd, "ContactMobile", DbType.String, model.ContactMobile);
            this._db.AddInParameter(cmd, "ContactFax", DbType.String, model.ContactFax);
            this._db.AddInParameter(cmd, "ProvinceId", DbType.Int32, model.ProvinceId);
            this._db.AddInParameter(cmd, "CityId", DbType.Int32, model.CityId);
            this._db.AddInParameter(cmd, "CountyId", DbType.Int32, model.CountyId);
            this._db.AddInParameter(cmd, "CnAddress", DbType.String, model.CnAddress);
            this._db.AddInParameter(cmd, "ScenicLevel", DbType.Byte, (int)model.ScenicLevel);
            this._db.AddInParameter(cmd, "Year", DbType.Int32, model.Year);
            this._db.AddInParameter(cmd, "OpenTime", DbType.String, model.OpenTime);
            this._db.AddInParameter(cmd, "Description", DbType.String, model.Description);
            this._db.AddInParameter(cmd, "Traffic", DbType.String, model.Traffic);
            this._db.AddInParameter(cmd, "Facilities", DbType.String, model.Facilities);
            this._db.AddInParameter(cmd, "Notes", DbType.String, model.Notes);
            this._db.AddInParameter(cmd, "OperatorId", DbType.AnsiStringFixedLength, model.OperatorId);
            this._db.AddInParameter(cmd, "ScenicRelationLandMark", DbType.Xml, CreateXml(model.MarkList));
            this._db.AddInParameter(cmd, "JieSuanType", DbType.AnsiStringFixedLength, model.JieSuanType ? 1 : 0);
            this._db.AddInParameter(cmd, "ChanPinSource", DbType.String, model.ChanPinSource);
            this._db.AddInParameter(cmd, "InterfaceID", DbType.String, model.InterfaceID);
            this._db.AddInParameter(cmd, "NetAddress", DbType.String, model.NetAddress);

            this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);

            DbHelper.RunProcedureWithResult(cmd, this._db);

            return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result")) > 0 ? true : false;
        }
        /// <summary>
        /// 修改景点
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateScenicArea(EyouSoft.Model.ScenicStructure.MScenicArea model)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_ScenicArea_Update");

            this._db.AddInParameter(cmd, "ScenicId", DbType.AnsiStringFixedLength, model.ScenicId);
            this._db.AddInParameter(cmd, "IsRecommend", DbType.AnsiStringFixedLength, model.IsRecommend ? 1 : 0);
            this._db.AddInParameter(cmd, "ScenicName", DbType.AnsiStringFixedLength, model.ScenicName);
            this._db.AddInParameter(cmd, "EnName", DbType.AnsiStringFixedLength, model.EnName);
            this._db.AddInParameter(cmd, "X", DbType.AnsiStringFixedLength, model.X);
            this._db.AddInParameter(cmd, "Y", DbType.AnsiStringFixedLength, model.Y);
            this._db.AddInParameter(cmd, "ServiceTel", DbType.String, model.ServiceTel);
            this._db.AddInParameter(cmd, "Contact", DbType.String, model.Contact);
            this._db.AddInParameter(cmd, "ContactTel", DbType.String, model.ContactTel);
            this._db.AddInParameter(cmd, "ContactMobile", DbType.String, model.ContactMobile);
            this._db.AddInParameter(cmd, "ContactFax", DbType.String, model.ContactFax);
            this._db.AddInParameter(cmd, "ProvinceId", DbType.Int32, model.ProvinceId);
            this._db.AddInParameter(cmd, "CityId", DbType.Int32, model.CityId);
            this._db.AddInParameter(cmd, "CountyId", DbType.Int32, model.CountyId);
            this._db.AddInParameter(cmd, "CnAddress", DbType.String, model.CnAddress);
            this._db.AddInParameter(cmd, "EnAddress", DbType.String, model.EnAddress);
            this._db.AddInParameter(cmd, "ScenicLevel", DbType.Byte, (int)model.ScenicLevel);
            this._db.AddInParameter(cmd, "Year", DbType.Int32, model.Year);
            this._db.AddInParameter(cmd, "OpenTime", DbType.String, model.OpenTime);
            this._db.AddInParameter(cmd, "Description", DbType.String, model.Description);
            this._db.AddInParameter(cmd, "Traffic", DbType.String, model.Traffic);
            this._db.AddInParameter(cmd, "Facilities", DbType.String, model.Facilities);
            this._db.AddInParameter(cmd, "Notes", DbType.String, model.Notes);
            this._db.AddInParameter(cmd, "OperatorId", DbType.AnsiStringFixedLength, model.OperatorId);
            this._db.AddInParameter(cmd, "ScenicRelationLandMark", DbType.Xml, CreateXml(model.MarkList));
            this._db.AddInParameter(cmd, "JieSuanType", DbType.AnsiStringFixedLength, model.JieSuanType ? 1 : 0);
            this._db.AddInParameter(cmd, "NetAddress", DbType.String, model.NetAddress);
            this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);

            DbHelper.RunProcedureWithResult(cmd, this._db);

            return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result")) > 0 ? true : false;
        }

        /// <summary>
        /// 删除景区
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteScenicArea(string Id)
        {
            var sql = new StringBuilder();
            sql.Append(" if not exists (select 1 from tbl_ScenicAreaOrder where ScenicId = @ScenicId) begin ");
            sql.Append(" DELETE FROM tbl_ScenicRelationLandMark WHERE ScenicId=@ScenicId ;");
            sql.Append(" DELETE FROM tbl_ScenicAreaImg WHERE ScenicId=@ScenicId ;");
            sql.Append(" DELETE FROM tbl_ScenicTickets WHERE ScenicId=@ScenicId ;");
            sql.Append(" DELETE FROM tbl_ScenicArea WHERE ScenicId=@ScenicId ;");
            sql.Append(" end ");
            DbCommand cmd = this._db.GetSqlStringCommand(sql.ToString());

            this._db.AddInParameter(cmd, "ScenicId", DbType.String, Id);
            return DbHelper.ExecuteSqlTrans(cmd, this._db) > 0 ? true : false;


        }
        /// <summary>
        /// 设置点击次数
        /// </summary>
        public void SetScenicAreaClickNum(string Id)
        {
            string sql = "update tbl_ScenicArea set ClickNum=ClickNum+1 where ScenicId=@ScenicId";
            DbCommand cmd = this._db.GetSqlStringCommand(sql);

            this._db.AddInParameter(cmd, "ScenicId", DbType.Int32, Id);

            DbHelper.ExecuteSql(cmd, this._db);
        }
        /// <summary>
        /// 修改状态
        /// </summary>
        public int UpdateState(string Id,EyouSoft.Model.Enum.XianLuStructure.XianLuZT state)
        {
            string sql = "update tbl_ScenicArea set IsIndex=@IsIndex where ScenicId=@ScenicId";
            DbCommand cmd = this._db.GetSqlStringCommand(sql);

            this._db.AddInParameter(cmd, "ScenicId", DbType.String, Id);
            this._db.AddInParameter(cmd, "IsIndex", DbType.Byte, (int)state);

            return DbHelper.ExecuteSql(cmd, this._db);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EyouSoft.Model.ScenicStructure.MScenicArea GetScenicAreaById(string Id)
        {
            EyouSoft.Model.ScenicStructure.MScenicArea model = new EyouSoft.Model.ScenicStructure.MScenicArea();

            StringBuilder fields = new StringBuilder();
            fields.Append(" SELECT NetAddress,");
            fields.Append("ScenicId,IsRecommend,ScenicName,EnName,X,Y,ServiceTel,Contact,ContactTel,ContactMobile,ContactFax");
            fields.Append(",ProvinceId,CityId,CountyId,CnAddress,EnAddress,ScenicLevel,[Year],OpenTime,Description,JieSuanType");
            fields.Append(",Traffic,Facilities,Notes,IssueTime,OperatorId,ClickNum,ChanPinSource,InterfaceID");
            fields.Append(",(select Realname from  tbl_Webmaster where Id=OperatorId) as OperatorName");
            fields.Append(",(select [Name] from  tbl_SysProvince as sp where sp.Id = tbl_ScenicArea.ProvinceId) as ProvinceName");
            fields.Append(",(select [Name] from  tbl_SysCity as sc where sc.Id = tbl_ScenicArea.CityId) as CityName");
            fields.Append(",(select LandMarkId from tbl_ScenicRelationLandMark where ScenicId=tbl_ScenicArea.ScenicId for xml raw,root('Root')) as ScenicRelationLandMark");
            fields.Append(
                " ,(select * from tbl_ScenicAreaImg as tsai where tsai.ScenicId = tbl_ScenicArea.ScenicId for xml raw,root('Root')) as ScenicAreaImg ");
            fields.Append(" FROM ");
            fields.Append(" tbl_ScenicArea where ScenicId=@ScenicId ");




            DbCommand cmd = this._db.GetSqlStringCommand(fields.ToString());
            this._db.AddInParameter(cmd, "ScenicId", DbType.String, Id);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model.ScenicId = dr.GetString(dr.GetOrdinal("ScenicId"));
                    model.IsRecommend = dr.GetString(dr.GetOrdinal("IsRecommend")) == "1";
                    model.ScenicName = !dr.IsDBNull(dr.GetOrdinal("ScenicName")) ? dr.GetString(dr.GetOrdinal("ScenicName")) : null;
                    model.EnName = !dr.IsDBNull(dr.GetOrdinal("EnName")) ? dr.GetString(dr.GetOrdinal("EnName")) : null;
                    model.X = !dr.IsDBNull(dr.GetOrdinal("X")) ? dr.GetString(dr.GetOrdinal("X")) : null;
                    model.Y = !dr.IsDBNull(dr.GetOrdinal("Y")) ? dr.GetString(dr.GetOrdinal("Y")) : null;
                    model.ServiceTel = !dr.IsDBNull(dr.GetOrdinal("ServiceTel")) ? dr.GetString(dr.GetOrdinal("ServiceTel")) : null;
                    model.Contact = !dr.IsDBNull(dr.GetOrdinal("Contact")) ? dr.GetString(dr.GetOrdinal("Contact")) : null;
                    model.ContactTel = !dr.IsDBNull(dr.GetOrdinal("ContactTel")) ? dr.GetString(dr.GetOrdinal("ContactTel")) : null;
                    model.ContactMobile = !dr.IsDBNull(dr.GetOrdinal("ContactMobile")) ? dr.GetString(dr.GetOrdinal("ContactMobile")) : null;
                    model.ContactFax = !dr.IsDBNull(dr.GetOrdinal("ContactFax")) ? dr.GetString(dr.GetOrdinal("ContactFax")) : null;

                    model.ProvinceId = dr.GetInt32(dr.GetOrdinal("ProvinceId"));
                    model.CityId = dr.GetInt32(dr.GetOrdinal("CityId"));
                    model.CountyId = dr.GetInt32(dr.GetOrdinal("CountyId"));

                    model.NetAddress = !dr.IsDBNull(dr.GetOrdinal("NetAddress")) ? dr.GetString(dr.GetOrdinal("NetAddress")) : null;
                    model.CnAddress = !dr.IsDBNull(dr.GetOrdinal("CnAddress")) ? dr.GetString(dr.GetOrdinal("CnAddress")) : null;
                    model.ScenicLevel = (Model.Enum.ScenicStructure.ScenicLevel?)dr.GetByte(dr.GetOrdinal("ScenicLevel"));
                    model.Year = dr.GetInt32(dr.GetOrdinal("Year"));
                    model.OpenTime = !dr.IsDBNull(dr.GetOrdinal("OpenTime")) ? dr.GetString(dr.GetOrdinal("OpenTime")) : null;
                    model.Description = !dr.IsDBNull(dr.GetOrdinal("Description")) ? dr.GetString(dr.GetOrdinal("Description")) : null;


                    model.Traffic = !dr.IsDBNull(dr.GetOrdinal("Traffic")) ? dr.GetString(dr.GetOrdinal("Traffic")) : null;
                    model.Facilities = !dr.IsDBNull(dr.GetOrdinal("Facilities")) ? dr.GetString(dr.GetOrdinal("Facilities")) : null;
                    model.Notes = !dr.IsDBNull(dr.GetOrdinal("Notes")) ? dr.GetString(dr.GetOrdinal("Notes")) : null;
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.OperatorId = dr.GetString(dr.GetOrdinal("OperatorId"));
                    model.OperatorName = !dr.IsDBNull(dr.GetOrdinal("OperatorName")) ? dr.GetString(dr.GetOrdinal("OperatorName")) : string.Empty;
                    model.ClickNum = dr.GetInt32(dr.GetOrdinal("ClickNum"));

                    model.MarkList = !dr.IsDBNull(dr.GetOrdinal("ScenicRelationLandMark")) ? (List<Model.ScenicStructure.MScenicRelationLandMark>)GetMarkListByXml(dr.GetString(dr.GetOrdinal("ScenicRelationLandMark"))) : null;
                    model.ImgList = !dr.IsDBNull(dr.GetOrdinal("ScenicAreaImg")) ? (List<Model.ScenicStructure.MScenicAreaImg>)this.GetImgListByXml(dr.GetString(dr.GetOrdinal("ScenicAreaImg"))) : null;
                    model.ChanPinSource = dr.IsDBNull(dr.GetOrdinal("ChanPinSource")) ? ChanPinSources.本站.ToInt() : dr.GetInt32(dr.GetOrdinal("ChanPinSource")); ;
                    model.InterfaceID = dr.IsDBNull(dr.GetOrdinal("InterfaceID")) ? string.Empty : dr.GetString(dr.GetOrdinal("InterfaceID"));

                    model.ProvinceName = !dr.IsDBNull(dr.GetOrdinal("ProvinceName")) ? dr.GetString(dr.GetOrdinal("ProvinceName")) : string.Empty;
                    model.CityName = !dr.IsDBNull(dr.GetOrdinal("CityName")) ? dr.GetString(dr.GetOrdinal("CityName")) : string.Empty;
                    model.JieSuanType = dr.GetString(dr.GetOrdinal("JieSuanType")) == "1";

                }
            }

            return model;

        }


        public MScenicArea GetScenicAreaByName(string ScenicName)
        {
            string strSql = string.Format(" select * FROM tbl_ScenicArea WHERE ScenicName='{0}'", ScenicName);
            DbCommand cmd = _db.GetSqlStringCommand(strSql);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                if (dr.Read())
                {
                    MScenicArea model = new MScenicArea();
                    model.ScenicId = dr.GetString(dr.GetOrdinal("ScenicId"));
                    model.IsRecommend = dr.GetString(dr.GetOrdinal("IsRecommend")) == "1";
                    model.ScenicName = !dr.IsDBNull(dr.GetOrdinal("ScenicName")) ? dr.GetString(dr.GetOrdinal("ScenicName")) : null;
                    model.EnName = !dr.IsDBNull(dr.GetOrdinal("EnName")) ? dr.GetString(dr.GetOrdinal("EnName")) : null;
                    model.X = !dr.IsDBNull(dr.GetOrdinal("X")) ? dr.GetString(dr.GetOrdinal("X")) : null;
                    model.Y = !dr.IsDBNull(dr.GetOrdinal("Y")) ? dr.GetString(dr.GetOrdinal("Y")) : null;
                    model.ServiceTel = !dr.IsDBNull(dr.GetOrdinal("ServiceTel")) ? dr.GetString(dr.GetOrdinal("ServiceTel")) : null;
                    model.Contact = !dr.IsDBNull(dr.GetOrdinal("Contact")) ? dr.GetString(dr.GetOrdinal("Contact")) : null;
                    model.ContactTel = !dr.IsDBNull(dr.GetOrdinal("ContactTel")) ? dr.GetString(dr.GetOrdinal("ContactTel")) : null;
                    model.ContactMobile = !dr.IsDBNull(dr.GetOrdinal("ContactMobile")) ? dr.GetString(dr.GetOrdinal("ContactMobile")) : null;
                    model.ContactFax = !dr.IsDBNull(dr.GetOrdinal("ContactFax")) ? dr.GetString(dr.GetOrdinal("ContactFax")) : null;
                    model.NetAddress = !dr.IsDBNull(dr.GetOrdinal("NetAddress")) ? dr.GetString(dr.GetOrdinal("NetAddress")) : null;

                    model.ProvinceId = dr.GetInt32(dr.GetOrdinal("ProvinceId"));
                    model.CityId = dr.GetInt32(dr.GetOrdinal("CityId"));
                    model.CountyId = dr.GetInt32(dr.GetOrdinal("CountyId"));


                    model.CnAddress = !dr.IsDBNull(dr.GetOrdinal("CnAddress")) ? dr.GetString(dr.GetOrdinal("CnAddress")) : null;
                    model.ScenicLevel = (Model.Enum.ScenicStructure.ScenicLevel?)dr.GetByte(dr.GetOrdinal("ScenicLevel"));
                    model.Year = dr.GetInt32(dr.GetOrdinal("Year"));
                    model.OpenTime = !dr.IsDBNull(dr.GetOrdinal("OpenTime")) ? dr.GetString(dr.GetOrdinal("OpenTime")) : null;
                    model.Description = !dr.IsDBNull(dr.GetOrdinal("Description")) ? dr.GetString(dr.GetOrdinal("Description")) : null;


                    model.Traffic = !dr.IsDBNull(dr.GetOrdinal("Traffic")) ? dr.GetString(dr.GetOrdinal("Traffic")) : null;
                    model.Facilities = !dr.IsDBNull(dr.GetOrdinal("Facilities")) ? dr.GetString(dr.GetOrdinal("Facilities")) : null;
                    model.Notes = !dr.IsDBNull(dr.GetOrdinal("Notes")) ? dr.GetString(dr.GetOrdinal("Notes")) : null;
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.OperatorId = dr.GetString(dr.GetOrdinal("OperatorId"));
                    //model.OperatorName = !dr.IsDBNull(dr.GetOrdinal("OperatorName")) ? dr.GetString(dr.GetOrdinal("OperatorName")) : string.Empty;
                    model.ClickNum = dr.GetInt32(dr.GetOrdinal("ClickNum"));

                    //model.MarkList = !dr.IsDBNull(dr.GetOrdinal("ScenicRelationLandMark")) ? (List<Model.ScenicStructure.MScenicRelationLandMark>)GetMarkListByXml(dr.GetString(dr.GetOrdinal("ScenicRelationLandMark"))) : null;
                    // model.ImgList = !dr.IsDBNull(dr.GetOrdinal("ScenicAreaImg")) ? (List<Model.ScenicStructure.MScenicAreaImg>)this.GetImgListByXml(dr.GetString(dr.GetOrdinal("ScenicAreaImg"))) : null;
                    model.ChanPinSource = dr.IsDBNull(dr.GetOrdinal("ChanPinSource")) ? ChanPinSources.本站.ToInt() : dr.GetInt32(dr.GetOrdinal("ChanPinSource")); ;
                    model.InterfaceID = dr.IsDBNull(dr.GetOrdinal("InterfaceID")) ? string.Empty : dr.GetString(dr.GetOrdinal("InterfaceID"));

                    //model.ProvinceName = !dr.IsDBNull(dr.GetOrdinal("ProvinceName")) ? dr.GetString(dr.GetOrdinal("ProvinceName")) : string.Empty;
                    //model.CityName = !dr.IsDBNull(dr.GetOrdinal("CityName")) ? dr.GetString(dr.GetOrdinal("CityName")) : string.Empty;
                    model.JieSuanType = dr.GetString(dr.GetOrdinal("JieSuanType")) == "1";
                    return model;
                }
                else
                {
                    return null;
                }
            }
        }

        public IList<Model.ScenicStructure.MScenicArea> GetScenicAreaListNoInterface(int top, MScenicAreaSearchModel search)
        {
            return GetScenicAreaList(top, search, false, false, false);
        }
        /// <summary>
        /// 获取景区信息
        /// </summary>
        /// <param name="top">top条数，小于等于0取所有</param>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public IList<Model.ScenicStructure.MScenicArea> GetScenicAreaList(int top, MScenicAreaSearchModel search, bool isGetInterfaceData, bool mustHasImg, bool mustHasTicket)
        {
            var strSql = new StringBuilder(" select ");
            strSql.AppendFormat(" {0} ", top > 0 ? string.Format(" top {0} ", top) : string.Empty);
            strSql.Append(
                " sa.ScenicId,IsRecommend,sa.ScenicName,sa.NetAddress,sa.EnName,X,Y,ServiceTel,Contact,ContactTel,ContactMobile,ContactFax ");
            strSql.Append(",ProvinceId,CityId,CountyId,CnAddress,EnAddress,ScenicLevel,[Year],OpenTime,sa.Description");
            strSql.Append(",Traffic,Facilities,Notes,sa.IssueTime,sa.OperatorId,ClickNum,ChanPinSource,InterfaceID");
            strSql.Append(",(select top 1 cast(DistributionPrice as varchar)+','+cast(WebsitePrices as varchar)+','+cast(RetailPrice as varchar) from tbl_ScenicTickets where ScenicId = sa.ScenicId and (EndTime is not null and EndTime>=getdate()) and Status=1 order by DistributionPrice) as PriceInfo");
            strSql.Append(",(select Realname from tbl_Webmaster where tbl_Webmaster.Id = sa.OperatorId) as OperatorName");
            strSql.Append(",(select top 1 address from tbl_ScenicAreaImg as t where t.ScenicId = sa.ScenicId and t.Address !='' and t.address is not null) as ScenicAreaImg ");
            strSql.Append(" from tbl_ScenicArea as sa");
            strSql.Append(" where IsDelete='0'");
            if (mustHasImg)
            {
                strSql.Append(" and sa.scenicId in (select scenicId from tbl_ScenicAreaImg where Address !='' and address is not null)");
            }
            if (mustHasTicket)
            {
                strSql.Append(" and (select count(1) from tbl_ScenicTickets where scenicId=sa.scenicId and status=1 and endtime>=getdate())>0");
            }
            if (search != null)
            {
                if (search.ProductSort > 0)
                {
                    strSql.Append(" and sa.ProductSort>0 ");
                }
                if (!string.IsNullOrEmpty(search.ScenicName))
                {
                    strSql.AppendFormat(" AND sa.ScenicName like '%{0}%' ", Utils.ToSqlLike(search.ScenicName));
                }
                if (search.ProvinceId > 0)
                {
                    strSql.AppendFormat(" AND ProvinceId = {0} ", search.ProvinceId);
                }
                if (search.CityId > 0)
                {
                    strSql.AppendFormat(" AND CityId = {0} ", search.CityId);
                }
                if (search.IsIndex.HasValue)
                {
                    strSql.AppendFormat(" AND IsIndex={0}", (int)search.IsIndex.Value);
                }
            }

            if (!isGetInterfaceData)
            {
                strSql.Append(" AND sa.InterfaceID is null");
            }

            strSql.Append(" order by ProductSort Asc,Id Desc ");

            DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());

            var list = new List<Model.ScenicStructure.MScenicArea>();

            using (IDataReader dr = DbHelper.ExecuteReader(dc, _db))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.ScenicStructure.MScenicArea model = new EyouSoft.Model.ScenicStructure.MScenicArea();
                    model.ScenicId = dr.GetString(dr.GetOrdinal("ScenicId"));
                    model.IsRecommend = dr.GetString(dr.GetOrdinal("IsRecommend")) == "1";
                    model.ScenicName = !dr.IsDBNull(dr.GetOrdinal("ScenicName")) ? dr.GetString(dr.GetOrdinal("ScenicName")) : string.Empty;
                    model.EnName = !dr.IsDBNull(dr.GetOrdinal("EnName")) ? dr.GetString(dr.GetOrdinal("EnName")) : string.Empty;
                    model.X = !dr.IsDBNull(dr.GetOrdinal("X")) ? dr.GetString(dr.GetOrdinal("X")) : string.Empty;
                    model.Y = !dr.IsDBNull(dr.GetOrdinal("Y")) ? dr.GetString(dr.GetOrdinal("Y")) : string.Empty;
                    model.ServiceTel = !dr.IsDBNull(dr.GetOrdinal("ServiceTel")) ? dr.GetString(dr.GetOrdinal("ServiceTel")) : string.Empty;
                    model.Contact = !dr.IsDBNull(dr.GetOrdinal("Contact")) ? dr.GetString(dr.GetOrdinal("Contact")) : string.Empty;
                    model.ContactTel = !dr.IsDBNull(dr.GetOrdinal("ContactTel")) ? dr.GetString(dr.GetOrdinal("ContactTel")) : string.Empty;
                    model.ContactMobile = !dr.IsDBNull(dr.GetOrdinal("ContactMobile")) ? dr.GetString(dr.GetOrdinal("ContactMobile")) : string.Empty;
                    model.ContactFax = !dr.IsDBNull(dr.GetOrdinal("ContactFax")) ? dr.GetString(dr.GetOrdinal("ContactFax")) : string.Empty;
                    model.ProvinceId = dr.GetInt32(dr.GetOrdinal("ProvinceId"));
                    model.CityId = dr.GetInt32(dr.GetOrdinal("CityId"));
                    model.CountyId = dr.GetInt32(dr.GetOrdinal("CountyId"));
                    model.CnAddress = !dr.IsDBNull(dr.GetOrdinal("CnAddress")) ? dr.GetString(dr.GetOrdinal("CnAddress")) : string.Empty;
                    model.ScenicLevel = (Model.Enum.ScenicStructure.ScenicLevel?)dr.GetByte(dr.GetOrdinal("ScenicLevel"));
                    model.Year = dr.GetInt32(dr.GetOrdinal("Year"));
                    model.OpenTime = !dr.IsDBNull(dr.GetOrdinal("OpenTime")) ? dr.GetString(dr.GetOrdinal("OpenTime")) : string.Empty;
                    model.Description = !dr.IsDBNull(dr.GetOrdinal("Description")) ? dr.GetString(dr.GetOrdinal("Description")) : string.Empty;

                    model.Traffic = !dr.IsDBNull(dr.GetOrdinal("Traffic")) ? dr.GetString(dr.GetOrdinal("Traffic")) : string.Empty;
                    model.Facilities = !dr.IsDBNull(dr.GetOrdinal("Facilities")) ? dr.GetString(dr.GetOrdinal("Facilities")) : string.Empty;
                    model.Notes = !dr.IsDBNull(dr.GetOrdinal("Notes")) ? dr.GetString(dr.GetOrdinal("Notes")) : string.Empty;
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.OperatorId = dr.GetString(dr.GetOrdinal("OperatorId"));
                    model.OperatorName = !dr.IsDBNull(dr.GetOrdinal("OperatorName")) ? dr.GetString(dr.GetOrdinal("OperatorName")) : string.Empty;
                    model.ClickNum = dr.GetInt32(dr.GetOrdinal("ClickNum"));
                    model.ChanPinSource = dr.IsDBNull(dr.GetOrdinal("ChanPinSource")) ? ChanPinSources.本站.ToInt() : dr.GetInt32(dr.GetOrdinal("ChanPinSource")); ;
                    model.InterfaceID = dr.IsDBNull(dr.GetOrdinal("InterfaceID")) ? string.Empty : dr.GetString(dr.GetOrdinal("InterfaceID"));
                    model.NetAddress = !dr.IsDBNull(dr.GetOrdinal("NetAddress")) ? dr.GetString(dr.GetOrdinal("NetAddress")) : null;

                    if (dr["PriceInfo"] != DBNull.Value)
                    {
                        string[] s = dr["PriceInfo"].ToString().Split(',');
                        model.SettlementPrice = decimal.Parse(s[0]);
                        model.WebPrice = decimal.Parse(s[1]);
                        model.RetailPrice = decimal.Parse(s[2]);
                    }

                    model.ImgList = !dr.IsDBNull(dr.GetOrdinal("ScenicAreaImg")) ? new List<Model.ScenicStructure.MScenicAreaImg> { new MScenicAreaImg { Address = (dr.GetString(dr.GetOrdinal("ScenicAreaImg"))) } } : null;
                    list.Add(model);
                }
            }

            return list;

        }

        /// <summary>
        /// 分页获取集合
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.ScenicStructure.MScenicArea> GetScenicAreaList(int pageSize, int pageIndex, ref int RecordCount, MScenicAreaSearchModel search)
        {
            IList<EyouSoft.Model.ScenicStructure.MScenicArea> list = new List<EyouSoft.Model.ScenicStructure.MScenicArea>();

            string tableName = "tbl_ScenicArea";

            StringBuilder fields = new StringBuilder();
            fields.Append("ScenicId,IsRecommend,ScenicName,NetAddress,EnName,X,Y,IsIndex,ServiceTel,Contact,ContactTel,ContactMobile,ContactFax");
            fields.Append(",ProvinceId,CityId,CountyId,CnAddress,EnAddress,ScenicLevel,[Year],OpenTime,Description");
            fields.Append(",Traffic,Facilities,Notes,IssueTime,OperatorId,ClickNum,ChanPinSource,InterfaceID");
            fields.Append(",(select Realname from  tbl_Webmaster where Id=OperatorId) as OperatorName");
            fields.Append(",(select LandMarkId from tbl_ScenicRelationLandMark where ScenicId=tbl_ScenicArea.ScenicId for xml raw,root('Root')) as ScenicRelationLandMark");
            fields.AppendFormat(
                " ,(select * from tbl_ScenicAreaImg as tsai where tsai.ScenicId = tbl_ScenicArea.ScenicId and tsai.ImgType = {0} for xml raw,root('Root')) as ScenicAreaImg ",
                (int)Model.Enum.ScenicStructure.ScenicImgType.景区形象);

            string orderByString = " Id Desc ";

            StringBuilder query = new StringBuilder();
            query.Append(" IsDelete='0' ");

            if (search != null)
            {
                if (!string.IsNullOrEmpty(search.ScenicName))
                {
                    query.AppendFormat(" AND ScenicName like '%{0}%' ", Utils.ToSqlLike(search.ScenicName));
                }
                if (search.ProvinceId > 0)
                {
                    query.AppendFormat(" AND ProvinceId = {0} ", search.ProvinceId);
                }
                if (search.CityId > 0)
                {
                    query.AppendFormat(" AND CityId = {0} ", search.CityId);
                }
            }

            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref RecordCount, tableName, fields.ToString(), query.ToString(), orderByString, null))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.ScenicStructure.MScenicArea model = new EyouSoft.Model.ScenicStructure.MScenicArea();
                    model.ScenicId = dr.GetString(dr.GetOrdinal("ScenicId"));
                    model.IsRecommend = dr.GetString(dr.GetOrdinal("IsRecommend")) == "1";
                    model.ScenicName = !dr.IsDBNull(dr.GetOrdinal("ScenicName")) ? dr.GetString(dr.GetOrdinal("ScenicName")) : string.Empty;
                    model.EnName = !dr.IsDBNull(dr.GetOrdinal("EnName")) ? dr.GetString(dr.GetOrdinal("EnName")) : string.Empty;
                    model.X = !dr.IsDBNull(dr.GetOrdinal("X")) ? dr.GetString(dr.GetOrdinal("X")) : string.Empty;
                    model.Y = !dr.IsDBNull(dr.GetOrdinal("Y")) ? dr.GetString(dr.GetOrdinal("Y")) : string.Empty;
                    model.ServiceTel = !dr.IsDBNull(dr.GetOrdinal("ServiceTel")) ? dr.GetString(dr.GetOrdinal("ServiceTel")) : string.Empty;
                    model.Contact = !dr.IsDBNull(dr.GetOrdinal("Contact")) ? dr.GetString(dr.GetOrdinal("Contact")) : string.Empty;
                    model.ContactTel = !dr.IsDBNull(dr.GetOrdinal("ContactTel")) ? dr.GetString(dr.GetOrdinal("ContactTel")) : string.Empty;
                    model.ContactMobile = !dr.IsDBNull(dr.GetOrdinal("ContactMobile")) ? dr.GetString(dr.GetOrdinal("ContactMobile")) : string.Empty;
                    model.ContactFax = !dr.IsDBNull(dr.GetOrdinal("ContactFax")) ? dr.GetString(dr.GetOrdinal("ContactFax")) : string.Empty;
                    model.ProvinceId = dr.GetInt32(dr.GetOrdinal("ProvinceId"));
                    model.CityId = dr.GetInt32(dr.GetOrdinal("CityId"));
                    model.CountyId = dr.GetInt32(dr.GetOrdinal("CountyId"));
                    model.CnAddress = !dr.IsDBNull(dr.GetOrdinal("CnAddress")) ? dr.GetString(dr.GetOrdinal("CnAddress")) : string.Empty;
                    model.ScenicLevel = (Model.Enum.ScenicStructure.ScenicLevel?)dr.GetByte(dr.GetOrdinal("ScenicLevel"));
                    model.Year = dr.GetInt32(dr.GetOrdinal("Year"));
                    model.OpenTime = !dr.IsDBNull(dr.GetOrdinal("OpenTime")) ? dr.GetString(dr.GetOrdinal("OpenTime")) : string.Empty;
                    model.Description = !dr.IsDBNull(dr.GetOrdinal("Description")) ? dr.GetString(dr.GetOrdinal("Description")) : string.Empty;

                    model.Traffic = !dr.IsDBNull(dr.GetOrdinal("Traffic")) ? dr.GetString(dr.GetOrdinal("Traffic")) : string.Empty;
                    model.Facilities = !dr.IsDBNull(dr.GetOrdinal("Facilities")) ? dr.GetString(dr.GetOrdinal("Facilities")) : string.Empty;
                    model.Notes = !dr.IsDBNull(dr.GetOrdinal("Notes")) ? dr.GetString(dr.GetOrdinal("Notes")) : string.Empty;
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.OperatorId = dr.GetString(dr.GetOrdinal("OperatorId"));
                    model.OperatorName = !dr.IsDBNull(dr.GetOrdinal("OperatorName")) ? dr.GetString(dr.GetOrdinal("OperatorName")) : string.Empty;
                    model.ClickNum = dr.GetInt32(dr.GetOrdinal("ClickNum"));
                    model.ChanPinSource = dr.IsDBNull(dr.GetOrdinal("ChanPinSource")) ? ChanPinSources.本站.ToInt() : dr.GetInt32(dr.GetOrdinal("ChanPinSource"));
                    model.InterfaceID = dr.IsDBNull(dr.GetOrdinal("InterfaceID")) ? string.Empty : dr.GetString(dr.GetOrdinal("InterfaceID"));
                    model.NetAddress = !dr.IsDBNull(dr.GetOrdinal("NetAddress")) ? dr.GetString(dr.GetOrdinal("NetAddress")) : null;

                    model.MarkList = !dr.IsDBNull(dr.GetOrdinal("ScenicRelationLandMark")) ? (List<Model.ScenicStructure.MScenicRelationLandMark>)GetMarkListByXml(dr.GetString(dr.GetOrdinal("ScenicRelationLandMark"))) : null;
                    model.ImgList = !dr.IsDBNull(dr.GetOrdinal("ScenicAreaImg")) ? (List<Model.ScenicStructure.MScenicAreaImg>)GetImgListByXml(dr.GetString(dr.GetOrdinal("ScenicAreaImg"))) : null;
                    model.IsIndex = (XianLuZT)dr.GetByte(dr.GetOrdinal("IsIndex"));
                    list.Add(model);
                }
            }

            return list;
        }

        #endregion


        #region IScenicArea 景区图片

        /// <summary>
        /// 添加景区图片
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddScenicAreaImg(EyouSoft.Model.ScenicStructure.MScenicAreaImg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tbl_ScenicAreaImg(");
            strSql.Append("ImgId,ScenicId,ImgType,Address,ThumbAddress,Description,OperatorId");
            strSql.Append(") values (");
            strSql.Append("@ImgId,@ScenicId,@ImgType,@Address,@ThumbAddress,@Description,@OperatorId");
            strSql.Append(") ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ImgId", DbType.AnsiStringFixedLength, model.ImgId);
            this._db.AddInParameter(cmd, "ScenicId", DbType.AnsiStringFixedLength, model.ScenicId);
            this._db.AddInParameter(cmd, "ImgType", DbType.Byte, (int)model.ImgType);
            this._db.AddInParameter(cmd, "Address", DbType.String, model.Address);
            this._db.AddInParameter(cmd, "ThumbAddress", DbType.String, model.ThumbAddress);
            this._db.AddInParameter(cmd, "Description", DbType.String, model.Description);
            this._db.AddInParameter(cmd, "OperatorId", DbType.AnsiStringFixedLength, model.OperatorId);

            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }


        /// <summary>
        /// 批量添加景区图片
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool AddScenicAreaImg(string ScenicId, IList<EyouSoft.Model.ScenicStructure.MScenicAreaImg> list)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_ScenicAreaImage_Add");
            this._db.AddInParameter(cmd, "ScenicAreaImg", DbType.Xml, CreateXml(ScenicId, list));
            this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);

            DbHelper.RunProcedureWithResult(cmd, this._db);
            return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result")) > 0 ? true : false;
        }

        /// <summary>
        /// 修改景区图片
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateScenicAreaImg(EyouSoft.Model.ScenicStructure.MScenicAreaImg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tbl_ScenicAreaImg set ");
            strSql.Append(" ScenicId = @ScenicId , ");
            strSql.Append(" ImgType = @ImgType , ");
            strSql.Append(" Address = @Address , ");
            strSql.Append(" ThumbAddress = @ThumbAddress , ");
            strSql.Append(" Description = @Description,  ");
            strSql.Append(" OperatorId = @OperatorId  ");
            strSql.Append(" where ImgId=@ImgId  ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ImgId", DbType.AnsiStringFixedLength, model.ImgId);
            this._db.AddInParameter(cmd, "ScenicId", DbType.AnsiStringFixedLength, model.ScenicId);
            this._db.AddInParameter(cmd, "ImgType", DbType.Byte, (int)model.ImgType);
            this._db.AddInParameter(cmd, "Address", DbType.String, model.Address);
            this._db.AddInParameter(cmd, "ThumbAddress", DbType.String, model.ThumbAddress);
            this._db.AddInParameter(cmd, "Description", DbType.String, model.Description);
            this._db.AddInParameter(cmd, "OperatorId", DbType.AnsiStringFixedLength, model.OperatorId);

            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;

        }

        /// <summary>
        /// 根据图片编号获取实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EyouSoft.Model.ScenicStructure.MScenicAreaImg GetScenicAreaImgById(string Id)
        {
            EyouSoft.Model.ScenicStructure.MScenicAreaImg model = new EyouSoft.Model.ScenicStructure.MScenicAreaImg();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM tbl_ScenicAreaImg where ImgId=@ImgId");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ImgId", DbType.AnsiStringFixedLength, Id);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model.ImgId = dr.GetString(dr.GetOrdinal("ImgId"));
                    model.ScenicId = dr.GetString(dr.GetOrdinal("ScenicId"));
                    model.ImgType = (ScenicImgType)dr.GetByte(dr.GetOrdinal("ImgType"));
                    model.Address = !dr.IsDBNull(dr.GetOrdinal("Address")) ? dr.GetString(dr.GetOrdinal("Address")) : string.Empty;
                    model.ThumbAddress = !dr.IsDBNull(dr.GetOrdinal("ThumbAddress")) ? dr.GetString(dr.GetOrdinal("ThumbAddress")) : string.Empty;
                    model.Description = !dr.IsDBNull(dr.GetOrdinal("Description")) ? dr.GetString(dr.GetOrdinal("Description")) : string.Empty;
                    model.OperatorId = dr.GetString(dr.GetOrdinal("OperatorId"));
                }
            }


            return model;

        }

        /// <summary>
        /// 根据图片编号删除图片
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteScenicAreaImg(string Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tbl_ScenicAreaImg ");
            strSql.Append(" where ImgId=@ImgId ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ImgId", DbType.AnsiStringFixedLength, Id);

            return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
        }

        /// <summary>
        /// 根据景区集合获取集合
        /// </summary>
        /// <returns></returns>
        public IList<EyouSoft.Model.ScenicStructure.MScenicAreaImg> GetScenicAreaImgList(string ScenicId)
        {
            IList<EyouSoft.Model.ScenicStructure.MScenicAreaImg> list = new List<EyouSoft.Model.ScenicStructure.MScenicAreaImg>();

            StringBuilder strSql = new StringBuilder();
            if (string.IsNullOrEmpty(ScenicId)) return null;
            strSql.Append("select * ");
            strSql.Append(" FROM tbl_ScenicAreaImg Where ScenicId=@ScenicId ");
            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "ScenicId", DbType.String, ScenicId);
            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    EyouSoft.Model.ScenicStructure.MScenicAreaImg model = new EyouSoft.Model.ScenicStructure.MScenicAreaImg();
                    model.ImgId = !dr.IsDBNull(dr.GetOrdinal("ImgId")) ? dr.GetString(dr.GetOrdinal("ImgId")) : string.Empty;
                    model.ScenicId = !dr.IsDBNull(dr.GetOrdinal("ScenicId")) ? dr.GetString(dr.GetOrdinal("ScenicId")) : string.Empty;
                    model.ImgType = (Model.Enum.ScenicStructure.ScenicImgType)dr.GetByte(dr.GetOrdinal("ImgType"));
                    model.Address = !dr.IsDBNull(dr.GetOrdinal("Address")) ? dr.GetString(dr.GetOrdinal("Address")) : string.Empty;
                    model.ThumbAddress = !dr.IsDBNull(dr.GetOrdinal("ThumbAddress")) ? dr.GetString(dr.GetOrdinal("ThumbAddress")) : string.Empty;
                    model.Address = !dr.IsDBNull(dr.GetOrdinal("Address")) ? dr.GetString(dr.GetOrdinal("Address")) : string.Empty;
                    model.Description = !dr.IsDBNull(dr.GetOrdinal("Description")) ? dr.GetString(dr.GetOrdinal("Description")) : string.Empty;
                    model.OperatorId = dr.GetString(dr.GetOrdinal("OperatorId"));
                    list.Add(model);
                }
            }

            return list;
        }

        #endregion


        #region IScenicArea 景区订单
        /// <summary>
        /// 添加景区订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddScenicAreaOrder(EyouSoft.Model.ScenicStructure.MScenicAreaOrder model)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_ScenicAreaOrder_Add");
            this._db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, model.OrderId);
            this._db.AddInParameter(cmd, "ScenicId", DbType.AnsiStringFixedLength, model.ScenicId);
            this._db.AddInParameter(cmd, "TicketsId", DbType.AnsiStringFixedLength, model.TicketsId);
            this._db.AddInParameter(cmd, "Price", DbType.Currency, model.Price);
            this._db.AddInParameter(cmd, "Num", DbType.Int32, model.Num);
            this._db.AddInParameter(cmd, "Status", DbType.Byte, (int)model.Status);
            this._db.AddInParameter(cmd, "Source", DbType.Byte, model.Source);
            this._db.AddInParameter(cmd, "FuKuanStatus", DbType.Byte, (int)model.FuKuanStatus);
            this._db.AddInParameter(cmd, "OperatorId", DbType.AnsiStringFixedLength, model.OperatorId);
            this._db.AddInParameter(cmd, "ContactName", DbType.String, model.ContactName);
            this._db.AddInParameter(cmd, "ContactTel", DbType.String, model.ContactTel);
            this._db.AddInParameter(cmd, "Remark", DbType.String, model.Remark);
            this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            this._db.AddOutParameter(cmd, "OrderCode", DbType.String, 255);
            this._db.AddInParameter(cmd, "BuyCompanyName", DbType.String, model.BuyCompanyName);
            DbHelper.RunProcedureWithResult(cmd, this._db);

            model.OrderCode = this._db.GetParameterValue(cmd, "OrderCode").ToString();
            return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result")) > 0 ? true : false;


        }
        /// <summary>
        /// 修改景区订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateScenicAreaOrder(EyouSoft.Model.ScenicStructure.MScenicAreaOrder model)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_ScenicAreaOrder_Update");
            this._db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, model.OrderId);
            this._db.AddInParameter(cmd, "ScenicId", DbType.AnsiStringFixedLength, model.ScenicId);
            this._db.AddInParameter(cmd, "TicketsId", DbType.AnsiStringFixedLength, model.TicketsId);
            this._db.AddInParameter(cmd, "Price", DbType.Currency, model.Price);
            this._db.AddInParameter(cmd, "Num", DbType.Int32, model.Num);
            this._db.AddInParameter(cmd, "Status", DbType.Byte, (int)model.Status);
            this._db.AddInParameter(cmd, "Source", DbType.Byte, model.Source);
            this._db.AddInParameter(cmd, "FuKuanStatus", DbType.Byte, (int)model.FuKuanStatus);
            this._db.AddInParameter(cmd, "ContactName", DbType.String, model.ContactName);
            this._db.AddInParameter(cmd, "ContactTel", DbType.String, model.ContactTel);
            this._db.AddInParameter(cmd, "Remark", DbType.String, model.Remark);
            this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            DbHelper.RunProcedureWithResult(cmd, this._db);

            return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result")) > 0 ? true : false;
        }

        /// <summary>
        /// 修改景区订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateScenicAreaOrderByUser(Model.ScenicStructure.MScenicAreaOrder model)
        {
            var strSql = new StringBuilder();

            strSql.Append(" UPDATE tbl_ScenicAreaOrder set ");
            strSql.Append(" Price = @Price,Num = @Num,ContactName = @ContactName,ContactTel = @ContactTel,Remark = @Remark ");
            strSql.Append(" WHERE OrderId = @OrderId ");

            DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
            this._db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, model.OrderId);
            this._db.AddInParameter(cmd, "Price", DbType.Currency, model.Price);
            this._db.AddInParameter(cmd, "Num", DbType.Int32, model.Num);
            this._db.AddInParameter(cmd, "ContactName", DbType.String, model.ContactName);
            this._db.AddInParameter(cmd, "ContactTel", DbType.String, model.ContactTel);
            this._db.AddInParameter(cmd, "Remark", DbType.String, model.Remark);

            return DbHelper.ExecuteSql(cmd, _db) > 0;
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
        /// 修改景区订单的状态
        /// </summary>
        /// <param name="OrderId"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public bool UpdateScenicAreaOrder(string OrderId, EyouSoft.Model.Enum.XianLuStructure.OrderStatus Status)
        {
            DbCommand cmd = this._db.GetStoredProcCommand("proc_ScenicAreaOrder_Update_Status");
            this._db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, OrderId);
            this._db.AddInParameter(cmd, "Status", DbType.Byte, Status);
            this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
            DbHelper.RunProcedureWithResult(cmd, this._db);

            return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result")) > 0 ? true : false;
        }

        /// <summary>
        /// 设置付款状态，返回1成功，其它失败
        /// </summary>
        /// <param name="orderId">订单编号</param>
        /// <param name="memberId">会员编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int SheZhiFuKuanStatus(string orderId, string memberId, Model.Enum.XianLuStructure.FuKuanStatus status)
        {
            DbCommand cmd = _db.GetSqlStringCommand("UPDATE [tbl_ScenicAreaOrder] SET [FuKuanStatus]=@FuKuanStatus WHERE [OrderId]=@OrderId AND [OperatorId]=@MemberId");

            _db.AddInParameter(cmd, "FuKuanStatus", DbType.Byte, (int)status);
            _db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, orderId);
            _db.AddInParameter(cmd, "MemberId", DbType.AnsiStringFixedLength, memberId);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : -100;
        }

        /// <summary>
        /// 获取景区订单的实体
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public EyouSoft.Model.ScenicStructure.MScenicAreaOrder GetScenicAreaOrderModel(string orderId)
        {
            EyouSoft.Model.ScenicStructure.MScenicAreaOrder model = null;

            string sql = "select * from view_ScenicAreaOrder where OrderId=@OrderId ";

            DbCommand cmd = this._db.GetSqlStringCommand(sql);
            this._db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, orderId);

            using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
            {
                while (dr.Read())
                {
                    model = new EyouSoft.Model.ScenicStructure.MScenicAreaOrder();
                    model.OrderId = dr.GetString(dr.GetOrdinal("OrderId"));
                    model.OrderCode = dr.GetString(dr.GetOrdinal("OrderCode"));
                    model.ScenicId = dr.GetString(dr.GetOrdinal("ScenicId"));
                    model.TicketsId = dr.GetString(dr.GetOrdinal("TicketsId"));
                    model.Price = dr.GetDecimal(dr.GetOrdinal("Price"));
                    model.Num = dr.GetInt32(dr.GetOrdinal("Num"));
                    model.Status = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)dr.GetByte(dr.GetOrdinal("Status"));
                    model.Source = (EyouSoft.Model.Enum.ScenicStructure.ScenicAreaOrderSource)dr.GetByte(dr.GetOrdinal("Source"));
                    model.FuKuanStatus = (EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus)dr.GetByte(dr.GetOrdinal("FuKuanStatus"));
                    model.OperatorId = dr.GetString(dr.GetOrdinal("OperatorId"));
                    model.OperatorName = dr.GetString(dr.GetOrdinal("OperatorName"));
                    model.OperatorMobile = dr.GetString(dr.GetOrdinal("OperatorMobile"));
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.ScenicName = !dr.IsDBNull(dr.GetOrdinal("ScenicName")) ? dr.GetString(dr.GetOrdinal("ScenicName")) : null;
                    model.TypeName = !dr.IsDBNull(dr.GetOrdinal("TypeName")) ? dr.GetString(dr.GetOrdinal("TypeName")) : null;
                    model.ContactName = !dr.IsDBNull(dr.GetOrdinal("ContactName")) ? dr.GetString(dr.GetOrdinal("ContactName")) : string.Empty;
                    model.ContactTel = !dr.IsDBNull(dr.GetOrdinal("ContactTel")) ? dr.GetString(dr.GetOrdinal("ContactTel")) : string.Empty;
                    model.Remark = !dr.IsDBNull(dr.GetOrdinal("Remark")) ? dr.GetString(dr.GetOrdinal("Remark")) : string.Empty;
                    model.BuyCompanyName = !dr.IsDBNull(dr.GetOrdinal("BuyCompanyName")) ? dr.GetString(dr.GetOrdinal("BuyCompanyName")) : "";
                    model.AgencyJinE = dr.GetDecimal(dr.GetOrdinal("AgencyJinE"));
                    model.SellerID = dr.GetString(dr.GetOrdinal("SellerID"));
                    model.ChuFaRiQi = !dr.IsDBNull(dr.GetOrdinal("ChuFaRiQi")) ? dr.GetDateTime(dr.GetOrdinal("ChuFaRiQi")) : DateTime.Now.Date;
                }
            }

            return model;

        }

        /// <summary>
        /// 获取景区订单的集合
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.ScenicStructure.MScenicAreaOrder> GetScenicAreaOrderList(int pageSize, int pageIndex, ref int RecordCount, MScenicAreaOrderSearchModel search)
        {
            IList<EyouSoft.Model.ScenicStructure.MScenicAreaOrder> list = new List<EyouSoft.Model.ScenicStructure.MScenicAreaOrder>();

            string tableName = "view_ScenicAreaOrder";

            StringBuilder fields = new StringBuilder();
            fields.Append("OrderId,ScenicId,TicketsId,Price,Num,Status,Source,OrderCode");
            fields.Append(",FuKuanStatus,OperatorId,OperatorName,IssueTime,ScenicName,TypeName,ContactName,ContactTel,Remark,BuyCompanyName,ChuFaRiQi,AgencyJinE,SellerID,UserType,OperatorMobile ");

            string orderByString = " IssueTime desc ";

            StringBuilder query = new StringBuilder(" 1=1 ");

            if (search != null)
            {
                if (!string.IsNullOrEmpty(search.BuyCompanyName))
                {
                    query.AppendFormat(" and BuyCompanyName like '%{0}%' ", search.BuyCompanyName);
                }
                if
                    (!string.IsNullOrEmpty(search.OrderCode))
                {
                    query.AppendFormat("  and OrderCode like '%{0}%' ", search.OrderCode);
                }

                if (!string.IsNullOrEmpty(search.ScenicName))
                {

                    query.AppendFormat("  and ScenicName like '%{0}%' ", search.ScenicName);
                }

                if (search.BeginTime.HasValue)
                {

                    query.AppendFormat("  and  datediff(day,'{0}',IssueTime)>=0 ", search.BeginTime.Value);
                }

                if (search.EndTime.HasValue)
                {

                    query.AppendFormat("  and  datediff(day,'{0}',IssueTime)<=0 ", search.EndTime.Value);
                }

                if (search.Status.HasValue)
                {
                    query.AppendFormat("  and  Status={0} ", (int)search.Status.Value);
                }
                if (!string.IsNullOrEmpty(search.UserId) && !string.IsNullOrEmpty(search.SellerID))
                {
                    query.AppendFormat("  and ( OperatorId = '{0}' or SellerID='{1}' ) ", Utils.ToSqlLike(search.UserId), Utils.ToSqlLike(search.SellerID));
                }
                else if (!string.IsNullOrEmpty(search.UserId))
                {
                    query.AppendFormat("  and  OperatorId = '{0}' ", Utils.ToSqlLike(search.UserId));
                }
                else if (!string.IsNullOrEmpty(search.SellerID))
                {
                    if (search.SellerID == "0")
                    {
                        query.Append(" AND (SellerID is null or  SellerID = '')");
                    }
                    else
                    {
                        query.AppendFormat(" AND SellerID = '{0}' ", search.SellerID);
                    }
                }

                if (search.Source.HasValue)
                {
                    query.AppendFormat(" and Source={0} ", (int)search.Source.Value);
                }
                if (!string.IsNullOrEmpty(search.JingDianId))
                {
                    query.AppendFormat(" AND ScenicId='{0}' ", search.JingDianId);
                }


                if (search.IsFeiHuiYuan)
                {
                    query.Append(" AND LEN(OperatorId)<>36 ");
                    query.AppendFormat(" AND OrderCode='{0}' ", search.FeiHuiYuanDingDanHao);
                    query.AppendFormat(" AND ContactName='{0}' ", search.FeiHuiYuanXingMing);
                    query.AppendFormat(" AND ContactTel='{0}' ", search.FeiHuiYuanDianHua);
                }
            }

            using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref RecordCount, tableName, fields.ToString(), query.ToString(), orderByString, null))
            {

                while (dr.Read())
                {
                    EyouSoft.Model.ScenicStructure.MScenicAreaOrder model = new EyouSoft.Model.ScenicStructure.MScenicAreaOrder();

                    model.OrderId = dr.GetString(dr.GetOrdinal("OrderId"));
                    model.ScenicId = dr.GetString(dr.GetOrdinal("ScenicId"));
                    model.TicketsId = dr.GetString(dr.GetOrdinal("TicketsId"));
                    model.Price = dr.GetDecimal(dr.GetOrdinal("Price"));
                    model.Num = dr.GetInt32(dr.GetOrdinal("Num"));
                    model.Status = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)dr.GetByte(dr.GetOrdinal("Status"));
                    model.Source = (EyouSoft.Model.Enum.ScenicStructure.ScenicAreaOrderSource)dr.GetByte(dr.GetOrdinal("Source"));
                    model.FuKuanStatus = (EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus)dr.GetByte(dr.GetOrdinal("FuKuanStatus"));
                    model.OperatorId = dr.GetString(dr.GetOrdinal("OperatorId"));
                    model.OperatorName = !dr.IsDBNull(dr.GetOrdinal("OperatorName")) ? dr.GetString(dr.GetOrdinal("OperatorName")) : string.Empty;
                    model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
                    model.ScenicName = !dr.IsDBNull(dr.GetOrdinal("ScenicName")) ? dr.GetString(dr.GetOrdinal("ScenicName")) : null;
                    model.TypeName = !dr.IsDBNull(dr.GetOrdinal("TypeName")) ? dr.GetString(dr.GetOrdinal("TypeName")) : null;
                    model.ContactName = !dr.IsDBNull(dr.GetOrdinal("ContactName")) ? dr.GetString(dr.GetOrdinal("ContactName")) : string.Empty;
                    model.ContactTel = !dr.IsDBNull(dr.GetOrdinal("ContactTel")) ? dr.GetString(dr.GetOrdinal("ContactTel")) : string.Empty;
                    model.Remark = !dr.IsDBNull(dr.GetOrdinal("Remark")) ? dr.GetString(dr.GetOrdinal("Remark")) : string.Empty;
                    model.OrderCode = !dr.IsDBNull(dr.GetOrdinal("OrderCode")) ? dr.GetString(dr.GetOrdinal("OrderCode")) : string.Empty;
                    model.BuyCompanyName = !dr.IsDBNull(dr.GetOrdinal("BuyCompanyName")) ? dr.GetString(dr.GetOrdinal("BuyCompanyName")) : "";
                    model.SellerID = dr.GetString(dr.GetOrdinal("SellerID"));
                    model.AgencyJinE = dr.GetDecimal(dr.GetOrdinal("AgencyJinE"));
                    model.ChuFaRiQi = dr.GetDateTime(dr.GetOrdinal("ChuFaRiQi"));
                    model.OperatorMobile = !dr.IsDBNull(dr.GetOrdinal("OperatorMobile")) ? dr.GetString(dr.GetOrdinal("OperatorMobile")) : "";
                    if (dr["UserType"] != null && dr["UserType"] != DBNull.Value)
                    {
                        model.UserType = (MemberTypes)dr.GetInt32(dr.GetOrdinal("UserType"));
                    }
                    else
                    {
                        model.UserType = MemberTypes.未注册用户;
                    }

                    list.Add(model);
                }
            }

            return list;
        }

        #endregion


        #region  private xml
        /// <summary>
        /// 创建线路标记的Xml
        /// </summary>
        /// <param name="MarkList"></param>
        /// <returns></returns>
        private string CreateXml(IList<Model.ScenicStructure.MScenicRelationLandMark> list)
        {
            if (list == null)
                return null;

            StringBuilder xmlDoc = new StringBuilder();
            xmlDoc.Append("<Root>");
            foreach (Model.ScenicStructure.MScenicRelationLandMark model in list)
            {
                xmlDoc.Append("<ScenicRelationLandMark ");
                xmlDoc.AppendFormat("LandMarkId=\"{0}\" ", model.LandMarkId);
                xmlDoc.Append(" />");
            }

            xmlDoc.Append("</Root>");

            return xmlDoc.ToString();
        }

        /// <summary>
        /// 创建景区图片的Xml
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private string CreateXml(string ScenicId, IList<EyouSoft.Model.ScenicStructure.MScenicAreaImg> list)
        {
            if (list == null) return null;
            StringBuilder xmlDoc = new StringBuilder();
            xmlDoc.Append("<Root>");
            foreach (EyouSoft.Model.ScenicStructure.MScenicAreaImg model in list)
            {
                xmlDoc.Append("<ScenicAreaImg ");
                xmlDoc.AppendFormat("ImgId=\"{0}\" ", model.ImgId);
                xmlDoc.AppendFormat("ScenicId=\"{0}\" ", ScenicId);
                xmlDoc.AppendFormat("ImgType=\"{0}\" ", (int)model.ImgType);
                xmlDoc.AppendFormat("Address=\"{0}\" ", model.Address);
                xmlDoc.AppendFormat("ThumbAddress=\"{0}\" ", model.ThumbAddress);
                xmlDoc.AppendFormat("Description=\"{0}\" ", model.Description);
                xmlDoc.AppendFormat("OperatorId=\"{0}\" ", model.OperatorId);
                xmlDoc.Append(" />");
            }

            xmlDoc.Append("</Root>");

            return xmlDoc.ToString();
        }

        /// <summary>
        /// 获取景区标记的集合
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private IList<Model.ScenicStructure.MScenicRelationLandMark> GetMarkListByXml(string xml)
        {
            if (string.IsNullOrEmpty(xml)) return null;
            IList<Model.ScenicStructure.MScenicRelationLandMark> list = new List<Model.ScenicStructure.MScenicRelationLandMark>();
            System.Xml.Linq.XElement xRoot = System.Xml.Linq.XElement.Parse(xml);
            var xRows = Utils.GetXElements(xRoot, "row");
            foreach (var xRow in xRows)
            {
                Model.ScenicStructure.MScenicRelationLandMark item = new Model.ScenicStructure.MScenicRelationLandMark()
                {
                    LandMarkId = Utils.GetInt(Utils.GetXAttributeValue(xRow, "LandMarkId"))
                };

                list.Add(item);
            }
            return list;

        }

        /// <summary>
        /// 获取景区图片
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private IList<Model.ScenicStructure.MScenicAreaImg> GetImgListByXml(string xml)
        {
            if (string.IsNullOrEmpty(xml)) return null;

            var xRoot = XElement.Parse(xml);

            var xRows = Utils.GetXElements(xRoot, "row");
            if (xRows == null || !xRows.Any()) return null;

            var list = new List<Model.ScenicStructure.MScenicAreaImg>();
            foreach (var t in xRows)
            {
                if (t == null) continue;

                list.Add(
                    new Model.ScenicStructure.MScenicAreaImg
                        {
                            Address = Utils.GetXAttributeValue(t, "Address"),
                            Description = Utils.GetXAttributeValue(t, "Description"),
                            ImgId = Utils.GetXAttributeValue(t, "ImgId"),
                            ImgType =
                                (Model.Enum.ScenicStructure.ScenicImgType)
                                Utils.GetInt(Utils.GetXAttributeValue(t, "ImgType")),
                            OperatorId = Utils.GetXAttributeValue(t, "OperatorId"),
                            ScenicId = Utils.GetXAttributeValue(t, "ScenicId"),
                            ThumbAddress = Utils.GetXAttributeValue(t, "ThumbAddress")
                        });
            }

            return list;
        }




        #endregion

        /// <summary>
        /// 新增点评
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int InsertDianPing(EyouSoft.Model.ScenicStructure.MJingDianDianPingInfo info)
        {
            string sql = "INSERT INTO [tbl_JingDianDianPing]([DianPingId],[JingDianId],[YouLanShiJian],[ShuLiang],[JingQu],[YuDing],[ManYiDu],[DianPingFangShi],[DianPingShiJian],[DianPingNeiRong],[SortId],[IsCheck],[OperatorId],[IssueTime]) VALUES (@DianPingId,@JingDianId,@YouLanShiJian,@ShuLiang,@JingQu,@YuDing,@ManYiDu,@DianPingFangShi,@DianPingShiJian,@DianPingNeiRong,@SortId,@IsCheck,@OperatorId,@IssueTime)";
            DbCommand cmd = _db.GetSqlStringCommand(sql);

            _db.AddInParameter(cmd, "DianPingId", DbType.AnsiStringFixedLength, info.DianPingId);
            _db.AddInParameter(cmd, "JingDianId", DbType.AnsiStringFixedLength, info.JingDianId);
            _db.AddInParameter(cmd, "YouLanShiJian", DbType.DateTime, info.YouLanShiJian);
            _db.AddInParameter(cmd, "ShuLiang", DbType.Int32, info.ShuLiang);
            _db.AddInParameter(cmd, "JingQu", DbType.Byte, info.JingQu);
            _db.AddInParameter(cmd, "YuDing", DbType.Byte, info.YuDing);
            _db.AddInParameter(cmd, "ManYiDu", DbType.Decimal, info.ManYiDu);
            _db.AddInParameter(cmd, "DianPingFangShi", DbType.Byte, info.DianPingFangShi);
            _db.AddInParameter(cmd, "DianPingShiJian", DbType.DateTime, info.DianPingShiJian);
            _db.AddInParameter(cmd, "DianPingNeiRong", DbType.String, info.DianPingNeiRong);
            _db.AddInParameter(cmd, "SortId", DbType.Int32, info.SortId);
            _db.AddInParameter(cmd, "IsCheck", DbType.AnsiStringFixedLength, info.IsCheck ? "1" : "0");
            _db.AddInParameter(cmd, "OperatorId", DbType.AnsiStringFixedLength, info.OperatorId);
            _db.AddInParameter(cmd, "IssueTime", DbType.DateTime, info.IssueTime);

            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }

        /// <summary>
        /// 修改点评
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int UpdateDianPing(EyouSoft.Model.ScenicStructure.MJingDianDianPingInfo info)
        {
            string sql = "UPDATE [tbl_JingDianDianPing] SET [JingDianId]=@JingDianId,[YouLanShiJian]=@YouLanShiJian,[ShuLiang]=@ShuLiang,[JingQu]=@JingQu,[YuDing]=@YuDing,[ManYiDu]=@ManYiDu,[DianPingFangShi]=@DianPingFangShi,[DianPingShiJian]=@DianPingShiJian,[DianPingNeiRong]=@DianPingNeiRong,[SortId]=@SortId WHERE [DianPingId]=@DianPingId";
            DbCommand cmd = _db.GetSqlStringCommand(sql);

            _db.AddInParameter(cmd, "DianPingId", DbType.AnsiStringFixedLength, info.DianPingId);
            _db.AddInParameter(cmd, "JingDianId", DbType.AnsiStringFixedLength, info.JingDianId);
            _db.AddInParameter(cmd, "YouLanShiJian", DbType.DateTime, info.YouLanShiJian);
            _db.AddInParameter(cmd, "ShuLiang", DbType.Int32, info.ShuLiang);
            _db.AddInParameter(cmd, "JingQu", DbType.Byte, info.JingQu);
            _db.AddInParameter(cmd, "YuDing", DbType.Byte, info.YuDing);
            _db.AddInParameter(cmd, "ManYiDu", DbType.Decimal, info.ManYiDu);
            _db.AddInParameter(cmd, "DianPingFangShi", DbType.Byte, info.DianPingFangShi);
            _db.AddInParameter(cmd, "DianPingShiJian", DbType.DateTime, info.DianPingShiJian);
            _db.AddInParameter(cmd, "DianPingNeiRong", DbType.String, info.DianPingNeiRong);
            _db.AddInParameter(cmd, "SortId", DbType.Int32, info.SortId);

            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }

        /// <summary>
        /// 删除点评
        /// </summary>
        /// <param name="dianPingId"></param>
        /// <returns></returns>
        public int DeleteDianPing(string dianPingId)
        {
            string sql = "DELETE FROM [tbl_JingDianDianPing] WHERE [DianPingId]=@DianPingId";
            DbCommand cmd = _db.GetSqlStringCommand(sql);

            _db.AddInParameter(cmd, "DianPingId", DbType.AnsiStringFixedLength, dianPingId);

            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }

        /// <summary>
        /// 获取点评
        /// </summary>
        /// <param name="dianPingId"></param>
        /// <returns></returns>
        public EyouSoft.Model.ScenicStructure.MJingDianDianPingInfo GetDianPingInfo(string dianPingId)
        {
            EyouSoft.Model.ScenicStructure.MJingDianDianPingInfo info = null;
            string sql = "SELECT *,(SELECT A1.ScenicName FROM tbl_ScenicArea AS A1 WHERE A1.ScenicId=A.JingDianId) AS JingDianName,(CASE LEN(OperatorId) WHEN 36 THEN (SELECT Account FROM tbl_Member WHERE MemberID=A.OperatorId) ELSE (SELECT Username FROM tbl_Webmaster WHERE Id=A.OperatorId) END) AS OperatorName FROM [tbl_JingDianDianPing] AS A WHERE A.[DianPingId]=@DianPingId";

            DbCommand cmd = _db.GetSqlStringCommand(sql);

            _db.AddInParameter(cmd, "DianPingId", DbType.AnsiStringFixedLength, dianPingId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    info = new EyouSoft.Model.ScenicStructure.MJingDianDianPingInfo();

                    info.DianPingFangShi = (EyouSoft.Model.Enum.XianLuStructure.DianPingType)rdr.GetByte(rdr.GetOrdinal("DianPingFangShi"));
                    info.DianPingId = rdr["DianPingId"].ToString();
                    info.DianPingNeiRong = rdr["DianPingNeiRong"].ToString();
                    info.DianPingShiJian = rdr.GetDateTime(rdr.GetOrdinal("DianPingShiJian"));
                    info.IsCheck = rdr["IsCheck"].ToString() == "1";
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.JingDianId = rdr["JingDianId"].ToString();
                    info.JingDianName = rdr["JingDianName"].ToString();
                    info.ManYiDu = rdr.GetDecimal(rdr.GetOrdinal("ManYiDu"));
                    info.OperatorId = rdr["OperatorId"].ToString();
                    info.OperatorName = rdr["OperatorName"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YouLanShiJian"))) info.YouLanShiJian = rdr.GetDateTime(rdr.GetOrdinal("YouLanShiJian"));
                    info.SortId = rdr.GetInt32(rdr.GetOrdinal("SortId"));
                    info.ShuLiang = rdr.GetInt32(rdr.GetOrdinal("ShuLiang"));
                    info.JingQu = (EyouSoft.Model.Enum.XianLuStructure.DianPingStatus)rdr.GetByte(rdr.GetOrdinal("JingQu"));
                    info.YuDing = (EyouSoft.Model.Enum.XianLuStructure.DianPingStatus)rdr.GetByte(rdr.GetOrdinal("YuDing"));
                }
            }

            return info;
        }

        /// <summary>
        /// 获取点评集合
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="chaXun"></param>
        /// <returns></returns>
        public IList<EyouSoft.Model.ScenicStructure.MJingDianDianPingInfo> GetDianPings(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.ScenicStructure.MJingDianDianPingChaXunInfo chaXun)
        {
            IList<EyouSoft.Model.ScenicStructure.MJingDianDianPingInfo> items = new List<EyouSoft.Model.ScenicStructure.MJingDianDianPingInfo>();
            string tableName = "tbl_JingDianDianPing";

            StringBuilder fields = new StringBuilder();
            fields.Append(" * ");
            fields.Append(",(SELECT A1.ScenicName FROM tbl_ScenicArea AS A1 WHERE A1.ScenicId=tbl_JingDianDianPing.JingDianId) AS JingDianName");
            fields.Append(",(CASE LEN(OperatorId) WHEN 36 THEN (SELECT Account FROM tbl_Member WHERE MemberID=tbl_JingDianDianPing.OperatorId) ELSE (SELECT Username FROM tbl_Webmaster WHERE Id=tbl_JingDianDianPing.OperatorId) END) AS OperatorName");

            string orderByString = "DianPingShiJian DESC,SortId DESC";

            StringBuilder s = new StringBuilder();
            s.Append(" 1=1 ");

            if (chaXun != null)
            {
                if (chaXun.DPETime.HasValue)
                {
                    s.AppendFormat(" AND DianPingShiJian<'{0}' ", chaXun.DPETime.Value.AddDays(1));
                }
                if (chaXun.DPSTime.HasValue)
                {
                    s.AppendFormat(" AND DianPingShiJian>'{0}' ", chaXun.DPSTime.Value.AddDays(-1));
                }
                if (chaXun.IsShenHe.HasValue)
                {
                    s.AppendFormat(" AND IsCheck='{0}' ", chaXun.IsShenHe.Value ? "1" : "0");
                }
                if (!string.IsNullOrEmpty(chaXun.JingDianId))
                {
                    s.AppendFormat(" AND JingDianId='{0}' ", chaXun.JingDianId);
                }
                if (!string.IsNullOrEmpty(chaXun.JingDianName))
                {
                    s.AppendFormat(" AND EXISTS(SELECT 1 FROM tbl_ScenicArea WHERE tbl_ScenicArea.ScenicId=tbl_JingDianDianPing.JingDianId AND tbl_ScenicArea.ScenicName LIKE '%{0}%' ) ", chaXun.JingDianName);
                }
                if (!string.IsNullOrEmpty(chaXun.OperatorId))
                {
                    s.AppendFormat(" AND OperatorId='{0}' ", chaXun.OperatorId);
                }
                if (!string.IsNullOrEmpty(chaXun.OperatorName))
                {
                    s.AppendFormat(" AND (EXISTS(SELECT 1 FROM tbl_Member WHERE MemberID=tbl_JingDianDianPing.OperatorId AND Account LIKE '%{0}%') OR EXISTS(SELECT 1 FROM tbl_Webmaster WHERE Id=tbl_JingDianDianPing.OperatorId AND Username LIKE '%{0}%') )", chaXun.OperatorName);
                }
            }

            using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), s.ToString(), orderByString, string.Empty))
            {
                while (rdr.Read())
                {
                    var info = new EyouSoft.Model.ScenicStructure.MJingDianDianPingInfo();

                    info.DianPingFangShi = (EyouSoft.Model.Enum.XianLuStructure.DianPingType)rdr.GetByte(rdr.GetOrdinal("DianPingFangShi"));
                    info.DianPingId = rdr["DianPingId"].ToString();
                    info.DianPingNeiRong = rdr["DianPingNeiRong"].ToString();
                    info.DianPingShiJian = rdr.GetDateTime(rdr.GetOrdinal("DianPingShiJian"));
                    info.IsCheck = rdr["IsCheck"].ToString() == "1";
                    info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
                    info.JingDianId = rdr["JingDianId"].ToString();
                    info.JingDianName = rdr["JingDianName"].ToString();
                    info.ManYiDu = rdr.GetDecimal(rdr.GetOrdinal("ManYiDu"));
                    info.OperatorId = rdr["OperatorId"].ToString();
                    info.OperatorName = rdr["OperatorName"].ToString();
                    if (!rdr.IsDBNull(rdr.GetOrdinal("YouLanShiJian"))) info.YouLanShiJian = rdr.GetDateTime(rdr.GetOrdinal("YouLanShiJian"));
                    info.SortId = rdr.GetInt32(rdr.GetOrdinal("SortId"));
                    info.ShuLiang = rdr.GetInt32(rdr.GetOrdinal("ShuLiang"));
                    info.JingQu = (EyouSoft.Model.Enum.XianLuStructure.DianPingStatus)rdr.GetByte(rdr.GetOrdinal("JingQu"));
                    info.YuDing = (EyouSoft.Model.Enum.XianLuStructure.DianPingStatus)rdr.GetByte(rdr.GetOrdinal("YuDing"));

                    items.Add(info);
                }
            }

            return items;
        }

        /// <summary>
        /// 审核点评
        /// </summary>
        /// <param name="dianPingId"></param>
        /// <param name="isShenHe"></param>
        /// <returns></returns>
        public int ShenHeDianPing(string dianPingId, bool isShenHe)
        {
            string sql = "UPDATE tbl_JingDianDianPing SET IsCheck=@IsCheck WHERE DianPingId=@DianPingId";
            DbCommand cmd = _db.GetSqlStringCommand(sql);

            _db.AddInParameter(cmd, "DianPingId", DbType.AnsiStringFixedLength, dianPingId);
            _db.AddInParameter(cmd, "IsCheck", DbType.AnsiStringFixedLength, isShenHe ? "1" : "0");

            return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
        }

        /// <summary>
        /// 获取满意度
        /// </summary>
        /// <param name="jingDianId"></param>
        /// <returns></returns>
        public decimal GetManYiDu(string jingDianId)
        {
            string sql = "SELECT AVG(ManYiDu) AS ManYiDu FROM tbl_JingDianDianPing  WHERE JingDianId=@JingDianId AND IsCheck='1' ";
            DbCommand cmd = _db.GetSqlStringCommand(sql);
            _db.AddInParameter(cmd, "JingDianId", DbType.AnsiStringFixedLength, jingDianId);

            using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
            {
                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(0)) return rdr.GetDecimal(0);
                }
            }

            return 0;
        }

        /// <summary>
        /// 获取门票剩余人数
        /// </summary>
        /// <param name="ticketId"></param>
        /// <returns></returns>
        public int ScenicStrucNumber(string ticketId)
        {
            int YiShou = 0;
            int JiHua = 0;
            if (string.IsNullOrEmpty(ticketId)) return -1;
            StringBuilder sql = new StringBuilder();

            sql.Append(" SELECT [Number],(");
            sql.Append(" SELECT SUM([Num])  FROM [tbl_ScenicAreaOrder]");
            sql.Append(" WHERE [TicketsId]=@ticketId AND [Status] IN(0,3,4,5)) as YiShou ");
            sql.Append(" FROM [tbl_ScenicTickets] ");
            sql.Append(" WHERE [TicketsId]=@ticketId");
            DbCommand dc = _db.GetSqlStringCommand(sql.ToString());
            _db.AddInParameter(dc, "ticketId", DbType.String, ticketId);

            using (IDataReader dr = DbHelper.ExecuteReader(dc, this._db))
            {
                while (dr.Read())
                {
                    YiShou = !dr.IsDBNull(dr.GetOrdinal("YiShou")) ? dr.GetInt32(dr.GetOrdinal("YiShou")) : 0;
                    JiHua = !dr.IsDBNull(dr.GetOrdinal("Number")) ? dr.GetInt32(dr.GetOrdinal("Number")) : 0;
                }
            }
            int ShenYu = JiHua - YiShou;

            return ShenYu > 0 ? ShenYu : 0;
        }
        /// <summary>
        /// 支付完成执行方法
        /// </summary>
        /// <param name="info">订单</param>
        /// <returns></returns>
        public int SheZhiZhiFus(EyouSoft.Model.ScenicStructure.MScenicAreaOrder info)
        {
            DbCommand cmd = _db.GetSqlStringCommand("UPDATE tbl_ScenicAreaOrder SET FuKuanStatus=@FuKuanStatus ,Status=@Status WHERE  OrderId=@OrderId ");

            _db.AddInParameter(cmd, "FuKuanStatus", DbType.Byte, info.FuKuanStatus);
            _db.AddInParameter(cmd, "Status", DbType.Byte, info.Status);
            _db.AddInParameter(cmd, "OrderId", DbType.AnsiStringFixedLength, info.OrderId);

            return DbHelper.ExecuteSql(cmd, _db) > 0 ? 1 : 0;
        }
        /// <summary>
        /// 根据订单状态获取订单数量
        /// </summary>
        /// <param name="Status">订单状态</param>
        /// <returns></returns>
        public int GetOrderNum(EyouSoft.Model.Enum.XianLuStructure.OrderStatus Status)
        {
            DbCommand cmd = _db.GetSqlStringCommand("Select count(OrderId) from view_ScenicAreaOrder WHERE Status=@Status   ");

            _db.AddInParameter(cmd, "Status", DbType.Byte, Status);

            object num = DbHelper.GetSingle(cmd, _db);
            return Convert.ToInt32(num);
        }
    }
}
