namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;

    public class HotelResDetailSearchRS
    {
        private List<Error> errors = new List<Error>();
        private List<HotelReservation> hotelReservations = new List<HotelReservation>();
        private com.travelsky.hotelbesdk.models.Success success = new com.travelsky.hotelbesdk.models.Success();
        private com.travelsky.hotelbesdk.models.Warnings warnings = new com.travelsky.hotelbesdk.models.Warnings();

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

        public com.travelsky.hotelbesdk.models.Success Success
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

        public com.travelsky.hotelbesdk.models.Warnings Warnings
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

