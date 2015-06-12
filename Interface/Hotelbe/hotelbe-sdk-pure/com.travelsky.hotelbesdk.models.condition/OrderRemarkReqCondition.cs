namespace com.travelsky.hotelbesdk.models.condition
{
    using System;

    public class OrderRemarkReqCondition : BaseReqCondition
    {
        private string orderid;

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

