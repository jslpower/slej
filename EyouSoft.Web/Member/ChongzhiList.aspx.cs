using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Common.page;
using EyouSoft.Common.Page;

namespace EyouSoft.Web.Member
{
    public partial class ChongzhiList : EyouSoft.Common.Page.HuiYuanPageBase
    {
        protected int PageSize = 20;
        protected int PageIndex = 1;
        protected int RecordCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HuiYuanInfo.UserId == "Guest" || string.IsNullOrEmpty(HuiYuanInfo.UserId))
            {
                Response.Redirect("/Default.aspx");
            }
            GetChongZhiList();
        }
        /// <summary>
        /// 获取充值记录
        /// </summary>
        public void GetChongZhiList()
        {
            var chaXun = new EyouSoft.Model.OtherStructure.MChongZhiChaXunInfo();
            chaXun.HuiYuanId = HuiYuanInfo.UserId;

            PageIndex = UtilsCommons.GetPagingIndex();
            var items = new EyouSoft.BLL.OtherStructure.BChongZhi().GetChongZhis(PageSize, PageIndex, ref RecordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                Repeater1.DataSource = items;
                Repeater1.DataBind();
            }
            else
            {
                Repeater1.DataSource = null;
                Repeater1.DataBind();
                XianShi.Text = "暂无充值记录!";
            }
        }
    }
}
