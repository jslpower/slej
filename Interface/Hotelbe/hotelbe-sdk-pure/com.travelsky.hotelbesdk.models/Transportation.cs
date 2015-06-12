namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Xml.Serialization;

    public class Transportation
    {
        private string carInterval;
        private string footInterval;

        [XmlAttribute("CarInterval")]
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

        [XmlAttribute("FootInterval")]
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
    }
}

