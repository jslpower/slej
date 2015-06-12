namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Xml.Serialization;

    public class CancelPolicy
    {
        private string endDate;
        private string feeValue1;
        private string feeValue2;
        private string feeValue3;
        private string hotelCode;
        private string longDesc;
        private string periodDate1;
        private string periodDate2;
        private string periodDate3;
        private string policyCode;
        private string policyType;
        private string ratePlanCode;
        private string roomTypeCode;
        private string shortDesc;
        private string startDate;
        private string status;
        private string unitOfFee1;
        private string unitOfFee2;
        private string unitOfFee3;
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

        public string FeeValue1
        {
            get
            {
                return this.feeValue1;
            }
            set
            {
                this.feeValue1 = value;
            }
        }

        public string FeeValue2
        {
            get
            {
                return this.feeValue2;
            }
            set
            {
                this.feeValue2 = value;
            }
        }

        public string FeeValue3
        {
            get
            {
                return this.feeValue3;
            }
            set
            {
                this.feeValue3 = value;
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

        public string PeriodDate1
        {
            get
            {
                return this.periodDate1;
            }
            set
            {
                this.periodDate1 = value;
            }
        }

        public string PeriodDate2
        {
            get
            {
                return this.periodDate2;
            }
            set
            {
                this.periodDate2 = value;
            }
        }

        public string PeriodDate3
        {
            get
            {
                return this.periodDate3;
            }
            set
            {
                this.periodDate3 = value;
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

        public string UnitOfFee1
        {
            get
            {
                return this.unitOfFee1;
            }
            set
            {
                this.unitOfFee1 = value;
            }
        }

        public string UnitOfFee2
        {
            get
            {
                return this.unitOfFee2;
            }
            set
            {
                this.unitOfFee2 = value;
            }
        }

        public string UnitOfFee3
        {
            get
            {
                return this.unitOfFee3;
            }
            set
            {
                this.unitOfFee3 = value;
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

