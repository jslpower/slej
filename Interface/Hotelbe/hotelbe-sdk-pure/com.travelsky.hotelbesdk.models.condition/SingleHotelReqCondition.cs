namespace com.travelsky.hotelbesdk.models.condition
{
    using System;
    using System.Collections;

    public class SingleHotelReqCondition : BaseReqCondition
    {
        private string checkindate;
        private string checkoutdate;
        private string hotelcode;
        private string payment;
        private ArrayList vendorcodes;

        public SingleHotelReqCondition()
        {
            this.Vendorcodes = new ArrayList();
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

        public string getPayment()
        {
            return this.payment;
        }

        public ArrayList getVendorcodes()
        {
            return this.vendorcodes;
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

        public void setPayment(string payment)
        {
            this.payment = payment;
        }

        public void setVendorcodes(ArrayList vendors)
        {
            this.vendorcodes = vendors;
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

        public string Payment
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
    }
}

