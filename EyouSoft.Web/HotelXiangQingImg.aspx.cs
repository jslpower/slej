using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Model.HotelStructure.WebModel;
using Common.page;
using EyouSoft.Model.HotelStructure;
using EyouSoft.BLL.HotelStructure;

namespace EyouSoft.Web
{
   public partial class HotelXiangQingImg : ClientModelViewPageBase<MHotelXiangQingModel>
   {
      BHotel2 bll = new BHotel2();
      protected void Page_Load(object sender, EventArgs e)
      {
         if (!string.IsNullOrEmpty(Model.HotelId))
         {
            Model.SearchInfo.PageInfo.PageSize = 4;
            Model.SearchInfo.PageInfo.PageIndex = 1;
            Model.Images = bll.GetHotelImgList(Model);
            if (Request["direction"] == "up")
            {
               Model.SearchInfo.PageInfo.PageIndex -= 1;
            }
            if (Request["direction"] == "down")
            {
               Model.SearchInfo.PageInfo.PageIndex += 1;
            }
            if (Model.SearchInfo.PageInfo.PageIndex < 1)
            {
               Model.SearchInfo.PageInfo.PageIndex = 1;
            }
            if ((Model.Images == null || Model.Images.Count == 0) && Request.QueryString["direction"] == "down")
            {
               Model.SearchInfo.PageInfo.PageIndex -= 1;
            }
            if (Model.Images == null)
            {
               Model.Images = new List<MHotelImg>();
            } 
            while (Model.Images.Count < 4)
            {
               Model.Images.Add(new MHotelImg { FilePath = EmptyImage });
            }
            foreach (var img in Model.Images)
            {
               if (string.IsNullOrEmpty(img.FilePath))
               {
                  img.FilePath = EmptyImage;
               }
            }
         }
      }
   }
}
