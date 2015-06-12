namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class ResCheckInDateRange
    {
        private string endDate;
        private string startDate;

        public string getEndDate()
        {
            return this.EndDate;
        }

        public string getStartDate()
        {
            return this.StartDate;
        }

        public void setEndDate(string endDate)
        {
            this.EndDate = endDate;
        }

        public void setStartDate(string startDate)
        {
            this.StartDate = startDate;
        }

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

