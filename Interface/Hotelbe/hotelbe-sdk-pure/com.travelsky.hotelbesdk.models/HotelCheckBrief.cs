namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class HotelCheckBrief
    {
        private com.travelsky.hotelbesdk.models.BasicProperty basicProperty;
        private string checkStatus;
        private com.travelsky.hotelbesdk.models.Commision commision;
        private string confirmNo;
        private string createDate;
        private string oldResID;
        private string payment;
        private com.travelsky.hotelbesdk.models.RatePlan ratePlan;
        private string resID;
        private string roomNight;
        private string roomNo;
        private string roomQuantity;
        private com.travelsky.hotelbesdk.models.RoomType roomType;
        private com.travelsky.hotelbesdk.models.TimeSpan timeSpan;
        private string totalFee;
        private string totalRateAmount;
        private com.travelsky.hotelbesdk.models.VendorInfo vendorInfo;

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

        public string CheckStatus
        {
            get
            {
                return this.checkStatus;
            }
            set
            {
                this.checkStatus = value;
            }
        }

        public com.travelsky.hotelbesdk.models.Commision Commision
        {
            get
            {
                return this.commision;
            }
            set
            {
                this.commision = value;
            }
        }

        public string ConfirmNo
        {
            get
            {
                return this.confirmNo;
            }
            set
            {
                this.confirmNo = value;
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

        public string OldResID
        {
            get
            {
                return this.oldResID;
            }
            set
            {
                this.oldResID = value;
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

        public com.travelsky.hotelbesdk.models.RatePlan RatePlan
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

        public string RoomNo
        {
            get
            {
                return this.roomNo;
            }
            set
            {
                this.roomNo = value;
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

        public com.travelsky.hotelbesdk.models.RoomType RoomType
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

        public com.travelsky.hotelbesdk.models.VendorInfo VendorInfo
        {
            get
            {
                return this.vendorInfo;
            }
            set
            {
                this.vendorInfo = value;
            }
        }
    }
}

