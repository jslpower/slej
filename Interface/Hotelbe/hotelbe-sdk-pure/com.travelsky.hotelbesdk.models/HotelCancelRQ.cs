namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;

    public class HotelCancelRQ
    {
        private string cancelReason;
        private List<HotelReservation> hotelReservations = new List<HotelReservation>();

        public string CancelReason
        {
            get
            {
                return this.cancelReason;
            }
            set
            {
                this.cancelReason = value;
            }
        }

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

