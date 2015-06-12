namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class OfferRoomTypesRQ
    {
        private string endTime;
        private string starTime;

        public string getEndTime()
        {
            return this.EndTime;
        }

        public string getStarTime()
        {
            return this.StarTime;
        }

        public void setEndTime(string endTime)
        {
            this.EndTime = endTime;
        }

        public void setStarTime(string starTime)
        {
            this.StarTime = starTime;
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

