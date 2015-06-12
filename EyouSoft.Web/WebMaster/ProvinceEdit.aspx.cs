using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster
{
    /// <summary>
    /// 省份编辑
    /// </summary>
    public partial class ProvinceEdit : Common.Page.WebmasterPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Utils.GetQueryStringValue("action").ToLower();
            int pid = Utils.GetInt(Utils.GetQueryStringValue("pid"));
            string save = Utils.GetQueryStringValue("save");

            if (!string.IsNullOrEmpty(save))
            {
                Response.Clear();
                Response.Write(Save(action, pid));
                Response.End();
            }

            if (!IsPostBack)
            {
                if (action == "edit")
                {
                    this.InitPage(pid);
                }
            }
        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        private void InitPage(int pid)
        {
            var model = new BLL.OtherStructure.BSysAreaInfo().GetSysProvinceModel(pid);
            if (model == null) return;

            txtProvinceName.Text = model.Name;
        }

        private string Save(string action, int pid)
        {
            var model = new Model.MSysProvince
            {
                Name = Utils.GetFormValue(txtProvinceName.UniqueID)
            };

            var bll = new BLL.OtherStructure.BSysAreaInfo();

            int r = 0;
            if (action == "edit")
            {
                model.ID = pid;

                if (!bll.ExistsSysProvince(model))
                {
                    r = bll.UpdateSysProvince(model) ? 1 : -2;
                }
                else
                {
                    r = -1;
                }
            }
            else
            {
                if (!bll.ExistsSysProvince(model))
                {
                    r = bll.AddSysProvince(model) ? 1 : -2;
                }
                else
                {
                    r = -1;
                }
            }

            switch (r)
            {
                case 0:
                    return UtilsCommons.AjaxReturnJson("0", "url错误，请重新打开此窗口操作！");
                case 1:
                    return UtilsCommons.AjaxReturnJson("1", "保存成功！");
                case -1:
                    return UtilsCommons.AjaxReturnJson("0", "省份名称重复！");
                default:
                    return UtilsCommons.AjaxReturnJson("0", "保存失败！");
            }
        }

    }
}
