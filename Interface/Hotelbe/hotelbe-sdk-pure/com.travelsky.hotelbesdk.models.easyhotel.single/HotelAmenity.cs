namespace com.travelsky.hotelbesdk.models.easyhotel.single
{
    using System;

    public class HotelAmenity
    {
        private string amenityname;
        private string amenitytype;

        public string Amenityname
        {
            get
            {
                return this.amenityname;
            }
            set
            {
                this.amenityname = value;
            }
        }

        public string Amenitytype
        {
            get
            {
                return this.amenitytype;
            }
            set
            {
                this.amenitytype = value;
            }
        }
    }
}

