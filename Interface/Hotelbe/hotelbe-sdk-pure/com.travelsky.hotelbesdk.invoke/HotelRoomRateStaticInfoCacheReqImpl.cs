namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models.condition;
    using System;

    public class HotelRoomRateStaticInfoCacheReqImpl : HotelbeReq
    {
        public override void checkReq()
        {
        }

        public override void setReq()
        {
            HotelRoomRateStaticInfoCacheReqCondition basereqcondition = base.Basereqcondition as HotelRoomRateStaticInfoCacheReqCondition;
            base.basereq = new TH_HotelAvailabilityCacheRQ();
            ((TH_HotelAvailabilityCacheRQ) base.basereq).HotelAvailabilityCacheRQ.HotelAvailabilityCacheCriteria.HotelCode = basereqcondition.getHotelcode();
            HotelRoomRateStaticInfoCacheReqCondition.ENUM_TYPE type = basereqcondition.Type;
            bool flag = 1 == 0;
            if (basereqcondition.Type.Equals(HotelRoomRateStaticInfoCacheReqCondition.ENUM_TYPE.TYPE_ROOMRATE))
            {
                ((TH_HotelAvailabilityCacheRQ) base.basereq).HotelAvailabilityCacheRQ.HotelAvailabilityCacheCriteria.Type = "R";
            }
            else if (basereqcondition.Type.Equals(HotelRoomRateStaticInfoCacheReqCondition.ENUM_TYPE.TYPE_AVAILABLE))
            {
                ((TH_HotelAvailabilityCacheRQ) base.basereq).HotelAvailabilityCacheRQ.HotelAvailabilityCacheCriteria.Type = "Q";
            }
            else if (basereqcondition.Type.Equals(HotelRoomRateStaticInfoCacheReqCondition.ENUM_TYPE.TYPE_RATEPLAN))
            {
                ((TH_HotelAvailabilityCacheRQ) base.basereq).HotelAvailabilityCacheRQ.HotelAvailabilityCacheCriteria.Type = "C";
            }
            else if (basereqcondition.Type.Equals(HotelRoomRateStaticInfoCacheReqCondition.ENUM_TYPE.TYPE_POLICY))
            {
                ((TH_HotelAvailabilityCacheRQ) base.basereq).HotelAvailabilityCacheRQ.HotelAvailabilityCacheCriteria.Type = "P";
            }
            basereqcondition.getAuthType();
            flag = 1 == 0;
            if (basereqcondition.getAuthType().Equals(HotelRoomRateStaticInfoCacheReqCondition.ENUM_AUTHTYPE.AUTHTYPE_PRIVATE))
            {
                ((TH_HotelAvailabilityCacheRQ) base.basereq).HotelAvailabilityCacheRQ.HotelAvailabilityCacheCriteria.AuthType = "P";
            }
            else if (basereqcondition.Type.Equals(HotelRoomRateStaticInfoCacheReqCondition.ENUM_AUTHTYPE.AUTHTYPE_PUBLIC))
            {
                ((TH_HotelAvailabilityCacheRQ) base.basereq).HotelAvailabilityCacheRQ.HotelAvailabilityCacheCriteria.AuthType = "U";
            }
            ((TH_HotelAvailabilityCacheRQ) base.basereq).HotelAvailabilityCacheRQ.HotelAvailabilityCacheCriteria.HotelCode = basereqcondition.getHotelcode();
            ((TH_HotelAvailabilityCacheRQ) base.basereq).OtRequest.Header.Application = "availCache";
        }
    }
}

