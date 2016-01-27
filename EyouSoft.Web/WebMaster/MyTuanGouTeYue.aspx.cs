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

namespace EyouSoft.Web.WebMaster
{
    public partial class MyTuanGouTeYue : EyouSoft.Common.Page.WebmasterPageBase
    {
        #region 分页参数
        protected int pageIndex = 1;
        protected int recordCount;
        protected int pageSize = 20;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("dotype") == "add")
            {
                Response.Clear();
                Response.Write(AddMyDaiLi());
                Response.End();
            }
            if (Utils.GetQueryStringValue("dotype") == "del")
            {
                Response.Clear();
                Response.Write(DelMyDaiLi());
                Response.End();
            }
            initList();
        }
        /// <summary>
        /// 初始化列表
        /// </summary>
        void initList()
        {
            pageIndex = UtilsCommons.GetPagingIndex();
            string GYSid = UserInfo.GysId;
            MTeYueSer model = new MTeYueSer();
            model.CompanyName = Utils.GetQueryStringValue("CompanyName");
            model.MemberName = Utils.GetQueryStringValue("MemberName");
            model.Mobile = Utils.GetQueryStringValue("Mobile");
            model.WebsiteName = Utils.GetQueryStringValue("WebsiteName");
            model.IsMyDaiLi = 0;
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("IsMyDaiLi")))
            {
                model.IsMyDaiLi = Convert.ToInt32(Utils.GetQueryStringValue("IsMyDaiLi"));
            }
            var list = new EyouSoft.BLL.MemberStructure.BMember().GetMyTGDaiLi(GYSid, pageIndex, pageSize, model);
            recordCount = new EyouSoft.BLL.MemberStructure.BMember().GetMyTGDaiLiNum(GYSid, model);
            if (list != null && list.Count > 0)
            {
                rptList.DataSource = list;
                rptList.DataBind();
                BindExportPage();
            }
        }
        /// <summary>
        /// 添加下级代理
        /// </summary>
        /// <returns></returns>
        private string AddMyDaiLi()
        {
            string id = Utils.GetQueryStringValue("id");
            if (string.IsNullOrEmpty(id)) return UtilsCommons.AjaxReturnJson("0", "添加失败！");
            string msg = "";
            if (new EyouSoft.BLL.MemberStructure.BMember().AddTGDaiLi(UserInfo.GysId, id) > 0)
            {
                msg = UtilsCommons.AjaxReturnJson("1", "添加成功！");
            }
            else
            {
                msg = UtilsCommons.AjaxReturnJson("0", "添加失败！");
            }
            return msg;
        }
        /// <summary>
        /// 添加下级代理
        /// </summary>
        /// <returns></returns>
        private string DelMyDaiLi()
        {
            string id = Utils.GetQueryStringValue("id");
            if (string.IsNullOrEmpty(id)) return UtilsCommons.AjaxReturnJson("0", "取消失败！");
            string msg = "";
            if (new EyouSoft.BLL.MemberStructure.BMember().DelTGDaiLi(UserInfo.GysId, id) > 0)
            {
                msg = UtilsCommons.AjaxReturnJson("1", "取消成功！");
            }
            else
            {
                msg = UtilsCommons.AjaxReturnJson("0", "取消失败！");
            }
            return msg;
        }
        protected string GetCaoZuo(object DaiLiId)
        {
            string caozuo = "";
            if (!string.IsNullOrEmpty(DaiLiId.ToString()))
            {
                int num = new EyouSoft.BLL.MemberStructure.BMember().JudgeTGDaiLi(UserInfo.GysId, DaiLiId.ToString());
                if (num > 0)
                {
                    caozuo = "<a href=\"javascript:;\" onclick=\"pageData.QuXiao(this)\" data-id=\"" + DaiLiId + "\">取消代理</a>";
                }
                else
                {
                    caozuo = "<a href=\"javascript:;\" onclick=\"pageData.Tianjia(this)\" data-id=\"" + DaiLiId + "\">添加代理</a>";
                }
            }
            return caozuo;
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
