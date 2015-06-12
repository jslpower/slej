namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;

    public class HotelResSearchRS
    {
        private List<Error> errors;
        private List<HotelResBrief> hotelResBriefs;
        private List<HotelReservation> hotelReservations;
        private com.travelsky.hotelbesdk.models.RespPageInfo respPageInfo;
        private com.travelsky.hotelbesdk.models.Success success;
        private com.travelsky.hotelbesdk.models.Warnings warnings;

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

        public List<HotelResBrief> HotelResBriefs
        {
            get
            {
                return this.hotelResBriefs;
            }
            set
            {
                this.hotelResBriefs = value;
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

        public com.travelsky.hotelbesdk.models.RespPageInfo RespPageInfo
        {
            get
            {
                return this.respPageInfo;
            }
            set
            {
                this.respPageInfo = value;
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

