using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.Common;
using EyouSoft.BLL.OtherStructure;
using EyouSoft.Model;
using EyouSoft.Common.Function;

namespace EyouSoft.Web.WebMaster.Strategy
{
    public partial class StrategyList : EyouSoft.Common.Page.WebmasterPageBase
    {

        #region  页面变量
        protected int pageIndex = 1, pageSize = 20, recordCount = 0;
        protected string dotype = "", id = "";
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.基础信息管理_旅游攻略))
            {
                ToUrl("/webmaster/default.aspx");
            }

            dotype = Utils.GetQueryStringValue("dotype");
            id = Utils.GetQueryStringValue("id");
            if (dotype != null && dotype.Length > 0)
            {
                AJAX(dotype, id);
            }
            if (!IsPostBack)
            {
                initList();
            }
        }

        /// <summary>
        /// ajax操作
        /// </summary>
        private void AJAX(string doType, string id)
        {
            string msg = string.Empty;
            //对应执行操作
            switch (dotype.ToLower())
            {
                case "sh": 
                    msg = this.Check(true, id);
                    break;
                case "qxsh":
                    msg = this.Check(false, id);
                    break;
                case "delete": 
                    msg = this.DeleteData(id);
                    break;
                default:
                    break;
            }

            //返回ajax操作结果
            Response.Clear();
            Response.Write(msg);
            Response.End();
        }

        protected void initList()
        {
            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("page"), 1);
            #region 查询实体
            MTravelStrategyCX modelSerch = new MTravelStrategyCX();
            modelSerch.TravelName = Utils.GetQueryStringValue("TravelName");
            modelSerch.ThemeID = Utils.GetInt(Utils.GetQueryStringValue("ddlTheme"));
            modelSerch.TravelDateBegin = !string.IsNullOrEmpty(Utils.GetQueryStringValue("txtStartTime")) ? Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtStartTime")) : null;
            modelSerch.TravelDateEnd = !string.IsNullOrEmpty(Utils.GetQueryStringValue("txtEndTime")) ? Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtEndTime")) : null;
            modelSerch.IsCheck = !string.IsNullOrEmpty(Utils.GetQueryStringValue("ddlIsCheck")) ? (bool?)(Utils.GetQueryStringValue("ddlIsCheck") == "1" ? true : false) : null;
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("ddlIsMember")))
            {
                modelSerch.OperatorLeiXing = (EyouSoft.Model.Enum.OperatorLeiXing)Utils.GetInt((Utils.GetQueryStringValue("ddlIsMember")));
            }
            #endregion

            BTravelStrategy bll = new BTravelStrategy();
            IList<MTravelStrategy> list = bll.GetList(pageSize, pageIndex, ref recordCount, modelSerch, null);
            if (list != null && list.Count > 0)
            {
                rpt_Strategys.DataSource = list;
                rpt_Strategys.DataBind();
                BindPage();
            }

        }

        #region 绑定主题
        /// <summary>
        /// 绑定主题
        /// </summary>
        /// <param name="selectItem"></param>
        /// <returns></returns>
        protected string BindTheme(string selectItem)
        {
            System.Text.StringBuilder query = new System.Text.StringBuilder();
            IList<EyouSoft.Model.MTravelStrategyTheme> list = new EyouSoft.BLL.OtherStructure.BTravelStrategyTheme().GetList(null);
            query.Append("<option value='0' >-请选择-</option>");
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ThemeID.ToString().Equals(selectItem))
                {
                    query.AppendFormat("<option value='{0}' selected='selected'>{1}</option>", list[i].ThemeID, list[i].ClassName);
                }
                else
                {
                    query.AppendFormat("<option value='{0}' >{1}</option>", list[i].ThemeID, list[i].ClassName);

                }
            }
            return query.ToString();

        }
        #endregion

        /// <summary>
        /// 获取主题名
        /// </summary>
        /// <param name="ID">主题ID</param>
        /// <returns></returns>
        protected string getThemeNameByID(object ID)
        {
            EyouSoft.BLL.OtherStructure.BTravelStrategyTheme bll = new EyouSoft.BLL.OtherStructure.BTravelStrategyTheme();
            EyouSoft.Model.MTravelStrategyTheme Model = bll.GetModel(Utils.GetInt(ID.ToString()));
            return Model.ClassName;
        }

        /// <summary>
        /// 绑定分页控件
        /// </summary>
        protected void BindPage()
        {
            this.ExporPageInfoSelect1.PageLinkURL = Request.ServerVariables["SCRIPT_NAME"].ToString() + "?";
            this.ExporPageInfoSelect1.intPageSize = pageSize;
            this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
            this.ExporPageInfoSelect1.intRecordCount = recordCount;
            this.ExporPageInfoSelect1.UrlParams = Request.QueryString;
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
                EyouSoft.BLL.OtherStructure.BTravelStrategy bll = new EyouSoft.BLL.OtherStructure.BTravelStrategy();
                if (bll.Delete(id.Split(',')))
                    msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "1", "删除成功");
                else
                    msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "0", "删除失败");
            }
            return msg;
        }

        /// <summary>
        /// 审核操作
        /// </summary>
        /// <param name="isCheck">审核状态</param>
        /// <param name="id">攻略ID</param>
        protected string Check(bool isCheck, string id)
        {
            string msg = string.Empty;
            BTravelStrategy bll = new BTravelStrategy();
            if (bll.SetCheck(isCheck, id.Split(',')))
                msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "1", isCheck ? "审核成功！" : "取消审核成功！");
            else
                msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "0", isCheck ? "审核失败！" : "取消审核失败！");
            return msg;
        }
    }
}
