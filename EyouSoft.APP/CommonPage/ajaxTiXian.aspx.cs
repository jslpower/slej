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
    public partial class ajaxTiXian : HuiYuanWapPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetTiXianList();
        }
        /// <summary>
        /// 获取充值记录
        /// </summary>
        public void GetTiXianList()
        {
            EyouSoft.Model.MoneyStructure.MApplyTiXianSer Model = new EyouSoft.Model.MoneyStructure.MApplyTiXianSer();
            Model.UserId = HuiYuanInfo.UserId;
            int RecordCount = 0;
            int pageindex = Utils.GetInt(Utils.GetQueryStringValue("pageindex"));
            var items = new EyouSoft.BLL.MoneyStructure.BApplyTiXian().GetList(20, pageindex, "", ref RecordCount, Model);

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
