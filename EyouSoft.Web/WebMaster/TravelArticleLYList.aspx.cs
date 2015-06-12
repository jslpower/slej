using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model;
using EyouSoft.BLL.OtherStructure;

namespace EyouSoft.Web.WebMaster
{
    public partial class TravelArticleLYList : EyouSoft.Common.Page.WebmasterPageBase
    {
        #region  页面变量
        protected int pageIndex = 1, pageSize = 20, recordCount = 0;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            string dotype = Utils.GetQueryStringValue("dotype");
            string id = Utils.GetQueryStringValue("id");
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
        private void AJAX(string dotype, string id)
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
            MTravelArticleLYCX modelSerch = new MTravelArticleLYCX();
            modelSerch.ArticleID = Utils.GetQueryStringValue("aid");
            modelSerch.Stime = !string.IsNullOrEmpty(Utils.GetQueryStringValue("txtStartTime")) ? Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtStartTime")) : null;
            modelSerch.Etime = !string.IsNullOrEmpty(Utils.GetQueryStringValue("txtEndTime")) ? Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtEndTime")) : null;
            modelSerch.IsCheck = !string.IsNullOrEmpty(Utils.GetQueryStringValue("ddlIsCheck")) ? (bool?)(Utils.GetQueryStringValue("ddlIsCheck") == "1" ? true : false) : null;
            #endregion

            IList<MTravelArticleLY> list = new BTravelArticle().GetLiuYanList(pageSize, pageIndex, ref recordCount, modelSerch);
            if (list != null && list.Count > 0)
            {
                rpt_List.DataSource = list;
                rpt_List.DataBind();
                BindPage();
            }

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
                if (new BTravelArticle().DeleteLiuYan(id.Split(',')))
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
            if (new BTravelArticle().UpdateLiuYan(isCheck, id.Split(',')))
                msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "1", isCheck ? "审核成功！" : "取消审核成功！");
            else
                msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "0", isCheck ? "审核失败！" : "取消审核失败！");
            return msg;
        }
    }
}
