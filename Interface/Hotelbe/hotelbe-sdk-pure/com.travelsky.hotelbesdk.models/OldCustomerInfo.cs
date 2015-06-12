namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class OldCustomerInfo
    {
        private com.travelsky.hotelbesdk.models.IdentityCard identityCard;
        private string personName;

        public com.travelsky.hotelbesdk.models.IdentityCard IdentityCard
        {
            get
            {
                return this.identityCard;
            }
            set
            {
                this.identityCard = value;
            }
        }

        public string PersonName
        {
            get
            {
                return this.personName;
            }
            set
            {
                this.personName = value;
            }
        }
    }
}

