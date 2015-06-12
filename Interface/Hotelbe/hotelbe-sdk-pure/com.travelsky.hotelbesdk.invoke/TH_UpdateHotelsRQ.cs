namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models;
    using System;

    public class TH_UpdateHotelsRQ : BaseRQ
    {
        private com.travelsky.hotelbesdk.models.UpdateHotelsRQ updateHotelsRQ = new com.travelsky.hotelbesdk.models.UpdateHotelsRQ();

        public TH_UpdateHotelsRQ()
        {
            base.OtRequest.UpdateHotelsRQ = this.updateHotelsRQ;
        }

        public com.travelsky.hotelbesdk.models.UpdateHotelsRQ getUpdateHotelsRQ()
        {
            return this.UpdateHotelsRQ;
        }

        public void setUpdateHotelsRQ(com.travelsky.hotelbesdk.models.UpdateHotelsRQ updateHotelsRQ)
        {
            this.UpdateHotelsRQ = updateHotelsRQ;
        }

        public com.travelsky.hotelbesdk.models.UpdateHotelsRQ UpdateHotelsRQ
        {
            get
            {
                return this.updateHotelsRQ;
            }
            set
            {
                this.updateHotelsRQ = value;
            }
        }
    }
}

