namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class FrequentFlyerCardInfo
    {
        private string airlineCode;
        private string number;

        public string AirlineCode
        {
            get
            {
                return this.airlineCode;
            }
            set
            {
                this.airlineCode = value;
            }
        }

        public string Number
        {
            get
            {
                return this.number;
            }
            set
            {
                this.number = value;
            }
        }
    }
}

