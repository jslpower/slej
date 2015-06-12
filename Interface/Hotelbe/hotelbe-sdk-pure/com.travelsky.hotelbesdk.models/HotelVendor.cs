namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class HotelVendor
    {
        private string vendorCode;
        private string vendorPromotionCode;
        private string vendorPromotionPicURL;
        private string vendorPromotionRemark;

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

        public string VendorPromotionCode
        {
            get
            {
                return this.vendorPromotionCode;
            }
            set
            {
                this.vendorPromotionCode = value;
            }
        }

        public string VendorPromotionPicURL
        {
            get
            {
                return this.vendorPromotionPicURL;
            }
            set
            {
                this.vendorPromotionPicURL = value;
            }
        }

        public string VendorPromotionRemark
        {
            get
            {
                return this.vendorPromotionRemark;
            }
            set
            {
                this.vendorPromotionRemark = value;
            }
        }
    }
}

