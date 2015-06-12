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
    public partial class FenSi : HuiYuanWapPageBase
    {
        protected string HuiYuanId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "粉丝信息";
            InitRpt();
        }
        void InitRpt()
        {
            int recordCount = 0;
            var chaXun = new EyouSoft.Model.MFenSiChaXunInfo();
            chaXun.FenSiId = Utils.GetQueryStringValue("fensiid");
            var items = new EyouSoft.BLL.OtherStructure.BMember().GetFenSis(HuiYuanInfo.UserId, 10, 1, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                ltrName.Text = items[0].HuiYuanXingMing;
                ltrUser.Text = items[0].HuiYuanYongHuMing;
                ltrMoblie.Text = items[0].HuiYuanShouJi;
                litWebSite.Text = items[0].HuiYuanWangZhanName;
                CreatTime.Text = items[0].ZhuCeShiJian.ToShortDateString();
                CherkTime.Text = Convert.ToDateTime(items[0].DaoQiShiJian).ToShortDateString();
                HuiYuanId = items[0].HuiYuanId;
            }
        }
    }
}
