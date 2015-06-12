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
    public partial class HotelMap : ClientModelViewPageBase<MHotelSearchModel1>
    {
        BHotel2 bll = new BHotel2();
        protected string database = "";
        public string BaiduMapKey = string.Empty;
        protected override int PageSize
        {
            get
            {
                return 50;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as Front2).HeadMenuIndex = 7;
            BaiduMapKey = Utils.GetBaiduMapKeyByXml();
            if (!Model.RuZhuRiQi.HasValue)
            {
                Model.RuZhuRiQi = DateTime.Now.Date;
            }
            if (!Model.LiDianRiQi.HasValue || Model.LiDianRiQi <= Model.RuZhuRiQi)
            {
                Model.LiDianRiQi = Model.RuZhuRiQi.Value.AddDays(1).Date;
            }
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("LandMarkID")))
            {
                int LandMarkID = Utils.GetInt(Utils.GetQueryStringValue("LandMarkID"));
                var list = new EyouSoft.BLL.OtherStructure.BDiBiao().GetLandMark(LandMarkID);
                Model.Latitude = list[0].Latitude;
                Model.Longitude = list[0].Longitude;
            }
            Model.SearchInfo.PageInfo = base.PageInfo;
            Model.MustHasImg = true;
            var hotellist = bll.GetHotelMapList(Model, true, CurrentUser.UserType, false);
            for (int i = 0; i < hotellist.Count; i++)
            {
                EyouSoft.Model.HotelStructure.MHotel hotmodel = new EyouSoft.BLL.HotelStructure.BHotel().GetModel(hotellist[i].HotelId);
               database += "{ title: '" + hotellist[i].HotelName + "'"
               + ", content: '星级：" + hotellist[i].Star + "&nbsp;<br>电话：" + hotmodel.ServiceTel + "<br>"
               + "地址：" + hotmodel.Address + "<br><font color=red><a target=\"_blank\" href='/HotelXiangQing.aspx?HotelId=" + hotellist[i].HotelId + "&RuZhuRiQi=" + Model.RuZhuRiQi + "&lidianriqi=" + Model.LiDianRiQi + "'>点击查看</a></font>', point: '" + hotellist[i].Longitude + "|" + hotellist[i].Latitude + "', isOpen: 1, icon: { w: 23, h: 25, l: 46, t: 21, x: 9, lb: 12} },";

                //database += "{ title: '" + hotellist[i].HotelName + "'"
                //+ ", content: '：" + hotellist[i].Star + "&nbsp;<br>地址：" + hotellist[i].Address + "<br>"
                //+ "<font color=red>点击查看</font>', point: '" + hotellist[i].Latitude + "|" + hotellist[i].Longitude + "', isOpen: 1, icon: { w: 23, h: 25, l: 46, t: 21, x: 9, lb: 12} },";
            }
            database = database.TrimEnd(',');
        }
    }
}
