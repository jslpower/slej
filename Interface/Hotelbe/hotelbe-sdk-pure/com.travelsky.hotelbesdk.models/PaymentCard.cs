namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Xml.Serialization;

    public class PaymentCard
    {
        private string cardCode;
        private string cardName;

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
    }
}

