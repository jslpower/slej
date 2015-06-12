namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;

    public class HotelResRQ
    {
        private List<HotelReservation> hotelReservations = new List<HotelReservation>();

        public List<HotelReservation> HotelReservations
        {
            get
            {
                return this.hotelReservations;
            }
            set
            {
                this.hotelReservations = value;
            }
        }
    }
}

