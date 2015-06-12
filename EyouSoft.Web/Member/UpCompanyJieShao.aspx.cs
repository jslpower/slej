using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.page;
using EyouSoft.Common;

namespace EyouSoft.Web.Member
{
    public partial class UpCompanyJieShao : ClientModelViewPageBase<MMember2>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HuiYuanInfo.UserId == "Guest" || HuiYuanInfo.UserId == "")
            {
                Response.Redirect("/Default.aspx");
            }
            string type = Utils.GetQueryStringValue("type").Trim();

            if (type == "update")
            {
                Response.Clear();
                Response.Write(UpdateUserInfo());
                Response.End();
            }
            else
            {
                txtContent.Text = new EyouSoft.BLL.MemberStructure.BMember().GetContent(HuiYuanInfo.UserId);
            }
        }
        private string UpdateUserInfo()
        {
            string msg = "";
            string CompanyCon = Utils.EditInputText(txtContent.Text);
            int num = new EyouSoft.BLL.MemberStructure.BMember().UpdateSellerContent(CompanyCon, HuiYuanInfo.UserId);
            if (num>0)
            {
                msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "1", "修改成功！");
            }
            else
            {
                msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "1", "修改失败！");
            }
            return msg;
        }
    }
}
