namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class HotelResSearchRQ
    {
        private com.travelsky.hotelbesdk.models.HotelResSearchCriteria hotelResSearchCriteria = new com.travelsky.hotelbesdk.models.HotelResSearchCriteria();

        public com.travelsky.hotelbesdk.models.HotelResSearchCriteria getHotelResSearchCriteria()
        {
            return this.HotelResSearchCriteria;
        }

        public void setHotelResSearchCriteria(com.travelsky.hotelbesdk.models.HotelResSearchCriteria hotelResSearchCriteria)
        {
            this.HotelResSearchCriteria = hotelResSearchCriteria;
        }

        public com.travelsky.hotelbesdk.models.HotelResSearchCriteria HotelResSearchCriteria
        {
            get
            {
                return this.hotelResSearchCriteria;
            }
            set
            {
                this.hotelResSearchCriteria = value;
            }
        }
    }
}

