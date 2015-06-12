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
    ///  线路主题管理
    /// </summary>
    public partial class RouteTheme : Common.Page.WebmasterPageBase
    {
        private int pagesize = 20;
        private int pagecount = 0;
        private int pageindex = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.基础信息管理_线路主题))
            {
                ToUrl("/webmaster/default.aspx");
            }

            string dotype = Utils.GetQueryStringValue("dotype");
            string tid = Utils.GetQueryStringValue("tid");
            if (!string.IsNullOrEmpty(dotype))
            {
                AJAX(dotype, tid);
            }
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        private void PageInit()
        {
            pageindex = Utils.GetInt(Utils.GetQueryStringValue("page"), 1);

            var list = new BLL.OtherStructure.BRouteTheme().GetList(pagesize, pageindex, ref pagecount);

            UtilsCommons.Paging(pagesize, ref pageindex, pagecount);

            rptList.DataSource = list;
            rptList.DataBind();

            BindExportPage();
        }

        protected string GetIndex(int index)
        {
            return ((pageindex - 1) * pagesize + index + 1).ToString();
        }

        /// <summary>
        /// ajax操作
        /// </summary>
        private void AJAX(string doType, string id)
        {
            string msg = string.Empty;

            msg = DeleteData(id);

            //返回ajax操作结果
            Response.Clear();
            Response.Write(msg);
            Response.End();
        }


        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="id">删除ID</param>
        /// <returns></returns>
        private string DeleteData(string id)
        {
            if (string.IsNullOrEmpty(id) || Utils.GetInt(id) <= 0) return UtilsCommons.AjaxReturnJson("0", "线路主题错误!");

            bool bllRetCode = new BLL.OtherStructure.BRouteTheme().Delete(Utils.GetInt(id));

            return UtilsCommons.AjaxReturnJson("1", string.Format("删除{0}!", bllRetCode ? "成功！" : "失败！"));
        }

        /// <summary>
        /// 绑定分页控件
        /// </summary>
        protected void BindExportPage()
        {
            this.ExporPageInfoSelect1.intPageSize = pagesize;
            this.ExporPageInfoSelect1.CurrencyPage = pageindex;
            this.ExporPageInfoSelect1.intRecordCount = pagecount;
        }
    }
}
