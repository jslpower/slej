namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models;
    using System;

    public class TH_HotelSingleAvailRQ : BaseRQ
    {
        private com.travelsky.hotelbesdk.models.HotelAvailRQ hotelAvailRQ = new com.travelsky.hotelbesdk.models.HotelAvailRQ();

        public TH_HotelSingleAvailRQ()
        {
            base.OtRequest.HotelAvailRQ = this.hotelAvailRQ;
        }

        public void clear()
        {
            base.clear();
            this.hotelAvailRQ = new com.travelsky.hotelbesdk.models.HotelAvailRQ();
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

        public void setHotelCode(string hotelCode)
        {
            HotelRef ref2 = new HotelRef {
                HotelCode = hotelCode
            };
            base.OtRequest.HotelAvailRQ.HotelAvailCriteria.HotelSearchCriteria.HotelRef = ref2;
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

