using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Common.page;

namespace EyouSoft.WAP.Member
{
    public partial class GongGaoXX : HuiYuanWapPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "公告详情";
            if (!IsPostBack)
            {
                initPage();
            }
        }
        void initPage()
        {
            EyouSoft.Model.MTravelArticle model = new EyouSoft.BLL.OtherStructure.BTravelArticle().GetModel(Utils.GetQueryStringValue("id"));
            if (model != null)
            {
                lblTitle.Text = model.ArticleTitle;
                lblTime.Text = model.IssueTime.ToString("yyyy-MM-dd");
                lblInfo.Text = model.ArticleText.Replace("<img src=\"","<img src=\"http://www.slej.cn");
                if (!string.IsNullOrEmpty(model.ImgPath))
                {
                    PicHtml.Text ="<div class=\"jq_cont\"><div class=\"cent\"><img src=\"http://www.slej.cn"+model.ImgPath+"\"></div></div>";
                }
            }

        }
    }
}
