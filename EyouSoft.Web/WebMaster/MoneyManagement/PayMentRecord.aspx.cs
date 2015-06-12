using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.OtherStructure;
using EyouSoft.BLL.OtherStructure;

namespace EyouSoft.Web.WebMaster.MoneyManagement
{
    public partial class PayMentRecord : Common.Page.WebmasterPageBase
    {
        #region 分页参数
        protected int pageIndex;
        protected int recordCount;
        protected int pageSize = 20;
        #endregion
        BPayMents bll = new BPayMents();
        MPayMentsInfo model = new MPayMentsInfo();
        MPaySearch searchModel = new MPaySearch();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitPage();
            }

            string Mname = Utils.GetQueryStringValue("mname");

        }

        protected void InitPage()
        {

            pageIndex = UtilsCommons.GetPagingIndex();
            searchModel.Mname = Utils.GetQueryStringValue("mname");
            searchModel.StartDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("startE"));
            searchModel.EndDate = Utils.GetDateTimeNullable(Utils.GetQueryStringValue("endE"));

            IList<MPayMentsInfo> list = bll.GetList(pageSize, pageIndex, ref recordCount, searchModel);

            if (list.Count > 0 && list != null)
            {
                rptList.DataSource = list;
                rptList.DataBind();
                BindExportPage();
            }
            else
            {
                litNoMsg.Text = "<tr><td align='center' colspan='10'>暂无数据</td></tr>";
            }
        }

        #region 绑定分页控件
        /// <summary>
        /// 绑定分页控件
        /// </summary>
        protected void BindExportPage()
        {
            this.ExporPageInfoSelect1.intPageSize = pageSize;
            this.ExporPageInfoSelect1.CurrencyPage = pageIndex;
            this.ExporPageInfoSelect1.intRecordCount = recordCount;
        }

        protected string GetMemberName(string memberID)
        {
            string ReturnValue;
            EyouSoft.IDAL.MemberStructure.BMember2 bllMember = new EyouSoft.IDAL.MemberStructure.BMember2();
            var Info = bllMember.Get(memberID);
            if (Info != null)
            {
                ReturnValue = Info.MemberName;

            }
            else
            {
                ReturnValue = "";
            }
            return ReturnValue;
        }
        ///// <summary>
        ///// 获取个人总积分
        ///// </summary>
        ///// <param name="memberid">会员编号</param>
        ///// <returns></returns>
        //protected string getSumJF(string memberid)
        //{
        //    return new BPayMents().GetHistoryRate(memberid).ToString();

        //}
        #endregion
    }
}
