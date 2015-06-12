namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models.condition;
    using com.travelsky.hotelbesdk.utils;
    using System;
    using System.Text.RegularExpressions;

    public class OfferRoomTypesReqImpl : HotelbeReq
    {
        public override void checkReq()
        {
            OfferRoomTypesReqCondition basereqcondition = base.Basereqcondition as OfferRoomTypesReqCondition;
            string pattern = "[0-9]{12}";
            if (string.IsNullOrEmpty(basereqcondition.Starttime))
            {
                throw new HotelbeException("起始时间不能为空!");
            }
            if (string.IsNullOrEmpty(basereqcondition.Endtime))
            {
                throw new HotelbeException("结束时间不能为空!");
            }
            if (!Regex.IsMatch(basereqcondition.Starttime, pattern))
            {
                throw new HotelbeException("起始时间格式错误yyyyMMddHHmm!");
            }
            if (!Regex.IsMatch(basereqcondition.Endtime, pattern))
            {
                throw new HotelbeException("结束时间格式错误yyyyMMddHHmm!");
            }
        }

        public override void setReq()
        {
            OfferRoomTypesReqCondition basereqcondition = base.Basereqcondition as OfferRoomTypesReqCondition;
            base.basereq = new TH_OfferRoomTypesRQ();
            ((TH_OfferRoomTypesRQ) base.basereq).OtRequest.OfferRoomTypesRQ.StarTime = basereqcondition.Starttime;
            ((TH_OfferRoomTypesRQ) base.basereq).OtRequest.OfferRoomTypesRQ.EndTime = basereqcondition.Endtime;
            ((TH_OfferRoomTypesRQ) base.basereq).OtRequest.Header.Application = "availCache";
        }
    }
}

