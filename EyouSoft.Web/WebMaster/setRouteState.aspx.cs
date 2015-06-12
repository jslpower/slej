using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster
{
    public partial class setRouteState : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("save") == "save") setXianLuStatus();
        }
        void setXianLuStatus()
        {
            string ids = Utils.GetQueryStringValue("ids");
            if (string.IsNullOrEmpty(ids)
                || ids.Split(',').Length == 0) Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "数据丢失，请返回上一级从新操作"));
            string[] idArr = ids.Split(',');
            EyouSoft.Model.Enum.XianLuStructure.XianLuZT zt = (EyouSoft.Model.Enum.XianLuStructure.XianLuZT)Utils.GetInt(Utils.GetFormValue("selectZT"));
            int result = new EyouSoft.BLL.XianLuStructure.BXianLu().setXianLuZT(idArr, zt);
            if (result >= 1) Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "设置成功！"));
            Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "设置失败！"));
        }
    }
}
