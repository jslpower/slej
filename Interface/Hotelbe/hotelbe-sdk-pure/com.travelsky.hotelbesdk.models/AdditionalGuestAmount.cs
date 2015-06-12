namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class AdditionalGuestAmount
    {
        private string amoutPrice;
        private string currency;

        public string AmoutPrice
        {
            get
            {
                return this.amoutPrice;
            }
            set
            {
                this.amoutPrice = value;
            }
        }

        public string Currency
        {
            get
            {
                return this.currency;
            }
            set
            {
                this.currency = value;
            }
        }
    }
}

