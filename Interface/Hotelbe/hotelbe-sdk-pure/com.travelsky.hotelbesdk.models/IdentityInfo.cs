namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class IdentityInfo
    {
        private string officeID;
        private string password;
        private string userID;

        public string OfficeID
        {
            get
            {
                return this.officeID;
            }
            set
            {
                this.officeID = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }

        public string UserID
        {
            get
            {
                return this.userID;
            }
            set
            {
                this.userID = value;
            }
        }
    }
}

