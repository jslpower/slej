using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.OtherStructure;
using EyouSoft.BLL.OtherStructure;
using Common.page;
namespace EyouSoft.WAP.Member
{
    public partial class ZengZhi : HuiYuanWapPageBase
    {
        #region 分页参数
        protected int pageIndex = 1, recordCount = 0, pageSize = 10;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "积分增值";
            if (HuiYuanInfo.UserId == "Guest" || HuiYuanInfo.UserId == "")
            {
                Response.Redirect("/Default.aspx");
            }

            if (!IsPostBack)
            {
                InitPage();
            }
        }

        protected void InitPage()
        {

            IList<MPayMentsInfo> list = new BPayMents().GetList(pageSize, pageIndex, ref recordCount, new MPaySearch() { MemID = HuiYuanInfo.UserId });

            if (list != null && list.Count > 0)
            {
                Repeater1.DataSource = list;
                Repeater1.DataBind();

            }
            YiDuiJiFen.Text = (new EyouSoft.BLL.OtherStructure.BJiFen().GetSumJiFen(HuiYuanInfo.UserId, EyouSoft.Model.Enum.JiFenDuiHuanStatus.审核通过)).ToString();
            DongJiJiFen.Text = (new EyouSoft.BLL.OtherStructure.BJiFen().GetSumJiFen(HuiYuanInfo.UserId, EyouSoft.Model.Enum.JiFenDuiHuanStatus.未审核)).ToString();
            KeYongJiFen.Text = (new EyouSoft.BLL.OtherStructure.BPayMents().GetHistoryRate(HuiYuanInfo.UserId) - Convert.ToInt32(YiDuiJiFen.Text) - Convert.ToInt32(DongJiJiFen.Text)).ToString();
        }
        /// <summary>
        /// 获取个人积分
        /// </summary>
        /// <returns></returns>
        protected string getSumJF()
        {
            return new BPayMents().GetHistoryRate(HuiYuanInfo.UserId).ToString();

        }
    }
}
