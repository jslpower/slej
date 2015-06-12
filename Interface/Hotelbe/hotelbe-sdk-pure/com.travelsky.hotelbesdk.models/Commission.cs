namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Xml.Serialization;

    public class Commission
    {
        private string commissionType;
        private string endDate;
        private string fix;
        private string hotelCode;
        private string percent;
        private string ratePlanCode;
        private string roomTypeCode;
        private string startDate;
        private string tax;
        private string vendorCode;

        [XmlAttribute("CommissionType")]
        public string CommissionType
        {
            get
            {
                return this.commissionType;
            }
            set
            {
                this.commissionType = value;
            }
        }

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

        public string Tax
        {
            get
            {
                return this.tax;
            }
            set
            {
                this.tax = value;
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

