using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster.ShangCheng
{
    public partial class TypeEdit : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string selfID = Utils.GetQueryStringValue("id");
            if (Utils.GetQueryStringValue("type") == "1")
            {
                SecondType.Visible = true;
            }
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
            var model = new EyouSoft.Model.MallStructure.MShangChengLeiBie();
            model.TypeName = Utils.GetFormValue(txtLeiBie.UniqueID);
            model.ParentID = Utils.GetInt(Utils.GetFormValue(ddlLeiBie.UniqueID));
            model.TypeDesc = Utils.GetFormValue(txtMiaoShu.UniqueID);
            model.OperatorName = UserInfo.ContactName;
            model.OperatorID = UserInfo.UserId;


            int result = 0;
            string dotype = Utils.GetQueryStringValue("dotype");
            if (dotype == "add")
            {
                result = new EyouSoft.BLL.MallStructure.BShangChengXiLie().Insert(model);
            }
            else
            {
                model.TypeID = Utils.GetInt(Utils.GetQueryStringValue("id"));
                result = new EyouSoft.BLL.MallStructure.BShangChengXiLie().Update(model);
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
            var model = new EyouSoft.BLL.MallStructure.BShangChengXiLie().GetModel(Utils.GetInt(typeid));
            if (model != null)
            {
                txtLeiBie.Text = model.TypeName;
                txtMiaoShu.Text = model.TypeDesc;
                if (ddlLeiBie.Items.FindByValue(model.ParentID.ToString()) != null)
                    ddlLeiBie.Items.FindByValue(model.ParentID.ToString()).Selected = true;

            }
        }
        /// <summary>
        /// 绑定分类
        /// </summary>
        void initDDL()
        {
            var typeList = new EyouSoft.BLL.MallStructure.BShangChengXiLie().GetList(new EyouSoft.Model.MallStructure.MShangChengLeiBieSer() { }, true);
            if (typeList != null && typeList.Count > 0)
            {
                this.ddlLeiBie.DataTextField = "TypeName";
                this.ddlLeiBie.DataValueField = "TypeID";
                this.ddlLeiBie.DataSource = typeList;
                this.ddlLeiBie.DataBind();
            }
            ddlLeiBie.Items.Insert(0, new ListItem() { Text = "请选择", Value = "" });

        }
    }
}
