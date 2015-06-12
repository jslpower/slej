namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Xml.Serialization;

    public class Position
    {
        private string latitude;
        private string longitude;

        [XmlAttribute("Latitude")]
        public string Latitude
        {
            get
            {
                return this.latitude;
            }
            set
            {
                this.latitude = value;
            }
        }

        [XmlAttribute("Longitude")]
        public string Longitude
        {
            get
            {
                return this.longitude;
            }
            set
            {
                this.longitude = value;
            }
        }
    }
}

