namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Xml.Serialization;

    public class GuaranteeInfo
    {
        private com.travelsky.hotelbesdk.models.CreditCardInfo creditCardInfo;
        private string guaranteeType;

        public com.travelsky.hotelbesdk.models.CreditCardInfo CreditCardInfo
        {
            get
            {
                return this.creditCardInfo;
            }
            set
            {
                this.creditCardInfo = value;
            }
        }

        [XmlAttribute("GuaranteeType")]
        public string GuaranteeType
        {
            get
            {
                return this.guaranteeType;
            }
            set
            {
                this.guaranteeType = value;
            }
        }
    }
}

