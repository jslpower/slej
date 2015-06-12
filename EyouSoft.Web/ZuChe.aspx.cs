using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Model.ZuCheStructure;
using EyouSoft.Model.SystemStructure;
using EyouSoft.BLL.SystemStructure;
using EyouSoft.Web.MasterPage;
using System.Text;
using EyouSoft.IDAL.AccountStructure;

namespace EyouSoft.Web
{
    public partial class ZuChe : System.Web.UI.Page
    {
        #region 分页
        protected const int PageSize = 10;

        protected int _pageIndex = 1;

        protected int _recordCount = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            string dotype = Utils.GetQueryStringValue("dotype");
            if (dotype == "save")
            {
                OrderSub();
            }

            ((EyouSoft.Web.MasterPage.Front2)(base.Master)).HeadMenuIndex = 8;
            ZuCheOrder1.BaiDuMapKey = "ovOm8pf0QIyWC4n4jx8I5vPG";
            if (!Page.IsPostBack)
            {
                InitPage();
            }
        }

        private void InitPage()
        {
            _pageIndex = Utils.GetInt(Utils.GetQueryStringValue("Page"), 1);

            
            EyouSoft.BLL.ZuCheStructure.BZuChe bll = new EyouSoft.BLL.ZuCheStructure.BZuChe();
            EyouSoft.Model.ZuCheStructure.MZuCheInfoChaXun model = new EyouSoft.Model.ZuCheStructure.MZuCheInfoChaXun()
            {
                State = EyouSoft.Model.Enum.ZuCheStates.启用,
                CarName = Utils.GetQueryStringValue("carname")
            };
            var list = bll.GetList(PageSize, _pageIndex, ref _recordCount, model);
            if (list != null && list.Count > 0)
            {
                rpt_ZuChe.DataSource = list;
                rpt_ZuChe.DataBind();
            }
        }


        private void OrderSub()
        {
            var Ordermodel = ZuCheOrder1.ExperienceInfo();
            EyouSoft.BLL.ZuCheStructure.BZuChe bll = new EyouSoft.BLL.ZuCheStructure.BZuChe();
            var newmodel = bll.GetModel(Ordermodel.ZuCheID);
            if (newmodel == null) RECW(EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "请求的数据不存在！"));
            Ordermodel.CarName = newmodel.CarName;

            string url = HttpContext.Current.Request.Url.Host;
            //string url = "8191.slej.cn";
            BSellers bsells = new BSellers();
            EyouSoft.Model.AccountStructure.MSellers seller = new EyouSoft.Model.AccountStructure.MSellers();
            seller = bsells.GetMSellersByWebSite(url);
            if (seller != null)
            {
                if (bsells.JudgeAuthor(url, EyouSoft.Model.Enum.FeeTypes.租车))
                {
                    Ordermodel.AgencyId = seller.ID;
                }
            }

            #region 金额
            decimal JinE = 0;
            decimal FenXiaoJia = 0;
            MFeeSettings feeSettings = new BFeeSettings().GetByType(EyouSoft.Model.Enum.FeeTypes.租车);

            Model.SSOStructure.MUserInfo userInfo = null;
            if (!Security.Membership.UserProvider.IsLogin(out userInfo)) RECW(EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "请求错误重新操作！"));
            if (userInfo == null) RECW(EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "请求错误重新操作！"));
            var userType = userInfo.UserType;
            Ordermodel.OperatorId = userInfo.UserId;
            Ordermodel.YuDingRName = userInfo.MemberName;
            Ordermodel.YuDingRTelephone = userInfo.Mobile;


            

            decimal discount = 0;//该用户提价比
            decimal fenxiao = 0;//分销商提交比
            switch (userType)
            {
                case EyouSoft.Model.Enum.MemberTypes.未注册用户:
                    break;
                case EyouSoft.Model.Enum.MemberTypes.员工:
                    discount = feeSettings.YuanGongJia;
                    break;
                case EyouSoft.Model.Enum.MemberTypes.普通会员:
                    discount = feeSettings.PuTongHuiYuanJia;
                    break;
                case EyouSoft.Model.Enum.MemberTypes.贵宾会员:
                    discount = feeSettings.GuiBinJia;
                    break;
                case EyouSoft.Model.Enum.MemberTypes.代理:
                    discount = feeSettings.FenXiaoJia;
                    break;
                default:
                    break;
            }
            if (seller != null)
            {
                if (seller.DengJi == EyouSoft.Model.Enum.MemberTypes.代理)
                {
                    fenxiao = feeSettings.FenXiaoJia;
                }
                else if (seller.DengJi == EyouSoft.Model.Enum.MemberTypes.免费代理)
                {
                    fenxiao = feeSettings.FreeFenXiaoJia;
                }
                else if (seller.DengJi == EyouSoft.Model.Enum.MemberTypes.员工)
                {
                    fenxiao = feeSettings.YuanGongJia;
                }
            }


            if (Ordermodel.ZuCheType == (int)EyouSoft.Model.Enum.ZhuCheType.同城往返带司机包租车)
            {
                var YouHuiJiaG = newmodel.MenShiJiaGeDanCheng + (newmodel.MenShiJia - newmodel.MenShiJiaGeDanCheng) * discount /100;
                FenXiaoJia = newmodel.MenShiJiaGeDanCheng + (newmodel.MenShiJia - newmodel.MenShiJiaGeDanCheng) * fenxiao / 100;
                JinE += YouHuiJiaG * Ordermodel.Number;
                FenXiaoJia = FenXiaoJia * Ordermodel.Number;
                TimeSpan ts = Ordermodel.EDate.Value.Subtract(Convert.ToDateTime(Ordermodel.LDate.Value.ToShortDateString()));
                Ordermodel.ZuCheTianShu = ts.Days;
                if (ts.Days > 0)
                {
                    JinE += ts.Days * (newmodel.MenShiJiaGeChaoShi + (newmodel.MenShiChaoShi - newmodel.MenShiJiaGeChaoShi) * discount / 100);
                    FenXiaoJia += ts.Days * (newmodel.MenShiJiaGeChaoShi + (newmodel.MenShiChaoShi - newmodel.MenShiJiaGeChaoShi) * fenxiao / 100);
                    
                }
                if (Ordermodel.GongLiShu > newmodel.MenShiJiaGeZuChe)
                {
                    JinE += ((Ordermodel.GongLiShu - newmodel.MenShiJiaGeZuChe) * (newmodel.MenShiJiaGeChaoCheng +(newmodel.MenShiChaoCheng-newmodel.MenShiJiaGeChaoCheng)*discount/100)).Value;
                    FenXiaoJia += ((Ordermodel.GongLiShu - newmodel.MenShiJiaGeZuChe) * (newmodel.MenShiJiaGeChaoCheng + (newmodel.MenShiChaoCheng-newmodel.MenShiJiaGeChaoCheng)*fenxiao/100)).Value;
                }
            }
            else
            {
                var YouHuiJiaG = newmodel.MenShiJiaGeDanCheng + (newmodel.MenShiJia - newmodel.MenShiJiaGeDanCheng) * discount / 100;
                FenXiaoJia = newmodel.MenShiJiaGeDanCheng + (newmodel.MenShiJia - newmodel.MenShiJiaGeDanCheng) * fenxiao / 100;
                JinE += YouHuiJiaG * Ordermodel.Number;
                FenXiaoJia = FenXiaoJia * Ordermodel.Number;
                TimeSpan ts = Ordermodel.EDate.Value.Subtract(Ordermodel.LDate.Value);
                Ordermodel.ZuCheTianShu = ts.Days;
                if (ts.Days > 0)
                {
                    JinE += ts.Days * (newmodel.YouHuiJiaGeChaoShi + (newmodel.YouHuiChaoShi - newmodel.YouHuiJiaGeChaoShi) * discount / 100);
                    FenXiaoJia += ts.Days * (newmodel.YouHuiJiaGeChaoShi + (newmodel.YouHuiChaoShi - newmodel.YouHuiJiaGeChaoShi) * fenxiao / 100);
                   
                }
                Ordermodel.GongLiShu = Ordermodel.GongLiShu * 2;
                if (Ordermodel.GongLiShu > newmodel.YouHuiJiaGeZuChe)
                {
                    
                    JinE += ((Ordermodel.GongLiShu - newmodel.YouHuiJiaGeZuChe*2) * (newmodel.YouHuiJiaGeChaoCheng + (newmodel.YouHuiChaoCheng - newmodel.YouHuiJiaGeChaoCheng) * discount / 100)).Value;
                    FenXiaoJia += ((Ordermodel.GongLiShu - newmodel.YouHuiJiaGeZuChe*2) * (newmodel.YouHuiJiaGeChaoCheng + (newmodel.YouHuiChaoCheng - newmodel.YouHuiJiaGeChaoCheng) * fenxiao / 100)).Value;
                }
            }
            Ordermodel.ZuJin = JinE;
            Ordermodel.AgencyJinE = FenXiaoJia;


            if (FenXiaoJia - JinE > 0)
            {
                Ordermodel.AgencyJinE = JinE;
            }
            if (seller == null)
            {
                Ordermodel.AgencyJinE = JinE;
            }

            #endregion
            Ordermodel.OrderId = Guid.NewGuid().ToString();
            Ordermodel.OrderSite = EyouSoft.Model.Enum.OrderSite.PC;
            EyouSoft.BLL.ZuCheStructure.BZuCheOrder orderBll = new EyouSoft.BLL.ZuCheStructure.BZuCheOrder();
            var r = orderBll.Add(Ordermodel);
            string strReturn;
            if (r == 1)
            {
                int code = new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(Ordermodel.OrderId, EyouSoft.Model.Enum.DingDanLeiBie.租车订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.下单);
                strReturn = "下单成功";

                //返联盟推广
                var flmtgInfo = new EyouSoft.Model.OtherStructure.MTuiGuangFanLiInfo();
                flmtgInfo.DingDanId = Ordermodel.OrderId;
                flmtgInfo.DingDanLeiXing = EyouSoft.Model.OtherStructure.DingDanType.租车订单;
                flmtgInfo.FanLiBiLi = 0;
                flmtgInfo.XiaDanRenId = Ordermodel.OperatorId;
                new EyouSoft.BLL.OtherStructure.BTuiGuang().TuiGuangFanLi_C(flmtgInfo);
            }
            else
            {
                strReturn = "下单失败";
            }
            RECW(UtilsCommons.AjaxReturnJson(r.ToString(), strReturn));
        }

        private void RECW(string msg)
        {
            Response.Clear();
            Response.Write(msg);
            Response.End();
        }

        protected string IMGhtml(object obj,object CarName)
        {
            var list = (IList<ZuCheImg>)obj;
            StringBuilder sb = new StringBuilder();
            if (list != null && list.Count > 0)
            {
                sb.AppendFormat("<img src='{0}' alt='{1}'>", list[0].FilePath, CarName.ToString());
            }
            return sb.ToString();
        }

    }
}
