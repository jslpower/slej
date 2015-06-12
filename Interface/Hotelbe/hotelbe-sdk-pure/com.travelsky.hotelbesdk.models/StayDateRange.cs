namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Xml.Serialization;

    public class StayDateRange
    {
        private string checkInDate;
        private string checkInDateOld;
        private string checkOutDate;
        private string checkOutDateOld;

        [XmlAttribute("CheckInDate")]
        public string CheckInDate
        {
            get
            {
                return this.checkInDate;
            }
            set
            {
                this.checkInDate = value;
            }
        }

        [XmlAttribute("CheckInDateOld")]
        public string CheckInDateOld
        {
            get
            {
                return this.checkInDateOld;
            }
            set
            {
                this.checkInDateOld = value;
            }
        }

        [XmlAttribute("CheckOutDate")]
        public string CheckOutDate
        {
            get
            {
                return this.checkOutDate;
            }
            set
            {
                this.checkOutDate = value;
            }
        }

        [XmlAttribute("CheckOutDateOld")]
        public string CheckOutDateOld
        {
            get
            {
                return this.checkOutDateOld;
            }
            set
            {
                this.checkOutDateOld = value;
            }
        }
    }
}

