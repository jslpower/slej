using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using System.Text;

namespace EyouSoft.Web.WebMaster
{
    public partial class ZiZuTuanXX : EyouSoft.Common.Page.WebmasterPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PageInit();
            }
        }
        private void PageInit()
        {
            string OrderId = Utils.GetQueryStringValue("orderid");
            if (string.IsNullOrEmpty(OrderId)) RCWE("请求异常");
            string type = Utils.GetQueryStringValue("type");
            var order = new EyouSoft.BLL.XianLuStructure.BZiZuTuan().GetInfo(OrderId);
            if (order == null) RCWE("请求异常");
            OrderCode.Text = order.OrderCode;
            XianLuName.Text = order.XianLuName;
            ChufaTime.Text = Convert.ToDateTime(order.ChuFaTime).ToString("yyyy-MM-dd");
            RenShu.Text = "该团为"+order.ChengTuanNum+"团，成人人数"+ order.RenShu+"人,儿童人数"+order.ErTongNum+"人";
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
                    HangBan.Text = "去程：" + info.TourTraffice[0].Traffic_01 + "<br />回程：" + info.TourTraffice[0].Traffic_02;
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
    }
}