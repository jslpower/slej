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
    /// 编辑城市
    /// </summary>
    public partial class CityEdit : Common.Page.WebmasterPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Utils.GetQueryStringValue("action").ToLower();
            int cid = Utils.GetInt(Utils.GetQueryStringValue("cid"));
            int pid = Utils.GetInt(Utils.GetQueryStringValue("pid"));
            string save = Utils.GetQueryStringValue("save");

            if (!string.IsNullOrEmpty(save))
            {
                Response.Clear();
                Response.Write(Save(action, cid));
                Response.End();
            }

            if (!IsPostBack)
            {
                InitDropDownList();

                if (action == "edit")
                {
                    this.InitPage(cid);
                }
                else
                {
                    if (ddlProvince.Items.FindByValue(pid.ToString()) != null)
                        ddlProvince.Items.FindByValue(pid.ToString()).Selected = true;
                }
            }
        }

        /// <summary>
        /// 初始化页面
        /// </summary>
        private void InitPage(int cId)
        {
            var model = new BLL.OtherStructure.BSysAreaInfo().GetSysCityModel(cId);
            if (model == null) return;

            txtCityName.Text = model.Name;
            if (ddlProvince.Items.FindByValue(model.ProvinceId.ToString()) != null)
                ddlProvince.Items.FindByValue(model.ProvinceId.ToString()).Selected = true;
        }

        /// <summary>
        /// 初始化省份
        /// </summary>
        private void InitDropDownList()
        {
            ddlProvince.DataSource = new BLL.OtherStructure.BSysAreaInfo().GetSysProvinceList(0, null);
            ddlProvince.DataTextField = "Name";
            ddlProvince.DataValueField = "ID";
            ddlProvince.DataBind();

            ddlProvince.Items.Insert(0, new ListItem("请选择省份", "0"));
        }

        private string Save(string action, int cid)
        {
            var model = new Model.MSysCity
                {
                    Name = Utils.GetFormValue(txtCityName.UniqueID),
                    ProvinceId = Utils.GetInt(Utils.GetFormValue(ddlProvince.UniqueID))
                };

            var bll = new BLL.OtherStructure.BSysAreaInfo();

            int r = 0;
            if (action == "edit")
            {
                model.Id = cid;
                if (!bll.ExistsSysCity(model))
                {
                    r = bll.UpdateSysCity(model) ? 1 : -2;
                }
                else
                {
                    r = -1;
                }
            }
            else
            {
                if (!bll.ExistsSysCity(model))
                {
                    r = bll.AddSysCity(model) ? 1 : -2;
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
                    return UtilsCommons.AjaxReturnJson("0", "城市名称重复！");
                default:
                    return UtilsCommons.AjaxReturnJson("0", "保存失败！");
            }
        }
    }
}
