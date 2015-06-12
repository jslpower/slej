using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.Member
{
    /// <summary>
    /// 返联盟推广代码
    /// </summary>
    public partial class TuiGuangDaiMa : EyouSoft.Common.Page.HuiYuanPageBase
    {
        #region attributes
        /// <summary>
        /// 页记录数
        /// </summary>
        protected int PageSize = 10;
        /// <summary>
        /// 页序号
        /// </summary>
        protected int PageIndex = 1;
        /// <summary>
        /// 推广链接
        /// </summary>
        protected string TuiGuangLianJie = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitInfo();
            InitRpt();
        }

        #region private members
        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            var info = new EyouSoft.BLL.OtherStructure.BTuiGuang().GetHuiYuanTuiGuangInfo(HuiYuanInfo.UserId);
            if (info != null)
            {
                string yuMing = "www.slej.cn";
                if (!string.IsNullOrEmpty(info.TuiGuangYuMing)) yuMing = info.TuiGuangYuMing;

                TuiGuangLianJie = "http://" + yuMing + "?" + EyouSoft.Security.Membership.UserProvider.FanLianMengTuiGuangTuiGuangIdChaXunKey + "=" + info.TuiGuangId;
            }

            if (string.IsNullOrEmpty(TuiGuangLianJie)) TuiGuangLianJie = "http://www.slej.cn/";
        }

        /// <summary>
        /// init rpt
        /// </summary>
        void InitRpt()
        {
            PageIndex = UtilsCommons.GetPagingIndex();
            int recordCount = 0;
            var chaXun = new EyouSoft.Model.OtherStructure.MTuiGuangFanLiChaXunInfo();
            chaXun.TuiGuanRenHuiYuanId = HuiYuanInfo.UserId;

            var items = new EyouSoft.BLL.OtherStructure.BTuiGuang().GetTuiGuangFanLis(PageSize, PageIndex, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                string script = string.Format("fenYe.recordCount={0};fenYe.pageIndex={1};fenYe.pageSize={2};", recordCount, PageIndex, PageSize);
                RegisterScript(script);

                rpt.DataSource = items;
                rpt.DataBind();
            }
            else
            {
                phEmpty.Visible = true;
            }
        }
        #endregion
    }
}
