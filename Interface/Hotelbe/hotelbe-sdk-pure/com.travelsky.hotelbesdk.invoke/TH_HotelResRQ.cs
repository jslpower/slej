namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models;
    using System;

    public class TH_HotelResRQ : BaseRQ
    {
        private HotelReservation hotelreservation = new HotelReservation();
        private com.travelsky.hotelbesdk.models.HotelResRQ hotelResRQ = new com.travelsky.hotelbesdk.models.HotelResRQ();

        public TH_HotelResRQ()
        {
            base.OtRequest.HotelResRQ = this.hotelResRQ;
            base.OtRequest.HotelResRQ.HotelReservations.Add(this.hotelreservation);
        }

        public HotelReservation Hotelreservation
        {
            get
            {
                return this.hotelreservation;
            }
            set
            {
                this.hotelreservation = value;
            }
        }

        public com.travelsky.hotelbesdk.models.HotelResRQ HotelResRQ
        {
            get
            {
                return this.hotelResRQ;
            }
            set
            {
                this.hotelResRQ = value;
            }
        }
    }
}

