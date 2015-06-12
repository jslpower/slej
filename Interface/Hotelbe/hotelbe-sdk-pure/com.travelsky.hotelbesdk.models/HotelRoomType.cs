namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public class HotelRoomType
    {
        private string checkInDate;
        private string checkOutDate;
        private string createDate;
        private string guestName;
        private string hotelCityCode;
        private string hotelCode;
        private string hotelName;
        private string hotelResStatus;
        private string payment;
        private com.travelsky.hotelbesdk.models.Policies policies;
        private string ratePlan;
        private List<Rate> rates;
        private string refundStatus;
        private string resID;
        private string resStatus;
        private string roomNight;
        private string roomQuantity;
        private List<RoomQuota> roomQuotas;
        private string roomType;
        private string roomTypeName;
        private string totalRateAmount;
        private string vendor;
        private string vendorCode;

        public string CheckInDate
        {
            get
            {
                return this.checkInDate;
            }
            set
            {
                this.checkInDate = value;
            }
        }

        public string CheckOutDate
        {
            get
            {
                return this.checkOutDate;
            }
            set
            {
                this.checkOutDate = value;
            }
        }

        public string CreateDate
        {
            get
            {
                return this.createDate;
            }
            set
            {
                this.createDate = value;
            }
        }

        public string GuestName
        {
            get
            {
                return this.guestName;
            }
            set
            {
                this.guestName = value;
            }
        }

        public string HotelCityCode
        {
            get
            {
                return this.hotelCityCode;
            }
            set
            {
                this.hotelCityCode = value;
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

        public string HotelName
        {
            get
            {
                return this.hotelName;
            }
            set
            {
                this.hotelName = value;
            }
        }

        public string HotelResStatus
        {
            get
            {
                return this.hotelResStatus;
            }
            set
            {
                this.hotelResStatus = value;
            }
        }

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

        public com.travelsky.hotelbesdk.models.Policies Policies
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

        [XmlAttribute("RatePlan")]
        public string RatePlan
        {
            get
            {
                return this.ratePlan;
            }
            set
            {
                this.ratePlan = value;
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

        public string ResID
        {
            get
            {
                return this.resID;
            }
            set
            {
                this.resID = value;
            }
        }

        public string ResStatus
        {
            get
            {
                return this.resStatus;
            }
            set
            {
                this.resStatus = value;
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

        public string RoomQuantity
        {
            get
            {
                return this.roomQuantity;
            }
            set
            {
                this.roomQuantity = value;
            }
        }

        public List<RoomQuota> RoomQuotas
        {
            get
            {
                return this.roomQuotas;
            }
            set
            {
                this.roomQuotas = value;
            }
        }

        [XmlAttribute("RoomType")]
        public string RoomType
        {
            get
            {
                return this.roomType;
            }
            set
            {
                this.roomType = value;
            }
        }

        public string RoomTypeName
        {
            get
            {
                return this.roomTypeName;
            }
            set
            {
                this.roomTypeName = value;
            }
        }

        public string TotalRateAmount
        {
            get
            {
                return this.totalRateAmount;
            }
            set
            {
                this.totalRateAmount = value;
            }
        }

        [XmlAttribute("Vendor")]
        public string Vendor
        {
            get
            {
                return this.vendor;
            }
            set
            {
                this.vendor = value;
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
    }
}

