namespace com.travelsky.hotelbesdk.models.easyhotel.i18nmulti
{
    using System;
    using System.Collections.Generic;

    public class MultiHotelVO
    {
        private MultiHotelInfo multihotelinfo = new MultiHotelInfo();
        private List<SingleHotel> singlehotel;

        public MultiHotelInfo Multihotelinfo
        {
            get
            {
                return this.multihotelinfo;
            }
            set
            {
                this.multihotelinfo = value;
            }
        }

        public List<SingleHotel> Singlehotel
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
    }
}

