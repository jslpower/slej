namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class ContactorInfo
    {
        private string dynamicPkgStatus;
        private string isEmailContact;
        private string isFaxContact;
        private string isMobileContact;
        private string isTelephoneContact;
        private com.travelsky.hotelbesdk.models.Profile profile = new com.travelsky.hotelbesdk.models.Profile();

        public string DynamicPkgStatus
        {
            get
            {
                return this.dynamicPkgStatus;
            }
            set
            {
                this.dynamicPkgStatus = value;
            }
        }

        public string IsEmailContact
        {
            get
            {
                return this.isEmailContact;
            }
            set
            {
                this.isEmailContact = value;
            }
        }

        public string IsFaxContact
        {
            get
            {
                return this.isFaxContact;
            }
            set
            {
                this.isFaxContact = value;
            }
        }

        public string IsMobileContact
        {
            get
            {
                return this.isMobileContact;
            }
            set
            {
                this.isMobileContact = value;
            }
        }

        public string IsTelephoneContact
        {
            get
            {
                return this.isTelephoneContact;
            }
            set
            {
                this.isTelephoneContact = value;
            }
        }

        public com.travelsky.hotelbesdk.models.Profile Profile
        {
            get
            {
                return this.profile;
            }
            set
            {
                this.profile = value;
            }
        }
    }
}

