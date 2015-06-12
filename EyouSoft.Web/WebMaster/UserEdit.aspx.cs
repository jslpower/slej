using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.Enum;
using EyouSoft.Toolkit.DataProtection;

namespace EyouSoft.Web.WebMaster
{
   /// <summary>
   /// 编辑用户信息
   /// </summary>
   public partial class UserEdit : Common.Page.WebmasterPageBase
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         string action = Utils.GetQueryStringValue("action");
         string save = Utils.GetQueryStringValue("save");
         string exists = Utils.GetQueryStringValue("exists");
         string un = Utils.GetQueryStringValue("un");
         int uid = Utils.GetInt(Utils.GetQueryStringValue("id"));
         if (!string.IsNullOrEmpty(save))
         {
            Response.Clear();
            Response.Write(this.Save());
            Response.End();
         }
         if (!string.IsNullOrEmpty(exists))
         {
            Response.Clear();
            Response.Write(this.Exists(un));
            Response.End();
         }

         if (!IsPostBack)
         {
            if (action == "edit")
            {
               txtUserName.ReadOnly = true;
               txtUserName.Attributes.Add("style", "background-color:#999999");
               InitPage(uid);
            }
         }
      }

      private void InitPage(int uid)
      {
         var model = new BLL.OtherStructure.BWebmaster().GetModel(uid);

         if (model == null) return;

         txtUserName.Text = model.Username;
         txtContactName.Value = model.Realname;
         txtQQ.Value = model.Fax;
         txtMobile.Value = model.Mobile;
         txtTel.Value = model.Telephone;
         ddlStateType.SelectedValue = model.IsEnable.ToString();


      }

      private string Exists(string un)
      {
         if (string.IsNullOrEmpty(un)) return UtilsCommons.AjaxReturnJson("0", "用户名为空！");

         bool r = this.ExistsUserName(un);

         return UtilsCommons.AjaxReturnJson(r ? "1" : "0", r ? "用户名已存在！" : "用户名可用！");
      }

      private string Save()
      {
         string action = Utils.GetQueryStringValue("action");
         int uid = Utils.GetInt(Utils.GetQueryStringValue("id"));

         if (action == "edit" && uid <= 0) return UtilsCommons.AjaxReturnJson("0", "url错误，请刷新后重试！");

         var model = new Model.MWebmaster
         {
            Fax = Utils.GetFormValue(txtQQ.UniqueID),//传真字段保存QQ信息。
            Mobile = Utils.GetFormValue(txtMobile.UniqueID),
            Telephone = Utils.GetFormValue(txtTel.UniqueID),
            Realname = Utils.GetFormValue(txtContactName.UniqueID),
            Username = Utils.GetFormValue(txtUserName.UniqueID),
            IsEnable = Utils.GetInt(Utils.GetFormValue(ddlStateType.UniqueID)),
         };

         string pw = Utils.GetFormValue(txtPassWord.UniqueID);
         string cpw = Utils.GetFormValue(txtCFPassWord.UniqueID);
         if (!string.IsNullOrEmpty(pw) && pw == cpw)
         {
            model.Password = pw;
            model.MD5Password = new HashCrypto().MD5Encrypt(pw);
         }

         model.LeiXing = Utils.GetInt(Utils.GetQueryStringValue("leixing"));
         model.GysId = Utils.GetQueryStringValue("gysid");

         bool r = false;
         var bll = new BLL.OtherStructure.BWebmaster();
         if (action == "edit")
         {
            model.Id = uid;

            r = bll.Update(model);
         }
         else
         {
            model.CreateTime = DateTime.Now;
            model.IsAdmin = (int)Is.是;
            model.Permissions = string.Empty;

            if (this.ExistsUserName(model.Username)) return UtilsCommons.AjaxReturnJson("0", "用户名已存在！");

            r = bll.Add(model);
         }

         return UtilsCommons.AjaxReturnJson(r ? "1" : "0", string.Format("保存{0}！", r ? "成功" : "失败"));
      }

      private bool ExistsUserName(string un)
      {
         if (string.IsNullOrEmpty(un)) return false;

         return new BLL.OtherStructure.BWebmaster().ExistsUserName(un, -1);
      }
   }
}
