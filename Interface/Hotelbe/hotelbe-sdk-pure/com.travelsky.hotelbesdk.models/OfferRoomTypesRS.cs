namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;

    public class OfferRoomTypesRS
    {
        private List<OfferRoomType> offerRoomTypes;

        public List<OfferRoomType> OfferRoomTypes
        {
            get
            {
                return this.offerRoomTypes;
            }
            set
            {
                this.offerRoomTypes = value;
            }
        }
    }
}

