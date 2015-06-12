using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Common.page;
using EyouSoft.Common.Page;

namespace EyouSoft.WAP.Member
{
    public partial class TiXianList : HuiYuanWapPageBase
    {
        #region 页面参数
        protected int recordCount = 0;
        protected int pageSize = 20;
        protected int pageIndex = 1;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "E额宝提现明细";
            GetTiXianList();
        }
        /// <summary>
        /// 获取提现列表
        /// </summary>
        public void GetTiXianList()
        {
            EyouSoft.Model.MoneyStructure.MApplyTiXianSer Model = new EyouSoft.Model.MoneyStructure.MApplyTiXianSer();
            Model.UserId = HuiYuanInfo.UserId;
            pageIndex = UtilsCommons.GetPagingIndex();
            var list = new EyouSoft.BLL.MoneyStructure.BApplyTiXian().GetList(pageSize, pageIndex, "", ref recordCount, Model);
            if (list != null && list.Count > 0)
            {
                Repeater1.DataSource = list;
                Repeater1.DataBind();
            }
            else
            {
                Repeater1.DataSource = null;
                Repeater1.DataBind();
                XianShi.Text = "暂无提现记录!";
            }
        }
    }
}
