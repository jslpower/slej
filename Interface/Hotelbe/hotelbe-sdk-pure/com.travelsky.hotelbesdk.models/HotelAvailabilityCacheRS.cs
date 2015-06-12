namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;

    public class HotelAvailabilityCacheRS
    {
        private List<HotelRoomType> hotelRoomTypes;

        public List<HotelRoomType> HotelRoomTypes
        {
            get
            {
                return this.hotelRoomTypes;
            }
            set
            {
                this.hotelRoomTypes = value;
            }
        }
    }
}

