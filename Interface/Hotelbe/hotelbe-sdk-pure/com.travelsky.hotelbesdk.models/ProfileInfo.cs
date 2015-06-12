namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class ProfileInfo
    {
        private com.travelsky.hotelbesdk.models.Customer customer;
        private com.travelsky.hotelbesdk.models.OldCustomerInfo oldCustomerInfo;
        private string type;
        private string uniqueID;

        public com.travelsky.hotelbesdk.models.Customer Customer
        {
            get
            {
                return this.customer;
            }
            set
            {
                this.customer = value;
            }
        }

        public com.travelsky.hotelbesdk.models.OldCustomerInfo OldCustomerInfo
        {
            get
            {
                return this.oldCustomerInfo;
            }
            set
            {
                this.oldCustomerInfo = value;
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

        public string UniqueID
        {
            get
            {
                return this.uniqueID;
            }
            set
            {
                this.uniqueID = value;
            }
        }
    }
}

