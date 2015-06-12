namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models;
    using System;

    public class TH_HotelResDetailSearchRQ : BaseRQ
    {
        private com.travelsky.hotelbesdk.models.HotelResDetailSearchRQ hotelResDetailSearchRQ = new com.travelsky.hotelbesdk.models.HotelResDetailSearchRQ();

        public TH_HotelResDetailSearchRQ()
        {
            base.OtRequest.HotelResDetailSearchRQ = this.hotelResDetailSearchRQ;
        }

        public com.travelsky.hotelbesdk.models.HotelResDetailSearchRQ getHotelResDetailSearchRQ()
        {
            return this.hotelResDetailSearchRQ;
        }

        public void setHotelResDetailSearchRQ(com.travelsky.hotelbesdk.models.HotelResDetailSearchRQ hotelResDetailSearchRQ)
        {
            this.hotelResDetailSearchRQ = hotelResDetailSearchRQ;
        }

        public com.travelsky.hotelbesdk.models.HotelResDetailSearchRQ HotelResDetailSearchRQ
        {
            get
            {
                return this.hotelResDetailSearchRQ;
            }
            set
            {
                this.hotelResDetailSearchRQ = value;
            }
        }
    }
}

