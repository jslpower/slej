using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.Text.RegularExpressions;

namespace Common.Function
{
   public class IISHelper
   {
      public static void AddHostHeader(string serverName, int siteid, string ip, int port, string domain)
      {
         DirectoryEntry site = new DirectoryEntry("IIS://" + serverName + "/W3SVC/" + siteid);
         PropertyValueCollection serverBindings = site.Properties["ServerBindings"];
         string headerStr = string.Format("{0}:{1}:{2}", ip, port, domain);
         if (!serverBindings.Contains(headerStr))
         {
            serverBindings.Add(headerStr);
         }
         site.CommitChanges();
      }

      public static void DeleteHostHeader(string serverName, int siteid, string ip, int port, string domain)
      {
         DirectoryEntry site = new DirectoryEntry("IIS://" + serverName + "/W3SVC/" + siteid);
         PropertyValueCollection serverBindings = site.Properties["ServerBindings"];
         string headerStr = string.Format("{0}:{1}:{2}", ip, port, domain);
         if (serverBindings.Contains(headerStr))
         {
            serverBindings.Remove(headerStr);
         }
         site.CommitChanges();
      }
   }
}
