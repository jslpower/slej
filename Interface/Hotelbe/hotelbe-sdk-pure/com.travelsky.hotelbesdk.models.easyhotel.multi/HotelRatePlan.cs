namespace com.travelsky.hotelbesdk.models.easyhotel.multi
{
    using System;
    using System.Collections.Generic;

    public class HotelRatePlan
    {
        private string availabilityStatus;
        private string averageprice;
        private List<HotelBookingPolicy> bookingPolicys = new List<HotelBookingPolicy>();
        private List<HotelCancelPolicie> cancelPolicies;
        private List<HotelFavourPolicy> favourPolicys = new List<HotelFavourPolicy>();
        private string firstdayprice;
        private List<HotelGuaranteePolicy> hotelguaranteepolicy = new List<HotelGuaranteePolicy>();
        private string internet;
        private string isSign;
        private string meal;
        private string paymentmethod;
        private string rateplancode;
        private string rateplanname;
        private List<HotelRoomRate> roomrate = new List<HotelRoomRate>();
        private string vendor;

        public string AvailabilityStatus
        {
            get
            {
                return this.availabilityStatus;
            }
            set
            {
                this.availabilityStatus = value;
            }
        }

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

        public List<HotelBookingPolicy> BookingPolicys
        {
            get
            {
                return this.bookingPolicys;
            }
            set
            {
                this.bookingPolicys = value;
            }
        }

        public List<HotelCancelPolicie> CancelPolicies
        {
            get
            {
                return this.cancelPolicies;
            }
            set
            {
                this.cancelPolicies = value;
            }
        }

        public List<HotelFavourPolicy> FavourPolicys
        {
            get
            {
                return this.favourPolicys;
            }
            set
            {
                this.favourPolicys = value;
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

        public List<HotelGuaranteePolicy> Hotelguaranteepolicy
        {
            get
            {
                return this.hotelguaranteepolicy;
            }
            set
            {
                this.hotelguaranteepolicy = value;
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

        public string IsSign
        {
            get
            {
                return this.isSign;
            }
            set
            {
                this.isSign = value;
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

        public string Paymentmethod
        {
            get
            {
                return this.paymentmethod;
            }
            set
            {
                this.paymentmethod = value;
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

        public string Vendor
        {
            get
            {
                return this.vendor;
            }
            set
            {
                this.vendor = value;
            }
        }
    }
}

