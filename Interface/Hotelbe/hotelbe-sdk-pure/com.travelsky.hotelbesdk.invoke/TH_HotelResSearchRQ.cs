namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models;
    using System;

    public class TH_HotelResSearchRQ : BaseRQ
    {
        private com.travelsky.hotelbesdk.models.HotelResSearchRQ hotelResSearchRQ = new com.travelsky.hotelbesdk.models.HotelResSearchRQ();

        public TH_HotelResSearchRQ()
        {
            base.OtRequest.HotelResSearchRQ = this.hotelResSearchRQ;
        }

        public com.travelsky.hotelbesdk.models.HotelResSearchRQ getHotelResSearchRQ()
        {
            return this.HotelResSearchRQ;
        }

        public HotelResSearchRS getHotelResSearchRS()
        {
            return base.OtResponse.HotelResSearchRS;
        }

        public void setHotelResSearchRQ(com.travelsky.hotelbesdk.models.HotelResSearchRQ hotelResSearchRQ)
        {
            base.OtRequest.HotelResSearchRQ = hotelResSearchRQ;
        }

        public void setHotelResSearchRS(HotelResSearchRS hotelResSearchRS)
        {
            base.OtResponse.HotelResSearchRS = hotelResSearchRS;
        }

        public void setResID(string resID)
        {
            this.HotelResSearchRQ.HotelResSearchCriteria.ResID = resID;
        }

        public com.travelsky.hotelbesdk.models.HotelResSearchRQ HotelResSearchRQ
        {
            get
            {
                return this.hotelResSearchRQ;
            }
            set
            {
                this.hotelResSearchRQ = value;
            }
        }
    }
}

