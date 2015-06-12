using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.BLL.OtherStructure;
using EyouSoft.Model;
using EyouSoft.Common;

namespace EyouSoft.Web
{
    public partial class ZiXun : System.Web.UI.Page
    {
        #region 分页参数
        public int pageIndex = 1, recordCount=0, pageSize = 40;
        public string ClassName = "旅游资讯";
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            int type = Convert.ToInt32(Request.QueryString["type"]);
            if (!IsPostBack)
            {
                BindZiXun(type);
            }
        }
        public void BindZiXun(int type)
        {
            if (type == 0)
            {
                ClassName = "最新公告";
            }
            pageIndex = UtilsCommons.GetPagingIndex();
            IList<EyouSoft.Model.MTravelArticle> list = new EyouSoft.BLL.OtherStructure.BTravelArticle().GetList(pageSize, pageIndex, ref recordCount, new EyouSoft.Model.MTravelArticleCX() { ClassId = type }, null);
            if (list != null && list.Count > 0)
            {
                ZiXunList.DataSource = list;
                ZiXunList.DataBind();

            }
        }
    }
}
