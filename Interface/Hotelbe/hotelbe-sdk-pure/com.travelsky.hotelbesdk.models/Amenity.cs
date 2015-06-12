namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class Amenity
    {
        private string qualityLevel;
        private string quantity;
        private string roomAmenityCode;

        public string QualityLevel
        {
            get
            {
                return this.qualityLevel;
            }
            set
            {
                this.qualityLevel = value;
            }
        }

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

        public string RoomAmenityCode
        {
            get
            {
                return this.roomAmenityCode;
            }
            set
            {
                this.roomAmenityCode = value;
            }
        }
    }
}

