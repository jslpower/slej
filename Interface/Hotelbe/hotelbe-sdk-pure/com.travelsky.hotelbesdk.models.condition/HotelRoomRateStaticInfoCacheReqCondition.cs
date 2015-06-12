namespace com.travelsky.hotelbesdk.models.condition
{
    using System;

    public class HotelRoomRateStaticInfoCacheReqCondition : BaseReqCondition
    {
        private ENUM_AUTHTYPE authType;
        private string hotelcode;
        private ENUM_TYPE type;

        public ENUM_AUTHTYPE getAuthType()
        {
            return this.authType;
        }

        public string getHotelcode()
        {
            return this.hotelcode;
        }

        public ENUM_TYPE getType()
        {
            return this.type;
        }

        public void setAuthType(ENUM_AUTHTYPE authType)
        {
            this.authType = authType;
        }

        public void setHotelcode(string hotelcode)
        {
            this.hotelcode = hotelcode;
        }

        public void setType(ENUM_TYPE type)
        {
            this.type = type;
        }

        public ENUM_AUTHTYPE AuthType
        {
            get
            {
                return this.authType;
            }
            set
            {
                this.authType = value;
            }
        }

        public string Hotelcode
        {
            get
            {
                return this.hotelcode;
            }
            set
            {
                this.hotelcode = value;
            }
        }

        public ENUM_TYPE Type
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

        public enum ENUM_AUTHTYPE
        {
            AUTHTYPE_PUBLIC,
            AUTHTYPE_PRIVATE,
            AUTHTYPE_ALL
        }

        public enum ENUM_TYPE
        {
            TYPE_ROOMRATE,
            TYPE_AVAILABLE,
            TYPE_RATEPLAN,
            TYPE_POLICY,
            TYPE_ALL
        }
    }
}

