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
using EyouSoft.Common.Page;
using EyouSoft.Common;

namespace EyouSoft.WAP.JingQu
{
    public partial class JingQu : WebPageBase
    {
        protected string pSelect = "0", cSelect = "0";
        BScenicArea2 bll = new BScenicArea2();
        protected string toplist = string.Empty;
        protected string dianlist = string.Empty;//确认个数
        #region 微信分享
        protected string weixin_jsapi_config = string.Empty
                                    , FenXiangBiaoTi = string.Empty
                                    , FenXiangMiaoShu = string.Empty
                                    , FenXiangTuPianFilepath = string.Empty
                                    , FenXiangLianJie = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "浙江";
            InitAd();
            GetJingQu();
            IList<string> weixin_jsApiList = new List<string>();
            weixin_jsApiList.Add("onMenuShareTimeline");
            weixin_jsApiList.Add("onMenuShareAppMessage");
            weixin_jsApiList.Add("onMenuShareQQ");
            var weixing_config_info = Utils.get_weixin_jsapi_config_info(weixin_jsApiList);
            weixin_jsapi_config = Newtonsoft.Json.JsonConvert.SerializeObject(weixing_config_info);
        }

        /// <summary>
        /// 绑定页面广告
        /// </summary>
        private void InitAd()
        {

            #region 图片处理
            
            EyouSoft.BLL.OtherStructure.BSysAdv bll = new EyouSoft.BLL.OtherStructure.BSysAdv();
            //首页轮播图
            List<MSysAdv> imgList = new List<MSysAdv>(bll.GetList(5, AdvArea.优惠门票首页轮换广告));

            FenXiangBiaoTi = "优惠门票";
            FenXiangMiaoShu = "优惠门票";
            if (imgList != null && imgList.Count > 0)
            {
                FenXiangTuPianFilepath = "http://" + Request.Url.Host + TuPian.F1(imgList[0].ImgPath[0], 640, 200);
            }
            FenXiangLianJie = HttpContext.Current.Request.Url.ToString();

            List<string> files = new List<string>();
            List<string> hrefs = new List<string>();
            if (imgList != null && imgList.Count > 0)
            {
                foreach (var item in imgList)
                {
                    files.Add(TuPian.F1(item.ImgPath,640,200));
                    hrefs.Add(item.AdvLink);
                }

            }
            ScrollImg1.ImgUrl = files;
            ScrollImg1.HrefUrl = hrefs;
            ScrollImg1.ImgGth = 200;
            ScrollImg1.ImgWid = 640;
            #endregion


           
            //if (imgList != null && imgList.Count > 0)
            //{
            //    for (int i = 0; i < imgList.Count; i++)
            //    {

            //        toplist += "<div class=\"slide slide-transition active\"><a href=\"" + imgList[i].AdvLink + "\" target=\"_blank\"><img src=\"" + imgList[i].ImgPath + "\" /></a></div>";
            //        if (i == 0)
            //        {
            //            dianlist += "<a class=\"radiusl dot-select\"></a>";
            //        }
            //        else
            //        {
            //            dianlist += "<a class=\"radiusl dot\"></a>";
            //        }
            //    }
            //}

        }
        private void GetJingQu()
        {
            MScenicAreaWebSearchModel Model = new MScenicAreaWebSearchModel() { SearchInfo = new Linq.Bussiness.SearchModel() { PageInfo = new Linq.Bussiness.PageInfo() { PageIndex = 1, PageSize = 12 } } };
            //Model.IsIndex = new[] { EyouSoft.Model.Enum.XianLuStructure.XianLuZT.首页推荐, EyouSoft.Model.Enum.XianLuStructure.XianLuZT.默认状态 };
            Model.ScenicName = Utils.GetQueryStringValue("SearchName");
            var list = bll.GetScenicList(Model);

            Repeater1.DataSource = list;
            Repeater1.DataBind();
        }
    }
}
