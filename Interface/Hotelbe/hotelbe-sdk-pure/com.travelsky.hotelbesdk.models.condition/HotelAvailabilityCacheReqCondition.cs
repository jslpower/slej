namespace com.travelsky.hotelbesdk.models.condition
{
    using System;

    public class HotelAvailabilityCacheReqCondition : BaseReqCondition
    {
        private string hotelcode;

        public string getHotelcode()
        {
            return this.hotelcode;
        }

        public void setHotelcode(string hotelcode)
        {
            this.hotelcode = hotelcode;
        }

        public string Hotelcode
        {
            get
            {
                return this.hotelcode;
            }
            set
            {
                this.hotelcode = value;
            }
        }
    }
}

