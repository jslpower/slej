using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;
using EyouSoft.InterfaceLib.Common.Serializer;
using System.Xml.Serialization;
using System.Web;

namespace EyouSoft.InterfaceLib.Models.MTS
{
   public class ArgumentBase : IXmlSerializable
   {
      #region IXmlSerializable 成员

      public System.Xml.Schema.XmlSchema GetSchema()
      {
         return null;
      }

      public void ReadXml(System.Xml.XmlReader reader)
      {
         throw new NotImplementedException();
      }

      public void WriteXml(System.Xml.XmlWriter writer)
      {
         FieldInfo[] fs = this.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
         for (int i = 0; i < fs.Length; i++)
         {
            object value = fs[i].GetValue(this);
            writer.WriteElementString(fs[i].Name, UrlEncode(FormatRaw(value)));
         }
      }

      public string UrlEncode(string value)
      {
         if (value == null)
         {
            return "";
         }
         return HttpUtility.UrlEncode(value);
      }

      public string FormatRaw(object value)
      {
         if (value == null)
         {
            return "";
         }
         if (value is DateTime)
         {
            return ((DateTime)value).ToString("yyyy-MM-dd");
         }
         if (value is Enum)
         {
            return ((int)value).ToString();
         }
         return value.ToString();
      }

      #endregion

      public string SerializeToUrlEncodedString()
      {
         return XmlSerialization.Serialize(this);
      }

      public override string ToString()
      {
         return SerializeToUrlEncodedString();
      }
   }
}
