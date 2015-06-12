namespace com.travelsky.hotelbesdk.models.condition
{
    using System;
    using System.Collections.Generic;

    public class PromotionHotelReqCondition : BaseReqCondition
    {
        private List<string> city = new List<string>();
        private EasySingleHotelReqCondition.ENUM_PAYMENT payment;
        private int size;

        public List<string> getCity()
        {
            return this.city;
        }

        public int getSize()
        {
            return this.size;
        }

        public void setCity(List<string> city)
        {
            this.city = city;
        }

        public void setSize(int size)
        {
            this.size = size;
        }

        public List<string> City
        {
            get
            {
                return this.city;
            }
            set
            {
                this.city = value;
            }
        }

        public EasySingleHotelReqCondition.ENUM_PAYMENT Payment
        {
            get
            {
                return this.payment;
            }
            set
            {
                this.payment = value;
            }
        }

        public int Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = value;
            }
        }
    }
}

