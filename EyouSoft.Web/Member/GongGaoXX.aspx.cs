using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.Member
{
    public partial class GongGaoXX : EyouSoft.Common.Page.HuiYuanPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                lblResource.Text = model.Source;
                lblTime.Text = model.IssueTime.ToString("yyyy-MM-dd HH:mm");
                lblInfo.Text = model.ArticleText;
                if (!string.IsNullOrEmpty(model.ImgPath)) litFile.Text = string.Format("<a target=\"_blank\" href=\"{0}\"><img width=\"800\"   src=\"{0}\" /></a>", model.ImgPath);

            }

        }
    }
}
