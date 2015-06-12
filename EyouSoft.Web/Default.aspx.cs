using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using EyouSoft.Web.MasterPage;
using EyouSoft.Common;
using EyouSoft.BLL.SystemStructure;
using EyouSoft.Model.SystemStructure;
using System.Web.Script.Serialization;
using EyouSoft.Common.Page;
using Linq.Bussiness;
using EyouSoft.Model.HotelStructure.WebModel;
using EyouSoft.Model.Enum;
using EyouSoft.Common;
using EyouSoft.BLL.HotelStructure;
using EyouSoft.IDAL.AccountStructure;

namespace EyouSoft.Web
{
    public partial class Defalut : HuiYuanPageBase
    {

        protected string MenPiaoShow = string.Empty;
        protected string GuoNeiShow = string.Empty;
        protected string ChuJingShow = string.Empty;
        protected string ZhouBianShow = string.Empty;
        protected string toplist = string.Empty;
        protected string dianlist = string.Empty;//确认个数
        protected string youad1 = string.Empty;
        protected string youad2 = string.Empty;
        protected string youad3 = string.Empty;
        private const string NoImgSrc = "<img alt=\"暂无图片\" src=\"/images/NoPic.jpg\" />";
        /// <summary>
        /// 酒店星级html
        /// </summary>
        private const string HotelStarHtml = "<img alt=\"{0}\" title=\"{0}\" src=\"/images/star.gif\" />";
        protected void Page_Load(object sender, EventArgs e)
        {
            //设置返联盟推广cookie
            EyouSoft.Security.Membership.UserProvider.SheZhiFanLianMengTuiGuangCookie();
            //写返联盟推广来源
            new EyouSoft.BLL.OtherStructure.BTuiGuang().TuiGuangLaiYuan_C();

            if (!Page.IsPostBack)
            {
                (Master as Front).HeadMenuIndex = 1; InitPage();
            }
            string website = HttpContext.Current.Request.Url.Host.ToLower();

            //string website = "8191.slej.cn";
            if (website.IndexOf("slej.cn") > -1 && website.IndexOf("www") < 0)
            {
                EyouSoft.Model.AccountStructure.MSellers seller = new BSellers().GetMSellersByWebSite(website);
                if (seller != null)
                {
                    if (seller.NavNum == NavNum.代理商导航)
                    {
                        DaiLi.Visible = true;
                        MainD.Visible = false;
                    }
                }
            }
            MainDefault1.CurrentUser = CurrentUser;
            DaiLiDefault1.CurrentUser = CurrentUser;
        }

        /// <summary>
        /// 初始化页面
        /// </summary>
        private void InitPage()
        {
            InitGongGao();
            InitZiXun();
            InitAd();

        }
        /// <summary>
        /// 绑定页面广告
        /// </summary>
        private void InitAd()
        {
            EyouSoft.BLL.OtherStructure.BSysAdv bll = new EyouSoft.BLL.OtherStructure.BSysAdv();
            //右侧第一块广告
            var top1 = bll.GetList(1, (EyouSoft.Model.Enum.AdvArea)2);
            if (top1 != null && top1.Count > 0)
            {
                youad1 = "<a target='_blank' href='" + top1[0].AdvLink + "'><img src='" + top1[0].ImgPath + "'></a>";
            }
            var top2 = bll.GetList(1, (EyouSoft.Model.Enum.AdvArea)3);
            if (top2 != null && top2.Count > 0)
            {
                youad2 = "<a target='_blank' href='" + top2[0].AdvLink + "'><img src='" + top2[0].ImgPath + "'></a>";
            }
            var top3 = bll.GetList(1, (EyouSoft.Model.Enum.AdvArea)4);
            if (top3 != null && top3.Count > 0)
            {
                youad3 = "<a target='_blank' href='" + top3[0].AdvLink + "'><img src='" + top3[0].ImgPath + "'></a>";
            }

        }
        /// <summary>
        /// 公告初始化
        /// </summary>
        private void InitGongGao()
        {
            var list = new BLL.OtherStructure.BTravelArticle().GetTopList(10, (int)Model.Enum.ArticleType.公告);
            if (list != null && list.Count > 0)
            {
                rpt_GongGao.DataSource = list;
                rpt_GongGao.DataBind();
            }
        }
        /// <summary>
        /// 旅游咨询初始化
        /// </summary>
        private void InitZiXun()
        {
            var list = new BLL.OtherStructure.BTravelArticle().GetTopList(10, (int)Model.Enum.ArticleType.旅游资讯);
            if (list != null && list.Count > 0)
            {
                this.rpt_Article.DataSource = list;
                this.rpt_Article.DataBind();
            }
        }
        
    }
}
