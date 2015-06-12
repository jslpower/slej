namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class ResGuest
    {
        private string guestIndex;
        private com.travelsky.hotelbesdk.models.GuestProfile guestProfile = new com.travelsky.hotelbesdk.models.GuestProfile();
        private string isMobileContact;
        private string modifyType;
        private com.travelsky.hotelbesdk.models.Profiles profiles;
        private string refundStatus;
        private string roomNumber;
        private string type;

        public string GuestIndex
        {
            get
            {
                return this.guestIndex;
            }
            set
            {
                this.guestIndex = value;
            }
        }

        public com.travelsky.hotelbesdk.models.GuestProfile GuestProfile
        {
            get
            {
                return this.guestProfile;
            }
            set
            {
                this.guestProfile = value;
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

        public string ModifyType
        {
            get
            {
                return this.modifyType;
            }
            set
            {
                this.modifyType = value;
            }
        }

        public com.travelsky.hotelbesdk.models.Profiles Profiles
        {
            get
            {
                return this.profiles;
            }
            set
            {
                this.profiles = value;
            }
        }

        public string RefundStatus
        {
            get
            {
                return this.refundStatus;
            }
            set
            {
                this.refundStatus = value;
            }
        }

        public string RoomNumber
        {
            get
            {
                return this.roomNumber;
            }
            set
            {
                this.roomNumber = value;
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
    }
}

