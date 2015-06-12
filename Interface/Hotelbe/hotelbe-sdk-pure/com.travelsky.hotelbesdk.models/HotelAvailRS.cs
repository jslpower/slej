namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;

    public class HotelAvailRS
    {
        private List<Error> errors;
        private com.travelsky.hotelbesdk.models.RespPageInfo respPageInfo;
        private List<RoomStay> roomStays;
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

        public List<RoomStay> RoomStays
        {
            get
            {
                return this.roomStays;
            }
            set
            {
                this.roomStays = value;
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

