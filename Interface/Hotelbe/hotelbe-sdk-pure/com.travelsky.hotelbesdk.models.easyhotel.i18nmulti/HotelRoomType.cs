namespace com.travelsky.hotelbesdk.models.easyhotel.i18nmulti
{
    using System;
    using System.Collections.Generic;

    public class HotelRoomType
    {
        private List<HotelRatePlan> rateplan = new List<HotelRatePlan>();
        private string roomtypecode;
        private string roomtypename;

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

