namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Xml.Serialization;

    public class Fee
    {
        private string amount;
        private string chargeFrequence;
        private string chargeFrequency;
        private string chargeUnit;
        private string comments;
        private string count;
        private string counts;
        private string endDate;
        private string feeCode;
        private string feeName;
        private string hotelCode;
        private string ratePlanCode;
        private string roomTypeCode;
        private string startDate;
        private string vendorCode;

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

        public string ChargeFrequence
        {
            get
            {
                return this.chargeFrequence;
            }
            set
            {
                this.chargeFrequence = value;
            }
        }

        public string ChargeFrequency
        {
            get
            {
                return this.chargeFrequency;
            }
            set
            {
                this.chargeFrequency = value;
            }
        }

        public string ChargeUnit
        {
            get
            {
                return this.chargeUnit;
            }
            set
            {
                this.chargeUnit = value;
            }
        }

        public string Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }

        public string Count
        {
            get
            {
                return this.count;
            }
            set
            {
                this.count = value;
            }
        }

        public string Counts
        {
            get
            {
                return this.counts;
            }
            set
            {
                this.counts = value;
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

        [XmlAttribute("FeeCode")]
        public string FeeCode
        {
            get
            {
                return this.feeCode;
            }
            set
            {
                this.feeCode = value;
            }
        }

        [XmlAttribute("FeeName")]
        public string FeeName
        {
            get
            {
                return this.feeName;
            }
            set
            {
                this.feeName = value;
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

