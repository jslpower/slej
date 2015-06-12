using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster.MemberCenter
{
    /// <summary>
    /// 会员粉丝信息
    /// </summary>
    public partial class FenSi : EyouSoft.Common.Page.WebmasterPageBase
    {
        #region attributes
        protected int PageSize = 20;
        protected int PageIndex = 1;
        /// <summary>
        /// 会员编号
        /// </summary>
        protected string HuiYuanId = string.Empty;
        /// <summary>
        /// 会员信息
        /// </summary>
        protected string HuiYuanXinXi = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            HuiYuanId = Utils.GetQueryStringValue("huiyuanid");
            if (string.IsNullOrEmpty(HuiYuanId)) Utils.RCWE("异常请求");

            InitInfo();
            InitRpt();
        }

        #region private members
        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            var info = new EyouSoft.BLL.OtherStructure.BMember().GetModel(HuiYuanId);
            if (info == null) return;
            HuiYuanXinXi = info.MemberName;
        }

        /// <summary>
        /// init rpt
        /// </summary>
        void InitRpt()
        {
            PageIndex = UtilsCommons.GetPagingIndex();
            int recordCount = 0;

            var chaXun = new EyouSoft.Model.MFenSiChaXunInfo();
            var items = new EyouSoft.BLL.OtherStructure.BMember().GetFenSis(HuiYuanId, PageSize, PageIndex, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                rpt.DataSource = items;
                rpt.DataBind();

                FenYe.intPageSize = PageSize;
                FenYe.CurrencyPage = PageIndex;
                FenYe.intRecordCount = recordCount;
            }
            else
            {
                phEmpty.Visible = true;
            }
        }
        #endregion

    }
}
