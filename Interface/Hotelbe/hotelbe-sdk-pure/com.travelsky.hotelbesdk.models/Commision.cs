namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class Commision
    {
        private string commisionType;
        private string commissionableAmount;
        private string fix;
        private string percent;
        private string taxAmount;
        private string taxPercent;
        private string totalCommision;

        public string CommisionType
        {
            get
            {
                return this.commisionType;
            }
            set
            {
                this.commisionType = value;
            }
        }

        public string CommissionableAmount
        {
            get
            {
                return this.commissionableAmount;
            }
            set
            {
                this.commissionableAmount = value;
            }
        }

        public string Fix
        {
            get
            {
                return this.fix;
            }
            set
            {
                this.fix = value;
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

        public string TaxAmount
        {
            get
            {
                return this.taxAmount;
            }
            set
            {
                this.taxAmount = value;
            }
        }

        public string TaxPercent
        {
            get
            {
                return this.taxPercent;
            }
            set
            {
                this.taxPercent = value;
            }
        }

        public string TotalCommision
        {
            get
            {
                return this.totalCommision;
            }
            set
            {
                this.totalCommision = value;
            }
        }
    }
}

