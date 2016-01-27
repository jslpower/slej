using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.BLL.OtherStructure;
using EyouSoft.Model.WeiXin;
using EyouSoft.IDAL.AccountStructure;
using EyouSoft.Common.Page;
using EyouSoft.Model.Enum;
using System.Text.RegularExpressions;

namespace EyouSoft.WAP.Member
{
    public partial class EJiaFenXiangInfo : WebPageBase
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
        protected string Xuke = "L-ZJ01409";
        protected string houtaiurl = "<a href=\"/HuiYuanCenter.aspx\">后台管理</a>";
        protected string youjiid = string.Empty;

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
            WapHeader1.isfx = true;
            initInfo();

            defaultInit();

            IList<string> weixin_jsApiList = new List<string>();
            weixin_jsApiList.Add("onMenuShareTimeline");
            weixin_jsApiList.Add("onMenuShareAppMessage");
            weixin_jsApiList.Add("onMenuShareQQ");
            var weixing_config_info = Utils.get_weixin_jsapi_config_info(weixin_jsApiList);
            weixin_jsapi_config = Newtonsoft.Json.JsonConvert.SerializeObject(weixing_config_info);
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        void initInfo()
        {
            string id = Utils.GetQueryStringValue("ID");
            youjiid = id;


            BYouJi bll = new BYouJi();
            var model = bll.GetModel(id);


            if (model != null)
            {
                lblTitle.Text = model.YouJiTitle;
                if (!string.IsNullOrEmpty(model.ShiPinLink))
                {
                    ltrLink.Text = string.Format("<a  href=\"{0}\" >{1}</a>", model.ShiPinLink, model.ShiPinLink);
                }
                if (model.YouJiContent != null && model.YouJiContent.Count > 0)
                {
                    rptlist.DataSource = model.YouJiContent;
                    rptlist.DataBind();
                }

                var prevModel = bll.GetPrevModel(model);
                if (prevModel != null)
                {
                    ltrPrev.Text = string.Format(" 上一篇:<a href=\"EJiaFenXiangInfo.aspx?id={0}\">{1}</a>", prevModel.YouJiId, prevModel.YouJiTitle);
                }
                var nextModel = bll.GetNextModel(model);
                if (nextModel != null)
                {
                    ltrNext.Text = string.Format(" 下一篇:<a href=\"EJiaFenXiangInfo.aspx?id={0}\">{1}</a>", nextModel.YouJiId, nextModel.YouJiTitle);
                }
                #region 设置微信分享链接
                //设置图片链接
                if (model.YouJiContent.Any())
                {

                    var setimg = string.Empty;

                    MatchCollection matches = regImg.Matches(model.YouJiContent[0].XingChengContent);
                    string[] sUrlList = new string[matches.Count];
                    foreach (Match match in matches)
                    {
                        setimg = match.Groups["imgUrl"].Value;
                        break;
                    }


                    if (!string.IsNullOrEmpty(model.YouJiContent[0].ImgFile))
                    {

                        WapHeader1.FenXiangTuPianFilepath = "http://" + Request.Url.Host + TuPian.F1(model.YouJiContent[0].ImgFile, 210, 70, model.YouJiId);
                    }
                    else if (!string.IsNullOrEmpty(setimg))
                    {
                        WapHeader1.FenXiangTuPianFilepath = "http://" + Request.Url.Host + TuPian.F1(setimg, 210, 70, model.YouJiId);
                    }
                    else
                    {
                        WapHeader1.FenXiangTuPianFilepath = "http://" + Request.Url.Host + "/images/NoPic.jpg";
                    }
                }
                WapHeader1.FenXiangBiaoTi = model.YouJiTitle;

                #endregion
            }


            WapHeader1.FenXiangLianJie = Utils.redirectUrl(HttpContext.Current.Request.Url.ToString().Replace("p.", "m."));

        }

        /// <summary>
        /// 返回图片链接
        /// </summary>
        /// <param name="objStr"></param>
        /// <returns></returns>
        protected string getImgSrc(object objStr, string youjiid)
        {
            string defaultImg = "";
            if (objStr == null) return defaultImg;
            string src = objStr.ToString();
            if (string.IsNullOrEmpty(src)) return defaultImg;
            return string.Format("<img src=\"{0}\">", TuPian.F1(src, 100, 80, youjiid));
        }




        #region 首页
        void defaultInit()
        {
            if (isLogin)
            {
                houtaiurl = "<a href=\"/Member/UserCenter.aspx\">后台管理</a>";
            }
            thisurl = "http://" + HttpContext.Current.Request.Url.Host.ToLower();
            if (isfenxiao)
            {
                string website = HttpContext.Current.Request.Url.Host.ToLower().Replace("m.", "");
                //string website = "m.1234.slej.cn".Replace("m.", "");
                if (website.IndexOf("slej") > 1)
                {
                    PCUrl = "http://" + website + "?source=m";
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

        }
        /// <summary>
        /// 根据分销商的website获取分销商权限
        /// </summary>
        /// <param name="website"></param>
        void GetQX(string website)
        {
            BSellers bsells = new BSellers();
            EyouSoft.Model.AccountStructure.MSellers seller = new EyouSoft.Model.AccountStructure.MSellers();
            seller = bsells.GetMSellersByWebSite(website);
            if (seller != null)
            {
                companyName = seller.CompanyName;
                MiaoShuJ = seller.CompanyContent;
                if (!string.IsNullOrEmpty(seller.CompanyName))
                {
                    BanQuan = seller.CompanyName;
                }
                if (!string.IsNullOrEmpty(seller.XuKeZhengHao))
                {
                    Xuke = seller.XuKeZhengHao;
                }
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
                Response.Redirect("http://p.slej.cn");
                Response.End();
            }
        }
        #endregion
    }
}
