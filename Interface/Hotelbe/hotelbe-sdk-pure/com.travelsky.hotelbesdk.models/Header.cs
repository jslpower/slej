namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Xml.Serialization;

    [XmlRoot("Header")]
    public class Header
    {
        private string application;
        private string encoding;
        private string invoker;
        private string language = "CN";
        private string locale;
        private string serialNo;
        private string sessionID;
        private string timeStamp;
        private string version;

        public string Application
        {
            get
            {
                return this.application;
            }
            set
            {
                this.application = value;
            }
        }

        public string Encoding
        {
            get
            {
                return this.encoding;
            }
            set
            {
                this.encoding = value;
            }
        }

        public string Invoker
        {
            get
            {
                return this.invoker;
            }
            set
            {
                this.invoker = value;
            }
        }

        public string Language
        {
            get
            {
                return this.language;
            }
            set
            {
                this.language = value;
            }
        }

        public string Locale
        {
            get
            {
                return this.locale;
            }
            set
            {
                this.locale = value;
            }
        }

        public string SerialNo
        {
            get
            {
                return this.serialNo;
            }
            set
            {
                this.serialNo = value;
            }
        }

        public string SessionID
        {
            get
            {
                return this.sessionID;
            }
            set
            {
                this.sessionID = value;
            }
        }

        public string TimeStamp
        {
            get
            {
                return this.timeStamp;
            }
            set
            {
                this.timeStamp = value;
            }
        }

        public string Version
        {
            get
            {
                return this.version;
            }
            set
            {
                this.version = value;
            }
        }
    }
}

