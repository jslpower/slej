using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using EyouSoft.InterfaceLib.Models;
using EyouSoft.InterfaceLib.Models.ZL;
using EyouSoft.InterfaceLib.Common.Serializer;
using EyouSoft.InterfaceLib.Common.StringHelper;

namespace EyouSoft.InterfaceLib.Request.ZL
{
    [XmlRoot("tourists")]
    public class CustomerList : List<Customer>
    {

    }

    [XmlRoot("mt-obd_order")]
    public class SendOrderRequestArgumentList : EyouSoft.InterfaceLib.Models.MTS.ArgumentBase, IXmlSerializable
    {
        public SendOrderRequestArgumentList()
        {
            OrderHeader = new OrderHeader();
            Customer = new OrderTourists();
        }
        public OrderHeader OrderHeader;

        public OrderTourists Customer;

        #region IXmlSerializable 成员

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            throw new Exception();
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            XmlSerializer serializer = new XmlSerializer(typeof(OrderHeader));

            XmlSerializer serializer1 = new XmlSerializer(typeof(OrderTourists));

            serializer.Serialize(writer, OrderHeader, ns);
            serializer1.Serialize(writer, Customer, ns);
        }

        #endregion


    }
}
