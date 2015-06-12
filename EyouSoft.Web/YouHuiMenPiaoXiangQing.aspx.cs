using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.page;
using EyouSoft.Model.ScenicStructure.WebModel;
using EyouSoft.BLL.ScenicStructure;
using EyouSoft.Model.ScenicStructure;
using EyouSoft.Model;
using Linq.Bussiness;
using EyouSoft.Common;
using Linq.Web;
using EyouSoft.Web.MasterPage;
using EyouSoft.IDAL.AccountStructure;
using EyouSoft.Model.Enum;
using Linq.Common;

namespace EyouSoft.Web
{
   [NoCache]
   public partial class YouHuiMenPiaoXiangQing : ClientModelViewPageBase<ScenicTicketXiangQingSearchModel>
   {
      BScenicArea2 bll = new BScenicArea2();
      public string img1Desc;
      public string img1Address;
      protected string thisurl = "";
      protected void Page_Load(object sender, EventArgs e)
      {
          string hosturl = Request.Url.Host.ToLower();
          if (hosturl.IndexOf("www") >= 0)
          {
              hosturl = "slej.cn";
          }
          thisurl = "http://m."+hosturl+"/JingQuXX.aspx?ScenicId="+Utils.GetQueryStringValue("ScenicId")+"&TicketsId="+Utils.GetQueryStringValue("TicketsId");
         (Master as Front2).HeadMenuIndex = 6;
         XiangGuanMenPiao();
      }
      private void XiangGuanMenPiao()
      {
         MScenicAreaWebSearchModel area = bll.GetScenicTicketsInfo(Model.ScenicId);
         if (area == null)
         {
            return;
         }
         else
         {
            while (area.ImgList.Count < 3)
            {
               area.ImgList.Add(new MScenicAreaImg { Address = "/Images/NoPic.jpg" });
            }
            using (var t = new timerRecorder())
            {
                Repeater2.DataSource = area.ImgList.Where(x => !string.IsNullOrEmpty(x.ImgId)).ToList();
                Repeater2.DataBind();

                Repeater4.DataSource = area.ImgList;
                Repeater4.DataBind();
                if (area.ImgList.Count > 0)
                {
                    img1Desc = area.ImgList[0].Description;
                    img1Address = area.ImgList[0].Address;
                }

                IList<MSysCity> cities = bll.GetProvinceCity(Model.ScenicId);
                Repeater3.DataSource = cities;
                Repeater3.DataBind();

                Model.ScenicArea = area;

                if (area.TicketInfo != null || area.TicketInfo.Count > 0)
                {
                    Model.FeeSettings = area.TicketInfo.First().FeeSetting;
                    if (Model.IsShowShenQing && !string.IsNullOrEmpty(Model.TicketsId))
                    {
                        var currentTicket = area.TicketInfo.FirstOrDefault(x => x.TicketsId == Model.TicketsId);
                        Repeater1.DataSource = area.TicketInfo.Where(x => x != currentTicket).OrderBy(x => x.DistributionPrice).ToArray();
                        UpdateModel(currentTicket);
                    }
                    else
                    {
                        UpdateModel(area.TicketInfo.OrderBy(x => x.DistributionPrice).First());
                        Repeater1.DataSource = area.TicketInfo.OrderBy(x => x.DistributionPrice).ToArray();
                    }
                    Repeater1.DataBind();
                }
                //Response.Write(t.getTime());
            }
         }
      }
   }
}
