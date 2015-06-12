using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.HtmlControls;
using EyouSoft.IDAL.AccountStructure;

namespace EyouSoft.Common.Page
{
    /// <summary>
    /// web page base
    /// </summary>
    public class ControlPageBase : System.Web.UI.UserControl
    {
        #region attributes
        public bool isDisplay = true;
        public bool isfenxiao = false;
        protected EyouSoft.Model.SSOStructure.MUserInfo m = null;
        public bool isLogin = false;
        public string AgencyId = "";
        #endregion

        #region private members

        #endregion

        #region protected override members
        /// <summary>
        /// OnInit
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        /// <summary>
        /// OnPreRender
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out m);

            //是否分销
            string requesturl = System.Web.HttpContext.Current.Request.Url.Host.ToLower();
            if (requesturl.IndexOf("m.") > -1)
            {
                //m.1234.slej.cn   m.slej.cn
                requesturl = requesturl.Replace("m.", "");
                if (requesturl.IndexOf("slej.cn") > 1)
                {
                    isfenxiao = true;
                }
            }
            else
            {
                if (requesturl.IndexOf("slej.cn") > -1 && requesturl.IndexOf("www") < 0) isfenxiao = true;
            }
            if (isfenxiao)
            {
                string url = System.Web.HttpContext.Current.Request.Url.Host.ToLower();
                if (url.IndexOf("m.") > -1)
                {
                    url = url.Replace("m.", "");
                }
                isDisplay = new EyouSoft.IDAL.AccountStructure.BSellers().WebSiteShowOrHidden(url) == EyouSoft.Model.Enum.ShowHidden.显示 ? true : false;
                BSellers bsells = new BSellers();
                EyouSoft.Model.AccountStructure.MSellers seller = new EyouSoft.Model.AccountStructure.MSellers();
                seller = bsells.GetMSellersByWebSite(url);
                if (seller != null)
                {
                    AgencyId = seller.ID;
                }
            }

            base.OnLoad(e);



            //add Head Cache Contorl
            //AddSiteIcon();
        }

        #endregion
    }
}
