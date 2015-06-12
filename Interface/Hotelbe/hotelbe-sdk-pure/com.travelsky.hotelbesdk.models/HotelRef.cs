namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Xml.Serialization;

    public class HotelRef
    {
        private string cityCode;
        private string countryCode;
        private string district;
        private string hotelBrandCode;
        private string hotelChineseName;
        private string hotelCityCode;
        private string hotelCode;
        private string hotelEnglishName;

        [XmlAttribute("CityCode")]
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

        [XmlAttribute("CountryCode")]
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

        public string District
        {
            get
            {
                return this.district;
            }
            set
            {
                this.district = value;
            }
        }

        public string HotelBrandCode
        {
            get
            {
                return this.hotelBrandCode;
            }
            set
            {
                this.hotelBrandCode = value;
            }
        }

        public string HotelChineseName
        {
            get
            {
                return this.hotelChineseName;
            }
            set
            {
                this.hotelChineseName = value;
            }
        }

        public string HotelCityCode
        {
            get
            {
                return this.hotelCityCode;
            }
            set
            {
                this.hotelCityCode = value;
            }
        }

        [XmlAttribute("HotelCode")]
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
    }
}

