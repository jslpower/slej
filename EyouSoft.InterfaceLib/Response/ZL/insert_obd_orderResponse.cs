using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using EyouSoft.InterfaceLib.Common.Serializer;
using EyouSoft.InterfaceLib.Common.StringHelper;
using EyouSoft.InterfaceLib.Response.MTS;

namespace EyouSoft.InterfaceLib.Response.ZL
{
    /// <summary>
    /// 出境团队详情
    /// </summary>
    [XmlRoot(ElementName = "request_result")]
    public class insert_obd_orderResponse : ResponseBase, IXmlSerializable
    {
        public insert_obd_orderResponse()
        {
            OrderHeader = new List<OrderResponseHeader>();
        }
        public int result_id;


        /// <summary>
        /// 错误描述
        /// </summary>
        public string error_desc;


        /// <summary>
        /// 团队头信息
        /// </summary>
        public List<OrderResponseHeader> OrderHeader;

        #region IXmlSerializable 成员

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            while (!reader.EOF)
            {
                if (reader.NodeType == System.Xml.XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "request_result":
                            result_id = reader.GetAttribute("result_id").GetInt();
                            error_desc = reader.GetAttribute("error_desc");
                            reader.Read();
                            break;
                        case "result_id": result_id = reader.ReadElementContentAsInt(); break;
                        case "error_desc": error_desc = reader.ReadElementContentAsString(); break;
                        case "order_header":
                            string xml = reader.ReadOuterXml();
                            OrderResponseHeader gh = XmlSerialization.Derialize<OrderResponseHeader>(xml);
                            this.OrderHeader.Add(gh);
                            break;
                        default: break;
                    }
                }
                else if (reader.NodeType == System.Xml.XmlNodeType.EndElement && reader.Name == "request_result")
                {
                    reader.Read();
                }
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    [XmlRoot("order_header")]
    public class OrderResponseHeader
    {
        public int SID;
    }
}
