namespace com.travelsky.hotelbesdk.models.condition
{
    using System;

    public class HotelStaticInfoCacheReqCondition : BaseReqCondition
    {
        private string citycode;
        private string hotelCode;
        private int pageNo;

        public string getCitycode()
        {
            return this.citycode;
        }

        public void setCitycode(string citycode)
        {
            this.citycode = citycode;
        }

        public string Citycode
        {
            get
            {
                return this.citycode;
            }
            set
            {
                this.citycode = value;
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

        public int PageNo
        {
            get
            {
                return this.pageNo;
            }
            set
            {
                this.pageNo = value;
            }
        }
    }
}

