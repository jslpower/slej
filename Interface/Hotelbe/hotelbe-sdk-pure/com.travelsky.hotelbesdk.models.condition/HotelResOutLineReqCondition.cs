namespace com.travelsky.hotelbesdk.models.condition
{
    using System;

    public class HotelResOutLineReqCondition : BaseReqCondition
    {
        private string bookingDateEnd;
        private string bookingDateStart;
        private string checkInDateEnd;
        private string checkInDateStart;
        private string checkOutDateEnd;
        private string checkOutDateStart;
        private string guestMobile;
        private string guestName;
        private string hotelName;
        private string orderid;
        private string reqNumOfEachPage;
        private string reqPageNo;
        private string resStatus;

        public string getBookingDateEnd()
        {
            return this.BookingDateEnd;
        }

        public string getBookingDateStart()
        {
            return this.BookingDateStart;
        }

        public string getCheckInDateEnd()
        {
            return this.CheckInDateEnd;
        }

        public string getCheckInDateStart()
        {
            return this.CheckInDateStart;
        }

        public string getCheckOutDateEnd()
        {
            return this.CheckOutDateEnd;
        }

        public string getCheckOutDateStart()
        {
            return this.CheckOutDateStart;
        }

        public string getGuestMobile()
        {
            return this.GuestMobile;
        }

        public string getGuestName()
        {
            return this.GuestName;
        }

        public string getHotelName()
        {
            return this.HotelName;
        }

        public string getOrderid()
        {
            return this.Orderid;
        }

        public string getReqNumOfEachPage()
        {
            return this.ReqNumOfEachPage;
        }

        public string getReqPageNo()
        {
            return this.ReqPageNo;
        }

        public string getResStatus()
        {
            return this.ResStatus;
        }

        public void setBookingDateEnd(string bookingDateEnd)
        {
            this.BookingDateEnd = bookingDateEnd;
        }

        public void setBookingDateStart(string bookingDateStart)
        {
            this.BookingDateStart = bookingDateStart;
        }

        public void setCheckInDateEnd(string checkInDateEnd)
        {
            this.CheckInDateEnd = checkInDateEnd;
        }

        public void setCheckInDateStart(string checkInDateStart)
        {
            this.CheckInDateStart = checkInDateStart;
        }

        public void setCheckOutDateEnd(string checkOutDateEnd)
        {
            this.CheckOutDateEnd = checkOutDateEnd;
        }

        public void setCheckOutDateStart(string checkOutDateStart)
        {
            this.CheckOutDateStart = checkOutDateStart;
        }

        public void setGuestMobile(string guestMobile)
        {
            this.GuestMobile = guestMobile;
        }

        public void setGuestName(string guestName)
        {
            this.GuestName = guestName;
        }

        public void setHotelName(string hotelName)
        {
            this.HotelName = hotelName;
        }

        public void setOrderid(string orderid)
        {
            this.Orderid = orderid;
        }

        public void setReqNumOfEachPage(string reqNumOfEachPage)
        {
            this.ReqNumOfEachPage = reqNumOfEachPage;
        }

        public void setReqPageNo(string reqPageNo)
        {
            this.ReqPageNo = reqPageNo;
        }

        public void setResStatus(string resStatus)
        {
            this.ResStatus = resStatus;
        }

        public string BookingDateEnd
        {
            get
            {
                return this.bookingDateEnd;
            }
            set
            {
                this.bookingDateEnd = value;
            }
        }

        public string BookingDateStart
        {
            get
            {
                return this.bookingDateStart;
            }
            set
            {
                this.bookingDateStart = value;
            }
        }

        public string CheckInDateEnd
        {
            get
            {
                return this.checkInDateEnd;
            }
            set
            {
                this.checkInDateEnd = value;
            }
        }

        public string CheckInDateStart
        {
            get
            {
                return this.checkInDateStart;
            }
            set
            {
                this.checkInDateStart = value;
            }
        }

        public string CheckOutDateEnd
        {
            get
            {
                return this.checkOutDateEnd;
            }
            set
            {
                this.checkOutDateEnd = value;
            }
        }

        public string CheckOutDateStart
        {
            get
            {
                return this.checkOutDateStart;
            }
            set
            {
                this.checkOutDateStart = value;
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

        public string Orderid
        {
            get
            {
                return this.orderid;
            }
            set
            {
                this.orderid = value;
            }
        }

        public string ReqNumOfEachPage
        {
            get
            {
                return this.reqNumOfEachPage;
            }
            set
            {
                this.reqNumOfEachPage = value;
            }
        }

        public string ReqPageNo
        {
            get
            {
                return this.reqPageNo;
            }
            set
            {
                this.reqPageNo = value;
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

