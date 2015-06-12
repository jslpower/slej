using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EyouSoft.InterfaceLib.Models.ZL
{
    [XmlRoot("mt-order_tourists", Namespace = "")]
    public class OrderTourists
    {
        [XmlElement("mt-tourist")]
        public List<Customer> list;

        public OrderTourists()
        {
            list = new List<Customer>();
        }
    }

    [XmlRoot("tourist")]
    public class Customer
    {
        [XmlElement("mt-Name")]
        public string Name;
        [XmlElement("mt-EName")]
        public string EName;
        [XmlElement("mt-Sex")]
        public string Sex;
        [XmlElement("mt-Birthday")]
        public string BirthDay;
        [XmlElement("mt-Telphone")]
        public string Telphone;
        [XmlElement("mt-MobilePhone")]
        public string MobilePhone;
        [XmlElement("mt-IDCard")]
        public string IDCard;
        [XmlElement("mt-Address")]
        public string Address;
        [XmlElement("mt-Email")]
        public string Email;
        [XmlElement("mt-tComments")]
        public string tComments;
    }
}
