namespace com.travelsky.hotelbesdk.models.easyhotel.city
{
    using System;
    using System.Collections.Generic;
    using com.travelsky.hotelbesdk.models.easyhotel.landmark;

    public class CityVO
    {
        private string cityCode;
        private string cityName;
        private string cityPinyin;
        private string cityPyfw;
        private string countryCode;
        private List<LandMarkVO> landMark;
        private string province;

        public CityVO()
        {
        }

        public CityVO(string cityName)
        {
            this.cityName = cityName;
        }

        public CityVO(string cityCode, string cityName, string cityPinyin, string cityPyfw, string countryCode, string province, List<LandMarkVO> landMark)
        {
            this.cityCode = cityCode;
            this.cityName = cityName;
            this.cityPinyin = cityPinyin;
            this.cityPyfw = cityPyfw;
            this.countryCode = countryCode;
            this.province = province;
            this.landMark = landMark;
        }

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

        public string CityPinyin
        {
            get
            {
                return this.cityPinyin;
            }
            set
            {
                this.cityPinyin = value;
            }
        }

        public string CityPyfw
        {
            get
            {
                return this.cityPyfw;
            }
            set
            {
                this.cityPyfw = value;
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

        public List<LandMarkVO> LandMark
        {
            get
            {
                return this.landMark;
            }
            set
            {
                this.landMark = value;
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

