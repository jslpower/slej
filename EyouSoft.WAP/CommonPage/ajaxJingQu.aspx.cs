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

namespace EyouSoft.WAP.CommonPage
{
    public partial class ajaxJingQu : ClientModelViewPageBase<MScenicAreaWebSearchModel>
    {
        BScenicArea2 bll = new BScenicArea2();
        protected override int PageSize
        {
            get
            {
                return 12;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Model.SearchInfo.PageInfo = PageInfo;
            int pageindex = Utils.GetInt(Utils.GetQueryStringValue("pageindex"));
            Model.SearchInfo.PageInfo.PageIndex = pageindex;
            Model.IsIndex = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐, EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 };
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("ProvinceId")))
            {
                Model.ProvinceId = Convert.ToInt32(Utils.GetQueryStringValue("ProvinceId"));
            }
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("CityId")))
            {
                Model.CityId = Convert.ToInt32(Utils.GetQueryStringValue("CityId"));
            }
            if (Utils.GetQueryStringValue("SearchName") != "景区名称")
            {
                Model.ScenicName = Utils.GetQueryStringValue("SearchName");
            }
            var list = bll.GetScenicList(Model);
            Repeater1.DataSource = list;
            Repeater1.DataBind();
        }
    }
}
