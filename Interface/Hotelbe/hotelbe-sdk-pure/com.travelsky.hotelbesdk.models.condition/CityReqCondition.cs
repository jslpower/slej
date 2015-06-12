namespace com.travelsky.hotelbesdk.models.condition
{
    using System;

    public class CityReqCondition : BaseReqCondition
    {
        private string countrycode;

        public string getCountrycode()
        {
            return this.countrycode;
        }

        public void setCountrycode(string countrycode)
        {
            this.countrycode = countrycode;
        }

        public string Countrycode
        {
            get
            {
                return this.countrycode;
            }
            set
            {
                this.countrycode = value;
            }
        }
    }
}

