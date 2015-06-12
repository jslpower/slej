namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class Discount
    {
        private string amount;
        private string currencty;
        private string percent;
        private string reason;

        public string Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                this.amount = value;
            }
        }

        public string Currencty
        {
            get
            {
                return this.currencty;
            }
            set
            {
                this.currencty = value;
            }
        }

        public string Percent
        {
            get
            {
                return this.percent;
            }
            set
            {
                this.percent = value;
            }
        }

        public string Reason
        {
            get
            {
                return this.reason;
            }
            set
            {
                this.reason = value;
            }
        }
    }
}

