namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class ResGlobalInfo
    {
        private string arriveEarlyTime;
        private string arriveLateTime;
        private string guarantee;
        private string guestCount;
        private string payment;
        private com.travelsky.hotelbesdk.models.TimeSpan timeSpan = new com.travelsky.hotelbesdk.models.TimeSpan();

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

        public string Guarantee
        {
            get
            {
                return this.guarantee;
            }
            set
            {
                this.guarantee = value;
            }
        }

        public string GuestCount
        {
            get
            {
                return this.guestCount;
            }
            set
            {
                this.guestCount = value;
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
    }
}

