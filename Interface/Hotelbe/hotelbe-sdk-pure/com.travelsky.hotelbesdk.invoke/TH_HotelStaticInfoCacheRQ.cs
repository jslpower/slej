namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models;
    using System;

    public class TH_HotelStaticInfoCacheRQ : BaseRQ
    {
        private com.travelsky.hotelbesdk.models.HotelStaticInfoCacheRQ hotelStaticInfoCacheRQ = new com.travelsky.hotelbesdk.models.HotelStaticInfoCacheRQ();

        public TH_HotelStaticInfoCacheRQ()
        {
            base.OtRequest.HotelStaticInfoCacheRQ = this.hotelStaticInfoCacheRQ;
        }

        public com.travelsky.hotelbesdk.models.HotelStaticInfoCacheRQ HotelStaticInfoCacheRQ
        {
            get
            {
                return this.hotelStaticInfoCacheRQ;
            }
            set
            {
                this.hotelStaticInfoCacheRQ = value;
            }
        }
    }
}

