using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Model;
using EyouSoft.Model.Enum;
using EyouSoft.Common;

namespace EyouSoft.WAP.Flight
{
    public partial class Default : System.Web.UI.Page
    {
        #region 微信分享
        protected string weixin_jsapi_config = string.Empty
                                    , FenXiangBiaoTi = string.Empty
                                    , FenXiangMiaoShu = string.Empty
                                    , FenXiangTuPianFilepath = string.Empty
                                    , FenXiangLianJie = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.isfx = true;
            WapHeader1.HeadText = "机票预订";
            InitAd();

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
            List<MSysAdv> imgList = new List<MSysAdv>(bll.GetList(5, AdvArea.机票栏目广告));
            List<string> files = new List<string>();
            List<string> hrefs = new List<string>();
            if (imgList != null && imgList.Count > 0)
            {
                #region 设置微信分享链接
                //设置图片链接
                WapHeader1.FenXiangTuPianFilepath = "http://" + Request.Url.Host + imgList[0].ImgPath;
                #endregion

                foreach (var item in imgList)
                {
                    files.Add(TuPian.F1(item.ImgPath, 640, 200));
                    hrefs.Add(item.AdvLink);
                }

            }
            ScrollImg1.ImgUrl = files;
            ScrollImg1.HrefUrl = hrefs;
            #endregion



            WapHeader1.FenXiangBiaoTi = "机票预订";
            WapHeader1.FenXiangMiaoShu = "机票预订";
            WapHeader1.FenXiangLianJie = Utils.redirectUrl(HttpContext.Current.Request.Url.ToString().Replace("p.", "m."));

        }
    }
}
