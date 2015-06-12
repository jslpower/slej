namespace com.travelsky.hotelbesdk.models.condition
{
    using System;

    public class RoomPrice
    {
        private string enddate;
        private string rateplancode;
        private int roomnum;
        private string roomtypecode;
        private string startdate;
        private string vendorCode;

        public string getEnddate()
        {
            return this.enddate;
        }

        public string getRateplancode()
        {
            return this.rateplancode;
        }

        public int getRoomnum()
        {
            return this.roomnum;
        }

        public string getRoomtypecode()
        {
            return this.roomtypecode;
        }

        public string getStartdate()
        {
            return this.startdate;
        }

        public string getVendorCode()
        {
            return this.VendorCode;
        }

        public void setEnddate(string enddate)
        {
            this.enddate = enddate;
        }

        public void setRateplancode(string rateplancode)
        {
            this.rateplancode = rateplancode;
        }

        public void setRoomnum(int roomnum)
        {
            this.roomnum = roomnum;
        }

        public void setRoomtypecode(string roomtypecode)
        {
            this.roomtypecode = roomtypecode;
        }

        public void setStartdate(string startdate)
        {
            this.startdate = startdate;
        }

        public void setVendorCode(string vendorCode)
        {
            this.VendorCode = vendorCode;
        }

        public string Enddate
        {
            get
            {
                return this.enddate;
            }
            set
            {
                this.enddate = value;
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

        public string Startdate
        {
            get
            {
                return this.startdate;
            }
            set
            {
                this.startdate = value;
            }
        }

        public string VendorCode
        {
            get
            {
                return this.vendorCode;
            }
            set
            {
                this.vendorCode = value;
            }
        }
    }
}

