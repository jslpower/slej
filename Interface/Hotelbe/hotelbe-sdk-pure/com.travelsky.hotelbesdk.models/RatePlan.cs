namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public class RatePlan
    {
        private List<CancelPenalty> cancelPolicies;
        private List<Commission> commissions;
        private string effectiveDate;
        private string expireDate;
        private List<Fee> fees;
        private List<Guarantee> guarantees;
        private string ratePlanCode;
        private string ratePlanName;
        private string ratePlanType;
        private string vendorCode;

        public List<CancelPenalty> CancelPolicies
        {
            get
            {
                return this.cancelPolicies;
            }
            set
            {
                this.cancelPolicies = value;
            }
        }

        public List<Commission> Commissions
        {
            get
            {
                return this.commissions;
            }
            set
            {
                this.commissions = value;
            }
        }

        [XmlAttribute("EffectiveDate")]
        public string EffectiveDate
        {
            get
            {
                return this.effectiveDate;
            }
            set
            {
                this.effectiveDate = value;
            }
        }

        [XmlAttribute("ExpireDate")]
        public string ExpireDate
        {
            get
            {
                return this.expireDate;
            }
            set
            {
                this.expireDate = value;
            }
        }

        public List<Fee> Fees
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

        public List<Guarantee> Guarantees
        {
            get
            {
                return this.guarantees;
            }
            set
            {
                this.guarantees = value;
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

        [XmlAttribute("RatePlanName")]
        public string RatePlanName
        {
            get
            {
                return this.ratePlanName;
            }
            set
            {
                this.ratePlanName = value;
            }
        }

        [XmlAttribute("RatePlanType")]
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

