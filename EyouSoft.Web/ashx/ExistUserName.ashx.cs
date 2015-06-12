using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

namespace EyouSoft.Web.ashx
{
    /// <summary>
    /// 验证注册用户名是否存在
    /// 创建人：刘飞
    /// 时间：2013-3-21
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ExistUserName : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string strUserName = EyouSoft.Common.Utils.InputText(context.Request.QueryString["UserName"]);
            string strUserId = EyouSoft.Common.Utils.InputText(context.Request.QueryString["UserId"]);
            context.Response.Write(IsExist(strUserName, strUserId));
            context.Response.End();
        }

        /// <summary>
        /// 检测用户名是否存在
        /// </summary>
        private bool IsExist(string UserName, string UserId)
        {
            bool isTrue = false;
            EyouSoft.BLL.OtherStructure.BMember bll = new EyouSoft.BLL.OtherStructure.BMember();
            isTrue = bll.ExistsUserName(UserName, UserId);
            return isTrue;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
