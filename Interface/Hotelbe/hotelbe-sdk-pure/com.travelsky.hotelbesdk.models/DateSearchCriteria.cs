namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Xml.Serialization;

    public class DateSearchCriteria
    {
        private string dateType;
        private com.travelsky.hotelbesdk.models.TimeSpan timeSpan;

        [XmlAttribute("DateType")]
        public string DateType
        {
            get
            {
                return this.dateType;
            }
            set
            {
                this.dateType = value;
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

