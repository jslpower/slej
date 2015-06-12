using System.Collections.Generic;
using com.travelsky.hotelbesdk.models.easyhotel.city;
using com.travelsky.hotelbesdk.cache.api;
using com.travelsky.hotelbesdk.models.easyhotel.landmark;
using System.Collections;
using com.travelsky.hotelbesdk.models.easyhotel.multi;
using com.travelsky.hotelbesdk.models.easyhotel.single;

namespace TravelSky.Base.Interface
{
   /// <summary>
   /// 城市，酒店，地标缓存数据接口
   /// </summary>
   public class TravelSky_HuanCunInterface
   {
      /// <summary>
      /// 城市缓存
      /// </summary>
      /// <param name="countryCode"></param>
      /// <param name="cityCode"></param>
      /// <param name="pinyin"></param>
      /// <returns></returns>
      public static List<CityVO> GetCities(string countryCode, string cityCode, string pinyin)
      {
         return CityCacheAPI.getCities(countryCode, cityCode, pinyin);
      }

      /// <summary>
      /// 地标缓存
      /// </summary>
      /// <param name="cityCode"></param>
      /// <param name="categories"></param>
      /// <returns></returns>
      public static List<LandMarkVO> GetLandMarks(string cityCode, ArrayList categories)
      {
         return LandMarkCacheAPI.getLandMarks(cityCode, categories);
      }

      /// <summary>
      /// 多酒店
      /// </summary>
      /// <param name="condition"></param>
      /// <returns></returns>
      public static MultiHotelVO GetMultiHotel(com.travelsky.hotelbesdk.cache.models.condition.MultiHotelReqCondition condition)
      {
         return MultiHotelCacheAPI.getMultiHotel(condition);
      }

      /// <summary>
      /// 单酒店
      /// </summary>
      /// <param name="condition"></param>
      /// <returns></returns>
      public static SingleHotelVO GetSingleHotel(com.travelsky.hotelbesdk.cache.models.condition.SingleHotelReqCondition condition)
      {
         return SingleHotelCacheAPI.getSingleHotel(condition);
      }
   }
}
