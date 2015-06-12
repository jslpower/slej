using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Model.HotelStructure;
using Common.page;
using EyouSoft.Model.HotelStructure.WebModel;
using EyouSoft.BLL.HotelStructure;
using System.Web.UI.HtmlControls;
using EyouSoft.Model;
using EyouSoft.BLL.OtherStructure;
using EyouSoft.Model.Enum;
using EyouSoft.Model.SystemStructure;
using EyouSoft.BLL.SystemStructure;
using EyouSoft.Web.MasterPage;
using EyouSoft.Common;

namespace EyouSoft.Web
{
   public partial class Hotel : ClientModelViewPageBase<MHotelSearchModel1>
   {
      BHotel2 bll = new BHotel2();
      BSysAdv bllAdv = new BSysAdv();
      protected override int PageSize
      {
         get
         {
            return 8;
         }
      }

      protected void Page_Load(object sender, EventArgs e)
      {
         (Master as Front).HeadMenuIndex = 7;
         List<MSysAdv> imgList = new List<MSysAdv>(bllAdv.GetList(new EyouSoft.Model.MSearchSysAdv { AreaIds = new AdvArea[] { AdvArea.酒店首页轮换广告 } }));
         while (imgList.Count < 5)
         {
            imgList.Add(new EyouSoft.Model.MSysAdv { ImgPath = EmptyImage, AdvLink = "javascript:;" });
         }
         Repeater1.DataSource = imgList;
         Repeater1.DataBind();

         if (!Model.RuZhuRiQi.HasValue)
         {
            Model.RuZhuRiQi = DateTime.Now.AddDays(7).Date;
         }
         if (!Model.LiDianRiQi.HasValue || Model.LiDianRiQi <= Model.RuZhuRiQi)
         {
            Model.LiDianRiQi = DateTime.Now.AddDays(8).Date;
         }
         if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("LandMarkID")))
         {
             int LandMarkID= Utils.GetInt(Utils.GetQueryStringValue("LandMarkID"));
             var list = new EyouSoft.BLL.OtherStructure.BDiBiao().GetLandMark(LandMarkID);
             Model.Latitude = list[0].Latitude;
             Model.Longitude = list[0].Longitude;
         }
         Model.SearchInfo.PageInfo = base.PageInfo;
         Model.MustHasImg = true;
         Model.IsIndex = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐, EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 };
         var items = bll.GetHotelList(Model, true, CurrentUser.UserType, false);
         if (items.Count>0)
         {
             Repeater2.DataSource = items;
             Repeater2.DataBind();
         }
         else
         {
             TiShiXinXi.Visible = true;
         }
      }

      protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
      {

         if ((e.Item.ItemType & (ListItemType.AlternatingItem | ListItemType.Item)) == e.Item.ItemType)
         {
            Repeater repeater3 = e.Item.FindControl("Repeater3") as Repeater;
            string hotelId = DataBinder.Eval(e.Item.DataItem, "HotelId").ToString();

            var roomRates = (e.Item.DataItem as MHotelSearchModel1).RoomRateInfo.OrderBy(x => x.RoomTypeInfo.RoomTypeId);
            int count = roomRates.Count();
            if (roomRates != null)
            {
               repeater3.DataSource = roomRates;
               repeater3.DataBind();
               HtmlGenericControl label = e.Item.FindControl("b1") as HtmlGenericControl;
               label.Attributes.Add("totalNumber", count.ToString());
               label.InnerHtml = "展开全部房型（" + (count - 3).ToString() + "）";
               if (repeater3.Items.Count <= 3)
               {
                  var div = (e.Item.FindControl("caozuo_box") as HtmlGenericControl);
                  div.Style[HtmlTextWriterStyle.Display] = "none";
               }
            }
         }
      }

      /// <summary>
      /// 酒店的星级
      /// </summary>
      public static string GetHotelStarString(object star)
      {
         if (star == null)
         {
            return "";
         }
         int? st = (int)star;
         if (!st.HasValue)
         {
            return "";
         }
         if (st.Value > 10)
         {
            return "<img alt='二星级以下' src=\"images/star-kong.gif\" />";
         }
         else
         {
            if (st.Value > 5)
            {
               return ("<img alt='参考" + st.Value + "星级' src=\"images/star-kong.gif\" />").Replicate(st.Value - 5);
            }
            else
            {
               return ("<img alt='挂" + st.Value + "星级' src=\"images/star.gif\" />").Replicate(st.Value);
            }
         }
      }
      public string GetAddress(object hotelid)
      {
          string address ="";
          if(hotelid !=null && hotelid.ToString() !="")
          {
              var list = new EyouSoft.BLL.HotelStructure.BHotel().GetModel(hotelid.ToString());
              if (list != null)
              {
                  address = list.Address;
              }
          }
          return address;
      }
   }
}
