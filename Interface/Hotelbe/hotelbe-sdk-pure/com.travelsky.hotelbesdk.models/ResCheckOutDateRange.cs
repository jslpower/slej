namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class ResCheckOutDateRange
    {
        private string endDate;
        private string startDate;

        public string EndDate
        {
            get
            {
                return this.endDate;
            }
            set
            {
                this.endDate = value;
            }
        }

        public string StartDate
        {
            get
            {
                return this.startDate;
            }
            set
            {
                this.startDate = value;
            }
        }
    }
}

