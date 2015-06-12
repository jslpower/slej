namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;

    public class HotelCancelRS
    {
        private List<Error> errors = new List<Error>();
        private List<HotelReservation> hotelReservations = new List<HotelReservation>();
        private string success;

        public List<Error> Errors
        {
            get
            {
                return this.errors;
            }
            set
            {
                this.errors = value;
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

        public string Success
        {
            get
            {
                return this.success;
            }
            set
            {
                this.success = value;
            }
        }
    }
}

