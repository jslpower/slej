namespace com.travelsky.hotelbesdk.models.easyhotel.single
{
    using System;

    public class HotelCommission
    {
        private string fix;
        private string percent;
        private string tax;
        private string type;

        public string Fix
        {
            get
            {
                return this.fix;
            }
            set
            {
                this.fix = value;
            }
        }

        public string Percent
        {
            get
            {
                return this.percent;
            }
            set
            {
                this.percent = value;
            }
        }

        public string Tax
        {
            get
            {
                return this.tax;
            }
            set
            {
                this.tax = value;
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

