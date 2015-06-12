namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;

    public class HotelCheckInfo
    {
        private com.travelsky.hotelbesdk.models.HotelCheckBrief hotelCheckBrief;
        private List<HotelCheckDetail> hotelCheckDetails;

        public com.travelsky.hotelbesdk.models.HotelCheckBrief HotelCheckBrief
        {
            get
            {
                return this.hotelCheckBrief;
            }
            set
            {
                this.hotelCheckBrief = value;
            }
        }

        private List<HotelCheckDetail> HotelCheckDetails
        {
            get
            {
                return this.hotelCheckDetails;
            }
            set
            {
                this.hotelCheckDetails = value;
            }
        }
    }
}

