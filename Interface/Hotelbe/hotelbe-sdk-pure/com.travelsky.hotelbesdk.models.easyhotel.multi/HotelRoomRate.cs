namespace com.travelsky.hotelbesdk.models.easyhotel.multi
{
    using System;

    public class HotelRoomRate
    {
        private string date;
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

