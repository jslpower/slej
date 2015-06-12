using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster
{
    public partial class JiFenDuiHuan : EyouSoft.Common.Page.WebmasterPageBase
    {
        #region 分页变量
        protected int pageSize = 20, pageIndex = 1, recordCount = 0, SumCount = 0;
        #endregion
        protected string StrOrderStatus = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("setState") == "1") setOrderState();

            string status = Utils.GetQueryStringValue("orderstatus");
            StrOrderStatus = EyouSoft.Common.Utils.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.JiFenDuiHuanStatus)), status.ToString(), true, "-1", "请选择");
            EyouSoft.Model.OtherStructure.MJiFenSer searchModel = new EyouSoft.Model.OtherStructure.MJiFenSer();
            EyouSoft.BLL.OtherStructure.BJiFen bll = new EyouSoft.BLL.OtherStructure.BJiFen();
            searchModel.StartTime = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtStartTime"));
            searchModel.EndTime = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtEndTime"));
            if (searchModel.EndTime.HasValue)
            {
                searchModel.EndTime = Convert.ToDateTime(searchModel.EndTime).AddDays(1);
            }
            if (status.ToString() != "-1" && !string.IsNullOrEmpty(status))
            {
                searchModel.DuiHuanStatus = (EyouSoft.Model.Enum.JiFenDuiHuanStatus?)Utils.GetInt(status);
            }
            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("Page"), 1);

            var list = bll.GetList(pageSize, pageIndex, ref recordCount, searchModel);
            if (list != null && list.Count > 0)
            {
                this.rpt_orders.DataSource = list;
                this.rpt_orders.DataBind();
                BindExportPage();
            }
            else
            {
                lbemptymsg.Text = "<tr><td colspan='10' align='center' height='30px'>暂无数据!</td></tr>";
            }
        }
        /// <summary>
        /// 返回下单人姓名
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        protected string GetMemberNameByID(object memberID)
        {
            string id = "";
            if (memberID != null)
            {
                id = Utils.GetString(memberID.ToString(), "");
            }
            if (id == "" || id == null) return "金奥";
            EyouSoft.BLL.OtherStructure.BMember bll = new EyouSoft.BLL.OtherStructure.BMember();
            EyouSoft.Model.MMember model = new EyouSoft.Model.MMember();
            model = bll.GetModel(id);
            if (model == null) return "金奥";
            return "<span style='color:red'>" + model.UserType + "</span><br />" + model.MemberName + "<br />" + model.Mobile;

        }
        /// <summary>
        /// 初始化操作
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="setState"></param>
        /// <returns></returns>
        protected string setOptClick(string orderid, object setState)
        {
            EyouSoft.Model.Enum.JiFenDuiHuanStatus state = (EyouSoft.Model.Enum.JiFenDuiHuanStatus)setState;
            switch (state)
            {
                case EyouSoft.Model.Enum.JiFenDuiHuanStatus.未审核:
                    return string.Format("  <a href=\"javascript:;\" onclick=\"javascript:OrderList.setOrder('{0}','{1}')\";  ><span style='color:red;'>审核通过</span></a>  <a href=\"javascript:;\" onclick=\"javascript:OrderList.setOrder('{0}','{2}')\";  ><span style='color:red;'>审核未通过</span></a>", orderid, (byte)EyouSoft.Model.Enum.JiFenDuiHuanStatus.审核通过, (byte)EyouSoft.Model.Enum.JiFenDuiHuanStatus.审核未通过);
                case EyouSoft.Model.Enum.JiFenDuiHuanStatus.审核通过:
                    return string.Format("  <span style='color:red;'>审核已通过</span>");
                case EyouSoft.Model.Enum.JiFenDuiHuanStatus.审核未通过:
                    return string.Format("  <span style='color:red;'>审核未通过</span>");
                default:
                    break;
            }
            return "";
        }
        /// <summary>
        /// 设置订单状态
        /// </summary>
        void setOrderState()
        {
            string orderid = Utils.GetQueryStringValue("id");
            EyouSoft.Model.Enum.JiFenDuiHuanStatus state = (EyouSoft.Model.Enum.JiFenDuiHuanStatus)Utils.GetInt(Utils.GetQueryStringValue("state"));
            EyouSoft.BLL.OtherStructure.BJiFen bll = new EyouSoft.BLL.OtherStructure.BJiFen();
            int result = bll.SheZhiStatus(orderid, state);
            RCWE(UtilsCommons.AjaxReturnJson(result == 1 ? "1" : "0", result == 1 ? "操作成功" : "操作失败"));

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
