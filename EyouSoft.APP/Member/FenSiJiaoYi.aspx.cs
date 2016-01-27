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
    public partial class FenSiJiaoYi : HuiYuanWapPageBase
    {
        protected string fensiid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "粉丝交易";
            InitRpt();
        }
        EyouSoft.Model.MFenSiJiaoYiChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.MFenSiJiaoYiChaXunInfo();
            info.FenSiId = Utils.GetQueryStringValue("fensiid");
            fensiid = info.FenSiId;
            if (string.IsNullOrEmpty(fensiid))
            {
                Response.Redirect("/Member/FenSi.aspx");
            }
            return info;
        }
        void InitRpt()
        {
            int recordCount = 0;
            var chaXun = GetChaXunInfo();
            var items = new EyouSoft.BLL.OtherStructure.BMember().GetFenSiJiaoYis(HuiYuanInfo.UserId, 10, 1, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                
                rpt.DataSource = items;
                rpt.DataBind();
            }
        }
    }
}
