namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class LandMarkSearchRQ
    {
        private string _cityCode;
        private string category;
        private string countryCode;
        private string countryName;

        public string Category
        {
            get
            {
                return this.category;
            }
            set
            {
                this.category = value;
            }
        }

        public string cityCode
        {
            get
            {
                return this._cityCode;
            }
            set
            {
                this._cityCode = value;
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
    }
}

