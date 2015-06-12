using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Common.page;

namespace EyouSoft.WAP.Member
{
    public partial class TiXian : HuiYuanWapPageBase
    {
        protected string yuetishi = "";//余额提示
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("type") == "tixian") ApplyTiXian();
            if (HuiYuanInfo.TotalMoney >= 100)
            {
                yuetishi = "您最多能提现" + HuiYuanInfo.TotalMoney.ToString("f2") + "元";
            }
            else
            {
                yuetishi = "您的余额为" + HuiYuanInfo.TotalMoney.ToString("f2") + "元，暂不能提现";
            }
        }
        void ApplyTiXian()
        {
            EyouSoft.Model.MoneyStructure.MApplyTiXian Model = new EyouSoft.Model.MoneyStructure.MApplyTiXian();
            Model.BankNum = Utils.GetFormValue("ZhangHao");
            Model.JinE = Utils.GetInt(Utils.GetFormValue("TixianJinE"));
            Model.KaiHuBank = Utils.GetFormValue("KaihuHang");
            Model.KaiHuName = Utils.GetFormValue("KaiHuMing");
            Model.UserId = HuiYuanInfo.UserId;
            Model.BeiZhu = Utils.GetFormValue("beizhu");
            if (Model.JinE <= HuiYuanInfo.TotalMoney)
            {
                if (Model.JinE >= 100)
                {
                    bool Success = new EyouSoft.BLL.MoneyStructure.BApplyTiXian().Add(Model);
                    //申请成功，扣除用户剩余金额总金额

                    Utils.RCWE(UtilsCommons.AjaxReturnJson(Success == true ? "1" : "0", Success == true ? "申请成功,等待审核！" : "申请失败,请联系客服！"));
                }
                else
                {
                    Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "申请失败,提现金额必须大于100且为整数！"));
                }
            }
            else
            {
                Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "申请失败,您的账户余额小于您要提现的金额！"));
            }
        }
    }
}
