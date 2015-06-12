using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web
{
    public partial class ZiXunDetails : System.Web.UI.Page
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
                lblTime.Text = model.IssueTime.ToString("yyyy-MM-dd HH:mm");
                lblInfo.Text = model.ArticleText;
                if (!string.IsNullOrEmpty(model.ImgPath)) litFile.Text = string.Format("<img  src=\"{0}\" />", model.ImgPath);
                litzixuntype.Text = model.ClassName.ToString();
            }

        }
    }
}
