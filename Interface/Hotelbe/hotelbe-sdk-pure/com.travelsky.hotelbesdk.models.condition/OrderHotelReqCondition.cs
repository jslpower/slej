namespace com.travelsky.hotelbesdk.models.condition
{
    using com.travelsky.hotelbesdk.models.easyhotel.order;
    using System;
    using System.Collections.Generic;

    public class OrderHotelReqCondition : BaseReqCondition
    {
        private string checkindate;
        private string checkoutdate;
        private com.travelsky.hotelbesdk.models.condition.Contact contact = new com.travelsky.hotelbesdk.models.condition.Contact();
        private string earlyarrivetime;
        private bool guarantee = false;
        private List<string> guests = new List<string>();
        private string hotelcode;
        private HotelCreditCardInfo hotelcreditcardinfo = new HotelCreditCardInfo();
        private string isEmailContact = "Y";
        private string isMobileContact = "Y";
        private string latearrivetime;
        private string payment;
        private List<RoomPrice> roomprices = new List<RoomPrice>();
        private string specialRequest;

        public string getCheckindate()
        {
            return this.checkindate;
        }

        public string getCheckoutdate()
        {
            return this.checkoutdate;
        }

        public com.travelsky.hotelbesdk.models.condition.Contact getContact()
        {
            return this.contact;
        }

        public string getEarlyarrivetime()
        {
            return this.earlyarrivetime;
        }

        public bool getGuarantee()
        {
            return this.guarantee;
        }

        public List<string> getGuests()
        {
            return this.guests;
        }

        public string getHotelcode()
        {
            return this.hotelcode;
        }

        public HotelCreditCardInfo getHotelCreditCardInfo()
        {
            return this.hotelcreditcardinfo;
        }

        public string getLatearrivetime()
        {
            return this.latearrivetime;
        }

        public string getPayment()
        {
            return this.payment;
        }

        public List<RoomPrice> getRoomprices()
        {
            return this.roomprices;
        }

        public void setCheckindate(string checkindate)
        {
            this.checkindate = checkindate;
        }

        public void setCheckoutdate(string checkoutdate)
        {
            this.checkoutdate = checkoutdate;
        }

        public void setContact(com.travelsky.hotelbesdk.models.condition.Contact contact)
        {
            this.contact = contact;
        }

        public void setEarlyarrivetime(string earlyarrivetime)
        {
            this.earlyarrivetime = earlyarrivetime;
        }

        public void setGuarantee(bool guarantee)
        {
            this.guarantee = guarantee;
        }

        public void setGuests(List<string> guests)
        {
            this.guests = guests;
        }

        public void setHotelcode(string hotelcode)
        {
            this.hotelcode = hotelcode;
        }

        public void setHotelCreditCardInfo(HotelCreditCardInfo hotelcreditcardinfo)
        {
            this.hotelcreditcardinfo = hotelcreditcardinfo;
        }

        public void setLatearrivetime(string latearrivetime)
        {
            this.latearrivetime = latearrivetime;
        }

        public void setPayment(string payment)
        {
            this.payment = payment;
        }

        public void setRoomprices(List<RoomPrice> roomprices)
        {
            this.roomprices = roomprices;
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

        public com.travelsky.hotelbesdk.models.condition.Contact Contact
        {
            get
            {
                return this.contact;
            }
            set
            {
                this.contact = value;
            }
        }

        public string Earlyarrivetime
        {
            get
            {
                return this.earlyarrivetime;
            }
            set
            {
                this.earlyarrivetime = value;
            }
        }

        public bool Guarantee
        {
            get
            {
                return this.guarantee;
            }
            set
            {
                this.guarantee = value;
            }
        }

        public List<string> Guests
        {
            get
            {
                return this.guests;
            }
            set
            {
                this.guests = value;
            }
        }

        public string Hotelcode
        {
            get
            {
                return this.hotelcode;
            }
            set
            {
                this.hotelcode = value;
            }
        }

        public HotelCreditCardInfo Hotelcreditcardinfo
        {
            get
            {
                return this.hotelcreditcardinfo;
            }
            set
            {
                this.hotelcreditcardinfo = value;
            }
        }

        public string IsEmailContact
        {
            get
            {
                return this.isEmailContact;
            }
            set
            {
                this.isEmailContact = value;
            }
        }

        public string IsMobileContact
        {
            get
            {
                return this.isMobileContact;
            }
            set
            {
                this.isMobileContact = value;
            }
        }

        public string Latearrivetime
        {
            get
            {
                return this.latearrivetime;
            }
            set
            {
                this.latearrivetime = value;
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

        public List<RoomPrice> Roomprices
        {
            get
            {
                return this.roomprices;
            }
            set
            {
                this.roomprices = value;
            }
        }

        public string SpecialRequest
        {
            get
            {
                return this.specialRequest;
            }
            set
            {
                this.specialRequest = value;
            }
        }
    }
}

