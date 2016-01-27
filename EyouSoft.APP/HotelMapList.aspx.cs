using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.BLL.HotelStructure;
using EyouSoft.Common;
using EyouSoft.Model.HotelStructure.WebModel;
using EyouSoft.Common.Page;

namespace EyouSoft.WAP
{
    public partial class HotelMapList : WebPageBase
    {
        BHotel2 bll = new BHotel2();
        MHotelSearchModel1 Model = new MHotelSearchModel1();
        protected string hotellist = "";
        protected string lngnum = "120.170004";
        protected string latnum = "30.276711";
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "酒店列表";
            if (string.IsNullOrEmpty(Utils.GetQueryStringValue("RuZhuRiQi")))
            {
                Model.RuZhuRiQi = DateTime.Now.Date;
            }
            else
            {
                Model.RuZhuRiQi = Convert.ToDateTime(Utils.GetQueryStringValue("RuZhuRiQi"));
            }
            if (string.IsNullOrEmpty(Utils.GetQueryStringValue("LiDianRiQi")))
            {
                Model.LiDianRiQi = Model.RuZhuRiQi.Value.AddDays(1).Date;
            }
            else
            {
                Model.LiDianRiQi = Convert.ToDateTime(Utils.GetQueryStringValue("LiDianRiQi"));
            }
            if (Model.LiDianRiQi <= Model.RuZhuRiQi)
            {
                Model.LiDianRiQi = Model.RuZhuRiQi.Value.AddDays(1).Date;
            }

            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("longitude")) && !string.IsNullOrEmpty(Utils.GetQueryStringValue("latitude")))
            {
                Model.Latitude = Utils.GetQueryStringValue("latitude");
                Model.Longitude = Utils.GetQueryStringValue("longitude");
            }
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("LandMarkID")))
            {
                int LandMarkID = Utils.GetInt(Utils.GetQueryStringValue("LandMarkID"));
                var items = new EyouSoft.BLL.OtherStructure.BDiBiao().GetLandMark(LandMarkID);
                Model.Latitude = items[0].Latitude;
                Model.Longitude = items[0].Longitude;
            }
            Model.SearchInfo = new Linq.Bussiness.SearchModel() { PageInfo = new Linq.Bussiness.PageInfo() { PageIndex = 1, PageSize = 150 } };
            Model.MustHasImg = true;
            Model.IsIndex = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐, EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 };
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("Star")))
            {
                Model.Star = (EyouSoft.Model.Enum.HotelStar)Utils.GetInt(Utils.GetQueryStringValue("Star"));
            }
            Model.SanZiMa = Utils.GetQueryStringValue("CityCode");
            Model.HotelName = Utils.GetQueryStringValue("HotelName");
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("JiaGe1")))
            {
                Model.JiaGe1 = Convert.ToInt32(Utils.GetQueryStringValue("JiaGe1"));
            }
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("JiaGe2")))
            {
                Model.JiaGe2 = Convert.ToInt32(Utils.GetQueryStringValue("JiaGe2"));
            }
            var list = bll.GetHotelMapList(Model, true, EyouSoft.Model.Enum.MemberTypes.普通会员, false);
            if (list != null && list.Count > 0)
            {
                lngnum = list[0].Longitude;
                latnum = list[0].Latitude;
                for (int i = 0; i < list.Count; i++)
                {
                    hotellist += " [" + list[i].Longitude + "," + list[i].Latitude + ",\"<a href='/HotelXX.aspx?HotelId=" + list[i].HotelId + "&RuZhuRiQi=" + Convert.ToDateTime(Model.RuZhuRiQi).ToShortDateString() + "&lidianriqi=" + Convert.ToDateTime(Model.LiDianRiQi).ToShortDateString() + "'>" + list[i].HotelName + "</a><br />" + list[i].Star + "<br />客服电话：" + list[i].ServiceTel + "<br />地址：" + list[i].Address + "\"],";
                }
            }
            hotellist = hotellist.TrimEnd(',');
            
        }
    }
}
