namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class IdentityCard
    {
        private string number;
        private string type;

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

        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }
    }
}

