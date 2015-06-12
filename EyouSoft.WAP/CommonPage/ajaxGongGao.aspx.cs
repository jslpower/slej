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
    public partial class ajaxGongGao : HuiYuanWapPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int recordCount = 0;
            int pageindex = Utils.GetInt(Utils.GetQueryStringValue("pageindex"));
            IList<EyouSoft.Model.MTravelArticle> list = new EyouSoft.BLL.OtherStructure.BTravelArticle().GetList(12, pageindex, ref recordCount, new EyouSoft.Model.MTravelArticleCX() { ClassId = (int)EyouSoft.Model.Enum.ArticleType.会员公告, JiBie = (EyouSoft.Model.Enum.GongGaoJiBie)((int)HuiYuanInfo.UserType - 1) }, null);

            if (list != null && list.Count > 0)
            {
                if (recordCount > (pageindex - 1) * 12)
                {
                    rptlist.DataSource = list;
                }
                else
                {
                    rptlist.DataSource = null;
                }
                rptlist.DataBind();

            }
        }
    }
}
