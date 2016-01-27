using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.page;
using EyouSoft.Common;

namespace EyouSoft.WAP.CommonPage
{
    public partial class ajaxChongZhi : HuiYuanWapPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetChongZhiList();
        }
        /// <summary>
        /// 获取充值记录
        /// </summary>
        public void GetChongZhiList()
        {
            var chaXun = new EyouSoft.Model.OtherStructure.MChongZhiChaXunInfo();
            chaXun.HuiYuanId = HuiYuanInfo.UserId;
            int RecordCount = 0;
            int pageindex = Utils.GetInt(Utils.GetQueryStringValue("pageindex"));
            var items = new EyouSoft.BLL.OtherStructure.BChongZhi().GetChongZhis(20, pageindex, ref RecordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                if (RecordCount > (pageindex - 1) * 20)
                {
                    Repeater1.DataSource = items;
                }
                else
                {
                    Repeater1.DataSource = null;
                }
                Repeater1.DataBind();
            }
        }
    }
}
