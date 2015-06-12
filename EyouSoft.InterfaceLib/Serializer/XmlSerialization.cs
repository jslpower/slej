using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Web;
using Newtonsoft.Json;

namespace EyouSoft.InterfaceLib.Common.Serializer
{
   public class XmlSerialization
   {
      public static T Derialize<T>(string xml)
      {
         try
         {
            if (string.IsNullOrEmpty(xml))
            {
               return default(T);
            }
            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml(xml);
            //var json = JsonConvert.SerializeXmlNode(doc);
            //xml = JsonConvert.DeserializeXmlNode(json).InnerXml;
            //return JsonConvert.DeserializeObject<T>(xml);
            //var sb = new StringBuilder();
            //var sw = new StringWriter(sb);
            //var xc = doc.CreateCDataSection(xml);
            //var xw = new XmlTextWriter(sw);
            //xw.Formatting = Formatting.Indented;
            //doc.WriteTo(xw);
            //doc.Save("1.xml");
            //xml = sb.ToString();
            //sw.Close();
            //sw.Flush();
            //xw.Close();
            //xw.Flush();
            if (xml.IndexOf("<![CDATA[") < 0)
            {

                xml = xml.Replace("<ProviderName>", "<ProviderName><![CDATA[");
                xml = xml.Replace("</ProviderName>", "]]></ProviderName>");

                xml = xml.Replace("<Name>", "<Name><![CDATA[");
                xml = xml.Replace("</Name>", "]]></Name>");

                xml = xml.Replace("<Feature>", "<Feature><![CDATA[");
                xml = xml.Replace("</Feature>", "]]></Feature>");

                xml = xml.Replace("<Comments>", "<Comments><![CDATA[");
                xml = xml.Replace("</Comments>", "]]></Comments>");


                xml = xml.Replace("<Contain>", "<Contain><![CDATA[");
                xml = xml.Replace("</Contain>", "]]></Contain>");


                xml = xml.Replace("<UnContain>", "<UnContain><![CDATA[");
                xml = xml.Replace("</UnContain>", "]]></UnContain>");


                xml = xml.Replace("<Attention>", "<Attention><![CDATA[");
                xml = xml.Replace("</Attention>", "]]></Attention>");



                xml = xml.Replace("<GuestPrompt>", "<GuestPrompt><![CDATA[");
                xml = xml.Replace("</GuestPrompt>", "]]></GuestPrompt>");
                xml = xml.Replace("<Description>", "<Description><![CDATA[");
                xml = xml.Replace("</Description>", "]]></Description>");
                xml = xml.Replace("<Services>", "<Services><![CDATA[");
                xml = xml.Replace("</Services>", "]]></Services>");
                xml = xml.Replace("<ResourceDescription>", "<ResourceDescription><![CDATA[");
                xml = xml.Replace("</ResourceDescription>", "]]></ResourceDescription>");
                xml = xml.Replace("<ResourceAddress>", "<ResourceAddress><![CDATA[");
                xml = xml.Replace("</ResourceAddress>", "]]></ResourceAddress>");
                xml = xml.Replace("<OrderLimit>", "<OrderLimit><![CDATA[");
                xml = xml.Replace("</OrderLimit>", "]]></OrderLimit>");
                xml = xml.Replace("<Help>", "<Help><![CDATA[");
                xml = xml.Replace("</Help>", "]]></Help>");
                xml = xml.Replace("<Content>", "<Content><![CDATA[");
                xml = xml.Replace("</Content>", "]]></Content>");
                xml = xml.Replace("<Keys>", "<Keys><![CDATA[");
                xml = xml.Replace("</Keys>", "]]></Keys>");
                xml = xml.Replace("<Keyword>", "<Keyword><![CDATA[");
                xml = xml.Replace("</Keyword>", "]]></Keyword>");                
                xml = xml.Replace("<Dining>", "<Dining><![CDATA[");
                xml = xml.Replace("</Dining>", "]]></Dining>");
                xml = xml.Replace("<FileName>", "<FileName><![CDATA[");
                xml = xml.Replace("</FileName>", "]]></FileName>");
                xml = xml.Replace("<OperatorName>", "<OperatorName><![CDATA[");
                xml = xml.Replace("</OperatorName>", "]]></OperatorName>");
                xml = xml.Replace("<Lodging>", "<Lodging><![CDATA[");
                xml = xml.Replace("</Lodging>", "]]></Lodging>");
                xml = xml.Replace("<Traffic>", "<Traffic><![CDATA[");
                xml = xml.Replace("</Traffic>", "]]></Traffic>");
                xml = xml.Replace("<CityOfDepart>", "<CityOfDepart><![CDATA[");
                xml = xml.Replace("</CityOfDepart>", "]]></CityOfDepart>");
                xml = xml.Replace("<PortOfDepart>", "<PortOfDepart><![CDATA[");
                xml = xml.Replace("</PortOfDepart>", "]]></PortOfDepart>");
                xml = xml.Replace("<PortOfReturn>", "<PortOfReturn><![CDATA[");
                xml = xml.Replace("</PortOfReturn>", "]]></PortOfReturn>");
                xml = xml.Replace("<FileURL>", "<FileURL><![CDATA[");
                xml = xml.Replace("</FileURL>", "]]></FileURL>");
                xml = xml.Replace("<LeftDate>", "<LeftDate><![CDATA[");
                xml = xml.Replace("</LeftDate>", "]]></LeftDate>");
                xml = xml.Replace("<ShutDate>", "<ShutDate><![CDATA[");
                xml = xml.Replace("</ShutDate>", "]]></ShutDate>");
                xml = xml.Replace("<Destinations>", "<Destinations><![CDATA[");
                xml = xml.Replace("</Destinations>", "]]></Destinations>");
                xml = xml.Replace("<BackDate>", "<BackDate><![CDATA[");
                xml = xml.Replace("</BackDate>", "]]></BackDate>");
                xml = xml.Replace("<Billno>", "<Billno><![CDATA[");
                xml = xml.Replace("</Billno>", "]]></Billno>");
                xml = xml.Replace("<sightname>", "<sightname><![CDATA[");
                xml = xml.Replace("</sightname>", "]]></sightname>");
                xml = xml.Replace("<Address>", "<Address><![CDATA[");
                xml = xml.Replace("</Address>", "]]></Address>");
                xml = xml.Replace("<BusLine>", "<BusLine><![CDATA[");
                xml = xml.Replace("</BusLine>", "]]></BusLine>");
                xml = xml.Replace("<DriveLine>", "<DriveLine><![CDATA[");
                xml = xml.Replace("</DriveLine>", "]]></DriveLine>");
                xml = xml.Replace("<Notice>", "<Notice><![CDATA[");
                xml = xml.Replace("</Notice>", "]]></Notice>");
                xml = xml.Replace("<LinkInfo>", "<LinkInfo><![CDATA[");
                xml = xml.Replace("</LinkInfo>", "]]></LinkInfo>");
                xml = xml.Replace("<MainPic>", "<MainPic><![CDATA[");
                xml = xml.Replace("</MainPic>", "]]></MainPic>");
                xml = xml.Replace("<FileType>", "<FileType><![CDATA[");
                xml = xml.Replace("</FileType>", "]]></FileType>");
                xml = xml.Replace("<Recommend>", "<Recommend><![CDATA[");
                xml = xml.Replace("</Recommend>", "]]></Recommend>");
                

                xml = xml.Replace("<group_saleitems />", "");
            }
            byte[] data = Encoding.UTF8.GetBytes(xml);

            MemoryStream ms = new MemoryStream();
            ms.Write(data, 0, data.Length);
            ms.Position = 0;

            XmlSerializer sr = new XmlSerializer(typeof(T));
#if DEBUG
            sr.UnknownNode += new XmlNodeEventHandler(sr_UnknownNode);
#endif
            T obj = (T)sr.Deserialize(ms);
            ms.Close();
            return obj;
         }
         catch (Exception ex)
         {
             Console.WriteLine(ex.Message);
             throw ex;

         }
      }


      public static string Serialize(object obj)
      {
         if (obj == null) return "";
         XmlSerializer sr = new XmlSerializer(obj.GetType());

         MemoryStream ms = new MemoryStream();
         XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
         ns.Add("", "");
         sr.Serialize(ms, obj, ns);

         ms.Position = 0;
         byte[] data = new byte[ms.Length];
         ms.Read(data, 0, (int)ms.Length);
         ms.Close();
         string xml = Encoding.UTF8.GetString(data);
         return xml;
      }

      static void sr_UnknownNode(object sender, XmlNodeEventArgs e)
      {
         throw new NotImplementedException();
      }

   }
}
