using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.BLL.OtherStructure;
using EyouSoft.Model.WeiXin;
using EyouSoft.IDAL.AccountStructure;
using EyouSoft.Common.Page;
using EyouSoft.Model.Enum;
using System.Text.RegularExpressions;

namespace EyouSoft.Web.WebMaster.YouJi
{
    public partial class chakan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            initInfo();
        }


        /// <summary>
        /// 初始化页面
        /// </summary>
        void initInfo()
        {
            string id = Utils.GetQueryStringValue("youjid");

            BYouJi bll = new BYouJi();
            var model = bll.GetModel(id);


            if (model != null)
            {
                lblTitle.Text = model.YouJiTitle;
                if (!string.IsNullOrEmpty(model.ShiPinLink))
                {
                    ltrLink.Text = string.Format("<a  href=\"{0}\" >{1}</a>", model.ShiPinLink, model.ShiPinLink);
                }
                if (model.YouJiContent != null && model.YouJiContent.Count > 0)
                {
                    rptlist.DataSource = model.YouJiContent;
                    rptlist.DataBind();
                }


            }
        }
    }
}
