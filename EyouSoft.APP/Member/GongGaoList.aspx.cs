using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.page;
using EyouSoft.Common;

namespace EyouSoft.WAP.Member
{
    public partial class GongGaoList : HuiYuanWapPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "会员公告";
            PageInit();
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        void PageInit()
        {
            int recordCount = 0;
            
            IList<EyouSoft.Model.MTravelArticle> list = new EyouSoft.BLL.OtherStructure.BTravelArticle().GetList(12, 1, ref recordCount, new EyouSoft.Model.MTravelArticleCX() { ClassId = (int)EyouSoft.Model.Enum.ArticleType.会员公告, JiBie = (EyouSoft.Model.Enum.GongGaoJiBie)((int)HuiYuanInfo.UserType - 1) }, null);

            if (list != null && list.Count > 0)
            {
                XianShi.Text = "";
                rptlist.DataSource = list;
                rptlist.DataBind();

            }
            else
            {
                XianShi.Text = "暂无数据！";
            }
        }
    }
}
