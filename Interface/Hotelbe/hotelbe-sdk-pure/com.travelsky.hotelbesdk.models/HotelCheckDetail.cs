namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;

    public class HotelCheckDetail
    {
        private string checkID;
        private string checkStatus;
        private com.travelsky.hotelbesdk.models.Commision commision;
        private string confirmNo;
        private string fee;
        private string rateAmount;
        private com.travelsky.hotelbesdk.models.RatePlan ratePlan;
        private List<Rate> rates;
        private string resID;
        private string roomIndex;
        private string roomNight;
        private string roomNo;
        private com.travelsky.hotelbesdk.models.RoomType roomType;
        private com.travelsky.hotelbesdk.models.TimeSpan timeSpan;
        private string totalFee;
        private string totalRateAmount;

        public string CheckID
        {
            get
            {
                return this.checkID;
            }
            set
            {
                this.checkID = value;
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

        public string RateAmount
        {
            get
            {
                return this.rateAmount;
            }
            set
            {
                this.rateAmount = value;
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

        public string RoomIndex
        {
            get
            {
                return this.roomIndex;
            }
            set
            {
                this.roomIndex = value;
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
    }
}

