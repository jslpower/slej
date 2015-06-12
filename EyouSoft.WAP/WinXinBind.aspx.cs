using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.IDAL.MemberStructure;

namespace EyouSoft.WAP
{
    public partial class WinXinBind : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("save") == "save") BaoCun();
        }
        /// <summary>
        /// 保存
        /// </summary>
        void BaoCun()
        {

            EyouSoft.Model.WeiXin.MWinXin weixinModel = new EyouSoft.Model.WeiXin.MWinXin();

            string userName = Utils.GetFormValue("u-Name");
            string userPwd = Utils.GetFormValue("u-Pwd");

            var member = new BMember2().GetByAccount(userName);
            if (member.UserType != EyouSoft.Model.Enum.MemberTypes.代理 && member.UserType != EyouSoft.Model.Enum.MemberTypes.员工) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "请升级代理后再操作绑定"));
            if (member.PassWord != userPwd) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "密码错误"));
            var daili = new EyouSoft.IDAL.AccountStructure.BSellers().Get(member.MemberID);
            if (daili != null)
            {
                weixinModel.AccountNum = userName;
                weixinModel.OpenID = Utils.GetFormValue("openid");
                weixinModel.MemberID = member.MemberID;
                weixinModel.MemberName = member.MemberName;
                weixinModel.ShopUrl = "http://m." + daili.Website;
                weixinModel.BindTime = DateTime.Now;
                weixinModel.NickName = "";
                int result = new EyouSoft.BLL.WeiXin.BWeiXin().Insert(weixinModel);
                if (result != 1) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "添加失败"));
                Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "添加成功", weixinModel.ShopUrl));
            }


        }
    }
}
