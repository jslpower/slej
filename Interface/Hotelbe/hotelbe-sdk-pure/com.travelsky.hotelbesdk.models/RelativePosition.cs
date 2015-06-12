namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Xml.Serialization;

    public class RelativePosition
    {
        private string distance;
        private string shortDesc;
        private com.travelsky.hotelbesdk.models.Transportation transportation;
        private string type;

        [XmlAttribute("Distance")]
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

        [XmlAttribute("ShortDesc")]
        public string ShortDesc
        {
            get
            {
                return this.shortDesc;
            }
            set
            {
                this.shortDesc = value;
            }
        }

        public com.travelsky.hotelbesdk.models.Transportation Transportation
        {
            get
            {
                return this.transportation;
            }
            set
            {
                this.transportation = value;
            }
        }

        [XmlAttribute("Type")]
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

