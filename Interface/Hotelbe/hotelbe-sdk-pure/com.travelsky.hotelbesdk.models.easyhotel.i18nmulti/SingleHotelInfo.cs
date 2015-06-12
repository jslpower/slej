namespace com.travelsky.hotelbesdk.models.easyhotel.i18nmulti
{
    using System;

    public class SingleHotelInfo
    {
        private string checkindate;
        private string checkoutdate;
        private string hotelcode;

        public string Checkindate
        {
            get
            {
                return this.checkindate;
            }
            set
            {
                this.checkindate = value;
            }
        }

        public string Checkoutdate
        {
            get
            {
                return this.checkoutdate;
            }
            set
            {
                this.checkoutdate = value;
            }
        }

        public string Hotelcode
        {
            get
            {
                return this.hotelcode;
            }
            set
            {
                this.hotelcode = value;
            }
        }
    }
}

