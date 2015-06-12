namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class VendorInfo
    {
        private string vendorCode;
        private string vendorName;

        public string VendorCode
        {
            get
            {
                return this.vendorCode;
            }
            set
            {
                this.vendorCode = value;
            }
        }

        public string VendorName
        {
            get
            {
                return this.vendorName;
            }
            set
            {
                this.vendorName = value;
            }
        }
    }
}

