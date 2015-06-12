using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyouSoft.Model.HotelStructure.Interface;
using Linq.DAL;
using Linq.Respository;
using EyouSoft.IDAL.HotelStructure.Interface;

namespace EyouSoft.DAL.HotelStructure.Interface
{
    public class DHotel_HotelInfo : DALHotelBI<Hotel_HotelInfo>, IDHotel_HotelInfo
   {
   }
}
