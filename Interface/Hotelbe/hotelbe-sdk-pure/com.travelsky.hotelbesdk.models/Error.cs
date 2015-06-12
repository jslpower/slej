namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Xml.Serialization;

    public class Error
    {
        private string errorCode;
        private string errorDesc;

        [XmlAttribute("ErrorCode")]
        public string ErrorCode
        {
            get
            {
                return this.errorCode;
            }
            set
            {
                this.errorCode = value;
            }
        }

        [XmlAttribute("ErrorDesc")]
        public string ErrorDesc
        {
            get
            {
                return this.errorDesc;
            }
            set
            {
                this.errorDesc = value;
            }
        }
    }
}

