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
using EyouSoft.Common;
using System.Xml.Linq;
using System.Collections.Generic;
using EyouSoft.Model.XianLuStructure;

namespace EyouSoft.Web.WebMaster
{
    public partial class SelectCustomer : EyouSoft.Common.Page.WebmasterPageBase
    {
        #region 分页参数
        protected int pageIndex = 1;
        protected int recordCount;
        protected int pageSize = 15;
        #endregion
        protected int listcount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string customername = Utils.GetQueryStringValue("txtName");
            string routeid = Utils.GetQueryStringValue("routeid");
            if (!IsPostBack)
            {
                BindDate(customername, routeid);
            }
        }

        private void BindDate(string customername, string routeid)
        {
            //EyouSoft.BLL.XianLuStructure.BXianLu bll = new EyouSoft.BLL.XianLuStructure.BXianLu();
            //MDianPingSearchYouKe searchmodel = new MDianPingSearchYouKe();
            //IList<MOrderYouKeInfo> list = bll.GetYouKeInfoByXianLuId(routeid, searchmodel);
            //if (list != null && list.Count > 0)
            //{
            //    this.RptCustomerList.DataSource = list;
            //    this.RptCustomerList.DataBind();
            //}
            //else
            //{
            //    this.lbemptymsg.Text = "<tr><td align='center' height='30px'>暂无数据!</td></tr>";
            //}
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
