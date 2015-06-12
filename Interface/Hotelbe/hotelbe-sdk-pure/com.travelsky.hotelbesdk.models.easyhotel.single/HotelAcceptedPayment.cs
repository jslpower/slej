namespace com.travelsky.hotelbesdk.models.easyhotel.single
{
    using System;

    public class HotelAcceptedPayment
    {
        private string cardcode;
        private string cardname;

        public string Cardcode
        {
            get
            {
                return this.cardcode;
            }
            set
            {
                this.cardcode = value;
            }
        }

        public string Cardname
        {
            get
            {
                return this.cardname;
            }
            set
            {
                this.cardname = value;
            }
        }
    }
}

