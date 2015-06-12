using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.IDAL.AccountStructure;
using EyouSoft.Model.Enum;
using EyouSoft.Common;

namespace EyouSoft.WAP
{
    public partial class _default : WebPageBase
    {
        protected string companyName = "";
        public string uqq = "";
        public string slqq = "";
        public string utel = "";
        public string slweixin = "";
        public string uweixin = "";
        public string slname = "";
        protected string uTouXiang = "/images/touxian.png";
        protected string slTouXiang = "/images/touxian.png";
        public string PCUrl = "http://www.slej.cn?source=m";
        protected string thisurl = "";
        protected string TelNum = "4006588180";
        protected string BanQuan = "杭州金奥国际旅行社有限公司";
        protected string MiaoShuJ = "";
        protected string houtaiurl = "<a href=\"/HuiYuanCenter.aspx\">后台管理</a>";
        #region 微信分享
        protected string weixin_jsapi_config = string.Empty
                                    , FenXiangBiaoTi = string.Empty
                                    , FenXiangMiaoShu = string.Empty
                                    , FenXiangTuPianFilepath = string.Empty
                                    , FenXiangLianJie = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (isLogin)
            {
                houtaiurl = "<a href=\"/Member/UserCenter.aspx\">后台管理</a>";
            }
            thisurl = "http://"+HttpContext.Current.Request.Url.Host.ToLower();
            if (isfenxiao)
            {
                string website = HttpContext.Current.Request.Url.Host.ToLower().Replace("m.", "");
                //string website = "m.1234.slej.cn".Replace("m.", "");
                if (website.IndexOf("slej") > 1)
                {
                    PCUrl = "http://"+website + "?source=m";
                }
                GetQX(website);
                EyouSoft.Model.AccountStructure.MSellers seller = new BSellers().GetMSellersByWebSite(website);
                //EyouSoft.Model.AccountStructure.MSellers seller = new BSellers().GetMSellersByWebSite("8191.slej.cn");
                if (seller != null)
                {
                    var item = new EyouSoft.IDAL.MemberStructure.BMember2().Get(seller.MemberID);
                    if (item != null)
                    {
                        TelNum = item.Mobile;
                    }
                    if (seller.NavNum == NavNum.代理商导航)
                    {
                        DaiLi.Visible = true;
                        MainD.Visible = false;
                    }
                }
            }
            IList<string> weixin_jsApiList = new List<string>();
            weixin_jsApiList.Add("onMenuShareTimeline");
            weixin_jsApiList.Add("onMenuShareAppMessage");
            weixin_jsApiList.Add("onMenuShareQQ");
            var weixing_config_info = Utils.get_weixin_jsapi_config_info(weixin_jsApiList);
            weixin_jsapi_config = Newtonsoft.Json.JsonConvert.SerializeObject(weixing_config_info);
            FenXiangBiaoTi = BanQuan;
            FenXiangMiaoShu = Utils.GetText2(MiaoShuJ, 30, true);
            FenXiangTuPianFilepath = "http://" + Request.Url.Host + "/images/logo.png";
            FenXiangLianJie = HttpContext.Current.Request.Url.ToString();
        }
        /// <summary>
        /// 根据分销商的website获取分销商权限
        /// </summary>
        /// <param name="website"></param>
        public void GetQX(string website)
        {
            BSellers bsells = new BSellers();
            EyouSoft.Model.AccountStructure.MSellers seller = new EyouSoft.Model.AccountStructure.MSellers();
            seller = bsells.GetMSellersByWebSite(website);
            if (seller != null)
            {
                companyName = seller.CompanyName;
                MiaoShuJ = seller.CompanyContent;
                BanQuan = seller.CompanyName;
                MMember2 model = new EyouSoft.IDAL.MemberStructure.BMember2().Get(seller.MemberID);
                if (model != null)
                {
                    UName.Text = model.MemberName;
                    if (UName.Text.Length == 2)
                    {
                        UName.Text = model.MemberName;
                    }
                    if (!string.IsNullOrEmpty(model.Photo))
                    {
                        uTouXiang = EyouSoft.Common.TuPian.F1(model.Photo, 31, 31);
                    }
                    if (!string.IsNullOrEmpty(seller.JinAoPhoto))
                    {
                        slTouXiang = EyouSoft.Common.TuPian.F1(seller.JinAoPhoto, 31, 31);
                    }
                    utel = model.Contact;
                    UMoblie.Text = model.Mobile;
                    uweixin = model.WeiXin;
                    uqq = model.qq.Trim();
                    slqq = seller.JinAoQQ.Trim();
                    slname = seller.JinAoLXR;
                    SLMoblie.Text = seller.JinAoMobile;
                    SLTel.Text = seller.JinAoTel;
                    slweixin = seller.JinAoWeiXin;
                    //Label1.Text = seller.JinAoWeiXin;
                }
                if (seller.QuanXian.IndexOf("9") > -1)
                {
                    //isquanxian = 0;
                }
            }
            else
            {
                Response.Redirect("http://m.slej.cn");
                Response.End();
            }
        }
    }
}
