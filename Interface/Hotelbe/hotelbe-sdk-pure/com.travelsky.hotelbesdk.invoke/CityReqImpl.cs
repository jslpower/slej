namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models.condition;
    using System;

    public class CityReqImpl : HotelbeReq
    {
        public override void checkReq()
        {
        }

        public override void setReq()
        {
            CityReqCondition basereqcondition = base.Basereqcondition as CityReqCondition;
            base.basereq = new TH_CityDetailsSearchRQ();
            if (string.IsNullOrEmpty(basereqcondition.Countrycode))
            {
                ((TH_CityDetailsSearchRQ) base.basereq).CityDetailsSearchRQ.CountryCode = "CN";
            }
            else
            {
                ((TH_CityDetailsSearchRQ) base.basereq).CityDetailsSearchRQ.CountryCode = basereqcondition.Countrycode;
            }
            ((TH_CityDetailsSearchRQ) base.basereq).OtRequest.Header.Application = "availCache";
        }
    }
}

