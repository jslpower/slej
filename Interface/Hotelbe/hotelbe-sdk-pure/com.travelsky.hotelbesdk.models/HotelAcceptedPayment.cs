namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Xml.Serialization;

    public class HotelAcceptedPayment
    {
        private string cardCode;
        private string cardName;
        private string cardType;

        [XmlAttribute("CardCode")]
        public string CardCode
        {
            get
            {
                return this.cardCode;
            }
            set
            {
                this.cardCode = value;
            }
        }

        [XmlAttribute("CardName")]
        public string CardName
        {
            get
            {
                return this.cardName;
            }
            set
            {
                this.cardName = value;
            }
        }

        [XmlAttribute("CardType")]
        public string CardType
        {
            get
            {
                return this.cardType;
            }
            set
            {
                this.cardType = value;
            }
        }
    }
}

