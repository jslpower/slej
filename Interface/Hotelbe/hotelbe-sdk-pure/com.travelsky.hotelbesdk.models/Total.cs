namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class Total
    {
        private string additionalFeeExcludeIndicator;
        private string amountPrice;
        private string currency;

        public string AdditionalFeeExcludeIndicator
        {
            get
            {
                return this.additionalFeeExcludeIndicator;
            }
            set
            {
                this.additionalFeeExcludeIndicator = value;
            }
        }

        public string AmountPrice
        {
            get
            {
                return this.amountPrice;
            }
            set
            {
                this.amountPrice = value;
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

