namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Xml.Serialization;

    public class VendorMessage
    {
        private string vendorCode;
        private string vendorPromotionCode;

        [XmlAttribute("VendorCode")]
        public string VendorCode
        {
            get
            {
                return this.vendorCode;
            }
            set
            {
                this.vendorCode = value;
            }
        }

        public string VendorPromotionCode
        {
            get
            {
                return this.vendorPromotionCode;
            }
            set
            {
                this.vendorPromotionCode = value;
            }
        }
    }
}

