namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Xml.Serialization;

    public class HotelResProcess
    {
        private string operaTor;
        private string processDateTime;
        private string processType;
        private string remark;
        private string resOrderID;

        [XmlAttribute("Operator")]
        public string OperaTor
        {
            get
            {
                return this.operaTor;
            }
            set
            {
                this.operaTor = value;
            }
        }

        public string ProcessDateTime
        {
            get
            {
                return this.processDateTime;
            }
            set
            {
                this.processDateTime = value;
            }
        }

        [XmlAttribute("ProcessType")]
        public string ProcessType
        {
            get
            {
                return this.processType;
            }
            set
            {
                this.processType = value;
            }
        }

        public string Remark
        {
            get
            {
                return this.remark;
            }
            set
            {
                this.remark = value;
            }
        }

        [XmlAttribute("ResOrderID")]
        public string ResOrderID
        {
            get
            {
                return this.resOrderID;
            }
            set
            {
                this.resOrderID = value;
            }
        }
    }
}

