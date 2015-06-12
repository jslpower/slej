namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class Profile
    {
        private string address;
        private string countryCode;
        private string email;
        private string fax;
        private string gender;
        private string mobile;
        private string namePrefix;
        private string personName;
        private string telephone;

        public string Address
        {
            get
            {
                return this.address;
            }
            set
            {
                this.address = value;
            }
        }

        public string CountryCode
        {
            get
            {
                return this.countryCode;
            }
            set
            {
                this.countryCode = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }

        public string Fax
        {
            get
            {
                return this.fax;
            }
            set
            {
                this.fax = value;
            }
        }

        public string Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                this.gender = value;
            }
        }

        public string Mobile
        {
            get
            {
                return this.mobile;
            }
            set
            {
                this.mobile = value;
            }
        }

        public string NamePrefix
        {
            get
            {
                return this.namePrefix;
            }
            set
            {
                this.namePrefix = value;
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

        public string Telephone
        {
            get
            {
                return this.telephone;
            }
            set
            {
                this.telephone = value;
            }
        }
    }
}

