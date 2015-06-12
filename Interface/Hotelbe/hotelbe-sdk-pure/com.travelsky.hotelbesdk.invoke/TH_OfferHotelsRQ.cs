namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models;
    using System;

    public class TH_OfferHotelsRQ : BaseRQ
    {
        private com.travelsky.hotelbesdk.models.OfferHotelsRQ offerHotelsRQ = new com.travelsky.hotelbesdk.models.OfferHotelsRQ();

        public TH_OfferHotelsRQ()
        {
            base.OtRequest.OfferHotelsRQ = this.offerHotelsRQ;
        }

        public com.travelsky.hotelbesdk.models.OfferHotelsRQ OfferHotelsRQ
        {
            get
            {
                return this.offerHotelsRQ;
            }
            set
            {
                this.offerHotelsRQ = value;
            }
        }
    }
}

