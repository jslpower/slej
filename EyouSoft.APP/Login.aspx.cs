using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using EyouSoft.Common;

namespace EyouSoft.WAP
{
    public partial class Login : System.Web.UI.Page
    {
        #region 微信分享
        protected string weixin_jsapi_config = string.Empty
                                    , FenXiangBiaoTi = string.Empty
                                    , FenXiangMiaoShu = string.Empty
                                    , FenXiangTuPianFilepath = string.Empty
                                    , FenXiangLianJie = string.Empty;

        // 定义正则表达式用来匹配 img 标签   
        Regex regImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WapHeader1.FenXiangBiaoTi = "登陆";
                WapHeader1.FenXiangMiaoShu = "登陆";
                WapHeader1.FenXiangTuPianFilepath = "http://p.8766.slej.cn/images/logo.jpg";
                WapHeader1.FenXiangLianJie = Utils.redirectUrl(HttpContext.Current.Request.Url.ToString().Replace("p.", "m."));
            }
           
        }
    }
}
