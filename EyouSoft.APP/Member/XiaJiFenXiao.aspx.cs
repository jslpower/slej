using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using Common.page;

namespace EyouSoft.WAP.Member
{
    public partial class XiaJiFenXiao : HuiYuanWapPageBase
    {
        #region attributes
        /// <summary>
        /// 页记录数
        /// </summary>
        protected int PageSize = 10;
        /// <summary>
        /// 页序号
        /// </summary>
        protected int PageIndex = 1;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "下级分销奖励";
            InitRpt();
        }

        #region private members

        /// <summary>
        /// init rpt
        /// </summary>
        void InitRpt()
        {
            int recordCount = 0;
            var items = new EyouSoft.BLL.OtherStructure.BMember().GetFenSiJiaoYis(HuiYuanInfo.UserId, PageSize, PageIndex, ref recordCount, null);

            if (items != null && items.Count > 0)
            {
                rpt.DataSource = items;
                rpt.DataBind();
            }
            var info = new EyouSoft.BLL.OtherStructure.BXiaJiFenXiaoTiCheng().GetHuiYuanXiaJiFenXiaoTiChengJinEInfo(HuiYuanInfo.UserId);
            if (info != null)
            {
                YiJieSuan.Text = info.YiShenQingJinE.ToString("f2");
                WeiJieSuan.Text = (info.ZongJinE - info.YiShenQingJinE).ToString("f2");
                if ((info.ZongJinE - info.YiShenQingJinE) >= 10)
                {
                    KeShenQing.Text = (Math.Floor((info.ZongJinE - info.YiShenQingJinE) / 10) * 10).ToString();
                }
                else
                {
                    KeShenQing.Text = "0.00";
                }
                ZongJInE.Text = info.ZongJinE.ToString("f2");
            }
            else
            {
                YiJieSuan.Text = "0.00";
                WeiJieSuan.Text = "0.00";
                KeShenQing.Text = "0.00";
                ZongJInE.Text = "0.00";
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
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款:
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货:
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货:
                    s = string.Format(" <span style='background-color:rgb(162, 19, 230);color:#FFF;'>暂未消费</span>");
                    break;
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利:
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.交易完成:
                    s = string.Format(" <span style='background-color:#23F111;color:#FFF;'>已消费</span>");
                    break;
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.取消订单:
                    s = string.Format(" <span style='background-color:rgb(162, 19, 230);color:#FFF;'>暂未消费</span>");
                    break;
                default:
                    break;
            }

            return s;
        }
        /// <summary>
        /// 获取订单状态
        /// </summary>
        /// <param name="dingDanStatus"></param>
        /// <returns></returns>
        protected string GetIsXiaoFei(object dingDanStatus)
        {
            var _dingDanStatus = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)dingDanStatus;
            string s = "0";
            switch (_dingDanStatus)
            {

                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利:
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.交易完成:
                    s = "1";
                    break;
                default:
                    break;
            }

            return s;
        }
        /// <summary>
        /// 获取代理商网站
        /// </summary>
        /// <param name="dailiid"></param>
        /// <returns></returns>
        protected string GetWebSite(object dailiid)
        {
            string website = "";
            if (dailiid != null && !string.IsNullOrEmpty(dailiid.ToString()))
            {
                var list = new EyouSoft.IDAL.AccountStructure.BSellers().GetWebSiteName(dailiid.ToString());
                if (list != null)
                {
                    website = list.Website;
                }
            }
            return website;
        }
        /// <summary>
        /// 获取会员名字
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        protected string GetMember(object userid)
        {
            string username = "";
            if (userid != null && !string.IsNullOrEmpty(userid.ToString()))
            {
                var list = new EyouSoft.IDAL.MemberStructure.BMember2().Get(userid.ToString());
                if (list != null)
                {
                    username = list.MemberName;
                }
            }
            return username;
        }
        #endregion
    }
}
