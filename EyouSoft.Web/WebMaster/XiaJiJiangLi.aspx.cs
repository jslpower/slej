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
    /// 分销奖励申请信息
    /// </summary>
    public partial class XiaJiJiangLi : EyouSoft.Common.Page.WebmasterPageBase
    {
        #region attributes
        protected int PageSize = 20;
        protected int PageIndex = 1;        
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Utils.GetQueryStringValue("dotype"))
            {
                case "shenhetongguo": ShenHeTongTuo(); break;
                default: break;

            }

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

            var chaXun = new EyouSoft.Model.OtherStructure.MXiaJiFenXiaoTiChengChaXunInfo();
            var items = new EyouSoft.BLL.OtherStructure.BXiaJiFenXiaoTiCheng().GetTiChengs(PageSize, PageIndex, ref recordCount, chaXun);

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

        /// <summary>
        /// shenhe tongguo
        /// </summary>
        void ShenHeTongTuo()
        {
            string txtTiChengId = Utils.GetFormValue("txtTiChengId");
            if (string.IsNullOrEmpty(txtTiChengId)) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败：异常请求。"));

            int bllRetCode = new EyouSoft.BLL.OtherStructure.BXiaJiFenXiaoTiCheng().SheZhiTiChengStatus(txtTiChengId, EyouSoft.Model.Enum.XiaJiFenXiaoTiChengStatus.已成交, UserInfo.UserId.ToString());

            if (bllRetCode == 1) { Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功。")); }
            else { Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败。")); }
        }
        #endregion

        #region protected members
        /// <summary>
        /// get caozuo html
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        protected string GetCaoZuoHtml(object status)
        {
            var _status = (EyouSoft.Model.Enum.XiaJiFenXiaoTiChengStatus)status;

            string s = string.Empty;

            switch (_status)
            {
                case EyouSoft.Model.Enum.XiaJiFenXiaoTiChengStatus.未处理:
                    s += "<a href=\"javascript:void(0)\" class=\"shenhetongguo\">审核通过</a>";
                    break;
                case EyouSoft.Model.Enum.XiaJiFenXiaoTiChengStatus.已成交: break;
                case EyouSoft.Model.Enum.XiaJiFenXiaoTiChengStatus.已取消: break;
                default: break;
            }

            return s;
        }
        #endregion
    }
}
