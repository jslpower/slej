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
using EyouSoft.Common;
using EyouSoft.Common.Page;

namespace EyouSoft.WAP
{
    public partial class JingQuList : WebPageBase
    {
        BScenicArea2 bll = new BScenicArea2();
        public string SearchName = "景区名称";
        public string cityid = "";
        public string proinceid = "";
        #region 微信分享
        protected string weixin_jsapi_config = string.Empty
                                    , FenXiangBiaoTi = string.Empty
                                    , FenXiangMiaoShu = string.Empty
                                    , FenXiangTuPianFilepath = string.Empty
                                    , FenXiangLianJie = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = EyouSoft.Common.Utils.GetQueryStringValue("CityName");
            GetJingQu();
            IList<string> weixin_jsApiList = new List<string>();
            weixin_jsApiList.Add("onMenuShareTimeline");
            weixin_jsApiList.Add("onMenuShareAppMessage");
            weixin_jsApiList.Add("onMenuShareQQ");
            var weixing_config_info = EyouSoft.Common.Utils.get_weixin_jsapi_config_info(weixin_jsApiList);
            weixin_jsapi_config = Newtonsoft.Json.JsonConvert.SerializeObject(weixing_config_info);

            FenXiangBiaoTi = EyouSoft.Common.Utils.GetQueryStringValue("CityName") + "景区门票";
            FenXiangMiaoShu = EyouSoft.Common.Utils.GetQueryStringValue("CityName") + "景区门票";
            FenXiangLianJie = Utils.redirectUrl(HttpContext.Current.Request.Url.ToString());
        }
        private void GetJingQu()
        {
            MScenicAreaWebSearchModel Model = new MScenicAreaWebSearchModel() { SearchInfo = new Linq.Bussiness.SearchModel() { PageInfo = new Linq.Bussiness.PageInfo() { PageIndex = 1, PageSize = 12 } } };
            Model.IsIndex = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐, EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 };
            if (!string.IsNullOrEmpty(EyouSoft.Common.Utils.GetQueryStringValue("ProvinceId")))
            {
                Model.ProvinceId = Convert.ToInt32(EyouSoft.Common.Utils.GetQueryStringValue("ProvinceId"));
                proinceid = Model.ProvinceId.ToString();
            }
            if (!string.IsNullOrEmpty(EyouSoft.Common.Utils.GetQueryStringValue("CityId")))
            {
                Model.CityId = Convert.ToInt32(EyouSoft.Common.Utils.GetQueryStringValue("CityId"));
                cityid = Model.CityId.ToString();
            }
            if (EyouSoft.Common.Utils.GetQueryStringValue("SearchName") != "景区名称")
            {
                Model.ScenicName = EyouSoft.Common.Utils.GetQueryStringValue("SearchName");
            }
            if (!string.IsNullOrEmpty(Model.ScenicName))
            {
                SearchName = Model.ScenicName;
            }
            var list = bll.GetScenicList(Model);
            if (list == null || list.Count == 0) { XianShi.Text = "该地区暂无景点！"; }
            else
            {
                FenXiangTuPianFilepath = "http://" + HttpContext.Current.Request.Url.Host + TuPian.F1(list[0].ImgFirst.Address, 320, 240);
                Repeater1.DataSource = list;
                Repeater1.DataBind();
            }
        }
    }
}
