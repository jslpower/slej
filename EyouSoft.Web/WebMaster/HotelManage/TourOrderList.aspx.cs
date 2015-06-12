using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;
namespace EyouSoft.Web.WebMaster.HotelManage
{
    public partial class TourOrderList : EyouSoft.Common.Page.WebmasterPageBase
    {
        #region 分页参数
        protected int pageIndex = 1;
        protected int recordCount;
        protected int pageSize = 15;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Utils.GetInt(Utils.GetQueryStringValue("id"));
            string dotype = Utils.GetQueryStringValue("dotype");
            if (dotype != null && dotype.Length > 0)
            {
                AJAX(dotype, id);
            }
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        /// <summary>
        /// ajax操作
        /// </summary>
        private void AJAX(string doType, int id)
        {
            string msg = "无信息！";
            //对应执行操作
            switch (doType)
            {
                case "ShowRever":
                    msg = this.GetRever(id);
                    break;
                default:
                    break;
            }

            //返回ajax操作结果
            Response.Clear();
            Response.Write(msg);
            Response.End();
        }

        private void PageInit()
        {
            EyouSoft.BLL.HotelStructure.BHotelTourCustoms bll = new EyouSoft.BLL.HotelStructure.BHotelTourCustoms();
            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("Page"), 1);
            IList<EyouSoft.Model.HotelStructure.MHotelTourCustoms> list = bll.GetList(pageSize, pageIndex, ref recordCount, null);
            if (list != null && list.Count > 0)
            {
                this.rptlist.DataSource = list;
                this.rptlist.DataBind();
                BindExportPage();
            }
            else
            {
                this.lbemptymsg.Text = "<tr><td colspan='16' align='center' height='30px'>暂无数据!</td></tr>";
            }
        }

        private string GetRever(int id)
        {
            StringBuilder msg = new StringBuilder();
            msg.Append("<table cellspacing='0' cellpadding='0' border='0' width='99%' class='pp-tableclass'style='margin:0px 0px 5px 0px'>");
            if (id > 0)
            {
                EyouSoft.BLL.HotelStructure.BHotelTourCustoms bll = new EyouSoft.BLL.HotelStructure.BHotelTourCustoms();
                IList<EyouSoft.Model.HotelStructure.MHotelTourCustomsAsk> list = bll.GetListAsk(0, id);
                if (list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        msg.AppendFormat("<tr><td style='text-align:left' width='75%'>【回复】{0}</td><td align='center' width='10%'>{1}</td><td align='center' width='6%'>{2}</td></tr>", list[i].AskContent, list[i].AskTime.ToString("yyyy-MM-dd"), list[i].AskName);
                    }
                }
                else
                {
                    msg.Append("<tr><td colspan='3'>暂无团队订单回复信息！</td></tr>");
                }
            }
            else
            {
                msg.Append("<tr><td colspan='3'>暂无团队订单回复信息！</td></tr>");
            }
            msg.Append("</table>");
            return msg.ToString();
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
