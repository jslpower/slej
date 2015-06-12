using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Web.MasterPage;
using EyouSoft.Model.SystemStructure;
using EyouSoft.BLL.SystemStructure;
using System.Text;
using EyouSoft.Model.ZuCheStructure;
using EyouSoft.IDAL.AccountStructure;
namespace EyouSoft.Web
{
    public partial class ZuCheXX : System.Web.UI.Page
    {
        protected string thisurl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string hosturl = Request.Url.Host.ToLower();
            if (hosturl.IndexOf("www") >= 0)
            {
                hosturl = "slej.cn";
            }
            thisurl = "http://m."+hosturl+"/Car.aspx?id="+Utils.GetQueryStringValue("id");
            string dotype = Utils.GetQueryStringValue("dotype");
            if (dotype == "save")
            {
                OrderSub();
            }

            if (!Page.IsPostBack)
            {
                ((EyouSoft.Web.MasterPage.Front2)(base.Master)).HeadMenuIndex = 8;
                InitInfo();
            }
        }

        protected void InitInfo()
        {
            string id = Utils.GetQueryStringValue("id");
            if (string.IsNullOrEmpty(id)) Utils.RCWE("异常请求！");
            EyouSoft.BLL.ZuCheStructure.BZuChe bll = new EyouSoft.BLL.ZuCheStructure.BZuChe();
            var model = bll.GetModel(id);
            if (model == null) Utils.RCWE("异常请求");
            ltrCarName.Text = model.CarName;
            ltrXianZuo.Text = model.XianZuoRenShu.ToString();
            ltrImage.Text = IMGHTML(model.ZucheInfoImg, model.CarName); //string.Format("<img width='390' height='220' src='{0}' alt='{1}'>", model.FilePath, model.CarName);
            ltrRem.Text = model.Remark;
            ZuCheOrder1.Iscarlist = false;
            ZuCheOrder1.ZuChe = model;

            ZuCheOrder1.BaiDuMapKey = "ovOm8pf0QIyWC4n4jx8I5vPG";

            //(Master as Front).HeadMenuIndex = 8;
        }

        private string IMGHTML(IList<ZuCheImg> ZucheInfoImg, string carName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class=\"big_img\">");
            if (ZucheInfoImg != null && ZucheInfoImg.Count > 0)
            {

                sb.AppendFormat("<img width='390' height='220' src='{0}' alt='{1}'>", ZucheInfoImg[0].FilePath, carName);

                sb.Append("</div><div class=\"small_img\">");
                sb.AppendFormat("<img width=\"192\" height=\"108\" src='{0}' alt='{1}'>", ZucheInfoImg[1].FilePath, carName);
                sb.AppendFormat("<img width=\"192\" height=\"108\" src='{0}' alt='{1}'></div>", ZucheInfoImg[2].FilePath, carName);
            }
            else
            {
                sb.Append("</div><div class=\"small_img\"></div>");
            }
            return sb.ToString();
        }

        private void OrderSub()
        {
            string id = Utils.GetQueryStringValue("id");
            var Ordermodel = ZuCheOrder1.ExperienceInfo();
            EyouSoft.BLL.ZuCheStructure.BZuChe bll = new EyouSoft.BLL.ZuCheStructure.BZuChe();
            var newmodel = bll.GetModel(id);

            if (newmodel == null) Utils.RCWE(EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "请求的数据不存在！"));
            Ordermodel.CarName = newmodel.CarName;
            Ordermodel.ZuCheID = newmodel.ZuCheID;


            string url = HttpContext.Current.Request.Url.Host;
            BSellers bsells = new BSellers();
            EyouSoft.Model.AccountStructure.MSellers seller = new EyouSoft.Model.AccountStructure.MSellers();
            seller = bsells.GetMSellersByWebSite(url);
            if (seller != null)
            {
                Ordermodel.AgencyId = seller.ID;
            }
            
            #region 金额
            decimal JinE = 0;
            decimal FenXiaoJia = 0;
            MFeeSettings feeSettings = new BFeeSettings().GetByType(EyouSoft.Model.Enum.FeeTypes.租车);



            Model.SSOStructure.MUserInfo userInfo = null;
            if (!Security.Membership.UserProvider.IsLogin(out userInfo)) Utils.RCWE(EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "请求错误重新操作！"));
            if (userInfo == null) Utils.RCWE(EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "请求错误重新操作！"));
            var userType = userInfo.UserType;
            Ordermodel.OperatorId = userInfo.UserId;
            Ordermodel.YuDingRName = userInfo.MemberName;
            Ordermodel.YuDingRTelephone = userInfo.Mobile;
            decimal discount = 0;
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
                fenxiao = feeSettings.FenXiaoJia;
            }

            if (Ordermodel.ZuCheType == (int)EyouSoft.Model.Enum.ZhuCheType.同城往返带司机包租车)
            {
                var YouHuiJiaG = newmodel.MenShiJiaGeDanCheng + (newmodel.MenShiJia - newmodel.MenShiJiaGeDanCheng) * discount / 100;
                FenXiaoJia = newmodel.MenShiJiaGeDanCheng + (newmodel.MenShiJia - newmodel.MenShiJiaGeDanCheng) * fenxiao / 100;
                JinE += YouHuiJiaG * Ordermodel.Number;
                FenXiaoJia = FenXiaoJia * Ordermodel.Number;
                TimeSpan ts = Ordermodel.EDate.Value.Subtract(Ordermodel.LDate.Value);
                Ordermodel.ZuCheTianShu = ts.Days;
                if (ts.Days > 0)
                {
                    JinE += ts.Days * (newmodel.MenShiJiaGeChaoShi + (newmodel.MenShiChaoShi - newmodel.MenShiJiaGeChaoShi) * discount / 100);
                    FenXiaoJia += ts.Days * (newmodel.MenShiJiaGeChaoShi + (newmodel.MenShiChaoShi - newmodel.MenShiJiaGeChaoShi) * fenxiao / 100);
                    
                }
                if (Ordermodel.GongLiShu > newmodel.MenShiJiaGeZuChe)
                {
                    JinE += ((Ordermodel.GongLiShu - newmodel.MenShiJiaGeZuChe) * (newmodel.MenShiJiaGeChaoCheng + (newmodel.MenShiChaoCheng - newmodel.MenShiJiaGeChaoCheng) * discount / 100)).Value;
                    FenXiaoJia += ((Ordermodel.GongLiShu - newmodel.MenShiJiaGeZuChe) * (newmodel.MenShiJiaGeChaoCheng + (newmodel.MenShiChaoCheng - newmodel.MenShiJiaGeChaoCheng) * fenxiao / 100)).Value;
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
                if (Ordermodel.GongLiShu > newmodel.YouHuiJiaGeZuChe)
                {
                    JinE += ((Ordermodel.GongLiShu - newmodel.YouHuiJiaGeZuChe) * (newmodel.YouHuiJiaGeChaoCheng + (newmodel.YouHuiChaoCheng - newmodel.YouHuiJiaGeChaoCheng) * discount / 100)).Value;
                    FenXiaoJia += ((Ordermodel.GongLiShu - newmodel.YouHuiJiaGeZuChe) * (newmodel.YouHuiJiaGeChaoCheng + (newmodel.YouHuiChaoCheng - newmodel.YouHuiJiaGeChaoCheng) * fenxiao / 100)).Value;
                }
            }
            Ordermodel.ZuJin = JinE;
            Ordermodel.AgencyJinE = FenXiaoJia;


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
            }
            else
            {
                strReturn = "下单失败";
            }
            Utils.RCWE(UtilsCommons.AjaxReturnJson(r.ToString(), strReturn));
        }
    }
}
