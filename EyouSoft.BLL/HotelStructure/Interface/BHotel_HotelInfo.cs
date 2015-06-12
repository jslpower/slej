using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.IDAL.HotelStructure.Interface;
using EyouSoft.DAL.HotelStructure.Interface;
using EyouSoft.IDAL.HotelStructure;
using EyouSoft.Model.HotelStructure;
using EyouSoft.DAL.HotelStructure;
using EyouSoft.Model.HotelStructure.Interface;
using Linq.Expressions;
using EyouSoft.IDAL.SystemStructure;
using EyouSoft.DAL.SystemStructure;
using EyouSoft.Toolkit;
using EyouSoft.Model;
using EyouSoft.Model.Enum;
using EyouSoft.Toolkit.BLL;
using EyouSoft.IDAL;

namespace EyouSoft.BLL.HotelStructure.Interface
{
   public class BHotel_HotelInfo : BLLBase
   {
      IDHotel_HotelInfo dal = new DHotel_HotelInfo();
      IDHotelCity dalHotelCity = new DHotelCity2();
      IDHotel2 dal2 = new DHotel2();
      IDHotelImg dalImg = new DHotelImg();
      IDHotelRoomType2 dalRoomType = new DHotelRoomType2();
      IDHotel_RoomType dalInterfaceRoomType = new DHotel_RoomType();
      IDHotelRoomRate dalRoomRate = new DHotelRoomRate();
      IDHotel_RoomRate dalInterfaceRoomRate = new DHotel_RoomRate();
      /// <summary>
      /// 将缓存的酒店数据转入到项目的酒店表
      /// </summary>
      /// <param name="Model"></param>
      /// <returns></returns>
      public bool Add(EyouSoft.Model.HotelStructure.Interface.Hotel_City Model, int userId)
      {
         if (string.IsNullOrEmpty(Model.PROVINCE))
         {
            return false;
         }
         QueryExpressionBuilder<Hotel_HotelInfo> query = new QueryExpressionBuilder<Hotel_HotelInfo>();
         query.Where(x => x.PROVINCE == Model.PROVINCE);

         var query2 = query.LeftOuterJoin<MHotelCity>().On((x, y) => x.CITY_CODE == y.CityCode);
         query2.SelectAs((x, y) => y.ID, "CityId");

         var query3 = query2.LeftOuterJoin2<MSysCity>().On((x, y) => x.ID == y.Id);
         query3.Select((x, y) => y.ProvinceId);

         if (!string.IsNullOrEmpty(Model.CITY_CODE))
         {
            query.Where(x => x.CITY_CODE == Model.CITY_CODE);
         }

         var query4 = query.LeftOuterJoin<MSysDistrict>().On((x, y) => x.DISTRICT == y.Name);
         query4.SelectAs((x, y) => y.Id, "CountyId");
         query.SelectAll();

         IList<Hotel_HotelInfoQueryModel> cacheData = dal.Select<Hotel_HotelInfoQueryModel>(query);

         for (int i = 0; i < cacheData.Count; i++)
         {
            Hotel_HotelInfoQueryModel item = cacheData[i];
            MHotel2 hotel = new MHotel2();
            hotel.AdditionalCost = "0";
            hotel.Address = item.HOTEL_ADDRESS;
            hotel.CityCode = item.CITY_CODE;
            hotel.CityId = 0;
            hotel.CountyId = 0;
            hotel.EnAddress = "";
            hotel.Fitment = item.FIX_MENT;
            hotel.Floor = item.FLOOR;
            hotel.HotelCode = item.HOTEL_CODE;
            hotel.HotelId = Guid.NewGuid().ToString();
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
            hotel.OperatorId = userId;
            hotel.PostalCode = item.POSTAL_CODE;
            hotel.ProvinceId = 0;
            hotel.RoomQuantity = Utils.GetInt(item.ROOM_QUANTITY, 0);
            hotel.ServiceTel = item.TEL;
            hotel.Star = string.IsNullOrEmpty(item.RANK_CODE) ? new Nullable<HotelStar>() : (HotelStar)((int)Enum.Parse(typeof(Hotel_HotelInfoQueryModel.Star), "_" + item.RANK_CODE));
            hotel.Status = HotelStatus.正常;
            hotel.Transport = "";
            //酒店基本信息
            if (dal2.Insert(hotel) != 1)
            {
               continue;
            }
            //图片
            MHotelImg image = new MHotelImg();
            image.HotelId = hotel.HotelId;
            image.ImgCategory = HotelImgType.酒店形象照片;
            image.IssueTime = hotel.IssueTime;
            image.OperatorId = userId.ToString();
            image.Desc = "外景图片";
            image.FilePath = item.IMG_WJ;
            if (dalImg.Insert(image) != 1)
            {
               //return false;
            }

            image.Desc = "大厅图片";
            image.FilePath = item.IMG_DT;
            if (dalImg.Insert(image) != 1)
            {
               //return false;
            }
            image.Desc = "客房图片";
            image.FilePath = item.IMG_KF;
            if (dalImg.Insert(image) != 1)
            {
               //return false;
            }
         

            //房间类型
            var queryInterfaceRoomType = new QueryExpressionBuilder<Hotel_RoomType>();
            queryInterfaceRoomType.Where(x => x.HOTEL_CODE == hotel.InterfaceId);
            IList<Hotel_RoomType> roomTypes = dalInterfaceRoomType.Select(queryInterfaceRoomType);
            foreach (var item2 in roomTypes)
            {
               if (item2.STATUS == "Y")
               {
                  var roomType = new MBaseHotelRoomType();
                  roomType.BedHeight = 0;
                  roomType.BedTypeDescription = item2.BED_TYPE;
                  roomType.BedWidth = 0;
                  roomType.Desc = item2.DESCP;
                  roomType.Floor = item2.FLOOR;
                  roomType.HotelId = hotel.HotelId;
                  roomType.IsAddBed = Utils.GetInt(item2.MAX_ADD_BED, 0) == 0 ? IsAddBed.不能 : IsAddBed.能;
                  roomType.IsAddBedPrice = 0;//目前接口未提供
                  roomType.IsBreakfast = IsBreakfast.不含早; //这个值是根据表Hotel_RoomRate定的，是浮动的
                  roomType.IsBreakfastPrice = 0;//目前接口未提供
                  roomType.IsFenXiao = true;
                  roomType.IsInternet = string.IsNullOrEmpty(item2.INTERNET) ? IsInternet.无宽带 : (IsInternet)((int)Enum.Parse(typeof(Hotel_RoomType.InternetType), item2.INTERNET));
                  roomType.IsInternetPrice = 0;
                  roomType.IsSmoking = string.IsNullOrEmpty(item2.NO_SMOKING) ? false : ((Hotel_RoomType.SmokingType)Enum.Parse(typeof(Hotel_RoomType.SmokingType), item2.NO_SMOKING) == Hotel_RoomType.SmokingType.Y);
                  roomType.IssueTime = DateTime.Now;
                  roomType.IsWindow = IsWindow.有开窗;
                  roomType.MaxGuestNum = Utils.GetInt(item2.MAX_GUEST_NUM, 0);
                  roomType.OperatorId = userId;
                  //roomType.Orientation =  Orientation.请选择; 缓存表并没有这个字段
                  roomType.Payment = Payment.预付全款; //此信息在Hotel_RoomRate中，但全部取预付全款
                  roomType.RoomArea = item2.ROOM_AREA;
                  roomType.RoomName = item2.INV_TYPE;
                  roomType.RoomStatus = RoomStatus.正常;// item2.STATUS;
                  roomType.RoomType = RoomType.其它;
                  roomType.RoomTypeId = Guid.NewGuid().ToString();
                  roomType.SortId = 0;
                  roomType.TotalNumber = Utils.GetInt(item2.TOTAL_NUMBER, 0);
                  roomType.InterfaceID = item2.ROOM_TYPE_CODE;
                  if (dalRoomType.Insert(roomType) != 1)
                  {
                     continue;
                  }

                  var queryInterfaceRoomRate = new QueryExpressionBuilder<Hotel_RoomRate>();
                  queryInterfaceRoomRate.Where(x => x.HOTEL_CODE == item.HOTEL_CODE && x.ROOM_TYPE_CODE == item2.ROOM_TYPE_CODE);
                  var roomRates = dalInterfaceRoomRate.Select(queryInterfaceRoomRate);
                  foreach (var item3 in roomRates)
                  {
                     if (item3.PAYMENT_METHOD.ToUpper() != "S"/* && item3.VENDOR_CODE.ToUpper() != "SOHOTO"*/)
                        continue;

                     MHotelRoomRate2 model3 = new MHotelRoomRate2();
                     model3.AmountPrice = Utils.GetDecimal(item3.DISPLAY_PRICE, 0m); //门市价
                     model3.EndDate = Utils.GetDateTime(item3.END_DATE, DateTime.Now);
                     model3.HotelId = hotel.HotelId;
                     model3.IssueTime = DateTime.Now;
                     model3.OperatorId = userId;
                     model3.PreferentialPrice = model3.AmountPrice; //优惠价
                     model3.Reason = "";
                     model3.Breakfast = item3.FREE_MEAL;
                     model3.RoomTypeId = roomType.RoomTypeId;
                     model3.RoomTypeCode = item3.ROOM_TYPE_CODE;
                     model3.HotelCode = item.HOTEL_CODE;
                     model3.SettlementPrice = Utils.GetDecimal(item3.AMOUNT_PRICE, 0); //结算价
                     model3.ShuLiang = roomType.TotalNumber;
                     model3.StartDate = item3.START_DATE;
                     model3.InterfaceID = item3.RATE_PLAN_CODE;
                     model3.VenderCode = item3.VENDOR_CODE;
                     model3.Status = item3.STATUS;
                     model3.RoomRateName = item3.RATE_PLAN_NAME;
                     //model3.ShengYuShuLiang = 0; 接口那边没有剩余数量，只在下订单时提示
                     if (model3.AmountPrice == 0)
                     {
                        model3.AmountPrice = model3.SettlementPrice;
                     }
                     if (model3.PreferentialPrice == 0)
                     {
                        model3.PreferentialPrice = Math.Round( model3.SettlementPrice * BHotel2.RetialPricePercent);
                     }
                     if (dalRoomRate.Insert(model3) != 1)
                     {
                        //return false;
                     }
                  }
               }
            }
         }
         return true;
      }
   }
}
