namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Xml.Serialization;

    public class BookingPolicy
    {
        private string endDate;
        private string hotelCode;
        private string longDesc;
        private string policyCode;
        private string policyType;
        private string ratePlanCode;
        private string roomTypeCode;
        private string shortDesc;
        private string startDate;
        private string status;
        private string vendorCode;

        [XmlAttribute("EndDate")]
        public string EndDate
        {
            get
            {
                return this.endDate;
            }
            set
            {
                this.endDate = value;
            }
        }

        [XmlAttribute("HotelCode")]
        public string HotelCode
        {
            get
            {
                return this.hotelCode;
            }
            set
            {
                this.hotelCode = value;
            }
        }

        public string LongDesc
        {
            get
            {
                return this.longDesc;
            }
            set
            {
                this.longDesc = value;
            }
        }

        [XmlAttribute("PolicyCode")]
        public string PolicyCode
        {
            get
            {
                return this.policyCode;
            }
            set
            {
                this.policyCode = value;
            }
        }

        [XmlAttribute("PolicyType")]
        public string PolicyType
        {
            get
            {
                return this.policyType;
            }
            set
            {
                this.policyType = value;
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

        [XmlAttribute("RoomTypeCode")]
        public string RoomTypeCode
        {
            get
            {
                return this.roomTypeCode;
            }
            set
            {
                this.roomTypeCode = value;
            }
        }

        public string ShortDesc
        {
            get
            {
                return this.shortDesc;
            }
            set
            {
                this.shortDesc = value;
            }
        }

        [XmlAttribute("StartDate")]
        public string StartDate
        {
            get
            {
                return this.startDate;
            }
            set
            {
                this.startDate = value;
            }
        }

        public string Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
            }
        }

        [XmlAttribute("VendorCode")]
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

