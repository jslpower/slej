namespace com.travelsky.hotelbesdk.models.easyhotel.multi
{
    using System;

    internal class SingleHotelInfo
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

