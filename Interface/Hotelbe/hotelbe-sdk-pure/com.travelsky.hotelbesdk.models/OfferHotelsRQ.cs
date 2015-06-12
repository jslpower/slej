namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class OfferHotelsRQ
    {
        private string endTime;
        private string starTime;

        public string getEndTime()
        {
            return this.endTime;
        }

        public string getStarTime()
        {
            return this.starTime;
        }

        public void setEndTime(string endTime)
        {
            this.endTime = endTime;
        }

        public void setStarTime(string starTime)
        {
            this.starTime = starTime;
        }

        public string EndTime
        {
            get
            {
                return this.endTime;
            }
            set
            {
                this.endTime = value;
            }
        }

        public string StarTime
        {
            get
            {
                return this.starTime;
            }
            set
            {
                this.starTime = value;
            }
        }
    }
}

