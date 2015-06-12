using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.BLL.OtherStructure;
using EyouSoft.Model;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster.Strategy
{
    public partial class StrategyEdit : EyouSoft.Common.Page.WebmasterPageBase
    {
        #region 页面变量
        BTravelStrategy bll = new BTravelStrategy();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Utils.GetQueryStringValue("tid");
            string dotype = Utils.GetQueryStringValue("dotype").Trim();
            string type = Utils.GetQueryStringValue("type").Trim();

            //Ajax
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
                InitDropDownList();
                PageInit(id, dotype);
            }
        }
        protected void PageInit(string id, string dotype)
        {
            if (id != "" && dotype != "add")
            {
                MTravelStrategy model = bll.GetModel(id);
                if (model != null)
                {
                    txt_gonglue.Text = model.TravelName;
                    txt_mudidi.Text = model.TravelDestination;
                    if (model.TravelDate != null)
                    {
                        txt_lvxingshijian.Text = model.TravelDate.Value.ToString("yyyy-MM-dd");
                    }
                    this.ddlThemeID.SelectedValue = model.ThemeID.ToString();
                    txt_lvxinghuafei.Text = model.TravelMoney.ToString("F2");
                    txt_jianyi.Text = model.TravelAdvice;
                    txt_neirong.Text = model.TravelContent;
                    this.hidOpLX.Value = ((int)model.OperatorLeiXing).ToString();
                    this.hidOp.Value = model.OperatorId.Trim();
                    this.ddlSort.SelectedValue = model.SortRule.ToString();

                    chk_shenhe.Checked = (bool)model.IsCheck;
                    chk_toutiao.Checked = (bool)model.IsHot;
                    chk_xianshi.Checked = (bool)model.IsFrontPage;

                    upload1.YuanFiles = new List<EyouSoft.Web.UserControl.MFileInfo>() { new EyouSoft.Web.UserControl.MFileInfo() { FileName = "图片", FilePath = model.ImgPath } };
                }
            }
        }

        /// <summary>
        /// 初始化主题
        /// </summary>
        private void InitDropDownList()
        {
            ddlThemeID.DataSource = new EyouSoft.BLL.OtherStructure.BTravelStrategyTheme().GetList(null);
            ddlThemeID.DataTextField = "ClassName";
            ddlThemeID.DataValueField = "ThemeId";
            ddlThemeID.DataBind();
            ddlThemeID.Items.Insert(0, new ListItem("请选择主题", ""));
        }

        protected string PageSave(string id, string dotype)
        {
            //t为true 新增，false 修改
            bool t = string.IsNullOrEmpty(id) && dotype == "add";

            string msg = string.Empty;
            MTravelStrategy model = new MTravelStrategy();
            #region 获取表单

            model.TravelID = id;
            model.TravelName = Utils.GetFormValue(txt_gonglue.UniqueID);
            model.TravelDestination = Utils.GetFormValue(txt_mudidi.UniqueID);
            if (!string.IsNullOrEmpty(Utils.GetFormValue(txt_lvxingshijian.UniqueID)))
            {
                model.TravelDate = Utils.GetDateTime(Utils.GetFormValue(txt_lvxingshijian.UniqueID));
            }
            model.TravelMoney = Utils.GetDecimal(Utils.GetFormValue(txt_lvxinghuafei.UniqueID));
            model.TravelAdvice = Utils.GetFormValue(txt_jianyi.UniqueID);
            model.TravelContent = Utils.GetFormValue(txt_neirong.UniqueID);
            model.SortRule = Utils.GetInt(Utils.GetFormValue(this.ddlSort.UniqueID));

            model.ThemeID = Utils.GetInt(Utils.GetFormValue(this.ddlThemeID.UniqueID));

            model.IsCheck = chk_shenhe.Checked;
            model.IsHot = chk_toutiao.Checked;
            model.IsFrontPage = chk_xianshi.Checked;
            model.IssueTime = DateTime.Now;
            model.OperatorId = string.IsNullOrEmpty(this.hidOp.Value.Trim()) ? UserInfo.UserId.ToString() : this.hidOp.Value.Trim();
            model.OperatorLeiXing = (EyouSoft.Model.Enum.OperatorLeiXing)Utils.GetInt(this.hidOpLX.Value, 1);

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

            #endregion

            bool result = false;
            if (t)
            {
                result = bll.Add(model);
            }
            else
            {
                model.TravelID = id;
                result = bll.Update(model);
            }
            switch (result)
            {
                case true:
                    msg = Utils.AjaxReturnJson("1", (t ? "新增" : "修改") + "成功");
                    break;
                case false:
                    msg = Utils.AjaxReturnJson("0", (t ? "新增" : "修改") + "失败");
                    break;
                default:
                    break;
            }
            return msg;

        }
    }
}
