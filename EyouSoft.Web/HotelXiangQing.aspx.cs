using System;
using Common.page;
using EyouSoft.Model.HotelStructure.WebModel;
using EyouSoft.BLL.HotelStructure;
using Linq.Web;
using EyouSoft.Common;
using EyouSoft.Web.MasterPage;
using System.Web;
using EyouSoft.Model.Enum;
using System.Collections.Generic;

namespace EyouSoft.Web
{
   [NoCache]
   public partial class HotelXiangQing : ClientModelViewPageBase<MHotelXiangQingModel>
   {
      BHotel2 bll = new BHotel2();
      protected string thisurl = "";
      protected void Page_Load(object sender, EventArgs e)
      {
          string hosturl = Request.Url.Host.ToLower();
          if (hosturl.IndexOf("www") >= 0)
          {
              hosturl = "slej.cn";
          }
          thisurl = thisurl = "http://m." + hosturl + "/HotelXX.aspx?HotelId=" + Utils.GetQueryStringValue("HotelId") + "&RuZhuRiQi=" + Utils.GetQueryStringValue("RuZhuRiQi") + "&lidianriqi=" + Utils.GetQueryStringValue("lidianriqi");
         (Master as Front2).HeadMenuIndex = 7;
         if (!Model.RuZhuRiQi.HasValue)
         {
            Model.RuZhuRiQi = DateTime.Now;
         }
         if (!Model.LiDianRiQi.HasValue)
         {
            Model.LiDianRiQi = DateTime.Now.AddDays(1);
         }
         MHotelXiangQingModel model = bll.GetHotelDetail(Model);
         if (model == null)
         {
            Response.End();
         }
         model.RuZhuRiQi = Model.RuZhuRiQi;
         model.LiDianRiQi = Model.LiDianRiQi;
         Model = model;
      }

      public static string ShowLink(MemberTypes memberType)
      {

         string url = HttpContext.Current.Request.Url.Host;
         var isshow = new EyouSoft.IDAL.AccountStructure.BSellers().WebSiteShowOrHidden(url);

         if (isshow == ShowHidden.显示)
         {
            return " onclick=\"instance.shenqing(" + (int)memberType + ",'" + memberType + "');return false;\"";
         }
         return " style='display:none;'";
      }


      protected string FillWhiteSpace(int totalwidth, int fontSize, string text)
      {
         int whitespaceWidth = 3;
         if (string.IsNullOrEmpty(text))
         {
            return "";
         }
         int textWidth = text.Length * fontSize;
         int every = 1;
         int leftCount = 0;
         int wsCount = (totalwidth - textWidth) / whitespaceWidth;
         int wsShouldInertPostionCount = text.Length - 1;
         if (textWidth < totalwidth)
         {
            if (wsCount > wsShouldInertPostionCount)
            {
               every = (int)(wsCount / wsShouldInertPostionCount);
               leftCount = wsCount % wsShouldInertPostionCount;
            }
            else if (wsCount == wsShouldInertPostionCount)
            {
               every = 1;
            }
         }
         else
         {
            return text;
         }
         List<string> newtext = new List<string>();
         for (int i = 0; i < text.Length; i++)
         {
            newtext.Add(text[i].ToString());
            if (i + 1 > wsCount)
            {
               break;
            }
            if (i < wsShouldInertPostionCount)
            {
               newtext.Add("&nbsp;".Replicate(every));
            }
         }
         if (leftCount > 0)
         {
            int _leftCount = 0;
            List<string> newtext2 = new List<string>();
            for (int j = 0; j < newtext.Count; j++)
            {
               if (newtext[j].IndexOf("&nbsp;") > -1)
               {
                  newtext2.Add(newtext[j]);
                  continue;
               }
               else if (j > 0 && _leftCount < leftCount)
               {
                  newtext2.Add("&nbsp;");
                  newtext2.Add(newtext[j]);
                  _leftCount++;
               }
               else
               {
                  newtext2.Add(newtext[j]);
               }
            }
            return string.Join("", newtext2.ToArray());
         }
         else
         {
            return string.Join("", newtext.ToArray());
         }
      }
   }
}
