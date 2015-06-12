using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.OtherStructure;
using EyouSoft.BLL.OtherStructure;

namespace EyouSoft.Web.Member
{
    public partial class ZengZhi : EyouSoft.Common.Page.HuiYuanPageBase
    {
        #region 分页参数
        protected int pageIndex = 1, recordCount = 0, pageSize = 10;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
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

            pageIndex = UtilsCommons.GetPagingIndex();


            IList<MPayMentsInfo> list = new BPayMents().GetList(pageSize, pageIndex, ref recordCount, new MPaySearch() { MemID = HuiYuanInfo.UserId });

            UtilsCommons.Paging(pageSize, ref pageIndex, recordCount);
            string pagingScript = "pagingConfig.pageSize={0};pagingConfig.pageIndex={1};pagingConfig.recordCount={2};";
            if (list != null && list.Count > 0)
            {
                Repeater1.DataSource = list;
                Repeater1.DataBind();

            }

            else
            {
                XianShi.Text = "暂无数据";
            }
            YiDuiJiFen.Text = (new EyouSoft.BLL.OtherStructure.BJiFen().GetSumJiFen(HuiYuanInfo.UserId, EyouSoft.Model.Enum.JiFenDuiHuanStatus.审核通过)).ToString();
            DongJiJiFen.Text = (new EyouSoft.BLL.OtherStructure.BJiFen().GetSumJiFen(HuiYuanInfo.UserId, EyouSoft.Model.Enum.JiFenDuiHuanStatus.未审核)).ToString();
            KeYongJiFen.Text = (new EyouSoft.BLL.OtherStructure.BPayMents().GetHistoryRate(HuiYuanInfo.UserId) - Convert.ToInt32(YiDuiJiFen.Text) - Convert.ToInt32(DongJiJiFen.Text)).ToString();
            RegisterScript(string.Format(pagingScript, pageSize, pageIndex, recordCount));
        }

        /// <summary>
        /// 获取会员姓名
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        protected string GetMemberName(string memberID)
        {
            var Info = new EyouSoft.IDAL.MemberStructure.BMember2().Get(memberID);
            if (Info == null) return "";
            return Info.MemberName;
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
