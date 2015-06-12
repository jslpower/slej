namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class GuestRef
    {
        private string uniqueID;

        public GuestRef()
        {
        }

        public GuestRef(string uniqueID)
        {
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

