using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Common.page;
using EyouSoft.Common.Page;
using EyouSoft.IDAL.MemberStructure;
using EyouSoft.BLL.OtherStructure;
using EyouSoft.Model.OtherStructure;

namespace EyouSoft.Web.Member
{
    public partial class UserTransaction : ClientModelViewPageBase<EyouSoft.Model.MemberStructure.WebModel.MMember2SearchModel>
    {

        protected int pageSize=20,pageIndex=1, RecordCount=0;
        public decimal mymoney = 0;
        BMember2 bll = new BMember2();
        BPayMents bllpay = new BPayMents();
        MPaySearch searchModel = new MPaySearch();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HuiYuanInfo.UserId == "Guest" || HuiYuanInfo.UserId == "")
            {
                Response.Redirect("/Default.aspx");
            }
            var list = bll.Get(HuiYuanInfo.UserId);
            decimal DJJinE = new EyouSoft.BLL.MoneyStructure.BApplyTiXian().GetDongJieJinE(HuiYuanInfo.UserId);
            DongjieJinE.Text = DJJinE.ToString("f2");
            if (list.TotalMoney != null)
            {
                mymoney = (decimal)list.TotalMoney;
            }
            else
            {
                mymoney = (decimal)0;
            }
        }

    }
}
