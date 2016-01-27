using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit.DAL;
using EyouSoft.IDAL;
using System.Data.SqlClient;
using System.Xml.Linq;
using EyouSoft.Toolkit;

namespace EyouSoft.DAL
{
   /// <summary>
   /// 区域省份城市区县
   /// </summary>
   public class DSysAreaInfo : DALBase, ISysAreaInfo
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
      public DSysAreaInfo()
      {
         _db = SystemStore;
      }
      #endregion

      #region ISysAreaInfo 成员

      #region  区域

      /// <summary>
      /// 是否存在该记录
      /// </summary>
      public bool ExistsSysArea(EyouSoft.Model.MSysArea model)
      {
         string StrSql = " select count(1) from tbl_SysArea WHERE 1=1 ";
         if (model.ID > 0)
         {
            StrSql += " AND ID<>@ID ";
         }
         if (!string.IsNullOrEmpty(model.AreaName))
         {
            StrSql += " AND AreaName=@AreaName ";
         }
         if (model.RouteType > 0)
         {
            StrSql += " AND RouteType = @RouteType ";
         }
         DbCommand dc = this._db.GetSqlStringCommand(StrSql);
         if (model.ID > 0)
         {
            this._db.AddInParameter(dc, "ID", DbType.Int32, model.ID);
         }
         if (!string.IsNullOrEmpty(model.AreaName))
         {
            this._db.AddInParameter(dc, "AreaName", DbType.String, model.AreaName);
         }
         if ((int)model.RouteType > 0)
         {
            this._db.AddInParameter(dc, "RouteType", DbType.Int32, (int)model.RouteType);
         }
         return DbHelper.Exists(dc, _db);
      }

      /// <summary>
      /// 增加一条数据
      /// </summary>
      public bool AddSysArea(EyouSoft.Model.MSysArea model)
      {
          string StrSql = "INSERT INTO tbl_SysArea(AreaName,RouteType,ImgPath,AdvLink,AdvTitle) VALUES(@AreaName,@RouteType,@ImgPath,@AdvLink,@AdvTitle)";
         DbCommand dc = this._db.GetSqlStringCommand(StrSql);
         this._db.AddInParameter(dc, "AreaName", DbType.String, model.AreaName);
         this._db.AddInParameter(dc, "RouteType", DbType.Int32, (int)model.RouteType);
         this._db.AddInParameter(dc, "ImgPath", DbType.String, model.ImgPath);
         this._db.AddInParameter(dc, "AdvLink", DbType.String, model.AdvLink);
         this._db.AddInParameter(dc, "AdvTitle", DbType.String, model.AdvTitle);
         return DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
      }

      /// <summary>
      /// 更新一条数据
      /// </summary>
      public bool UpdateSysArea(EyouSoft.Model.MSysArea model)
      {
         string StrSql = "UPDATE tbl_SysArea SET AreaName = @AreaName,RouteType = @RouteType,ImgPath = @ImgPath,AdvLink = @AdvLink , AdvTitle = @AdvTitle WHERE ID=@ID";
         DbCommand dc = this._db.GetSqlStringCommand(StrSql);
         this._db.AddInParameter(dc, "AreaName", DbType.String, model.AreaName);
         this._db.AddInParameter(dc, "RouteType", DbType.Int32, (int)model.RouteType);
         this._db.AddInParameter(dc, "ID", DbType.Int32, model.ID);
         this._db.AddInParameter(dc, "ImgPath", DbType.String, model.ImgPath);
         this._db.AddInParameter(dc, "AdvLink", DbType.String, model.AdvLink);
         this._db.AddInParameter(dc, "AdvTitle", DbType.String, model.AdvTitle);
         return EyouSoft.Toolkit.DAL.DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
      }

      /// <summary>
      /// 删除数据
      /// </summary>
      public bool DeleteSysArea(int ID)
      {
         string StrSql = "DELETE FROM tbl_SysArea WHERE ID=@ID";
         DbCommand dc = this._db.GetSqlStringCommand(StrSql);
         this._db.AddInParameter(dc, "ID", DbType.Int32, ID);
         return EyouSoft.Toolkit.DAL.DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
      }

      /// <summary>
      /// 得到一个对象实体
      /// </summary>
      public EyouSoft.Model.MSysArea GetSysAreaModel(int ID)
      {
         EyouSoft.Model.MSysArea model = null;
         string StrSql = "SELECT ID, AreaName, RouteType, ImgPath, AdvLink, AdvTitle FROM tbl_SysArea WHERE ID=@ID";
         DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
         this._db.AddInParameter(dc, "ID", DbType.Int32, ID);
         using (IDataReader dr = EyouSoft.Toolkit.DAL.DbHelper.ExecuteReader(dc, this._db))
         {
            if (dr.Read())
            {
               model = new EyouSoft.Model.MSysArea()
               {
                  ID = dr.GetInt32(dr.GetOrdinal("ID")),
                  AreaName = dr.IsDBNull(dr.GetOrdinal("AreaName")) ? "" : dr.GetString(dr.GetOrdinal("AreaName")),
                  RouteType = (EyouSoft.Model.Enum.AreaType)dr.GetByte(dr.GetOrdinal("RouteType")),
                  ImgPath = !dr.IsDBNull(dr.GetOrdinal("ImgPath")) ? dr.GetString(dr.GetOrdinal("ImgPath")) : null,
                  AdvLink = !dr.IsDBNull(dr.GetOrdinal("AdvLink")) ? dr.GetString(dr.GetOrdinal("AdvLink")) : null,
                  AdvTitle = !dr.IsDBNull(dr.GetOrdinal("AdvTitle")) ? dr.GetString(dr.GetOrdinal("AdvTitle")) : null
               };
            }
         };
         return model;
      }

      /// <summary>
      /// 更加区域编号获得区域名称
      /// </summary>
      /// <param name="ID"></param>
      /// <returns></returns>
      public string GetSysAreaName(int ID)
      {
         string StrSql = "SELECT AreaName FROM tbl_SysArea WHERE ID=@ID";
         DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
         this._db.AddInParameter(dc, "ID", DbType.Int32, ID);
         using (IDataReader dr = EyouSoft.Toolkit.DAL.DbHelper.ExecuteReader(dc, this._db))
         {
            if (dr.Read())
            {
               return dr.IsDBNull(dr.GetOrdinal("AreaName")) ? "" : dr.GetString(dr.GetOrdinal("AreaName"));
            }
         };
         return "";
      }

      /// <summary>
      /// 获得数据列表集合，分页
      /// </summary>
      /// <param name="pageSize"></param>
      /// <param name="pageIndex"></param>
      /// <param name="recordCount"></param>
      /// <param name="chaXun"></param>
      /// <returns></returns>
      public IList<EyouSoft.Model.MSysArea> GetSysAreaList(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.MSysArea chaXun)
      {
         IList<EyouSoft.Model.MSysArea> ResultList = null;
         string tableName = "tbl_SysArea";
         string fields = "ID, AreaName, RouteType";
         string query = " 1=1 ";
         if (chaXun != null)
         {
            if ((int)chaXun.RouteType > 0)
            {
               query = query + string.Format(" AND RouteType={0} ", (int)chaXun.RouteType);
            }
            if (!string.IsNullOrEmpty(chaXun.AreaName))
            {
               query = query + string.Format(" AND AreaName like '%{0}%'", chaXun.AreaName);
            }
         }
         string orderByString = " ID ASC";
         using (IDataReader dr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields, query
             , orderByString, string.Empty))
         {
            ResultList = new List<EyouSoft.Model.MSysArea>();
            while (dr.Read())
            {
               EyouSoft.Model.MSysArea model = new EyouSoft.Model.MSysArea()
               {
                  ID = dr.GetInt32(dr.GetOrdinal("ID")),
                  AreaName = dr.IsDBNull(dr.GetOrdinal("AreaName")) ? "" : dr.GetString(dr.GetOrdinal("AreaName")),
                  RouteType = (EyouSoft.Model.Enum.AreaType)dr.GetByte(dr.GetOrdinal("RouteType"))
               };
               ResultList.Add(model);
               model = null;
            }
         };
         return ResultList;
      }

      /// <summary>
      /// 获得前几行数据集合
      /// </summary>
      /// <param name="Top">0:所有</param>
      /// <param name="chaXun"></param>
      /// <param name="filedOrder"></param>
      /// <returns></returns>
      public IList<EyouSoft.Model.MSysArea> GetSysAreaList(int Top, EyouSoft.Model.MSysArea chaXun, string filedOrder)
      {
         IList<EyouSoft.Model.MSysArea> ResultList = null;
         string StrSql = string.Format("SELECT {0} ID, AreaName, RouteType FROM tbl_SysArea WHERE 1=1 ", (Top > 0 ? " TOP " + Top + " " : ""));
         if (chaXun != null)
         {
            if ((int)chaXun.RouteType > 0)
            {
               StrSql = StrSql + string.Format(" AND RouteType={0} ", (int)chaXun.RouteType);
            }
            if (!string.IsNullOrEmpty(chaXun.AreaName))
            {
               StrSql = StrSql + string.Format(" AND AreaName like '%{0}%'", chaXun.AreaName);
            }
            if (chaXun.ID > 0)
            {
               StrSql = StrSql + string.Format(" AND ID ={0}", chaXun.ID);
            }
         }
         StrSql = StrSql + (string.IsNullOrEmpty(filedOrder) ? "" : " ORDER BY " + filedOrder + " ASC ");
         DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
         using (IDataReader dr = EyouSoft.Toolkit.DAL.DbHelper.ExecuteReader(dc, this._db))
         {
            ResultList = new List<EyouSoft.Model.MSysArea>();
            while (dr.Read())
            {
               EyouSoft.Model.MSysArea model = new EyouSoft.Model.MSysArea()
               {
                  ID = dr.GetInt32(dr.GetOrdinal("ID")),
                  AreaName = dr.IsDBNull(dr.GetOrdinal("AreaName")) ? "" : dr.GetString(dr.GetOrdinal("AreaName")),
                  RouteType = (EyouSoft.Model.Enum.AreaType)dr.GetByte(dr.GetOrdinal("RouteType"))
               };
               ResultList.Add(model);
               model = null;
            }

         }
         return ResultList;
      }

      #endregion  区域

      #region  国家

      /// <summary>
      /// 是否存在该记录
      /// </summary>
      public bool ExistsSysCountry(EyouSoft.Model.MSysCountry model)
      {
         string StrSql = " select count(1) from tbl_SysCountry WHERE 1=1 ";
         if (model.Id > 0)
         {
            StrSql += " AND Id<>@Id ";
         }
         if (!string.IsNullOrEmpty(model.EnName))
         {
            StrSql += " AND EnName=@EnName ";
         }
         if (!string.IsNullOrEmpty(model.CnName))
         {
            StrSql += " AND CnName=@CnName ";
         }
         if (model.Zones > 0)
         {
            StrSql += " AND Zones = @Zones ";
         }
         DbCommand dc = this._db.GetSqlStringCommand(StrSql);
         if (model.Id > 0)
         {
            this._db.AddInParameter(dc, "Id", DbType.Int32, model.Id);
         }
         if (!string.IsNullOrEmpty(model.EnName))
         {
            this._db.AddInParameter(dc, "EnName", DbType.String, model.EnName);
         }
         if (!string.IsNullOrEmpty(model.CnName))
         {
            this._db.AddInParameter(dc, "CnName", DbType.String, model.CnName);
         }
         if (model.Zones > 0)
         {
            this._db.AddInParameter(dc, "Zones", DbType.Int32, model.Zones);
         }
         return DbHelper.Exists(dc, _db);
      }

      /// <summary>
      /// 增加一条数据
      /// </summary>
      public bool AddSysCountry(EyouSoft.Model.MSysCountry model)
      {
         string StrSql = "INSERT INTO tbl_SysCountry(EnName,Zones,CnName) VALUES(@EnName,@Zones,@CnName)";
         DbCommand dc = this._db.GetSqlStringCommand(StrSql);
         this._db.AddInParameter(dc, "EnName", DbType.String, model.EnName);
         this._db.AddInParameter(dc, "CnName", DbType.String, model.CnName);
         this._db.AddInParameter(dc, "Zones", DbType.Int32, model.Zones);
         return DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
      }

      /// <summary>
      /// 更新一条数据
      /// </summary>
      public bool UpdateSysCountry(EyouSoft.Model.MSysCountry model)
      {
         string StrSql = "UPDATE tbl_SysCountry SET EnName = @EnName,Zones = @Zones,CnName = @CnName WHERE Id=@Id";
         DbCommand dc = this._db.GetSqlStringCommand(StrSql);
         this._db.AddInParameter(dc, "EnName", DbType.String, model.EnName);
         this._db.AddInParameter(dc, "CnName", DbType.String, model.CnName);
         this._db.AddInParameter(dc, "Zones", DbType.Int32, model.Zones);
         this._db.AddInParameter(dc, "Id", DbType.Int32, model.Id);
         return EyouSoft.Toolkit.DAL.DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
      }

      /// <summary>
      /// 删除数据
      /// </summary>
      public bool DeleteSysCountry(int ID)
      {
         string StrSql = "DELETE FROM tbl_SysCountry WHERE Id=@Id";
         DbCommand dc = this._db.GetSqlStringCommand(StrSql);
         this._db.AddInParameter(dc, "Id", DbType.Int32, ID);
         return EyouSoft.Toolkit.DAL.DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
      }

      /// <summary>
      /// 得到一个对象实体
      /// </summary>
      public EyouSoft.Model.MSysCountry GetSysCountryModel(int ID)
      {
         EyouSoft.Model.MSysCountry model = null;
         string StrSql = "SELECT Id, EnName,Zones,CnName FROM tbl_SysCountry WHERE Id=@Id";
         DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
         this._db.AddInParameter(dc, "Id", DbType.Int32, ID);
         using (IDataReader dr = EyouSoft.Toolkit.DAL.DbHelper.ExecuteReader(dc, this._db))
         {
            if (dr.Read())
            {
               model = new EyouSoft.Model.MSysCountry()
               {
                  Id = dr.GetInt32(dr.GetOrdinal("Id")),
                  EnName = dr.IsDBNull(dr.GetOrdinal("EnName")) ? "" : dr.GetString(dr.GetOrdinal("EnName")),
                  Zones = dr.GetInt32(dr.GetOrdinal("Zones")),
                  CnName = dr.IsDBNull(dr.GetOrdinal("CnName")) ? "" : dr.GetString(dr.GetOrdinal("CnName"))
               };
            }
         };
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
      public IList<EyouSoft.Model.MSysCountry> GetSysCountryList(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.MSysCountry chaXun)
      {
         IList<EyouSoft.Model.MSysCountry> ResultList = null;
         string tableName = "tbl_SysCountry";
         string identityColumnName = "Id";
         string fields = "Id, EnName,Zones,CnName";
         string query = " 1=1 ";
         if (chaXun != null)
         {
            if (chaXun.Zones > 0)
            {
               query = query + string.Format(" AND Zones={0} ", chaXun.Zones);
            }
            if (!string.IsNullOrEmpty(chaXun.EnName))
            {
               query = query + string.Format(" AND EnName like '%{0}%'", chaXun.EnName);
            }
            if (!string.IsNullOrEmpty(chaXun.CnName))
            {
               query = query + string.Format(" AND CnName like '%{0}%'", chaXun.CnName);
            }
         }
         string orderByString = " ID ASC";
         using (IDataReader dr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, identityColumnName, fields, query, orderByString))
         {
            ResultList = new List<EyouSoft.Model.MSysCountry>();
            while (dr.Read())
            {
               EyouSoft.Model.MSysCountry model = new EyouSoft.Model.MSysCountry()
               {
                  Id = dr.GetInt32(dr.GetOrdinal("Id")),
                  EnName = dr.IsDBNull(dr.GetOrdinal("EnName")) ? "" : dr.GetString(dr.GetOrdinal("EnName")),
                  Zones = dr.GetInt32(dr.GetOrdinal("Zones")),
                  CnName = dr.IsDBNull(dr.GetOrdinal("CnName")) ? "" : dr.GetString(dr.GetOrdinal("CnName"))
               };
               ResultList.Add(model);
               model = null;
            }
         };
         return ResultList;
      }

      /// <summary>
      /// 获得前几行数据集合
      /// </summary>
      /// <param name="Top">0:所有</param>
      /// <param name="chaXun"></param>
      /// <param name="filedOrder"></param>
      /// <returns></returns>
      public IList<EyouSoft.Model.MSysCountry> GetSysCountryList(int Top, EyouSoft.Model.MSysCountry chaXun, string filedOrder)
      {
         IList<EyouSoft.Model.MSysCountry> ResultList = null;
         string StrSql = string.Format("SELECT {0} Id, EnName,Zones,CnName FROM tbl_SysCountry WHERE 1=1 ", (Top > 0 ? " TOP " + Top + " " : ""));
         if (chaXun != null)
         {
            if (chaXun.Zones > 0)
            {
               StrSql = StrSql + string.Format(" AND Zones={0} ", chaXun.Zones);
            }
            if (!string.IsNullOrEmpty(chaXun.EnName))
            {
               StrSql = StrSql + string.Format(" AND EnName like '%{0}%'", chaXun.EnName);
            }
            if (!string.IsNullOrEmpty(chaXun.CnName))
            {
               StrSql = StrSql + string.Format(" AND CnName like '%{0}%'", chaXun.CnName);
            }
         }
         StrSql = StrSql + (string.IsNullOrEmpty(filedOrder) ? "" : " ORDER BY " + filedOrder + " ASC ");
         DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
         using (IDataReader dr = EyouSoft.Toolkit.DAL.DbHelper.ExecuteReader(dc, this._db))
         {
            ResultList = new List<EyouSoft.Model.MSysCountry>();
            while (dr.Read())
            {
               EyouSoft.Model.MSysCountry model = new EyouSoft.Model.MSysCountry()
               {
                  Id = dr.GetInt32(dr.GetOrdinal("Id")),
                  EnName = dr.IsDBNull(dr.GetOrdinal("EnName")) ? "" : dr.GetString(dr.GetOrdinal("EnName")),
                  Zones = dr.GetInt32(dr.GetOrdinal("Zones")),
                  CnName = dr.IsDBNull(dr.GetOrdinal("CnName")) ? "" : dr.GetString(dr.GetOrdinal("CnName"))
               };
               ResultList.Add(model);
               model = null;
            }

         }
         return ResultList;
      }

      #endregion  国家

      #region  省份

      /// <summary>
      /// 是否存在该记录
      /// </summary>
      public bool ExistsSysProvince(EyouSoft.Model.MSysProvince model)
      {
         string StrSql = " select count(1) from tbl_SysProvince WHERE 1=1 ";
         if (model.ID > 0)
         {
            StrSql += " AND ID<>@ID ";
         }
         if (!string.IsNullOrEmpty(model.Name))
         {
            StrSql += " AND Name=@Name ";
         }
         if (!string.IsNullOrEmpty(model.HeaderLetter))
         {
            StrSql += " AND HeaderLetter=@HeaderLetter ";
         }
         if (model.CountryId > 0)
         {
            StrSql += " AND CountryId = @CountryId ";
         }
         if (model.AreaId > 0)
         {
            StrSql += " AND AreaId = @AreaId ";
         }
         DbCommand dc = this._db.GetSqlStringCommand(StrSql);
         if (model.ID > 0)
         {
            this._db.AddInParameter(dc, "ID", DbType.Int32, model.ID);
         }
         if (!string.IsNullOrEmpty(model.Name))
         {
            this._db.AddInParameter(dc, "Name", DbType.String, model.Name);
         }
         if (!string.IsNullOrEmpty(model.HeaderLetter))
         {
            this._db.AddInParameter(dc, "HeaderLetter", DbType.String, model.HeaderLetter);
         }
         if (model.CountryId > 0)
         {
            this._db.AddInParameter(dc, "CountryId", DbType.Int32, model.CountryId);
         }
         if (model.AreaId > 0)
         {
            this._db.AddInParameter(dc, "AreaId", DbType.Int32, model.AreaId);
         }
         return DbHelper.Exists(dc, _db);
      }

      /// <summary>
      /// 增加一条数据
      /// </summary>
      public bool AddSysProvince(EyouSoft.Model.MSysProvince model)
      {
         string StrSql = "INSERT INTO tbl_SysProvince(CountryId,HeaderLetter,Name,AreaId,SortId) VALUES(@CountryId,@HeaderLetter,@Name,@AreaId,@SortId)";
         DbCommand dc = this._db.GetSqlStringCommand(StrSql);
         this._db.AddInParameter(dc, "CountryId", DbType.Int32, model.CountryId);
         this._db.AddInParameter(dc, "HeaderLetter", DbType.String, model.HeaderLetter);
         this._db.AddInParameter(dc, "Name", DbType.String, model.Name);
         this._db.AddInParameter(dc, "AreaId", DbType.Int32, model.AreaId);
         this._db.AddInParameter(dc, "SortId", DbType.Int32, model.SortId);
         return DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
      }

      /// <summary>
      /// 更新一条数据
      /// </summary>
      public bool UpdateSysProvince(EyouSoft.Model.MSysProvince model)
      {
         string StrSql = "UPDATE tbl_SysProvince SET CountryId=@CountryId,HeaderLetter=@HeaderLetter,Name=@Name,AreaId=@AreaId,SortId=@SortId WHERE ID=@ID";
         DbCommand dc = this._db.GetSqlStringCommand(StrSql);
         this._db.AddInParameter(dc, "CountryId", DbType.Int32, model.CountryId);
         this._db.AddInParameter(dc, "HeaderLetter", DbType.String, model.HeaderLetter);
         this._db.AddInParameter(dc, "Name", DbType.String, model.Name);
         this._db.AddInParameter(dc, "AreaId", DbType.Int32, model.AreaId);
         this._db.AddInParameter(dc, "SortId", DbType.Int32, model.SortId);
         this._db.AddInParameter(dc, "ID", DbType.Int32, model.ID);
         return EyouSoft.Toolkit.DAL.DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
      }

      /// <summary>
      /// 删除数据
      /// </summary>
      public bool DeleteSysProvince(int ID)
      {
         string StrSql = " DELETE FROM tbl_SysCity WHERE ProvinceId=@ID ;DELETE FROM tbl_SysProvince WHERE ID=@ID";
         DbCommand dc = this._db.GetSqlStringCommand(StrSql);
         this._db.AddInParameter(dc, "ID", DbType.Int32, ID);
         return EyouSoft.Toolkit.DAL.DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
      }

      /// <summary>
      /// 得到一个对象实体
      /// </summary>
      public EyouSoft.Model.MSysProvince GetSysProvinceModel(int ID)
      {
         EyouSoft.Model.MSysProvince model = null;
         string StrSql = "SELECT ID, CountryId,HeaderLetter,Name,AreaId,SortId FROM tbl_SysProvince WHERE ID=@ID";
         DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
         this._db.AddInParameter(dc, "ID", DbType.Int32, ID);
         using (IDataReader dr = EyouSoft.Toolkit.DAL.DbHelper.ExecuteReader(dc, this._db))
         {
            if (dr.Read())
            {
               model = new EyouSoft.Model.MSysProvince()
               {
                  ID = dr.GetInt32(dr.GetOrdinal("ID")),
                  CountryId = dr.GetInt32(dr.GetOrdinal("CountryId")),
                  HeaderLetter = dr.IsDBNull(dr.GetOrdinal("HeaderLetter")) ? "" : dr.GetString(dr.GetOrdinal("HeaderLetter")),
                  Name = dr.IsDBNull(dr.GetOrdinal("Name")) ? "" : dr.GetString(dr.GetOrdinal("Name")),
                  AreaId = dr.GetInt32(dr.GetOrdinal("AreaId")),
                  SortId = dr.GetInt32(dr.GetOrdinal("SortId"))
               };
            }
         };
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
      public IList<EyouSoft.Model.MSysProvince> GetSysProvinceList(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.MSysProvince chaXun)
      {
         IList<EyouSoft.Model.MSysProvince> ResultList = null;
         string tableName = "tbl_SysProvince";
         string fields = "ID, CountryId,HeaderLetter,Name,AreaId,SortId,(select [Id],[ProvinceId],[Name],[CenterCityId],[HeaderLetter],[IsSite],[DomainName],[IsEnabled] from tbl_SysCity where tbl_SysCity.ProvinceId = tbl_SysProvince.ID for xml raw,root('Root')) as CityList ";
         string query = " 1=1 ";
         if (chaXun != null)
         {
            if (chaXun.CountryId > 0)
            {
               query = query + string.Format(" AND CountryId={0} ", chaXun.CountryId);
            }
            if (!string.IsNullOrEmpty(chaXun.HeaderLetter))
            {
               query = query + string.Format(" AND HeaderLetter like '%{0}%'", chaXun.HeaderLetter);
            }
            if (!string.IsNullOrEmpty(chaXun.Name))
            {
               query = query + string.Format(" AND Name like '%{0}%'", chaXun.Name);
            }
            if (chaXun.AreaId > 0)
            {
               query = query + string.Format(" AND AreaId={0} ", chaXun.AreaId);
            }
         }
         string orderByString = " ID ASC";
         using (IDataReader dr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields, query
             , orderByString, string.Empty))
         {
            ResultList = new List<EyouSoft.Model.MSysProvince>();
            while (dr.Read())
            {
               EyouSoft.Model.MSysProvince model = new EyouSoft.Model.MSysProvince()
               {
                  ID = dr.GetInt32(dr.GetOrdinal("ID")),
                  CountryId = dr.GetInt32(dr.GetOrdinal("CountryId")),
                  HeaderLetter = dr.IsDBNull(dr.GetOrdinal("HeaderLetter")) ? "" : dr.GetString(dr.GetOrdinal("HeaderLetter")),
                  Name = dr.IsDBNull(dr.GetOrdinal("Name")) ? "" : dr.GetString(dr.GetOrdinal("Name")),
                  AreaId = dr.GetInt32(dr.GetOrdinal("AreaId")),
                  SortId = dr.GetInt32(dr.GetOrdinal("SortId"))
               };
               if (!dr.IsDBNull(dr.GetOrdinal("CityList")))
                  model.CityList = (List<EyouSoft.Model.MSysCity>)this.GetCity(dr.GetString(dr.GetOrdinal("CityList")));

               ResultList.Add(model);
               model = null;
            }
         };
         return ResultList;
      }

      /// <summary>
      /// 获得前几行数据集合
      /// </summary>
      /// <param name="Top">0:所有</param>
      /// <param name="chaXun"></param>
      /// <param name="filedOrder"></param>
      /// <returns></returns>
      public IList<EyouSoft.Model.MSysProvince> GetSysProvinceList(int Top, EyouSoft.Model.MSysProvince chaXun, string filedOrder)
      {
         IList<EyouSoft.Model.MSysProvince> ResultList = null;
         string StrSql = string.Format("SELECT {0} ID, CountryId,HeaderLetter,Name,AreaId,SortId FROM tbl_SysProvince WHERE 1=1 ", (Top > 0 ? " TOP " + Top + " " : ""));
         if (chaXun != null)
         {
            if (chaXun.CountryId > 0)
            {
               StrSql = StrSql + string.Format(" AND CountryId={0} ", chaXun.CountryId);
            }
            if (!string.IsNullOrEmpty(chaXun.HeaderLetter))
            {
               StrSql = StrSql + string.Format(" AND HeaderLetter like '%{0}%'", chaXun.HeaderLetter);
            }
            if (!string.IsNullOrEmpty(chaXun.Name))
            {
               StrSql = StrSql + string.Format(" AND Name like '%{0}%'", chaXun.Name);
            }
            if (chaXun.AreaId > 0)
            {
               StrSql = StrSql + string.Format(" AND AreaId={0} ", chaXun.AreaId);
            }
         }
         StrSql = StrSql + (string.IsNullOrEmpty(filedOrder) ? "" : " ORDER BY " + filedOrder + " ASC ");
         DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
         using (IDataReader dr = EyouSoft.Toolkit.DAL.DbHelper.ExecuteReader(dc, this._db))
         {
            ResultList = new List<EyouSoft.Model.MSysProvince>();
            while (dr.Read())
            {
               EyouSoft.Model.MSysProvince model = new EyouSoft.Model.MSysProvince()
               {
                  ID = dr.GetInt32(dr.GetOrdinal("ID")),
                  CountryId = dr.GetInt32(dr.GetOrdinal("CountryId")),
                  HeaderLetter = dr.IsDBNull(dr.GetOrdinal("HeaderLetter")) ? "" : dr.GetString(dr.GetOrdinal("HeaderLetter")),
                  Name = dr.IsDBNull(dr.GetOrdinal("Name")) ? "" : dr.GetString(dr.GetOrdinal("Name")),
                  AreaId = dr.GetInt32(dr.GetOrdinal("AreaId")),
                  SortId = dr.GetInt32(dr.GetOrdinal("SortId"))
               };
               ResultList.Add(model);
               model = null;
            }

         }
         return ResultList;
      }

      private IList<Model.MSysCity> GetCity(string sqlXml)
      {
         if (string.IsNullOrEmpty(sqlXml)) return null;

         var xRoot = XElement.Parse(sqlXml);
         var xRow = Utils.GetXElements(xRoot, "row");

         if (xRow == null || !xRow.Any()) return null;

         return
             xRow.Select(
                 t =>
                 new Model.MSysCity
                     {
                        CenterCityId = Utils.GetInt(Utils.GetXAttributeValue(t, "CenterCityId")),
                        DomainName = Utils.GetXAttributeValue(t, "DomainName"),
                        HeaderLetter = Utils.GetXAttributeValue(t, "HeaderLetter"),
                        Id = Utils.GetInt(Utils.GetXAttributeValue(t, "Id")),
                        IsEnabled = this.GetBoolean(Utils.GetXAttributeValue(t, "IsEnabled")),
                        IsSite = this.GetBoolean(Utils.GetXAttributeValue(t, "IsSite")),
                        Name = Utils.GetXAttributeValue(t, "Name"),
                        ProvinceId = Utils.GetInt(Utils.GetXAttributeValue(t, "ProvinceId"))
                     }).ToList();
      }

      #endregion  省份

      #region  城市

      /// <summary>
      /// 是否存在该记录
      /// </summary>
      public bool ExistsSysCity(EyouSoft.Model.MSysCity model)
      {
         string StrSql = " select count(1) from tbl_SysCity WHERE 1=1 ";
         if (model.Id > 0)
         {
            StrSql += " AND Id<>@Id ";
         }
         if (!string.IsNullOrEmpty(model.Name))
         {
            StrSql += " AND Name=@Name ";
         }
         if (!string.IsNullOrEmpty(model.HeaderLetter))
         {
            StrSql += " AND HeaderLetter=@HeaderLetter ";
         }
         if (model.ProvinceId > 0)
         {
            StrSql += " AND ProvinceId = @ProvinceId ";
         }
         DbCommand dc = this._db.GetSqlStringCommand(StrSql);
         if (model.Id > 0)
         {
            this._db.AddInParameter(dc, "Id", DbType.Int32, model.Id);
         }
         if (!string.IsNullOrEmpty(model.Name))
         {
            this._db.AddInParameter(dc, "Name", DbType.String, model.Name);
         }
         if (!string.IsNullOrEmpty(model.HeaderLetter))
         {
            this._db.AddInParameter(dc, "HeaderLetter", DbType.String, model.HeaderLetter);
         }
         if (model.ProvinceId > 0)
         {
            this._db.AddInParameter(dc, "ProvinceId", DbType.Int32, model.ProvinceId);
         }
         return DbHelper.Exists(dc, _db);

      }

      /// <summary>
      /// 增加一条数据
      /// </summary>
      public bool AddSysCity(EyouSoft.Model.MSysCity model)
      {
         string StrSql = "INSERT INTO tbl_SysCity(ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled) VALUES(@ProvinceId,@Name,@CenterCityId,@HeaderLetter,@IsSite,@DomainName,@IsEnabled)";
         DbCommand dc = this._db.GetSqlStringCommand(StrSql);
         this._db.AddInParameter(dc, "ProvinceId", DbType.Int32, model.ProvinceId);
         this._db.AddInParameter(dc, "Name", DbType.String, model.Name);
         this._db.AddInParameter(dc, "CenterCityId", DbType.Int32, model.CenterCityId);
         this._db.AddInParameter(dc, "HeaderLetter", DbType.String, model.HeaderLetter);
         this._db.AddInParameter(dc, "IsSite", DbType.AnsiStringFixedLength, this.GetBooleanToStr(model.IsSite));
         this._db.AddInParameter(dc, "DomainName", DbType.String, model.DomainName);
         this._db.AddInParameter(dc, "IsEnabled", DbType.AnsiStringFixedLength, this.GetBooleanToStr(model.IsEnabled));
         return DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
      }

      /// <summary>
      /// 更新一条数据
      /// </summary>
      public bool UpdateSysCity(EyouSoft.Model.MSysCity model)
      {
         string StrSql = "UPDATE tbl_SysCity SET ProvinceId = @ProvinceId,Name = @Name,CenterCityId = @CenterCityId,HeaderLetter = @HeaderLetter,IsSite = @IsSite,DomainName = @DomainName,IsEnabled = @IsEnabled WHERE Id=@Id";
         DbCommand dc = this._db.GetSqlStringCommand(StrSql);
         this._db.AddInParameter(dc, "ProvinceId", DbType.Int32, model.ProvinceId);
         this._db.AddInParameter(dc, "Name", DbType.String, model.Name);
         this._db.AddInParameter(dc, "CenterCityId", DbType.Int32, model.CenterCityId);
         this._db.AddInParameter(dc, "HeaderLetter", DbType.String, model.HeaderLetter);
         this._db.AddInParameter(dc, "IsSite", DbType.AnsiStringFixedLength, this.GetBooleanToStr(model.IsSite));
         this._db.AddInParameter(dc, "DomainName", DbType.String, model.DomainName);
         this._db.AddInParameter(dc, "IsEnabled", DbType.AnsiStringFixedLength, this.GetBooleanToStr(model.IsEnabled));
         this._db.AddInParameter(dc, "Id", DbType.Int32, model.Id);
         return EyouSoft.Toolkit.DAL.DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
      }

      /// <summary>
      /// 删除数据
      /// </summary>
      public bool DeleteSysCity(int ID)
      {
         string StrSql = " DELETE FROM tbl_SysCity WHERE Id=@Id ";
         DbCommand dc = this._db.GetSqlStringCommand(StrSql);
         this._db.AddInParameter(dc, "Id", DbType.Int32, ID);
         return EyouSoft.Toolkit.DAL.DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
      }

      /// <summary>
      /// 得到一个对象实体
      /// </summary>
      public EyouSoft.Model.MSysCity GetSysCityModel(int ID)
      {
         EyouSoft.Model.MSysCity model = null;
         string StrSql = "SELECT Id, ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled FROM tbl_SysCity WHERE Id=@Id";
         DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
         this._db.AddInParameter(dc, "Id", DbType.Int32, ID);
         using (IDataReader dr = EyouSoft.Toolkit.DAL.DbHelper.ExecuteReader(dc, this._db))
         {
            if (dr.Read())
            {
               model = new EyouSoft.Model.MSysCity()
               {
                  Id = dr.GetInt32(dr.GetOrdinal("Id")),
                  ProvinceId = dr.GetInt32(dr.GetOrdinal("ProvinceId")),
                  Name = dr.IsDBNull(dr.GetOrdinal("Name")) ? "" : dr.GetString(dr.GetOrdinal("Name")),
                  CenterCityId = dr.GetInt32(dr.GetOrdinal("CenterCityId")),
                  HeaderLetter = dr.IsDBNull(dr.GetOrdinal("HeaderLetter")) ? "" : dr.GetString(dr.GetOrdinal("HeaderLetter")),
                  IsSite = this.GetBoolean(dr.IsDBNull(dr.GetOrdinal("IsSite")) ? "" : dr.GetString(dr.GetOrdinal("IsSite"))),
                  DomainName = dr.IsDBNull(dr.GetOrdinal("DomainName")) ? "" : dr.GetString(dr.GetOrdinal("DomainName")),
                  IsEnabled = this.GetBoolean(dr.IsDBNull(dr.GetOrdinal("IsEnabled")) ? "" : dr.GetString(dr.GetOrdinal("IsEnabled")))
               };
            }
         };
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
      public IList<EyouSoft.Model.MSysCity> GetSysCityList(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.MSysCity chaXun)
      {
         IList<EyouSoft.Model.MSysCity> ResultList = null;
         string tableName = "tbl_SysCity";
         string identityColumnName = "Id";
         string fields = "Id, ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled";
         string query = " 1=1 ";
         if (chaXun != null)
         {
            if (chaXun.ProvinceId > 0)
            {
               query = query + string.Format(" AND ProvinceId={0} ", chaXun.ProvinceId);
            }
            if (!string.IsNullOrEmpty(chaXun.Name))
            {
               query = query + string.Format(" AND Name like '%{0}%'", chaXun.Name);
            }
            if (chaXun.CenterCityId > 0)
            {
               query = query + string.Format(" AND CenterCityId={0} ", chaXun.CenterCityId);
            }
            if (!string.IsNullOrEmpty(chaXun.HeaderLetter))
            {
               query = query + string.Format(" AND HeaderLetter like '%{0}%'", chaXun.HeaderLetter);
            }
            if (chaXun.IsSite)
            {
               query = query + string.Format(" AND IsSite='{0}'", this.GetBooleanToStr(chaXun.IsSite));
            }
            if (!string.IsNullOrEmpty(chaXun.DomainName))
            {
               query = query + string.Format(" AND DomainName like '%{0}%'", chaXun.DomainName);
            }
            if (chaXun.IsEnabled)
            {
               query = query + string.Format(" AND IsEnabled='{0}'", this.GetBooleanToStr(chaXun.IsEnabled));
            }
         }
         string orderByString = " Id ASC";
         using (IDataReader dr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, identityColumnName, fields, query, orderByString))
         {
            ResultList = new List<EyouSoft.Model.MSysCity>();
            while (dr.Read())
            {
               EyouSoft.Model.MSysCity model = new EyouSoft.Model.MSysCity()
               {
                  Id = dr.GetInt32(dr.GetOrdinal("Id")),
                  ProvinceId = dr.GetInt32(dr.GetOrdinal("ProvinceId")),
                  Name = dr.IsDBNull(dr.GetOrdinal("Name")) ? "" : dr.GetString(dr.GetOrdinal("Name")),
                  CenterCityId = dr.GetInt32(dr.GetOrdinal("CenterCityId")),
                  HeaderLetter = dr.IsDBNull(dr.GetOrdinal("HeaderLetter")) ? "" : dr.GetString(dr.GetOrdinal("HeaderLetter")),
                  IsSite = this.GetBoolean(dr.IsDBNull(dr.GetOrdinal("IsSite")) ? "" : dr.GetString(dr.GetOrdinal("IsSite"))),
                  DomainName = dr.IsDBNull(dr.GetOrdinal("DomainName")) ? "" : dr.GetString(dr.GetOrdinal("DomainName")),
                  IsEnabled = this.GetBoolean(dr.IsDBNull(dr.GetOrdinal("IsEnabled")) ? "" : dr.GetString(dr.GetOrdinal("IsEnabled")))
               };
               ResultList.Add(model);
               model = null;
            }
         };
         return ResultList;
      }

      /// <summary>
      /// 获得前几行数据集合
      /// </summary>
      /// <param name="Top">0:所有</param>
      /// <param name="chaXun"></param>
      /// <param name="filedOrder"></param>
      /// <returns></returns>
      public IList<EyouSoft.Model.MSysCity> GetSysCityList(int Top, EyouSoft.Model.MSysCity chaXun, string filedOrder)
      {
         IList<EyouSoft.Model.MSysCity> ResultList = null;
         string StrSql = string.Format("SELECT {0} Id, ProvinceId,Name,CenterCityId,HeaderLetter,IsSite,DomainName,IsEnabled FROM tbl_SysCity WHERE 1=1 ", (Top > 0 ? " TOP " + Top + " " : ""));
         if (chaXun != null)
         {
            if (chaXun.ProvinceId > -1)
            {
               StrSql = StrSql + string.Format(" AND ProvinceId={0} ", chaXun.ProvinceId);
            }
            if (!string.IsNullOrEmpty(chaXun.Name))
            {
               StrSql = StrSql + string.Format(" AND Name like '%{0}%'", chaXun.Name);
            }
            if (chaXun.CenterCityId > 0)
            {
               StrSql = StrSql + string.Format(" AND CenterCityId={0} ", chaXun.CenterCityId);
            }
            if (!string.IsNullOrEmpty(chaXun.HeaderLetter))
            {
               StrSql = StrSql + string.Format(" AND HeaderLetter like '%{0}%'", chaXun.HeaderLetter);
            }
            if (chaXun.IsSite)
            {
               StrSql = StrSql + string.Format(" AND IsSite='{0}'", this.GetBooleanToStr(chaXun.IsSite));
            }
            if (!string.IsNullOrEmpty(chaXun.DomainName))
            {
               StrSql = StrSql + string.Format(" AND DomainName like '%{0}%'", chaXun.DomainName);
            }
            if (chaXun.IsEnabled)
            {
               StrSql = StrSql + string.Format(" AND IsEnabled='{0}'", this.GetBooleanToStr(chaXun.IsEnabled));
            }
         }
         StrSql = StrSql + (string.IsNullOrEmpty(filedOrder) ? "" : " ORDER BY " + filedOrder + " ASC ");
         DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
         using (IDataReader dr = EyouSoft.Toolkit.DAL.DbHelper.ExecuteReader(dc, this._db))
         {
            ResultList = new List<EyouSoft.Model.MSysCity>();
            while (dr.Read())
            {
               EyouSoft.Model.MSysCity model = new EyouSoft.Model.MSysCity()
               {
                  Id = dr.GetInt32(dr.GetOrdinal("Id")),
                  ProvinceId = dr.GetInt32(dr.GetOrdinal("ProvinceId")),
                  Name = dr.IsDBNull(dr.GetOrdinal("Name")) ? "" : dr.GetString(dr.GetOrdinal("Name")),
                  CenterCityId = dr.GetInt32(dr.GetOrdinal("CenterCityId")),
                  HeaderLetter = dr.IsDBNull(dr.GetOrdinal("HeaderLetter")) ? "" : dr.GetString(dr.GetOrdinal("HeaderLetter")),
                  IsSite = this.GetBoolean(dr.IsDBNull(dr.GetOrdinal("IsSite")) ? "" : dr.GetString(dr.GetOrdinal("IsSite"))),
                  DomainName = dr.IsDBNull(dr.GetOrdinal("DomainName")) ? "" : dr.GetString(dr.GetOrdinal("DomainName")),
                  IsEnabled = this.GetBoolean(dr.IsDBNull(dr.GetOrdinal("IsEnabled")) ? "" : dr.GetString(dr.GetOrdinal("IsEnabled")))
               };
               ResultList.Add(model);
               model = null;
            }

         }
         return ResultList;
      }

      #endregion  城市

      #region  县区

      /// <summary>
      /// 是否存在该记录
      /// </summary>
      public bool ExistsSysDistrict(EyouSoft.Model.MSysDistrict model)
      {
         string StrSql = " select count(1) from tbl_SysDistrict WHERE 1=1 ";
         if (model.Id > 0)
         {
            StrSql += " AND Id<>@Id ";
         }
         if (!string.IsNullOrEmpty(model.Name))
         {
            StrSql += " AND Name=@Name ";
         }
         if (!string.IsNullOrEmpty(model.HeaderLetter))
         {
            StrSql += " AND HeaderLetter=@HeaderLetter ";
         }
         if (model.CityId > 0)
         {
            StrSql += " AND CityId = @CityId ";
         }
         if (model.ProvinceId > 0)
         {
            StrSql += " AND ProvinceId = @ProvinceId ";
         }
         DbCommand dc = this._db.GetSqlStringCommand(StrSql);
         if (model.Id > 0)
         {
            this._db.AddInParameter(dc, "Id", DbType.Int32, model.Id);
         }
         if (!string.IsNullOrEmpty(model.Name))
         {
            this._db.AddInParameter(dc, "Name", DbType.String, model.Name);
         }
         if (!string.IsNullOrEmpty(model.HeaderLetter))
         {
            this._db.AddInParameter(dc, "HeaderLetter", DbType.String, model.HeaderLetter);
         }
         if (model.CityId > 0)
         {
            this._db.AddInParameter(dc, "CityId", DbType.Int32, model.CityId);
         }
         if (model.ProvinceId > 0)
         {
            this._db.AddInParameter(dc, "ProvinceId", DbType.Int32, model.ProvinceId);
         }
         return DbHelper.Exists(dc, _db);
      }

      /// <summary>
      /// 增加一条数据
      /// </summary>
      public bool AddSysDistrict(EyouSoft.Model.MSysDistrict model)
      {
         string StrSql = "INSERT INTO tbl_SysDistrict(Name,ProvinceId,CityId,HeaderLetter) VALUES(@Name,@ProvinceId,@CityId,@HeaderLetter)";
         DbCommand dc = this._db.GetSqlStringCommand(StrSql);
         this._db.AddInParameter(dc, "Name", DbType.String, model.Name);
         this._db.AddInParameter(dc, "ProvinceId", DbType.Int32, model.ProvinceId);
         this._db.AddInParameter(dc, "CityId", DbType.Int32, model.CityId);
         this._db.AddInParameter(dc, "HeaderLetter", DbType.String, model.HeaderLetter);
         return DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
      }

      /// <summary>
      /// 更新一条数据
      /// </summary>
      public bool UpdateSysDistrict(EyouSoft.Model.MSysDistrict model)
      {
         string StrSql = "UPDATE tbl_SysDistrict SET Name = @Name,ProvinceId = @ProvinceId,CityId = @CityId,HeaderLetter=@HeaderLetter WHERE Id=@Id";
         DbCommand dc = this._db.GetSqlStringCommand(StrSql);
         this._db.AddInParameter(dc, "Name", DbType.String, model.Name);
         this._db.AddInParameter(dc, "ProvinceId", DbType.Int32, model.ProvinceId);
         this._db.AddInParameter(dc, "CityId", DbType.Int32, model.CityId);
         this._db.AddInParameter(dc, "HeaderLetter", DbType.String, model.HeaderLetter);
         this._db.AddInParameter(dc, "Id", DbType.Int32, model.Id);
         return EyouSoft.Toolkit.DAL.DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
      }

      /// <summary>
      /// 删除数据
      /// </summary>
      public bool DeleteSysDistrict(int ID)
      {
         string StrSql = "DELETE FROM tbl_SysDistrict WHERE Id=@Id";
         DbCommand dc = this._db.GetSqlStringCommand(StrSql);
         this._db.AddInParameter(dc, "Id", DbType.Int32, ID);
         return EyouSoft.Toolkit.DAL.DbHelper.ExecuteSql(dc, this._db) > 0 ? true : false;
      }

      /// <summary>
      /// 得到一个对象实体
      /// </summary>
      public EyouSoft.Model.MSysDistrict GetSysDistrictModel(int ID)
      {
         EyouSoft.Model.MSysDistrict model = null;
         string StrSql = "SELECT Id, Name,ProvinceId,CityId,HeaderLetter FROM tbl_SysDistrict WHERE Id=@Id";
         DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
         this._db.AddInParameter(dc, "Id", DbType.Int32, ID);
         using (IDataReader dr = EyouSoft.Toolkit.DAL.DbHelper.ExecuteReader(dc, this._db))
         {
            if (dr.Read())
            {
               model = new EyouSoft.Model.MSysDistrict()
               {
                  Id = dr.GetInt32(dr.GetOrdinal("Id")),
                  Name = dr.IsDBNull(dr.GetOrdinal("Name")) ? "" : dr.GetString(dr.GetOrdinal("Name")),
                  ProvinceId = dr.GetInt32(dr.GetOrdinal("ProvinceId")),
                  CityId = dr.GetInt32(dr.GetOrdinal("CityId")),
                  HeaderLetter = dr.IsDBNull(dr.GetOrdinal("HeaderLetter")) ? "" : dr.GetString(dr.GetOrdinal("HeaderLetter"))
               };
            }
         };
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
      public IList<EyouSoft.Model.MSysDistrict> GetSysDistrictList(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.MSysDistrict chaXun)
      {
         IList<EyouSoft.Model.MSysDistrict> ResultList = null;
         string tableName = "tbl_SysDistrict";
         string identityColumnName = "Id";
         string fields = "Id, Name,ProvinceId,CityId,HeaderLetter";
         string query = " 1=1 ";
         if (chaXun != null)
         {
            if (!string.IsNullOrEmpty(chaXun.Name))
            {
               query = query + string.Format(" AND Name like '%{0}%'", chaXun.Name);
            }
            if (chaXun.ProvinceId > 0)
            {
               query = query + string.Format(" AND ProvinceId={0} ", chaXun.ProvinceId);
            }
            if (chaXun.CityId > 0)
            {
               query = query + string.Format(" AND CityId={0} ", chaXun.CityId);
            }
            if (!string.IsNullOrEmpty(chaXun.HeaderLetter))
            {
               query = query + string.Format(" AND HeaderLetter like '%{0}%'", chaXun.HeaderLetter);
            }
         }
         string orderByString = " Id ASC";
         using (IDataReader dr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, identityColumnName, fields, query, orderByString))
         {
            ResultList = new List<EyouSoft.Model.MSysDistrict>();
            while (dr.Read())
            {
               EyouSoft.Model.MSysDistrict model = new EyouSoft.Model.MSysDistrict()
               {
                  Id = dr.GetInt32(dr.GetOrdinal("Id")),
                  Name = dr.IsDBNull(dr.GetOrdinal("Name")) ? "" : dr.GetString(dr.GetOrdinal("Name")),
                  ProvinceId = dr.GetInt32(dr.GetOrdinal("ProvinceId")),
                  CityId = dr.GetInt32(dr.GetOrdinal("CityId")),
                  HeaderLetter = dr.IsDBNull(dr.GetOrdinal("HeaderLetter")) ? "" : dr.GetString(dr.GetOrdinal("HeaderLetter"))
               };
               ResultList.Add(model);
               model = null;
            }
         };
         return ResultList;
      }

      /// <summary>
      /// 获得前几行数据集合
      /// </summary>
      /// <param name="Top">0:所有</param>
      /// <param name="chaXun"></param>
      /// <param name="filedOrder"></param>
      /// <returns></returns>
      public IList<EyouSoft.Model.MSysDistrict> GetSysDistrictList(int Top, EyouSoft.Model.MSysDistrict chaXun, string filedOrder)
      {
         IList<EyouSoft.Model.MSysDistrict> ResultList = null;
         string StrSql = string.Format("SELECT {0} Id, Name,ProvinceId,CityId,HeaderLetter FROM tbl_SysDistrict WHERE 1=1 ", (Top > 0 ? " TOP " + Top + " " : ""));
         if (chaXun != null)
         {
            if (!string.IsNullOrEmpty(chaXun.Name))
            {
               StrSql = StrSql + string.Format(" AND Name like '%{0}%'", chaXun.Name);
            }
            if (chaXun.ProvinceId > 0)
            {
               StrSql = StrSql + string.Format(" AND ProvinceId={0} ", chaXun.ProvinceId);
            }
            if (chaXun.CityId > -1)
            {
               StrSql = StrSql + string.Format(" AND CityId={0} ", chaXun.CityId);
            }
            if (!string.IsNullOrEmpty(chaXun.HeaderLetter))
            {
               StrSql = StrSql + string.Format(" AND HeaderLetter like '%{0}%'", chaXun.HeaderLetter);
            }
         }
         StrSql = StrSql + (string.IsNullOrEmpty(filedOrder) ? "" : " ORDER BY " + filedOrder + " ASC ");
         DbCommand dc = this._db.GetSqlStringCommand(StrSql.ToString());
         using (IDataReader dr = EyouSoft.Toolkit.DAL.DbHelper.ExecuteReader(dc, this._db))
         {
            ResultList = new List<EyouSoft.Model.MSysDistrict>();
            while (dr.Read())
            {
               EyouSoft.Model.MSysDistrict model = new EyouSoft.Model.MSysDistrict()
               {
                  Id = dr.GetInt32(dr.GetOrdinal("Id")),
                  Name = dr.IsDBNull(dr.GetOrdinal("Name")) ? "" : dr.GetString(dr.GetOrdinal("Name")),
                  ProvinceId = dr.GetInt32(dr.GetOrdinal("ProvinceId")),
                  CityId = dr.GetInt32(dr.GetOrdinal("CityId")),
                  HeaderLetter = dr.IsDBNull(dr.GetOrdinal("HeaderLetter")) ? "" : dr.GetString(dr.GetOrdinal("HeaderLetter"))
               };
               ResultList.Add(model);
               model = null;
            }

         }
         return ResultList;
      }

      #endregion  县区

      #endregion ISysAreaInfo 成员

      #region ISysAreaInfo 成员


      public int? GetProvinceIdByName(string name)
      {
         string StrSql = string.Format(" select ID from tbl_SysProvince WHERE [Name]='{0}'", name);
         DbCommand cmd = _db.GetSqlStringCommand(StrSql);
         object o = DbHelper.GetSingle(cmd, _db);
         if (o != null)
         {
            return Convert.ToInt32(o);
         }
         return null;
      }

      public int? GetCityIdByName(string name)
      {
         string StrSql = string.Format(" select ID from tbl_SysCity WHERE [Name]='{0}'", name);
         DbCommand cmd = _db.GetSqlStringCommand(StrSql);
         object o = DbHelper.GetSingle(cmd, _db);
         if (o != null)
         {
            return Convert.ToInt32(o);
         }
         return null;
      }

      #endregion
   }
}
