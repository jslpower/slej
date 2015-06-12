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
    public partial class HotelList : WebPageBase
    {
        BHotel2 bll = new BHotel2();
        MHotelSearchModel1 Model = new MHotelSearchModel1();
        protected string ruzhuriqi = "";
        protected string lidianriqi = "";
        protected string CitySanZiMa = "HGH";
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
            ruzhuriqi = Model.RuZhuRiQi.Value.ToString("yyyy-MM-dd");
            lidianriqi = Model.LiDianRiQi.Value.ToString("yyyy-MM-dd");

            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("longitude")) && !string.IsNullOrEmpty(Utils.GetQueryStringValue("latitude")))
            {
                Model.Latitude = Utils.GetQueryStringValue("latitude");
                Model.Longitude = Utils.GetQueryStringValue("longitude");
            }
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("LandMarkID")))
            {
                int LandMarkID = Utils.GetInt(Utils.GetQueryStringValue("LandMarkID"));
                var list = new EyouSoft.BLL.OtherStructure.BDiBiao().GetLandMark(LandMarkID);
                Model.Latitude = list[0].Latitude;
                Model.Longitude = list[0].Longitude;
            }
            Model.SearchInfo = new Linq.Bussiness.SearchModel() { PageInfo = new Linq.Bussiness.PageInfo() { PageIndex = 1, PageSize = 8 } };
            Model.MustHasImg = true;
            Model.IsIndex = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐, EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 };
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("Star")))
            {
                Model.Star = (EyouSoft.Model.Enum.HotelStar)Utils.GetInt(Utils.GetQueryStringValue("Star"));
            }
            Model.SanZiMa = Utils.GetQueryStringValue("CityCode");
            CitySanZiMa = Model.SanZiMa;
            Model.HotelName = Utils.GetQueryStringValue("HotelName");
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("JiaGe1")))
            {
                Model.JiaGe1 = Convert.ToInt32(Utils.GetQueryStringValue("JiaGe1"));
            }
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("JiaGe2")))
            {
                Model.JiaGe2 = Convert.ToInt32(Utils.GetQueryStringValue("JiaGe2"));
            }
            if (!isLogin)
            {
                var list = bll.GetHotelList(Model, true, EyouSoft.Model.Enum.MemberTypes.普通会员, false);
                if (list == null || list.Count == 0) { XianShi.Text = "没房？房型不适合？调整日期试试看！"; }
                Repeater1.DataSource = list;
                Repeater1.DataBind();
            }
            else
            {
                var list = bll.GetHotelList(Model, true, m.UserType, false);
                if (list == null || list.Count == 0) { XianShi.Text = "没房？房型不适合？调整日期试试看！"; }
                Repeater1.DataSource = list;
                Repeater1.DataBind();
            }
            
        }

        public string GetAddress(object hotelid)
        {
            string address = "";
            if (hotelid != null && hotelid.ToString() != "")
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
