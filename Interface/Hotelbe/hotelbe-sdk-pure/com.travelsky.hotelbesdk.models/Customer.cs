namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;

    public class Customer
    {
        private string birthday;
        private List<FrequentFlyerCardInfo> frequentFlyerCardInfos;
        private com.travelsky.hotelbesdk.models.IdentityCard identityCard;
        private string newPersonName;
        private string personName;

        public string Birthday
        {
            get
            {
                return this.birthday;
            }
            set
            {
                this.birthday = value;
            }
        }

        private List<FrequentFlyerCardInfo> FrequentFlyerCardInfos
        {
            get
            {
                return this.frequentFlyerCardInfos;
            }
            set
            {
                this.frequentFlyerCardInfos = value;
            }
        }

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

        public string NewPersonName
        {
            get
            {
                return this.newPersonName;
            }
            set
            {
                this.newPersonName = value;
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

