namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Xml.Serialization;

    public class Source
    {
        private string bookingChannel;
        private string officeCode;
        private string uniqueID;

        [XmlElement(ElementName="BookingChannel")]
        public string BookingChannel
        {
            get
            {
                return this.bookingChannel;
            }
            set
            {
                this.bookingChannel = value;
            }
        }

        [XmlElement(ElementName="OfficeCode")]
        public string OfficeCode
        {
            get
            {
                return this.officeCode;
            }
            set
            {
                this.officeCode = value;
            }
        }

        [XmlElement(ElementName="UniqueID")]
        public string UniqueID
        {
            get
            {
                return this.uniqueID;
            }
            set
            {
                this.uniqueID = value;
            }
        }
    }
}

