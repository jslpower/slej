using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster
{
    public partial class DiBiao : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected int pageSize = 20;
        protected int pageIndex = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Utils.GetQueryStringValue("dotype") == "delete") Delete();

            if (!CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.基础信息管理_地标管理)) ToUrl("/webmaster/default.aspx");

            InitRpt();
        }

        void InitRpt()
        {
            //pageIndex = Utils.GetInt(Utils.GetQueryStringValue("Page"), 1);
            //int recordCount = 0;

            //var chaXun = new EyouSoft.Model.OtherStructure.MDiBiaoInfo();

            //chaXun.DistrictId = Utils.GetInt(Utils.GetQueryStringValue("txtDistrictId"));
            //chaXun.CityId = Utils.GetInt(Utils.GetQueryStringValue("txtCityId"));
            //chaXun.ProvinceId = Utils.GetInt(Utils.GetQueryStringValue("txtProvinceId"));
            //chaXun.Name = Utils.GetQueryStringValue("txtName");

            //var items = new EyouSoft.BLL.OtherStructure.BDiBiao().GetDiBiaos(pageSize, pageIndex, ref recordCount, chaXun);

            //if (items != null && items.Count > 0)
            //{
            //    rpt.DataSource = items;
            //    rpt.DataBind();

            //    this.FenYe.intPageSize = pageSize;
            //    this.FenYe.CurrencyPage = pageIndex;
            //    this.FenYe.intRecordCount = recordCount;
            //}
            //else
            //{
            //    phEmpty.Visible = true;
            //}
        }

        //void Delete()
        //{
        //    if (!CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.基础信息管理_地标管理))
        //    {
        //        RCWE(UtilsCommons.AjaxReturnJson("0", "无权限"));
        //    }

        //    int id = Utils.GetInt(Utils.GetFormValue("txtid"));

        //    if (id < 1)
        //    {
        //        RCWE(UtilsCommons.AjaxReturnJson("0", "异常请求"));
        //    }

        //    var bllRetCode = new EyouSoft.BLL.OtherStructure.BDiBiao().Delete(id);

        //    if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
        //    else RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败"));
        //}
    }
}
