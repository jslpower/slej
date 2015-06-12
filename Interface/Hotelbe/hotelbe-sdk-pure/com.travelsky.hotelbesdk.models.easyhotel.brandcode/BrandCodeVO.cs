namespace com.travelsky.hotelbesdk.models.easyhotel.brandcode
{
    using System;

    public class BrandCodeVO
    {
        private string brandCode;
        private string brandName;
        private string chainCode;
        private string descp;

        public string BrandCode
        {
            get
            {
                return this.brandCode;
            }
            set
            {
                this.brandCode = value;
            }
        }

        public string BrandName
        {
            get
            {
                return this.brandName;
            }
            set
            {
                this.brandName = value;
            }
        }

        public string ChainCode
        {
            get
            {
                return this.chainCode;
            }
            set
            {
                this.chainCode = value;
            }
        }

        public string Descp
        {
            get
            {
                return this.descp;
            }
            set
            {
                this.descp = value;
            }
        }
    }
}

