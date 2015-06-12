namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Xml.Serialization;

    public class GuaranteePolicy
    {
        private string daysOfStay;
        private string daysOfStay2;
        private string daysOfStay3;
        private string endDate;
        private string feeValue;
        private string feeValue2;
        private string feeValue3;
        private string guaranteeDate;
        private string guaranteeDate2;
        private string guaranteeDate3;
        private string guaranteeMethod;
        private string guaranteeType;
        private string holdTime;
        private string holdTime2;
        private string holdTime3;
        private string hotelCode;
        private string longDesc;
        private string numOfRoom;
        private string numOfRoom2;
        private string numOfRoom3;
        private string policyCode;
        private string policyType;
        private string ratePlanCode;
        private string roomTypeCode;
        private string shortDesc;
        private string startDate;
        private string status;
        private string unitOfFee;
        private string unitOfFee2;
        private string unitOfFee3;
        private string vendorCode;

        public string DaysOfStay
        {
            get
            {
                return this.daysOfStay;
            }
            set
            {
                this.daysOfStay = value;
            }
        }

        public string DaysOfStay2
        {
            get
            {
                return this.daysOfStay2;
            }
            set
            {
                this.daysOfStay2 = value;
            }
        }

        public string DaysOfStay3
        {
            get
            {
                return this.daysOfStay3;
            }
            set
            {
                this.daysOfStay3 = value;
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

        public string FeeValue
        {
            get
            {
                return this.feeValue;
            }
            set
            {
                this.feeValue = value;
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

        public string GuaranteeDate
        {
            get
            {
                return this.guaranteeDate;
            }
            set
            {
                this.guaranteeDate = value;
            }
        }

        public string GuaranteeDate2
        {
            get
            {
                return this.guaranteeDate2;
            }
            set
            {
                this.guaranteeDate2 = value;
            }
        }

        public string GuaranteeDate3
        {
            get
            {
                return this.guaranteeDate3;
            }
            set
            {
                this.guaranteeDate3 = value;
            }
        }

        public string GuaranteeMethod
        {
            get
            {
                return this.guaranteeMethod;
            }
            set
            {
                this.guaranteeMethod = value;
            }
        }

        public string GuaranteeType
        {
            get
            {
                return this.guaranteeType;
            }
            set
            {
                this.guaranteeType = value;
            }
        }

        public string HoldTime
        {
            get
            {
                return this.holdTime;
            }
            set
            {
                this.holdTime = value;
            }
        }

        public string HoldTime2
        {
            get
            {
                return this.holdTime2;
            }
            set
            {
                this.holdTime2 = value;
            }
        }

        public string HoldTime3
        {
            get
            {
                return this.holdTime3;
            }
            set
            {
                this.holdTime3 = value;
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

        public string NumOfRoom
        {
            get
            {
                return this.numOfRoom;
            }
            set
            {
                this.numOfRoom = value;
            }
        }

        public string NumOfRoom2
        {
            get
            {
                return this.numOfRoom2;
            }
            set
            {
                this.numOfRoom2 = value;
            }
        }

        public string NumOfRoom3
        {
            get
            {
                return this.numOfRoom3;
            }
            set
            {
                this.numOfRoom3 = value;
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

        public string UnitOfFee
        {
            get
            {
                return this.unitOfFee;
            }
            set
            {
                this.unitOfFee = value;
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

