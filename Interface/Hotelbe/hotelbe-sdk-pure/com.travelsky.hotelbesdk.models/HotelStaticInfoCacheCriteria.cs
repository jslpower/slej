namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class HotelStaticInfoCacheCriteria
    {
        private string cityCode;
        private string cityName;
        private string countryCode;
        private string hotelCode;
        private string hotelEnglishName;
        private string hotelName;
        private int pageNo;
        private string rank;

        public string CityCode
        {
            get
            {
                return this.cityCode;
            }
            set
            {
                this.cityCode = value;
            }
        }

        public string CityName
        {
            get
            {
                return this.cityName;
            }
            set
            {
                this.cityName = value;
            }
        }

        public string CountryCode
        {
            get
            {
                return this.countryCode;
            }
            set
            {
                this.countryCode = value;
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

        public string HotelEnglishName
        {
            get
            {
                return this.hotelEnglishName;
            }
            set
            {
                this.hotelEnglishName = value;
            }
        }

        public string HotelName
        {
            get
            {
                return this.hotelName;
            }
            set
            {
                this.hotelName = value;
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

        public string Rank
        {
            get
            {
                return this.rank;
            }
            set
            {
                this.rank = value;
            }
        }
    }
}

