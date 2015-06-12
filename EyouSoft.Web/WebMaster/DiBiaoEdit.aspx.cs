using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster
{
    public partial class DiBiaoEdit : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected int DiBiaoId = 0;
        protected int ProvinceId = 0;
        protected int CityId = 0;
        protected int DistrictId = 0;
        protected string Name = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            DiBiaoId = Utils.GetInt(Utils.GetQueryStringValue("id"));

            if (Utils.GetQueryStringValue("dotype") == "submit") BaoCun();

            InitInfo();
        }

        void InitInfo()
        {
            //if (DiBiaoId < 1) return;
            //var info = new EyouSoft.BLL.OtherStructure.BDiBiao().GetInfo(DiBiaoId);
            //if (info == null) RCWE("请求异常");

            //ProvinceId = info.ProvinceId;
            //CityId = info.CityId;
            //DistrictId = info.DistrictId;
            //Name = info.Name;
        }

        void BaoCun()
        {
            //if (!CheckGrantMenu2(EyouSoft.Model.Enum.Privs.Menu2.基础信息管理_地标管理))
            //{
            //    RCWE(UtilsCommons.AjaxReturnJson("0", "无权限"));
            //}

            //var info = new EyouSoft.Model.OtherStructure.MDiBiaoInfo();
            //info.Id = DiBiaoId;
            //info.ProvinceId = Utils.GetInt(Utils.GetFormValue("txtProvinceId"));
            //info.CityId = Utils.GetInt(Utils.GetFormValue("txtCityId"));
            //info.DistrictId = Utils.GetInt(Utils.GetFormValue("txtDistrictId"));
            //info.Name = Utils.GetFormValue("txtName");

            //int bllRetCode = 0;
            //if (info.Id < 1)
            //{
            //    bllRetCode = new EyouSoft.BLL.OtherStructure.BDiBiao().Insert(info);
            //}
            //else
            //{
            //    bllRetCode = new EyouSoft.BLL.OtherStructure.BDiBiao().Update(info);
            //}

            //if (bllRetCode == 1) RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            //else RCWE(UtilsCommons.AjaxReturnJson("0", "操作失败"));
        }
    }
}
