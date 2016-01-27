using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster
{
    public partial class MyTGGysList : EyouSoft.Common.Page.WebmasterPageBase
    {
        #region 分页参数
        protected int pageIndex = 1;
        protected int recordCount;
        protected int pageSize = 20;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            initList();
        }
        /// <summary>
        /// 初始化列表
        /// </summary>
        void initList()
        {
            pageIndex = UtilsCommons.GetPagingIndex();
            string DaiLiId = UserInfo.GysId;
            MTeYueSer model = new MTeYueSer();
            model.CompanyName = Utils.GetQueryStringValue("CompanyName");
            model.MemberName = Utils.GetQueryStringValue("MemberName");
            model.Mobile = Utils.GetQueryStringValue("Mobile");
            model.WebsiteName = Utils.GetQueryStringValue("WebsiteName");
            //model.IsMyDaiLi = 0;
            //if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("IsMyDaiLi")))
            //{
            //    model.IsMyDaiLi = Convert.ToInt32(Utils.GetQueryStringValue("IsMyDaiLi"));
            //}
            var list = new EyouSoft.BLL.MemberStructure.BMember().GetMyTGGYS(DaiLiId, pageIndex, pageSize, model);
            recordCount = new EyouSoft.BLL.MemberStructure.BMember().GetMyTGGYSNum(DaiLiId, model);
            if (list != null && list.Count > 0)
            {
                rptList.DataSource = list;
                rptList.DataBind();
                BindExportPage();
            }
        }


        #region 绑定分页控件
        /// <summary>
        /// 绑定分页控件
        /// </summary>
        protected void BindExportPage()
        {
            this.ExporPageInfoSelect1.intPageSize = pageSize;
            this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
            this.ExporPageInfoSelect1.intRecordCount = recordCount;
        }
        #endregion
    }
}
