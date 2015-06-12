namespace com.travelsky.hotelbesdk.models.easyhotel.single
{
    using System;

    public class HotelRoomRate
    {
        private string date;
        private string fee;
        private string feeFix;
        private string feePercent;
        private HotelCommission hotelcommission;
        private string meal;
        private string price;

        public string Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }

        public string Fee
        {
            get
            {
                return this.fee;
            }
            set
            {
                this.fee = value;
            }
        }

        public string FeeFix
        {
            get
            {
                return this.feeFix;
            }
            set
            {
                this.feeFix = value;
            }
        }

        public string FeePercent
        {
            get
            {
                return this.feePercent;
            }
            set
            {
                this.feePercent = value;
            }
        }

        public HotelCommission Hotelcommission
        {
            get
            {
                return this.hotelcommission;
            }
            set
            {
                this.hotelcommission = value;
            }
        }

        public string Meal
        {
            get
            {
                return this.meal;
            }
            set
            {
                this.meal = value;
            }
        }

        public string Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }
    }
}

