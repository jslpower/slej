namespace com.travelsky.hotelbesdk.models.condition
{
    using System;

    public class SearchCheckedOrderReqCondition : BaseReqCondition
    {
        private string orderid;
        private ENUM_STATUS status;

        public string getOrderid()
        {
            return this.orderid;
        }

        public ENUM_STATUS getStatus()
        {
            return this.status;
        }

        public void setOrderid(string orderid)
        {
            this.orderid = orderid;
        }

        public void setStatus(ENUM_STATUS status)
        {
            this.status = status;
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

        public enum ENUM_STATUS
        {
            STATUS_NNN,
            STATUS_INN,
            STATUS_NML,
            STATUS_LES,
            STATUS_MOR,
            STATUS_CAN
        }
    }
}

