using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster.YouJi
{
    public partial class YouJiEdit : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected string shipinStyle = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
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
            if (Utils.GetInt(model.HuiYuanId.Trim()) == 0) Utils.RCWE("没有修改权限");
            txtTitle.Text = model.YouJiTitle;
            txtLink.Text = model.ShiPinLink;
            if (model.YouJiContent != null && model.YouJiContent.Count > 0)
            {
                txtInfo.Text = model.YouJiContent[0].XingChengContent;
            }
            //FenXiang1.SetPlanList = model.YouJiContent;
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
            model.HuiYuanId = UserInfo.UserId.ToString();
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
            string txtContent = Request.Form[txtInfo.UniqueID];
            //附件
            string files = Utils.GetFormValue("hide_Journey_file");

            if (txtContent.Length > 0)
            {

                EyouSoft.Model.WeiXin.XingCheng model = new EyouSoft.Model.WeiXin.XingCheng();
                model.XingChengContent = txtContent;
                if (files.Split('|').Length > 1)
                {
                    model.ImgFile = files.Split('|')[1];
                }
                list.Add(model);

            }
            return list;
        }
    }
}
