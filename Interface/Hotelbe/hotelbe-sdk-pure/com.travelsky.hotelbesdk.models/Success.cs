namespace com.travelsky.hotelbesdk.models
{
    using System;

    public class Success
    {
        private string code;
        private string desc;

        public string Code
        {
            get
            {
                return this.code;
            }
            set
            {
                this.code = value;
            }
        }

        public string Desc
        {
            get
            {
                return this.desc;
            }
            set
            {
                this.desc = value;
            }
        }
    }
}

