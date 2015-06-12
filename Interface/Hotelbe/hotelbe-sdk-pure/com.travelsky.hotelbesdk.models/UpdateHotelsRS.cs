namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;

    public class UpdateHotelsRS
    {
        private List<UpdateHotel> updateHotels;

        public List<UpdateHotel> UpdateHotels
        {
            get
            {
                return this.updateHotels;
            }
            set
            {
                this.updateHotels = value;
            }
        }
    }
}

