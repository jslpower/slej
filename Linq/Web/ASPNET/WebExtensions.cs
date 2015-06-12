using System.Web;

namespace Linq.Web.ASPNET
{
   public static class WebExtensions
   {
      public static bool IsAjaxRequest(this HttpRequest request)  
      {
         return (((request["X-Requested-With"] == "XMLHttpRequest") || ((request.Headers != null) && (request.Headers["X-Requested-With"] == "XMLHttpRequest"))));
      }
   }
}
