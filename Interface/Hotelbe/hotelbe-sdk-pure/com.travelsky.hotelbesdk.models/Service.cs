namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class Service
    {
        private string price;
        private string quantity;
        private string ratePlanCode;
        private string serviceCode;
        private string serviceDescription;
        private string serviceName;
        private com.travelsky.hotelbesdk.models.TimeSpan timespan;
        private string vendorCode;

        public string Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }

        public string Quantity
        {
            get
            {
                return this.quantity;
            }
            set
            {
                this.quantity = value;
            }
        }

        public string RatePlanCode
        {
            get
            {
                return this.ratePlanCode;
            }
            set
            {
                this.ratePlanCode = value;
            }
        }

        public string ServiceCode
        {
            get
            {
                return this.serviceCode;
            }
            set
            {
                this.serviceCode = value;
            }
        }

        public string ServiceDescription
        {
            get
            {
                return this.serviceDescription;
            }
            set
            {
                this.serviceDescription = value;
            }
        }

        public string ServiceName
        {
            get
            {
                return this.serviceName;
            }
            set
            {
                this.serviceName = value;
            }
        }

        public com.travelsky.hotelbesdk.models.TimeSpan Timespan
        {
            get
            {
                return this.timespan;
            }
            set
            {
                this.timespan = value;
            }
        }

        public string VendorCode
        {
            get
            {
                return this.vendorCode;
            }
            set
            {
                this.vendorCode = value;
            }
        }
    }
}

