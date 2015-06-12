namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models.condition;
    using System;

    public class HotelStaticInfoCacheReqImpl : HotelbeReq
    {
        public override void checkReq()
        {
        }

        public override void setReq()
        {
            HotelStaticInfoCacheReqCondition basereqcondition = base.Basereqcondition as HotelStaticInfoCacheReqCondition;
            base.basereq = new TH_HotelStaticInfoCacheRQ();
            if (string.IsNullOrEmpty(basereqcondition.Citycode))
            {
                ((TH_HotelStaticInfoCacheRQ) base.basereq).HotelStaticInfoCacheRQ.HotelStaticInfoCacheCriteria.CityCode = "PEK";
            }
            else
            {
                ((TH_HotelStaticInfoCacheRQ) base.basereq).HotelStaticInfoCacheRQ.HotelStaticInfoCacheCriteria.CityCode = basereqcondition.Citycode;
            }
            if (basereqcondition.PageNo != 0)
            {
                ((TH_HotelStaticInfoCacheRQ) base.basereq).HotelStaticInfoCacheRQ.HotelStaticInfoCacheCriteria.PageNo = basereqcondition.PageNo;
            }
            else
            {
                ((TH_HotelStaticInfoCacheRQ) base.basereq).HotelStaticInfoCacheRQ.HotelStaticInfoCacheCriteria.PageNo = 1;
            }
            if (!string.IsNullOrEmpty(basereqcondition.HotelCode))
            {
                ((TH_HotelStaticInfoCacheRQ) base.basereq).HotelStaticInfoCacheRQ.HotelStaticInfoCacheCriteria.HotelCode = basereqcondition.HotelCode;
            }
            ((TH_HotelStaticInfoCacheRQ) base.basereq).OtRequest.Header.Application = "availCache";
        }
    }
}

