using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.CodeDom;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Web.Services.Description;
using System.Xml.Serialization;
using System.Configuration;
using System.Web.Services.Protocols;
using System.Collections;

namespace EyouSoft.InterfaceLib.Common
{
   public class WebServiceHelper
   {
      static string @namespace = "EnterpriseServerBase.WebService.DynamicWebCalling";
      static string[] dll = new string[] { "System.dll", "System.XML.dll", "System.Web.Services.dll", "System.Data.dll" };
      static Hashtable SoapHttpClientClasses = new Hashtable();
      static bool ReadCache = bool.Parse(ConfigurationManager.AppSettings["WSDL_Cache"]);
      static int WaitMinutes = int.Parse(ConfigurationManager.AppSettings["WSWaitMinutes"]);
      public static object Invoke(string url, string method, object[] args)
      {
         Type SoapHttpClientClass = null;

         if (ReadCache && SoapHttpClientClasses.ContainsKey(url))
         {
            SoapHttpClientClass = SoapHttpClientClasses[url] as Type;
         }
         else
         {
            string @classname = "";
            var urls = url.Split('/');
            @classname = urls[urls.Length - 1].Split('.')[0];

            IWebProxy proxy = WebRequest.GetSystemWebProxy();
            proxy.Credentials = CredentialCache.DefaultCredentials;

            WebClient wc = new WebClient();
            wc.Proxy = proxy;

            Stream stream = wc.OpenRead(url + "?WSDL");
            ServiceDescription sd = ServiceDescription.Read(stream);
            ServiceDescriptionImporter sdi = new ServiceDescriptionImporter();

            sdi.ProtocolName = "Soap";
            sdi.Style = ServiceDescriptionImportStyle.Client;
            sdi.CodeGenerationOptions = CodeGenerationOptions.GenerateProperties;// | CodeGenerationOptions.GenerateNewAsync;


            sdi.AddServiceDescription(sd, "", "");
            CodeNamespace cn = new CodeNamespace(@namespace);

            CodeCompileUnit ccu = new CodeCompileUnit();
            ccu.Namespaces.Add(cn);
            sdi.Import(cn, ccu);

            CSharpCodeProvider csc = new CSharpCodeProvider();
            CodeDomProvider provider = CodeDomProvider.CreateProvider("C#");
            //ICodeCompiler icc = csc.CreateCompiler();

            CompilerParameters cplist = new CompilerParameters();
            cplist.GenerateExecutable = false;
            cplist.GenerateInMemory = true;
            foreach (var a in dll)
            {
               cplist.ReferencedAssemblies.Add(a);
            }

            CompilerResults cr = provider.CompileAssemblyFromDom(cplist, ccu);
            //CompilerResults cr = csc.CompileAssemblyFromDom(cplist, ccu);

            if (cr.Errors.HasErrors)
            {
               System.Text.StringBuilder sb = new System.Text.StringBuilder();

               foreach (System.CodeDom.Compiler.CompilerError ce in cr.Errors)
               {
                  sb.Append(ce.ToString());
                  sb.Append(System.Environment.NewLine);
               }
               throw new Exception(sb.ToString());
            }

            Assembly compliedAssembly = cr.CompiledAssembly;

            SoapHttpClientClass = compliedAssembly.GetTypes().FirstOrDefault(x => x.BaseType == typeof(SoapHttpClientProtocol));
            if (SoapHttpClientClass == null)
            {
               SoapHttpClientClass = compliedAssembly.GetType(@namespace + "." + @classname, true, true);
            }
            if (SoapHttpClientClass == null)
            {
               return null;
            }
            else
            {
               SoapHttpClientClasses.Remove(url);
               SoapHttpClientClasses.Add(url, SoapHttpClientClass);
            }
         }

         object obj = Activator.CreateInstance(SoapHttpClientClass);
         (obj as SoapHttpClientProtocol).Timeout = WaitMinutes * 60 * 1000;
         System.Reflection.MethodInfo mi = SoapHttpClientClass.GetMethod(method);

         if (mi == null)
         {
            throw new Exception("未找到方法：" + method);
         }
         ParameterInfo[] pars = mi.GetParameters();
         for (int i = 0; i < pars.Length; i++)
         {
            if (args[i] != null)
            {
               if (args[i].GetType().Name != pars[i].ParameterType.Name)
               {
                  args[i] = Convert.ChangeType(args[i], pars[i].ParameterType);
               }
            }
            else
            {
               args[i] = "";
            }
         }

         return mi.Invoke(obj, args);

      }
   }
}
