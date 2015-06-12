using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Configuration;
using System.Web.SessionState;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using EyouSoft.Services.BackgroundServices;
using EyouSoft.Toolkit.BLL;

namespace EyouSoft.WEB
{
   public class EyouSoftApplication : System.Web.HttpApplication
   {
      protected void Application_Start(object sender, EventArgs e)
      {
         AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
         log4net.Config.XmlConfigurator.Configure();
         this.registerControllerFactory();
         this.launchBackgroundServices();
      }

      void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
      {
         new BLLBase().RecordError(e.ExceptionObject as Exception);
      }

      /// <summary>
      /// register controller factory
      /// </summary>
      private void registerControllerFactory()
      {
         IUnityContainer container = new UnityContainer();

         container
             .RegisterType<EyouSoft.BackgroundServices.IDAL.IPluginService, EyouSoft.BackgroundServices.DAL.PluginService>()
             .RegisterType<EyouSoft.BackgroundServices.IDAL.ISysTimerServices, EyouSoft.BackgroundServices.DAL.SysTimerServices>();

         Application.Add("container", container);
      }

      /// <summary>
      /// launch background services
      /// </summary>
      private void launchBackgroundServices()
      {
         if (!System.IO.File.Exists(EyouSoft.Toolkit.Utils.GetMapPath("/Config/BackgroundServices.txt"))) return;

         IUnityContainer container = (IUnityContainer)Application["container"];

         BackgroundServicesExecutor backgroundServicesExecutor = (BackgroundServicesExecutor)Application["backgroundServicesExecutor"];

         if (backgroundServicesExecutor == null)
         {
            backgroundServicesExecutor = new BackgroundServicesExecutor(container);

            Application.Add("backgroundServicesExecutor", backgroundServicesExecutor);

            backgroundServicesExecutor.Start();
         }
      }

      protected void Session_Start(object sender, EventArgs e)
      {

      }

      protected void Application_BeginRequest(object sender, EventArgs e)
      {

      }

      protected void Application_AuthenticateRequest(object sender, EventArgs e)
      {

      }

      protected void Application_Error(object sender, EventArgs e)
      {

      }

      protected void Session_End(object sender, EventArgs e)
      {

      }

      protected void Application_End(object sender, EventArgs e)
      {
         BackgroundServicesExecutor backgroundServicesExecutor = (BackgroundServicesExecutor)Application["backgroundServicesExecutor"];

         if (backgroundServicesExecutor != null)
         {
            backgroundServicesExecutor.Stop();
         }
      }
   }
}