using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.OtherStructure;

namespace EyouSoft.Web.WebMaster
{
    public partial class FeedbackManage : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected const int PageSize = 10;

        private int pageIndex ;

        private int recordCount ;
        protected void Page_Load(object sender, EventArgs e)
        {
           /* if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.基础信息管理_反馈信息管理))
            {
                ToUrl("/webmaster/default.aspx");
            }*/

            string id = Utils.GetQueryStringValue("id");
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

        private void PageInit()
        {
            
            EyouSoft.Model.OtherStructure.MSearchFeedback Search = new MSearchFeedback();
            string MessageType = Utils.GetQueryStringValue("MessageType");
            if (!MessageType.Equals("0"))
            {
                Search.MessageType = MessageType;
                
            }
            else
            {
                Search.MessageType = null;
            }
            Search.MsgContent = Utils.GetQueryStringValue("txtContext");
            Search.Name = Utils.GetQueryStringValue("txtName");
            Search.starttime = !string.IsNullOrEmpty(Utils.GetQueryStringValue("txtStartTime")) ? Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtStartTime")) : null;
            Search.endtime = !string.IsNullOrEmpty(Utils.GetQueryStringValue("txtEndTime")) ? Utils.GetDateTimeNullable(Utils.GetQueryStringValue("txtEndTime")) : null;

            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("Page"), 1);

            EyouSoft.BLL.OtherStructure.BFeedback bll = new EyouSoft.BLL.OtherStructure.BFeedback();
            

            IList<EyouSoft.Model.OtherStructure.MFeedback> list = bll.GetList(PageSize, pageIndex, ref recordCount, Search);
            if (list != null && list.Count > 0)
            {
                this.rptlist.DataSource = list;
                this.rptlist.DataBind();
                BindExportPage();
            }
            else
            {
                lbemptymsg.Text = "<tr><td colspan='5' align='center' height='30px'>暂无数据!</td></tr>";
            }
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
                    msg = this.DeleteData(id);
                    break;
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
                EyouSoft.BLL.OtherStructure.BFeedback bll = new EyouSoft.BLL.OtherStructure.BFeedback();
                if (bll.Delete(id.Trim()))
                    msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "1", "删除成功");
                else
                    msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "0", "删除失败");
            }
            return msg;
        }

        #region 绑定分页控件
        /// <summary>
        /// 绑定分页控件
        /// </summary>
        protected void BindExportPage()
        {
            this.ExporPageInfoSelect1.intPageSize = PageSize;
            this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
            this.ExporPageInfoSelect1.intRecordCount = recordCount;
        }
        #endregion


        #region 绑定类别
        /// <summary>
        /// 绑定类别
        /// </summary>
        /// 
        /// <param name="selectItem"></param>
        /// <returns></returns>
        protected string BindArticleClass(string selectItem)
        {
            System.Text.StringBuilder query = new System.Text.StringBuilder();
            query.Append("<option value='0' >-请选择-</option>");
            string[] ss = {"建议与意见", "内容纠错", "商务合作", "其他"};
            for (int i = 0; i < ss.Length; i++)
            {
                if (ss[i].ToString().Equals(selectItem))
                {
                    query.AppendFormat("<option value='{0}' selected='selected'>{1}</option>", selectItem, selectItem);
                }
                else
                {
                    query.AppendFormat("<option value='{0}' >{1}</option>", ss[i], ss[i]);

                }
            }
            return query.ToString();

        }
        #endregion

    }
}
