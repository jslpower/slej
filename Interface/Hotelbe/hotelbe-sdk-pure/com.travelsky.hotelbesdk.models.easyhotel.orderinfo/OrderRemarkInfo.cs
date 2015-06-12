namespace com.travelsky.hotelbesdk.models.easyhotel.orderinfo
{
    using System;

    public class OrderRemarkInfo
    {
        private string operaTor;
        private string processDateTime;
        private string processType;
        private string remark;

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
    }
}

