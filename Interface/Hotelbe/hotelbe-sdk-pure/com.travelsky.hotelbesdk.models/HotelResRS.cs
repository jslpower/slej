namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;

    public class HotelResRS
    {
        private List<Error> errors;
        private List<HotelReservation> hotelReservations;
        private string success;
        private string warnings;

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

        public string Warnings
        {
            get
            {
                return this.warnings;
            }
            set
            {
                this.warnings = value;
            }
        }
    }
}

