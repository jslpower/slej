namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;

    public class OfferHotelsRS
    {
        private List<OfferHotel> offerHotels;

        public List<OfferHotel> OfferHotels
        {
            get
            {
                return this.offerHotels;
            }
            set
            {
                this.offerHotels = value;
            }
        }
    }
}

