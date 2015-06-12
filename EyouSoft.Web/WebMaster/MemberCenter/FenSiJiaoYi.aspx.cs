using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster.MemberCenter
{
    /// <summary>
    /// 会员粉丝交易信息
    /// </summary>
    public partial class FenSiJiaoYi : EyouSoft.Common.Page.WebmasterPageBase
    {
        #region attributes
        protected int PageSize = 20;
        protected int PageIndex = 1;

        /// <summary>
        /// 会员编号
        /// </summary>
        protected string HuiYuanId = string.Empty;
        /// <summary>
        /// 会员信息
        /// </summary>
        protected string HuiYuanXinXi = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            HuiYuanId = Utils.GetQueryStringValue("huiyuanid");
            if (string.IsNullOrEmpty(HuiYuanId)) Utils.RCWE("异常请求");

            InitInfo();
            InitRpt();
        }

        #region private members
        /// <summary>
        /// init info
        /// </summary>
        void InitInfo()
        {
            var info = new EyouSoft.BLL.OtherStructure.BMember().GetModel(HuiYuanId);
            if (info == null) return;
            HuiYuanXinXi = info.MemberName;
        }

        /// <summary>
        /// get chaxun info
        /// </summary>
        /// <returns></returns>
        EyouSoft.Model.MFenSiJiaoYiChaXunInfo GetChaXunInfo()
        {
            var info = new EyouSoft.Model.MFenSiJiaoYiChaXunInfo();
            info.FenSiId = Utils.GetQueryStringValue("fensiid");
            return info;
        }

        /// <summary>
        /// init rpt
        /// </summary>
        void InitRpt()
        {
            PageIndex = UtilsCommons.GetPagingIndex();
            int recordCount = 0;

            var chaXun = GetChaXunInfo();
            var items = new EyouSoft.BLL.OtherStructure.BMember().GetFenSiJiaoYis(HuiYuanId, PageSize, PageIndex, ref recordCount, chaXun);

            if (items != null && items.Count > 0)
            {
                rpt.DataSource = items;
                rpt.DataBind();

                FenYe.intPageSize = PageSize;
                FenYe.CurrencyPage = PageIndex;
                FenYe.intRecordCount = recordCount;
            }
            else
            {
                phEmpty.Visible = true;
            }
        }
        #endregion

        #region protected members
        /// <summary>
        /// 获取订单状态
        /// </summary>
        /// <param name="dingDanStatus"></param>
        /// <returns></returns>
        protected string GetDingDanStatus(object dingDanStatus)
        {
            var _dingDanStatus = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)dingDanStatus;
            string s = string.Empty;
            switch (_dingDanStatus)
            {
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理:
                    s = string.Format(" <span style='background-color:#00F;color:#FFF;'>订单审核</span>");
                    break;
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款:
                    s = string.Format(" <span style='background-color:#906;color:#FFF;'>等待付款</span>");
                    break;
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货:
                    s = string.Format(" <span style='background-color:#060;color:#FFF;'>付款成功，<br />请通知出行!</span>");
                    break;
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货:
                    s = string.Format(" <span  style='background-color:#F08C0C;color:#FFF;'>等待收货</span>");
                    break;
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利:
                    s = string.Format(" <span style='background-color:#23F111;color:#FFF;'>待返利</span>");
                    break;
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.交易完成:
                    s = string.Format(" <span style='background-color:#23F111;color:#FFF;'>交易完成</span>");
                    break;
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.取消订单:
                    s = string.Format(" <span style='background-color:rgb(162, 19, 230);color:#FFF;'>订单已取消</span>");
                    break;
                default:
                    break;
            }

            return s;
        }
        #endregion
    }
}
