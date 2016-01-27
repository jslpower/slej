using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using EyouSoft.Common;
using Common.page;
using EyouSoft.IDAL.AccountStructure;
using EyouSoft.Model.OtherStructure;

namespace EyouSoft.WAP.Member
{
    public partial class ZiZuTuanOrderXX : HuiYuanWapPageBase
    {
        BSellers bsells = new BSellers();
        EyouSoft.Model.AccountStructure.MSellers mseller = new EyouSoft.Model.AccountStructure.MSellers();
        protected bool isAgency = true;//判断是否为分销商、免费分销商、员工，1为true
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "单团报价订单";
            if (!Page.IsPostBack)
            {
                PageInit();
            }
        }
        private void PageInit()
        {
            if (HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.免费代理 || HuiYuanInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
            {
                isAgency = true;
            }
            string OrderId = Utils.GetQueryStringValue("orderid");
            if (string.IsNullOrEmpty(OrderId)) RECW("请求异常");
            string type = Utils.GetQueryStringValue("type");
            var order = new EyouSoft.BLL.XianLuStructure.BZiZuTuan().GetInfo(OrderId);
            if (order == null) RECW("请求异常");
            OrderCode.Text = order.OrderCode;
            XianLuName.Text = order.XianLuName;
            ChufaTime.Text = Convert.ToDateTime(order.ChuFaTime).ToString("yyyy-MM-dd");
            RenShu.Text = "该团为" + order.ChengTuanNum + "人团，成人人数" + order.RenShu + "人,儿童人数" + order.ErTongNum + "人";
            CarMoney.Text = Convert.ToDecimal(order.CarMoney).ToString("f2");
            DaoYouNum.Text = order.DaoYouNum.ToString();
            DiPeiDaoYouNum.Text = order.DiPeiDaoYouNum.ToString();
            DiPeiFei.Text = Convert.ToDecimal(order.DiPeiRJJia).ToString("f2");
            DaoYouFei.Text = Convert.ToDecimal(order.QuanPeiRJJia).ToString("f2");
            ZaoCanNum.Text = order.ZaoCanNum.ToString();
            ZaoCanMoney.Text = Convert.ToDecimal(order.ZaoCanJia).ToString("f2");
            WuCanNum.Text = order.WuCanNum.ToString();
            WuCanMoney.Text = Convert.ToDecimal(order.WuCanJia).ToString("f2");
            WanCanMoney.Text = Convert.ToDecimal(order.WanCanJia).ToString("f2");
            WanCanNum.Text = order.WanCanNum.ToString();
            CanWuFei.Text = Convert.ToDecimal(order.CanWuJia).ToString("f2");
            if (!string.IsNullOrEmpty(order.BaoXian))
            {
                BaoXian.Text = "增加<span style=\"color:red\">" + order.BaoXian + "</span>，投保" + order.BaoXianDay + "天，共" + Convert.ToDecimal(order.BXJiaGe).ToString("f2") + "元, 其中人身保险人均" + Convert.ToDecimal(order.RSBXJiaGe).ToString("f2") + "元，交通保险人均" + Convert.ToDecimal(order.JTBXJiaGe).ToString("f2") + "元/天";
            }
            else
            {
                BaoXian.Text = "没有参保";
            }
            ZuCheFei.Text = Convert.ToDecimal(order.ZCMoney).ToString("f2");
            ZongMoney.Text = Convert.ToDecimal(order.ZongMOney).ToString("f2");
            ChengRenJia.Text = Convert.ToDecimal(order.CRJiage).ToString("f2");
            ETJia.Text = Convert.ToDecimal(order.ETJiage).ToString("f2");
            AgencyJinE.Text = Convert.ToDecimal(Convert.ToDecimal(order.AgencyJinE) * order.RenShu + Convert.ToDecimal(order.ETAgencyJinE) * order.ErTongNum).ToString("f2") + "元";
            AgencyLiRui.Text = ((Convert.ToDecimal(Convert.ToDecimal(order.CRJiage) * order.RenShu + Convert.ToDecimal(order.ETJiage) * order.ErTongNum)) - (Convert.ToDecimal(Convert.ToDecimal(order.AgencyJinE) * order.RenShu + Convert.ToDecimal(order.ETAgencyJinE) * order.ErTongNum))).ToString("f2") + "元";
            ZongJia.Text = "成人单价<span style=\"color:red;\">" + Convert.ToDecimal(order.CRJiage).ToString("f2") + "</span>元 * 成人人数<span style=\"color:red;\">" + order.RenShu + "</span>人 + 儿童单价<span style=\"color:red;\">" + Convert.ToDecimal(order.ETJiage).ToString("f2") + "</span>元 * 儿童人数<span style=\"color:red;\">" + order.ErTongNum + "</span>人 = <span style=\"color:red;\">" + Convert.ToDecimal(Convert.ToDecimal(order.CRJiage) * order.RenShu + Convert.ToDecimal(order.ETJiage) * order.ErTongNum).ToString("f2") + "</span>元";
            CaoZuoRen.Text = order.UserType + "   " + GetMemberNameByID(order.XDRId);
            if (order.ZCMoney.HasValue)
            {
                var list = new EyouSoft.BLL.XianLuStructure.BZiZuTuan().GetXCList(order.ZuTuanId);
                Repeater1.DataSource = list;
                Repeater1.DataBind();
            }
            EyouSoft.Model.XianLuStructure.MXianLuInfo info = new EyouSoft.BLL.XianLuStructure.BXianLu().GetInfo(order.XianLuId);
            Chengshi.Text = info.CFCS;
            if (info.Line_Source == EyouSoft.Model.XianLuStructure.LineSource.光大)//光大的线路的话取航班
            {
                if (info.TourTraffice != null && info.TourTraffice.Count > 0)
                {
                    HangBan.Text = "<li>去程：" + info.TourTraffice[0].Traffic_01 + "</li><li>回程：" + info.TourTraffice[0].Traffic_02 + "<li>";
                }
            }
            bool isxianshi = (info.Line_Source == EyouSoft.Model.XianLuStructure.LineSource.博客 && info.LineType == EyouSoft.Model.XianLuStructure.LineType.长线);
            if (isxianshi)
            {
                StringBuilder strHB = new StringBuilder();//显示发班信息

                if (info.TourTraffice != null && info.TourTraffice.Count > 0)
                {
                    var hanlist = info.TourTraffice.Where(i => i.TrafficId == order.HangBanId).ToList();
                    if (hanlist != null && hanlist.Count > 0)
                    {
                        HangBan.Text = "去程：" + hanlist[0].Traffic_01 + "<br />回程：" + hanlist[0].Traffic_02;
                    }
                }
            }
            AnNiu.Text = getZhiFuURL(OrderId, order.OrderState, order.AgencyId, order.XDRId);
        }
        private void RECW(string msg)
        {
            Response.Clear();
            Response.Write(msg);
            Response.End();
        }
        protected string GetCheName(object zucheid)
        {
            string chename = "";
            if (!string.IsNullOrEmpty(zucheid.ToString()))
            {
                chename = new EyouSoft.BLL.ZuCheStructure.BZuChe().GetModel(zucheid.ToString()).CarName;
            }
            return chename;
        }
        /// <summary>
        /// 返回下单人姓名
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        protected string GetMemberNameByID(object memberID)
        {
            string id = "";
            if (memberID != null)
            {
                id = Utils.GetString(memberID.ToString(), "");
            }
            if (id == "" || id == null) return "金奥";
            EyouSoft.BLL.OtherStructure.BMember bll = new EyouSoft.BLL.OtherStructure.BMember();
            EyouSoft.Model.MMember model = new EyouSoft.Model.MMember();
            model = bll.GetModel(memberID.ToString());
            if (model == null) return "金奥";
            return "会员姓名：" + model.MemberName + "  会员帐号：" + model.Account;

        }
        /// <summary>
        /// 获取支付链接
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        protected string getZhiFuURL(string orderid, object state, object AgencyId, object xdrid)
        {
            mseller = bsells.Get(HuiYuanInfo.UserId);
            string FenXiaoId = "";
            if (mseller != null)
            {
                FenXiaoId = mseller.ID;
                isAgency = true;
            }
            if (AgencyId== null || string.IsNullOrEmpty(AgencyId.ToString())) { AgencyId = ""; }
            EyouSoft.Model.Enum.XianLuStructure.OrderStatus type = (EyouSoft.Model.Enum.XianLuStructure.OrderStatus)state;
            switch (type)
            {
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理:
                    return string.Format("<span class=\"y_btn\">等待审核</span>");
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待付款:
                    return string.Format("<a class=\"y_btn\" href='javascript:;' onclick=\"javascript:pageData.Pay('{0}','{1}','{2}');\"  >马上付款</a>", orderid, (int)DingDanType.单团订单, HuiYuanInfo.UserId);
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.订单出货:
                    if (isAgency == true && FenXiaoId.ToString() == AgencyId.ToString())
                    {
                        return string.Format("  <a class=\"y_btn\" href='javascript:;' onclick=\"javascript:pageData.setOrder('{0}','{1}');\"  >订单出货</a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货);
                    }
                    else
                    {
                        return string.Format("<span class=\"y_btn\">继续采购</span>");
                    }
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.确认收货:
                    if (isAgency == true && FenXiaoId.ToString() == AgencyId.ToString() && xdrid.ToString() != HuiYuanInfo.UserId)
                    {
                        return string.Format("<span class=\"y_btn\">确认出行</span>");
                    }
                    else
                    {
                        return string.Format("  <a class=\"y_btn\" href='javascript:;' onclick=\"javascript:pageData.setOrder('{0}','{1}');\"  >确认出行</a>", orderid, (byte)EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利);
                    }
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.待返利:
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.交易完成:
                    return string.Format("<a class=\"y_btn\" href='/Default.aspx'>继续采购</a>");
                case EyouSoft.Model.Enum.XianLuStructure.OrderStatus.取消订单:
                    return string.Format("<a class=\"y_btn\" href='/Default.aspx'>继续采购</a>");
                default:
                    break;
            }
            return "";
        }
    }
}
