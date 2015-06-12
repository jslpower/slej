namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models;
    using System;

    public class TH_HotelResProcessRQ : BaseRQ
    {
        private com.travelsky.hotelbesdk.models.HotelResProcessRQ hotelResProcessRQ = new com.travelsky.hotelbesdk.models.HotelResProcessRQ();

        public TH_HotelResProcessRQ()
        {
            base.OtRequest.HotelResProcessRQ = this.hotelResProcessRQ;
        }

        public com.travelsky.hotelbesdk.models.HotelResProcessRQ getHotelResProcessRQ()
        {
            return this.HotelResProcessRQ;
        }

        public void setHotelResProcessRQ(com.travelsky.hotelbesdk.models.HotelResProcessRQ hotelResProcessRQ)
        {
            this.HotelResProcessRQ = hotelResProcessRQ;
        }

        public com.travelsky.hotelbesdk.models.HotelResProcessRQ HotelResProcessRQ
        {
            get
            {
                return this.hotelResProcessRQ;
            }
            set
            {
                this.hotelResProcessRQ = value;
            }
        }
    }
}

