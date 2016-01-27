using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.WeiXin;
using EyouSoft.Model.Enum;
using EyouSoft.BLL.OtherStructure;

namespace EyouSoft.Web.WebMaster.YouJi
{
    public partial class YouJiList : EyouSoft.Common.Page.WebmasterPageBase
    {
        private int pagesize = 20;
        private int pagecount = 0;
        private int pageindex = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            string dotype = Utils.GetQueryStringValue("dotype");
            if (dotype == "DelYouJi") DelYouJi();
            BindInte();
        }

        void BindInte()
        {
            MYouJiSer YouJiS = new MYouJiSer();
            //YouJiS.YouJiType = YouJiLeiXing.图文游记;
            YouJiS.HuiYuanName = Utils.GetQueryStringValue("txtOperatorName");
            YouJiS.YouJiTitle = Utils.GetQueryStringValue("txtArticleTitle");
            pageindex = UtilsCommons.GetPagingIndex();
            var list = new BYouJi().GetList(pagesize, pageindex, ref pagecount, YouJiS);
            if (list != null && list.Count > 0)
            {
                rptlist.DataSource = list;
                rptlist.DataBind();
                this.ExportPageInfo1.intPageSize = pagesize;
                this.ExportPageInfo1.CurrencyPage = pageindex;
                this.ExportPageInfo1.intRecordCount = pagecount;
            }
            else
            {
                ltrNoMsg.Visible = true;
            }
        }
        /// <summary>
        /// 删除游记
        /// </summary>
        void DelYouJi()
        {
            string YouJiId = Utils.GetQueryStringValue("youjid");
            if (string.IsNullOrEmpty(YouJiId)) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "请选择需要删除的游记"));

            bool bllRetCode = new BYouJi().Delete(YouJiId);

            if (bllRetCode)
            {
                Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            }
            else
            {
                Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败"));
            }

        }
        /// <summary>
        /// 获取是否有删除权限
        /// </summary>
        /// <param name="huiyuanID"></param>
        /// <returns></returns>
        protected string getIsUpdateHtml(string huiyuanID)
        {
            if (Utils.GetInt(huiyuanID.Trim()) == 0)
                return string.Format("<a class=\"toolbar_chakan\" href=\"javascript:;\">查看</a> | ");

            return string.Format("<a class=\"toolbar_update\" href=\"javascript:;\">编辑</a> | ");

        }

    }
}
