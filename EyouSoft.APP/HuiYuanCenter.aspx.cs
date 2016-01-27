using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.WAP
{
    public partial class HuiYuanCenter : System.Web.UI.Page
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
            WapHeader1.HeadText = "会员中心";
            IList<string> weixin_jsApiList = new List<string>();
            weixin_jsApiList.Add("onMenuShareTimeline");
            weixin_jsApiList.Add("onMenuShareAppMessage");
            weixin_jsApiList.Add("onMenuShareQQ");
            var weixing_config_info = Utils.get_weixin_jsapi_config_info(weixin_jsApiList);
            weixin_jsapi_config = Newtonsoft.Json.JsonConvert.SerializeObject(weixing_config_info);
            FenXiangBiaoTi = "会员中心";
            FenXiangMiaoShu = "会员中心";
            FenXiangTuPianFilepath = "http://" + Request.Url.Host + "/images/logo.jpg";
            FenXiangLianJie = Utils.redirectUrl( HttpContext.Current.Request.Url.ToString());
        }
    }
}
