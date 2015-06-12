namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class UpdateHotelsRQ
    {
        private string endTime;
        private string starTime;
        private string type;

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

        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }
    }
}

