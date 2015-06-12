namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public class RoomStay
    {
        private string arriveEarlyTime;
        private string arriveLateTime;
        private string availabilityStatus;
        private com.travelsky.hotelbesdk.models.BasicProperty basicProperty = new com.travelsky.hotelbesdk.models.BasicProperty();
        private com.travelsky.hotelbesdk.models.BasicPropertyInfo basicPropertyInfo;
        private string comments;
        private string currency;
        private string guaranteeStatus;
        private List<GuestRef> guestRefs;
        private string paymentDeadLine;
        private string paymentStatus;
        private string quantity;
        private List<RatePlan> ratePlans = new List<RatePlan>();
        private string refundStatus;
        private string resOrderID;
        private string roomName;
        private List<RoomRate> roomRates = new List<RoomRate>();
        private string roomStayStatus;
        private string roomTypeCode;
        private List<RoomType> roomTypes = new List<RoomType>();
        private string specialRequest;
        private com.travelsky.hotelbesdk.models.StayDateRange stayDateRange;
        private com.travelsky.hotelbesdk.models.TimeSpan timeSpan = new com.travelsky.hotelbesdk.models.TimeSpan();
        private com.travelsky.hotelbesdk.models.Total total;
        private string totalAmount;
        private string totalCommission;
        private string totalFee;
        private string vendorCode;
        private string vendorComments;

        public string ArriveEarlyTime
        {
            get
            {
                return this.arriveEarlyTime;
            }
            set
            {
                this.arriveEarlyTime = value;
            }
        }

        public string ArriveLateTime
        {
            get
            {
                return this.arriveLateTime;
            }
            set
            {
                this.arriveLateTime = value;
            }
        }

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

        public com.travelsky.hotelbesdk.models.BasicProperty BasicProperty
        {
            get
            {
                return this.basicProperty;
            }
            set
            {
                this.basicProperty = value;
            }
        }

        public com.travelsky.hotelbesdk.models.BasicPropertyInfo BasicPropertyInfo
        {
            get
            {
                return this.basicPropertyInfo;
            }
            set
            {
                this.basicPropertyInfo = value;
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

        public string GuaranteeStatus
        {
            get
            {
                return this.guaranteeStatus;
            }
            set
            {
                this.guaranteeStatus = value;
            }
        }

        public List<GuestRef> GuestRefs
        {
            get
            {
                return this.guestRefs;
            }
            set
            {
                this.guestRefs = value;
            }
        }

        public string PaymentDeadLine
        {
            get
            {
                return this.paymentDeadLine;
            }
            set
            {
                this.paymentDeadLine = value;
            }
        }

        public string PaymentStatus
        {
            get
            {
                return this.paymentStatus;
            }
            set
            {
                this.paymentStatus = value;
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

        public List<RatePlan> RatePlans
        {
            get
            {
                return this.ratePlans;
            }
            set
            {
                this.ratePlans = value;
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

        [XmlAttribute("ResOrderID")]
        public string ResOrderID
        {
            get
            {
                return this.resOrderID;
            }
            set
            {
                this.resOrderID = value;
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

        public List<RoomRate> RoomRates
        {
            get
            {
                return this.roomRates;
            }
            set
            {
                this.roomRates = value;
            }
        }

        [XmlAttribute("RoomStayStatus")]
        public string RoomStayStatus
        {
            get
            {
                return this.roomStayStatus;
            }
            set
            {
                this.roomStayStatus = value;
            }
        }

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

        public List<RoomType> RoomTypes
        {
            get
            {
                return this.roomTypes;
            }
            set
            {
                this.roomTypes = value;
            }
        }

        public string SpecialRequest
        {
            get
            {
                return this.specialRequest;
            }
            set
            {
                this.specialRequest = value;
            }
        }

        public com.travelsky.hotelbesdk.models.StayDateRange StayDateRange
        {
            get
            {
                return this.stayDateRange;
            }
            set
            {
                this.stayDateRange = value;
            }
        }

        public com.travelsky.hotelbesdk.models.TimeSpan TimeSpan
        {
            get
            {
                return this.timeSpan;
            }
            set
            {
                this.timeSpan = value;
            }
        }

        public com.travelsky.hotelbesdk.models.Total Total
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

        public string TotalAmount
        {
            get
            {
                return this.totalAmount;
            }
            set
            {
                this.totalAmount = value;
            }
        }

        public string TotalCommission
        {
            get
            {
                return this.totalCommission;
            }
            set
            {
                this.totalCommission = value;
            }
        }

        public string TotalFee
        {
            get
            {
                return this.totalFee;
            }
            set
            {
                this.totalFee = value;
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

        public string VendorComments
        {
            get
            {
                return this.vendorComments;
            }
            set
            {
                this.vendorComments = value;
            }
        }
    }
}

