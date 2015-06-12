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
    public class WebPageBase : System.Web.UI.Page
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

            AddMetaContentType();
            AddMetaIE8Compatible();

            var model = new BLL.OtherStructure.BKV().GetCompanySetting();
            if (model != null)
            {
                AddMetaTag("description", model.Description);
                AddMetaTag("keywords", model.Keywords);
            }

            //add Head Cache Contorl
            //AddSiteIcon();
        }

        #endregion

        #region protected members
        /// <summary>
        /// response to xls
        /// </summary>
        /// <param name="s">要写入 HTTP 输出流的字符串。</param>
        protected void ResponseToXls(string s)
        {
            ResponseToXls(s, System.Text.Encoding.Default);
        }

        /// <summary>
        /// response to xls
        /// </summary>
        /// <param name="s">要写入 HTTP 输出流的字符串。</param>
        /// <param name="encoding">encoding</param>
        protected void ResponseToXls(string s, Encoding encoding)
        {
            string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            ResponseToXls(s, encoding, filename);
        }

        /// <summary>
        /// response to xls
        /// </summary>
        /// <param name="s">要写入 HTTP 输出流的字符串。</param>
        /// <param name="encoding">encoding</param>
        /// <param name="filename">filename</param>
        protected void ResponseToXls(string s, Encoding encoding, string filename)
        {
            if (string.IsNullOrEmpty(filename)) filename = DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            if (System.IO.Path.GetExtension(filename).ToLower() != ".xls") filename += ".xls";

            Response.Clear();
            Response.ContentEncoding = encoding;
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
            Response.ContentType = "application/ms-excel";
            Response.Write(s.ToString());
            Response.End();
        }


        /// <summary>
        /// Response.Clear();Response.Write(s);Response.End();
        /// </summary>
        /// <param name="s">输出字符串</param>
        protected void RCWE(string s)
        {
            Response.Clear();
            Response.Write(s);
            Response.End();
        }

        /// <summary>
        /// register alert script
        /// </summary>
        /// <param name="s">msg</param>
        protected void RegisterAlertScript(string s)
        {
            this.RegisterScript(string.Format("alert('{0}');", s));
        }

        /// <summary>
        /// register alert and redirect script
        /// </summary>
        /// <param name="s"></param>
        /// <param name="url">IsNullOrEmpty(url)=true page reload</param>
        protected void RegisterAlertAndRedirectScript(string s, string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                this.RegisterScript(string.Format("alert('{0}');window.location.href='{1}';", s, url));
            }
            else
            {
                this.RegisterScript(string.Format("alert('{0}');window.location.href=window.location.href;", s));
            }
        }

        /// <summary>
        /// register alert and reload script
        /// </summary>
        /// <param name="s"></param>
        protected void RegisterAlertAndReloadScript(string s)
        {
            RegisterAlertAndRedirectScript(s, null);
        }

        /// <summary>
        /// register scripts
        /// </summary>
        /// <param name="script"></param>
        protected void RegisterScript(string script)
        {
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), script, true);
        }

        /// <summary>
        /// 添加Meta 标记到页面头部
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        protected virtual void AddMetaTag(string name, string value)
        {
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(value))
            {
                return;
            }

            var meta = new HtmlMeta();
            meta.Name = name;
            meta.Content = value;
            if (Page.Header != null)
            {
                Page.Header.Controls.Add(meta);
            }
        }

        /// <summary>
        /// 添加Content-Type Meta标记到页面头部
        /// </summary>
        protected virtual void AddMetaContentType()
        {
            var meta = new HtmlMeta();
            //meta.HttpEquiv = "content-type";
            //meta.Content = Response.ContentType + "; charset=" + Response.ContentEncoding.HeaderName;
            meta.Attributes["charset"] = Response.ContentEncoding.HeaderName;
            if (Page.Header != null)
            {
                Page.Header.Controls.Add(meta);
            }
        }
        /// <summary>
        /// 添加IE8兼容IE7 Meta Tag.
        /// </summary>
        protected virtual void AddMetaIE8Compatible()
        {
            var meta = new HtmlMeta();
            meta.HttpEquiv = "X-UA-Compatible";
            meta.Content = "IE=EmulateIE7";
            if (Page.Header != null)
            {
                Page.Header.Controls.Add(meta);
            }
        }
        /// <summary>
        /// 添加网站favicon
        /// </summary>
        protected virtual void AddSiteIcon()
        {
            AddGenericLink("image/x-icon", "icon", "/images/favicon.ico");
            AddGenericLink("image/x-icon", "shortcut icon", "/images/favicon.ico");
        }

        /// <summary>
        /// 添加link 标记到页面头部
        /// </summary>
        /// <summary>
        /// Adds the generic link to the header.
        /// </summary>
        protected virtual void AddGenericLink(string type, string relation, string href)
        {
            var link = new HtmlLink();
            link.Attributes["type"] = type;
            link.Attributes["rel"] = relation;
            link.Attributes["href"] = href;
            if (Page.Header != null)
            {
                Page.Header.Controls.Add(link);
            }
        }

        /// <summary>
        /// 添加Javascript外部文件到html页面
        /// </summary>
        /// <param name="url">文件URL</param>
        /// <param name="placeInBottom">是否添加在html代码底部</param>
        /// <param name="addDeferAttribute">是否添加defer属性</param>
        public virtual void AddJavaScriptInclude(string url, bool placeInBottom, bool addDeferAttribute)
        {
            if (placeInBottom)
            {
                string script = "<script type=\"text/javascript\"" + (addDeferAttribute ? " defer=\"defer\"" : string.Empty) + " src=\"" + url + "\"></script>";
                ClientScript.RegisterStartupScript(GetType(), url.GetHashCode().ToString(), script);
            }
            else
            {
                var script = new HtmlGenericControl("script");
                script.Attributes["type"] = "text/javascript";
                script.Attributes["src"] = url;
                if (addDeferAttribute)
                {
                    script.Attributes["defer"] = "defer";
                }

                Page.Header.Controls.Add(script);
            }
        }

        /// <summary>
        /// 添加css外部文件到html页面
        /// </summary>
        /// <param name="url">The relative URL.</param>
        public virtual void AddStylesheetInclude(string url)
        {
            AddGenericLink("text/css", "stylesheet", url);
        }

        /// <summary>
        /// 转换成货币字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string ToMoneyString(object obj)
        {
            return UtilsCommons.GetMoneyString(obj, "zh-cn");
        }

        /// <summary>
        /// 转换成日期字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string ToDateTimeString(object obj)
        {
            return UtilsCommons.GetDateString(obj, "yyyy-MM-dd");
        }

        #endregion
    }
}
