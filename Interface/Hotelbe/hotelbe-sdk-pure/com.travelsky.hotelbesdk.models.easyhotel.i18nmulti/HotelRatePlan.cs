namespace com.travelsky.hotelbesdk.models.easyhotel.i18nmulti
{
    using System;
    using System.Collections.Generic;

    public class HotelRatePlan
    {
        private string averageprice;
        private string currency;
        private string firstdayprice;
        private string meal;
        private string rateplancode;
        private string rateplanname;
        private List<HotelRoomRate> roomrate = new List<HotelRoomRate>();

        public string Averageprice
        {
            get
            {
                return this.averageprice;
            }
            set
            {
                this.averageprice = value;
            }
        }

        public string Currency
        {
            get
            {
                return this.currency;
            }
            set
            {
                this.currency = value;
            }
        }

        public string Firstdayprice
        {
            get
            {
                return this.firstdayprice;
            }
            set
            {
                this.firstdayprice = value;
            }
        }

        public string Meal
        {
            get
            {
                return this.meal;
            }
            set
            {
                this.meal = value;
            }
        }

        public string Rateplancode
        {
            get
            {
                return this.rateplancode;
            }
            set
            {
                this.rateplancode = value;
            }
        }

        public string Rateplanname
        {
            get
            {
                return this.rateplanname;
            }
            set
            {
                this.rateplanname = value;
            }
        }

        public List<HotelRoomRate> Roomrate
        {
            get
            {
                return this.roomrate;
            }
            set
            {
                this.roomrate = value;
            }
        }
    }
}

