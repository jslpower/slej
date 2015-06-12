using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using System.Web.Script.Serialization;
using System.Reflection;
using System.ComponentModel;

namespace EyouSoft.InterfaceLib.Common
{
   public class WebInvoker
   {
      static public bool IsSetDefaultValue = true;

      static JavaScriptSerializer js = new JavaScriptSerializer();
      public static TResponse Invoke<TRequest, TResponse>(string url, TRequest request) where TRequest : class
      {
         StringBuilder sb = new StringBuilder(1000);
         FieldInfo[] fs = typeof(TRequest).GetFields(BindingFlags.Public | BindingFlags.Instance);
         for (int i = 0; i < fs.Length; i++)
         {
            if (i != 0) sb.Append("&");
            sb.Append(fs[i].Name + "=" + HttpUtility.UrlEncode(FormatValue(fs[i], request)));
         }
         string json = Post(url, sb.ToString());
         return js.Deserialize<TResponse>(json);
      }

      static object GetTypeDefaultValue(Type T)
      {
         if (T.IsValueType)
         {
            return Activator.CreateInstance(T);
         }
         return null;
      }

      static string FormatValue(FieldInfo field, object obj)
      {
         if (field == null || obj == null)
            return "";

         Type type = field.FieldType;
         if (field.FieldType.IsValueType && field.FieldType.IsGenericType && typeof(Nullable<>).IsAssignableFrom(field.FieldType))
         {
            if (obj == null)
            {
               return "";
            }
            else
            {
               type = type.GetGenericArguments()[0];
            }
         }

         object value = field.GetValue(obj);
         //object[] attrs = field.GetCustomAttributes(true);
         //if (attrs.Length > 0 && attrs.Any(x => x.GetType() == typeof(DefaultValueAttribute)))
         //{
         //   value = attrs.OfType<DefaultValueAttribute>().First().Value;
         //   //if (IsSetDefaultValue)
         //   //{
         //   //   field.SetValue(obj, value);
         //   //}
         //}

         if (type == typeof(DateTime))
         {
            if (((DateTime)value) == DateTime.MinValue || ((DateTime)value) == DateTime.MaxValue)
            {
               return "";
            }
            return ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
         }

         if (type.IsEnum)
         {
            return ((int)value).ToString();
         }
         if (value != null)
         {
            return value.ToString();
         }
         return "";
      }

      static string Post(string url, string formsData)
      {
         HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
         request.Method = "POST";
         request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

         byte[] formbytes = Encoding.UTF8.GetBytes(formsData);
         request.ContentLength = formbytes.Length;
         Stream requestStream = request.GetRequestStream();
         requestStream.Write(formbytes, 0, formbytes.Length);
         requestStream.Close();

         string result = null;
         HttpWebResponse response = request.GetResponse() as HttpWebResponse;
         using (Stream responseStream = response.GetResponseStream())
         {
            int b;
            List<byte> bytes = new List<byte>();
            while ((b = responseStream.ReadByte()) != -1)
            {
               bytes.Add((byte)b);
            }

            string html = Encoding.UTF8.GetString(bytes.ToArray());
            result = html;
            //////////////////////////////////////////////////////////////////////////////////////////
            return result;
         }
      }

   }
}
