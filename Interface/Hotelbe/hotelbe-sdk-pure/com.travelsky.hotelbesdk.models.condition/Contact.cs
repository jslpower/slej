namespace com.travelsky.hotelbesdk.models.condition
{
    using System;

    public class Contact
    {
        private string contactemail;
        private string contactmobile;
        private string contactname;

        public string getContactemail()
        {
            return this.contactemail;
        }

        public string getContactmobile()
        {
            return this.contactmobile;
        }

        public string getContactname()
        {
            return this.contactname;
        }

        public void setContactemail(string contactemail)
        {
            this.contactemail = contactemail;
        }

        public void setContactmobile(string contactmobile)
        {
            this.contactmobile = contactmobile;
        }

        public void setContactname(string contactname)
        {
            this.contactname = contactname;
        }

        public string Contactemail
        {
            get
            {
                return this.contactemail;
            }
            set
            {
                this.contactemail = value;
            }
        }

        public string Contactmobile
        {
            get
            {
                return this.contactmobile;
            }
            set
            {
                this.contactmobile = value;
            }
        }

        public string Contactname
        {
            get
            {
                return this.contactname;
            }
            set
            {
                this.contactname = value;
            }
        }
    }
}

