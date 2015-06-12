using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Toolkit.DataProtection;

namespace EyouSoft.Web.WebMaster
{
   /// <summary>
   /// 编辑个人信息
   /// </summary>
   public partial class UserInfo : Common.Page.WebmasterPageBase
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         string save = Utils.GetQueryStringValue("save");
         if (!string.IsNullOrEmpty(save))
         {
            Save();
         }

         if (!IsPostBack)
         {
            InitPage();
         }
      }

      private void InitPage()
      {
         var model = new BLL.OtherStructure.BWebmaster().GetModel(this.UserInfo.UserId);

         if (model == null) return;

         ltrUserName.Text = model.Username;
         txtContactName.Value = model.Realname;
         txtQQ.Value = model.Fax;//传真字段保存着QQ信息
         txtMobile.Value = model.Mobile;
         txtTel.Value = model.Telephone;
         txtIsEnabled.Value = model.IsEnable.ToString();
      }

      private void Save()
      {
         var model = new Model.MWebmaster
             {
                Id = this.UserInfo.UserId,
                Fax = Utils.GetFormValue(txtQQ.UniqueID),//传真字段保存QQ信息
                Mobile = Utils.GetFormValue(txtMobile.UniqueID),
                Telephone = Utils.GetFormValue(txtTel.UniqueID),
                Realname = Utils.GetFormValue(txtContactName.UniqueID),
                IsEnable = Utils.GetInt(Utils.GetFormValue(txtIsEnabled.UniqueID)),
             };

         string pw = Utils.GetFormValue(txtPassWord.UniqueID);
         string cpw = Utils.GetFormValue(txtCFPassWord.UniqueID);
         if (!string.IsNullOrEmpty(pw) && pw == cpw)
         {
            model.Password = pw;
            model.MD5Password = new HashCrypto().MD5Encrypt(pw);
         }

         Common.Function.MessageBox.ShowAndRedirect(
             this,
             string.Format("保存{0}！", new BLL.OtherStructure.BWebmaster().Update(model) ? "成功" : "失败"),
             "/WebMaster/UserInfo.aspx");
      }
   }
}
