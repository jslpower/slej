using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.Member
{
    public partial class FenSiJiangLi : EyouSoft.Common.Page.HuiYuanPageBase
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
        protected decimal XiaJiYongJinZong = 0;
        protected decimal JiangJinZong = 0;
        protected decimal KeJieSuanZong = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            InitRpt();
        }

        #region private members

        /// <summary>
        /// init rpt
        /// </summary>
        void InitRpt()
        {
            //var info = new EyouSoft.BLL.OtherStructure.BXiaJiFenXiaoTiCheng().GetHuiYuanXiaJiFenXiaoTiChengJinEInfo(HuiYuanInfo.UserId);
            //if (info != null)
            //{
            //    var peiZhiInfo = new EyouSoft.BLL.OtherStructure.BKV().GetXiaJiFenXiaoJiangLiPeiZhi();

            //    YiJieSuan.Text = info.YiShenQingJinE.ToString("f2");
            //    WeiJieSuan.Text = (info.WeiJieSuanYongJinJinE * peiZhiInfo.JieSuanBiLi).ToString("f2");
            //    int shenqing = Convert.ToInt32(info.WeiJieSuanYongJinJinE * peiZhiInfo.JieSuanBiLi);
            //    if (shenqing >= 10)
            //    {
            //        KeShenQing.Text = (Convert.ToInt32(shenqing / 10) * 10).ToString();
            //    }
            //    else
            //    {
            //        KeShenQing.Text = "0";
            //    }

            //}
            //else
            //{
            //    YiJieSuan.Text = "0";
            //    WeiJieSuan.Text = "0";
            //    KeShenQing.Text = "0";
            //}
            PageIndex = UtilsCommons.GetPagingIndex();
            int recordCount = 0;
            var items = new EyouSoft.BLL.OtherStructure.BMember().GetFenSiJiaoYis(HuiYuanInfo.UserId, PageSize, PageIndex, ref recordCount, null);

            if (items != null && items.Count > 0)
            {
                string script = string.Format("fenYe.recordCount={0};fenYe.pageIndex={1};fenYe.pageSize={2};", recordCount, PageIndex, PageSize);
                RegisterScript(script);

                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].DingDanLeiXing != EyouSoft.Model.OtherStructure.DingDanType.团购订单)
                    {
                        XiaJiYongJinZong = XiaJiYongJinZong + items[i].YongJinJinE;
                        JiangJinZong = JiangJinZong + (items[i].YongJinJinE * items[i].JiangLiBi);
                        if (items[i].DingDanStatus == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.交易完成 || items[i].DingDanStatus == EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利)
                        {
                            KeJieSuanZong = KeJieSuanZong + (items[i].YongJinJinE * items[i].JiangLiBi);
                        }
                    }
                }

                rpt.DataSource = items;
                rpt.DataBind();
            }
            else
            {
                phEmpty.Visible = true;
            }
            var info = new EyouSoft.BLL.OtherStructure.BXiaJiFenXiaoTiCheng().GetHuiYuanXiaJiFenXiaoTiChengJinEInfo(HuiYuanInfo.UserId);
            if (info != null)
            {
                YiJieSuan.Text = info.YiShenQingJinE.ToString("f2");
                WeiJieSuan.Text = (info.ZongJinE - info.YiShenQingJinE).ToString("f2");
                if ((info.ZongJinE - info.YiShenQingJinE) >= 10)
                {
                    KeShenQing.Text = (Math.Floor((info.ZongJinE - info.YiShenQingJinE)/10)*10).ToString();
                }
                else
                {
                    KeShenQing.Text = "0";
                }
            }
            else
            {
                YiJieSuan.Text = "0";
                WeiJieSuan.Text = "0";
                KeShenQing.Text = "0";
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
            string website ="";
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
