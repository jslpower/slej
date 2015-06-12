namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public class RoomRate
    {
        private string amount;
        private string authorizedChannel;
        private string availabilityStatus;
        private List<BookingPolicy> bookingPolicies;
        private string breakfast;
        private List<CancelPolicy> cancelPolicies;
        private List<Commission> commissions;
        private string confirmRightNowIndicator;
        private string crsIndicator;
        private string crsPath;
        private string date;
        private string endDate;
        private List<FavourPolicy> favourPolicies;
        private List<Policy> favPolicies;
        private List<Feature> features;
        private List<Fee> fees;
        private List<GuaranteePolicy> guaranteePolicies;
        private string guestTypeIndicator;
        private string hotelCode;
        private List<Image> images;
        private string internet;
        private string maxGuestNum;
        private string modifyType;
        private string payment;
        private List<Policy> policies;
        private string quantity;
        private string quantityOld;
        private string ratePlanCode;
        private string ratePlanName;
        private List<Rate> rates;
        private string refundStatus;
        private string restQuantity;
        private string roomName;
        private string roomNight;
        private string roomTypeCode;
        private string startDate;
        private string total;
        private string uniqueID;
        private string vendorCode;
        private string vendorName;

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

        [XmlAttribute("AuthorizedChannel")]
        public string AuthorizedChannel
        {
            get
            {
                return this.authorizedChannel;
            }
            set
            {
                this.authorizedChannel = value;
            }
        }

        [XmlAttribute("AvailabilityStatus")]
        public string AvailabilityStatus
        {
            get
            {
                return this.availabilityStatus;
            }
            set
            {
                this.availabilityStatus = value;
            }
        }

        public List<BookingPolicy> BookingPolicies
        {
            get
            {
                return this.bookingPolicies;
            }
            set
            {
                this.bookingPolicies = value;
            }
        }

        public string Breakfast
        {
            get
            {
                return this.breakfast;
            }
            set
            {
                this.breakfast = value;
            }
        }

        public List<CancelPolicy> CancelPolicies
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

        public string ConfirmRightNowIndicator
        {
            get
            {
                return this.confirmRightNowIndicator;
            }
            set
            {
                this.confirmRightNowIndicator = value;
            }
        }

        [XmlAttribute("CrsIndicator")]
        public string CrsIndicator
        {
            get
            {
                return this.crsIndicator;
            }
            set
            {
                this.crsIndicator = value;
            }
        }

        [XmlAttribute("CrsPath")]
        public string CrsPath
        {
            get
            {
                return this.crsPath;
            }
            set
            {
                this.crsPath = value;
            }
        }

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

        public List<FavourPolicy> FavourPolicies
        {
            get
            {
                return this.favourPolicies;
            }
            set
            {
                this.favourPolicies = value;
            }
        }

        public List<Policy> FavPolicies
        {
            get
            {
                return this.favPolicies;
            }
            set
            {
                this.favPolicies = value;
            }
        }

        public List<Feature> Features
        {
            get
            {
                return this.features;
            }
            set
            {
                this.features = value;
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

        public List<GuaranteePolicy> GuaranteePolicies
        {
            get
            {
                return this.guaranteePolicies;
            }
            set
            {
                this.guaranteePolicies = value;
            }
        }

        [XmlAttribute("GuestTypeIndicator")]
        public string GuestTypeIndicator
        {
            get
            {
                return this.guestTypeIndicator;
            }
            set
            {
                this.guestTypeIndicator = value;
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

        public List<Image> Images
        {
            get
            {
                return this.images;
            }
            set
            {
                this.images = value;
            }
        }

        public string Internet
        {
            get
            {
                return this.internet;
            }
            set
            {
                this.internet = value;
            }
        }

        public string MaxGuestNum
        {
            get
            {
                return this.maxGuestNum;
            }
            set
            {
                this.maxGuestNum = value;
            }
        }

        public string ModifyType
        {
            get
            {
                return this.modifyType;
            }
            set
            {
                this.modifyType = value;
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

        public List<Policy> Policies
        {
            get
            {
                return this.policies;
            }
            set
            {
                this.policies = value;
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

        public string QuantityOld
        {
            get
            {
                return this.quantityOld;
            }
            set
            {
                this.quantityOld = value;
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

        public List<Rate> Rates
        {
            get
            {
                return this.rates;
            }
            set
            {
                this.rates = value;
            }
        }

        public string RefundStatus
        {
            get
            {
                return this.refundStatus;
            }
            set
            {
                this.refundStatus = value;
            }
        }

        public string RestQuantity
        {
            get
            {
                return this.restQuantity;
            }
            set
            {
                this.restQuantity = value;
            }
        }

        public string RoomName
        {
            get
            {
                return this.roomName;
            }
            set
            {
                this.roomName = value;
            }
        }

        public string RoomNight
        {
            get
            {
                return this.roomNight;
            }
            set
            {
                this.roomNight = value;
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

        public string Total
        {
            get
            {
                return this.total;
            }
            set
            {
                this.total = value;
            }
        }

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

        [XmlAttribute("VendorName")]
        public string VendorName
        {
            get
            {
                return this.vendorName;
            }
            set
            {
                this.vendorName = value;
            }
        }
    }
}

