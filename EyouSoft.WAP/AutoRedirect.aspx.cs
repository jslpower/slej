using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Weixin.Mp.Sdk;
using System.Net;
using System.Text;

namespace EyouSoft.WAP
{
    public partial class AutoRedirect : System.Web.UI.Page
    {
        string Appid = "";
        string appsecret = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Appid = Utils.GetConfigString("", "slejAppId").Trim();
            appsecret = Utils.GetConfigString("", "slejAppSecret").Trim();


            Response.Buffer = true;
            Response.CacheControl = "no-cache";    //禁止代理服务器缓存本页面
            Response.Expires = -1000;

            if (!string.IsNullOrEmpty(Request.QueryString["code"]))
            {
                string Code = Request.QueryString["code"].ToString();
                OAuth_Token Model = Get_token(Code);
                string OpenId = Model.openid;
                string BaseUrl = HttpContext.Current.Server.UrlDecode(Request.QueryString["state"]);
                if (!String.IsNullOrEmpty(OpenId))
                {
                    Utils.setOpenidCookie(OpenId);
                    if (!String.IsNullOrEmpty(BaseUrl))
                    {
                        Response.Redirect(BaseUrl, true);
                        return;
                    }

                }

            }




        }
        //获得Token  
        protected OAuth_Token Get_token(string Code)
        {
            string Str = GetJson("https://api.weixin.qq.com/sns/oauth2/access_token?appid=" + Appid + "&secret=" + appsecret + "&code=" + Code + "&grant_type=authorization_code");
            OAuth_Token Oauth_Token_Model = JsonHelper.ParseFromJson<OAuth_Token>(Str);
            return Oauth_Token_Model;
        }
        //刷新Token  
        protected OAuth_Token refresh_token(string REFRESH_TOKEN)
        {
            string Str = GetJson("https://api.weixin.qq.com/sns/oauth2/refresh_token?appid=" + Appid + "&grant_type=refresh_token&refresh_token=" + REFRESH_TOKEN);
            OAuth_Token Oauth_Token_Model = JsonHelper.ParseFromJson<OAuth_Token>(Str);
            return Oauth_Token_Model;
        }
        //获得用户信息  
        protected OAuthUser Get_UserInfo(string REFRESH_TOKEN, string OPENID)
        {
            // Response.Write("获得用户信息REFRESH_TOKEN:" + REFRESH_TOKEN + "||OPENID:" + OPENID);  
            string Str = GetJson("https://api.weixin.qq.com/sns/userinfo?access_token=" + REFRESH_TOKEN + "&openid=" + OPENID);
            OAuthUser OAuthUser_Model = JsonHelper.ParseFromJson<OAuthUser>(Str);
            return OAuthUser_Model;
        }
        protected string GetJson(string url)
        {
            WebClient wc = new WebClient();
            wc.Credentials = CredentialCache.DefaultCredentials;
            wc.Encoding = Encoding.UTF8;
            string returnText = wc.DownloadString(url);

            if (returnText.Contains("errcode"))
            {
                //可能发生错误  
            }
            //Response.Write(returnText);  
            return returnText;
        }
    }
}
