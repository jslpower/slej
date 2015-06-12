using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace EyouSoft.Web.Member
{
    /// <summary>
    /// 下级分销奖励
    /// </summary>
    public partial class XiaJiJiangLi : EyouSoft.Common.Page.HuiYuanPageBase
    {
        #region attributes
        /// <summary>
        /// 页记录数
        /// </summary>
        protected int PageSize = 10;
        /// <summary>
        /// 总记录数
        /// </summary>
        protected int PageIndex = 1;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitInfo();
            InitRpt();
        }

        #region private members
        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            var info = new EyouSoft.BLL.OtherStructure.BXiaJiFenXiaoTiCheng().GetHuiYuanXiaJiFenXiaoTiChengJinEInfo(HuiYuanInfo.UserId);

            if (info == null) return;

            var peiZhiInfo = new EyouSoft.BLL.OtherStructure.BKV().GetXiaJiFenXiaoJiangLiPeiZhi();

            StringBuilder s = new StringBuilder();

            s.AppendFormat("已结算下级分销奖励佣金：{0:F2}", info.YiShenQingYongJinJinE);
            s.AppendFormat("， 已结算金额：{0:F2}。<br />",info.YiShenQingJinE);
            s.AppendFormat("未结算下级分销奖励佣金：{0:F2}", info.WeiJieSuanYongJinJinE);
            s.AppendFormat("，当前下级分销奖励结算比例：{0}", peiZhiInfo.JieSuanBiLiBaiFenBi);
            s.AppendFormat("，可结算金额：{0:F2}。", info.WeiJieSuanYongJinJinE * peiZhiInfo.JieSuanBiLi);
            ltrJinEXinXi.Text = s.ToString();
        }

        /// <summary>
        /// init rpt
        /// </summary>
        void InitRpt()
        {
            PageIndex = UtilsCommons.GetPagingIndex();
            int recordCount = 0;
            var chaXun = new EyouSoft.Model.OtherStructure.MXiaJiFenXiaoTiChengChaXunInfo();
            chaXun.HuiYuanId = HuiYuanInfo.UserId;

            var items = new EyouSoft.BLL.OtherStructure.BXiaJiFenXiaoTiCheng().GetTiChengs(PageSize, PageIndex, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                string script = string.Format("fenYe.recordCount={0};fenYe.pageIndex={1};fenYe.pageSize={2};", recordCount, PageIndex, PageSize);
                RegisterScript(script);

                rpt.DataSource = items;
                rpt.DataBind();
            }
            else
            {
                phEmpty.Visible = true;
            }
        }
        #endregion
    }
}
