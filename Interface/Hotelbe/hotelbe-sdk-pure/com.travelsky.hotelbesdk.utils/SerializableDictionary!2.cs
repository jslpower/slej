namespace com.travelsky.hotelbesdk.utils
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
    {
        public SerializableDictionary()
        {
        }

        public SerializableDictionary(IDictionary<TKey, TValue> dictionary) : base(dictionary)
        {
        }

        public SerializableDictionary(IEqualityComparer<TKey> comparer) : base(comparer)
        {
        }

        public SerializableDictionary(int capacity) : base(capacity)
        {
        }

        public SerializableDictionary(int capacity, IEqualityComparer<TKey> comparer) : base(capacity, comparer)
        {
        }

        protected SerializableDictionary(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TKey));
            XmlSerializer serializer2 = new XmlSerializer(typeof(TValue));
            bool isEmptyElement = reader.IsEmptyElement;
            reader.Read();
            if (!isEmptyElement)
            {
                while (reader.NodeType != XmlNodeType.EndElement)
                {
                    reader.ReadStartElement("Key");
                    TKey key = (TKey) serializer.Deserialize(reader);
                    reader.ReadEndElement();
                    reader.ReadStartElement("Value");
                    TValue local2 = (TValue) serializer2.Deserialize(reader);
                    reader.ReadEndElement();
                    base.Add(key, local2);
                    reader.MoveToContent();
                }
                reader.ReadEndElement();
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TKey));
            XmlSerializer serializer2 = new XmlSerializer(typeof(TValue));
            foreach (TKey local in base.Keys)
            {
                writer.WriteStartElement("item");
                writer.WriteElementString("key", local.ToString());
                serializer.Serialize(writer, local);
                writer.WriteEndElement();
                TValue o = base[local];
                writer.WriteElementString("value", o.ToString());
                serializer2.Serialize(writer, o);
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }
    }
}

