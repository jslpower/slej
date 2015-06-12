namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class HotelImage
    {
        private string category;
        private string descp;
        private string hotelCode;
        private string url;

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

        public string Descp
        {
            get
            {
                return this.descp;
            }
            set
            {
                this.descp = value;
            }
        }

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

        public string Url
        {
            get
            {
                return this.url;
            }
            set
            {
                this.url = value;
            }
        }
    }
}

