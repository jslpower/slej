namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class CityDetailsSearchRQ
    {
        private string countryCode;
        private string countryName;

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

