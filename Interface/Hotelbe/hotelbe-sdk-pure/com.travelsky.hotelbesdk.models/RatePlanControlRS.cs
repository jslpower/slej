namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;

    public class RatePlanControlRS
    {
        private List<RatePlanControl> ratePlanControls = new List<RatePlanControl>();

        public List<RatePlanControl> RatePlanControls
        {
            get
            {
                return this.ratePlanControls;
            }
            set
            {
                this.ratePlanControls = value;
            }
        }
    }
}

