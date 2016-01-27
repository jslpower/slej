using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.page;
using EyouSoft.Common;

namespace EyouSoft.WAP.CommonPage
{
    public partial class ajaxFenSiJiaoYi : HuiYuanWapPageBase
    {
        #region 分页参数
        protected int pageIndex = 1, recordCount = 0, pageSize = 10;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            InitRpt();
        }
        void InitRpt()
        {
            var chaXun = new EyouSoft.Model.MFenSiJiaoYiChaXunInfo();
            chaXun.FenSiId = Utils.GetQueryStringValue("fensiid");
            pageIndex = Utils.GetInt(Utils.GetQueryStringValue("pageindex"));
            int recordCount = 0;
            var items = new EyouSoft.BLL.OtherStructure.BMember().GetFenSiJiaoYis(HuiYuanInfo.UserId, 10, pageIndex, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                if (recordCount > (pageIndex - 1) * 10)
                {
                    rpt.DataSource = items;
                }
                else
                {
                    rpt.DataSource = null;
                }
                
                rpt.DataBind();
            }
        }
    }
}
