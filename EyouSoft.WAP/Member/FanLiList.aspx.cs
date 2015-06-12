using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Common.page;
using EyouSoft.Common.Page;

namespace EyouSoft.WAP.Member
{
    public partial class FanLiList : EyouSoft.Common.Page.HuiYuanPageBase
    {
        protected int PageSize = 20;
        protected int PageIndex = 1;
        protected int RecordCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "E额宝返利明细";
            GetFanLiList();
        }
        /// <summary>
        /// 获取返利列表
        /// </summary>
        public void GetFanLiList()
        {
            var chaXun = new EyouSoft.Model.OtherStructure.MDingDanFanLiChaXunInfo();
            chaXun.HuiYuanId = HuiYuanInfo.UserId;

            PageIndex = UtilsCommons.GetPagingIndex();
            var items = new EyouSoft.BLL.OtherStructure.BDingDanFanLi().GetDingDanFanLis(20, PageIndex, ref RecordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                Repeater1.DataSource = items;
                Repeater1.DataBind();
            }
            else
            {
                Repeater1.DataSource = null;
                Repeater1.DataBind();
                XianShi.Text = "暂无返利记录!";
            }
        }
    }
}
