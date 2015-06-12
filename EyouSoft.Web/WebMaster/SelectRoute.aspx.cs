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
    /// 线路选用页面
    /// 创建人：刘飞
    /// 时间：2013-3-20
    /// </summary>
    public partial class SelectRoute : EyouSoft.Common.Page.WebmasterPageBase
    {
        #region 分页参数
        protected int pageIndex = 1;
        protected int recordCount;
        protected int pageSize = 18;
        #endregion
        protected int listcount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string routename = Utils.GetQueryStringValue("txtName");
            string dianping = Utils.GetQueryStringValue("dianpin");
            if (!IsPostBack)
            {
                BindDate(routename, dianping);
            }
        }

        private void BindDate(string routename, string dianping)
        {
            EyouSoft.BLL.XianLuStructure.BXianLu bll = new EyouSoft.BLL.XianLuStructure.BXianLu();
            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("Page"), 1);
            if (dianping == "")
            {
                EyouSoft.Model.XianLuStructure.MXianLuChaXunInfo smodel = new EyouSoft.Model.XianLuStructure.MXianLuChaXunInfo();
                smodel.RouteName = routename;
                IList<MXianLuInfo> list = bll.GetXianLus(pageSize, pageIndex, ref recordCount, smodel);
                Utils.Paging(pageSize, ref pageIndex, recordCount);
                if (list != null && list.Count > 0)
                {
                    this.RptrouteList.DataSource = list;
                    this.RptrouteList.DataBind();
                    listcount = list.Count;
                    this.BindExportPage();
                }
                else
                {
                    this.lbemptymsg.Text = "<tr><td colspan='3' align='center' height='30px'>暂无数据!</td></tr>";
                }
            }
            else
            {
                //IList<EyouSoft.Model.MKV> listyouke = bll.GetDianPingRoute(pageSize, pageIndex, ref recordCount, routename);
                //Utils.Paging(pageSize, ref pageIndex, recordCount);
                //if (listyouke != null && listyouke.Count > 0)
                //{
                //    this.RptrouteList.DataSource = listyouke;
                //    this.RptrouteList.DataBind();
                //    listcount = listyouke.Count;
                //    this.BindExportPage();
                //}
                //else
                //{
                //    this.lbemptymsg.Text = "<tr><td colspan='3' align='center' height='30px'>暂无数据!</td></tr>";
                //}
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
