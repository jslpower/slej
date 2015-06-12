namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Xml.Serialization;

    public class BaseHotelBEXml
    {
        private com.travelsky.hotelbesdk.models.Header header;
        private com.travelsky.hotelbesdk.models.IdentityInfo identityInfo;
        private string transactionName;

        [XmlElement("Header")]
        public com.travelsky.hotelbesdk.models.Header Header
        {
            get
            {
                return this.header;
            }
            set
            {
                this.header = value;
            }
        }

        [XmlElement("IdentityInfo")]
        public com.travelsky.hotelbesdk.models.IdentityInfo IdentityInfo
        {
            get
            {
                return this.identityInfo;
            }
            set
            {
                this.identityInfo = value;
            }
        }

        [XmlElement("TransactionName")]
        public string TransactionName
        {
            get
            {
                return this.transactionName;
            }
            set
            {
                this.transactionName = value;
            }
        }
    }
}

