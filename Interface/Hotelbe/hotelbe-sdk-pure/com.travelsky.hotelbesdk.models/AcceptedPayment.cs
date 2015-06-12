namespace com.travelsky.hotelbesdk.models
{
    using System;
    using System.Xml.Serialization;

    public class AcceptedPayment
    {
        private com.travelsky.hotelbesdk.models.PaymentCard paymentCard;

        [XmlElement("paymentCard")]
        public com.travelsky.hotelbesdk.models.PaymentCard PaymentCard
        {
            get
            {
                return this.paymentCard;
            }
            set
            {
                this.paymentCard = value;
            }
        }
    }
}

