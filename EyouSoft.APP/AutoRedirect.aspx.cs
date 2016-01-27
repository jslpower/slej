using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Model.SSOStructure;
using EyouSoft.IDAL.MemberStructure;
using EyouSoft.IDAL.AccountStructure;

namespace EyouSoft.WebApp
{
    public partial class AutoRedirect : System.Web.UI.Page
    {
        const string DeafaultUri = "http://p.slej.cn";
        protected void Page_Load(object sender, EventArgs e)
        {


            MUserInfo loginModel;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out loginModel);

            if (isLogin)
            {
                var member = new EyouSoft.IDAL.MemberStructure.BMember2().Get(loginModel.UserId);
                if (member == null) Response.Redirect(DeafaultUri);


                switch (loginModel.UserType)
                {
                    case EyouSoft.Model.Enum.MemberTypes.未注册用户:
                    case EyouSoft.Model.Enum.MemberTypes.普通会员:
                    case EyouSoft.Model.Enum.MemberTypes.贵宾会员:
                        Response.Redirect(DeafaultUri);
                        break;
                    case EyouSoft.Model.Enum.MemberTypes.免费代理:
                    case EyouSoft.Model.Enum.MemberTypes.代理:
                    case EyouSoft.Model.Enum.MemberTypes.员工:
                        Response.Redirect(setAutoUri(member));
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// 获取代理商、员工APP域名
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        string setAutoUri(MMember2 userModel)
        {
            var retUri = string.Empty;
            var msell = new BSellers().Get(userModel.MemberID);
            retUri = string.Format("p.{0}", msell.Website.Trim());
            return retUri;




        }

    }
}
