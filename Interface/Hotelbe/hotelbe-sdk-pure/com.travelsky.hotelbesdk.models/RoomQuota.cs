namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class RoomQuota
    {
        private string authenQuota;
        private string avail;
        private string date;
        private string hotelCode;
        private string ratePlanCode;
        private string ratePlanName;
        private string roomTypeCode;
        private string roomTypeEnName;
        private string roomTypeName;
        private string saleQuota;
        private string vendorCode;
        private string vendorName;

        public string AuthenQuota
        {
            get
            {
                return this.authenQuota;
            }
            set
            {
                this.authenQuota = value;
            }
        }

        public string Avail
        {
            get
            {
                return this.avail;
            }
            set
            {
                this.avail = value;
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

        public string RoomTypeEnName
        {
            get
            {
                return this.roomTypeEnName;
            }
            set
            {
                this.roomTypeEnName = value;
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

        public string SaleQuota
        {
            get
            {
                return this.saleQuota;
            }
            set
            {
                this.saleQuota = value;
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

