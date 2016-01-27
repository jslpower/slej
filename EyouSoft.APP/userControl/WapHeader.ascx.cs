using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Model.SSOStructure;

namespace EyouSoft.WAP.userControl
{
    public partial class WapHeader : System.Web.UI.UserControl
    {
        protected string TelNum = "4006588180";
        private string _headText;
        /// <summary>
        /// 设置logo图片的URL
        /// </summary>
        public string HeadText
        {
            get { return _headText; }
            set { _headText = value; }
        }
        /// <summary>
        /// 是否登录，登录则不显示注册登录按钮
        /// </summary>
        public bool isLogin
        {
            get
            {
                MUserInfo m = null;
                bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out m);
                return !isLogin;
            }
        }
        #region 微信分享
        public string weixin_jsapi_config = string.Empty
                                    , FenXiangBiaoTi = string.Empty
                                    , FenXiangMiaoShu = string.Empty
                                    , FenXiangTuPianFilepath = string.Empty
                                    , FenXiangLianJie = string.Empty;
        #endregion
        public bool isfx=false;
        public bool iscd = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            string requesturl = System.Web.HttpContext.Current.Request.Url.Host.ToLower();
            if (requesturl.IndexOf("m.") > -1)
            {
                //m.1234.slej.cn   m.slej.cn
                requesturl = requesturl.Replace("m.", "");
                if (requesturl.IndexOf("slej.cn") > 1)
                {
                    string website = HttpContext.Current.Request.Url.Host.ToLower().Replace("m.", "");
                    EyouSoft.Model.AccountStructure.MSellers seller = new EyouSoft.IDAL.AccountStructure.BSellers().GetMSellersByWebSite(website);
                    if (seller != null)
                    {
                        var item = new EyouSoft.IDAL.MemberStructure.BMember2().Get(seller.MemberID);
                        if (item != null)
                        {
                            TelNum = item.Mobile;
                        }

                    }
                }
            }
            else
            {
                if (requesturl.IndexOf("slej.cn") > -1 && requesturl.IndexOf("www") < 0)
                {
                    string website = HttpContext.Current.Request.Url.Host.ToLower().Replace("m.", "");
                    EyouSoft.Model.AccountStructure.MSellers seller = new EyouSoft.IDAL.AccountStructure.BSellers().GetMSellersByWebSite(website);
                    if (seller != null)
                    {
                        var item = new EyouSoft.IDAL.MemberStructure.BMember2().Get(seller.MemberID);
                        if (item != null)
                        {
                            TelNum = item.Mobile;
                        }

                    }
                }
            }
        }
    }
}