namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Xml.Serialization;

    public class BookingDateRange
    {
        private string endDate;
        private string startDate;

        public string getEndDate()
        {
            return this.endDate;
        }

        public string getStartDate()
        {
            return this.startDate;
        }

        public void setEndDate(string endDate)
        {
            this.endDate = endDate;
        }

        public void setStartDate(string startDate)
        {
            this.startDate = startDate;
        }

        [XmlAttribute("EndDate")]
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

        [XmlAttribute("StartDate")]
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

