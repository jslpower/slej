namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("Rate", Namespace="Rate")]
    public class Rate
    {
        private string additionalFeeExcludeIndicator;
        private com.travelsky.hotelbesdk.models.AdditionalGuestAmount additionalGuestAmount;
        private string amount;
        private string amountBeforeTax;
        private string amountPrice;
        private string crowdsFitCode;
        private string crowdsFitDesc;
        private string currency;
        private string date;
        private com.travelsky.hotelbesdk.models.Discount discount;
        private string displayPrice;
        private string endDate;
        private string fee;
        private string feeFix;
        private string feePercent;
        private List<com.travelsky.hotelbesdk.models.Fee> fees;
        private string freeMeal;
        private string hotelCode;
        private string payment;
        private string ratePlanCode;
        private string roomTypeCode;
        private string startDate;
        private string uniqueID;
        private string vendorCode;

        [XmlAttribute("AdditionalFeeExcludeIndicator")]
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

        public com.travelsky.hotelbesdk.models.AdditionalGuestAmount AdditionalGuestAmount
        {
            get
            {
                return this.additionalGuestAmount;
            }
            set
            {
                this.additionalGuestAmount = value;
            }
        }

        [XmlAttribute("Amount")]
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

        [XmlAttribute("AmountBeforeTax")]
        public string AmountBeforeTax
        {
            get
            {
                return this.amountBeforeTax;
            }
            set
            {
                this.amountBeforeTax = value;
            }
        }

        [XmlAttribute("AmountPrice")]
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

        [XmlAttribute("CrowdsFitCode")]
        public string CrowdsFitCode
        {
            get
            {
                return this.crowdsFitCode;
            }
            set
            {
                this.crowdsFitCode = value;
            }
        }

        [XmlAttribute("CrowdsFitDesc")]
        public string CrowdsFitDesc
        {
            get
            {
                return this.crowdsFitDesc;
            }
            set
            {
                this.crowdsFitDesc = value;
            }
        }

        [XmlAttribute("Currency")]
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

        [XmlAttribute("Date")]
        public string Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }

        public com.travelsky.hotelbesdk.models.Discount Discount
        {
            get
            {
                return this.discount;
            }
            set
            {
                this.discount = value;
            }
        }

        [XmlAttribute("DisplayPrice")]
        public string DisplayPrice
        {
            get
            {
                return this.displayPrice;
            }
            set
            {
                this.displayPrice = value;
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

        [XmlAttribute("Fee")]
        public string Fee
        {
            get
            {
                return this.fee;
            }
            set
            {
                this.fee = value;
            }
        }

        [XmlAttribute("FeeFix")]
        public string FeeFix
        {
            get
            {
                return this.feeFix;
            }
            set
            {
                this.feeFix = value;
            }
        }

        [XmlAttribute("FeePercent")]
        public string FeePercent
        {
            get
            {
                return this.feePercent;
            }
            set
            {
                this.feePercent = value;
            }
        }

        public List<com.travelsky.hotelbesdk.models.Fee> Fees
        {
            get
            {
                return this.fees;
            }
            set
            {
                this.fees = value;
            }
        }

        [XmlElement(ElementName="FreeMeal", Namespace="")]
        public string FreeMeal
        {
            get
            {
                return this.freeMeal;
            }
            set
            {
                this.freeMeal = value;
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

        [XmlAttribute("UniqueID")]
        public string UniqueID
        {
            get
            {
                return this.uniqueID;
            }
            set
            {
                this.uniqueID = value;
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

