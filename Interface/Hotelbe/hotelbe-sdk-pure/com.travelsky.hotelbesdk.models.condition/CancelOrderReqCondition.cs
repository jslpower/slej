namespace com.travelsky.hotelbesdk.models.condition
{
    using System;

    public class CancelOrderReqCondition : BaseReqCondition
    {
        private string orderid;

        public string getOrderid()
        {
            return this.orderid;
        }

        public void setOrderid(string orderid)
        {
            this.orderid = orderid;
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

