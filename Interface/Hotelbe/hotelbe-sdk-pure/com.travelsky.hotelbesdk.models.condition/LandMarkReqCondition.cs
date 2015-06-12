namespace com.travelsky.hotelbesdk.models.condition
{
    using System;

    public class LandMarkReqCondition : BaseReqCondition
    {
        private string citycode;

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
    }
}

