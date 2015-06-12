namespace com.travelsky.hotelbesdk.models.condition
{
    using System;

    public class UpdateHotelsReqCondition : BaseReqCondition
    {
        private string endtime;
        private string starttime;
        private ENUM_TYPE type;

        public string getEndtime()
        {
            return this.endtime;
        }

        public string getStarttime()
        {
            return this.starttime;
        }

        public ENUM_TYPE getType()
        {
            return this.type;
        }

        public void setEndtime(string endtime)
        {
            this.endtime = endtime;
        }

        public void setStarttime(string starttime)
        {
            this.starttime = starttime;
        }

        public void setType(ENUM_TYPE type)
        {
            this.type = type;
        }

        public string Endtime
        {
            get
            {
                return this.endtime;
            }
            set
            {
                this.endtime = value;
            }
        }

        public string Starttime
        {
            get
            {
                return this.starttime;
            }
            set
            {
                this.starttime = value;
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

