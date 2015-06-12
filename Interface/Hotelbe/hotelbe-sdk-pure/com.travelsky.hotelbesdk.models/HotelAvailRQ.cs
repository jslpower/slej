namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class HotelAvailRQ
    {
        private com.travelsky.hotelbesdk.models.HotelAvailCriteria hotelAvailCriteria = new com.travelsky.hotelbesdk.models.HotelAvailCriteria();

        public com.travelsky.hotelbesdk.models.HotelAvailCriteria HotelAvailCriteria
        {
            get
            {
                return this.hotelAvailCriteria;
            }
            set
            {
                this.hotelAvailCriteria = value;
            }
        }
    }
}

