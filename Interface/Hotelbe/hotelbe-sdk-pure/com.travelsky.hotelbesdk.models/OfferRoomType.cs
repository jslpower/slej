namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class OfferRoomType
    {
        private string hotelCode;
        private string roomTypeCode;
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

        public string RoomTypeCode
        {
            get
            {
                return this.roomTypeCode;
            }
            set
            {
                this.roomTypeCode = value;
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

