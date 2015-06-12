namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models;
    using System;

    public class TH_HotelAvailabilityCacheRQ : BaseRQ
    {
        private com.travelsky.hotelbesdk.models.HotelAvailabilityCacheRQ hotelAvailabilityCacheRQ = new com.travelsky.hotelbesdk.models.HotelAvailabilityCacheRQ();

        public TH_HotelAvailabilityCacheRQ()
        {
            base.OtRequest.HotelAvailabilityCacheRQ = this.hotelAvailabilityCacheRQ;
        }

        public HotelAvailabilityCacheRS HotelAvailabilityCache()
        {
            return base.OtResponse.HotelAvailabilityCacheRS;
        }

        public void setHotelAvailabilityCacheRS(HotelAvailabilityCacheRS hotelAvailabilityCacheRS)
        {
            base.OtResponse.HotelAvailabilityCacheRS = hotelAvailabilityCacheRS;
        }

        public com.travelsky.hotelbesdk.models.HotelAvailabilityCacheRQ HotelAvailabilityCacheRQ
        {
            get
            {
                return this.hotelAvailabilityCacheRQ;
            }
            set
            {
                this.hotelAvailabilityCacheRQ = value;
            }
        }
    }
}

