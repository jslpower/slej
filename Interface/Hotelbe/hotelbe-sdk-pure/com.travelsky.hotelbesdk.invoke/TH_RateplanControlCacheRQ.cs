namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models;
    using System;

    public class TH_RateplanControlCacheRQ : BaseRQ
    {
        private RateplanControlCacheRQ rateplanControlCacheRQ = new RateplanControlCacheRQ();

        public TH_RateplanControlCacheRQ()
        {
            base.OtRequest.RateplanControlCacheRQ = this.rateplanControlCacheRQ;
        }

        public RateplanControlCacheRQ getRateplanControlCacheRQ()
        {
            return this.rateplanControlCacheRQ;
        }

        public void setRateplanControlCacheRQ(RateplanControlCacheRQ rateplanControlCacheRQ)
        {
            this.rateplanControlCacheRQ = rateplanControlCacheRQ;
        }
    }
}

