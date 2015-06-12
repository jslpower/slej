namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models.condition;
    using com.travelsky.hotelbesdk.utils;
    using System;
    using System.Text.RegularExpressions;

    public class OfferHotelsReqImpl : HotelbeReq
    {
        public override void checkReq()
        {
            OfferHotelsReqCondition basereqcondition = base.Basereqcondition as OfferHotelsReqCondition;
            string pattern = "[0-9]{12}";
            if (string.IsNullOrEmpty(basereqcondition.getStarttime()))
            {
                throw new HotelbeException("起始时间不能为空!");
            }
            if (string.IsNullOrEmpty(basereqcondition.getEndtime()))
            {
                throw new HotelbeException("结束时间不能为空!");
            }
            if (!Regex.IsMatch(basereqcondition.getStarttime(), pattern))
            {
                throw new HotelbeException("起始时间格式错误yyyyMMddHHmm!");
            }
            if (!Regex.IsMatch(basereqcondition.getEndtime(), pattern))
            {
                throw new HotelbeException("结束时间格式错误yyyyMMddHHmm!");
            }
        }

        public override void setReq()
        {
            OfferHotelsReqCondition basereqcondition = base.Basereqcondition as OfferHotelsReqCondition;
            base.basereq = new TH_OfferHotelsRQ();
            ((TH_OfferHotelsRQ) base.basereq).OtRequest.OfferHotelsRQ.StarTime = basereqcondition.Starttime;
            ((TH_OfferHotelsRQ) base.basereq).OtRequest.OfferHotelsRQ.EndTime = basereqcondition.Endtime;
            ((TH_OfferHotelsRQ) base.basereq).OtRequest.Header.Application = "availCache";
        }
    }
}

