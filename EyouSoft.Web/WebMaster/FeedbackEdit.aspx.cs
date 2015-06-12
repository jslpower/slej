using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster
{
    public partial class FeedbackEdit : System.Web.UI.Page
    {
        string dotype = Utils.GetQueryStringValue("dotype");
        string id = Utils.GetQueryStringValue("id");
        string type = Utils.GetQueryStringValue("type").Trim();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageInit(id, dotype);
            }
        }

         /// <summary>
         /// 初始化
         /// </summary>
         /// 
         /// <param name="id"></param>
         /// <param name="dotype"></param>
         private void PageInit(string id, string dotype)
         {
             if (id != "" && dotype == "update")
             {
                 EyouSoft.BLL.OtherStructure.BFeedback bll = new EyouSoft.BLL.OtherStructure.BFeedback();
                 EyouSoft.Model.OtherStructure.MFeedback model = bll.GetModel(id);
                 if (model != null)
                 {
                     this.RadioButtonList1.SelectedValue = model.MessageType;
                     this.textarea.Text = model.MsgContent;
                     this.textfield.Text = model.Name;
                     this.textfield2.Text = model.Email;
                     this.textfield3.Text = model.Tel;
                 }
             }
         }


        private string PageSave(string id, string dotype)
        {
            //t为true 新增，false 修改
            //t为true 新增，false 修改
            bool t = string.IsNullOrEmpty(id) && dotype == "add";
            string msg = string.Empty;
            EyouSoft.BLL.OtherStructure.BFeedback bll = new EyouSoft.BLL.OtherStructure.BFeedback();
            EyouSoft.Model.OtherStructure.MFeedback model = new EyouSoft.Model.OtherStructure.MFeedback();
            model.MessageType = this.RadioButtonList1.SelectedValue;
            model.MsgContent = this.textarea.Text;
            model.Name = this.textfield.Text;
            model.Email = this.textfield2.Text;
            model.Tel = this.textfield3.Text;

            bool result = false;
            if (t)
            {
                result = bll.Add(model);
            }
            else
            {
                model.ID = int.Parse(id);
                result = bll.Update(model);
            }
            if (result)
                msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "1", (t ? "添加" : "修改") + "成功");
            else
                msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "0", (t ? "添加" : "修改") + "失败");
            return msg;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Response.Clear();
            Response.Write(PageSave(id, dotype));
            Response.End();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.close();</script>"); 
        }
    }
}
