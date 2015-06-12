namespace com.travelsky.hotelbesdk.models.condition
{
    using System;
    using System.Collections;

    public class EasyMultiHotelReqCondition : BaseReqCondition
    {
        private string checkindate;
        private string checkoutdate;
        private string chinesename;
        private string citycode;
        private bool confirmrightnow;
        private string district;
        private string englishname;
        private ENUM_INCLUDETEST including;
        private string isDefinedChannel;
        private string landMark;
        private int maxrate;
        private int minrate;
        private ENUM_ORDER order;
        private int pageno;
        private int pagesize;
        private string payment;
        private ENUM_RANK rank;
        private bool showdetail;
        private ArrayList vendorcodes;

        public EasyMultiHotelReqCondition()
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

        public string getChinesename()
        {
            return this.chinesename;
        }

        public string getCitycode()
        {
            return this.citycode;
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

        public ENUM_ORDER getOrder()
        {
            return this.order;
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

        public ENUM_RANK getRank()
        {
            return this.rank;
        }

        public bool getShowdetail()
        {
            return this.showdetail;
        }

        public ArrayList getVendorcodes()
        {
            return this.vendorcodes;
        }

        public bool isConfirmrightnow()
        {
            return this.confirmrightnow;
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

        public void setIncluding(ENUM_INCLUDETEST including)
        {
            this.Including = including;
        }

        public void setMaxrate(int maxrate)
        {
            this.maxrate = maxrate;
        }

        public void setMinrate(int minrate)
        {
            this.minrate = minrate;
        }

        public void setOrder(ENUM_ORDER order)
        {
            this.order = order;
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

        public void setRank(ENUM_RANK rank)
        {
            this.rank = rank;
        }

        public void setShowdetail(bool showdetail)
        {
            this.showdetail = showdetail;
        }

        public void setVendorcodes(ArrayList vendors)
        {
            this.vendorcodes = vendors;
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

        public ENUM_INCLUDETEST Including
        {
            get
            {
                return this.including;
            }
            set
            {
                this.including = value;
            }
        }

        public string IsDefinedChannel
        {
            get
            {
                return this.isDefinedChannel;
            }
            set
            {
                this.isDefinedChannel = value;
            }
        }

        public string LandMark
        {
            get
            {
                return this.landMark;
            }
            set
            {
                this.landMark = value;
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

        public enum ENUM_INCLUDETEST
        {
            INCLUDING_Y,
            INCLUDING_N
        }

        public enum ENUM_ORDER
        {
            ORDER_RANKASC,
            ORDER_RANKDESC,
            ORDER_PRICEASC,
            ORDER_PRICEDESC
        }

        public enum ENUM_RANK
        {
            rank_null,
            RANK_1,
            RANK_2,
            RANK_3,
            RANK_4,
            RANK_5,
            RANK_1S,
            RANK_2S,
            RANK_3S,
            RANK_4S,
            RANK_5S,
            RANK_1A,
            RANK_2A,
            RANK_3A,
            RANK_4A,
            RANK_5A
        }
    }
}

