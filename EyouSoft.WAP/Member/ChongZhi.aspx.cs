using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.page;
using EyouSoft.Common;

namespace EyouSoft.WAP.Member
{
    public partial class ChongZhi : HuiYuanWapPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EyouSoft.Model.SSOStructure.MUserInfo m = null;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out m);
            if (!isLogin) Response.Redirect("/default.aspx");
            if (Utils.GetQueryStringValue("chongzhi") == "1") baocun();
        }
        /// <summary>
        /// 保存充值信息
        /// </summary>
        void baocun()
        {
            var model = new EyouSoft.Model.OtherStructure.MChongZhi();
            model.DingDanId = Guid.NewGuid().ToString();
            model.HuiYuanId = HuiYuanInfo.UserId;
            model.JinE = Utils.GetDecimal(Utils.GetFormValue("txtjine"));
            model.ZhiFuStatus = EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.未付款;
            int result = new EyouSoft.BLL.OtherStructure.BChongZhi().Add(model);

            if (result == 1)
            {
                ////发送短信
                //var duanXinInfo = new EyouSoft.Model.OtherStructure.MDuanXinInfo();
                //duanXinInfo.JieShouShouJi = HuiYuanInfo.Username;
                //duanXinInfo.NeiRong = "您好，您的E额宝帐户" + HuiYuanInfo.Username + "已充值成功，金额为：" + model.JinE + "元！E额宝帐户具有安全结算和余额增值的功能！欢迎使用！总机：400-6588-180【商旅e家】";

                //new EyouSoft.BLL.OtherStructure.BDuanXin().FaSong(duanXinInfo);
                Utils.RCWE(UtilsCommons.AjaxReturnJson(model.JinE.ToString("F0"), HuiYuanInfo.UserId, model.DingDanId));
            }
            else
            {
                Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "系统繁忙，稍后再试！", string.Empty));
            }
        }


    }
}
