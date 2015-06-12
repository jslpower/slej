namespace com.travelsky.hotelbesdk.models.easyhotel.multi
{
    using System;
    using System.Collections.Generic;

    public class HotelRoomType
    {
        private string bedtype;
        private string desc;
        private string internet;
        private string marketprice;
        private List<HotelRatePlan> rateplan = new List<HotelRatePlan>();
        private string roomtypecode;
        private string roomtypename;

        public string Bedtype
        {
            get
            {
                return this.bedtype;
            }
            set
            {
                this.bedtype = value;
            }
        }

        public string Desc
        {
            get
            {
                return this.desc;
            }
            set
            {
                this.desc = value;
            }
        }

        public string Internet
        {
            get
            {
                return this.internet;
            }
            set
            {
                this.internet = value;
            }
        }

        public string Marketprice
        {
            get
            {
                return this.marketprice;
            }
            set
            {
                this.marketprice = value;
            }
        }

        public List<HotelRatePlan> Rateplan
        {
            get
            {
                return this.rateplan;
            }
            set
            {
                this.rateplan = value;
            }
        }

        public string Roomtypecode
        {
            get
            {
                return this.roomtypecode;
            }
            set
            {
                this.roomtypecode = value;
            }
        }

        public string Roomtypename
        {
            get
            {
                return this.roomtypename;
            }
            set
            {
                this.roomtypename = value;
            }
        }
    }
}

