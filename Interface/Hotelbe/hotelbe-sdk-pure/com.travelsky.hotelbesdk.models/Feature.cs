namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class Feature
    {
        private string quantity;
        private string roomAmenity;

        public string Quantity
        {
            get
            {
                return this.quantity;
            }
            set
            {
                this.quantity = value;
            }
        }

        public string RoomAmenity
        {
            get
            {
                return this.roomAmenity;
            }
            set
            {
                this.roomAmenity = value;
            }
        }
    }
}

