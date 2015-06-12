namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models.condition;
    using System;

    public class HotelRatePlanStaticInfoCacheReqImpl : HotelbeReq
    {
        public override void checkReq()
        {
        }

        public override void setReq()
        {
            HotelRatePlanStaticInfoCacheReqCondition basereqcondition = base.Basereqcondition as HotelRatePlanStaticInfoCacheReqCondition;
            base.basereq = new TH_RateplanControlCacheRQ();
            ((TH_RateplanControlCacheRQ) base.basereq).getRateplanControlCacheRQ().RateplanControlCacheCriteria.HotelCode = basereqcondition.Hotelcode;
            ((TH_RateplanControlCacheRQ) base.basereq).OtRequest.Header.Application = "availCache";
        }
    }
}

