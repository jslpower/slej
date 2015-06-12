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
using System.Text;
using EyouSoft.Model.Enum;
using EyouSoft.Model.Enum.XianLuStructure;
using EyouSoft.Model;

namespace EyouSoft.Web.WebMaster
{
    /// <summary>
    /// 创建人：刘飞
    /// 功能：线路列表
    /// ２０１３年３月１6号
    /// </summary>
    public partial class RouteList : Common.Page.WebmasterPageBase
    {
        #region 分页参数
        protected int pageIndex = 1;
        protected int recordCount;
        protected int pageSize = 20;
        #endregion

        protected string RouteArea = string.Empty;
        protected string AreaType = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.线路产品管理_线路管理))
            {
                ToUrl("/webmaster/default.aspx");
            }

            string dotype = Utils.GetQueryStringValue("dotype");
            string opt = Utils.GetQueryStringValue("opt");
            string id = Utils.GetQueryStringValue("id");
            if (dotype != null && dotype.Length > 0)
            {
                AJAX(dotype, id);
            }
            if (opt == "set") setXianLuStatus();
            if (!IsPostBack)
            {
                PageInit();
            }
        }
        private void PageInit()
        {
            EyouSoft.BLL.XianLuStructure.BXianLu bll = new EyouSoft.BLL.XianLuStructure.BXianLu();
            EyouSoft.Model.XianLuStructure.MXianLuChaXunInfo searchmodel = new EyouSoft.Model.XianLuStructure.MXianLuChaXunInfo();
            string PathName = Utils.GetQueryStringValue("txtPathName");
            string Days = Utils.GetQueryStringValue("txtDays");
            string Author = Utils.GetQueryStringValue("txtAuthor");
            DateTime? StartTime = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtStartTime"));
            DateTime? EndTime = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtEndTime"));

            int areaid = Utils.GetInt(Utils.GetQueryStringValue("AreaID"));
            if (areaid > 0)
            {
                searchmodel.AreaIds = new int[] { areaid };
            }
            GetRouteArea(areaid);
            int areatype = Utils.GetInt(Utils.GetQueryStringValue("AreaType"));
            if (areatype > 0)
            {
                searchmodel.AreaTypes = new AreaType[] { (AreaType)areatype };
            }
            GetAreaType(areatype);
            searchmodel.RouteName = PathName;
            if (Utils.GetInt(Days) > 0)
            {
                searchmodel.TianShu = Utils.GetInt(Days);
            }
            searchmodel.SLDate = StartTime;
            searchmodel.ELDate = EndTime;
            searchmodel.RouteName = PathName;
            if (Utils.GetInt(Days) > 0)
                searchmodel.TianShu = Utils.GetInt(Days);

            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("Page"), 1);

            #region 排序 时间 价格
            string paiXuLeiXing = Utils.GetQueryStringValue("Sdesc").Trim();

            switch (paiXuLeiXing)
            {
                case "Sasc":
                    searchmodel.PaiXuLeiXing = 2;
                    break;
                case "Sdesc":
                    searchmodel.PaiXuLeiXing = 3;
                    break;
                case "Lasc":
                    searchmodel.PaiXuLeiXing = 0;
                    break;
                case "Ldesc":
                    searchmodel.PaiXuLeiXing = 1;
                    break;
                case "Iasc":
                    searchmodel.PaiXuLeiXing = 4;
                    break;
                case "Idesc":
                    searchmodel.PaiXuLeiXing = 5;
                    break;
                default:
                    searchmodel.PaiXuLeiXing = 0;
                    break;
            }
            #endregion

            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("source"))) searchmodel.LineSource = (LineSource)Utils.GetInt(Utils.GetQueryStringValue("source"));
            IList<MXianLuInfo> list = bll.GetXianLus(pageSize, pageIndex, ref recordCount, searchmodel);
            Utils.Paging(pageSize, ref pageIndex, recordCount);
            if (list != null && list.Count > 0)
            {
                this.rptlist.DataSource = list;
                this.rptlist.DataBind();
                BindExportPage();
            }
            else
            {
                lbemptymsg.Text = "<tr><td colspan='7' align='center' height='30px'>暂无数据!</td></tr>";
            }
        }


        /// <summary>
        /// 获取线路区域
        /// </summary>
        /// <param name="areaname">区域名称</param>
        private void GetRouteArea(int areaid)
        {
            StringBuilder str = new StringBuilder();
            EyouSoft.BLL.OtherStructure.BSysAreaInfo bll = new EyouSoft.BLL.OtherStructure.BSysAreaInfo();
            AreaType areaType = 0;
            IList<EyouSoft.Model.MSysArea> AreaList = null;
            if (areaid > 0)
            {
                areaType = (AreaType)areaid;
                AreaList = bll.GetSysAreaList(0, new EyouSoft.Model.MSysArea { RouteType = areaType });
            }
            str.Append("<option value='-1'>请选择</option>");
            if (AreaList != null && AreaList.Count > 0)
            {
                for (int i = 0; i < AreaList.Count; i++)
                {
                    str.AppendFormat("<option value='{0}'>{1}</option>", AreaList[i].ID, AreaList[i].AreaName);
                }
            }
            RouteArea = str.ToString();
        }

        /// <summary>
        /// 获取线路区域类型
        /// </summary>
        /// <param name="areatype"></param>
        private void GetAreaType(int areatype)
        {
            AreaType = Utils.GetEnumDDL(EyouSoft.Common.EnumObj.GetList(typeof(AreaType)), areatype.ToString(), "-1", "请选择");
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

        /// <summary>
        /// 获取线路状态
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string GetStatus(object obj)
        {
            StringBuilder str = new StringBuilder();
            IList<XianLuZhuangTai> status = (IList<XianLuZhuangTai>)obj;
            if (status != null && status.Count > 0)
            {
                for (int i = 0; i < status.Count; i++)
                {
                    if (i == status.Count - 1)
                        str.Append(status[i].ToString());
                    else
                        str.Append(status[i].ToString() + "、");
                }
            }
            return str.ToString();
        }

        /// <summary>
        /// 获取出团时间
        /// </summary>
        /// <param name="obj">时间集合</param>
        /// <param name="t">用来区分列表和单个</param>
        /// <returns></returns>
        protected string GetLEdate(object obj, bool t, object xianluId)
        {
            StringBuilder str = new StringBuilder();
            IList<MXianLuTourInfo> list = (IList<MXianLuTourInfo>)obj;
            if (list != null && list.Count > 0)
            {
                if (t)
                {
                    str.Append("<table cellspacing='0' cellpadding='0' border='0' width='100%' class='pp-tableclass'><tr class='pp-table-title'><th>出团日期</th><th>回团日期</th></tr>");
                    for (int i = 0; i < list.Count; i++)
                    {
                        str.AppendFormat("<tr><td>{0}</td><td>{1}</td></tr>", "<a href='javascript:;' data-tourid='" + list[i].TourId + "' data-xianluid='" + xianluId.ToString() + "' onclick='RouteList.EditDate(this)' >" + Utils.GetDateString(list[i].LDate, "yyyy-MM-dd") + "</a>", Utils.GetDateString(list[i].RDate, "yyyy-MM-dd"));
                    }
                    str.Append("</table>");
                }
                else
                {
                    str.Append(Utils.GetDateString(list[0].LDate, "yyyy-MM-dd"));

                }
            }
            return str.ToString();
        }

        protected string GetTourdate(object obj)
        {
            MXianLuTourInfo info = (MXianLuTourInfo)obj;
            if (info != null)
            {
                return info.LDate.ToString("yyyy-MM-dd");
            }
            else
                return "";
        }

        /// <summary>
        /// 获取线路区域名称
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string GetAreaName(object obj)
        {
            int areaid = Utils.GetInt(obj.ToString());
            EyouSoft.BLL.OtherStructure.BSysAreaInfo bll = new EyouSoft.BLL.OtherStructure.BSysAreaInfo();
            string areaname = string.Empty;
            areaname = bll.GetSysAreaName(areaid);
            return areaname;
        }

        /// <summary>
        /// ajax操作
        /// </summary>
        private void AJAX(string doType, string id)
        {
            string msg = string.Empty;
            //对应执行操作
            switch (doType.ToLower())
            {
                case "delete":
                    // 判断权限
                    //if (this.CheckGrant(EyouSoft.Model.EnumType.PrivsStructure.Privs3.客户管理_客户资料_删除))
                    //{
                    msg = this.DeleteData(id);
                    //}
                    break;
                case "getareas":
                    GetRouteArea(Utils.GetInt(Utils.GetQueryStringValue("areaid")));
                    msg = RouteArea;
                    break;
                default: break;
            }
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
            string msg = string.Empty;
            if (!String.IsNullOrEmpty(id))
            {
                EyouSoft.BLL.XianLuStructure.BXianLu bll = new EyouSoft.BLL.XianLuStructure.BXianLu();
                int result = bll.Delete(id);
                switch (result)
                {
                    case 1:
                        msg = UtilsCommons.AjaxReturnJson("1", "删除成功");
                        break;
                    default:
                        msg = UtilsCommons.AjaxReturnJson("0", "删除失败!");
                        break;
                }
            }
            return msg;
        }
        /// <summary>
        /// 设置线路状态
        /// </summary>
        void setXianLuStatus()
        {
            string ids = Utils.GetQueryStringValue("id");
            if (string.IsNullOrEmpty(ids)
                || ids.Split(',').Length == 0) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "数据丢失，请刷新页面"));
            string[] idArr = ids.Split(',');
            EyouSoft.Model.Enum.XianLuStructure.XianLuZT zt = (EyouSoft.Model.Enum.XianLuStructure.XianLuZT)Utils.GetInt(Utils.GetQueryStringValue("state"));
            int result = new EyouSoft.BLL.XianLuStructure.BXianLu().setXianLuZT(idArr, zt);

            if (result >= 1)
            {
                for (int i = 0; i < idArr.Count(); i++)
                {
                    new EyouSoft.BLL.OtherStructure.BTuanGou().UpdateProductSort("xianlu", idArr[i], 1);
                }
                Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "设置成功！"));
            }
            Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "设置失败！"));
        }
    }
}
