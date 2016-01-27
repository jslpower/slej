using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.page;
using EyouSoft.Model.WeiXin;
using EyouSoft.Common;
using EyouSoft.BLL.OtherStructure;

namespace EyouSoft.Web.Member
{
    public partial class FenXiang : EyouSoft.Common.Page.HuiYuanPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            EyouSoft.Model.SSOStructure.MUserInfo m = null;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out m);
            if (!isLogin) Response.Redirect("/default.aspx");

            string dotype = Utils.GetQueryStringValue("dotype");
            if (dotype == "DelYouJi") DelYouJi();
            BindInte();
        }

        void BindInte()
        {
            MYouJiSer YouJiS = new MYouJiSer();
            YouJiS.HuiYuanId = HuiYuanInfo.UserId;
            //YouJiS.YouJiType = YouJiLeiXing.图文游记;
            int count = 0;
            var list = new BYouJi().GetList(10, 1, ref count, YouJiS);
            if (list != null && list.Count > 0)
            {
                rptlist.DataSource = list;
                rptlist.DataBind();
            }
            else
            {
                ltrNoMsg.Visible = true;
            }
        }
        /// <summary>
        /// 删除游记
        /// </summary>
        void DelYouJi()
        {
            string YouJiId = Utils.GetQueryStringValue("youjid");
            if (string.IsNullOrEmpty(YouJiId)) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "请选择需要删除的游记"));

            bool bllRetCode = new BYouJi().Delete(YouJiId);

            if (bllRetCode)
            {
                Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            }
            else
            {
                Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败"));
            }

        }
    }
}
