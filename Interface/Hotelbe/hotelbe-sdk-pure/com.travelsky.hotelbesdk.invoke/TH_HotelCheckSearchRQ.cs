namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models;
    using System;

    public class TH_HotelCheckSearchRQ : BaseRQ
    {
        private com.travelsky.hotelbesdk.models.HotelCheckSearchRQ hotelCheckSearchRQ = new com.travelsky.hotelbesdk.models.HotelCheckSearchRQ();

        public TH_HotelCheckSearchRQ()
        {
            base.OtRequest.HotelCheckSearchRQ = this.hotelCheckSearchRQ;
        }

        public com.travelsky.hotelbesdk.models.HotelCheckSearchRQ HotelCheckSearchRQ
        {
            get
            {
                return this.hotelCheckSearchRQ;
            }
            set
            {
                this.hotelCheckSearchRQ = value;
            }
        }
    }
}

