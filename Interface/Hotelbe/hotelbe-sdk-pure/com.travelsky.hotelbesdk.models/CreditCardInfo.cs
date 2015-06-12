namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Xml.Serialization;

    public class CreditCardInfo
    {
        private string cardCode;
        private string cardNum;
        private string cardType;
        private string cVV2;
        private string expireDate;
        private string iDNum;
        private string iDType;
        private string ownerName;
        private string tel;

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

        [XmlAttribute("CardNum")]
        public string CardNum
        {
            get
            {
                return this.cardNum;
            }
            set
            {
                this.cardNum = value;
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

        [XmlAttribute("CVV2")]
        public string CVV2
        {
            get
            {
                return this.cVV2;
            }
            set
            {
                this.cVV2 = value;
            }
        }

        [XmlAttribute("ExpireDate")]
        public string ExpireDate
        {
            get
            {
                return this.expireDate;
            }
            set
            {
                this.expireDate = value;
            }
        }

        [XmlAttribute("IDNum")]
        public string IDNum
        {
            get
            {
                return this.iDNum;
            }
            set
            {
                this.iDNum = value;
            }
        }

        [XmlAttribute("IDType")]
        public string IDType
        {
            get
            {
                return this.iDType;
            }
            set
            {
                this.iDType = value;
            }
        }

        [XmlAttribute("OwnerName")]
        public string OwnerName
        {
            get
            {
                return this.ownerName;
            }
            set
            {
                this.ownerName = value;
            }
        }

        [XmlAttribute("Tel")]
        public string Tel
        {
            get
            {
                return this.tel;
            }
            set
            {
                this.tel = value;
            }
        }
    }
}

