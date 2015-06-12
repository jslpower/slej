using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster.ShangCheng
{
    public partial class LianMengLBE : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string selfID = Utils.GetQueryStringValue("id");
            if (!IsPostBack)
            {
                initPage(selfID);
            }
            if (Utils.GetQueryStringValue("save") == "save") BaoCun();
        }
        /// <summary>
        /// 保存
        /// </summary>
        void BaoCun()
        {
            var model = new EyouSoft.Model.MallStructure.MLianMengLeiBie();
            model.LeiBieMingCheng = Utils.GetFormValue(txtLeiBie.UniqueID);
            model.modelTp = (EyouSoft.Model.Enum.ModelTypes)Utils.GetInt(Utils.GetQueryStringValue("tp"));
            int result = 0;
            string dotype = Utils.GetQueryStringValue("dotype");
            if (dotype == "add")
            {
                result = new EyouSoft.BLL.MallStructure.BLianMeng().Insert(model);
            }
            else
            {
                model.LeiBieID = Utils.GetInt(Utils.GetQueryStringValue("id"));
                result = new EyouSoft.BLL.MallStructure.BLianMeng().Update(model);
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
            var model = new EyouSoft.BLL.MallStructure.BLianMeng().GetModelLB(Utils.GetInt(typeid));
            if (model != null)
            {

                txtLeiBie.Text = model.LeiBieMingCheng;

            }
        }
    }
}
