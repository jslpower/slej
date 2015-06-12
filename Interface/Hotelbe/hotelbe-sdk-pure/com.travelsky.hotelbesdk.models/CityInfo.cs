namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class CityInfo
    {
        private string cityCode;
        private string cityName;
        private string cityPinYin;
        private string cityPYFW;
        private string countryCode;
        private string countryName;
        private string province;

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

        public string CityPinYin
        {
            get
            {
                return this.cityPinYin;
            }
            set
            {
                this.cityPinYin = value;
            }
        }

        public string CityPYFW
        {
            get
            {
                return this.cityPYFW;
            }
            set
            {
                this.cityPYFW = value;
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

        public string CountryName
        {
            get
            {
                return this.countryName;
            }
            set
            {
                this.countryName = value;
            }
        }

        public string Province
        {
            get
            {
                return this.province;
            }
            set
            {
                this.province = value;
            }
        }
    }
}

