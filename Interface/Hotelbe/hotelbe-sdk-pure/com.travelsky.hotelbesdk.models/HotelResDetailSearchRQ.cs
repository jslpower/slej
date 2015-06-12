namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class HotelResDetailSearchRQ
    {
        private com.travelsky.hotelbesdk.models.HotelResSearchCriteria hotelResSearchCriteria = new com.travelsky.hotelbesdk.models.HotelResSearchCriteria();

        public com.travelsky.hotelbesdk.models.HotelResSearchCriteria getHotelResSearchCriteria()
        {
            return this.hotelResSearchCriteria;
        }

        public void setHotelResSearchCriteria(com.travelsky.hotelbesdk.models.HotelResSearchCriteria hotelResSearchCriteria)
        {
            this.hotelResSearchCriteria = hotelResSearchCriteria;
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

