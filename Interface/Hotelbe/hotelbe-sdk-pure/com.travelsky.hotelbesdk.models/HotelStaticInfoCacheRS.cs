namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;

    public class HotelStaticInfoCacheRS
    {
        private List<HotelStaticInfo> hotelStaticInfos = new List<HotelStaticInfo>();
        private string totalNumber;

        public List<HotelStaticInfo> HotelStaticInfos
        {
            get
            {
                return this.hotelStaticInfos;
            }
            set
            {
                this.hotelStaticInfos = value;
            }
        }

        public string TotalNumber
        {
            get
            {
                return this.totalNumber;
            }
            set
            {
                this.totalNumber = value;
            }
        }
    }
}

