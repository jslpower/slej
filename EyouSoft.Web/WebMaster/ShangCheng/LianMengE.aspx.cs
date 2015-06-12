using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster.ShangCheng
{
    public partial class LianMengE : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string selfID = Utils.GetQueryStringValue("id");
            if (!IsPostBack)
            {
                initDDL();
                initPage(selfID);
            }
            if (Utils.GetQueryStringValue("save") == "save") BaoCun();
        }
        /// <summary>
        /// 保存
        /// </summary>
        void BaoCun()
        {
            var model = new EyouSoft.Model.MallStructure.MLianMeng();
            model.SiteName = Utils.GetFormValue(txtSiteName.UniqueID);
            model.SiteUrl = Utils.GetFormValue(txtSiteUrl.UniqueID);
            model.LieBieID = Utils.GetInt(Utils.GetFormValue(ddlType.UniqueID));
            string file = Utils.GetFormValue(UploadControl1.ClientHideID);
            if (!string.IsNullOrEmpty(file) && file.Split('|').Length > 0)
            {
                model.ImgFile = file.Split('|')[1];
            }
            else
            {
                model.ImgFile = Utils.GetFormValue("hidfiles");
            }
            model.OperatorID = UserInfo.UserId.ToString();
            model.KeyWord = "";

            int result = 0;
            string dotype = Utils.GetQueryStringValue("dotype");
            if (dotype == "add")
            {
                result = new EyouSoft.BLL.MallStructure.BLianMeng().Insert(model);
            }
            else
            {
                model.ID = Utils.GetInt(Utils.GetQueryStringValue("id"));
                result = new EyouSoft.BLL.MallStructure.BLianMeng().Update(model);
            }
            Response.Clear();
            if (result == 1)
            {
                Response.Write(UtilsCommons.AjaxReturnJson(result == 1 ? "1" : "0", dotype == "add" ? "添加成功" : "修改成功"));
            }
            else
            {
                Response.Write(UtilsCommons.AjaxReturnJson(result == 1 ? "1" : "0", dotype == "add" ? "添加失败" : "修改失败"));
            }

            Response.End();

        }
        /// <summary>
        /// 初始化页面
        /// </summary>
        /// <param name="typeid"></param>
        void initPage(string typeid)
        {
            var model = new EyouSoft.BLL.MallStructure.BLianMeng().GetModel(Utils.GetInt(typeid));
            if (model != null)
            {

                txtSiteName.Text = model.SiteName;
                txtSiteUrl.Text = model.SiteUrl;
                if (ddlType.Items.FindByValue(model.LieBieID.ToString()) != null)
                {
                    ddlType.Items.FindByValue(model.LieBieID.ToString()).Selected = true;
                }
                if (!string.IsNullOrEmpty(model.ImgFile))
                {
                    litFiles.Text = string.Format("<input type=\"hidden\" id=\"hidfiles\" name=\"hidfiles\" value=\"{0}\" /><a target=\"_blank\" href=\"{0}\">查看图片</a>", model.ImgFile);
                }
            }
        }
        /// <summary>
        /// 初始化站点类别
        /// </summary>
        void initDDL()
        {
            int refCount = 0;
         EyouSoft.Model.MallStructure.MLianMengLeiBieSer ser=   new EyouSoft.Model.MallStructure.MLianMengLeiBieSer() ;
         if (!string.IsNullOrEmpty(Utils.GetQueryStringValue("mt")))
         {
             ser.modelTp = (EyouSoft.Model.Enum.ModelTypes)Utils.GetInt(Utils.GetQueryStringValue("mt"));
         }
            var ls = new EyouSoft.BLL.MallStructure.BLianMeng().GetList(10000, 1, ref refCount, ser);
            if (ls != null && ls.Count > 0)
            {
                ddlType.DataTextField = "LeiBieMingCheng";
                ddlType.DataValueField = "LeiBieID";
                ddlType.DataSource = ls;
                ddlType.DataBind();
            }
            ddlType.Items.Insert(0, new ListItem() { Text = "请选择", Value = "" });
        }

    }
}
