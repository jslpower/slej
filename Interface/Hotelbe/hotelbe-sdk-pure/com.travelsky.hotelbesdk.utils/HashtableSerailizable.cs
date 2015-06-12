namespace com.travelsky.hotelbesdk.utils
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    public class HashtableSerailizable : Hashtable, IXmlSerializable
    {
        public HashtableSerailizable()
        {
        }

        public HashtableSerailizable(string filename)
        {
            this.ReadXml(filename);
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(string filename)
        {
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(filename);
                if (document.ChildNodes.Count != 0)
                {
                    XmlNodeList childNodes = document.ChildNodes[1].ChildNodes[0].ChildNodes;
                    for (int i = 0; i < childNodes.Count; i++)
                    {
                        this.Add(childNodes[i].ChildNodes[0].InnerText, childNodes[i].ChildNodes[1].InnerText);
                    }
                }
            }
            catch
            {
            }
        }

        public void ReadXml(XmlReader reader)
        {
            reader.Read();
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                reader.ReadStartElement("item");
                string key = reader.ReadElementString("key");
                string str2 = reader.ReadElementString("value");
                reader.ReadEndElement();
                reader.MoveToContent();
                this.Add(key, str2);
            }
        }

        public void SaveXml(string filename)
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(filename);
                new XmlSerializer(base.GetType()).Serialize((TextWriter) writer, this);
                writer.Close();
            }
            catch
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            foreach (object obj2 in this.Keys)
            {
                object obj3 = this[obj2];
                writer.WriteStartElement("item");
                writer.WriteElementString("key", obj2.ToString());
                writer.WriteElementString("value", (obj3 ?? "").ToString());
                writer.WriteEndElement();
            }
        }
    }
}

