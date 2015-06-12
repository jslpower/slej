namespace com.travelsky.hotelbesdk.models.condition
{
    using System;
    using System.Collections;

    public class EasySingleHotelReqCondition : BaseReqCondition
    {
        private ENUM_REQ availReqType;
        private string checkindate;
        private string checkoutdate;
        private string hotelcode;
        private ENUM_PAYMENT payment;
        private string ratePlanCode;
        private string roomTypeCode;
        private ArrayList vendorcodes;

        public EasySingleHotelReqCondition()
        {
            this.Vendorcodes = new ArrayList();
        }

        public ENUM_REQ getAvailReqType()
        {
            return this.availReqType;
        }

        public string getCheckindate()
        {
            return this.checkindate;
        }

        public string getCheckoutdate()
        {
            return this.checkoutdate;
        }

        public string getHotelcode()
        {
            return this.hotelcode;
        }

        public ENUM_PAYMENT getPayment()
        {
            return this.payment;
        }

        public ArrayList getVendorcodes()
        {
            return this.vendorcodes;
        }

        public void setAvailReqType(ENUM_REQ availReqType)
        {
            this.availReqType = availReqType;
        }

        public void setCheckindate(string checkindate)
        {
            this.checkindate = checkindate;
        }

        public void setCheckoutdate(string checkoutdate)
        {
            this.checkoutdate = checkoutdate;
        }

        public void setHotelcode(string hotelcode)
        {
            this.hotelcode = hotelcode;
        }

        public void setPayment(ENUM_PAYMENT payment)
        {
            this.payment = payment;
        }

        public void setVendorcodes(ArrayList vendors)
        {
            this.vendorcodes = vendors;
        }

        public ENUM_REQ AvailReqType
        {
            get
            {
                return this.availReqType;
            }
            set
            {
                this.availReqType = value;
            }
        }

        public string Checkindate
        {
            get
            {
                return this.checkindate;
            }
            set
            {
                this.checkindate = value;
            }
        }

        public string Checkoutdate
        {
            get
            {
                return this.checkoutdate;
            }
            set
            {
                this.checkoutdate = value;
            }
        }

        public string Hotelcode
        {
            get
            {
                return this.hotelcode;
            }
            set
            {
                this.hotelcode = value;
            }
        }

        public ENUM_PAYMENT Payment
        {
            get
            {
                return this.payment;
            }
            set
            {
                this.payment = value;
            }
        }

        public string RatePlanCode
        {
            get
            {
                return this.ratePlanCode;
            }
            set
            {
                this.ratePlanCode = value;
            }
        }

        public string RoomTypeCode
        {
            get
            {
                return this.roomTypeCode;
            }
            set
            {
                this.roomTypeCode = value;
            }
        }

        public ArrayList Vendorcodes
        {
            get
            {
                return this.vendorcodes;
            }
            set
            {
                this.vendorcodes = value;
            }
        }

        public enum ENUM_PAYMENT
        {
            PAYMENT_ALL,
            PAYMENT_COUNTER,
            PAYMENT_ADVANCED
        }

        public enum ENUM_REQ
        {
            REQ_INCLUDE,
            REQ_NONE
        }
    }
}

