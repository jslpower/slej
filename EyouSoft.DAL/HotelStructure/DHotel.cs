using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit.DAL;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit;
using EyouSoft.Model.HotelStructure.WebModel;
using EyouSoft.Model.SystemStructure;
using EyouSoft.Model.Enum.XianLuStructure;
using EyouSoft.DAL.SystemStructure;
using EyouSoft.Model.Enum;

namespace EyouSoft.DAL.HotelStructure
{
   public class DHotel : DALBase, EyouSoft.IDAL.HotelStructure.IHotel
   {

      #region
      const string SQL_UPDATE_SheZhiOrderStatus = "UPDATE [tbl_HotelOrder] SET [OrderState]=@Status WHERE [OrderId]=@OrderId ";

      #endregion
      #region 初始化db

      private Microsoft.Practices.EnterpriseLibrary.Data.Database _db = null;

      /// <summary>
      /// 初始化_db
      /// </summary>
      public DHotel()
      {
         _db = base.SystemStore;
      }

      #endregion

      #region 酒店

      /// <summary>
      /// 添加酒店
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>
      public bool AddHotel(EyouSoft.Model.HotelStructure.MHotel model)
      {
         DbCommand cmd = this._db.GetStoredProcCommand("proc_Hotel_Add");

         this._db.AddInParameter(cmd, "HotelId", DbType.AnsiStringFixedLength, model.HotelId);
         this._db.AddInParameter(cmd, "HotelName", DbType.String, model.HotelName);
         this._db.AddInParameter(cmd, "HotelNameEn", DbType.String, model.HotelNameEn);
         this._db.AddInParameter(cmd, "Latitude", DbType.String, model.Latitude);
         this._db.AddInParameter(cmd, "Longitude", DbType.String, model.Longitude);
         this._db.AddInParameter(cmd, "ServiceTel", DbType.String, model.ServiceTel);
         this._db.AddInParameter(cmd, "ProvinceId", DbType.Int32, model.ProvinceId);
         this._db.AddInParameter(cmd, "CityId", DbType.Int32, model.CityId);
         this._db.AddInParameter(cmd, "CountyId", DbType.Int32, model.CountyId);
         this._db.AddInParameter(cmd, "Address", DbType.String, model.Address);
         this._db.AddInParameter(cmd, "EnAddress", DbType.String, model.EnAddress);
         this._db.AddInParameter(cmd, "Star", DbType.Byte, (int)model.Star);
         this._db.AddInParameter(cmd, "PostalCode", DbType.String, model.PostalCode);
         this._db.AddInParameter(cmd, "OpenDate", DbType.String, model.OpenDate);
         this._db.AddInParameter(cmd, "Fitment", DbType.String, model.Fitment);
         this._db.AddInParameter(cmd, "RoomQuantity", DbType.Int32, model.RoomQuantity);
         this._db.AddInParameter(cmd, "Floor", DbType.String, model.Floor);
         this._db.AddInParameter(cmd, "LongDesc", DbType.String, model.LongDesc);
         this._db.AddInParameter(cmd, "Transport", DbType.String, model.Transport);
         this._db.AddInParameter(cmd, "AdditionalCost", DbType.String, model.AdditionalCost);
         this._db.AddInParameter(cmd, "Status", DbType.Byte, (int)model.Status);
         this._db.AddInParameter(cmd, "OperatorId", DbType.Int32, model.OperatorId);
         this._db.AddInParameter(cmd, "IsHot", DbType.AnsiStringFixedLength, model.IsHot == true ? 1 : 0);
         this._db.AddInParameter(cmd, "IsRecommend", DbType.AnsiStringFixedLength, model.IsRecommend == true ? 1 : 0);
         this._db.AddInParameter(cmd, "CityCode", DbType.String, model.CityCode);
         this._db.AddInParameter(cmd, "HotelLandMark", DbType.Xml, CreateXml(model.HotelId, model.MarkList));
         this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
         _db.AddInParameter(cmd, "Mobile", DbType.String, model.Mobile);
         this._db.AddInParameter(cmd, "JieSuanType", DbType.AnsiStringFixedLength, model.JieSuanType ? 1 : 0);

         DbHelper.RunProcedureWithResult(cmd, this._db);
         return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result")) > 0 ? true : false;

      }

      /// <summary>
      /// 修改酒店
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>
      public bool UpdateHotel(EyouSoft.Model.HotelStructure.MHotel model)
      {
         DbCommand cmd = this._db.GetStoredProcCommand("proc_Hotel_Update");

         this._db.AddInParameter(cmd, "HotelId", DbType.AnsiStringFixedLength, model.HotelId);
         this._db.AddInParameter(cmd, "HotelName", DbType.String, model.HotelName);
         this._db.AddInParameter(cmd, "HotelNameEn", DbType.String, model.HotelNameEn);
         this._db.AddInParameter(cmd, "Latitude", DbType.String, model.Latitude);
         this._db.AddInParameter(cmd, "Longitude", DbType.String, model.Longitude);
         this._db.AddInParameter(cmd, "ServiceTel", DbType.String, model.ServiceTel);
         this._db.AddInParameter(cmd, "ProvinceId", DbType.Int32, model.ProvinceId);
         this._db.AddInParameter(cmd, "CityId", DbType.Int32, model.CityId);
         this._db.AddInParameter(cmd, "CountyId", DbType.Int32, model.CountyId);
         this._db.AddInParameter(cmd, "Address", DbType.String, model.Address);
         this._db.AddInParameter(cmd, "EnAddress", DbType.String, model.EnAddress);
         this._db.AddInParameter(cmd, "Star", DbType.Byte, (int)model.Star);
         this._db.AddInParameter(cmd, "PostalCode", DbType.String, model.PostalCode);
         this._db.AddInParameter(cmd, "OpenDate", DbType.String, model.OpenDate);
         this._db.AddInParameter(cmd, "Fitment", DbType.String, model.Fitment);
         this._db.AddInParameter(cmd, "RoomQuantity", DbType.Int32, model.RoomQuantity);
         this._db.AddInParameter(cmd, "Floor", DbType.String, model.Floor);
         this._db.AddInParameter(cmd, "LongDesc", DbType.String, model.LongDesc);
         this._db.AddInParameter(cmd, "Transport", DbType.String, model.Transport);
         this._db.AddInParameter(cmd, "AdditionalCost", DbType.String, model.AdditionalCost);
         this._db.AddInParameter(cmd, "Status", DbType.Byte, (int)model.Status);
         this._db.AddInParameter(cmd, "IsHot", DbType.AnsiStringFixedLength, model.IsHot ? 1 : 0);
         this._db.AddInParameter(cmd, "IsRecommend", DbType.AnsiStringFixedLength, model.IsRecommend ? 1 : 0);
         this._db.AddInParameter(cmd, "CityCode", DbType.String, model.CityCode);
         this._db.AddInParameter(cmd, "HotelLandMark", DbType.Xml, CreateXml(model.HotelId, model.MarkList));
         this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
         _db.AddInParameter(cmd, "Mobile", DbType.String, model.Mobile);
         this._db.AddInParameter(cmd, "JieSuanType", DbType.AnsiStringFixedLength, model.JieSuanType ? 1 : 0);

         DbHelper.RunProcedureWithResult(cmd, this._db);
         return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result")) > 0 ? true : false;
      }

      /// <summary>
      /// 删除酒店
      /// </summary>
      /// <param name="HotelId"></param>
      /// <returns></returns>
      public bool DeleteHotel(string HotelId)
      {
         DbCommand cmd = this._db.GetStoredProcCommand("proc_Hotel_Delete");

         this._db.AddInParameter(cmd, "HotelId", DbType.AnsiStringFixedLength, HotelId);
         this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);

         DbHelper.RunProcedureWithResult(cmd, this._db);
         return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result")) > 0 ? true : false;
      }

      /// <summary>
      /// 获取实体
      /// </summary>
      /// <param name="hotelId"></param>
      /// <returns></returns>
      public EyouSoft.Model.HotelStructure.MHotel GetModel(string hotelId)
      {
         EyouSoft.Model.HotelStructure.MHotel model = null;

         StringBuilder query = new StringBuilder();

         query.Append(" SELECT ");
         query.Append("HotelId,HotelCode,HotelName,HotelNameEn,Latitude,Longitude,JieSuanType");
         query.Append(",ServiceTel,ProvinceId,CityId,CountyId,Address,EnAddress");
         query.Append(",Star,PostalCode,OpenDate,Fitment,RoomQuantity,Floor,LongDesc");
         query.Append(",Transport,AdditionalCost,Status,IssueTime,IsHot,IsRecommend,CityCode,HotelRoomType,HotelImg,HotelLandMark,Mobile");
         query.Append(" FROM view_Hotel");
         query.Append(" Where HotelId=@HotelId");

         DbCommand cmd = this._db.GetSqlStringCommand(query.ToString());
         this._db.AddInParameter(cmd, "HotelId", DbType.AnsiStringFixedLength, hotelId);

         using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
         {
            while (dr.Read())
            {
               model = new EyouSoft.Model.HotelStructure.MHotel();
               model.HotelId = dr.GetString(dr.GetOrdinal("HotelId"));
               model.HotelCode = dr.GetString(dr.GetOrdinal("HotelCode"));
               model.HotelName = !dr.IsDBNull(dr.GetOrdinal("HotelName")) ? dr.GetString(dr.GetOrdinal("HotelName")) : null;
               model.HotelNameEn = !dr.IsDBNull(dr.GetOrdinal("Latitude")) ? dr.GetString(dr.GetOrdinal("HotelNameEn")) : null;
               model.Latitude = !dr.IsDBNull(dr.GetOrdinal("Latitude")) ? dr.GetString(dr.GetOrdinal("Latitude")) : null;
               model.Longitude = !dr.IsDBNull(dr.GetOrdinal("Longitude")) ? dr.GetString(dr.GetOrdinal("Longitude")) : null;
               model.ServiceTel = !dr.IsDBNull(dr.GetOrdinal("ServiceTel")) ? dr.GetString(dr.GetOrdinal("ServiceTel")) : null;
               model.ProvinceId = dr.GetInt32(dr.GetOrdinal("ProvinceId"));
               model.CityId = dr.GetInt32(dr.GetOrdinal("CityId"));
               model.CountyId = dr.GetInt32(dr.GetOrdinal("CountyId"));
               model.Address = !dr.IsDBNull(dr.GetOrdinal("Address")) ? dr.GetString(dr.GetOrdinal("Address")) : null;
               model.EnAddress = !dr.IsDBNull(dr.GetOrdinal("EnAddress")) ? dr.GetString(dr.GetOrdinal("EnAddress")) : null;
               model.Star = (EyouSoft.Model.Enum.HotelStar?)dr.GetByte(dr.GetOrdinal("Star"));
               model.PostalCode = !dr.IsDBNull(dr.GetOrdinal("PostalCode")) ? dr.GetString(dr.GetOrdinal("PostalCode")) : null;
               model.OpenDate = !dr.IsDBNull(dr.GetOrdinal("OpenDate")) ? dr.GetString(dr.GetOrdinal("OpenDate")) : null;
               model.Fitment = !dr.IsDBNull(dr.GetOrdinal("Fitment")) ? dr.GetString(dr.GetOrdinal("Fitment")) : null;
               model.RoomQuantity = dr.GetInt32(dr.GetOrdinal("RoomQuantity"));
               model.Floor = !dr.IsDBNull(dr.GetOrdinal("Floor")) ? dr.GetString(dr.GetOrdinal("Floor")) : "";
               model.LongDesc = !dr.IsDBNull(dr.GetOrdinal("LongDesc")) ? dr.GetString(dr.GetOrdinal("LongDesc")) : null;
               model.Transport = !dr.IsDBNull(dr.GetOrdinal("Transport")) ? dr.GetString(dr.GetOrdinal("Transport")) : null;
               model.AdditionalCost = !dr.IsDBNull(dr.GetOrdinal("AdditionalCost")) ? dr.GetString(dr.GetOrdinal("AdditionalCost")) : null;
               model.Status = (EyouSoft.Model.Enum.HotelStatus)dr.GetByte(dr.GetOrdinal("Status"));
               model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
               model.IsHot = dr.GetString(dr.GetOrdinal("IsHot")) == "1";
               model.IsRecommend = dr.GetString(dr.GetOrdinal("IsRecommend")) == "1";
               model.CityCode = dr.IsDBNull(dr.GetOrdinal("CityCode"))
                                    ? string.Empty
                                    : dr.GetString(dr.GetOrdinal("CityCode"));


               model.ImgList = !dr.IsDBNull(dr.GetOrdinal("HotelImg")) ? (List<EyouSoft.Model.HotelStructure.MHotelImg>)GetHotelImgList(dr.GetString(dr.GetOrdinal("HotelImg"))) : null;
               model.MarkList = !dr.IsDBNull(dr.GetOrdinal("HotelLandMark")) ? (List<EyouSoft.Model.HotelStructure.MHotelLandMark>)GetHotelLandMarkList(dr.GetString(dr.GetOrdinal("HotelLandMark"))) : null;
               model.RoomTypeList = !dr.IsDBNull(dr.GetOrdinal("HotelRoomType")) ? (List<EyouSoft.Model.HotelStructure.MHotelRoomType>)GetHotelRoomTypeList(dr.GetString(dr.GetOrdinal("HotelRoomType"))) : null;
               model.Mobile = dr["Mobile"].ToString();
               model.JieSuanType = dr.GetString(dr.GetOrdinal("JieSuanType")) == "1";
            }
         }

         return model;

      }

      /// <summary>
      /// 分页获取酒店集合
      /// </summary>
      /// <param name="pageIndex"></param>
      /// <param name="pageSize"></param>
      /// <param name="recordCount"></param>
      /// <param name="search"></param>
      /// <returns></returns>
      public IList<Model.HotelStructure.MHotel> GetHotelListByPublic(int pageIndex, int pageSize, ref int recordCount
          , Model.HotelStructure.MHotelSearch search)
      {
         var strTableName = new StringBuilder();
         var strWhere = new StringBuilder();
         var strSonWhere = new StringBuilder();
         var files = new StringBuilder();
         string orderBy = " IssueTime desc ";

         #region sql拼接

         #region where条件构造

         if (search != null)
         {
            if (!string.IsNullOrEmpty(search.HotelName))
            {
               strWhere.AppendFormat(" and A.HotelName like '%{0}%'  ", Utils.ToSqlLike(search.HotelName));
            }
            //if (!string.IsNullOrEmpty(search.HotelCityCode))
            //{
            //    strWhere.AppendFormat(" and A.CityCode like '%{0}%'  ", Utils.ToSqlLike(search.HotelCityCode));
            //}
            if (search.CountyId > 0)
            {
               strWhere.AppendFormat(" and A.CountyId ={0} ", search.CountyId);
            }
            else if (search.CityId > 0)
            {
               strWhere.AppendFormat(" and A.CityId ={0} ", search.CityId);
            }
            else if (search.ProvinceId > 0)
            {
               strWhere.AppendFormat(" and A.ProvinceId ={0} ", search.ProvinceId);
            }
            else
            {
               if (!string.IsNullOrEmpty(search.HotelCityCode) && EyouSoft.Toolkit.Utils.GetInt(search.HotelCityCode) > 0)
               {
                  strWhere.AppendFormat(" and A.CityId ={0} ", search.HotelCityCode);
               }
            }

            if (search.HotelStar.HasValue)
            {
               strWhere.AppendFormat(" and A.Star = {0} ", (int)search.HotelStar.Value);
            }
            if (search.HotelMarkId > 0)
            {
               strWhere.AppendFormat(
                   " and exists (select 1 from tbl_HotelLandMark as hlm where hlm.HotelId = A.HotelId and hlm.LandMarkId = {0}) ",
                   search.HotelMarkId);
            }
            if (search.IsHot.HasValue)
            {
               strWhere.AppendFormat(" and A.IsHot = '{0}' ", this.GetBooleanToStr(search.IsHot.Value));
            }
            if (search.IsRecommend.HasValue)
            {
               strWhere.AppendFormat(" and A.IsRecommend = '{0}' ", this.GetBooleanToStr(search.IsRecommend.Value));
            }
            if (search.HotelStatus.HasValue)
            {
               strWhere.AppendFormat(" and A.Status = {0} ", (int)search.HotelStatus.Value);
            }

            //房型价格查询
            if (search.InDate.HasValue)
            {
               strSonWhere.AppendFormat(" and datediff(day,C.StartDate,'{0}')>=0  ", search.InDate.Value.ToShortDateString());
            }
            else
            {
               strSonWhere.Append(" and datediff(day,C.StartDate,getdate())>=0  ");
            }
            if (search.OutDate.HasValue)
            {
               strSonWhere.AppendFormat(" and datediff(day,C.EndDate,'{0}')<=0  ", search.OutDate.Value.ToShortDateString());
            }
            else
            {
               strSonWhere.Append(" and datediff(day,C.EndDate,getdate())<=0 ");
            }
            if (search.MinPrice > 0)
            {
               strSonWhere.AppendFormat(" and C.AmountPrice >= {0} ", search.MinPrice);
            }
            if (search.MaxPrice > 0)
            {
               strSonWhere.AppendFormat(" and C.AmountPrice <= {0} ", search.MaxPrice);
            }

            switch (search.OrderIndex)
            {
               case 1:
                  orderBy = " MinPrice asc ";
                  break;
               case 2:
                  orderBy = " MinPrice desc ";
                  break;
               case 3:
                  orderBy = " Star asc ";
                  break;
               case 4:
                  orderBy = " Star desc ";
                  break;
               default:
                  orderBy = " IssueTime desc ";
                  break;
            }
         }

         #endregion

         #region 派生表构造

         strTableName.AppendLine(@" SELECT A.HotelId,A.HotelCode,A.HotelName,A.HotelNameEn,A.Latitude,A.Longitude,A.ServiceTel,A.ProvinceId
                            ,A.CityId,A.CountyId,A.Address,A.EnAddress,A.Star,A.PostalCode,A.OpenDate,A.Fitment,A.RoomQuantity,A.Floor,A.LongDesc
                            ,A.Transport,A.AdditionalCost,A.Status,A.IssueTime,A.IsDelete,A.IsHot,A.IsRecommend,A.CityCode ");
         //房型
         strTableName.AppendLine(
             @" ,(SELECT B.RoomTypeId,B.HotelId,B.RoomName,B.TotalNumber,B.RoomType,B.RoomArea,B.Floor,B.BedType,B.BedHeight,B.BedWidth,B.MaxGuestNum,B.IsSmoking,B.IsInternet,B.IsInternetPrice,B.Orientation,B.IsBreakfast,B.IsBreakfastPrice,B.IsWindow,B.IsAddBed,B.IsAddBedPrice,B.Payment,B.[Desc],B.IssueTime,B.OperatorId,B.SortId,B.RoomStatus,C.AmountPrice,C.PreferentialPrice,C.SettlementPrice ");
         strTableName.AppendLine(@" FROM tbl_HotelRoomType as B left join tbl_HotelRoomRate as C ");
         //补充房型条件
         strTableName.AppendFormat(@" on B.RoomTypeId = C.RoomTypeId {0} ", strSonWhere.ToString());
         strTableName.AppendLine();
         strTableName.AppendFormat(
             @" where B.HotelId=A.HotelId and B.IsDelete='0' and B.RoomStatus = {0}  for xml raw,root('Root')) as HotelRoomType ",
             (int)Model.Enum.RoomStatus.正常);
         //酒店图片
         strTableName.AppendLine(
             @" ,(SELECT D.ImgId,D.HotelId,D.ImgCategory,D.FilePath,D.[Desc],D.IssueTime,D.OperatorId FROM tbl_HotelImg as D where D.HotelId=A.HotelId for xml raw,root('Root') ) as HotelImg ");
         //酒店地标
         strTableName.AppendLine(@" ,(select E.HotelId,E.LandMarkId,(select Por from tbl_HotelLandMarks where Id=E.LandMarkId) as Por from tbl_HotelLandMark as E where E.HotelId=A.HotelId for xml raw,root('Root')) as HotelLandMark ");
         //酒店所有房型价格最小值
         strTableName.AppendFormat(
             " ,(select IsNull(Min(AmountPrice),0) from tbl_HotelRoomRate as hrr where hrr.HotelId = A.HotelId and hrr.AmountPrice > 0 {0} ) as MinPrice ",
             strSonWhere.ToString().Replace("C.", "hrr."));

         strTableName.AppendLine(@" FROM tbl_Hotel as A  where A.IsDelete='0' ");

         strTableName.AppendLine(strWhere.ToString());

         #endregion

         files.AppendLine(" * ");

         #endregion

         var list = new List<Model.HotelStructure.MHotel>();
         using (IDataReader dr = DbHelper.ExecuteReader2(this._db, pageSize, pageIndex, ref recordCount, strTableName.ToString()
             , files.ToString(), string.Empty, orderBy, null))
         {
            while (dr.Read())
            {
               #region 实体赋值

               var model = new Model.HotelStructure.MHotel
                   {
                      HotelId = dr.IsDBNull(dr.GetOrdinal("HotelId")) ? string.Empty : dr.GetString(dr.GetOrdinal("HotelId")),
                      HotelCode = dr.IsDBNull(dr.GetOrdinal("HotelCode")) ? string.Empty : dr.GetString(dr.GetOrdinal("HotelCode")),
                      HotelName =
                          !dr.IsDBNull(dr.GetOrdinal("HotelName")) ? dr.GetString(dr.GetOrdinal("HotelName")) : null,
                      HotelNameEn =
                          !dr.IsDBNull(dr.GetOrdinal("Latitude"))
                              ? dr.GetString(dr.GetOrdinal("HotelNameEn"))
                              : null,
                      Latitude =
                          !dr.IsDBNull(dr.GetOrdinal("Latitude")) ? dr.GetString(dr.GetOrdinal("Latitude")) : null,
                      Longitude =
                          !dr.IsDBNull(dr.GetOrdinal("Longitude")) ? dr.GetString(dr.GetOrdinal("Longitude")) : null,
                      ServiceTel =
                          !dr.IsDBNull(dr.GetOrdinal("ServiceTel"))
                              ? dr.GetString(dr.GetOrdinal("ServiceTel"))
                              : null,
                      ProvinceId = dr.GetInt32(dr.GetOrdinal("ProvinceId")),
                      CityId = dr.GetInt32(dr.GetOrdinal("CityId")),
                      CountyId = dr.GetInt32(dr.GetOrdinal("CountyId")),
                      Address =
                          !dr.IsDBNull(dr.GetOrdinal("Address")) ? dr.GetString(dr.GetOrdinal("Address")) : null,
                      EnAddress =
                          !dr.IsDBNull(dr.GetOrdinal("EnAddress")) ? dr.GetString(dr.GetOrdinal("EnAddress")) : null,
                      Star = (Model.Enum.HotelStar?)dr.GetByte(dr.GetOrdinal("Star")),
                      PostalCode =
                          !dr.IsDBNull(dr.GetOrdinal("PostalCode"))
                              ? dr.GetString(dr.GetOrdinal("PostalCode"))
                              : null,
                      OpenDate =
                          !dr.IsDBNull(dr.GetOrdinal("OpenDate")) ? dr.GetString(dr.GetOrdinal("OpenDate")) : null,
                      Fitment =
                          !dr.IsDBNull(dr.GetOrdinal("Fitment")) ? dr.GetString(dr.GetOrdinal("Fitment")) : null,
                      RoomQuantity = dr.GetInt32(dr.GetOrdinal("RoomQuantity")),
                      Floor = dr.GetString(dr.GetOrdinal("Floor")),
                      LongDesc =
                          !dr.IsDBNull(dr.GetOrdinal("LongDesc")) ? dr.GetString(dr.GetOrdinal("LongDesc")) : null,
                      Transport =
                          !dr.IsDBNull(dr.GetOrdinal("Transport")) ? dr.GetString(dr.GetOrdinal("Transport")) : null,
                      AdditionalCost =
                          !dr.IsDBNull(dr.GetOrdinal("AdditionalCost"))
                              ? dr.GetString(dr.GetOrdinal("AdditionalCost"))
                              : null,
                      Status = (Model.Enum.HotelStatus)dr.GetByte(dr.GetOrdinal("Status")),
                      IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime")),
                      IsHot = dr.GetString(dr.GetOrdinal("IsHot")) == "1",
                      IsRecommend = dr.GetString(dr.GetOrdinal("IsRecommend")) == "1",
                      ImgList =
                          !dr.IsDBNull(dr.GetOrdinal("HotelImg"))
                              ? (List<EyouSoft.Model.HotelStructure.MHotelImg>)this.GetHotelImgList(dr.GetString(dr.GetOrdinal("HotelImg")))
                              : null,
                      MarkList =
                          !dr.IsDBNull(dr.GetOrdinal("HotelLandMark"))
                              ? (List<EyouSoft.Model.HotelStructure.MHotelLandMark>)this.GetHotelLandMarkList(dr.GetString(dr.GetOrdinal("HotelLandMark")))
                              : null,
                      RoomTypeList =
                          !dr.IsDBNull(dr.GetOrdinal("HotelRoomType"))
                              ? (List<EyouSoft.Model.HotelStructure.MHotelRoomType>)this.GetHotelRoomTypeList(dr.GetString(dr.GetOrdinal("HotelRoomType")))
                              : null
                   };

               #endregion

               list.Add(model);
            }
         }

         return list;
      }

      /// <summary>
      /// 分页获取酒店集合
      /// </summary>
      /// <param name="pageIndex"></param>
      /// <param name="pageSize"></param>
      /// <param name="recordCount"></param>
      /// <param name="search"></param>
      /// <returns></returns>
      public IList<EyouSoft.Model.HotelStructure.MHotel> GetHotelList(int pageIndex, int pageSize, ref int recordCount, EyouSoft.Model.HotelStructure.MHotelSearch search)
      {

         IList<EyouSoft.Model.HotelStructure.MHotel> list = new List<EyouSoft.Model.HotelStructure.MHotel>();

         string tableName = "view_Hotel2";

         string orderByString = " IssueTime desc ";

         StringBuilder fileds = new StringBuilder();
         fileds.Append("HotelId,HotelCode,HotelName,HotelNameEn,Latitude,Longitude,InterfaceId");
         fileds.Append(",ServiceTel,ProvinceId,CityId,CountyId,Address,EnAddress");
         fileds.Append(",Star,PostalCode,OpenDate,Fitment,RoomQuantity,Floor,LongDesc");
         fileds.Append(",Transport,AdditionalCost,Status,IssueTime,IsHot,IsRecommend,CityCode,HotelRoomType,HotelImg,HotelLandMark,IsIndex");

         StringBuilder query = new StringBuilder(" IsDelete='0' ");

         if (search != null)
         {
            if (!string.IsNullOrEmpty(search.HotelName))
            {
               query.AppendFormat(" and HotelName like '%{0}%'", search.HotelName);
            }

            if (!string.IsNullOrEmpty(search.HotelCode))
            {
               query.AppendFormat(" and HotelCode like '%{0}%'", search.HotelCode);
            }

            if (search.IsHot.HasValue)
            {
               query.AppendFormat(" and IsHot='{0}' ", search.IsHot.Value ? "1" : "0");
            }

            if (search.IsRecommend.HasValue)
            {
               query.AppendFormat(" and IsRecommend='{0}' ", search.IsRecommend.Value ? "1" : "0");
            }

            if (search.HotelStar.HasValue)
            {
               query.AppendFormat(" and Status={0} ", (int)search.HotelStatus.Value);
            }

            //if (!string.IsNullOrEmpty(search.CityCode))
            //{
            //    query.AppendFormat(" and CityCode like '%{0}%'", search.CityCode);
            //}

            if (search.CountyId > 0)
            {
               query.AppendFormat(" and CountyId ={0} ", search.CountyId);
            }
            else if (search.CityId > 0)
            {
               query.AppendFormat(" and CityId ={0} ", search.CityId);
            }
            else if (search.ProvinceId > 0)
            {
               query.AppendFormat(" and ProvinceId ={0} ", search.ProvinceId);
            }
            else
            {
               if (!string.IsNullOrEmpty(search.CityCode) && EyouSoft.Toolkit.Utils.GetInt(search.CityCode) > 0)
               {
                  query.AppendFormat(" and CityId ={0} ", search.CityCode);
               }
            }

         }

         using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref recordCount, tableName, fileds.ToString(), query.ToString(), orderByString, null))
         {
            while (dr.Read())
            {
               EyouSoft.Model.HotelStructure.MHotel model = new EyouSoft.Model.HotelStructure.MHotel();
               model.HotelId = dr.GetString(dr.GetOrdinal("HotelId"));
               model.HotelCode = dr.GetString(dr.GetOrdinal("HotelCode"));
               model.HotelName = !dr.IsDBNull(dr.GetOrdinal("HotelName")) ? dr.GetString(dr.GetOrdinal("HotelName")) : null;
               model.HotelNameEn = !dr.IsDBNull(dr.GetOrdinal("Latitude")) ? dr.GetString(dr.GetOrdinal("HotelNameEn")) : null;
               model.Latitude = !dr.IsDBNull(dr.GetOrdinal("Latitude")) ? dr.GetString(dr.GetOrdinal("Latitude")) : null;
               model.Longitude = !dr.IsDBNull(dr.GetOrdinal("Longitude")) ? dr.GetString(dr.GetOrdinal("Longitude")) : null;
               model.ServiceTel = !dr.IsDBNull(dr.GetOrdinal("ServiceTel")) ? dr.GetString(dr.GetOrdinal("ServiceTel")) : null;
               model.ProvinceId = dr.GetInt32(dr.GetOrdinal("ProvinceId"));
               model.CityId = dr.GetInt32(dr.GetOrdinal("CityId"));
               model.CountyId = dr.GetInt32(dr.GetOrdinal("CountyId"));
               model.Address = !dr.IsDBNull(dr.GetOrdinal("Address")) ? dr.GetString(dr.GetOrdinal("Address")) : null;
               model.EnAddress = !dr.IsDBNull(dr.GetOrdinal("EnAddress")) ? dr.GetString(dr.GetOrdinal("EnAddress")) : null;
               model.Star = (EyouSoft.Model.Enum.HotelStar?)dr.GetByte(dr.GetOrdinal("Star"));
               model.PostalCode = !dr.IsDBNull(dr.GetOrdinal("PostalCode")) ? dr.GetString(dr.GetOrdinal("PostalCode")) : null;
               model.OpenDate = !dr.IsDBNull(dr.GetOrdinal("OpenDate")) ? dr.GetString(dr.GetOrdinal("OpenDate")) : null;
               model.Fitment = !dr.IsDBNull(dr.GetOrdinal("Fitment")) ? dr.GetString(dr.GetOrdinal("Fitment")) : null;
               model.RoomQuantity = dr.GetInt32(dr.GetOrdinal("RoomQuantity"));
               model.Floor = !dr.IsDBNull(dr.GetOrdinal("Floor")) ? dr.GetString(dr.GetOrdinal("Floor")) : "";
               model.LongDesc = !dr.IsDBNull(dr.GetOrdinal("LongDesc")) ? dr.GetString(dr.GetOrdinal("LongDesc")) : null;
               model.Transport = !dr.IsDBNull(dr.GetOrdinal("Transport")) ? dr.GetString(dr.GetOrdinal("Transport")) : null;
               model.AdditionalCost = !dr.IsDBNull(dr.GetOrdinal("AdditionalCost")) ? dr.GetString(dr.GetOrdinal("AdditionalCost")) : null;
               model.Status = (EyouSoft.Model.Enum.HotelStatus)dr.GetByte(dr.GetOrdinal("Status"));
               model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
               model.IsHot = dr.GetString(dr.GetOrdinal("IsHot")) == "1";
               model.IsRecommend = dr.GetString(dr.GetOrdinal("IsRecommend")) == "1";
               model.InterfaceId = !dr.IsDBNull(dr.GetOrdinal("InterfaceId")) ? dr.GetString(dr.GetOrdinal("InterfaceId")):"";
               model.ImgList = !dr.IsDBNull(dr.GetOrdinal("HotelImg")) ? (List<EyouSoft.Model.HotelStructure.MHotelImg>)GetHotelImgList(dr.GetString(dr.GetOrdinal("HotelImg"))) : null;
               model.MarkList = !dr.IsDBNull(dr.GetOrdinal("HotelLandMark")) ? (List<EyouSoft.Model.HotelStructure.MHotelLandMark>)GetHotelLandMarkList(dr.GetString(dr.GetOrdinal("HotelLandMark"))) : null;
               model.RoomTypeList = !dr.IsDBNull(dr.GetOrdinal("HotelRoomType")) ? (List<EyouSoft.Model.HotelStructure.MHotelRoomType>)GetHotelRoomTypeList(dr.GetString(dr.GetOrdinal("HotelRoomType"))) : null;
               model.IsIndex = (XianLuZT)dr.GetByte(dr.GetOrdinal("IsIndex"));

               list.Add(model);
            }
         }
         return list;
      }
      /// <summary>
      /// 获取推荐酒店信息
      /// </summary>
      /// <param name="top">top条数，小于等于0取所有</param>
      /// <param name="search">查询实体</param>
      /// <returns></returns>
      public IList<MHotelSearchModel2> GetHotelList(int top)
      {
         if (top <= 0)
         {
            top = 4;
         }
         if (top > 10)
         {
            top = 10;
         }
         string citycode = "HGH";
         string sql = "select top " + top + " a.hotelName,a.hotelid,b.PreferentialPrice,b.SettlementPrice from tbl_hotel as a inner join tbl_HotelRoomRate as b on (a.hotelid=b.hotelid) where a.ProductSort>0 and CityCode='" + citycode + "' and isHot='1' and IsRecommend='1' and  b.roomrateid=(select top 1 roomrateid from tbl_HotelRoomRate where hotelid=a.hotelid and enddate>='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and startdate<='" + DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "') order by ProductSort Asc";

         DbCommand dc = _db.GetSqlStringCommand(sql);

         var list = new List<MHotelSearchModel2>();

         MFeeSettings feeSetting = new DFeeSettings().Get(x => x.LeiBie == EyouSoft.Model.Enum.FeeTypes.酒店);
         using (IDataReader dr = DbHelper.ExecuteReader(dc, _db))
         {
            while (dr.Read())
            {
               MHotelSearchModel2 model = new MHotelSearchModel2();
               model.HotelName = !dr.IsDBNull(dr.GetOrdinal("HotelName")) ? dr.GetString(dr.GetOrdinal("HotelName")) : string.Empty;
               model.HotelId = !dr.IsDBNull(dr.GetOrdinal("HotelId")) ? dr.GetString(dr.GetOrdinal("HotelId")) : string.Empty;
               model.FeeSetting = feeSetting;
               model.PriceInfo = new EyouSoft.Model.HotelStructure.MHotelRoomRate2
               {
                  PreferentialPrice = Convert.ToDecimal(dr["PreferentialPrice"]),
                  SettlementPrice = Convert.ToDecimal(dr["SettlementPrice"]),
               };
               list.Add(model);
            }
         }
         return list;

      }
      /// <summary>
      /// 获取推荐酒店房间结算价
      /// </summary>
      /// <returns></returns>
      public decimal GetRoomSetPrice(string hotelid, decimal jiage)
      {
         var strSql = new StringBuilder(" select ");
         strSql.Append(" SettlementPrice from tbl_HotelRoomRate where AmountPrice ='" + jiage + "' and EndDate>getdate() and HotelId='" + hotelid + "'");

         DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());

         decimal setprice = 0;
         using (IDataReader dr = DbHelper.ExecuteReader(dc, _db))
         {
            while (dr.Read())
            {
               setprice = dr.GetDecimal(dr.GetOrdinal("SettlementPrice"));
            }
         }

         return setprice;

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
      /// 修改状态
      /// </summary>
      public int UpdateState(string Id, EyouSoft.Model.Enum.XianLuStructure.XianLuZT state)
      {
          string sql = "update tbl_Hotel set IsIndex=@IsIndex where HotelId=@HotelId";
          DbCommand cmd = this._db.GetSqlStringCommand(sql);

          this._db.AddInParameter(cmd, "HotelId", DbType.String, Id);
          this._db.AddInParameter(cmd, "IsIndex", DbType.Byte, (int)state);

          return DbHelper.ExecuteSql(cmd, this._db);
      }
      #endregion

      #region 酒店图片

      /// <summary>
      /// 添加酒店图片
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>
      public bool AddHotelImg(EyouSoft.Model.HotelStructure.MHotelImg model)
      {
         StringBuilder strSql = new StringBuilder();
         strSql.Append("insert into tbl_HotelImg(");
         strSql.Append("HotelId,ImgCategory,FilePath,[Desc],IssueTime,OperatorId");
         strSql.Append(") values (");
         strSql.Append("@HotelId,@ImgCategory,@FilePath,@Desc,getdate(),@OperatorId");
         strSql.Append(") ");


         DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
         this._db.AddInParameter(cmd, "HotelId", DbType.AnsiStringFixedLength, model.HotelId);
         this._db.AddInParameter(cmd, "ImgCategory", DbType.Byte, (int)model.ImgCategory);
         this._db.AddInParameter(cmd, "FilePath", DbType.String, model.FilePath);
         this._db.AddInParameter(cmd, "Desc", DbType.String, model.Desc);
         this._db.AddInParameter(cmd, "OperatorId", DbType.Int32, model.OperatorId);

         return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;


      }
      /// <summary>
      /// 批量添加酒店图片
      /// </summary>
      /// <param name="HotelId"></param>
      /// <param name="list"></param>
      /// <returns></returns>
      public bool AddHotelImg(string HotelId, IList<EyouSoft.Model.HotelStructure.MHotelImg> list)
      {

         DbCommand cmd = this._db.GetStoredProcCommand("proc_HotelImg_Add");
         this._db.AddInParameter(cmd, "HotelImg", DbType.Xml, CreateXml(HotelId, list));
         this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);

         DbHelper.RunProcedureWithResult(cmd, this._db);
         return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result")) > 0 ? true : false;

      }

      /// <summary>
      /// 修改酒店图片
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>
      public bool UpdateHotelImg(EyouSoft.Model.HotelStructure.MHotelImg model)
      {
         StringBuilder strSql = new StringBuilder();
         strSql.Append("update tbl_HotelImg set ");

         strSql.Append(" HotelId = @HotelId , ");
         strSql.Append(" ImgCategory = @ImgCategory , ");
         strSql.Append(" FilePath = @FilePath , ");
         strSql.Append(" [Desc] = @Desc  ");
         strSql.Append(" where ImgId=@ImgId ");


         DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
         this._db.AddInParameter(cmd, "ImgId", DbType.Int32, model.ImgId);
         this._db.AddInParameter(cmd, "HotelId", DbType.AnsiStringFixedLength, model.HotelId);
         this._db.AddInParameter(cmd, "ImgCategory", DbType.Byte, (int)model.ImgCategory);
         this._db.AddInParameter(cmd, "FilePath", DbType.String, model.FilePath);
         this._db.AddInParameter(cmd, "Desc", DbType.String, model.Desc);

         return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
      }

      /// <summary>
      /// 删除酒店图片
      /// </summary>
      /// <param name="ImgId"></param>
      /// <returns></returns>
      public bool DeleteHotelImg(int ImgId)
      {
         string sql = " delete from tbl_HotelImg where ImgId=@ImgId ";
         DbCommand cmd = this._db.GetSqlStringCommand(sql);

         this._db.AddInParameter(cmd, "ImgId", DbType.Int32, ImgId);

         return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;
      }

      /// <summary>
      /// 获取酒店图片的实体
      /// </summary>
      /// <param name="ImgId"></param>
      /// <returns></returns>
      public EyouSoft.Model.HotelStructure.MHotelImg GetHotelImgModel(int ImgId)
      {
         EyouSoft.Model.HotelStructure.MHotelImg model = null;

         StringBuilder strSql = new StringBuilder();
         strSql.Append("select ImgId, HotelId, ImgCategory, FilePath, [Desc], IssueTime, OperatorId  ");
         strSql.Append("  from tbl_HotelImg ");
         strSql.Append(" where ImgId=@ImgId");

         DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
         this._db.AddInParameter(cmd, "ImgId", DbType.Int32, ImgId);

         using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
         {

            while (dr.Read())
            {
               model = new EyouSoft.Model.HotelStructure.MHotelImg();
               model.ImgId = dr.GetInt32(dr.GetOrdinal("ImgId"));
               model.HotelId = dr.GetString(dr.GetOrdinal("HotelId"));
               model.ImgCategory = (EyouSoft.Model.Enum.HotelImgType)dr.GetByte(dr.GetOrdinal("ImgCategory"));
               model.FilePath = !dr.IsDBNull(dr.GetOrdinal("FilePath")) ? dr.GetString(dr.GetOrdinal("FilePath")) : null;
               model.Desc = dr.GetString(dr.GetOrdinal("Desc"));
               model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
               model.OperatorId = dr.GetString(dr.GetOrdinal("OperatorId"));
            }
         }

         return model;

      }

      /// <summary>
      /// 获取酒店图片的集合
      /// </summary>
      /// <param name="HotelId"></param>
      /// <returns></returns>
      public IList<EyouSoft.Model.HotelStructure.MHotelImg> GetHotelImgListByHotelId(string HotelId)
      {
         IList<EyouSoft.Model.HotelStructure.MHotelImg> list = new List<EyouSoft.Model.HotelStructure.MHotelImg>();

         StringBuilder strSql = new StringBuilder();
         strSql.Append("select ImgId, HotelId, ImgCategory, FilePath, [Desc], IssueTime, OperatorId  ");
         strSql.Append("  from tbl_HotelImg ");
         strSql.Append(" where HotelId=@HotelId");

         DbCommand cmd = this._db.GetSqlStringCommand(strSql.ToString());
         this._db.AddInParameter(cmd, "HotelId", DbType.Int32, HotelId);

         using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
         {
            while (dr.Read())
            {
               EyouSoft.Model.HotelStructure.MHotelImg model = new EyouSoft.Model.HotelStructure.MHotelImg();
               model.ImgId = dr.GetInt32(dr.GetOrdinal("ImgId"));
               model.HotelId = dr.GetString(dr.GetOrdinal("HotelId"));
               model.ImgCategory = (EyouSoft.Model.Enum.HotelImgType)dr.GetByte(dr.GetOrdinal("ImgCategory"));
               model.FilePath = !dr.IsDBNull(dr.GetOrdinal("FilePath")) ? dr.GetString(dr.GetOrdinal("FilePath")) : null;
               model.Desc = dr.GetString(dr.GetOrdinal("Desc"));
               model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
               model.OperatorId = dr.GetString(dr.GetOrdinal("OperatorId"));

               list.Add(model);
            }
         }
         return list;
      }

      #endregion

      #region private xml

      /// <summary>
      /// 创建酒店图片的xml
      /// </summary>
      /// <param name="list"></param>
      /// <returns></returns>
      private string CreateXml(IList<EyouSoft.Model.HotelStructure.MHotelImg> list)
      {
         if (list == null && list.Count == 0) return null;

         StringBuilder xmlDoc = new StringBuilder();
         xmlDoc.Append("<Root>");
         foreach (EyouSoft.Model.HotelStructure.MHotelImg model in list)
         {
            xmlDoc.Append("<HotelImg ");
            xmlDoc.AppendFormat("ImgId=\"{0}\" ", model.ImgId);
            xmlDoc.AppendFormat("HotelId=\"{0}\" ", model.HotelId);
            xmlDoc.AppendFormat("ImgCategory=\"{0}\" ", (int)model.ImgCategory);
            xmlDoc.AppendFormat("FilePath=\"{0}\" ", model.FilePath);
            xmlDoc.AppendFormat("Desc=\"{0}\" ", model.Desc);
            xmlDoc.AppendFormat("IssueTime  =\"{0}\" ", model.IssueTime);
            xmlDoc.AppendFormat("OperatorId=\"{0}\" ", model.OperatorId);
            xmlDoc.Append(" />");
         }
         xmlDoc.Append("</Root>");
         return xmlDoc.ToString();
      }

      /// <summary>
      /// 创建酒店地标的xml
      /// </summary>
      /// <param name="list"></param>
      /// <param name="hotelId">酒店编号</param>
      /// <returns></returns>
      private string CreateXml(string hotelId, IList<EyouSoft.Model.HotelStructure.MHotelLandMark> list)
      {
         if (string.IsNullOrEmpty(hotelId) || list == null || list.Count == 0) return null;

         StringBuilder xmlDoc = new StringBuilder();
         xmlDoc.Append("<Root>");
         foreach (EyouSoft.Model.HotelStructure.MHotelLandMark model in list)
         {
            xmlDoc.Append("<HotelLandMark ");
            xmlDoc.AppendFormat("HotelId=\"{0}\" ", hotelId);
            xmlDoc.AppendFormat("LandMarkId=\"{0}\" ", model.LandMarkId);
            xmlDoc.Append(" />");
         }
         xmlDoc.Append("</Root>");
         return xmlDoc.ToString();
      }

      /// <summary>
      /// 创建酒店图片的xml
      /// </summary>
      /// <param name="HotelId"></param>
      /// <param name="list"></param>
      /// <returns></returns>
      private string CreateXml(string HotelId, IList<EyouSoft.Model.HotelStructure.MHotelImg> list)
      {
         if (list == null || list.Count == 0) return null;

         StringBuilder xmlDoc = new StringBuilder();
         xmlDoc.Append("<Root>");
         foreach (EyouSoft.Model.HotelStructure.MHotelImg model in list)
         {
            xmlDoc.Append("<HotelImg ");
            xmlDoc.AppendFormat("HotelId=\"{0}\" ", HotelId);
            xmlDoc.AppendFormat("ImgCategory=\"{0}\" ", (int)model.ImgCategory);
            xmlDoc.AppendFormat("FilePath=\"{0}\" ", model.FilePath);
            xmlDoc.AppendFormat("Desc=\"{0}\" ", model.Desc);
            xmlDoc.AppendFormat("OperatorId=\"{0}\" ", model.OperatorId);
            xmlDoc.Append(" />");
         }
         xmlDoc.Append("</Root>");
         return xmlDoc.ToString();
      }


      /// <summary>
      /// 获取酒店图片的集合
      /// </summary>
      /// <returns></returns>
      private IList<EyouSoft.Model.HotelStructure.MHotelImg> GetHotelImgList(string xml)
      {
         if (string.IsNullOrEmpty(xml)) return null;
         IList<EyouSoft.Model.HotelStructure.MHotelImg> list = new List<EyouSoft.Model.HotelStructure.MHotelImg>();
         System.Xml.Linq.XElement xRoot = System.Xml.Linq.XElement.Parse(xml);
         var xRows = Utils.GetXElements(xRoot, "row");
         foreach (var xRow in xRows)
         {
            EyouSoft.Model.HotelStructure.MHotelImg item = new EyouSoft.Model.HotelStructure.MHotelImg()
            {
               ImgId = Utils.GetInt(Utils.GetXAttributeValue(xRow, "ImgId")),
               HotelId = Utils.GetXAttributeValue(xRow, "HotelId"),
               ImgCategory = (EyouSoft.Model.Enum.HotelImgType)Utils.GetInt(Utils.GetXAttributeValue(xRow, "ImgCategory")),
               FilePath = Utils.GetXAttributeValue(xRow, "FilePath"),
               Desc = Utils.GetXAttributeValue(xRow, "Desc"),
               IssueTime = Utils.GetDateTime(Utils.GetXAttributeValue(xRow, "IssueTime")),
               OperatorId = Utils.GetXAttributeValue(xRow, "OperatorId")
            };

            list.Add(item);
         }
         return list;
      }

      /// <summary>
      /// 获取酒店地标的集合
      /// </summary>
      /// <param name="xml"></param>
      /// <returns></returns>
      private IList<EyouSoft.Model.HotelStructure.MHotelLandMark> GetHotelLandMarkList(string xml)
      {
         if (string.IsNullOrEmpty(xml)) return null;
         IList<EyouSoft.Model.HotelStructure.MHotelLandMark> list = new List<EyouSoft.Model.HotelStructure.MHotelLandMark>();
         System.Xml.Linq.XElement xRoot = System.Xml.Linq.XElement.Parse(xml);
         var xRows = Utils.GetXElements(xRoot, "row");
         foreach (var xRow in xRows)
         {
            EyouSoft.Model.HotelStructure.MHotelLandMark item = new EyouSoft.Model.HotelStructure.MHotelLandMark()
            {
               HotelId = Utils.GetXAttributeValue(xRow, "HotelId"),
               LandMarkId = Utils.GetInt(Utils.GetXAttributeValue(xRow, "LandMarkId")),
               Por = Utils.GetXAttributeValue(xRow, "Por")
            };

            list.Add(item);
         }
         return list;
      }

      /// <summary>
      /// 获取酒店房型的集合
      /// </summary>
      /// <param name="xml"></param>
      /// <returns></returns>
      private IList<EyouSoft.Model.HotelStructure.MHotelRoomType> GetHotelRoomTypeList(string xml)
      {
         if (string.IsNullOrEmpty(xml)) return null;
         IList<EyouSoft.Model.HotelStructure.MHotelRoomType> list = new List<EyouSoft.Model.HotelStructure.MHotelRoomType>();
         System.Xml.Linq.XElement xRoot = System.Xml.Linq.XElement.Parse(xml);
         var xRows = Utils.GetXElements(xRoot, "row");
         foreach (var xRow in xRows)
         {
            EyouSoft.Model.HotelStructure.MHotelRoomType item = new EyouSoft.Model.HotelStructure.MHotelRoomType()
            {
               RoomTypeId = Utils.GetXAttributeValue(xRow, "RoomTypeId"),
               HotelId = Utils.GetXAttributeValue(xRow, "HotelId"),
               RoomName = Utils.GetXAttributeValue(xRow, "RoomName"),
               TotalNumber = Utils.GetInt(Utils.GetXAttributeValue(xRow, "TotalNumber")),
               RoomType = (EyouSoft.Model.Enum.RoomType)Utils.GetInt(Utils.GetXAttributeValue(xRow, "RoomType")),
               RoomArea = Utils.GetXAttributeValue(xRow, "RoomArea"),
               Floor = Utils.GetXAttributeValue(xRow, "Floor"),
               BedType = (EyouSoft.Model.Enum.BedType)Utils.GetInt(Utils.GetXAttributeValue(xRow, "BedType")),
               BedTypeDescription = Utils.GetXAttributeValue(xRow, "BedTypeDescription"),
               BedHeight = Utils.GetDecimal(Utils.GetXAttributeValue(xRow, "BedHeight")),
               BedWidth = Utils.GetDecimal(Utils.GetXAttributeValue(xRow, "BedWidth")),
               MaxGuestNum = Utils.GetInt(Utils.GetXAttributeValue(xRow, "MaxGuestNum")),
               IsSmoking = Utils.GetXAttributeValue(xRow, "IsSmoking") == "1",
               IsInternet = (EyouSoft.Model.Enum.IsInternet)Utils.GetInt(Utils.GetXAttributeValue(xRow, "IsInternet")),
               IsInternetPrice = Utils.GetDecimal(Utils.GetXAttributeValue(xRow, "IsInternetPrice")),
               Orientation = (EyouSoft.Model.Enum.Orientation)Utils.GetInt(Utils.GetXAttributeValue(xRow, "Orientation")),
               IsBreakfast = (EyouSoft.Model.Enum.IsBreakfast)Utils.GetInt(Utils.GetXAttributeValue(xRow, "IsBreakfast")),
               IsBreakfastPrice = Utils.GetDecimal(Utils.GetXAttributeValue(xRow, "IsBreakfastPrice")),
               IsWindow = (EyouSoft.Model.Enum.IsWindow)Utils.GetInt(Utils.GetXAttributeValue(xRow, "IsWindow")),
               IsAddBed = (EyouSoft.Model.Enum.IsAddBed)Utils.GetInt(Utils.GetXAttributeValue(xRow, "IsAddBed")),
               IsAddBedPrice = Utils.GetDecimal(Utils.GetXAttributeValue(xRow, "IsAddBedPrice")),
               Payment = (EyouSoft.Model.Enum.Payment)Utils.GetInt(Utils.GetXAttributeValue(xRow, "Payment")),
               Desc = Utils.GetXAttributeValue(xRow, "Desc"),
               IssueTime = Utils.GetDateTime(Utils.GetXAttributeValue(xRow, "IssueTime")),
               OperatorId = Utils.GetInt(Utils.GetXAttributeValue(xRow, "OperatorId")),
               SortId = Utils.GetInt(Utils.GetXAttributeValue(xRow, "SortId")),
               RoomStatus = (EyouSoft.Model.Enum.RoomStatus)Utils.GetInt(Utils.GetXAttributeValue(xRow, "RoomStatus")),
               AmountPrice = Utils.GetDecimal(Utils.GetXAttributeValue(xRow, "AmountPrice")),
               PreferentialPrice = Utils.GetDecimal(Utils.GetXAttributeValue(xRow, "PreferentialPrice")),
               SettlementPrice = Utils.GetDecimal(Utils.GetXAttributeValue(xRow, "SettlementPrice"))
            };

            list.Add(item);
         }

         return list;
      }


      #endregion

      /// <summary>
      /// 新增点评
      /// </summary>
      /// <param name="info"></param>
      /// <returns></returns>
      public int InsertDianPing(EyouSoft.Model.HotelStructure.MJiuDianDianPingInfo info)
      {
         string sql = "INSERT INTO [tbl_JiuDianDianPing]([DianPingId],[HotelId],[RuZhuShiJian],[WeiSheng],[FuWu],[SheShi],[WeiZhi],[YuDing],[ManYiDu],[DianPingFangShi],[DianPingShiJian],[DianPingNeiRong],[SortId],[IsCheck],[OperatorId],[IssueTime]) VALUES (@DianPingId,@HotelId,@RuZhuShiJian,@WeiSheng,@FuWu,@SheShi,@WeiZhi,@YuDing,@ManYiDu,@DianPingFangShi,@DianPingShiJian,@DianPingNeiRong,@SortId,@IsCheck,@OperatorId,@IssueTime)";
         DbCommand cmd = _db.GetSqlStringCommand(sql);

         _db.AddInParameter(cmd, "DianPingId", DbType.AnsiStringFixedLength, info.DianPingId);
         _db.AddInParameter(cmd, "HotelId", DbType.AnsiStringFixedLength, info.JiuDianId);
         _db.AddInParameter(cmd, "RuZhuShiJian", DbType.DateTime, info.RuZhuShiJian);
         _db.AddInParameter(cmd, "WeiSheng", DbType.Byte, info.WeiSheng);
         _db.AddInParameter(cmd, "FuWu", DbType.Byte, info.FuWu);
         _db.AddInParameter(cmd, "SheShi", DbType.Byte, info.SheShi);
         _db.AddInParameter(cmd, "WeiZhi", DbType.Byte, info.WeiZhi);
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
      public int UpdateDianPing(EyouSoft.Model.HotelStructure.MJiuDianDianPingInfo info)
      {
         string sql = "UPDATE [tbl_JiuDianDianPing] SET [HotelId]=@HotelId,[RuZhuShiJian]=@RuZhuShiJian,[WeiSheng]=@WeiSheng,[FuWu]=@FuWu,[SheShi]=@SheShi,[WeiZhi]=@WeiZhi,[YuDing]=@YuDing,[ManYiDu]=@ManYiDu,[DianPingFangShi]=@DianPingFangShi,[DianPingShiJian]=@DianPingShiJian,[DianPingNeiRong]=@DianPingNeiRong,[SortId]=@SortId WHERE [DianPingId]=@DianPingId";
         DbCommand cmd = _db.GetSqlStringCommand(sql);

         _db.AddInParameter(cmd, "DianPingId", DbType.AnsiStringFixedLength, info.DianPingId);
         _db.AddInParameter(cmd, "HotelId", DbType.AnsiStringFixedLength, info.JiuDianId);
         _db.AddInParameter(cmd, "RuZhuShiJian", DbType.DateTime, info.RuZhuShiJian);
         _db.AddInParameter(cmd, "WeiSheng", DbType.Byte, info.WeiSheng);
         _db.AddInParameter(cmd, "FuWu", DbType.Byte, info.FuWu);
         _db.AddInParameter(cmd, "SheShi", DbType.Byte, info.SheShi);
         _db.AddInParameter(cmd, "WeiZhi", DbType.Byte, info.WeiZhi);
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
         string sql = "DELETE FROM [tbl_JiuDianDianPing] WHERE [DianPingId]=@DianPingId";
         DbCommand cmd = _db.GetSqlStringCommand(sql);

         _db.AddInParameter(cmd, "DianPingId", DbType.AnsiStringFixedLength, dianPingId);

         return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
      }

      /// <summary>
      /// 获取点评
      /// </summary>
      /// <param name="dianPingId"></param>
      /// <returns></returns>
      public EyouSoft.Model.HotelStructure.MJiuDianDianPingInfo GetDianPingInfo(string dianPingId)
      {
         EyouSoft.Model.HotelStructure.MJiuDianDianPingInfo info = null;
         string sql = "SELECT *,(SELECT A1.HotelName FROM tbl_Hotel AS A1 WHERE A1.HotelId=A.HotelId) AS JiuDianName,(CASE LEN(OperatorId) WHEN 36 THEN (SELECT Account FROM tbl_Member WHERE MemberID=A.OperatorId) ELSE (SELECT Username FROM tbl_Webmaster WHERE Id=A.OperatorId) END) AS OperatorName FROM [tbl_JiuDianDianPing] AS A WHERE A.[DianPingId]=@DianPingId";

         DbCommand cmd = _db.GetSqlStringCommand(sql);

         _db.AddInParameter(cmd, "DianPingId", DbType.AnsiStringFixedLength, dianPingId);

         using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
         {
            if (rdr.Read())
            {
               info = new EyouSoft.Model.HotelStructure.MJiuDianDianPingInfo();

               info.DianPingFangShi = (EyouSoft.Model.Enum.XianLuStructure.DianPingType)rdr.GetByte(rdr.GetOrdinal("DianPingFangShi"));
               info.DianPingId = dianPingId;
               info.DianPingNeiRong = rdr["DianPingNeiRong"].ToString();
               info.DianPingShiJian = rdr.GetDateTime(rdr.GetOrdinal("DianPingShiJian"));
               info.FuWu = (EyouSoft.Model.Enum.XianLuStructure.DianPingStatus)rdr.GetByte(rdr.GetOrdinal("FuWu"));
               info.IsCheck = rdr["IsCheck"].ToString() == "1";
               info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
               info.JiuDianId = rdr["HotelId"].ToString();
               info.JiuDianName = rdr["JiuDianName"].ToString();
               info.ManYiDu = rdr.GetDecimal(rdr.GetOrdinal("ManYiDu"));
               info.OperatorId = rdr["OperatorId"].ToString();
               info.OperatorName = rdr["OperatorName"].ToString();
               if (!rdr.IsDBNull(rdr.GetOrdinal("RuZhuShiJian"))) info.RuZhuShiJian = rdr.GetDateTime(rdr.GetOrdinal("RuZhuShiJian"));
               info.SheShi = (EyouSoft.Model.Enum.XianLuStructure.DianPingStatus)rdr.GetByte(rdr.GetOrdinal("SheShi"));
               info.SortId = rdr.GetInt32(rdr.GetOrdinal("SortId"));
               info.WeiSheng = (EyouSoft.Model.Enum.XianLuStructure.DianPingStatus)rdr.GetByte(rdr.GetOrdinal("WeiSheng"));
               info.WeiZhi = (EyouSoft.Model.Enum.XianLuStructure.DianPingStatus)rdr.GetByte(rdr.GetOrdinal("WeiZhi"));
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
      public IList<EyouSoft.Model.HotelStructure.MJiuDianDianPingInfo> GetDianPings(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.HotelStructure.MJiuDianDianPingChaXunInfo chaXun)
      {
         IList<EyouSoft.Model.HotelStructure.MJiuDianDianPingInfo> items = new List<EyouSoft.Model.HotelStructure.MJiuDianDianPingInfo>();
         string tableName = "tbl_JiuDianDianPing";

         StringBuilder fields = new StringBuilder();
         fields.Append(" * ");
         fields.Append(",(SELECT A1.HotelName FROM tbl_Hotel AS A1 WHERE A1.HotelId=tbl_JiuDianDianPing.HotelId) AS JiuDianName");
         fields.Append(",(CASE LEN(OperatorId) WHEN 36 THEN (SELECT Account FROM tbl_Member WHERE MemberID=tbl_JiuDianDianPing.OperatorId) ELSE (SELECT Username FROM tbl_Webmaster WHERE Id=tbl_JiuDianDianPing.OperatorId) END) AS OperatorName");

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
            if (!string.IsNullOrEmpty(chaXun.JiuDianId))
            {
               s.AppendFormat(" AND HotelId='{0}' ", chaXun.JiuDianId);
            }
            if (!string.IsNullOrEmpty(chaXun.JiuDianName))
            {
               s.AppendFormat(" AND EXISTS(SELECT 1 FROM tbl_Hotel WHERE tbl_Hotel.HotelId=tbl_JiuDianDianPing.HotelId AND tbl_Hotel.HotelName LIKE '%{0}%' ) ", chaXun.JiuDianName);
            }
            if (!string.IsNullOrEmpty(chaXun.OperatorId))
            {
               s.AppendFormat(" AND OperatorId='{0}' ", chaXun.OperatorId);
            }
            if (!string.IsNullOrEmpty(chaXun.OperatorName))
            {
               s.AppendFormat(" AND (EXISTS(SELECT 1 FROM tbl_Member WHERE MemberID=tbl_JiuDianDianPing.OperatorId AND Account LIKE '%{0}%') OR EXISTS(SELECT 1 FROM tbl_Webmaster WHERE Id=tbl_JiuDianDianPing.OperatorId AND Username LIKE '%{0}%') )", chaXun.OperatorName);
            }
         }

         using (IDataReader rdr = DbHelper.ExecuteReader1(_db, pageSize, pageIndex, ref recordCount, tableName, fields.ToString(), s.ToString(), orderByString, string.Empty))
         {
            while (rdr.Read())
            {
               var info = new EyouSoft.Model.HotelStructure.MJiuDianDianPingInfo();

               info.DianPingFangShi = (EyouSoft.Model.Enum.XianLuStructure.DianPingType)rdr.GetByte(rdr.GetOrdinal("DianPingFangShi"));
               info.DianPingId = rdr["DianPingId"].ToString();
               info.DianPingNeiRong = rdr["DianPingNeiRong"].ToString();
               info.DianPingShiJian = rdr.GetDateTime(rdr.GetOrdinal("DianPingShiJian"));
               info.FuWu = (EyouSoft.Model.Enum.XianLuStructure.DianPingStatus)rdr.GetByte(rdr.GetOrdinal("FuWu"));
               info.IsCheck = rdr["IsCheck"].ToString() == "1";
               info.IssueTime = rdr.GetDateTime(rdr.GetOrdinal("IssueTime"));
               info.JiuDianId = rdr["HotelId"].ToString();
               info.JiuDianName = rdr["JiuDianName"].ToString();
               info.ManYiDu = rdr.GetDecimal(rdr.GetOrdinal("ManYiDu"));
               info.OperatorId = rdr["OperatorId"].ToString();
               info.OperatorName = rdr["OperatorName"].ToString();
               if (!rdr.IsDBNull(rdr.GetOrdinal("RuZhuShiJian"))) info.RuZhuShiJian = rdr.GetDateTime(rdr.GetOrdinal("RuZhuShiJian"));
               info.SheShi = (EyouSoft.Model.Enum.XianLuStructure.DianPingStatus)rdr.GetByte(rdr.GetOrdinal("SheShi"));
               info.SortId = rdr.GetInt32(rdr.GetOrdinal("SortId"));
               info.WeiSheng = (EyouSoft.Model.Enum.XianLuStructure.DianPingStatus)rdr.GetByte(rdr.GetOrdinal("WeiSheng"));
               info.WeiZhi = (EyouSoft.Model.Enum.XianLuStructure.DianPingStatus)rdr.GetByte(rdr.GetOrdinal("WeiZhi"));
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
         string sql = "UPDATE tbl_JiuDianDianPing SET IsCheck=@IsCheck WHERE DianPingId=@DianPingId";
         DbCommand cmd = _db.GetSqlStringCommand(sql);

         _db.AddInParameter(cmd, "DianPingId", DbType.AnsiStringFixedLength, dianPingId);
         _db.AddInParameter(cmd, "IsCheck", DbType.AnsiStringFixedLength, isShenHe ? "1" : "0");

         return DbHelper.ExecuteSql(cmd, _db) == 1 ? 1 : -100;
      }

      /// <summary>
      /// 获取满意度
      /// </summary>
      /// <param name="jiuDianId"></param>
      /// <returns></returns>
      public decimal GetManYiDu(string jiuDianId)
      {
         string sql = "SELECT AVG(ManYiDu) AS ManYiDu FROM tbl_JiuDianDianPing  WHERE HotelId=@JiuDianId AND IsCheck='1' ";
         DbCommand cmd = _db.GetSqlStringCommand(sql);
         _db.AddInParameter(cmd, "JiuDianId", DbType.AnsiStringFixedLength, jiuDianId);

         using (IDataReader rdr = DbHelper.ExecuteReader(cmd, _db))
         {
            if (rdr.Read())
            {
               if (!rdr.IsDBNull(0)) return rdr.GetDecimal(0);
            }
         }

         return 0;
      }

   }
}
