namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class UpdateHotel
    {
        private string hotelCode;
        private string type;

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
    }
}

