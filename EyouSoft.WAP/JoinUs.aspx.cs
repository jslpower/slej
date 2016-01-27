using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.WAP
{
    public partial class JoinUs : System.Web.UI.Page
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
            if (!Page.IsPostBack)
            {
                GetAbout();
            }
            IList<string> weixin_jsApiList = new List<string>();
            weixin_jsApiList.Add("onMenuShareTimeline");
            weixin_jsApiList.Add("onMenuShareAppMessage");
            weixin_jsApiList.Add("onMenuShareQQ");
            var weixing_config_info = Utils.get_weixin_jsapi_config_info(weixin_jsApiList);
            weixin_jsapi_config = Newtonsoft.Json.JsonConvert.SerializeObject(weixing_config_info);
            FenXiangBiaoTi = "加入我们";
            FenXiangMiaoShu = "加入我们";
            FenXiangTuPianFilepath = "http://" + Request.Url.Host + "/images/logo.jpg";
            FenXiangLianJie =  Utils.redirectUrl(HttpContext.Current.Request.Url.ToString());
        }
        protected void GetAbout()
        {
            EyouSoft.BLL.OtherStructure.BKV BLL = new EyouSoft.BLL.OtherStructure.BKV();
            EyouSoft.Model.MCompanySetting model = BLL.GetCompanySetting();
            if (model == null) return;
            JIARUWOMEN.Text += model.WapMakeFenXiao + "<BR/>";
            JIARUWOMEN.Text += string.IsNullOrEmpty(model.WapMakeGongYing) ? "" : model.WapMakeGongYing + "<BR/>";
            JIARUWOMEN.Text += string.IsNullOrEmpty(model.WapMakeGuiBin) ? "" : model.WapMakeGuiBin + "<BR/>";
            JIARUWOMEN.Text += string.IsNullOrEmpty(model.WapMakePuTong) ? "" : model.WapMakePuTong + "<BR/>";
            JIARUWOMEN.Text += string.IsNullOrEmpty(model.WapMakeYingPing) ? "" : model.WapMakeYingPing + "<BR/>";
            JIARUWOMEN.Text = JIARUWOMEN.Text.Replace("<img", "<img  class=\"about_xx_img\" ");

        }
    }
}
