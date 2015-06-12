namespace com.travelsky.hotelbesdk.invoke
{
    using com.travelsky.hotelbesdk.models;
    using System;

    public class TH_RoomTypeStaticInfoCacheRQ : BaseRQ
    {
        private com.travelsky.hotelbesdk.models.HotelRoomTypeStaticInfoCacheRQ hotelRoomTypeStaticInfoCacheRQ = new com.travelsky.hotelbesdk.models.HotelRoomTypeStaticInfoCacheRQ();

        public TH_RoomTypeStaticInfoCacheRQ()
        {
            base.OtRequest.HotelRoomTypeStaticInfoCacheRQ = this.hotelRoomTypeStaticInfoCacheRQ;
        }

        public com.travelsky.hotelbesdk.models.HotelRoomTypeStaticInfoCacheRQ HotelRoomTypeStaticInfoCacheRQ
        {
            get
            {
                return this.hotelRoomTypeStaticInfoCacheRQ;
            }
            set
            {
                this.hotelRoomTypeStaticInfoCacheRQ = value;
            }
        }
    }
}

