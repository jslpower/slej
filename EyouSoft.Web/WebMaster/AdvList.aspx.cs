using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.IDAL.AccountStructure;

namespace EyouSoft.Web.WebMaster
{
    public partial class AdvList : EyouSoft.Common.Page.WebmasterPageBase
    {
        #region 分页参数
        protected int pageIndex;
        protected int recordCount;
        protected int pageSize = 10;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.基础信息管理_站点广告))
            {
                ToUrl("/webmaster/default.aspx");
            }

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
            EyouSoft.Model.MSearchSysAdv searchModel = new EyouSoft.Model.MSearchSysAdv();
            EyouSoft.BLL.OtherStructure.BSysAdv bll = new EyouSoft.BLL.OtherStructure.BSysAdv();
            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("Page"), 1);
            int typeAdv = Utils.GetInt(Utils.GetQueryStringValue("advType"));
            if (typeAdv != 0)
            {
                EyouSoft.Model.Enum.AdvArea[] searchArrs = new EyouSoft.Model.Enum.AdvArea[] { (EyouSoft.Model.Enum.AdvArea)typeAdv };
                searchModel.AreaIds = searchArrs;

            }
            if (UserInfo.LeiXing == EyouSoft.Model.Enum.WebmasterUserType.代理商用户)
            {
                searchModel.AgencyId = UserInfo.GysId;
            }
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("txtWebName")))
            {
                searchModel.WebSiteName = Utils.GetQueryStringValue("txtWebName");
            }
            if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("txtCJC")))
            {
                searchModel.CompanyJC = Utils.GetQueryStringValue("txtCJC");
            }
            IList<EyouSoft.Model.MSysAdv> list = bll.GetList(pageSize, pageIndex, ref recordCount, searchModel);
            if (list != null && list.Count > 0)
            {
                this.rptlist.DataSource = list;
                this.rptlist.DataBind();
                BindExportPage();
            }
            else
            {
                lbemptymsg.Text = "<tr><td colspan='6' align='center' height='30px'>暂无数据!</td></tr>";
            }
        }

        /// <summary>
        /// 返回网点名称
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        protected string GetWangDianByID(object AgencyId)
        {
            string id = "";
            if (AgencyId != null)
            {
                id = Utils.GetString(AgencyId.ToString(), "");
            }
            if (id == "" || id == null) return "金奥";
            BSellers bsells = new BSellers();
            EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.Model.AccountStructure.MSellers();
            mseller = bsells.GetWebSiteName(id);
            if (mseller == null) return "金奥";
            if (!string.IsNullOrEmpty(mseller.CompanyJC))
            {
                return mseller.CompanyJC +  mseller.WebsiteName;
            }
            else
            {
                return mseller.WebsiteName;
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
                EyouSoft.BLL.OtherStructure.BSysAdv bll = new EyouSoft.BLL.OtherStructure.BSysAdv();
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
            this.ExporPageInfoSelect1.intPageSize = pageSize;
            this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
            this.ExporPageInfoSelect1.intRecordCount = recordCount;
        }
        #endregion
    }
}
