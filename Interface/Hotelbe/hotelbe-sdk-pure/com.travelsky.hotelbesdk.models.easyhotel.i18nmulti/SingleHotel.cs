namespace com.travelsky.hotelbesdk.models.easyhotel.i18nmulti
{
    using System;
    using System.Collections.Generic;

    public class SingleHotel
    {
        private BasicHotelInfo basichotelinfo;
        private List<HotelRoomType> roomtypeinfo;

        public BasicHotelInfo Basichotelinfo
        {
            get
            {
                return this.basichotelinfo;
            }
            set
            {
                this.basichotelinfo = value;
            }
        }

        public List<HotelRoomType> Roomtypeinfo
        {
            get
            {
                return this.roomtypeinfo;
            }
            set
            {
                this.roomtypeinfo = value;
            }
        }
    }
}

