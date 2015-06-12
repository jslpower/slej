namespace com.travelsky.hotelbesdk.models.basicproperty
{
    using System;
    using System.Xml.Serialization;

    [XmlRoot("HotelAmenity", Namespace="basicproperty")]
    public class HotelAmenity
    {
        private string amenityName;
        private string amenityType;
        private string status;

        [XmlAttribute("AmenityName")]
        public string AmenityName
        {
            get
            {
                return this.amenityName;
            }
            set
            {
                this.amenityName = value;
            }
        }

        [XmlAttribute("AmenityType")]
        public string AmenityType
        {
            get
            {
                return this.amenityType;
            }
            set
            {
                this.amenityType = value;
            }
        }

        [XmlAttribute("Status")]
        public string Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
            }
        }
    }
}

