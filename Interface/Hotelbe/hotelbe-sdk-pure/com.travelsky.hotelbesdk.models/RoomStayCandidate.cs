namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public class RoomStayCandidate
    {
        private string bedType;
        private List<GuestCount> guestCounts = new List<GuestCount>();
        private string quantity;
        private string roomTypeCode;

        [XmlAttribute("BedType")]
        public string BedType
        {
            get
            {
                return this.bedType;
            }
            set
            {
                this.bedType = value;
            }
        }

        public List<GuestCount> GuestCounts
        {
            get
            {
                return this.guestCounts;
            }
            set
            {
                this.guestCounts = value;
            }
        }

        [XmlAttribute("Quantity")]
        public string Quantity
        {
            get
            {
                return this.quantity;
            }
            set
            {
                this.quantity = value;
            }
        }
        [XmlAttribute("RoomTypeCode")]
        public string RoomTypeCode
        {
            get
            {
                return this.roomTypeCode;
            }
            set
            {
                this.roomTypeCode = value;
            }
        }
    }
}

