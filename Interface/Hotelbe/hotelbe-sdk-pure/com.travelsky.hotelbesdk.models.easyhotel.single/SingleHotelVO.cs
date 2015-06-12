namespace com.travelsky.hotelbesdk.models.easyhotel.single
{
    using System;

    public class SingleHotelVO
    {
        private SingleHotel singlehotel = new SingleHotel();
        private SingleHotelInfo singlehotelinfo = new SingleHotelInfo();

        public SingleHotel Singlehotel
        {
            get
            {
                return this.singlehotel;
            }
            set
            {
                this.singlehotel = value;
            }
        }

        public SingleHotelInfo Singlehotelinfo
        {
            get
            {
                return this.singlehotelinfo;
            }
            set
            {
                this.singlehotelinfo = value;
            }
        }
    }
}

