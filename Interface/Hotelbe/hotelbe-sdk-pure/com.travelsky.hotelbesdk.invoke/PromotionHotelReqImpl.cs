namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models.condition;
    using com.travelsky.hotelbesdk.utils;
    using System;

    public class PromotionHotelReqImpl : HotelbeReq
    {
        public override void checkReq()
        {
            PromotionHotelReqCondition basereqcondition = base.Basereqcondition as PromotionHotelReqCondition;
            if (basereqcondition.City.Count == 0)
            {
                throw new HotelbeException("城市数量必须大于1!");
            }
        }

        public override void setReq()
        {
        }
    }
}

