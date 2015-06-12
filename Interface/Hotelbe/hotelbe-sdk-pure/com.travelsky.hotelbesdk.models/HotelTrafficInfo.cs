namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class HotelTrafficInfo
    {
        private string carInterval;
        private string category;
        private string distance;
        private string footInterval;
        private string trafficName;

        public string CarInterval
        {
            get
            {
                return this.carInterval;
            }
            set
            {
                this.carInterval = value;
            }
        }

        public string Category
        {
            get
            {
                return this.category;
            }
            set
            {
                this.category = value;
            }
        }

        public string Distance
        {
            get
            {
                return this.distance;
            }
            set
            {
                this.distance = value;
            }
        }

        public string FootInterval
        {
            get
            {
                return this.footInterval;
            }
            set
            {
                this.footInterval = value;
            }
        }

        public string TrafficName
        {
            get
            {
                return this.trafficName;
            }
            set
            {
                this.trafficName = value;
            }
        }
    }
}

