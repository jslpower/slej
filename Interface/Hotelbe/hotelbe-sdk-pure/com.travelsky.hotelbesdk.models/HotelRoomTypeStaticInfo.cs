namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;

    public class HotelRoomTypeStaticInfo
    {
        private List<HotelAcceptedPayment> hotelAcceptedPayments;
        private List<HotelAmenity> hotelAmenities;
        private string hotelCode;
        private List<HotelTrafficInfo> hotelTrafficInfos;
        private List<HotelVendor> hotelVendors;
        private List<RoomTypeStaticInfo> roomTypeStaticInfos;

        public List<HotelAcceptedPayment> HotelAcceptedPayments
        {
            get
            {
                return this.hotelAcceptedPayments;
            }
            set
            {
                this.hotelAcceptedPayments = value;
            }
        }

        public List<HotelAmenity> HotelAmenities
        {
            get
            {
                return this.hotelAmenities;
            }
            set
            {
                this.hotelAmenities = value;
            }
        }

        public string HotelCode
        {
            get
            {
                return this.hotelCode;
            }
            set
            {
                this.hotelCode = value;
            }
        }

        public List<HotelTrafficInfo> HotelTrafficInfos
        {
            get
            {
                return this.hotelTrafficInfos;
            }
            set
            {
                this.hotelTrafficInfos = value;
            }
        }

        public List<HotelVendor> HotelVendors
        {
            get
            {
                return this.hotelVendors;
            }
            set
            {
                this.hotelVendors = value;
            }
        }

        public List<RoomTypeStaticInfo> RoomTypeStaticInfos
        {
            get
            {
                return this.roomTypeStaticInfos;
            }
            set
            {
                this.roomTypeStaticInfos = value;
            }
        }
    }
}

