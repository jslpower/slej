namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public class RatePlanCandidate
    {
        private string isDefinedChannel;
        private string payment;
        private string ratePlanCode;
        private string ratePlanType;
        private string vendorCode;
        private List<Vendor> vendors;
        private List<Vendor> vendorsIncluded = new List<Vendor>();

        public string IsDefinedChannel
        {
            get
            {
                return this.isDefinedChannel;
            }
            set
            {
                this.isDefinedChannel = value;
            }
        }
        [XmlAttribute("Payment")]
        public string Payment
        {
            get
            {
                return this.payment;
            }
            set
            {
                this.payment = value;
            }
        }
        [XmlAttribute("RatePlanCode")]
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

        public string RatePlanType
        {
            get
            {
                return this.ratePlanType;
            }
            set
            {
                this.ratePlanType = value;
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

        public List<Vendor> Vendors
        {
            get
            {
                return this.vendors;
            }
            set
            {
                this.vendors = value;
            }
        }

        public List<Vendor> VendorsIncluded
        {
            get
            {
                return this.vendorsIncluded;
            }
            set
            {
                this.vendorsIncluded = value;
            }
        }
    }
}

