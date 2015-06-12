namespace com.travelsky.hotelbesdk.models.condition
{
    using System;

    public class BaseReqCondition
    {
        private bool log = false;

        public bool getLog()
        {
            return this.log;
        }

        public void setLog(bool log)
        {
            this.log = log;
        }

        public bool Log
        {
            get
            {
                return this.log;
            }
            set
            {
                this.log = value;
            }
        }
    }
}

