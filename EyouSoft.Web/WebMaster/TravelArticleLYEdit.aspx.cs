using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster
{
    public partial class TravelArticleLYEdit : EyouSoft.Common.Page.WebmasterPageBase
    {
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
                    Response.Write(PageSave(id));
                    Response.End();
                    break;
                default:
                    break;
            }

            if (!IsPostBack)
            {
                PageInit(id);
            }
        }

        private void PageInit(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                EyouSoft.Model.MTravelArticleLY model = new EyouSoft.BLL.OtherStructure.BTravelArticle().GetLiuYanModel(id);
                if (model != null)
                {
                    this.labLYRSJ.Text = model.Account + "(" + model.LiuYanShiJian + ")";
                    this.txtLiuYan.Text = model.LiuYanContet;
                    this.txtHuiFu.Text = model.HuiFuContet;
                }
            }
        }

        /// <summary>
        /// 保存或修改信息
        /// </summary>
        private string PageSave(string id)
        {
            string msg = string.Empty;
            EyouSoft.BLL.OtherStructure.BTravelArticle bll = new EyouSoft.BLL.OtherStructure.BTravelArticle();
            EyouSoft.Model.MTravelArticleLY model = new EyouSoft.Model.MTravelArticleLY();
            model.LiuYanId = id;
            model.HuiFuContet = Utils.GetFormValue(this.txtHuiFu.UniqueID);
            model.IsCheck = chk_shenhe.Checked;
            model.IssueTime = DateTime.Now;
            model.OperatorId = UserInfo.UserId.ToString();

            if (new EyouSoft.BLL.OtherStructure.BTravelArticle().UpdateLiuYan(model))
            {
                msg = Utils.AjaxReturnJson("1", "回复成功！");
            }
            else
            {
                msg = Utils.AjaxReturnJson("0", "回复失败！");
            }
            return msg;
        }
    }
}
