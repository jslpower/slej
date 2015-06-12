using System;
using System.Collections.Generic;
using EyouSoft.IDAL.HotelStructure.Interface;
using EyouSoft.IDAL.HotelStructure;
using EyouSoft.DAL.HotelStructure;
using EyouSoft.DAL.HotelStructure.Interface;
using EyouSoft.Model.HotelStructure;
using EyouSoft.Common;
using EyouSoft.Model.Enum;
using EyouSoft.Model.HotelStructure.Interface;
using Linq.Expressions;
using System.IO;
using System.Threading;
using System.Data.Common;

namespace ConsoleApp_HotelDataImporter
{
   public class HotelDataImporter
   {
      /// <summary>
      /// 秒
      /// </summary>
      public static int commandTimeout = 60 * 60;

      IDHotel_HotelInfo dal = new DHotel_HotelInfo { CommandTimeOut = commandTimeout };
      IDHotel2 dal2 = new DHotel2 { CommandTimeOut = commandTimeout };
      IDHotelImg dalImg = new DHotelImg { CommandTimeOut = commandTimeout };
      IDHotelRoomType2 dalRoomType = new DHotelRoomType2 { CommandTimeOut = commandTimeout };
      IDHotel_RoomType dalInterfaceRoomType = new DHotel_RoomType { CommandTimeOut = commandTimeout };
      IDHotelRoomRate dalRoomRate = new DHotelRoomRate { CommandTimeOut = commandTimeout };
      IDHotel_RoomRate dalInterfaceRoomRate = new DHotel_RoomRate { CommandTimeOut = commandTimeout };

      public Action<object> Action { get; set; }
      public Action<object> Action2 { get; set; }
      public Action<int> Action3 { get; set; }
      private void Act(object state)
      {
         if (Action != null)
         {
            Action(state);
         }
      }
      private void Act2(object state)
      {
         if (Action2 != null)
         {
            Action2(state);
         }
      }
      private void ReportPrecent(int percent)
      {
         if (Action3 != null)
         {
            Action3(percent);
         }
      }
      public static void log(string msg)
      {
         if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "errorlog"))
         {
            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "errorlog");
         }
         File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "errorlog\\jd_errorlog_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt", "\r\n错误：" + msg);
      }
      List<string> sqls_hotel = new List<string>(70000);
      List<string> sqls_roomType = new List<string>(500000);
      List<string> sqls_roomRate = new List<string>(5000000);

      /// <summary>
      /// 将缓存的酒店数据转入到项目的酒店表
      /// </summary>
      /// <param name="Model"></param>
      /// <returns></returns>
      public bool AddOrUpdateHotel()
      {
         bool flag = true;
         DbDataReader reader = null;
         try
         {
            Act2("开始读取酒店缓存,这可能要花费几分钟,请稍候...");
            List<Hotel_HotelInfo> cacheData = new List<Hotel_HotelInfo>(70000);
            reader = dal.ExecuteReader("select * from Hotel_HotelInfo");
            Act2("开始读取列表...");
            while (reader.Read())
            {
               Hotel_HotelInfo model = new Hotel_HotelInfo();
               object o = reader["BRAND_CODE"];
               object o2 = reader["CITY_CODE"];
               object o3 = reader["COUNTRY_CODE"];
               object o4 = reader["DISTRICT"];
               object o5 = reader["FAX"];
               object o6 = reader["FIX_MENT"];
               object o7 = reader["FLOOR"];
               object o8 = reader["HOTEL_ADDRESS"];
               object o9 = reader["HOTEL_NAMECN"];
               object o10 = reader["HOTEL_NAMEEN"];
               object o11 = reader["IMG_DT"];
               object o12 = reader["IMG_KF"];
               object o13 = reader["IMG_WJ"];
               object o14 = reader["LATITUDE"];
               object o15 = reader["LONG_DESC"];
               object o16 = reader["LONGITUDE"];
               object o17 = reader["OPEN_DATE"];
               object o18 = reader["POSTAL_CODE"];
               object o19 = reader["PROVINCE"];
               object o20 = reader["RANK_CODE"];
               object o21 = reader["ROOM_QUANTITY"];
               object o22 = reader["STATUS"];
               object o23 = reader["TEL"];

               model.BRAND_CODE = o == DBNull.Value ? "" : o.ToString();
               model.CITY_CODE = o2 == DBNull.Value ? "" : o2.ToString();
               model.COUNTRY_CODE = o3 == DBNull.Value ? "" : o3.ToString();
               model.DISTRICT = o4 == DBNull.Value ? "" : o4.ToString();
               model.FAX = o5 == DBNull.Value ? "" : o5.ToString();
               model.FIX_MENT = o6 == DBNull.Value ? "" : o6.ToString();
               model.FLOOR = o7 == DBNull.Value ? "" : o7.ToString();
               model.HOTEL_ADDRESS = o8 == DBNull.Value ? "" : o8.ToString();
               model.HOTEL_CODE = reader["HOTEL_CODE"].ToString();
               model.HOTEL_NAMECN = o9 == DBNull.Value ? "" : o9.ToString();
               model.HOTEL_NAMEEN = o10 == DBNull.Value ? "" : o10.ToString();
               model.IMG_DT = o11 == DBNull.Value ? "" : o11.ToString();
               model.IMG_KF = o12 == DBNull.Value ? "" : o12.ToString();
               model.IMG_WJ = o13 == DBNull.Value ? "" : o13.ToString();
               model.LATITUDE = o14 == DBNull.Value ? "" : o14.ToString();
               model.LONG_DESC = o15 == DBNull.Value ? "" : o15.ToString();
               model.LONGITUDE = o16 == DBNull.Value ? "" : o16.ToString();
               model.OPEN_DATE = o17 == DBNull.Value ? "" : o17.ToString();
               model.POSTAL_CODE = o18 == DBNull.Value ? "" : o18.ToString();
               model.PROVINCE = o19 == DBNull.Value ? "" : o19.ToString();
               model.RANK_CODE = o20 == DBNull.Value ? "" : o20.ToString();
               model.ROOM_QUANTITY = o21 == DBNull.Value ? "" : o21.ToString();
               model.STATUS = o22 == DBNull.Value ? "" : o22.ToString();
               model.TEL = o23 == DBNull.Value ? "" : o23.ToString();

               cacheData.Add(model);
            }
            reader.Close();
            Act2("酒店读取完毕，酒店缓存条数:" + cacheData.Count);
            Thread.Sleep(3000);
            Act2("开始获取酒店更新数据,这可能要花费几分钟,请稍等...");
            Thread.Sleep(3000);
            var tbl_hotelQuery = new QueryExpressionBuilder<MHotel2>();
            for (int i = 0, len = cacheData.Count; i < len; i++)
            {

               MHotel2 hotel = null;
               DbDataReader reader22 = null;
               try
               {
                  bool isAdd = false;
                  Hotel_HotelInfo item = cacheData[i];
                  reader22 = dal2.ExecuteReader("select Address,Fitment,Floor,HotelId,HotelCode,HotelName,HotelNameEn,InterfaceId,IssueTime,Latitude,LongDesc,Longitude,Mobile,OpenDate,PostalCode,RoomQuantity,ServiceTel,Star from tbl_hotel where interfaceid='" + item.HOTEL_CODE + "'");
                  if (reader22.Read())
                  {
                     hotel = new MHotel2();
                     object o = reader22["Address"];
                     object o1 = reader22["Fitment"];
                     object o2 = reader22["Floor"];
                     object o4 = reader22["HotelCode"];
                     object o5 = reader22["HotelName"];
                     object o6 = reader22["HotelNameEn"];
                     object o7 = reader22["InterfaceId"];
                     object o8 = reader22["IssueTime"];
                     object o9 = reader22["Latitude"];
                     object o10 = reader22["LongDesc"];
                     object o11 = reader22["Longitude"];
                     object o12 = reader22["Mobile"];
                     object o13 = reader22["OpenDate"];
                     object o14 = reader22["PostalCode"];
                     object o15 = reader22["RoomQuantity"];
                     object o16 = reader22["ServiceTel"];
                     object o17 = reader22["Star"];

                     hotel.AdditionalCost = "0";
                     hotel.Address = o == DBNull.Value ? "" : o.ToString();
                     hotel.CityCode = item.CITY_CODE;
                     hotel.CityId = 0;
                     hotel.CountyId = 0;
                     hotel.EnAddress = "";
                     hotel.Fitment = o1 == DBNull.Value ? "" : o1.ToString();
                     hotel.Floor = o2 == DBNull.Value ? "" : o2.ToString();
                     hotel.HotelId = reader22["HotelId"].ToString();
                     hotel.HotelCode = o4 == DBNull.Value ? "" : o4.ToString();
                     hotel.HotelName = o5 == DBNull.Value ? "" : o5.ToString();
                     hotel.HotelNameEn = o6 == DBNull.Value ? "" : o6.ToString();
                     hotel.InterfaceId = o7 == DBNull.Value ? "" : o7.ToString();
                     hotel.IsDelete = "0";
                     hotel.IsHot = "1";
                     hotel.IsRecommend = "1";
                     hotel.IssueTime = o8 == DBNull.Value ? DateTime.Now.AddYears(-1) : (DateTime)o8;
                     hotel.JieSuanType = "0";//现结
                     hotel.Latitude = o9 == DBNull.Value ? "" : o9.ToString();
                     hotel.LongDesc = o10 == DBNull.Value ? "" : o10.ToString();
                     hotel.Longitude = o11 == DBNull.Value ? "" : o11.ToString();
                     hotel.Mobile = o12 == DBNull.Value ? "" : o12.ToString();
                     hotel.OpenDate = o13 == DBNull.Value ? "" : o13.ToString();
                     hotel.OperatorId = 0;
                     hotel.PostalCode = o14 == DBNull.Value ? "" : o14.ToString();
                     hotel.ProvinceId = 0;
                     hotel.RoomQuantity = o15 == DBNull.Value ? 0 : (int)o15;
                     hotel.ServiceTel = o16 == DBNull.Value ? "" : o16.ToString();
                     hotel.Star = o17 == DBNull.Value ? HotelStar.二星级以下 : (HotelStar)(byte)o17;
                     hotel.Status = HotelStatus.正常;
                  }
                  reader22.Close();
                  if (hotel == null)
                  {
                     hotel = new MHotel2();
                     hotel.HotelId = Guid.NewGuid().ToString();
                     isAdd = true;
                  }
                  else
                  {
                     if (
                          hotel.Address == item.HOTEL_ADDRESS
                         && hotel.CityCode == item.CITY_CODE
                         && hotel.Fitment == item.FIX_MENT
                         && hotel.Floor == item.FLOOR
                         && hotel.HotelName == item.HOTEL_NAMECN
                         && hotel.HotelNameEn == item.HOTEL_NAMEEN
                         && hotel.InterfaceId == item.HOTEL_CODE
                         && hotel.Latitude == item.LATITUDE
                         && hotel.LongDesc == item.LONG_DESC
                         && hotel.Longitude == item.LONGITUDE
                         && hotel.Mobile == item.TEL
                         && hotel.OpenDate == item.OPEN_DATE
                         && hotel.PostalCode == item.POSTAL_CODE
                         && hotel.RoomQuantity == Utils.GetInt(item.ROOM_QUANTITY, 0)
                         && hotel.ServiceTel == item.TEL
                         && hotel.Star == (string.IsNullOrEmpty(item.RANK_CODE) ? new Nullable<HotelStar>() : (HotelStar)((int)Enum.Parse(typeof(Hotel_HotelInfoQueryModel.Star), "_" + item.RANK_CODE)))
                        )
                     {
                        Act("酒店：" + hotel.HotelName + "将跳过更新操作,无须更新.");
                        goto NextImg;
                     }
                     else
                     {
                        isAdd = false;
                     }
                  }

                  hotel.AdditionalCost = "0";
                  hotel.Address = item.HOTEL_ADDRESS;
                  hotel.CityCode = item.CITY_CODE;
                  hotel.CityId = 0;
                  hotel.CountyId = 0;
                  hotel.EnAddress = "";
                  hotel.Fitment = item.FIX_MENT;
                  hotel.Floor = item.FLOOR;
                  hotel.HotelCode = item.HOTEL_CODE;
                  hotel.HotelName = item.HOTEL_NAMECN;
                  hotel.HotelNameEn = item.HOTEL_NAMEEN;
                  hotel.InterfaceId = item.HOTEL_CODE;
                  hotel.IsDelete = "0";
                  hotel.IsHot = "1";
                  hotel.IsRecommend = "1";
                  hotel.IssueTime = DateTime.Now;
                  hotel.JieSuanType = "0"; //现结
                  hotel.Latitude = item.LATITUDE;
                  hotel.LongDesc = item.LONG_DESC;
                  hotel.Longitude = item.LONGITUDE;
                  hotel.Mobile = item.TEL;
                  hotel.OpenDate = item.OPEN_DATE;
                  hotel.OperatorId = 0;
                  hotel.PostalCode = item.POSTAL_CODE;
                  hotel.ProvinceId = 0;
                  hotel.RoomQuantity = Utils.GetInt(item.ROOM_QUANTITY, 0);
                  hotel.ServiceTel = item.TEL;
                  hotel.Star = string.IsNullOrEmpty(item.RANK_CODE) ? new Nullable<HotelStar>() : (HotelStar)((int)Enum.Parse(typeof(Hotel_HotelInfoQueryModel.Star), "_" + item.RANK_CODE));
                  hotel.Status = HotelStatus.正常;
                  hotel.Transport = "";
                  if (isAdd)
                  {
                     sqls_hotel.Add(tbl_hotelQuery.bisql(hotel));
                     Act("将要新增酒店：" + hotel.HotelName + "," + hotel.HotelId);
                  }
                  else
                  {
                     sqls_hotel.Add(tbl_hotelQuery.busql(hotel));
                     Act("将要更新酒店：" + hotel.HotelName + "," + hotel.HotelId);
                  }
               NextImg:

                  sqls_hotel.Add(string.Format("delete from tbl_HotelImg where HotelId='{0}'", hotel.HotelId));
                  MHotelImg image = new MHotelImg();
                  image.HotelId = hotel.HotelId;
                  image.ImgCategory = HotelImgType.酒店形象照片;
                  image.IssueTime = hotel.IssueTime;
                  image.OperatorId = "0";
                  //1
                  if (!string.IsNullOrEmpty(item.IMG_WJ))
                  {
                     image.Desc = "外景图片";
                     image.FilePath = item.IMG_WJ;
                     sqls_hotel.Add(string.Format("insert into tbl_HotelImg (HotelId,ImgCategory,FilePath,[Desc],IssueTime,OperatorId) values('{0}',{1},'{2}','{3}','{4}','{5}')", image.HotelId, (int)image.ImgCategory, image.FilePath, image.Desc, image.IssueTime, "0"));
                  }

                  //2
                  if (!string.IsNullOrEmpty(item.IMG_DT))
                  {
                     image.Desc = "大厅图片";
                     image.FilePath = item.IMG_DT;
                     sqls_hotel.Add(string.Format("insert into tbl_HotelImg (HotelId,ImgCategory,FilePath,[Desc],IssueTime,OperatorId) values('{0}',{1},'{2}','{3}','{4}','{5}')", image.HotelId, (int)image.ImgCategory, image.FilePath, image.Desc, image.IssueTime, "0"));
                  }
                  //3
                  if (!string.IsNullOrEmpty(item.IMG_KF))
                  {
                     image.Desc = "客房图片";
                     image.FilePath = item.IMG_KF;
                     sqls_hotel.Add(string.Format("insert into tbl_HotelImg (HotelId,ImgCategory,FilePath,[Desc],IssueTime,OperatorId) values('{0}',{1},'{2}','{3}','{4}','{5}')", image.HotelId, (int)image.ImgCategory, image.FilePath, image.Desc, image.IssueTime, "0"));
                  }
                  Act("将要更新酒店" + hotel.HotelName + "," + hotel.HotelId + "的图片信息");
               }
               catch (Exception ex)
               {
                  if (reader22 != null)
                  {
                     reader22.Close();
                  }
                  log(ex.ToString() + ",酒店：" + hotel.HotelName);
                  flag = false;
               }
               finally
               {
                  ReportPrecent((int)(Math.Round((decimal)((decimal)i / cacheData.Count), 2) * 100));
               }
            }
            cacheData.Clear();
            cacheData = null;
            Act2("开始执行数据更新操作...,即将执行的sql的总数为：" + sqls_hotel.Count);
            Thread.Sleep(2000);
            using (dal2.BeginTransaction())
            {
               for (int i = 0, len = sqls_hotel.Count; i < len; i++)
               {
                  string sql = sqls_hotel[i];
                  try
                  {
                     dal2.ExecuteSqlNoQuery(sql);
                  }
                  catch (Exception ex)
                  {
                     log(ex.ToString() + ",sql:" + sql);
                     flag = false;
                  }
                  finally
                  {
                     ReportPrecent((int)(Math.Round((decimal)((decimal)i / len), 2) * 100));
                  }
               }
               dal2.Complete();
               Act2("酒店更新操作完成。");
            }
            return flag;
         }
         catch (Exception ex)
         {
            log(ex.ToString());
            return false;
         }
         finally
         {
            if (reader != null)
            {
               reader.Close();
            }
            sqls_hotel.Clear();
         }
      }

      /// <summary>
      /// 已处理过的房型
      /// </summary>
      Dictionary<string, string> HandledRoomTypes;
      /// <summary>
      /// 所有房型
      /// </summary>
      List<Hotel_RoomType> roomTypeListAll;
      /// <summary>
      /// 所有房型字典，加快查找
      /// </summary>
      Dictionary<string, Hotel_RoomType> roomtypedicsAll;
      /// <summary>
      /// 所有酒店字典，加快查找
      /// </summary>
      Dictionary<string, MHotel2> hoteldicsAll;
      /// <summary>
      /// 所有酒店
      /// </summary>
      List<MHotel2> hotelListAll = new List<MHotel2>(70000);


      /// <summary>
      /// 新增或更新房型和价格计划
      /// </summary>
      public bool AddOrUpdateRoomTypeAndRoomRate()
      {
        string swTYPE_PATH = AppDomain.CurrentDomain.BaseDirectory + "TYPE_" + DateTime.Now.ToString("yyyyMMdd") + ".log";
        string swRATE_PATH = AppDomain.CurrentDomain.BaseDirectory + "RATE_" + DateTime.Now.ToString("yyyyMMdd") + ".log";
        StreamWriter swTYPE = new StreamWriter(swTYPE_PATH,true);
        StreamWriter swRATE = new StreamWriter(swRATE_PATH,true);
          
         bool flag = true;

         DbDataReader reader3 = null;
         DbDataReader reader2 = null;
         DbDataReader reader = null;


         try
         {
            //取所有酒店
            Act2("取酒店数据中,这可能要花费几分钟,请稍候...");
            reader = dal2.ExecuteReader("select HotelId,HotelName,InterfaceId,citycode from tbl_hotel where interfaceid is not null and interfaceid!=''");
            while (reader.Read())
            {
               MHotel2 model = new MHotel2();
               model.HotelId = reader["HotelId"].ToString();
               model.HotelName = reader["HotelName"].ToString();
               model.InterfaceId = reader["InterfaceId"].ToString();
               model.CityCode = reader["citycode"].ToString();
               hotelListAll.Add(model);
            }
            reader.Close();
            Act2("取酒店数据完毕，酒店总数：" + hotelListAll.Count);
            hoteldicsAll = new Dictionary<string, MHotel2>(hotelListAll.Count);
            Act2("建立酒店的数据字典...");
            for (int tr = 0; tr < hotelListAll.Count; tr++) //
            {
               MHotel2 rt = hotelListAll[tr];
               string key = rt.InterfaceId;
               if (!hoteldicsAll.ContainsKey(key))
               {
                  hoteldicsAll.Add(key, rt);
               }
            }
            roomtypedicsAll = new Dictionary<string, Hotel_RoomType>(hotelListAll.Count * 10);
            hotelListAll.Clear();
            hotelListAll = null;
            Act2("建立完毕...");
            Thread.Sleep(2000);
            //取所有房型
            Act2("取房型缓存中,这可能要花费几分钟,请稍候...");
            int count = (int)dalInterfaceRoomType.Count();
            roomTypeListAll = new List<Hotel_RoomType>(count);
            HandledRoomTypes = new Dictionary<string, string>(count);
            reader2 = dalInterfaceRoomType.ExecuteReader("select * from Hotel_RoomType");
            while (reader2.Read())
            {
               string o7 = reader2["HOTEL_CODE"].ToString();
               if (hoteldicsAll.ContainsKey(o7))
               {
                  Hotel_RoomType model2 = new Hotel_RoomType();
                  object o = reader2["BED_AREA"];
                  object o2 = reader2["BED_TYPE"];
                  object o3 = reader2["CATEGORY"];
                  object o4 = reader2["DESCP"];
                  object o5 = reader2["EN_INV_TYPE"];
                  object o6 = reader2["FLOOR"];
                  object o8 = reader2["INTERNET"];
                  object o9 = reader2["INV_STATUS"];
                  object o10 = reader2["INV_TYPE"];
                  object o11 = reader2["MAX_ADD_BED"];
                  object o12 = reader2["MAX_GUEST_NUM"];
                  object o13 = reader2["NO_SMOKING"];
                  object o14 = reader2["ROOM_AREA"];
                  object o15 = reader2["ROOM_TYPE_CODE"];
                  object o16 = reader2["ROOM_VIEW"];
                  object o17 = reader2["STATUS"];
                  object o18 = reader2["TOTAL_NUMBER"];

                  model2.BED_AREA = o == DBNull.Value ? "" : o.ToString();
                  model2.BED_TYPE = o2 == DBNull.Value ? "" : o2.ToString();
                  model2.CATEGORY = o3 == DBNull.Value ? "" : o3.ToString();
                  model2.DESCP = o4 == DBNull.Value ? "" : o4.ToString();
                  model2.EN_INV_TYPE = o5 == DBNull.Value ? "" : o5.ToString();
                  model2.FLOOR = o6 == DBNull.Value ? "" : o6.ToString();
                  model2.HOTEL_CODE = o7;
                  model2.INTERNET = o8 == DBNull.Value ? "" : o8.ToString();
                  model2.INV_STATUS = o9 == DBNull.Value ? "" : o9.ToString();
                  model2.INV_TYPE = o10 == DBNull.Value ? "" : o10.ToString();
                  model2.MAX_ADD_BED = o11 == DBNull.Value ? "0" : o11.ToString();
                  model2.MAX_GUEST_NUM = o12 == DBNull.Value ? "0" : o12.ToString();
                  model2.NO_SMOKING = o13 == DBNull.Value ? "" : o13.ToString();
                  model2.ROOM_AREA = o14 == DBNull.Value ? "" : o14.ToString();
                  model2.ROOM_TYPE_CODE = o15.ToString();
                  model2.ROOM_VIEW = o16 == DBNull.Value ? "" : o16.ToString();
                  model2.STATUS = o17 == DBNull.Value ? "0" : o17.ToString();
                  model2.TOTAL_NUMBER = o18 == DBNull.Value ? "0" : o18.ToString();
                  roomTypeListAll.Add(model2);
               }
            }
            reader2.Close();
            Act2("取房型缓存数据完毕，房型总数：" + roomTypeListAll.Count);
            Act2("建立所有房型的字典...");
            for (int tr = 0; tr < roomTypeListAll.Count; tr++) //
            {
               Hotel_RoomType rt = roomTypeListAll[tr];
               string key = rt.HOTEL_CODE + "$" + rt.ROOM_TYPE_CODE;
               if (!roomtypedicsAll.ContainsKey(key))
               {
                  roomtypedicsAll.Add(key, rt);
               }
            }
            Act2("建立完毕...");
            roomTypeListAll.Clear();
            roomTypeListAll = null;
            GC.CollectionCount(0);
            Thread.Sleep(1000);

            Act2("取房价缓存总数量中,这可能要花费更多时间,请稍候...");
            string queryInterfaceRoomRateCountSql = "select count(1) from Hotel_RoomRate where PAYMENT_METHOD IN ('S','T') and END_DATE>='" + DateTime.Today.ToString("yyyy-MM-dd") +  "'";
            int rowcount = (int)dalInterfaceRoomRate.ExecuteSqlScalar(queryInterfaceRoomRateCountSql);
            int pagesize = 300000;
            int pagecount = (rowcount % pagesize == 0 ? (rowcount / pagesize) : (rowcount / pagesize + 1));
            Act2("房价总数据量：" + rowcount);
            Act2("每次取" + pagesize + "条房价，共取" + pagecount + "次");
            Act2("开始分页取缓存....");
            GC.CollectionCount(0);
            GC.CollectionCount(1);
            for (int pageindex = 1; pageindex <= pagecount; pageindex++)
            {
                List<Hotel_RoomRate> curRoomRateList = new List<Hotel_RoomRate>(100000);
               Dictionary<string, List<Hotel_RoomRate>> roomRateDic = new Dictionary<string, List<Hotel_RoomRate>>(200000);
               Dictionary<string, List<Hotel_RoomType>> roomTypeDic = new Dictionary<string, List<Hotel_RoomType>>(50000);
               List<Hotel_RoomType> curRoomTypeList = new List<Hotel_RoomType>();
               Dictionary<string, string> temp_hotelcode_roomcodes = new Dictionary<string, string>();
               try
               {
                  #region 取缓存
                  Act2("当前是第" + pageindex + "次取数据。");
                  string queryInterfaceRoomRate = "select rr.* from (select AMOUNT_PRICE,CURRENCY,DISPLAY_PRICE,END_DATE,FEE_PERCENT,FREE_MEAL,HOTEL_CODE,RATE_PLAN_CODE,RATE_PLAN_NAME,ROOM_TYPE_CODE,START_DATE,STATUS,VENDOR_CODE,row_number() over (order by TIME_STAMP) as rowNumber from Hotel_RoomRate where PAYMENT_METHOD IN ('S','T') and END_DATE>='" + DateTime.Today.ToString("yyyy-MM-dd") + "') rr where rr.rowNumber between " + (pagesize * (pageindex - 1) + 1) + " and " + (pagesize * pageindex);
                  Act2("开始取房价缓存,这可能需要10分钟左右的时间，请稍候....");
                  reader3 = dalInterfaceRoomRate.ExecuteReader(queryInterfaceRoomRate);
                  while (reader3.Read())
                  {
                     Hotel_RoomRate model3 = new Hotel_RoomRate();
                     object o = reader3["AMOUNT_PRICE"];
                     object o2 = reader3["CURRENCY"];
                     object o3 = reader3["DISPLAY_PRICE"];
                     object o4 = reader3["END_DATE"];
                     object o5 = reader3["FEE_PERCENT"];
                     object o6 = reader3["FREE_MEAL"];
                     object o7 = reader3["HOTEL_CODE"];
                     object o8 = reader3["RATE_PLAN_CODE"];
                     object o10 = reader3["RATE_PLAN_NAME"];
                     object o11 = reader3["ROOM_TYPE_CODE"];
                     object o12 = reader3["START_DATE"];
                     object o13 = reader3["STATUS"];
                     object o14 = reader3["VENDOR_CODE"];
                     model3.AMOUNT_PRICE = o == DBNull.Value ? "0" : o.ToString();
                     model3.CURRENCY = o2 == DBNull.Value ? "CNY" : o2.ToString();
                     model3.DISPLAY_PRICE = o3 == DBNull.Value ? "0" : o3.ToString();
                     model3.END_DATE = o4 == DBNull.Value ? "1991-01-01 00:00:01" : o4.ToString();
                     model3.FEE_PERCENT = o5 == DBNull.Value ? "0.0" : o5.ToString();
                     model3.FREE_MEAL = o6 == DBNull.Value ? "" : o6.ToString();
                     model3.HOTEL_CODE = o7.ToString();
                     model3.IS_SIGN = null;
                     model3.LOAD_TIME = 0;
                     model3.PAYMENT_METHOD = "S";
                     model3.RATE_PLAN_CODE = o8.ToString();
                     model3.RATE_PLAN_NAME = o10 == DBNull.Value ? "" : o10.ToString();
                     model3.ROOM_TYPE_CODE = o11.ToString();
                     model3.START_DATE = Convert.ToDateTime(o12);
                     model3.STATUS = o13 == DBNull.Value ? "C" : o13.ToString();
                     model3.TIME_STAMP = 0;
                     model3.VENDOR_CODE = o14.ToString();
                     curRoomRateList.Add(model3);
                  }
                  reader3.Close();
                  Act2("取房价缓存完毕");

                  Thread.Sleep(1000);
                  Act2("组织当前房价数据字典，请稍候.....");
                  for (int k = 0, len33 = curRoomRateList.Count; k < len33; k++)
                  {
                     Hotel_RoomRate r = curRoomRateList[k];
                     string key = r.HOTEL_CODE + "$" + r.ROOM_TYPE_CODE;
                     if (!roomRateDic.ContainsKey(key))
                     {
                        roomRateDic.Add(key, new List<Hotel_RoomRate>(1000) { r });
                     }
                     else
                     {
                        roomRateDic[key].Add(r);
                     }
                  }

                  Thread.Sleep(1000);
                  Act2("找出当前房价中包含的房型...");

                  for (int bn = 0, len = curRoomRateList.Count; bn < len; bn++)
                  {
                     Hotel_RoomRate rt = curRoomRateList[bn];
                     string key = rt.HOTEL_CODE + "$" + rt.ROOM_TYPE_CODE;
                     if (!temp_hotelcode_roomcodes.ContainsKey(key))
                     {
                        if (roomtypedicsAll.ContainsKey(key))
                        {
                           curRoomTypeList.Add(roomtypedicsAll[key]);
                        }
                        temp_hotelcode_roomcodes.Add(key, "");
                     }
                  }

                  Thread.Sleep(1000);
                  Act2("开始收集更新数据。。。。这可能要花费5分钟左右,请稍候...");
                  Thread.Sleep(2000);
                  #endregion

                  DbDataReader reader5 = null;
                  DbDataReader reader6 = null;
                  for (int r = 0, len2 = curRoomTypeList.Count; r < len2; r++)
                  {
                     #region 房型房价
                     var item2 = curRoomTypeList[r];
                     if (!hoteldicsAll.ContainsKey(item2.HOTEL_CODE))
                     {
                        log("你需要确保tbl_hotel中的酒店已更新过了。hotel_hotelInfo中的酒店：" + item2.HOTEL_CODE + "在tbl_hotel中未找到,已跳过。");
                        continue;
                     }
                     MHotel2 hotel = hoteldicsAll[item2.HOTEL_CODE];
                     MBaseHotelRoomType roomType = null;
                     bool isAdd = true;
                     try
                     {
                        reader5 = dalRoomType.ExecuteReader("select BedTypeDescription,[Desc],Floor,HotelId,IsAddBed,IsInternet,IsSmoking,IssueTime,MaxGuestNum,RoomArea,RoomName,RoomStatus,RoomTypeId,TotalNumber,InterfaceID,HotelCode from tbl_hotelroomtype where InterfaceID='" + item2.ROOM_TYPE_CODE + "' and HotelCode='" + item2.HOTEL_CODE + "'");
                        if (reader5.Read())
                        {
                           object o = reader5["BedTypeDescription"];
                           object o1 = reader5["Desc"];
                           object o2 = reader5["Floor"];
                           object o3 = reader5["HotelId"];
                           object o4 = reader5["IsAddBed"];
                           object o5 = reader5["IsInternet"];
                           object o6 = reader5["IsSmoking"];
                           object o7 = reader5["IssueTime"];
                           object o8 = reader5["MaxGuestNum"];
                           object o9 = reader5["RoomArea"];
                           object o10 = reader5["RoomName"];
                           object o11 = reader5["RoomStatus"];
                           object o12 = reader5["RoomTypeId"];
                           object o13 = reader5["TotalNumber"];
                           object o14 = reader5["InterfaceID"];
                           object o15 = reader5["HotelCode"];

                           roomType = new MBaseHotelRoomType();
                           roomType.BedHeight = 0;
                           roomType.BedTypeDescription = o == DBNull.Value ? "" : o.ToString();
                           roomType.BedWidth = 0;
                           roomType.Desc = o1 == DBNull.Value ? "" : o1.ToString();
                           roomType.Floor = o2.ToString();
                           roomType.HotelId = o3 == DBNull.Value ? "" : o3.ToString();
                           roomType.IsAddBed = o4 == DBNull.Value ? IsAddBed.不能 : (IsAddBed)(byte)o4;
                           roomType.IsAddBedPrice = 0;
                           roomType.IsBreakfast = IsBreakfast.不含早;
                           roomType.IsBreakfastPrice = 0;
                           roomType.IsFenXiao = true;
                           roomType.IsInternet = (IsInternet)(byte)o5;
                           roomType.IsInternetPrice = 0;
                           roomType.IsSmoking = o6 == DBNull.Value ? true : o6.ToString() == "1";
                           roomType.IssueTime = (DateTime)o7;
                           roomType.IsWindow = IsWindow.有开窗;
                           roomType.MaxGuestNum = (int)o8;
                           roomType.OperatorId = 0;
                           roomType.Payment = Payment.预付全款;
                           roomType.RoomArea = o9 == DBNull.Value ? "" : o9.ToString();
                           roomType.RoomName = o10 == DBNull.Value ? "" : o10.ToString();
                           roomType.RoomStatus = (RoomStatus)(byte)o11;
                           roomType.RoomTypeId = o12 == DBNull.Value ? "" : o12.ToString();
                           roomType.RoomType = RoomType.其它;
                           roomType.SortId = 0;
                           roomType.TotalNumber = o13 == DBNull.Value ? 0 : (int)o13;
                           roomType.InterfaceID = o14 == DBNull.Value ? "" : o14.ToString();
                           roomType.HotelCode = o15 == DBNull.Value ? "" : o15.ToString();
                        }
                        reader5.Close();
                        if (roomType == null)
                        {
                           isAdd = true;
                           roomType = new MBaseHotelRoomType();
                           roomType.RoomTypeId = Guid.NewGuid().ToString();
                        }
                        else
                        {
                           if (
                              roomType.BedTypeDescription == item2.BED_TYPE
                              && roomType.Desc == item2.DESCP
                              && roomType.Floor == item2.FLOOR
                              && roomType.IsAddBed == (Utils.GetInt(item2.MAX_ADD_BED, 0) == 0 ? IsAddBed.不能 : IsAddBed.能)
                              && roomType.IsInternet == (string.IsNullOrEmpty(item2.INTERNET) ? IsInternet.无宽带 : (IsInternet)((int)Enum.Parse(typeof(Hotel_RoomType.InternetType), item2.INTERNET)))
                              && roomType.IsSmoking == (string.IsNullOrEmpty(item2.NO_SMOKING) ? false : ((Hotel_RoomType.SmokingType)Enum.Parse(typeof(Hotel_RoomType.SmokingType), item2.NO_SMOKING) == Hotel_RoomType.SmokingType.Y))
                              && roomType.MaxGuestNum == Utils.GetInt(item2.MAX_GUEST_NUM, 0)
                              && roomType.RoomArea == item2.ROOM_AREA
                              && roomType.RoomName == item2.INV_TYPE
                              && roomType.RoomStatus == (item2.STATUS == "Y" ? RoomStatus.正常 : RoomStatus.下架)
                              && roomType.TotalNumber == Utils.GetInt(item2.TOTAL_NUMBER, 0)
                              )
                           {
                              //Act("房型：" + roomType.RoomTypeId + "将跳过更新操作,无须更新.");
                              goto UpdateRoomRateLabel;
                           }
                           else
                           {
                              isAdd = false;
                           }
                        }

                        roomType.BedHeight = 0;
                        roomType.BedTypeDescription = item2.BED_TYPE;
                        roomType.BedWidth = 0;
                        roomType.Desc = item2.DESCP;
                        roomType.Floor = item2.FLOOR;
                        roomType.HotelId = hotel.HotelId;
                        roomType.IsAddBed = Utils.GetInt(item2.MAX_ADD_BED, 0) == 0 ? IsAddBed.不能 : IsAddBed.能;
                        roomType.IsAddBedPrice = 0;
                        roomType.IsBreakfast = IsBreakfast.不含早;
                        roomType.IsBreakfastPrice = 0;
                        roomType.IsFenXiao = true;
                        roomType.IsInternet = string.IsNullOrEmpty(item2.INTERNET) ? IsInternet.无宽带 : (IsInternet)((int)Enum.Parse(typeof(Hotel_RoomType.InternetType), item2.INTERNET));
                        roomType.IsInternetPrice = 0;
                        roomType.IsSmoking = string.IsNullOrEmpty(item2.NO_SMOKING) ? false : ((Hotel_RoomType.SmokingType)Enum.Parse(typeof(Hotel_RoomType.SmokingType), item2.NO_SMOKING) == Hotel_RoomType.SmokingType.Y);
                        roomType.IssueTime = DateTime.Now;
                        roomType.IsWindow = IsWindow.有开窗;
                        roomType.MaxGuestNum = Utils.GetInt(item2.MAX_GUEST_NUM, 0);
                        roomType.OperatorId = 0;
                        roomType.Payment = Payment.预付全款;
                        roomType.RoomArea = item2.ROOM_AREA;
                        roomType.RoomName = item2.INV_TYPE;
                        roomType.RoomStatus = item2.STATUS == "Y" ? RoomStatus.正常 : RoomStatus.下架;
                        roomType.RoomType = RoomType.其它;
                        roomType.SortId = 0;
                        roomType.TotalNumber = Utils.GetInt(item2.TOTAL_NUMBER, 0);
                        roomType.InterfaceID = item2.ROOM_TYPE_CODE;
                        roomType.HotelCode = item2.HOTEL_CODE;
                        string uniqueKey = item2.HOTEL_CODE + "$" + item2.ROOM_TYPE_CODE;
                        if (HandledRoomTypes.ContainsKey(uniqueKey))
                        {
                           Act(null);
                           //Act("酒店$房型：" + uniqueKey + "已处理过，无须处理，已跳过。");
                           goto UpdateRoomRateLabel;
                        }
                        else
                        {
                           HandledRoomTypes.Add(uniqueKey, "");
                        }
                        if (isAdd)
                        {
                            string sql = string.Format(@"insert into tbl_HotelRoomType (RoomTypeId,HotelId,RoomName,TotalNumber,RoomType,RoomArea,Floor,BedType,BedHeight,BedWidth,MaxGuestNum,IsSmoking,IsInternet,IsInternetPrice,Orientation,IsBreakfast,IsBreakfastPrice,IsWindow,IsAddBed,IsAddBedPrice,Payment,[Desc],IssueTime,OperatorId,SortId,RoomStatus,IsFenXiao,BedTypeDescription,InterfaceID,HotelCode) values('{0}','{1}','{2}',{3},{4},'{5}','{6}',{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},'{21}','{22}',{23},{24},{25},{26},'{27}','{28}','{29}');", roomType.RoomTypeId, roomType.HotelId, roomType.RoomName, roomType.TotalNumber, (int)roomType.RoomType, roomType.RoomArea, roomType.Floor, (int)roomType.BedType, roomType.BedHeight, roomType.BedWidth, roomType.MaxGuestNum, (roomType.IsSmoking ? "1" : "0"), (int)roomType.IsInternet, roomType.IsInternetPrice, 0, (int)roomType.IsBreakfast, roomType.IsBreakfastPrice, (int)roomType.IsWindow, (int)roomType.IsAddBed, roomType.IsAddBedPrice, (int)roomType.Payment, roomType.Desc.Replace("\n", "<br>"), roomType.IssueTime, roomType.OperatorId, roomType.SortId, (int)roomType.RoomStatus, (roomType.IsFenXiao ? "1" : "0"), roomType.BedTypeDescription, roomType.InterfaceID, roomType.HotelCode);
                            swTYPE.WriteLine(sql);
                            sqls_roomType.Add(string.Empty);
                        }
                        else
                        {
                            string sql = string.Format(@"update tbl_HotelRoomType set RoomTypeId='{0}',HotelId='{1}',RoomName='{2}',TotalNumber={3},RoomType={4},RoomArea='{5}',Floor='{6}',BedType={7},BedHeight={8},BedWidth={9},MaxGuestNum={10},IsSmoking={11},IsInternet={12},IsInternetPrice={13},Orientation={14},IsBreakfast={15},IsBreakfastPrice={16},IsWindow={17},IsAddBed={18},IsAddBedPrice={19},Payment={20},[Desc]='{21}',IssueTime='{22}',OperatorId={23},SortId={24},RoomStatus={25},IsFenXiao={26},BedTypeDescription='{27}',InterfaceID='{28}',HotelCode='{29}' where (RoomTypeId='{30}');", roomType.RoomTypeId, roomType.HotelId, roomType.RoomName, roomType.TotalNumber, (int)roomType.RoomType, roomType.RoomArea, roomType.Floor, (int)roomType.BedType, roomType.BedHeight, roomType.BedWidth, roomType.MaxGuestNum, (roomType.IsSmoking ? "1" : "0"), (int)roomType.IsInternet, roomType.IsInternetPrice, 0, (int)roomType.IsBreakfast, roomType.IsBreakfastPrice, (int)roomType.IsWindow, (int)roomType.IsAddBed, roomType.IsAddBedPrice, (int)roomType.Payment, roomType.Desc.Replace("\n", "<br>"), roomType.IssueTime, roomType.OperatorId, roomType.SortId, (int)roomType.RoomStatus, (roomType.IsFenXiao ? "1" : "0"), roomType.BedTypeDescription, roomType.InterfaceID, roomType.HotelCode, roomType.RoomTypeId);
                           swTYPE.WriteLine(sql);
                           sqls_roomType.Add(string.Empty);
                        }
                        Act(null);
                     // Act((isAdd ? "将添加房型：" : "将更新房型：") + roomType.HotelCode + ":" + roomType.RoomName);

                     UpdateRoomRateLabel:
                        uniqueKey = item2.HOTEL_CODE + "$" + item2.ROOM_TYPE_CODE;
                        if (!roomRateDic.ContainsKey(uniqueKey))
                        {
                           log("roomRateListAll中包含的[酒店房型]不和roomtypedicsAll中的[酒店房型]数完全一致，出现这种情况，须检查 存在于房价表Hotel_RoomRate中的符合条件酒店code和房型code也完全存在于房型表Hotel_RoomType中");
                           continue;
                        }
                        List<Hotel_RoomRate> roomRateList = roomRateDic[uniqueKey]; //该酒店该房型下的房价信息
                        for (int rr = 0, len3 = roomRateList.Count; rr < len3; rr++)
                        {
                           #region 更新价格
                           var item3 = roomRateList[rr];
                           MHotelRoomRate2 roomRate = null;
                           try
                           {
                              bool isAdd2 = false;
                              reader6 = dalRoomRate.ExecuteReader("select AmountPrice,EndDate,HotelId,Breakfast,RoomTypeId,RoomTypeCode,IssueTime,HotelCode,SettlementPrice,ShuLiang,StartDate,InterfaceID,VenderCode,Status,RoomRateName,RoomRateId,PreferentialPrice from tbl_hotelroomrate where hotelcode='" + item2.HOTEL_CODE + "' and RoomTypeCode='" + item2.ROOM_TYPE_CODE + "' and VenderCode='" + item3.VENDOR_CODE + "' and InterfaceID ='" + item3.RATE_PLAN_CODE + "' and StartDate ='" + item3.START_DATE + "'");
                              if (reader6.Read())
                              {
                                 roomRate = new MHotelRoomRate2();
                                 object o = reader6["AmountPrice"];
                                 object o1 = reader6["EndDate"];
                                 object o2 = reader6["HotelId"];
                                 object o3 = reader6["Breakfast"];
                                 object o4 = reader6["RoomTypeId"];
                                 object o5 = reader6["RoomTypeCode"];
                                 object o6 = reader6["IssueTime"];
                                 object o7 = reader6["HotelCode"];
                                 object o8 = reader6["SettlementPrice"];
                                 object o9 = reader6["ShuLiang"];
                                 object o10 = reader6["StartDate"];
                                 object o11 = reader6["InterfaceID"];
                                 object o12 = reader6["VenderCode"];
                                 object o13 = reader6["Status"];
                                 object o14 = reader6["RoomRateName"];
                                 object o15 = reader6["RoomRateId"];
                                 object o16 = reader6["PreferentialPrice"];

                                 roomRate.AmountPrice = o == DBNull.Value ? 0 : (decimal)o;
                                 roomRate.EndDate = o1 == DBNull.Value ? DateTime.Now : (DateTime)o1;
                                 roomRate.HotelId = o2 == DBNull.Value ? "" : o2.ToString();
                                 roomRate.OperatorId = 0;
                                 roomRate.Reason = "";
                                 roomRate.Breakfast = o3 == DBNull.Value ? "" : o3.ToString();
                                 roomRate.RoomTypeId = o4 == DBNull.Value ? "" : o4.ToString();
                                 roomRate.RoomTypeCode = o5 == DBNull.Value ? "" : o5.ToString();
                                 roomRate.IssueTime = o6 == DBNull.Value ? DateTime.Now.AddYears(-1) : (DateTime)o6;
                                 roomRate.HotelCode = o7 == DBNull.Value ? "" : o7.ToString();
                                 roomRate.SettlementPrice = o8 == DBNull.Value ? 0 : (decimal)o8;
                                 roomRate.ShuLiang = o9 == DBNull.Value ? 0 : (int)o9;
                                 roomRate.StartDate = o10 == DBNull.Value ? DateTime.Now.AddYears(-1) : (DateTime)o10;
                                 roomRate.InterfaceID = o11 == DBNull.Value ? "" : o11.ToString();
                                 roomRate.VenderCode = o12 == DBNull.Value ? "" : o12.ToString();
                                 roomRate.Status = o13 == DBNull.Value ? "" : o13.ToString();
                                 roomRate.RoomRateName = o14 == DBNull.Value ? "" : o14.ToString();
                                 roomRate.RoomRateId = (int)o15;
                                 roomRate.ShengYuShuLiang = 0;
                                 roomRate.PreferentialPrice = o16 == DBNull.Value ? 0 : (decimal)o16;
                              }
                              reader6.Close();
                              if (roomRate == null)
                              {
                                 isAdd2 = true;
                                 roomRate = new MHotelRoomRate2();
                              }
                              else
                              {
                                 decimal settlementPrice = Utils.GetDecimal(item3.AMOUNT_PRICE, 0m);
                                 if (
                                      roomRate.AmountPrice == settlementPrice //接口只提供了一个价格，故此判断
                                    && roomRate.EndDate == Utils.GetDateTime(item3.END_DATE, DateTime.Now)
                                    && roomRate.Breakfast == item3.FREE_MEAL
                                    && roomRate.SettlementPrice == settlementPrice
                                    && roomRate.Status == item3.STATUS
                                    && roomRate.RoomRateName == item3.RATE_PLAN_NAME
                                    && roomRate.PreferentialPrice == settlementPrice
                                    )
                                 {
                                    Act(null);
                                    //Act("房型：" + roomRate.RoomTypeId + "的价格：" + roomRate.RoomRateId + "将跳过更新操作,无须更新.");
                                    continue;
                                 }
                                 else
                                 {
                                    isAdd2 = false;
                                 }
                              }
                              roomRate.EndDate = Utils.GetDateTime(item3.END_DATE, DateTime.Now);
                              roomRate.HotelId = hotel.HotelId;
                              roomRate.IssueTime = DateTime.Now;
                              roomRate.OperatorId = 0;
                              roomRate.Reason = "";
                              roomRate.Breakfast = item3.FREE_MEAL;
                              roomRate.RoomTypeId = roomType.RoomTypeId;
                              roomRate.RoomTypeCode = item3.ROOM_TYPE_CODE;
                              roomRate.HotelCode = hotel.InterfaceId;
                              roomRate.SettlementPrice = Utils.GetDecimal(item3.AMOUNT_PRICE, 0); //结算价
                              roomRate.StartDate = item3.START_DATE;
                              roomRate.InterfaceID = item3.RATE_PLAN_CODE;
                              roomRate.VenderCode = item3.VENDOR_CODE;
                              roomRate.Status = item3.STATUS;
                              roomRate.RoomRateName = item3.RATE_PLAN_NAME;
                              roomRate.ShengYuShuLiang = 0;
                              roomRate.AmountPrice = Utils.GetDecimal(item3.AMOUNT_PRICE, 0); //门市价
                              roomRate.PreferentialPrice = Utils.GetDecimal(item3.AMOUNT_PRICE, 0); //网络销售价
                              roomRate.CityCode = hotel.CityCode;
                              if (isAdd2)
                              {
                                  string sql = string.Format(@"insert into tbl_HotelRoomRate (HotelId,RoomTypeId,AmountPrice,PreferentialPrice,SettlementPrice,StartDate,EndDate,Reason,IssueTime,OperatorId,ShuLiang,ShengYuShuLiang,InterfaceID,VenderCode,Breakfast,RoomRateName,HotelCode,RoomTypeCode,Status,CityCode) values('{0}','{1}',{2},{3},{4},'{5}','{6}','{7}','{8}',{9},{10},{11}, '{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}');", roomRate.HotelId, roomRate.RoomTypeId, roomRate.AmountPrice, roomRate.PreferentialPrice, roomRate.SettlementPrice, roomRate.StartDate, roomRate.EndDate, roomRate.Reason, roomRate.IssueTime, roomRate.OperatorId, roomRate.ShuLiang, roomRate.ShengYuShuLiang, roomRate.InterfaceID, roomRate.VenderCode, roomRate.Breakfast, roomRate.RoomRateName.Replace("'", ""), roomRate.HotelCode, roomRate.RoomTypeCode, roomRate.Status, roomRate.CityCode);
                                 swRATE.WriteLine(sql);
                                 sqls_roomRate.Add(string.Empty);
                              }
                              else
                              {
                                  string sql2 = string.Format(@"update tbl_HotelRoomRate set HotelId='{0}',RoomTypeId='{1}',AmountPrice={2},PreferentialPrice={3},SettlementPrice={4},StartDate='{5}',EndDate='{6}',Reason='{7}',IssueTime='{8}',  OperatorId={9},ShuLiang={10},ShengYuShuLiang={11},InterfaceID='{12}',VenderCode='{13}',Breakfast='{14}', RoomRateName='{15}',HotelCode='{16}',RoomTypeCode='{17}',Status='{18}' where (RoomRateId={19});", roomRate.HotelId, roomRate.RoomTypeId, roomRate.AmountPrice, roomRate.PreferentialPrice, roomRate.SettlementPrice, roomRate.StartDate, roomRate.EndDate, roomRate.Reason, roomRate.IssueTime, roomRate.OperatorId, roomRate.ShuLiang, roomRate.ShengYuShuLiang, roomRate.InterfaceID, roomRate.VenderCode, roomRate.Breakfast, roomRate.RoomRateName.Replace("'", ""), roomRate.HotelCode, roomRate.RoomTypeCode, roomRate.Status, roomRate.RoomRateId);
                                 swRATE.WriteLine(sql2);
                                 sqls_roomRate.Add(string.Empty);
                              }
                              Act(null);
                              //Act((isAdd2 ? ("将添加房价,套餐名：" + roomRate.RoomRateName) : "将更新房价, 房价id:" + roomRate.RoomRateId) + "，所属房型：" + roomRate.RoomTypeId + "，酒店：" + hotel.HotelName);
                           }
                           catch (Exception ex)
                           {
                              if (reader6 != null)
                              {
                                 reader6.Close();
                              }
                              if (roomRate != null)
                              {
                                 log(ex.ToString() + "，1：RATE_PLAN_CODE：" + roomRate.InterfaceID + "，Room_type_code：" + roomRate.RoomTypeCode + ",HotelCode：" + roomRate.HotelCode);
                              }
                              else
                              {
                                 log(ex.ToString() + "，2：RATE_PLAN_CODE：" + item3.RATE_PLAN_CODE + "，Room_type_code：" + item3.ROOM_TYPE_CODE + ",HotelCode：" + item3.HOTEL_CODE);
                              }
                              flag = false;
                              continue;
                           }
                           finally
                           {
                              roomRate = null;
                           }
                           #endregion
                        }
                        roomRateList = null;
                     }
                     catch (Exception ex)
                     {
                        if (reader5 != null)
                        {
                           reader5.Close();
                        }
                        if (roomType != null)
                        {
                           log(ex.ToString() + "，RoomTypeCode：" + roomType.InterfaceID + "，HotelCode：" + roomType.HotelCode);
                        }
                        else
                        {
                           log(ex.ToString() + "，RoomTypeCode：" + item2.ROOM_TYPE_CODE + "，HotelCode：" + item2.HOTEL_CODE);
                        }
                        flag = false;
                        continue;
                     }
                     finally
                     {
                        roomType = null;
                     }
                     #endregion
                  }
               }
               catch (Exception ex)
               {
                  flag = false;
                  log(ex.ToString());
               }
               finally
               {
                  if (temp_hotelcode_roomcodes != null)
                  {
                     temp_hotelcode_roomcodes.Clear();
                     temp_hotelcode_roomcodes = null;
                  }
                  if (curRoomRateList != null)
                  {
                     curRoomRateList.Clear();
                     curRoomRateList = null;
                  }
                  if (curRoomTypeList != null)
                  {
                     curRoomTypeList.Clear();
                     curRoomTypeList = null;
                  }
                  if (roomRateDic != null)
                  {
                     roomRateDic.Clear();
                     roomRateDic = null;
                  }
                  if (roomTypeDic != null)
                  {
                     roomTypeDic.Clear();
                     roomTypeDic = null;
                  }
                  ReportPrecent((int)(Math.Round((decimal)((decimal)pageindex / pagecount), 2) * 100));
                  GC.CollectionCount(0);
                  GC.CollectionCount(1);
                  Act2("处理完毕。");
               }
            }
            GC.CollectionCount(0);
            Thread.Sleep(3000);
            Act2("开始更新。。。。这可能要持续几分钟，请稍候....");
            Thread.Sleep(1000);

            swTYPE.Close();
            swRATE.Close();

            StreamReader srTYPE = new StreamReader(swTYPE_PATH);
            StreamReader srRATE = new StreamReader(swRATE_PATH);

            try
            {
                using (dal2.BeginTransaction())
               {
                  Act2("开始执行房型更新语句，sql总数：" + sqls_roomType.Count + "，请稍候....");
                  int i = 0;
                  int len = sqls_roomType.Count;
                  while (srTYPE.Peek() != -1)
                  {
                      string t_sql = srTYPE.ReadLine();
                      try
                      {
                          dal2.ExecuteSqlNoQuery(t_sql);
                      }
                      catch (Exception ex)
                      {
                          log(ex.ToString() + ",sql:" + t_sql);
                          flag = false;
                          continue;
                      }
                      finally
                      {
                          ReportPrecent((int)(Math.Round((decimal)((decimal)i / len), 2) * 100));
                      }
                      i++;
                  }
                  srTYPE.Close();
                  //for (int i = 0, len = sqls_roomType.Count; i < len; i++)
                  //{
                  //    string t_sql = sqls_roomType[i];
                  //   try
                  //   {
                  //      dalInterfaceRoomRate.ExecuteSqlNoQuery(t_sql);
                  //   }
                  //   catch (Exception ex)
                  //   {
                  //      log(ex.ToString() + ",sql:" + t_sql);
                  //      flag = false;
                  //      continue;
                  //   }
                  //   finally
                  //   {
                  //      ReportPrecent((int)(Math.Round((decimal)((decimal)i / len), 2) * 100));
                  //   }
                  //}
                  Act2("执行完毕。");
                  Act2("开始执行房价更新语句，sql总数：" + sqls_roomRate.Count + "，请稍候....");

                  i = 0;

                  len = sqls_roomRate.Count;
                  while (srRATE.Peek() != -1)
                  {
                      string t_sql = srRATE.ReadLine();
                      try
                      {
                          dal2.ExecuteSqlNoQuery(t_sql);
                      }
                      catch (Exception ex)
                      {
                          log(ex.ToString() + ",sql:" + t_sql);
                          flag = false;
                          continue;
                      }
                      finally
                      {
                          ReportPrecent((int)(Math.Round((decimal)((decimal)i / len), 2) * 100));
                      }
                      i++;
                  }
                  srRATE.Close();

                  //for (int i = 0, len = sqls_roomRate.Count; i < len; i++)
                  //{
                  //    string r_sql = sqls_roomRate[i];
                  //   try
                  //   {
                  //      dalInterfaceRoomRate.ExecuteSqlNoQuery(r_sql);
                  //   }
                  //   catch (Exception ex)
                  //   {
                  //      log(ex.ToString() + ",sql:" + r_sql);
                  //      flag = false;
                  //      continue;
                  //   }
                  //   finally
                  //   {
                  //      ReportPrecent((int)(Math.Round((decimal)((decimal)i / len), 2) * 100));
                  //   }
                  //}
                  Act2("执行完毕。");
                  Act2("开始提交到数据库.....");
                  dal2.Complete();
                  Act2("执行完毕。");
                  Act2("房型房价更新操作完成。");
                  return flag;
               }
            }
            catch (Exception ex)
            {
               log(ex.ToString());
               throw ex;
            }
         }
         catch (Exception ex)
         {
            log(ex.ToString());
            return false;
         }
         finally
         {
            if (reader != null)
            {
               reader.Close();
            }
            if (reader2 != null)
            {
               reader2.Close();
            }
            if (reader3 != null)
            {
               reader3.Close();
            }
            if (sqls_roomType != null)
            {
               sqls_roomType.Clear();
            }
            if (sqls_roomRate != null)
            {
               sqls_roomRate.Clear();
            }
            if (hoteldicsAll != null)
            {
               hoteldicsAll.Clear();
               hoteldicsAll = null;
            }
            if (hotelListAll != null)
            {
               hotelListAll.Clear();
               hotelListAll = null;
            }
            if (roomtypedicsAll != null)
            {
               roomtypedicsAll.Clear();
               roomtypedicsAll = null;
            }
            if (roomTypeListAll != null)
            {
               roomTypeListAll.Clear();
               roomTypeListAll = null;
            }
            if (HandledRoomTypes != null)
            {
               HandledRoomTypes.Clear();
               HandledRoomTypes = null;
            }
         }
      }

      internal bool ClearExpiredRoomRate()
      {
         try
         {
            Act2("开始清理，请稍候。。。");
            dal.ExecuteSqlNoQuery("delete from Hotel_RoomRate where cast(END_DATE as datetime)<getdate()");
            Act2("清理完毕。。。");
            return true;
         }
         catch (Exception ex)
         {
            log(ex.ToString());
            Act2("清理未成功。。。");
            return false;
         }
      }
   }
}
