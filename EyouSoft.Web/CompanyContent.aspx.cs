using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.IDAL.AccountStructure;

namespace EyouSoft.Web
{
    public partial class CompanyContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string website = HttpContext.Current.Request.Url.Host.ToLower();
            if (website.IndexOf("slej.cn") > -1 && website.IndexOf("www") < 0)
            {
                BSellers bsells = new BSellers();
                EyouSoft.Model.AccountStructure.MSellers seller = new EyouSoft.Model.AccountStructure.MSellers();
                seller = bsells.GetMSellersByWebSite(website);
                if (seller != null)
                {
                    WebSite.Text = seller.CompanyName;
                    string MemberId = seller.MemberID;
                    if (!string.IsNullOrEmpty(MemberId))
                    {
                        CompanyJieShao.Text = new EyouSoft.BLL.MemberStructure.BMember().GetContent(MemberId);
                    }
                }

            }

        }
    }
}
