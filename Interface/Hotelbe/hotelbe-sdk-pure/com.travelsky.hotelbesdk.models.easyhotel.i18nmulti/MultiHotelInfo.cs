namespace com.travelsky.hotelbesdk.models.easyhotel.i18nmulti
{
    using System;

    public class MultiHotelInfo
    {
        private int adultnum;
        private string checkindate;
        private string checkoutdate;
        private int childnum;
        private string citycode;
        private string countrycode;
        private int pageindex;
        private int pagesize;
        private int roomnum;
        private bool status;
        private int totalhotels;
        private int totalpage;

        public int Adultnum
        {
            get
            {
                return this.adultnum;
            }
            set
            {
                this.adultnum = value;
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

        public int Childnum
        {
            get
            {
                return this.childnum;
            }
            set
            {
                this.childnum = value;
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

        public string Countrycode
        {
            get
            {
                return this.countrycode;
            }
            set
            {
                this.countrycode = value;
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

        public int Roomnum
        {
            get
            {
                return this.roomnum;
            }
            set
            {
                this.roomnum = value;
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

