namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Collections.Generic;

    public class Policies
    {
        private List<BookingPolicy> bookingPolicies;
        private List<CancelPolicy> cancelPolicies;
        private List<FavourPolicy> favourPolicies;
        private List<GuaranteePolicy> guaranteePolicies;

        public List<BookingPolicy> BookingPolicies
        {
            get
            {
                return this.bookingPolicies;
            }
            set
            {
                this.bookingPolicies = value;
            }
        }

        public List<CancelPolicy> CancelPolicies
        {
            get
            {
                return this.cancelPolicies;
            }
            set
            {
                this.cancelPolicies = value;
            }
        }

        public List<FavourPolicy> FavourPolicies
        {
            get
            {
                return this.favourPolicies;
            }
            set
            {
                this.favourPolicies = value;
            }
        }

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

