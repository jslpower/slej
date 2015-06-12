namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models;
    using System;

    public class TH_HotelCancelRQ : BaseRQ
    {
        private com.travelsky.hotelbesdk.models.HotelCancelRQ hotelCancelRQ = new com.travelsky.hotelbesdk.models.HotelCancelRQ();

        public TH_HotelCancelRQ()
        {
            base.OtRequest.HotelCancelRQ = this.hotelCancelRQ;
        }

        public com.travelsky.hotelbesdk.models.HotelCancelRQ HotelCancelRQ
        {
            get
            {
                return this.hotelCancelRQ;
            }
            set
            {
                this.hotelCancelRQ = value;
            }
        }
    }
}

