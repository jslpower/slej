using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.Member
{
    public partial class GongGao : EyouSoft.Common.Page.HuiYuanPageBase
    {
        #region 分页参数
        protected int pageIndex = 1, recordCount, pageSize = 10;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            EyouSoft.Model.SSOStructure.MUserInfo m = null;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out m);
            if (!isLogin) Response.Redirect("/default.aspx");
            if (!IsPostBack)
            {
                PageInit();
            }
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        void PageInit()
        {

            pageIndex = UtilsCommons.GetPagingIndex();
            IList<EyouSoft.Model.MTravelArticle> list = new EyouSoft.BLL.OtherStructure.BTravelArticle().GetList(pageSize, pageIndex, ref recordCount, new EyouSoft.Model.MTravelArticleCX() { ClassId = (int)EyouSoft.Model.Enum.ArticleType.会员公告, JiBie = (EyouSoft.Model.Enum.GongGaoJiBie)((int)HuiYuanInfo.UserType-1)  }, null);

            UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
            string pagingScript = "pagingConfig.pageSize={0};pagingConfig.pageIndex={1};pagingConfig.recordCount={2};";
            if (list != null && list.Count > 0)
            {
                rptlist.DataSource = list;
                rptlist.DataBind();

            }
            RegisterScript(string.Format(pagingScript, pageSize, pageIndex, recordCount));


        }
    }
}
