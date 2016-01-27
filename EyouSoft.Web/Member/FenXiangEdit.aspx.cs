using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.page;
using EyouSoft.Model.WeiXin;
using EyouSoft.Common;
using EyouSoft.BLL.OtherStructure;

namespace EyouSoft.Web.Member
{
    public partial class FenXiangEdit : EyouSoft.Common.Page.HuiYuanPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            EyouSoft.Model.SSOStructure.MUserInfo m = null;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out m);
            if (!isLogin) Response.Redirect("/default.aspx");

            string dotype = Utils.GetQueryStringValue("dotype");
            string id = Utils.GetQueryStringValue("youjid");
            string type = Utils.GetQueryStringValue("type").Trim();
            if (type == "save")
            {
                pageSave(id, dotype);
            }
            if (dotype != "add")
            {
                initPage(id);
            }
        }


        void initPage(string id)
        {
            var model = new EyouSoft.BLL.OtherStructure.BYouJi().GetModel(id);
            if (model == null) Utils.RCWE("数据异常");
            txtTitle.Text = model.YouJiTitle;
            txtLink.Text = model.ShiPinLink;
            FenXiang1.SetPlanList = model.YouJiContent;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dotype"></param>
        void pageSave(string id, string dotype)
        {
            //t为true 新增，false 修改
            bool t = string.IsNullOrEmpty(id) && dotype == "add";

            var model = new EyouSoft.Model.WeiXin.MYouJi();
            model.HuiYuanId = HuiYuanInfo.UserId.ToString();
            model.YouJiTitle = Utils.GetFormValue(txtTitle.UniqueID);
            model.YouJiType = EyouSoft.Model.Enum.YouJiLeiXing.图文分享;

            model.ShiPinLink = Utils.GetFormValue(txtLink.UniqueID);
            model.YouJiContent = GetXingChengList();

            bool result = false;
            if (t)
            {
                result = new EyouSoft.BLL.OtherStructure.BYouJi().Add(model);
            }
            else
            {
                model.YouJiId = id;
                result = new EyouSoft.BLL.OtherStructure.BYouJi().UpdateModel(model);
            }
            if (result) Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "操作成功"));
            Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "操作失败"));

        }


        /// <summary>
        /// 获得计划行程集合
        /// </summary>
        /// <returns></returns>
        public List<EyouSoft.Model.WeiXin.XingCheng> GetXingChengList()
        {

            List<EyouSoft.Model.WeiXin.XingCheng> list = new List<EyouSoft.Model.WeiXin.XingCheng>();
            //行程内容
            string[] txtContent = Request.Form.GetValues("txtContent");
            //附件
            string[] files = Utils.GetFormValues("hide_Journey_file");

            if (txtContent.Length > 0)
            {
                for (int i = 0; i < txtContent.Length; i++)
                {
                    EyouSoft.Model.WeiXin.XingCheng model = new EyouSoft.Model.WeiXin.XingCheng();
                    model.XingChengContent = Utils.EditInputText(txtContent[i]);
                    if (files[i].Split('|').Length > 1)
                    {
                        model.ImgFile = files[i].Split('|')[1];
                    }
                    list.Add(model);
                }
            }
            return list;
        }
    }
}
