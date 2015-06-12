using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.Enum;

namespace EyouSoft.Web.WebMaster.ScenicAndTicketManage
{
    /// <summary>
    /// 编辑景区门票
    /// </summary>
    public partial class TicketEdit : Common.Page.WebmasterPageBase
    {
        protected string StrStartDate = string.Empty;
        protected string StrEndDate = string.Empty;
        protected string IsFenXiao = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Utils.GetQueryStringValue("action").ToLower();
            string id = Utils.GetQueryStringValue("id");
            string save = Utils.GetQueryStringValue("save");
            string sid = Utils.GetQueryStringValue("sid");

            if (!string.IsNullOrEmpty(save))
            {
                Response.Clear();
                Response.Write(this.Save(action, id));
                Response.End();
            }

            if (!IsPostBack)
            {
                InitDropDownList();

                if (action == "edit")
                {
                    InitPage(id);
                }
                else
                {
                    if (!string.IsNullOrEmpty(sid))
                    {
                        if (ddlScenic.Items.FindByValue(sid) != null) ddlScenic.Items.FindByValue(sid).Selected = true;
                    }

                    if (UserInfo.LeiXing == WebmasterUserType.供应商用户)
                    {
                        ph_0_0.Visible = false;
                        ph_0_1.Visible = false;
                    }
                }
            }
        }

        /// <summary>
        /// 初始化下拉框
        /// </summary>
        private void InitDropDownList()
        {
            var list = EnumObj.GetList(typeof(Model.Enum.ScenicStructure.ScenicTicketsStatus));

            ddlState.DataSource = list;
            ddlState.DataTextField = "Text";
            ddlState.DataValueField = "Value";
            ddlState.DataBind();

            var list2 = new BLL.ScenicStructure.BScenicArea().GetScenicAreaListNoInterface(0, null);
            ddlScenic.DataSource = list2;
            ddlScenic.DataValueField = "ScenicId";
            ddlScenic.DataTextField = "ScenicName";
            ddlScenic.DataBind();

            ddlScenic.Items.Insert(0, new ListItem("请选择景区", "0"));
        }

        private void InitPage(string id)
        {
           if (UserInfo.LeiXing == WebmasterUserType.供应商用户)
            {
                ph_0_0.Visible = false;
                ph_0_1.Visible = false;
            }

            if (string.IsNullOrEmpty(id)) return;

            var model = new BLL.ScenicStructure.BScenicTickets().GetModel(id);

            if (model == null) return;

            if (ddlScenic.Items.FindByValue(model.ScenicId) != null) ddlScenic.Items.FindByValue(model.ScenicId).Selected = true;
            txtTypeName.Text = model.TypeName;
            txtEnName.Text = model.EnName;
            txtMenShiPrice.Text = model.RetailPrice == 0 ? string.Empty : model.RetailPrice.ToString("F2");
            txtWebSitePrice.Text = model.WebsitePrices == 0 ? string.Empty : model.WebsitePrices.ToString("F2");
            txtSettlementPrice.Text = model.DistributionPrice == 0 ? string.Empty : model.DistributionPrice.ToString("F2");
            txtMin.Text = model.Limit <= 0 ? string.Empty : model.Limit.ToString();
            if (model.StartTime.HasValue) StrStartDate = model.StartTime.Value.ToShortDateString();
            if (model.EndTime.HasValue) StrEndDate = model.EndTime.Value.ToShortDateString();
            txtDescription.Value = model.Description;
            txtSaleDescription.Value = model.SaleDescription;
            if (model.Status.HasValue && ddlState.Items.FindByValue(((int)model.Status.Value).ToString()) != null)
                ddlState.Items.FindByValue(((int)model.Status).ToString()).Selected = true;
            txtIndex.Value = model.CustomOrder.ToString();
            if (model.IsFenXiao) IsFenXiao = "1";
            txtNumber.Text = model.Number.ToString();

        }

        /// <summary>
        /// 获取表单值
        /// </summary>
        /// <returns></returns>
        private Model.ScenicStructure.MScenicTickets GetFormValue()
        {
            var model = new Model.ScenicStructure.MScenicTickets
                {
                    CustomOrder = Utils.GetInt(Utils.GetFormValue(txtIndex.UniqueID)),
                    Description = Utils.EditInputText(txtDescription.Value),
                    DistributionPrice = Utils.GetDecimal(Utils.GetFormValue(txtSettlementPrice.UniqueID)),
                    EndTime = Utils.GetDateTimeNullable(Utils.GetFormValue("txtEndDate")),
                    EnName = Utils.GetFormValue(txtEnName.UniqueID),
                    IssueTime = DateTime.Now,
                    LastUpdateTime = DateTime.Now,
                    Limit = Utils.GetInt(Utils.GetFormValue(txtMin.UniqueID)),
                    OperatorId = this.UserInfo.UserId.ToString(),
                     RetailPrice = Utils.GetDecimal(Utils.GetFormValue(txtMenShiPrice.UniqueID)),
                    SaleDescription = Utils.EditInputText(txtSaleDescription.Value),
                    ScenicId = Utils.GetFormValue(ddlScenic.UniqueID),
                    ScenicName = string.Empty,
                    StartTime = Utils.GetDateTimeNullable(Utils.GetFormValue("txtStartDate")),
                    Status = (Model.Enum.ScenicStructure.ScenicTicketsStatus)Utils.GetInt(Utils.GetFormValue(ddlState.UniqueID)),
                    TicketsId = string.Empty,
                    TypeName = Utils.GetFormValue(txtTypeName.UniqueID),
                     WebsitePrices = Utils.GetDecimal(Utils.GetFormValue(txtWebSitePrice.UniqueID)),
                    Number = Utils.GetInt(Utils.GetFormValue(txtNumber.UniqueID))
                };

            if (UserInfo.LeiXing == WebmasterUserType.供应商用户)
            {
                model.ScenicId = UserInfo.GysId;
            }

            model.IsFenXiao = Utils.GetFormValue("txtIsFenXiao") == "1";

            return model;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="action"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private string Save(string action, string id)
        {
            if (action == "edit" && string.IsNullOrEmpty(id)) return UtilsCommons.AjaxReturnJson("0", "url错误，请重新打开此窗口！");

            if (action == "add") id = string.Empty;

            var model = this.GetFormValue();
            model.TicketsId = id;

            var bll = new BLL.ScenicStructure.BScenicTickets();

            bool r = bll.ExistsTypeName(model.TypeName, model.TicketsId, model.ScenicId);
            if (r)
            {
                return UtilsCommons.AjaxReturnJson("0", "门票名称已经存在！");
            }

            if (action == "add")
            {
                r = bll.Add(model);
            }
            else if (action == "edit")
            {
                r = bll.Update(model);
            }

            return UtilsCommons.AjaxReturnJson(r ? "1" : "0", r ? "保存成功！" : "保存失败！");
        }
    }
}
