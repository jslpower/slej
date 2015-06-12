namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models;
    using System;

    public class TH_HotelMultiAvailRQ : BaseRQ
    {
        private com.travelsky.hotelbesdk.models.HotelAvailRQ hotelAvailRQ = new com.travelsky.hotelbesdk.models.HotelAvailRQ();

        public TH_HotelMultiAvailRQ()
        {
            base.OtRequest.HotelAvailRQ = this.hotelAvailRQ;
        }

        public void setCheckInDate(string checkInDate)
        {
            base.OtRequest.HotelAvailRQ.HotelAvailCriteria.StayDateRange.CheckInDate = checkInDate;
        }

        public void setCheckOutDate(string checkOutDate)
        {
            base.OtRequest.HotelAvailRQ.HotelAvailCriteria.StayDateRange.CheckOutDate = checkOutDate;
        }

        public void setCountryCode(string strCountryCode)
        {
            base.OtRequest.HotelAvailRQ.HotelAvailCriteria.HotelSearchCriteria.HotelRef.CountryCode = strCountryCode;
        }

        public void setHotelCityCode(string strCityCode)
        {
            HotelRef ref2 = new HotelRef {
                CityCode = strCityCode
            };
            base.OtRequest.HotelAvailRQ.HotelAvailCriteria.HotelSearchCriteria.HotelRef = ref2;
        }

        public void setIncludingTest(string includingTest)
        {
            this.hotelAvailRQ.HotelAvailCriteria.HotelSearchCriteria.IncludingTest = includingTest;
        }

        public com.travelsky.hotelbesdk.models.HotelAvailRQ HotelAvailRQ
        {
            get
            {
                return this.hotelAvailRQ;
            }
            set
            {
                this.hotelAvailRQ = value;
            }
        }
    }
}

