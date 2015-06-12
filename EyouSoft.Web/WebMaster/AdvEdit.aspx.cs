using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster
{
    public partial class AdvEdit : EyouSoft.Common.Page.WebmasterPageBase
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
            //绑定广告位置
            Array values = Enum.GetValues(typeof(EyouSoft.Model.Enum.AdvArea));
            foreach (var item in values)
            {
                int value = (int)Enum.Parse(typeof(EyouSoft.Model.Enum.AdvArea), item.ToString());
                string text = Enum.GetName(typeof(EyouSoft.Model.Enum.AdvArea), item);

                this.ddlAreaId.Items.Add(new ListItem() { Text = text, Value = value.ToString() });
            }
            this.ddlAreaId.Items[0].Selected = true;
            this.GongYSId.Value = "-1";
            if (id != "" && dotype == "update")
            {
                EyouSoft.BLL.OtherStructure.BSysAdv bll = new EyouSoft.BLL.OtherStructure.BSysAdv();
                EyouSoft.Model.MSysAdv model = bll.GetModel(Utils.GetInt(id));
                if (model != null)
                {
                    this.txtAdvTitle.Value = model.AdvTitle;
                    this.txtAdvLink.Text = model.AdvLink;
                    this.ddlAreaId.SelectedValue = ((int)model.AreaId).ToString();
                    if (!string.IsNullOrEmpty(model.ImgPath))
                    {
                        upload1.YuanFiles = new List<EyouSoft.Web.UserControl.MFileInfo> { new EyouSoft.Web.UserControl.MFileInfo { FilePath = model.ImgPath, FileId = "-1", FileName = "已上传的图片" } };
                    }
                    this.hidClick.Value = model.Click.ToString();
                    this.txtSort.Text = model.SortId.ToString();
                    this.GongYSId.Value = model.AgencyId;
                }
            }
        }
        private string PageSave(string id, string dotype)
        {
            //t为true 新增，false 修改
            bool t = string.IsNullOrEmpty(id) && dotype == "add";
            string msg = string.Empty;
            EyouSoft.BLL.OtherStructure.BSysAdv bll = new EyouSoft.BLL.OtherStructure.BSysAdv(); ;
            EyouSoft.Model.MSysAdv model = new EyouSoft.Model.MSysAdv();
            model.AdvTitle = Utils.GetFormValue(this.txtAdvTitle.UniqueID);
            model.AdvLink = Utils.GetFormValue(this.txtAdvLink.UniqueID);
            if (UserInfo.LeiXing == EyouSoft.Model.Enum.WebmasterUserType.代理商用户)
            {
                model.AreaId = EyouSoft.Model.Enum.AdvArea.首页轮换广告;
                model.AgencyId = UserInfo.GysId;
            }
            else
            {
                model.AreaId = (EyouSoft.Model.Enum.AdvArea)Utils.GetInt(Utils.GetFormValue(this.ddlAreaId.UniqueID));
                model.AgencyId = GongYSId.Value;
            }

            model.Click = Utils.GetInt(Utils.GetFormValue(this.hidClick.UniqueID));
            model.SortId = Utils.GetInt(Utils.GetFormValue(this.txtSort.UniqueID));
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
                result = bll.Add(model) > 0;
            }
            else
            {
                model.AdvID = Utils.GetInt(id);
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
