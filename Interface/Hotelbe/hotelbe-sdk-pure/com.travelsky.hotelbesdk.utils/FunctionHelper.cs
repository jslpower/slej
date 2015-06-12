namespace com.travelsky.hotelbesdk.utils
{
    using com.travelsky.hotelbesdk.models.condition;
    using System;

    public class FunctionHelper
    {
        public static string getRank(EasyMultiHotelReqCondition.ENUM_RANK rankCode)
        {
            string str = "";
            if (rankCode.Equals(EasyMultiHotelReqCondition.ENUM_RANK.RANK_1))
            {
                return "1";
            }
            if (rankCode.Equals(EasyMultiHotelReqCondition.ENUM_RANK.RANK_2))
            {
                return "2";
            }
            if (rankCode.Equals(EasyMultiHotelReqCondition.ENUM_RANK.RANK_3))
            {
                return "3";
            }
            if (rankCode.Equals(EasyMultiHotelReqCondition.ENUM_RANK.RANK_4))
            {
                return "4";
            }
            if (rankCode.Equals(EasyMultiHotelReqCondition.ENUM_RANK.RANK_5))
            {
                return "5";
            }
            if (rankCode.Equals(EasyMultiHotelReqCondition.ENUM_RANK.RANK_1S))
            {
                return "1S";
            }
            if (rankCode.Equals(EasyMultiHotelReqCondition.ENUM_RANK.RANK_2S))
            {
                return "2S";
            }
            if (rankCode.Equals(EasyMultiHotelReqCondition.ENUM_RANK.RANK_3S))
            {
                return "3S";
            }
            if (rankCode.Equals(EasyMultiHotelReqCondition.ENUM_RANK.RANK_4S))
            {
                return "4S";
            }
            if (rankCode.Equals(EasyMultiHotelReqCondition.ENUM_RANK.RANK_5S))
            {
                return "5S";
            }
            if (rankCode.Equals(EasyMultiHotelReqCondition.ENUM_RANK.RANK_1A))
            {
                return "1A";
            }
            if (rankCode.Equals(EasyMultiHotelReqCondition.ENUM_RANK.RANK_2A))
            {
                return "2A";
            }
            if (rankCode.Equals(EasyMultiHotelReqCondition.ENUM_RANK.RANK_3A))
            {
                return "3A";
            }
            if (rankCode.Equals(EasyMultiHotelReqCondition.ENUM_RANK.RANK_4A))
            {
                return "4A";
            }
            if (rankCode.Equals(EasyMultiHotelReqCondition.ENUM_RANK.RANK_5A))
            {
                str = "5A";
            }
            return str;
        }
    }
}

