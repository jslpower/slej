using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace EyouSoft.Web.WebMaster
{
    /// <summary>
    /// 编辑线路区域
    /// </summary>
    public partial class AreaEdit : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string save = Utils.GetQueryStringValue("save");
            string areaid = Utils.GetQueryStringValue("areaid");
            string action = Utils.GetQueryStringValue("action").ToLower();

            if (save == "1")
            {
                Response.Clear();
                Response.Write(Save(action, areaid));
                Response.End();

                return;
            }

            if (!IsPostBack)
            {
                InitDropDownList();
                PageInit(areaid, action);
            }
        }

        private void PageInit(string areaid, string action)
        {
            if (action != "edit") return;

            var model = new BLL.OtherStructure.BSysAreaInfo().GetSysAreaModel(Utils.GetInt(areaid));

            if (model == null) return;

            txtAreaName.Text = model.AreaName;

            if (ddlType.Items.FindByValue(((int)model.RouteType).ToString()) != null)
                ddlType.Items.FindByValue(((int)model.RouteType).ToString()).Selected = true;
            if (!string.IsNullOrEmpty(model.ImgPath))
            {
                 StringBuilder uploadstr = new StringBuilder();
                 uploadstr.AppendFormat("<img height='75' width='100' alt='' class='addpic img' style='vertical-align:bottom' src='{0}' /><span style='vertical-align: bottom;'><img alt='' class='pand4' style='vertical-align: bottom;' onclick=\"LineAdd.DelImg(this)\" src='/images/webmaster/cha.gif' /><input type='hidden' name='hideimg' value='|{0}' /></span>", model.ImgPath);
                        this.lbUploadInfo.Text = uploadstr.ToString();
            }
            txtYinXiaoLJ.Text = model.AdvLink;
            txtYinXiaoWZ.Text = model.AdvTitle;
        }

        private void InitDropDownList()
        {
            var list = EnumObj.GetList(typeof(EyouSoft.Model.Enum.AreaType));

            ddlType.DataSource = list;
            ddlType.DataTextField = "Text";
            ddlType.DataValueField = "Value";
            ddlType.DataBind();
        }

        private string Save(string action, string areaid)
        {
            string[] imgUpload = Utils.GetFormValues(this.UploadControl1.ClientHideID);
            string[] oldimgUpload = Utils.GetFormValues("hideimg");
            var model = new Model.MSysArea
                {
                    AreaName = Utils.GetFormValue(txtAreaName.UniqueID),
                    RouteType = (Model.Enum.AreaType)Utils.GetInt(Utils.GetFormValue(ddlType.UniqueID)),
                    AdvLink = Utils.GetFormValue(txtYinXiaoLJ.UniqueID),
                    AdvTitle = Utils.GetFormValue(txtYinXiaoWZ.UniqueID),
                    
                };
            if (imgUpload.Length>0)
            {
                model.ImgPath = imgUpload[0].Split('|')[1];
            }
            else if (oldimgUpload.Length>0)
            {
                model.ImgPath = oldimgUpload[0].Split('|')[1];
            }
            int r = 0;
            var bll = new BLL.OtherStructure.BSysAreaInfo();
            if (action == "edit")
            {
                model.ID = Utils.GetInt(areaid);

                r = bll.UpdateSysArea(model);
            }
            else
            {
                r = bll.AddSysArea(model);
            }

            switch (r)
            {
                case 0:
                    return UtilsCommons.AjaxReturnJson("0", "url错误，请重新打开此窗口操作！");
                case 1:
                    return UtilsCommons.AjaxReturnJson("1", "保存成功！");
                case -1:
                    return UtilsCommons.AjaxReturnJson("0", "线路区域名称重复！");
                default:
                    return UtilsCommons.AjaxReturnJson("0", "保存失败！");
            }
        }
    }
}
