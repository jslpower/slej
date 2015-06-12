using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web
{
    public partial class biangeng : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            initPage();
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        void initPage()
        {
            var model = new EyouSoft.BLL.XianLuStructure.BXianLu().GetInfo(Utils.GetQueryStringValue("id"));
            if (model == null) Utils.RCWE("暂无数据");
            if (model.TourTraffice != null && model.TourTraffice.Count > 0)
            {
                rptlist.DataSource = model.TourTraffice;
                rptlist.DataBind();
            }
        }
    }
}
