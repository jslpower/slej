using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using EyouSoft.InterfaceLib.Models;
using EyouSoft.InterfaceLib.Common.Serializer;
using EyouSoft.InterfaceLib.Common.StringHelper;
using EyouSoft.InterfaceLib.Response.MTS;
using EyouSoft.InterfaceLib.Models.ZL;

namespace EyouSoft.InterfaceLib.Response.ZL
{
   /// <summary>
   /// 出境团队列表
   /// </summary>
   [XmlRoot(ElementName = "request_result")]
   public class get_obd_group_listResponse : ResponseBase, IXmlSerializable
   {
      /// <summary>
      /// 符合查询条件的总行数
      /// </summary>
      [XmlAttribute]
       public int total_count { get; set; }
      [XmlAttribute]
      public int page_count { get; set; }
      /// <summary>
      ///  返回结果 0表示成功,大于0代表错误码
      /// </summary>
      public int result_id { get; set; }
      /// <summary>
      /// 错误描述
      /// </summary>
      public string error_desc { get; set; }
      /// <summary>
      /// 团队头信息
      /// </summary>
      public List<Group_Header> group_headers { get; set; }

      #region IXmlSerializable 成员

      public System.Xml.Schema.XmlSchema GetSchema()
      {
         return null;
      }

      public void ReadXml(System.Xml.XmlReader reader)
      {
         if (group_headers == null)
         {
             group_headers = new List<Group_Header>();
         }
         while (!reader.EOF)
         {
            if (reader.NodeType == System.Xml.XmlNodeType.Element)
            {
               switch (reader.Name)
               {
                  case "request_result":
                     total_count = reader.GetAttribute("total_count").GetInt();
                     page_count = reader.GetAttribute("page_count").GetInt();
                     error_desc = reader.GetAttribute("error_desc");
                     reader.Read();
                     break;
                  case "result_id": result_id = reader.ReadElementContentAsInt(); break;
                  case "error_desc": error_desc = reader.ReadElementContentAsString(); break;
                  case "group_header":
                     string xml = reader.ReadOuterXml();
                     Group_Header gh = XmlSerialization.Derialize<Group_Header>(xml);
                     this.group_headers.Add(gh);
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
}
