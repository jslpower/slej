using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.IDAL.AccountStructure;

namespace EyouSoft.Web.WebMaster.MemberCenter
{
    public partial class CompanyContent : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string MemberId = Utils.GetQueryStringValue("MemberId");
            if (!string.IsNullOrEmpty(MemberId))
            {
                txtContent.Text = new EyouSoft.BLL.MemberStructure.BMember().GetContent(MemberId);
            }
            else
            {
                Response.Redirect("/WebMaster/MemberCenter/MemberList.aspx");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string MemberId = Utils.GetQueryStringValue("MemberId");
            string CompanyCon = Utils.EditInputText(Request.Form["txtContent"]);
            int num = new EyouSoft.BLL.MemberStructure.BMember().UpdateSellerContent(CompanyCon, MemberId);
            if (num > 0)
            {
                EyouSoft.Common.Function.MessageBox.ShowAndRedirect(
                this, string.Format("保存成功！"), "/WebMaster/MemberCenter/MemberList.aspx");
            }
            else
            {
                EyouSoft.Common.Function.MessageBox.ShowAndRedirect(
                this, string.Format("保存失败！"), "");
            }
        }
    }
}
