using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.page;
using EyouSoft.Common;
using PayAPI.Model.Tencent;
using EyouSoft.WAP.tenPay;

namespace EyouSoft.WAP.Member
{

    public partial class ChongZhi : HuiYuanWapPageBase
    {

        protected TenPayTrade TenPayTradeModel = new TenPayTrade();
        protected PrePay _TenPayTradeModel = new PrePay();
        protected string weixin_jsapi_config = string.Empty;
        protected string openid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Utils.GetQueryStringValue("chongzhi") == "1") baocun();
            EyouSoft.Model.SSOStructure.MUserInfo m = null;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out m);
            if (!isLogin) Response.Redirect("/default.aspx");
            if (Request.UserAgent.ToLower().Contains("micromessenger"))
            {
                getOpentID();
                //plaIsWxBow.Visible = true;

            }
           
        }
        /// <summary>
        /// 保存充值信息
        /// </summary>
        void baocun()
        {
            var model = new EyouSoft.Model.OtherStructure.MChongZhi();
            model.DingDanId = Guid.NewGuid().ToString();
            model.HuiYuanId = HuiYuanInfo.UserId;
            model.JinE = Utils.GetDecimal(Utils.GetFormValue("txtjine"));
            model.ZhiFuStatus = EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.未付款;
            int result = new EyouSoft.BLL.OtherStructure.BChongZhi().Add(model);

            if (result == 1)
            {
                ////发送短信
                //var duanXinInfo = new EyouSoft.Model.OtherStructure.MDuanXinInfo();
                //duanXinInfo.JieShouShouJi = HuiYuanInfo.Username;
                //duanXinInfo.NeiRong = "您好，您的E额宝帐户" + HuiYuanInfo.Username + "已充值成功，金额为：" + model.JinE + "元！E额宝帐户具有安全结算和余额增值的功能！欢迎使用！总机：400-6588-180【商旅e家】";

                //new EyouSoft.BLL.OtherStructure.BDuanXin().FaSong(duanXinInfo);
                Utils.RCWE(UtilsCommons.AjaxReturnJson(model.JinE.ToString("F2"), HuiYuanInfo.UserId, model.DingDanId));
            }
            else
            {
                Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "系统繁忙，稍后再试！", string.Empty));
            }
        }

        /// <summary>
        /// 获取openid
        /// </summary>
        void getOpentID()
        {
            string weixin_appid = Utils.GetConfigString("", "slejAppId").Trim();
            string weixin_secret = Utils.GetConfigString("", "slejAppSecret").Trim();






            string code = Utils.GetQueryStringValue("code");
            string state = Utils.GetQueryStringValue("state");

            if (string.IsNullOrEmpty(code))
            {
                string url = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + weixin_appid + "&redirect_uri=http://m.slej.cn/Member/ChongZhi.aspx&response_type=code&scope=snsapi_base&state=weidian_snsapi_base#wechat_redirect";
                Response.Redirect(url);
            }

            if (string.IsNullOrEmpty(state)) Utils.RCWE("异常请求");
            if (string.IsNullOrEmpty(code) && string.IsNullOrEmpty(state)) Utils.RCWE("异常请求");



            var access_token_info = get_weixin_oauth2_access_token_info(weixin_appid, weixin_secret, code);

            if (access_token_info == null) Utils.RCWE("get weixin_oauth2_access_token_info is null<br/>");

            openid = access_token_info.openid;

        }
        /// <summary>
        /// get weixin oauth2 access_token info
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        EyouSoft.Common.Utils.weixin_oauth2_access_token_info get_weixin_oauth2_access_token_info(string appid, string secret, string code)
        {
            string url = "https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code";
            url = string.Format(url, appid, secret, code);

            string cookies = string.Empty;
            var weixin_oauth2_access_token_json = EyouSoft.Toolkit.request.create(url, "", EyouSoft.Toolkit.Method.GET, "", ref cookies, false);
            if (string.IsNullOrEmpty(weixin_oauth2_access_token_json)) return null;

            var error = Newtonsoft.Json.JsonConvert.DeserializeObject<EyouSoft.Common.Utils.weixin_oauth2_error_info>(weixin_oauth2_access_token_json);

            if (error.errcode != 0) return null;

            var info = Newtonsoft.Json.JsonConvert.DeserializeObject<EyouSoft.Common.Utils.weixin_oauth2_access_token_info>(weixin_oauth2_access_token_json);

            return info;
        }



    }
}
