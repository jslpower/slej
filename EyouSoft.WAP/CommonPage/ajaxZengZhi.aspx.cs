using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.OtherStructure;
using EyouSoft.BLL.OtherStructure;
using Common.page;

namespace EyouSoft.WAP.CommonPage
{
    public partial class ajaxZengZhi : HuiYuanWapPageBase
    {
        #region 分页参数
        protected int pageIndex = 1, recordCount = 0, pageSize = 10;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
                InitPage();
        }

        protected void InitPage()
        {
            int recordCount = 0;
            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("pageindex"));

            IList<MPayMentsInfo> list = new BPayMents().GetList(pageSize, pageIndex, ref recordCount, new MPaySearch() { MemID = HuiYuanInfo.UserId });

            if (list != null && list.Count > 0)
            {
                if (recordCount > (pageIndex - 1) * 10)
                {
                    Repeater1.DataSource = list;
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
