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
using System.Collections.Generic;
using EyouSoft.Model.XianLuStructure;

namespace EyouSoft.Web.WebMaster
{
    /// <summary>
    /// 刘飞
    /// 2013-3-21
    /// 团购列表
    /// </summary>
    public partial class TuangouList : EyouSoft.Common.Page.WebmasterPageBase
    {
        #region 分页参数
        protected int pageIndex = 1;
        protected int recordCount;
        protected int pageSize = 20;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.线路产品管理_团购产品))
            {
                ToUrl("/webmaster/default.aspx");
            }

            string id = Utils.GetQueryStringValue("id");
            string dotype = Utils.GetQueryStringValue("dotype");
            if (dotype == "delete")
            {
                AJAX(id);
            }
            if (!IsPostBack)
            {
                PageInit();
            }
        }
        private void PageInit()
        {
            string tuanname = Utils.GetQueryStringValue("txttuanname");
            string routename = Utils.GetQueryStringValue("txtrouteName");
            DateTime? stime = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtStartTime"));
            DateTime? etime = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtEndTime"));
            EyouSoft.BLL.XianLuStructure.BXianLu bll = new EyouSoft.BLL.XianLuStructure.BXianLu();
            EyouSoft.Model.XianLuStructure.MXianLuTuanGouChaXunInfo searchmodel = new EyouSoft.Model.XianLuStructure.MXianLuTuanGouChaXunInfo();
            searchmodel.RouteName = routename;
            searchmodel.STime = stime;
            searchmodel.ETime = etime;
            searchmodel.TuanName = tuanname;
            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("Page"), 1);
            IList<MXianLuTuanGouInfo> list = bll.GetTuanGous(pageSize, pageIndex, ref recordCount, searchmodel);
            Utils.Paging(pageSize, ref pageIndex, recordCount);
            if (list != null && list.Count > 0)
            {

                this.rptlist.DataSource = list;
                this.rptlist.DataBind();
                BindExportPage();
            }
            else
            {
                this.lbemptymsg.Text = "<tr><td colspan='11' align='center' height='30px'>暂无数据!</td></tr>";
            }
        }

        private void AJAX(string id)
        {
            string msg = string.Empty;
            msg = DeleteDate(id);
            Response.Clear();
            Response.Write(msg);
            Response.End();
        }
        private string DeleteDate(string id)
        {
            string msg = string.Empty;
            int result = 0;
            EyouSoft.BLL.XianLuStructure.BXianLu bll = new EyouSoft.BLL.XianLuStructure.BXianLu();
            result = bll.DeleteTuanGou(id);
            switch (result)
            {
                case 1:
                    msg = UtilsCommons.AjaxReturnJson("1", "删除成功");
                    break;
                default:
                    msg = UtilsCommons.AjaxReturnJson("0", "删除失败!");
                    break;
            }
            return msg;
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
