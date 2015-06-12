namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class HotelResSearchCriteria
    {
        private com.travelsky.hotelbesdk.models.BookingDateRange bookingDateRange = new com.travelsky.hotelbesdk.models.BookingDateRange();
        private string guestMobile;
        private string guestName;
        private string hotelName;
        private com.travelsky.hotelbesdk.models.ReqPageInfo reqPageInfo = new com.travelsky.hotelbesdk.models.ReqPageInfo();
        private com.travelsky.hotelbesdk.models.ResCheckInDateRange resCheckInDateRange;
        private com.travelsky.hotelbesdk.models.ResCheckOutDateRange resCheckOutDateRange;
        private string resID;
        private string resStatus;

        public com.travelsky.hotelbesdk.models.BookingDateRange getBookingDateRange()
        {
            return this.bookingDateRange;
        }

        public string getGuestMobile()
        {
            return this.guestMobile;
        }

        public string getGuestName()
        {
            return this.guestName;
        }

        public string getHotelName()
        {
            return this.hotelName;
        }

        public com.travelsky.hotelbesdk.models.ReqPageInfo getReqPageInfo()
        {
            return this.reqPageInfo;
        }

        public string getResID()
        {
            return this.resID;
        }

        public string getResStatus()
        {
            return this.resStatus;
        }

        public void setBookingDateRange(com.travelsky.hotelbesdk.models.BookingDateRange bookingDateRange)
        {
            this.bookingDateRange = bookingDateRange;
        }

        public void setGuestMobile(string guestMobile)
        {
            this.guestMobile = guestMobile;
        }

        public void setGuestName(string guestName)
        {
            this.guestName = guestName;
        }

        public void setHotelName(string hotelName)
        {
            this.hotelName = hotelName;
        }

        public void setReqPageInfo(com.travelsky.hotelbesdk.models.ReqPageInfo reqPageInfo)
        {
            this.reqPageInfo = reqPageInfo;
        }

        public void setResID(string resID)
        {
            this.resID = resID;
        }

        public void setResStatus(string resStatus)
        {
            this.resStatus = resStatus;
        }

        public com.travelsky.hotelbesdk.models.BookingDateRange BookingDateRange
        {
            get
            {
                return this.bookingDateRange;
            }
            set
            {
                this.bookingDateRange = value;
            }
        }

        public string GuestMobile
        {
            get
            {
                return this.guestMobile;
            }
            set
            {
                this.guestMobile = value;
            }
        }

        public string GuestName
        {
            get
            {
                return this.guestName;
            }
            set
            {
                this.guestName = value;
            }
        }

        public string HotelName
        {
            get
            {
                return this.hotelName;
            }
            set
            {
                this.hotelName = value;
            }
        }

        public com.travelsky.hotelbesdk.models.ReqPageInfo ReqPageInfo
        {
            get
            {
                return this.reqPageInfo;
            }
            set
            {
                this.reqPageInfo = value;
            }
        }

        public com.travelsky.hotelbesdk.models.ResCheckInDateRange ResCheckInDateRange
        {
            get
            {
                return this.resCheckInDateRange;
            }
            set
            {
                this.resCheckInDateRange = value;
            }
        }

        public com.travelsky.hotelbesdk.models.ResCheckOutDateRange ResCheckOutDateRange
        {
            get
            {
                return this.resCheckOutDateRange;
            }
            set
            {
                this.resCheckOutDateRange = value;
            }
        }

        public string ResID
        {
            get
            {
                return this.resID;
            }
            set
            {
                this.resID = value;
            }
        }

        public string ResStatus
        {
            get
            {
                return this.resStatus;
            }
            set
            {
                this.resStatus = value;
            }
        }
    }
}

