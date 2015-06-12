using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster
{
    public partial class LinkEdit : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dotype = Utils.GetQueryStringValue("dotype");
            string id = Utils.GetQueryStringValue("id");
            string type = Utils.GetQueryStringValue("type").Trim();

            switch (type)
            {
                case "save":
                    Response.Clear();
                    Response.Write(PageSave(id, dotype));
                    Response.End();
                    break;
                default:
                    break;
            }
            if (!IsPostBack)
            {
                PageInit(id, dotype);
            }
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dotype"></param>
        private void PageInit(string id, string dotype)
        {
            if (id != "" && dotype == "update")
            {
                EyouSoft.BLL.OtherStructure.BLink bll = new EyouSoft.BLL.OtherStructure.BLink();
                EyouSoft.Model.MLink model = bll.GetModel(id);
                if (model != null)
                {
                    this.txtLinkText.Value = model.LinkText;
                    this.txtLinkAddre.Text = !string.IsNullOrEmpty(model.LinkAddre) ? model.LinkAddre : "http://";
                    if (!string.IsNullOrEmpty(model.ImgPath))
                    {
                        upload1.YuanFiles = new List<EyouSoft.Web.UserControl.MFileInfo> { new EyouSoft.Web.UserControl.MFileInfo { FilePath = model.ImgPath, FileId = "-1", FileName = "已上传的图片" } };
                    }
                    this.txtSort.Text = model.SortRule.ToString();
                }
            }
        }
        private string PageSave(string id, string dotype)
        {
            //t为true 新增，false 修改
            bool t = string.IsNullOrEmpty(id) && dotype == "add";
            string msg = string.Empty;
            EyouSoft.BLL.OtherStructure.BLink bll = new EyouSoft.BLL.OtherStructure.BLink();
            EyouSoft.Model.MLink model = new EyouSoft.Model.MLink();
            model.LinkText = Utils.GetFormValue(this.txtLinkText.UniqueID);
            model.LinkAddre = Utils.GetFormValue(this.txtLinkAddre.UniqueID);
            model.SortRule = Utils.GetInt(Utils.GetFormValue(this.txtSort.UniqueID));
            model.IssueTime = DateTime.Now;
            var newFiles = upload1.Files;
            if (newFiles == null || !newFiles.Any())
            {
                var oldFiles = upload1.YuanFiles;
                if (oldFiles != null && oldFiles.Any())
                {
                    model.ImgPath = oldFiles[0].FilePath;
                }
                else
                {
                    model.ImgPath = string.Empty;
                }
            }
            else
            {
                model.ImgPath = newFiles[0].FilePath;
            }

            bool result = false;
            if (t)
            {
                result = bll.Add(model);
            }
            else
            {
                model.LinkID = id;
                result = bll.Update(model);
            }
            if (result)
                msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "1", (t ? "添加" : "修改") + "成功");
            else
                msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "0", (t ? "添加" : "修改") + "失败");
            return msg;
        }
    }
}
