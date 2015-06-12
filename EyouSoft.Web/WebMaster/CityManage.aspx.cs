using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace EyouSoft.Web.WebMaster
{
    /// <summary>
    /// 城市管理
    /// </summary>
    public partial class CityManage : Common.Page.WebmasterPageBase
    {
        protected int pageIndex;
        protected int recordCount;
        protected int pageSize = 5;

        protected string proAndCityHtml;//城市省份列表html

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.基础信息管理_城市信息))
            {
                ToUrl("/webmaster/default.aspx");
            }

            string method = Utils.GetQueryStringValue("method");
            int id = Utils.GetInt(Utils.GetQueryStringValue("id"));//省份或城市Id
            //获取当前操作
            bool result = false;
            if (method != "")
            {
                var cityBll = new BLL.OtherStructure.BSysAreaInfo();
                switch (method)
                {
                    case "delCity"://删除城市
                        result = cityBll.DeleteSysCity(id);
                        break;
                    case "delPro"://删除省份
                        result = cityBll.DeleteSysProvince(id);
                        break;
                    case "True"://设置为常用城市
                    case "False":
                        //
                        break;
                }
                Utils.ResponseMeg(result, result ? "" : "操作失败！");
                return;
            }
            //绑定城市省份数据
            GetProAndCityHTML();
        }

        /// <summary>
        /// 绑定城市省份数据
        /// </summary>
        protected void GetProAndCityHTML()
        {
            int itemIndex2 = 1;
            var cityBll = new BLL.OtherStructure.BSysAreaInfo();
            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("Page"), 1);
            var proList = cityBll.GetSysProvinceList(pageSize, pageIndex, ref recordCount, null);
            UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
            if (proList != null && proList.Count > 0)
            {
                var proBuilder = new StringBuilder();
                int itemIndex = 1;
                itemIndex2 = (pageIndex - 1) * pageSize;
                foreach (var pro in proList)
                {


                    itemIndex2++;
                    proBuilder.AppendFormat(
                        "<tr class='{3}'>" + "<td {0} align=\"center\" valign=\"top\">{1}</td>"
                        +
                        "<td {0} align=\"center\" valign=\"top\"><strong><a href=\"javascript:;\" onclick=\"return CityManage.updatePro('{4}');\">{2}</a></strong> <a href=\"javascript:;\" onclick=\"return CityManage.delPro('{4}',this);\">[删除]</a></td>",
                        (pro.CityList != null && pro.CityList.Count > 0) ? "rowspan='" + pro.CityList.Count + "'" : "",
                        itemIndex2,
                        pro.Name,
                        itemIndex2 % 2 == 0 ? "even" : "odd",
                        pro.ID);
                    if (pro.CityList != null && pro.CityList.Count > 0)
                    {
                        foreach (var c in pro.CityList)
                        {
                            if (itemIndex != 1)
                                proBuilder.AppendFormat("<tr class='{0}'>", itemIndex2 % 2 == 0 ? "even" : "odd");
                            proBuilder.AppendFormat(
                                "<td align=\"center\" ><a href=\"javascript:;\" onclick=\"return CityManage.updateCity('{0}');\">{1}</a></td>"
                                +
                                "<td align=\"center\" ><a href=\"javascript:;\" onclick=\"return CityManage.delCity('{0}',this);\">删除</a></td></tr>",
                                c.Id,
                                c.Name);
                            itemIndex++;
                        }
                    }
                    else
                    {
                        proBuilder.Append("<td align=\"center\" >&nbsp;</td><td align=\"center\">&nbsp;</td></tr>");
                    }
                    itemIndex = 1;
                }
                proAndCityHtml = proBuilder.ToString();
                BindExportPage();
            }
            else
            {
                proAndCityHtml = "<tr><td colspan='5' align='center'>对不起，暂无城市省份信息！</td></tr>";
                ExporPageInfoSelect1.Visible = false;
            }
        }

        /// <summary>
        /// 绑定分页控件
        /// </summary>
        protected void BindExportPage()
        {
            this.ExporPageInfoSelect1.intPageSize = pageSize;
            this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
            this.ExporPageInfoSelect1.intRecordCount = recordCount;
        }

    }
}
