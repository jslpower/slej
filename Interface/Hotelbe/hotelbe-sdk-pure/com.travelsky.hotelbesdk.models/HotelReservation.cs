namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public class HotelReservation
    {
        private com.travelsky.hotelbesdk.models.ContactorInfo contactorInfo = new com.travelsky.hotelbesdk.models.ContactorInfo();
        private string createDateTime;
        private string createOrigResIndicator;
        private string cRSPath;
        private com.travelsky.hotelbesdk.models.GuaranteeInfo guaranteeInfo;
        private com.travelsky.hotelbesdk.models.ResGlobalInfo resGlobalInfo = new com.travelsky.hotelbesdk.models.ResGlobalInfo();
        private List<ResGuest> resGuests = new List<ResGuest>();
        private string resOrderID;
        private string resStatus;
        private List<RoomStay> roomStays = new List<RoomStay>();
        private List<Service> services = new List<Service>();
        private string totalAmount;
        private string vendorResID;

        public com.travelsky.hotelbesdk.models.ContactorInfo ContactorInfo
        {
            get
            {
                return this.contactorInfo;
            }
            set
            {
                this.contactorInfo = value;
            }
        }

        [XmlAttribute("CreateDateTime")]
        public string CreateDateTime
        {
            get
            {
                return this.createDateTime;
            }
            set
            {
                this.createDateTime = value;
            }
        }

        public string CreateOrigResIndicator
        {
            get
            {
                return this.createOrigResIndicator;
            }
            set
            {
                this.createOrigResIndicator = value;
            }
        }

        public string CRSPath
        {
            get
            {
                return this.cRSPath;
            }
            set
            {
                this.cRSPath = value;
            }
        }

        public com.travelsky.hotelbesdk.models.GuaranteeInfo GuaranteeInfo
        {
            get
            {
                return this.guaranteeInfo;
            }
            set
            {
                this.guaranteeInfo = value;
            }
        }

        public com.travelsky.hotelbesdk.models.ResGlobalInfo ResGlobalInfo
        {
            get
            {
                return this.resGlobalInfo;
            }
            set
            {
                this.resGlobalInfo = value;
            }
        }

        public List<ResGuest> ResGuests
        {
            get
            {
                return this.resGuests;
            }
            set
            {
                this.resGuests = value;
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

        [XmlAttribute("ResStatus")]
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

        public List<RoomStay> RoomStays
        {
            get
            {
                return this.roomStays;
            }
            set
            {
                this.roomStays = value;
            }
        }

        public List<Service> Services
        {
            get
            {
                return this.services;
            }
            set
            {
                this.services = value;
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

        [XmlAttribute("VendorResID")]
        public string VendorResID
        {
            get
            {
                return this.vendorResID;
            }
            set
            {
                this.vendorResID = value;
            }
        }
    }
}

