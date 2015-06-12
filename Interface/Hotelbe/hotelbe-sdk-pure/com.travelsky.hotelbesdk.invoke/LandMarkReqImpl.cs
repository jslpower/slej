namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models.condition;
    using System;

    public class LandMarkReqImpl : HotelbeReq
    {
        public override void checkReq()
        {
        }

        public override void setReq()
        {
            LandMarkReqCondition basereqcondition = base.Basereqcondition as LandMarkReqCondition;
            base.basereq = new TH_LandMarkSearchRQ();
            if (string.IsNullOrEmpty(basereqcondition.Citycode))
            {
                ((TH_LandMarkSearchRQ) base.basereq).LandMarkSearchRQ.cityCode = "PEK";
            }
            else
            {
                ((TH_LandMarkSearchRQ) base.basereq).LandMarkSearchRQ.cityCode = basereqcondition.Citycode;
            }
            ((TH_LandMarkSearchRQ) base.basereq).OtRequest.Header.Application = "availCache";
        }
    }
}

