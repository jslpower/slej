namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models;
    using System;

    internal class TH_LandMarkSearchRQ : BaseRQ
    {
        private com.travelsky.hotelbesdk.models.LandMarkSearchRQ landMarkSearchRQ = new com.travelsky.hotelbesdk.models.LandMarkSearchRQ();

        public TH_LandMarkSearchRQ()
        {
            base.OtRequest.LandMarkSearchRQ = this.landMarkSearchRQ;
        }

        public com.travelsky.hotelbesdk.models.LandMarkSearchRQ LandMarkSearchRQ
        {
            get
            {
                return this.landMarkSearchRQ;
            }
            set
            {
                this.landMarkSearchRQ = value;
            }
        }
    }
}

