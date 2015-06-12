namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Xml.Serialization;

    public class RateRange
    {
        private string currency;
        private string maxRate;
        private string minRate;

        public string Currency
        {
            get
            {
                return this.currency;
            }
            set
            {
                this.currency = value;
            }
        }

        [XmlAttribute("MaxRate")]
        public string MaxRate
        {
            get
            {
                return this.maxRate;
            }
            set
            {
                this.maxRate = value;
            }
        }

        [XmlAttribute("MinRate")]
        public string MinRate
        {
            get
            {
                return this.minRate;
            }
            set
            {
                this.minRate = value;
            }
        }
    }
}

