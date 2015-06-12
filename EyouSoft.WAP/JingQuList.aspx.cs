using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Model.ScenicStructure;
using Common.page;
using EyouSoft.BLL.ScenicStructure;
using EyouSoft.Model.ScenicStructure.WebModel;
using Linq.Web;
using EyouSoft.BLL.OtherStructure;
using EyouSoft.Model.Enum;
using EyouSoft.Model;
using Linq.Common;
using EyouSoft.InterfaceLib.Common;
using EyouSoft.Common.Page;

namespace EyouSoft.WAP
{
    public partial class JingQuList : WebPageBase
    {
        BScenicArea2 bll = new BScenicArea2();
        public string SearchName = "景区名称";
        public string cityid = "";
        public string proinceid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = Utils.GetQueryStringValue("CityName");
            GetJingQu();
        }
        private void GetJingQu()
        {
            MScenicAreaWebSearchModel Model = new MScenicAreaWebSearchModel() { SearchInfo = new Linq.Bussiness.SearchModel() { PageInfo = new Linq.Bussiness.PageInfo() { PageIndex = 1, PageSize = 12 } } };
            Model.IsIndex = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐, EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 };
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("ProvinceId")))
            {
                Model.ProvinceId = Convert.ToInt32(Utils.GetQueryStringValue("ProvinceId"));
                proinceid = Model.ProvinceId.ToString();
            }
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("CityId")))
            {
                Model.CityId = Convert.ToInt32(Utils.GetQueryStringValue("CityId"));
                cityid = Model.CityId.ToString();
            }
            if (Utils.GetQueryStringValue("SearchName") != "景区名称")
            {
                Model.ScenicName = Utils.GetQueryStringValue("SearchName");
            }
            if (!string.IsNullOrEmpty(Model.ScenicName))
            {
                SearchName = Model.ScenicName;
            }
            var list = bll.GetScenicList(Model);
            if (list == null || list.Count == 0) { XianShi.Text = "该地区暂无景点！"; }
            Repeater1.DataSource = list;
            Repeater1.DataBind();
        }
    }
}
