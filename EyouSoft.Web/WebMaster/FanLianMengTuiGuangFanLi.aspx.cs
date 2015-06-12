using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster
{
    /// <summary>
    /// 返联盟推广返利
    /// </summary>
    public partial class FanLianMengTuiGuangFanLi : EyouSoft.Common.Page.WebmasterPageBase
    {
        #region attributes
        /// <summary>
        /// 页记录数
        /// </summary>
        protected int PageSize = 20;
        /// <summary>
        /// 页序号
        /// </summary>
        protected int PageIndex = 1;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitRpt();

        }

        #region private members
        /// <summary>
        /// init rpt
        /// </summary>
        void InitRpt()
        {
            PageIndex = UtilsCommons.GetPagingIndex();
            int recordCount = 0;
            var chaXun = new EyouSoft.Model.OtherStructure.MTuiGuangFanLiChaXunInfo();

            chaXun.XiaDanShiJian1 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtXiaDanShiJian1"));
            chaXun.XiaDanShiJian2 = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtXiaDanShiJian2"));
            chaXun.FanLiStatus = (EyouSoft.Model.Enum.FanLianMengTuiGuangFanLiStatus?)Utils.GetEnumValueNull(typeof(EyouSoft.Model.Enum.FanLianMengTuiGuangFanLiStatus), Utils.GetQueryStringValue("txtStatus"));

            var items = new EyouSoft.BLL.OtherStructure.BTuiGuang().GetTuiGuangFanLis(PageSize, PageIndex, ref recordCount, chaXun);

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
