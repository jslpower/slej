namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class HotelAmenity
    {
        private string amenityName;
        private string amenityType;
        private string status;

        public string AmenityName
        {
            get
            {
                return this.amenityName;
            }
            set
            {
                this.amenityName = value;
            }
        }

        public string AmenityType
        {
            get
            {
                return this.amenityType;
            }
            set
            {
                this.amenityType = value;
            }
        }

        public string Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
            }
        }
    }
}

