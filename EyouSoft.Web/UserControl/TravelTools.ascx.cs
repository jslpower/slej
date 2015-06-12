using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyouSoft.Web.UserControl
{
   public partial class TravelTools : System.Web.UI.UserControl
   {
      protected string urllist = string.Empty;
      protected void Page_Load(object sender, EventArgs e)
      {
         var model = new BLL.OtherStructure.BKV().GetCompanySetting();
         if (model == null)
            return;
         urllist = "<li><a href='" + model.TrainSearch + "' target='_blank'><s class='huoche'></s><span>火车查询</span></a></li>"
      + "<li><a href='" + model.TransitSearch + "' target='_blank'><s class='gongjiao'></s><span>公交查询</span></a></li>"
      + "<li class='marR0'><a href='" + model.WeatherSearch + "' target='_blank'><s class='tianqi'></s><span>天气查询</span></a></li>"
      + "<li><a href='" + model.FlightSearch + "' target='_blank'><s class='hangban'></s><span>航班查询</span></a></li>"
      + "<li><a href='" + model.MobileSearch + "' target='_blank'><s class='phone'></s><span>手机查询</span></a></li>"
      + "<li class='marR0'><a href='" + model.TrainTravelTips + "' target='_blank'><s class='lvyou'></s><span>火车旅游常识</span></a></li>"
      + "<li><a href='" + model.TouristMap + "' target='_blank'><s class='map'></s><span>旅游地图</span></a></li>"
      + "<li><a href='" + model.OnlineTranslation + "' target='_blank'><s class='fanyi'></s><span>在线翻译</span></a></li>"
      + "<li class='marR0'><a href='" + model.ZipCode + "' target='_blank'><s class='youbian'></s><span>邮编区号</span></a></li>";
      }
   }
}