using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common.Page;
using EyouSoft.BLL.HotelStructure;
using EyouSoft.Model.HotelStructure;
using EyouSoft.Common;
namespace EyouSoft.Web.WebMaster.HotelManage
{
    public partial class HotelOrderMsg : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string tid = Utils.GetQueryStringValue("tid");
            string dotype = Utils.GetQueryStringValue("dotype").Trim();
            string type = Utils.GetQueryStringValue("type");
            //Ajax
            switch (type)
            {
                case "save":
                    Response.Clear();
                    Response.Write(PageSave(tid, dotype));
                    Response.End();
                    break;
                default:
                    break;
            }

            if (!IsPostBack)
            {
                PageInit();
            }
        }

        protected void PageInit()
        {
            this.txtLinkPerson.Value = UserInfo.Username;
            this.txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        protected string PageSave(string tid, string dotype)
        {
            string msg = string.Empty;
            MHotelTourCustomsAsk model = new MHotelTourCustomsAsk();
            #region 获取表单
            model.TourOrderID = Utils.GetInt(tid);
            model.AskName = Utils.GetFormValue(txtLinkPerson.UniqueID);
            if (!string.IsNullOrEmpty(Utils.GetFormValue(txtDate.UniqueID)))
            {
                model.AskTime = Utils.GetDateTime(Utils.GetFormValue(txtDate.UniqueID));
            }
            else
            {
                model.AskTime = DateTime.Now;
            }
            model.AskContent = Utils.GetFormValue(txtContent.UniqueID);
            #endregion

            bool result = new BHotelTourCustoms().AddAsk(model);
            switch (result)
            {
                case true:
                    msg = Utils.AjaxReturnJson("1", "新增成功");
                    break;
                case false:
                    msg = Utils.AjaxReturnJson("0", "新增失败");
                    break;
                default:
                    break;
            }
            return msg;

        }
    }
}
