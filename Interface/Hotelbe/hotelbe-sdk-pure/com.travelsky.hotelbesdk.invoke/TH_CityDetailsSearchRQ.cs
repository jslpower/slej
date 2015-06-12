namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models;
    using System;

    internal class TH_CityDetailsSearchRQ : BaseRQ
    {
        private com.travelsky.hotelbesdk.models.CityDetailsSearchRQ cityDetailsSearchRQ = new com.travelsky.hotelbesdk.models.CityDetailsSearchRQ();

        public TH_CityDetailsSearchRQ()
        {
            base.OtRequest.CityDetailsSearchRQ = this.cityDetailsSearchRQ;
        }

        public com.travelsky.hotelbesdk.models.CityDetailsSearchRQ CityDetailsSearchRQ
        {
            get
            {
                return this.cityDetailsSearchRQ;
            }
            set
            {
                this.cityDetailsSearchRQ = value;
            }
        }
    }
}

