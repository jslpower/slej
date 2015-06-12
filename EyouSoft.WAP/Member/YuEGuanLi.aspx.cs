using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.page;
using EyouSoft.IDAL.MemberStructure;

namespace EyouSoft.WAP.Member
{
    public partial class YuEGuanLi : HuiYuanWapPageBase
    {
        BMember2 bll = new BMember2();
        protected void Page_Load(object sender, EventArgs e)
        {
            var list = bll.Get(HuiYuanInfo.UserId);
            decimal DJJinE = new EyouSoft.BLL.MoneyStructure.BApplyTiXian().GetDongJieJinE(HuiYuanInfo.UserId);
            DongJieJinE.Text = DJJinE.ToString("f2");
            if (list.TotalMoney != null)
            {
                KeYongJinE.Text = ShengYuJInE.Text = ((decimal)list.TotalMoney).ToString("f2");
            }
            else
            {
                KeYongJinE.Text = ShengYuJInE.Text = "0.00";
            }
        }
    }
}
