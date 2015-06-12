namespace com.travelsky.hotelbesdk.models.condition
{
    using System;

    public class HotelResDetailReqCondition : BaseReqCondition
    {
        private string orderid;

        public string getOrderid()
        {
            return this.Orderid;
        }

        public void setOrderid(string orderid)
        {
            this.Orderid = orderid;
        }

        public string Orderid
        {
            get
            {
                return this.orderid;
            }
            set
            {
                this.orderid = value;
            }
        }
    }
}

