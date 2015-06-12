using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.page;

namespace EyouSoft.WAP.Member
{
    public partial class EBaoList : HuiYuanWapPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "充值记录";
            GetChongZhiList();
        }
        /// <summary>
        /// 获取充值记录
        /// </summary>
        public void GetChongZhiList()
        {
            var chaXun = new EyouSoft.Model.OtherStructure.MChongZhiChaXunInfo();
            chaXun.HuiYuanId = HuiYuanInfo.UserId;
            int RecordCount = 0;
            var items = new EyouSoft.BLL.OtherStructure.BChongZhi().GetChongZhis(10, 1, ref RecordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                Repeater1.DataSource = items;
                Repeater1.DataBind();
            }
            else
            {
                Repeater1.DataSource = null;
                Repeater1.DataBind();
                //XianShi.Text = "暂无充值记录!";
            }
        }
    }
}
