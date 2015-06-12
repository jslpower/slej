using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Linq.Common
{
   public class timerRecorder : IDisposable
   {
      private Stopwatch sw = new Stopwatch();
      string name;
      bool isConsole;
      public timerRecorder()
      {
         this.sw.Start();
      }
      public timerRecorder(string name)
         : this()
      {
         this.name = name;
      }

      public timerRecorder(string name, bool forconsole)
         : this()
      {
         this.isConsole = true;
      }
      public timerRecorder(bool forconsole)
         : this()
      {
         this.isConsole = true;
      }
      public void Dispose()
      {
      }
      public static void run(Action act)
      {
         using (new timerRecorder())
         {
            act();
         }
      }
      public string getTime()
      {
         this.sw.Stop();
         StackTrace trace = new StackTrace(true);
         Type declaringType = trace.GetFrame(1).GetMethod().DeclaringType;
         int fileLineNumber = trace.GetFrame(1).GetFileLineNumber();
         string name = trace.GetFrame(1).GetMethod().Name;
         string br = "<br />";
         if (isConsole)
         {
            br = Environment.NewLine;
         }
         return "<br />" + (this.name ?? "") + "总耗时： " + this.sw.Elapsed.ToString() + "， 所在申明类型:" + declaringType.FullName + "， 行号:" + fileLineNumber + "，所在方法名: " + name;
      }
   }
}
