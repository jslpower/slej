using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Toolkit.DAL;
using System.Data.Common;
using System.Data;
using EyouSoft.Toolkit;

namespace EyouSoft.DAL.HotelStructure
{
   public class DHotelRoomType : DALBase, EyouSoft.IDAL.HotelStructure.IHotelRoomType
   {
      #region 初始化db

      private Microsoft.Practices.EnterpriseLibrary.Data.Database _db = null;

      /// <summary>
      /// 初始化_db
      /// </summary>
      public DHotelRoomType()
      {
         _db = base.SystemStore;
      }

      #endregion

      #region 房型

      /// <summary>
      /// 添加酒店房型
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>
      public bool AddHotelRoomType(EyouSoft.Model.HotelStructure.MHotelRoomType model)
      {
         DbCommand cmd = this._db.GetStoredProcCommand("proc_HotelRoomType_Add");
         this._db.AddInParameter(cmd, "RoomTypeId", DbType.AnsiStringFixedLength, model.RoomTypeId);
         this._db.AddInParameter(cmd, "HotelId", DbType.AnsiStringFixedLength, model.HotelId);
         this._db.AddInParameter(cmd, "RoomName", DbType.String, model.RoomName);
         this._db.AddInParameter(cmd, "TotalNumber", DbType.Int32, model.TotalNumber);
         this._db.AddInParameter(cmd, "RoomType", DbType.Byte, (int)model.RoomType);
         this._db.AddInParameter(cmd, "RoomArea", DbType.String, model.RoomArea);
         this._db.AddInParameter(cmd, "Floor", DbType.String, model.Floor);
         this._db.AddInParameter(cmd, "BedType", DbType.Byte, (int)model.BedType);
         this._db.AddInParameter(cmd, "BedHeight", DbType.Decimal, model.BedHeight);
         this._db.AddInParameter(cmd, "BedWidth", DbType.Decimal, model.BedWidth);
         this._db.AddInParameter(cmd, "MaxGuestNum", DbType.Int32, model.MaxGuestNum);
         this._db.AddInParameter(cmd, "IsSmoking", DbType.AnsiStringFixedLength, model.IsSmoking ? 1 : 0);
         this._db.AddInParameter(cmd, "IsInternet", DbType.Byte, model.IsInternet);
         this._db.AddInParameter(cmd, "IsInternetPrice", DbType.Currency, model.IsInternetPrice);
         this._db.AddInParameter(cmd, "Orientation", DbType.Byte, (int)model.Orientation);
         this._db.AddInParameter(cmd, "IsBreakfast", DbType.Byte, model.IsBreakfast);
         this._db.AddInParameter(cmd, "IsBreakfastPrice", DbType.Decimal, model.IsBreakfastPrice);
         this._db.AddInParameter(cmd, "IsWindow", DbType.Byte, (int)model.IsWindow);
         this._db.AddInParameter(cmd, "IsAddBed", DbType.Byte, (int)model.IsAddBed);
         this._db.AddInParameter(cmd, "IsAddBedPrice", DbType.Currency, model.IsAddBedPrice);
         this._db.AddInParameter(cmd, "Payment", DbType.Currency, model.Payment);
         this._db.AddInParameter(cmd, "Desc", DbType.String, model.Desc);
         this._db.AddInParameter(cmd, "OperatorId", DbType.Int32, model.OperatorId);
         this._db.AddInParameter(cmd, "SortId", DbType.Int32, model.SortId);
         this._db.AddInParameter(cmd, "RoomStatus", DbType.Byte, (int)model.RoomStatus);
         this._db.AddInParameter(cmd, "HotelRoomImg", DbType.Xml, CreateXml(model.HoteRoomImgList));
         this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
         _db.AddInParameter(cmd, "IsFenXiao", DbType.AnsiStringFixedLength, model.IsFenXiao ? "1" : "0");

         DbHelper.RunProcedureWithResult(cmd, this._db);
         return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result")) > 0 ? true : false;
      }

      /// <summary>
      /// 修改酒店房型
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>
      public bool UpdateHotelRoomType(EyouSoft.Model.HotelStructure.MHotelRoomType model)
      {
         DbCommand cmd = this._db.GetStoredProcCommand("proc_HotelRoomType_Update");
         this._db.AddInParameter(cmd, "RoomTypeId", DbType.AnsiStringFixedLength, model.RoomTypeId);
         this._db.AddInParameter(cmd, "HotelId", DbType.AnsiStringFixedLength, model.HotelId);
         this._db.AddInParameter(cmd, "RoomName", DbType.String, model.RoomName);
         this._db.AddInParameter(cmd, "TotalNumber", DbType.Int32, model.TotalNumber);
         this._db.AddInParameter(cmd, "RoomType", DbType.Byte, (int)model.RoomType);
         this._db.AddInParameter(cmd, "RoomArea", DbType.String, model.RoomArea);
         this._db.AddInParameter(cmd, "Floor", DbType.String, model.Floor);
         this._db.AddInParameter(cmd, "BedType", DbType.Byte, (int)model.BedType);
         this._db.AddInParameter(cmd, "BedHeight", DbType.Decimal, model.BedHeight);
         this._db.AddInParameter(cmd, "BedWidth", DbType.Decimal, model.BedWidth);
         this._db.AddInParameter(cmd, "MaxGuestNum", DbType.Int32, model.MaxGuestNum);
         this._db.AddInParameter(cmd, "IsSmoking", DbType.AnsiStringFixedLength, model.IsSmoking ? 1 : 0);
         this._db.AddInParameter(cmd, "IsInternet", DbType.Byte, model.IsInternet);
         this._db.AddInParameter(cmd, "IsInternetPrice", DbType.Currency, model.IsInternetPrice);
         this._db.AddInParameter(cmd, "Orientation", DbType.Byte, (int)model.Orientation);
         this._db.AddInParameter(cmd, "IsBreakfast", DbType.Byte, model.IsBreakfast);
         this._db.AddInParameter(cmd, "IsBreakfastPrice", DbType.Decimal, model.IsBreakfastPrice);
         this._db.AddInParameter(cmd, "IsWindow", DbType.Byte, (int)model.IsWindow);
         this._db.AddInParameter(cmd, "IsAddBed", DbType.Byte, (int)model.IsAddBed);
         this._db.AddInParameter(cmd, "IsAddBedPrice", DbType.Currency, model.IsAddBedPrice);
         this._db.AddInParameter(cmd, "Payment", DbType.Currency, model.Payment);
         this._db.AddInParameter(cmd, "Desc", DbType.String, model.Desc);
         this._db.AddInParameter(cmd, "OperatorId", DbType.Int32, model.OperatorId);
         this._db.AddInParameter(cmd, "SortId", DbType.Int32, model.SortId);
         this._db.AddInParameter(cmd, "RoomStatus", DbType.Byte, (int)model.RoomStatus);
         this._db.AddInParameter(cmd, "HotelRoomImg", DbType.Xml, CreateXml(model.HoteRoomImgList));
         this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
         _db.AddInParameter(cmd, "IsFenXiao", DbType.AnsiStringFixedLength, model.IsFenXiao ? "1" : "0");

         DbHelper.RunProcedureWithResult(cmd, this._db);
         return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result")) > 0 ? true : false;
      }

      /// <summary>
      /// 修改房型的状态
      /// </summary>
      /// <param name="RoomTypeId"></param>
      /// <returns></returns>
      public bool UpdateHotelRoomType(string RoomTypeId, EyouSoft.Model.Enum.RoomStatus RoomStatus)
      {
         string query = "update tbl_HotelRoomType set RoomStatus=@RoomStatus where RoomTypeId=@RoomTypeId";
         DbCommand cmd = this._db.GetSqlStringCommand(query);
         this._db.AddInParameter(cmd, "RoomStatus", DbType.Byte, (int)RoomStatus);
         this._db.AddInParameter(cmd, "RoomTypeId", DbType.AnsiStringFixedLength, RoomTypeId);

         return DbHelper.ExecuteSql(cmd, this._db) > 0 ? true : false;

      }

      /// <summary>
      /// 删除房型
      /// </summary>
      /// <param name="RoomTypeId"></param>
      /// <returns>
      ///  -1:房型存在订单不允许删除
      ///   1:成功
      ///	  0:失败
      /// </returns>
      public int DeleteHotelRoomType(string RoomTypeId)
      {
         DbCommand cmd = this._db.GetStoredProcCommand("proc_HotelRoomType_Delete");
         this._db.AddInParameter(cmd, "RoomTypeId", DbType.AnsiStringFixedLength, RoomTypeId);
         this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);

         DbHelper.RunProcedureWithResult(cmd, this._db);
         return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result"));
      }

      /// <summary>
      /// 根据房型的编码获取实体
      /// </summary>
      /// <param name="RoomTypeId"></param>
      /// <returns></returns>
      public EyouSoft.Model.HotelStructure.MHotelRoomType GetHotelRoomTypeModel(string RoomTypeId)
      {
         EyouSoft.Model.HotelStructure.MHotelRoomType model = null;

         // string sql = "select *,(select * from tbl_HotelRoomImg where RoomTypeId=tbl_HotelRoomType.RoomTypeId for xml raw,root('Root')) as HotelRoomImg from tbl_HotelRoomType  where RoomTypeId=@RoomTypeId";

         StringBuilder query = new StringBuilder();
         query.Append(" SELECT ");
         query.Append(" B.* ");
         query.Append(" ,(select * from tbl_HotelRoomImg where RoomTypeId=B.RoomTypeId for xml raw,root('Root')) as HotelRoomImg  ");
         query.Append(" ,isnull(C.AmountPrice,0) as AmountPrice ");
         query.Append(" ,isnull(C.PreferentialPrice,0) as PreferentialPrice ");
         query.Append(" ,isnull(C.SettlementPrice,0) as SettlementPrice ");
         query.Append(" FROM tbl_HotelRoomType as B	left join tbl_HotelRoomRate as C ");
         query.Append(" on B.RoomTypeId=C.RoomTypeId and datediff(day,C.StartDate,getdate())>=0 and datediff(day,C.EndDate,getdate())<=0 ");
         query.Append(" where B.RoomTypeId=@RoomTypeId ");


         DbCommand cmd = this._db.GetSqlStringCommand(query.ToString());

         this._db.AddInParameter(cmd, "RoomTypeId", DbType.AnsiStringFixedLength, RoomTypeId);

         using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
         {
            while (dr.Read())
            {
               model = new EyouSoft.Model.HotelStructure.MHotelRoomType();
               model.RoomTypeId = dr.GetString(dr.GetOrdinal("RoomTypeId"));
               model.HotelId = dr.GetString(dr.GetOrdinal("HotelId"));
               model.RoomName = !dr.IsDBNull(dr.GetOrdinal("RoomName")) ? dr.GetString(dr.GetOrdinal("RoomName")) : null;
               model.TotalNumber = dr.GetInt32(dr.GetOrdinal("TotalNumber"));
               model.RoomType = (EyouSoft.Model.Enum.RoomType)dr.GetByte(dr.GetOrdinal("RoomType"));
               model.RoomArea = !dr.IsDBNull(dr.GetOrdinal("RoomArea")) ? dr.GetString(dr.GetOrdinal("RoomArea")) : null;
               model.Floor = !dr.IsDBNull(dr.GetOrdinal("Floor")) ? dr.GetString(dr.GetOrdinal("Floor")) : null;
               model.BedType = (EyouSoft.Model.Enum.BedType)dr.GetByte(dr.GetOrdinal("BedType"));
               model.BedHeight = dr.GetDecimal(dr.GetOrdinal("BedHeight"));
               model.BedWidth = dr.GetDecimal(dr.GetOrdinal("BedWidth"));
               model.MaxGuestNum = dr.GetInt32(dr.GetOrdinal("MaxGuestNum"));
               model.IsSmoking = dr.GetString(dr.GetOrdinal("IsSmoking")) == "1";
               model.IsInternet = (EyouSoft.Model.Enum.IsInternet)dr.GetByte(dr.GetOrdinal("IsInternet"));
               model.IsInternetPrice = dr.GetDecimal(dr.GetOrdinal("IsInternetPrice"));
               model.Orientation = (EyouSoft.Model.Enum.Orientation)dr.GetByte(dr.GetOrdinal("Orientation"));
               model.IsBreakfast = (EyouSoft.Model.Enum.IsBreakfast)dr.GetByte(dr.GetOrdinal("IsBreakfast"));
               model.IsBreakfastPrice = dr.GetDecimal(dr.GetOrdinal("IsBreakfastPrice"));
               model.IsWindow = (EyouSoft.Model.Enum.IsWindow)dr.GetByte(dr.GetOrdinal("IsWindow"));
               model.IsAddBed = (EyouSoft.Model.Enum.IsAddBed)dr.GetByte(dr.GetOrdinal("IsAddBed"));
               model.IsAddBedPrice = dr.GetDecimal(dr.GetOrdinal("IsAddBedPrice"));
               model.Payment = (EyouSoft.Model.Enum.Payment)dr.GetByte(dr.GetOrdinal("Payment"));
               model.Desc = !dr.IsDBNull(dr.GetOrdinal("Desc")) ? dr.GetString(dr.GetOrdinal("Desc")) : null;
               model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
               model.OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"));
               model.SortId = dr.GetInt32(dr.GetOrdinal("SortId"));
               model.RoomStatus = (EyouSoft.Model.Enum.RoomStatus)dr.GetByte(dr.GetOrdinal("RoomStatus"));

               model.AmountPrice = dr.GetDecimal(dr.GetOrdinal("AmountPrice"));
               model.PreferentialPrice = dr.GetDecimal(dr.GetOrdinal("PreferentialPrice"));
               model.SettlementPrice = dr.GetDecimal(dr.GetOrdinal("SettlementPrice"));

               model.HoteRoomImgList = !dr.IsDBNull(dr.GetOrdinal("HotelRoomImg")) ? (List<EyouSoft.Model.HotelStructure.MHotelRoomImg>)GetHotelRoomImgList(dr.GetString(dr.GetOrdinal("HotelRoomImg"))) : null;
               model.IsFenXiao = dr["IsFenXiao"].ToString() == "1";

            }
         }

         return model;
      }

      /// <summary>
      /// 根据酒店编号获取酒店房型
      /// </summary>
      /// <param name="search"></param>
      /// <param name="top"></param>
      /// <returns></returns>
      public IList<Model.HotelStructure.MHotelRoomType> GetHotelRoomTypeListByHotelId(int top,
          Model.HotelStructure.MHotelRoomTypeSearch search)
      {
         var strSql = new StringBuilder(" select ");
         var strWhere = new StringBuilder(" hrt.IsDelete = '0' ");
         var strSonWhere = new StringBuilder();
         if (search != null)
         {
            if (!string.IsNullOrEmpty(search.HotelId))
            {
               strWhere.AppendFormat(" and hrt.HotelId = '{0}' ", Utils.ToSqlLike(search.HotelId));
            }
            if (!string.IsNullOrEmpty(search.RoomName))
            {
               strWhere.AppendFormat(" and hrt.RoomName like '%{0}%' ", Utils.ToSqlLike(search.RoomName));
            }
            if (search.RoomStatus.HasValue)
            {
               strWhere.AppendFormat(" and hrt.RoomStatus = {0} ", (int)search.RoomStatus.Value);
            }
            if (search.InDate.HasValue)
            {
               strSonWhere.AppendFormat(" and datediff(day,hrr.StartDate,'{0}')>=0  ", search.InDate.Value.ToShortDateString());
            }
            else
            {
               strSonWhere.Append(" and datediff(day,hrr.StartDate,getdate())>=0  ");
            }
            if (search.OutDate.HasValue)
            {
               strSonWhere.AppendFormat(" and datediff(day,hrr.EndDate,'{0}')<=0  ", search.OutDate.Value.ToShortDateString());
            }
            else
            {
               strSonWhere.Append(" and datediff(day,hrr.EndDate,getdate())<=0 ");
            }
            if (search.IsFenXiao.HasValue)
            {
               strWhere.AppendFormat(" AND hrt.IsFenXiao='{0}' ", search.IsFenXiao.Value ? "1" : "0");
            }
         }
         if (top > 0)
         {
            strSql.AppendFormat(" top {0} ", top);
         }
         strSql.Append(
             " hrt.*,(select * from tbl_HotelRoomImg where tbl_HotelRoomImg.RoomTypeId=hrt.RoomTypeId for xml raw,root('Root')) as HotelRoomImg ");
         strSql.Append(" ,hrr.AmountPrice,hrr.PreferentialPrice,hrr.SettlementPrice ");
         strSql.Append(",hrr.RoomRateId AS JiaGeId");
         strSql.Append(",hrr.ShuLiang AS ShuLiang");
         strSql.Append(",(SELECT SUM(A1.RoomCount) FROM tbl_HotelOrder AS A1 WHERE A1.JiaGeId=hrr.RoomRateId AND A1.OrderState IN(0,3,4,5)) AS YiYuDingShuLiang ");
         strSql.Append(" from tbl_HotelRoomType as hrt left join tbl_HotelRoomRate as hrr ");
         //补充房型条件
         strSql.AppendFormat(@" on hrt.HotelId = hrr.HotelId and hrt.RoomTypeId = hrr.RoomTypeId {0} ", strSonWhere.ToString());

         strSql.AppendFormat(" where {0} ", strWhere.ToString());

         DbCommand dc = _db.GetSqlStringCommand(strSql.ToString());

         var list = new List<Model.HotelStructure.MHotelRoomType>();
         using (IDataReader dr = DbHelper.ExecuteReader(dc, this._db))
         {
            while (dr.Read())
            {
               var model = new Model.HotelStructure.MHotelRoomType
                   {
                      RoomTypeId = dr.GetString(dr.GetOrdinal("RoomTypeId")),
                      HotelId = dr.GetString(dr.GetOrdinal("HotelId")),
                      RoomName =
                          !dr.IsDBNull(dr.GetOrdinal("RoomName")) ? dr.GetString(dr.GetOrdinal("RoomName")) : null,
                      TotalNumber = dr.GetInt32(dr.GetOrdinal("TotalNumber")),
                      RoomType = (Model.Enum.RoomType)dr.GetByte(dr.GetOrdinal("RoomType")),
                      RoomArea =
                          !dr.IsDBNull(dr.GetOrdinal("RoomArea")) ? dr.GetString(dr.GetOrdinal("RoomArea")) : null,
                      Floor = !dr.IsDBNull(dr.GetOrdinal("Floor")) ? dr.GetString(dr.GetOrdinal("Floor")) : null,
                      BedType = (Model.Enum.BedType)dr.GetByte(dr.GetOrdinal("BedType")),
                      BedHeight = dr.GetDecimal(dr.GetOrdinal("BedHeight")),
                      BedWidth = dr.GetDecimal(dr.GetOrdinal("BedWidth")),
                      MaxGuestNum = dr.GetInt32(dr.GetOrdinal("MaxGuestNum")),
                      IsSmoking = dr.GetString(dr.GetOrdinal("IsSmoking")) == "1",
                      IsInternet = (Model.Enum.IsInternet)dr.GetByte(dr.GetOrdinal("IsInternet")),
                      IsInternetPrice = dr.GetDecimal(dr.GetOrdinal("IsInternetPrice")),
                      Orientation = (Model.Enum.Orientation)dr.GetByte(dr.GetOrdinal("Orientation")),
                      IsBreakfast = (Model.Enum.IsBreakfast)dr.GetByte(dr.GetOrdinal("IsBreakfast")),
                      IsBreakfastPrice = dr.GetDecimal(dr.GetOrdinal("IsBreakfastPrice")),
                      IsWindow = (Model.Enum.IsWindow)dr.GetByte(dr.GetOrdinal("IsWindow")),
                      IsAddBed = (Model.Enum.IsAddBed)dr.GetByte(dr.GetOrdinal("IsAddBed")),
                      IsAddBedPrice = dr.GetDecimal(dr.GetOrdinal("IsAddBedPrice")),
                      Payment = (Model.Enum.Payment)dr.GetByte(dr.GetOrdinal("Payment")),
                      Desc = !dr.IsDBNull(dr.GetOrdinal("Desc")) ? dr.GetString(dr.GetOrdinal("Desc")) : null,
                      IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime")),
                      OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId")),
                      SortId = dr.GetInt32(dr.GetOrdinal("SortId")),
                      RoomStatus = (Model.Enum.RoomStatus)dr.GetByte(dr.GetOrdinal("RoomStatus")),
                      HoteRoomImgList =
                          !dr.IsDBNull(dr.GetOrdinal("HotelRoomImg"))
                              ? (List<EyouSoft.Model.HotelStructure.MHotelRoomImg>)this.GetHotelRoomImgList(dr.GetString(dr.GetOrdinal("HotelRoomImg")))
                              : null,
                      AmountPrice =
                          dr.IsDBNull(dr.GetOrdinal("AmountPrice"))
                              ? 0M
                              : dr.GetDecimal(dr.GetOrdinal("AmountPrice")),
                      PreferentialPrice =
                          dr.IsDBNull(dr.GetOrdinal("PreferentialPrice"))
                              ? 0M
                              : dr.GetDecimal(dr.GetOrdinal("PreferentialPrice")),
                      SettlementPrice =
                          dr.IsDBNull(dr.GetOrdinal("SettlementPrice"))
                              ? 0M
                              : dr.GetDecimal(dr.GetOrdinal("SettlementPrice"))
                   };

               if (!dr.IsDBNull(dr.GetOrdinal("JiaGeId"))) model.JiaGeId = dr.GetInt32(dr.GetOrdinal("JiaGeId"));
               if (!dr.IsDBNull(dr.GetOrdinal("ShuLiang"))) model.ShuLiang = dr.GetInt32(dr.GetOrdinal("ShuLiang"));
               if (!dr.IsDBNull(dr.GetOrdinal("YiYuDingShuLiang"))) model.YiYuDingShuLiang = dr.GetInt32(dr.GetOrdinal("YiYuDingShuLiang"));

               list.Add(model);
            }
         }

         return list;

      }


      /// <summary>
      /// 根据酒店编号获取酒店房型
      /// </summary>
      /// <param name="HotelId"></param>
      /// <returns></returns>
      public IList<EyouSoft.Model.HotelStructure.MHotelRoomType> GetHotelRoomTypeListByHotelId(string HotelId)
      {
         IList<EyouSoft.Model.HotelStructure.MHotelRoomType> list = new List<EyouSoft.Model.HotelStructure.MHotelRoomType>();

         string sql = "select *,(select * from tbl_HotelRoomImg where RoomTypeId=tbl_HotelRoomType.RoomTypeId for xml raw,root('Root')) as HotelRoomImg from tbl_HotelRoomType  where IsDelete = '0' and HotelId=@HotelId";

         DbCommand cmd = this._db.GetSqlStringCommand(sql);

         this._db.AddInParameter(cmd, "HotelId", DbType.AnsiStringFixedLength, HotelId);
         using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
         {
            while (dr.Read())
            {
               EyouSoft.Model.HotelStructure.MHotelRoomType model = new EyouSoft.Model.HotelStructure.MHotelRoomType();
               model.RoomTypeId = dr.GetString(dr.GetOrdinal("RoomTypeId"));
               model.HotelId = dr.GetString(dr.GetOrdinal("HotelId"));
               model.RoomName = !dr.IsDBNull(dr.GetOrdinal("RoomName")) ? dr.GetString(dr.GetOrdinal("RoomName")) : null;
               model.TotalNumber = dr.GetInt32(dr.GetOrdinal("TotalNumber"));
               model.RoomType = (EyouSoft.Model.Enum.RoomType)dr.GetByte(dr.GetOrdinal("RoomType"));
               model.RoomArea = !dr.IsDBNull(dr.GetOrdinal("RoomArea")) ? dr.GetString(dr.GetOrdinal("RoomArea")) : null;
               model.Floor = !dr.IsDBNull(dr.GetOrdinal("Floor")) ? dr.GetString(dr.GetOrdinal("Floor")) : null;
               model.BedType = (EyouSoft.Model.Enum.BedType)dr.GetByte(dr.GetOrdinal("BedType"));
               model.BedHeight = dr.GetDecimal(dr.GetOrdinal("BedHeight"));
               model.BedWidth = dr.GetDecimal(dr.GetOrdinal("BedWidth"));
               model.MaxGuestNum = dr.GetInt32(dr.GetOrdinal("MaxGuestNum"));
               model.IsSmoking = dr.GetString(dr.GetOrdinal("IsSmoking")) == "1";
               model.IsInternet = (EyouSoft.Model.Enum.IsInternet)dr.GetByte(dr.GetOrdinal("IsInternet"));
               model.IsInternetPrice = dr.GetDecimal(dr.GetOrdinal("IsInternetPrice"));
               model.Orientation = (EyouSoft.Model.Enum.Orientation)dr.GetByte(dr.GetOrdinal("Orientation"));
               model.IsBreakfast = (EyouSoft.Model.Enum.IsBreakfast)dr.GetByte(dr.GetOrdinal("IsBreakfast"));
               model.IsBreakfastPrice = dr.GetDecimal(dr.GetOrdinal("IsBreakfastPrice"));
               model.IsWindow = (EyouSoft.Model.Enum.IsWindow)dr.GetByte(dr.GetOrdinal("IsWindow"));
               model.IsAddBed = (EyouSoft.Model.Enum.IsAddBed)dr.GetByte(dr.GetOrdinal("IsAddBed"));
               model.IsAddBedPrice = dr.GetDecimal(dr.GetOrdinal("IsAddBedPrice"));
               model.Payment = (EyouSoft.Model.Enum.Payment)dr.GetByte(dr.GetOrdinal("Payment"));
               model.Desc = !dr.IsDBNull(dr.GetOrdinal("Desc")) ? dr.GetString(dr.GetOrdinal("Desc")) : null;
               model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
               model.OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"));
               model.SortId = dr.GetInt32(dr.GetOrdinal("SortId"));
               model.RoomStatus = (EyouSoft.Model.Enum.RoomStatus)dr.GetByte(dr.GetOrdinal("RoomStatus"));

               model.HoteRoomImgList = !dr.IsDBNull(dr.GetOrdinal("HotelRoomImg")) ? (List<EyouSoft.Model.HotelStructure.MHotelRoomImg>)GetHotelRoomImgList(dr.GetString(dr.GetOrdinal("HotelRoomImg"))) : null;

               list.Add(model);
            }


         }

         return list;
      }

      /// <summary>
      /// 获取酒店房型的分页列表
      /// </summary>
      /// <param name="pageSize"></param>
      /// <param name="pageIndex"></param>
      /// <param name="recordCount"></param>
      /// <param name="search"></param>
      /// <returns></returns>
      public IList<EyouSoft.Model.HotelStructure.MHotelRoomType> GetHotelRoomTypeList(int pageSize, int pageIndex, ref int recordCount, EyouSoft.Model.HotelStructure.MHotelRoomTypeSearch search)
      {
         IList<EyouSoft.Model.HotelStructure.MHotelRoomType> list = new List<EyouSoft.Model.HotelStructure.MHotelRoomType>();

         StringBuilder tableName = new StringBuilder();
         tableName.Append(" SELECT ");
         tableName.Append(" B.RoomTypeId,B.HotelId,B.RoomName,B.TotalNumber,B.RoomType,B.RoomArea, ");
         tableName.Append(" B.Floor,B.BedType,B.BedTypeDescription,B.InterfaceID,B.BedHeight,B.BedWidth,B.MaxGuestNum,B.IsSmoking, ");
         tableName.Append(" B.IsInternet,B.IsInternetPrice,B.Orientation,B.IsBreakfast,B.IsBreakfastPrice, ");
         tableName.Append(" B.IsWindow,B.IsAddBed,B.IsAddBedPrice,B.Payment,B.[Desc],B.IssueTime, ");
         tableName.Append(" B.OperatorId,B.SortId,B.RoomStatus,B.IsDelete,");
         tableName.Append(" isnull(C.AmountPrice,0) as AmountPrice,isnull(C.PreferentialPrice,0) as PreferentialPrice,isnull(C.SettlementPrice,0) as SettlementPrice");
         tableName.Append(" ,(select HotelName from tbl_Hotel where tbl_Hotel.HotelId = B.HotelId) as HotelName ");
         tableName.Append(" FROM tbl_HotelRoomType as B	left join tbl_HotelRoomRate as C ");
         tableName.Append(" on B.RoomTypeId=C.RoomTypeId ");

         if (search != null)
         {
            if (search.InDate.HasValue)
            {
               tableName.AppendFormat(" and datediff(day,C.StartDate,'{0}')>=0 ", search.InDate.Value);
            }
            else
            {
               tableName.Append(" and datediff(day,C.StartDate,getdate())>=0 ");
            }

            if (search.OutDate.HasValue)
            {
               tableName.AppendFormat(" and datediff(day,C.EndDate,'{0}')<=0 ", search.OutDate.Value);
            }
            else
            {
               tableName.Append(" and datediff(day,C.EndDate,getdate())<=0 ");
            }
         }

         tableName.Append(" where B.IsDelete='0' ");

         if (search != null)
         {
            if (!string.IsNullOrEmpty(search.HotelId))
            {
               tableName.AppendFormat(" and B.HotelId='{0}' ", search.HotelId);
            }

            if (!string.IsNullOrEmpty(search.RoomName))
            {
               tableName.AppendFormat(" and B.RoomName like '%{0}%' ", search.RoomName);
            }
            if (!string.IsNullOrEmpty(search.HotelName))
            {
               tableName.AppendFormat(
                   " and exists (select 1 from tbl_Hotel where tbl_Hotel.HotelId = B.HotelId and tbl_Hotel.HotelName like '%{0}%' ) ",
                   search.HotelName);
            }

            if (search.RoomStatus.HasValue)
            {
               tableName.AppendFormat(" and B.RoomStatus={0} ", (int)search.RoomStatus.Value);
            }
         }

         string fields = " * ";


         string orderByString = " IssueTime desc ";

         string query = null;

         using (IDataReader dr = DbHelper.ExecuteReader2(this._db, pageSize, pageIndex, ref recordCount, tableName.ToString(), fields, query, orderByString, null))
         {
            while (dr.Read())
            {
               EyouSoft.Model.HotelStructure.MHotelRoomType model = new EyouSoft.Model.HotelStructure.MHotelRoomType();
               model.RoomTypeId = dr.GetString(dr.GetOrdinal("RoomTypeId"));
               model.HotelId = dr.GetString(dr.GetOrdinal("HotelId"));
               model.RoomName = !dr.IsDBNull(dr.GetOrdinal("RoomName")) ? dr.GetString(dr.GetOrdinal("RoomName")) : null;
               model.TotalNumber = dr.GetInt32(dr.GetOrdinal("TotalNumber"));
               model.RoomType = (EyouSoft.Model.Enum.RoomType)dr.GetByte(dr.GetOrdinal("RoomType"));
               model.RoomArea = !dr.IsDBNull(dr.GetOrdinal("RoomArea")) ? dr.GetString(dr.GetOrdinal("RoomArea")) : null;
               model.Floor = !dr.IsDBNull(dr.GetOrdinal("Floor")) ? dr.GetString(dr.GetOrdinal("Floor")) : null;
               model.BedType = (EyouSoft.Model.Enum.BedType)dr.GetByte(dr.GetOrdinal("BedType"));
               model.BedTypeDescription = !dr.IsDBNull(dr.GetOrdinal("BedTypeDescription")) ? dr.GetString(dr.GetOrdinal("BedTypeDescription")) : "";
               model.InterfaceID = !dr.IsDBNull(dr.GetOrdinal("InterfaceID")) ? dr.GetString(dr.GetOrdinal("InterfaceID")) : "";
               model.BedHeight = dr.GetDecimal(dr.GetOrdinal("BedHeight"));
               model.BedWidth = dr.GetDecimal(dr.GetOrdinal("BedWidth"));
               model.MaxGuestNum = dr.GetInt32(dr.GetOrdinal("MaxGuestNum"));
               model.IsSmoking = dr.GetString(dr.GetOrdinal("IsSmoking")) == "1";
               model.IsInternet = (EyouSoft.Model.Enum.IsInternet)dr.GetByte(dr.GetOrdinal("IsInternet"));
               model.IsInternetPrice = dr.GetDecimal(dr.GetOrdinal("IsInternetPrice"));
               model.Orientation = (EyouSoft.Model.Enum.Orientation)dr.GetByte(dr.GetOrdinal("Orientation"));
               model.IsBreakfast = (EyouSoft.Model.Enum.IsBreakfast)dr.GetByte(dr.GetOrdinal("IsBreakfast"));
               model.IsBreakfastPrice = dr.GetDecimal(dr.GetOrdinal("IsBreakfastPrice"));
               model.IsWindow = (EyouSoft.Model.Enum.IsWindow)dr.GetByte(dr.GetOrdinal("IsWindow"));
               model.IsAddBed = (EyouSoft.Model.Enum.IsAddBed)dr.GetByte(dr.GetOrdinal("IsAddBed"));
               model.IsAddBedPrice = dr.GetDecimal(dr.GetOrdinal("IsAddBedPrice"));
               model.Payment = (EyouSoft.Model.Enum.Payment)dr.GetByte(dr.GetOrdinal("Payment"));
               model.Desc = !dr.IsDBNull(dr.GetOrdinal("Desc")) ? dr.GetString(dr.GetOrdinal("Desc")) : null;
               model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
               model.OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"));
               model.SortId = dr.GetInt32(dr.GetOrdinal("SortId"));
               model.RoomStatus = (EyouSoft.Model.Enum.RoomStatus)dr.GetByte(dr.GetOrdinal("RoomStatus"));

               model.AmountPrice = dr.GetDecimal(dr.GetOrdinal("AmountPrice"));
               model.PreferentialPrice = dr.GetDecimal(dr.GetOrdinal("PreferentialPrice"));
               model.SettlementPrice = dr.GetDecimal(dr.GetOrdinal("SettlementPrice"));

               model.HotelName = !dr.IsDBNull(dr.GetOrdinal("HotelName")) ? dr.GetString(dr.GetOrdinal("HotelName")) : string.Empty;

               list.Add(model);
            }
         }

         return list;


      }

      #endregion

      #region 房型价格

      /// <summary>
      /// 添加房型价格
      /// </summary>
      /// <param name="model"></param>
      /// <returns>
      /// -1:开始时间已存在价格
      /// -2:结束时间已存在价格
      ///  1:成功
      ///  0:失败
      /// </returns>
      public int AddHotelRoomRate(EyouSoft.Model.HotelStructure.MHotelRoomRate model)
      {
         DbCommand cmd = this._db.GetStoredProcCommand("proc_HotelRoomRate_Add");
         this._db.AddInParameter(cmd, "HotelId", DbType.AnsiStringFixedLength, model.HotelId);
         this._db.AddInParameter(cmd, "RoomTypeId", DbType.AnsiStringFixedLength, model.RoomTypeId);
         this._db.AddInParameter(cmd, "AmountPrice", DbType.Currency, model.AmountPrice);
         this._db.AddInParameter(cmd, "PreferentialPrice", DbType.Currency, model.PreferentialPrice);
         this._db.AddInParameter(cmd, "SettlementPrice", DbType.Currency, model.SettlementPrice);
         this._db.AddInParameter(cmd, "StartDate", DbType.DateTime, model.StartDate);
         this._db.AddInParameter(cmd, "EndDate", DbType.DateTime, model.EndDate);
         this._db.AddInParameter(cmd, "Reason", DbType.String, model.Reason);
         this._db.AddInParameter(cmd, "OperatorId", DbType.Int32, model.OperatorId);
         this._db.AddInParameter(cmd, "ShengYuShuLiang", DbType.Int32, model.ShengYuShuLiang);
         this._db.AddInParameter(cmd, "ShuLiang", DbType.Int32, model.ShuLiang);
         this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);

         DbHelper.RunProcedureWithResult(cmd, this._db);
         return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result"));
      }

      /// <summary>
      /// 修改房型价格
      /// </summary>
      /// <param name="model"></param>
      /// <returns>
      /// -1:开始时间已存在价格
      /// -2:结束时间已存在价格
      /// -3:存在订单不允许修改
      ///  1:成功
      ///  0:失败
      /// </returns>
      public int UpdateHotelRoomRate(EyouSoft.Model.HotelStructure.MHotelRoomRate model)
      {
         DbCommand cmd = this._db.GetStoredProcCommand("proc_HotelRoomRate_Update");
         this._db.AddInParameter(cmd, "RoomRateId", DbType.Int32, model.RoomRateId);
         this._db.AddInParameter(cmd, "HotelId", DbType.AnsiStringFixedLength, model.HotelId);
         this._db.AddInParameter(cmd, "RoomTypeId", DbType.AnsiStringFixedLength, model.RoomTypeId);
         this._db.AddInParameter(cmd, "AmountPrice", DbType.Currency, model.AmountPrice);
         this._db.AddInParameter(cmd, "PreferentialPrice", DbType.Currency, model.PreferentialPrice);
         this._db.AddInParameter(cmd, "SettlementPrice", DbType.Currency, model.SettlementPrice);
         this._db.AddInParameter(cmd, "StartDate", DbType.DateTime, model.StartDate);
         this._db.AddInParameter(cmd, "EndDate", DbType.DateTime, model.EndDate);
         this._db.AddInParameter(cmd, "Reason", DbType.String, model.Reason);
         this._db.AddInParameter(cmd, "OperatorId", DbType.Int32, model.OperatorId);
         this._db.AddInParameter(cmd, "ShengYuShuLiang", DbType.Int32, model.ShengYuShuLiang);
         this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);
         _db.AddInParameter(cmd, "ShuLiang", DbType.Int32, model.ShuLiang);

         DbHelper.RunProcedureWithResult(cmd, this._db);
         return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result"));
      }

      /// <summary>
      /// 删除房型价格
      /// </summary>
      /// <param name="RoomRateId"></param>
      /// <returns>
      ///  -1:存在订单不允许修改
      ///  1:成功
      ///  0:失败
      /// </returns>
      public int DeleteHotelRoomRate(int RoomRateId)
      {
         DbCommand cmd = this._db.GetStoredProcCommand("proc_HotelRoomRate_Delete");
         this._db.AddInParameter(cmd, "RoomRateId", DbType.Int32, RoomRateId);
         this._db.AddOutParameter(cmd, "Result", DbType.Int32, 4);

         DbHelper.RunProcedureWithResult(cmd, this._db);
         return Convert.ToInt32(this._db.GetParameterValue(cmd, "Result"));

      }

      /// <summary>
      /// 获取房型价格的实体
      /// </summary>
      /// <param name="RoomRateId"></param>
      /// <returns></returns>
      public EyouSoft.Model.HotelStructure.MHotelRoomRate GetHotelRoomRateModel(string RoomRateId)
      {
         EyouSoft.Model.HotelStructure.MHotelRoomRate model = null;

         string sql = "select *,(SELECT SUM(A1.RoomCount) FROM tbl_HotelOrder AS A1 WHERE A1.JiaGeId=A.RoomRateId AND A1.OrderState IN(0,3,4,5)) AS YiYuDingShuLiang from tbl_HotelRoomRate AS A where A.RoomRateId=@RoomRateId";

         DbCommand cmd = this._db.GetSqlStringCommand(sql);
         this._db.AddInParameter(cmd, "RoomRateId", DbType.Int32, RoomRateId);

         using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
         {
            while (dr.Read())
            {
               model = new EyouSoft.Model.HotelStructure.MHotelRoomRate();

               model.RoomRateId = dr.GetInt32(dr.GetOrdinal("RoomRateId"));
               model.HotelId = dr.GetString(dr.GetOrdinal("HotelId"));
               model.RoomTypeId = dr.GetString(dr.GetOrdinal("RoomTypeId"));
               model.AmountPrice = dr.GetDecimal(dr.GetOrdinal("AmountPrice"));
               model.PreferentialPrice = dr.GetDecimal(dr.GetOrdinal("PreferentialPrice"));
               model.SettlementPrice = dr.GetDecimal(dr.GetOrdinal("SettlementPrice"));
               model.StartDate = dr.GetDateTime(dr.GetOrdinal("StartDate"));
               model.EndDate = dr.GetDateTime(dr.GetOrdinal("EndDate"));
               model.Reason = !dr.IsDBNull(dr.GetOrdinal("Reason")) ? dr.GetString(dr.GetOrdinal("Reason")) : null;
               model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
               model.OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"));
               model.ShuLiang = dr.GetInt32(dr.GetOrdinal("ShuLiang"));
               if (!dr.IsDBNull(dr.GetOrdinal("ShengYuShuLiang"))) model.ShengYuShuLiang = dr.GetInt32(dr.GetOrdinal("ShengYuShuLiang"));
               model.RoomType = EyouSoft.Model.Enum.RoomType.其它;
            }
         }
         return model;

      }

      /// <summary>
      /// 根据房型编号获取房型的价格
      /// </summary>
      /// <param name="RoomTypeId"></param>
      /// <returns></returns>
      public IList<EyouSoft.Model.HotelStructure.MHotelRoomRate> GetHotelRoomRateList(string HotelId, string RoomTypeId)
      {
         IList<EyouSoft.Model.HotelStructure.MHotelRoomRate> list = new List<EyouSoft.Model.HotelStructure.MHotelRoomRate>();

         string sql = "select *,(SELECT SUM(A1.RoomCount) FROM tbl_HotelOrder AS A1 WHERE A1.JiaGeId=A.RoomRateId AND A1.OrderState IN(0,3,4,5)) AS YiYuDingShuLiang  from tbl_HotelRoomRate AS A where A.HotelId=@HotelId and  A.RoomTypeId=@RoomTypeId";

         DbCommand cmd = this._db.GetSqlStringCommand(sql);
         this._db.AddInParameter(cmd, "HotelId", DbType.AnsiStringFixedLength, HotelId);
         this._db.AddInParameter(cmd, "RoomTypeId", DbType.AnsiStringFixedLength, RoomTypeId);

         using (IDataReader dr = DbHelper.ExecuteReader(cmd, this._db))
         {
            while (dr.Read())
            {
               EyouSoft.Model.HotelStructure.MHotelRoomRate model = new EyouSoft.Model.HotelStructure.MHotelRoomRate();

               model.RoomRateId = dr.GetInt32(dr.GetOrdinal("RoomRateId"));
               model.HotelId = dr.GetString(dr.GetOrdinal("HotelId"));
               model.RoomTypeId = dr.GetString(dr.GetOrdinal("RoomTypeId"));
               model.AmountPrice = dr.GetDecimal(dr.GetOrdinal("AmountPrice"));
               model.PreferentialPrice = dr.GetDecimal(dr.GetOrdinal("PreferentialPrice"));
               model.SettlementPrice = dr.GetDecimal(dr.GetOrdinal("SettlementPrice"));
               model.StartDate = dr.GetDateTime(dr.GetOrdinal("StartDate"));
               model.EndDate = dr.GetDateTime(dr.GetOrdinal("EndDate"));
               model.Reason = !dr.IsDBNull(dr.GetOrdinal("Reason")) ? dr.GetString(dr.GetOrdinal("Reason")) : null;
               model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
               model.OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"));
               model.ShuLiang = dr.GetInt32(dr.GetOrdinal("ShuLiang"));
               if (!dr.IsDBNull(dr.GetOrdinal("ShengYuShuLiang"))) model.ShengYuShuLiang = dr.GetInt32(dr.GetOrdinal("ShengYuShuLiang"));

               list.Add(model);
            }
         }
         return list;
      }

      /// <summary>
      /// 获取价格的分页列表
      /// </summary>
      /// <param name="pageSize"></param>
      /// <param name="pageIndex"></param>
      /// <param name="RecordCount"></param>
      /// <returns></returns>
      public IList<EyouSoft.Model.HotelStructure.MHotelRoomRate> GetHotelRoomRateList(int pageSize, int pageIndex, ref int RecordCount, EyouSoft.Model.HotelStructure.MHotelRoomRateSearch search)
      {
         IList<EyouSoft.Model.HotelStructure.MHotelRoomRate> list = new List<EyouSoft.Model.HotelStructure.MHotelRoomRate>();

         string tableName = "view_HotelRoomRate";

         StringBuilder fileds = new StringBuilder();
         fileds.Append(" RoomRateId,HotelId,RoomTypeId,AmountPrice,PreferentialPrice,SettlementPrice,ShengYuShuLiang ");
         fileds.Append(" ,StartDate,EndDate,Reason,IssueTime,OperatorId,RoomName,RoomType,HotelName,OperatorName ");
         fileds.Append(",ShuLiang,YiYuDingShuLiang");

         string orderByString = " IssueTime desc ";

         StringBuilder query = new StringBuilder(" 1=1 ");


         if (search != null)
         {
            if (!string.IsNullOrEmpty(search.HotelId))
            {
               query.AppendFormat(" and HotelId='{0}' ", search.HotelId);
            }
            if (!string.IsNullOrEmpty(search.RoomName))
            {
               query.AppendFormat(" and RoomName  like '%{0}%' ", search.RoomName);
            }
            if (search.RoomType.HasValue)
            {
               query.AppendFormat(" and RoomType={0} ", (int)search.RoomType.Value);
            }

            if (search.StartDate.HasValue)
            {
               query.AppendFormat(" and datediff(day,StartDate,'{0}')>=0 ", search.StartDate.Value);
            }

            if (search.EndDate.HasValue)
            {
               query.AppendFormat(" and datediff(day,EndDate,'{0}')<=0 ", search.EndDate.Value);
            }

         }

         using (IDataReader dr = DbHelper.ExecuteReader1(this._db, pageSize, pageIndex, ref RecordCount, tableName, fileds.ToString(), query.ToString(), orderByString, null))
         {
            while (dr.Read())
            {
               EyouSoft.Model.HotelStructure.MHotelRoomRate model = new EyouSoft.Model.HotelStructure.MHotelRoomRate();
               model.RoomRateId = dr.GetInt32(dr.GetOrdinal("RoomRateId"));
               model.HotelId = dr.GetString(dr.GetOrdinal("HotelId"));
               model.HotelName = !dr.IsDBNull(dr.GetOrdinal("HotelName")) ? dr.GetString(dr.GetOrdinal("HotelName")) : null;
               model.RoomTypeId = dr.GetString(dr.GetOrdinal("RoomTypeId"));
               model.RoomName = !dr.IsDBNull(dr.GetOrdinal("RoomName")) ? dr.GetString(dr.GetOrdinal("RoomName")) : null;
               model.RoomType = (EyouSoft.Model.Enum.RoomType)dr.GetByte(dr.GetOrdinal("RoomType"));
               model.AmountPrice = dr.GetDecimal(dr.GetOrdinal("AmountPrice"));
               model.PreferentialPrice = dr.GetDecimal(dr.GetOrdinal("PreferentialPrice"));
               model.SettlementPrice = dr.GetDecimal(dr.GetOrdinal("SettlementPrice"));
               model.StartDate = dr.GetDateTime(dr.GetOrdinal("StartDate"));
               model.EndDate = dr.GetDateTime(dr.GetOrdinal("EndDate"));
               model.Reason = !dr.IsDBNull(dr.GetOrdinal("Reason")) ? dr.GetString(dr.GetOrdinal("Reason")) : null;
               model.IssueTime = dr.GetDateTime(dr.GetOrdinal("IssueTime"));
               model.OperatorId = dr.GetInt32(dr.GetOrdinal("OperatorId"));
               model.OperatorName = !dr.IsDBNull(dr.GetOrdinal("OperatorName")) ? dr.GetString(dr.GetOrdinal("OperatorName")) : null;
               model.ShuLiang = dr.GetInt32(dr.GetOrdinal("ShuLiang"));
               if (!dr.IsDBNull(dr.GetOrdinal("ShengYuShuLiang"))) model.ShengYuShuLiang = dr.GetInt32(dr.GetOrdinal("ShengYuShuLiang"));

               list.Add(model);
            }
         }

         return list;
      }

      #endregion

      #region private xml
      /// <summary>
      /// 创建酒店房型图片的xml
      /// </summary>
      /// <param name="list"></param>
      /// <returns></returns>
      private string CreateXml(IList<EyouSoft.Model.HotelStructure.MHotelRoomImg> list)
      {
         if (list == null || list.Count == 0) return null;

         StringBuilder xmlDoc = new StringBuilder();
         xmlDoc.Append("<Root>");
         foreach (EyouSoft.Model.HotelStructure.MHotelRoomImg model in list)
         {
            xmlDoc.Append("<HotelRoomImg ");
            xmlDoc.AppendFormat("FilePath=\"{0}\" ", model.FilePath);
            xmlDoc.AppendFormat("Desc=\"{0}\" ", model.Desc);
            xmlDoc.Append(" />");
         }
         xmlDoc.Append("</Root>");
         return xmlDoc.ToString();
      }

      /// <summary>
      /// 获取酒店图片的集合
      /// </summary>
      /// <returns></returns>
      private IList<EyouSoft.Model.HotelStructure.MHotelRoomImg> GetHotelRoomImgList(string xml)
      {
         if (string.IsNullOrEmpty(xml)) return null;
         IList<EyouSoft.Model.HotelStructure.MHotelRoomImg> list = new List<EyouSoft.Model.HotelStructure.MHotelRoomImg>();
         System.Xml.Linq.XElement xRoot = System.Xml.Linq.XElement.Parse(xml);
         var xRows = Utils.GetXElements(xRoot, "row");
         foreach (var xRow in xRows)
         {
            EyouSoft.Model.HotelStructure.MHotelRoomImg item = new EyouSoft.Model.HotelStructure.MHotelRoomImg()
            {
               RoomImgId = Utils.GetInt(Utils.GetXAttributeValue(xRow, "RoomImgId")),
               FilePath = Utils.GetXAttributeValue(xRow, "FilePath"),
               Desc = Utils.GetXAttributeValue(xRow, "Desc")
            };

            list.Add(item);
         }
         return list;
      }

      #endregion
   }
}
