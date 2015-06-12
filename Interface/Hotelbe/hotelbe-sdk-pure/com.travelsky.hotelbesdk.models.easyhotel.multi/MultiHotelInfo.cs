namespace com.travelsky.hotelbesdk.models.easyhotel.multi
{
    using System;

    public class MultiHotelInfo
    {
        private string checkindate;
        private string checkoutdate;
        private string citycode;
        private int pageindex;
        private int pagesize;
        private bool status;
        private int totalhotels;
        private int totalpage;

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

        public string Citycode
        {
            get
            {
                return this.citycode;
            }
            set
            {
                this.citycode = value;
            }
        }

        public int Pageindex
        {
            get
            {
                return this.pageindex;
            }
            set
            {
                this.pageindex = value;
            }
        }

        public int Pagesize
        {
            get
            {
                return this.pagesize;
            }
            set
            {
                this.pagesize = value;
            }
        }

        public bool Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
            }
        }

        public int Totalhotels
        {
            get
            {
                return this.totalhotels;
            }
            set
            {
                this.totalhotels = value;
            }
        }

        public int Totalpage
        {
            get
            {
                return this.totalpage;
            }
            set
            {
                this.totalpage = value;
            }
        }
    }
}

