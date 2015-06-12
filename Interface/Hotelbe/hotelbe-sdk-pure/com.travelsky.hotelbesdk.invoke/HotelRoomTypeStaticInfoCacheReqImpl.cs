namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models.condition;
    using System;

    public class HotelRoomTypeStaticInfoCacheReqImpl : HotelbeReq
    {
        public override void checkReq()
        {
        }

        public override void setReq()
        {
            HotelRoomTypeStaticInfoCacheReqCondition basereqcondition = base.Basereqcondition as HotelRoomTypeStaticInfoCacheReqCondition;
            base.basereq = new TH_RoomTypeStaticInfoCacheRQ();
            ((TH_RoomTypeStaticInfoCacheRQ) base.basereq).HotelRoomTypeStaticInfoCacheRQ.HotelRoomTypeStaticInfoCacheCriteria.HotelCode = basereqcondition.Hotelcode;
            ((TH_RoomTypeStaticInfoCacheRQ) base.basereq).OtRequest.Header.Application = "availCache";
        }
    }
}

