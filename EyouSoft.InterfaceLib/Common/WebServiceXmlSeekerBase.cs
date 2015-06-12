using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.Web;
using EyouSoft.InterfaceLib.Common.Serializer;
using EyouSoft.InterfaceLib.Attributes;

namespace EyouSoft.InterfaceLib.Common
{
   public abstract class WebServiceXmlSeekerBase
   {
      protected abstract string Address { get; }

      bool UrlEnDeCode;
      public WebServiceXmlSeekerBase(bool UrlEnDeCode)
      {
         this.UrlEnDeCode = UrlEnDeCode;
      }

      protected string GetResponseString(object[] args)
      {
         if (string.IsNullOrEmpty(Address))
         {
            return null;
         }
         if (args == null)
         {
            return null;
         }
         MethodBase method = new StackFrame(1).GetMethod();
         string callMethod = method.Name;
         ContractNameAttribute m = method.GetCustomAttributes(false).OfType<ContractNameAttribute>().FirstOrDefault();
         if (m != null)
         {
            callMethod = m.Name;
         }
         object result = WebServiceHelper.Invoke(Address, callMethod, args);
         if (result == null)
         {
            return null;
         }
         string str = result.ToString();
         if (result.ToString() == "")
         {
            return "";
         }
         object value;
         if (!IsXml(str, out value))
         {
            return "";
         }
         if (UrlEnDeCode)
         {
            str = HttpUtility.UrlDecode(str);
         }
         return str;
      }

      protected TResponse GetResponse<TResponse>(object[] args) where TResponse : new()
      {
         TResponse _default = default(TResponse);
         if (string.IsNullOrEmpty(Address))
         {
            return _default;
         }
         if (args == null)
         {
            return _default;
         }
         if (!typeof(TResponse).IsPublic)
         {
            return _default;
         }
         MethodBase method = new StackFrame(1).GetMethod();
         string callMethod = method.Name;
         ContractNameAttribute m = method.GetCustomAttributes(false).OfType<ContractNameAttribute>().FirstOrDefault();
         if (m != null)
         {
            callMethod = m.Name;
         }
         object result =  WebServiceHelper.Invoke(Address, callMethod, args);
         if (result == null)
         {
            return _default;
         }
         string str = result.ToString();
         if (result.ToString() == "")
         {
            return _default;
         }
         TResponse value;
         if (UrlEnDeCode)
         {
            str = HttpUtility.UrlDecode(str);
         }
         if (!IsXml(str, out value))
         {
            return value;
         }
         else
         {
            return XmlSerialization.Derialize<TResponse>(str);
         }
      }

      protected bool IsXml<T>(string str, out T value)
      {
         if (!str.StartsWith("<?xml"))
         {
            try
            {
               value = (T)Convert.ChangeType(str, typeof(T));
            }
            catch
            {
               value = default(T);
            }
            return false;
         }
         value = default(T);
         return true;
      }
   }
}
