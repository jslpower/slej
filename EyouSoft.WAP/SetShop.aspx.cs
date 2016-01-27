using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Common.page;
using EyouSoft.Model.Enum;

namespace EyouSoft.WAP
{
    public partial class SetShop : HuiYuanWapPageBase
    {
        protected string CardNum;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("cardid")))
            {
                CardNum = Utils.GetQueryStringValue("cardid");
            }
            //string type = Utils.GetQueryStringValue("type").Trim();

            //if (type == "update")
            //{
            //    Response.Clear();
            //    Response.Write(UpdateUserInfo());
            //    Response.End();
            //}
        }
        //private string UpdateUserInfo()
        //{
        //    string msg = "";
        //    EyouSoft.BLL.MemberStructure.BMember membll = new EyouSoft.BLL.MemberStructure.BMember();
        //    int count = membll.UpdateShowOrHidden(ShowHidden.隐藏, (EyouSoft.Model.Enum.NavNum)Utils.GetInt(Utils.GetFormValue("ShopType")), HuiYuanInfo.UserId);
        //    if (count > 0)
        //    {
        //        msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "1", "修改成功！");
        //    }
        //    else
        //    {
        //        msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "0", "修改失败！");
        //    }
        //    return msg;
        //}
    }
}
