namespace com.travelsky.hotelbesdk.models.condition
{
    using System;

    public class MultiHotelReqCondition : BaseReqCondition
    {
        private string checkindate;
        private string checkoutdate;
        private string chinesename;
        private string citycode;
        private bool confirmrightnow;
        private string district;
        private string englishname;
        private int maxrate;
        private int minrate;
        private int pageno;
        private int pagesize;
        private string payment;
        private string rank;
        private bool showdetail;

        public string getCheckindate()
        {
            return this.checkindate;
        }

        public string getCheckoutdate()
        {
            return this.checkoutdate;
        }

        public string getChinesename()
        {
            return this.chinesename;
        }

        public string getCitycode()
        {
            return this.citycode;
        }

        public bool getConfirmrightnow()
        {
            return this.confirmrightnow;
        }

        public string getDistrict()
        {
            return this.district;
        }

        public string getEnglishname()
        {
            return this.englishname;
        }

        public int getMaxrate()
        {
            return this.maxrate;
        }

        public int getMinrate()
        {
            return this.minrate;
        }

        public int getPageno()
        {
            return this.pageno;
        }

        public int getPagesize()
        {
            return this.pagesize;
        }

        public string getPayment()
        {
            return this.payment;
        }

        public string getRank()
        {
            return this.rank;
        }

        public bool getShowdetail()
        {
            return this.showdetail;
        }

        public void setCheckindate(string checkindate)
        {
            this.checkindate = checkindate;
        }

        public void setCheckoutdate(string checkoutdate)
        {
            this.checkoutdate = checkoutdate;
        }

        public void setChinesename(string chinesename)
        {
            this.chinesename = chinesename;
        }

        public void setCitycode(string citycode)
        {
            this.citycode = citycode;
        }

        public void setConfirmrightnow(bool confirmrightnow)
        {
            this.confirmrightnow = confirmrightnow;
        }

        public void setDistrict(string district)
        {
            this.district = district;
        }

        public void setEnglishname(string englishname)
        {
            this.englishname = englishname;
        }

        public void setMaxrate(int maxrate)
        {
            this.maxrate = maxrate;
        }

        public void setMinrate(int minrate)
        {
            this.minrate = minrate;
        }

        public void setPageno(int pageno)
        {
            this.pageno = pageno;
        }

        public void setPagesize(int pagesize)
        {
            this.pagesize = pagesize;
        }

        public void setPayment(string payment)
        {
            this.payment = payment;
        }

        public void setRank(string rank)
        {
            this.rank = rank;
        }

        public void setShowdetail(bool showdetail)
        {
            this.showdetail = showdetail;
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

        public string Chinesename
        {
            get
            {
                return this.chinesename;
            }
            set
            {
                this.chinesename = value;
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

        public bool Confirmrightnow
        {
            get
            {
                return this.confirmrightnow;
            }
            set
            {
                this.confirmrightnow = value;
            }
        }

        public string District
        {
            get
            {
                return this.district;
            }
            set
            {
                this.district = value;
            }
        }

        public string Englishname
        {
            get
            {
                return this.englishname;
            }
            set
            {
                this.englishname = value;
            }
        }

        public int Maxrate
        {
            get
            {
                return this.maxrate;
            }
            set
            {
                this.maxrate = value;
            }
        }

        public int Minrate
        {
            get
            {
                return this.minrate;
            }
            set
            {
                this.minrate = value;
            }
        }

        public int Pageno
        {
            get
            {
                return this.pageno;
            }
            set
            {
                this.pageno = value;
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

        public string Rank
        {
            get
            {
                return this.rank;
            }
            set
            {
                this.rank = value;
            }
        }

        public bool Showdetail
        {
            get
            {
                return this.showdetail;
            }
            set
            {
                this.showdetail = value;
            }
        }
    }
}

