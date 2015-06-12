using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.page;
using EyouSoft.Model.HotelStructure.WebModel;
using EyouSoft.Web.MasterPage;
using EyouSoft.BLL.HotelStructure;
using EyouSoft.Model.Enum;
using EyouSoft.IDAL.MemberStructure;
using System.Configuration;
using EyouSoft.Toolkit.DataProtection;
using Linq.Web;
using EyouSoft.Common;

namespace EyouSoft.Web
{
   public partial class HotelXiangQing2 : ClientModelViewPageBase<MHotelXiangQingModel2>
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
          thisurl = "http://m." + hosturl + "/HotelXX.aspx?HotelId="+Utils.GetQueryStringValue("hotelid")+"&RuZhuRiQi="+Utils.GetQueryStringValue("ruzhuriqi")+"&lidianriqi="+Utils.GetQueryStringValue("lidianriqi");
         (Master as Front2).HeadMenuIndex = 7;
         if (!Model.RuZhuRiQi.HasValue)
         {
            Model.RuZhuRiQi = DateTime.Now;
         }
         if (!Model.LiDianRiQi.HasValue)
         {
            Model.LiDianRiQi = DateTime.Now.AddDays(1);
         }
         //取酒店详情
         var hotelDetailModel = bll.GetHotelDetail2(Model);
         if (hotelDetailModel == null)
         {
            Response.End();
            return;
         } 
         //界面显示
         hotelDetailModel.SearchInfo = Model.SearchInfo;
         hotelDetailModel.RuZhuRiQi = Model.RuZhuRiQi;
         hotelDetailModel.LiDianRiQi = Model.LiDianRiQi;
         hotelDetailModel.RoomRateIds = Model.RoomRateIds;
         Model = hotelDetailModel;
      }
   }
}
