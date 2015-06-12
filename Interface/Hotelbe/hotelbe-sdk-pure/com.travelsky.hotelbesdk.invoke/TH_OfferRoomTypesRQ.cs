namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models;
    using System;

    public class TH_OfferRoomTypesRQ : BaseRQ
    {
        private com.travelsky.hotelbesdk.models.OfferRoomTypesRQ offerRoomTypesRQ = new com.travelsky.hotelbesdk.models.OfferRoomTypesRQ();

        public TH_OfferRoomTypesRQ()
        {
            base.OtRequest.OfferRoomTypesRQ = this.offerRoomTypesRQ;
        }

        public com.travelsky.hotelbesdk.models.OfferRoomTypesRQ OfferRoomTypesRQ
        {
            get
            {
                return this.offerRoomTypesRQ;
            }
            set
            {
                this.offerRoomTypesRQ = value;
            }
        }
    }
}

