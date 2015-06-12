namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class HotelAvailabilityCacheCriteria
    {
        private string authType;
        private string dateRange;
        private string hotelCode;
        private string ratePlan;
        private string roomType;
        private string type;
        private string vendor;

        public string AuthType
        {
            get
            {
                return this.authType;
            }
            set
            {
                this.authType = value;
            }
        }

        public string DateRange
        {
            get
            {
                return this.dateRange;
            }
            set
            {
                this.dateRange = value;
            }
        }

        public string HotelCode
        {
            get
            {
                return this.hotelCode;
            }
            set
            {
                this.hotelCode = value;
            }
        }

        public string RatePlan
        {
            get
            {
                return this.ratePlan;
            }
            set
            {
                this.ratePlan = value;
            }
        }

        public string RoomType
        {
            get
            {
                return this.roomType;
            }
            set
            {
                this.roomType = value;
            }
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        public string Vendor
        {
            get
            {
                return this.vendor;
            }
            set
            {
                this.vendor = value;
            }
        }
    }
}

