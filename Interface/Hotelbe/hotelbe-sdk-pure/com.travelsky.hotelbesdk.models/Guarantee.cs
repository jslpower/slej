namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;

    public class Guarantee
    {
        private List<GuaranteePolicy> guaranteePolicies;

        public List<GuaranteePolicy> GuaranteePolicies
        {
            get
            {
                return this.guaranteePolicies;
            }
            set
            {
                this.guaranteePolicies = value;
            }
        }
    }
}

