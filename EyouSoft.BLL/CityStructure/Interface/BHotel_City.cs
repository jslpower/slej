using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model;
using EyouSoft.IDAL.SystemStructure;
using EyouSoft.DAL.SystemStructure;
using EyouSoft.IDAL.HotelStructure;
using EyouSoft.DAL.HotelStructure.Interface;
using Linq.Expressions;
using EyouSoft.Model.HotelStructure.Interface;
using EyouSoft.DAL.CityStructure.Interface;
using EyouSoft.IDAL.CityStructure.Interface;

namespace EyouSoft.BLL.CityStructure.Interface
{
   public class BHotel_City
   {
      IDHotel_City dalInterfaceCity = new DHotel_City();

      private IList<Hotel_City> GetCites(string province)
      {
         var query = new QueryExpressionBuilder<Hotel_City>();
         query.Select(x => x.CITY_NAME);
         query.Select(x => x.CITY_CODE);
         if (!string.IsNullOrEmpty(province))
         {
            query.Where(x => x.PROVINCE == province);
         }
         return dalInterfaceCity.Select(query);
      }
      public IList<Hotel_City> GetCitesByProvince(string province)
      {
         if (string.IsNullOrEmpty(province))
         {
            return null;
         }
         return GetCites(province);
      }

      public IEnumerable<string> GetProvince()
      {
         var query = new QueryExpressionBuilder<Hotel_City>();
         query.Distinct(x => x.PROVINCE);
         return dalInterfaceCity.Select(query).Select(x => x.PROVINCE);
      }
   }
}
