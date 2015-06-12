using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.BLL.SystemStructure;
using EyouSoft.Model.SystemStructure;
using EyouSoft.IDAL.AccountStructure;

namespace EyouSoft.Web
{
    public partial class VisaBox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utils.GetQueryStringValue("dotype") == "save") BaoCun();
            initPage();
        }
        void initPage()
        {
            string visaid = Utils.GetQueryStringValue("qianzhengid");
            EyouSoft.BLL.QianZhengStructure.BQianZheng bll = new EyouSoft.BLL.QianZhengStructure.BQianZheng();
            EyouSoft.Model.QianZhengStructure.MQianZhengInfo model = new EyouSoft.Model.QianZhengStructure.MQianZhengInfo();
            if (visaid != null && visaid != "")
            {
                model = bll.GetInfo(visaid);
                if (model.QianZhengId != "")
                {
                    VisaName.Text = model.Name;
                    QianZhengId.Text = visaid;
                    YudingShiJian.Text = Utils.GetQueryStringValue("yudingtime");
                    EyouSoft.BLL.QianZhengStructure.BQianZhengGuoJia guojiabll = new EyouSoft.BLL.QianZhengStructure.BQianZhengGuoJia();
                    var list = guojiabll.GetInfo(model.GuoJiaId);
                    VisaGuojia.Text = list.Name1;
                    YuDingShuLiang.Text = Utils.GetQueryStringValue("visanum");
                    Model.SSOStructure.MUserInfo userInfo = null;
                    MFeeSettings feeSettings = new BFeeSettings().GetByType(EyouSoft.Model.Enum.FeeTypes.签证);
                    if (!Security.Membership.UserProvider.IsLogin(out userInfo)) RECW(EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "请求错误重新操作！"));
                    if (userInfo == null) RECW(EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "请求错误重新操作！"));
                    decimal discount = 0;//该用户提价比
                    decimal fenxiao = 0;//分销商提交比
                    var userType = userInfo.UserType;
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

                    string url = HttpContext.Current.Request.Url.Host;
                    BSellers bsells = new BSellers();
                    EyouSoft.Model.AccountStructure.MSellers seller = new EyouSoft.Model.AccountStructure.MSellers();
                    seller = bsells.GetMSellersByWebSite(url);
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

                    
                    int danjia = Convert.ToInt32(model.JiaGe + (model.JiaGeMenShi - model.JiaGe) * discount / 100);
                    int shuliang =Convert.ToInt32(Utils.GetQueryStringValue("visanum"));
                    int Agencyjine = Convert.ToInt32(model.JiaGe + (model.JiaGeMenShi - model.JiaGe) * fenxiao / 100);
                    FenxiaoJia.Text = (Agencyjine * shuliang).ToString();
                    DanJia.Text = danjia.ToString();
                    ZongJIa.Text = (danjia * shuliang).ToString();

                }
            }

        }
        void BaoCun()
        {
            EyouSoft.Model.QianZhengStructure.MQianZhengDingDanInfo model = new EyouSoft.Model.QianZhengStructure.MQianZhengDingDanInfo();
            model.BeiZhu = Utils.GetFormValue("beizhu");
            model.DanJia = Convert.ToDecimal(DanJia.Text);
            model.DingDanStatus = EyouSoft.Model.Enum.XianLuStructure.OrderStatus.未处理;
            model.FuKuanStatus = EyouSoft.Model.Enum.XianLuStructure.FuKuanStatus.未付款;
            model.IssueTime = DateTime.Now;
            model.JinE = Convert.ToDecimal(ZongJIa.Text);
            model.LxrDianHua = Utils.GetFormValue("lxrmobile");
            model.LxrXingMing = Utils.GetFormValue("lxrname");
            model.QianZhengGuoJiaId = 0;
            model.QianZhengId = QianZhengId.Text;
            model.QianZhengName = VisaName.Text;
            Model.SSOStructure.MUserInfo userInfo = null;
            MFeeSettings feeSettings = new BFeeSettings().GetByType(EyouSoft.Model.Enum.FeeTypes.签证);
            if (!Security.Membership.UserProvider.IsLogin(out userInfo)) RECW(EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "请求错误重新操作！"));
            if (userInfo == null) RECW(EyouSoft.Common.UtilsCommons.AjaxReturnJson("0", "请求错误重新操作！"));

            string url = HttpContext.Current.Request.Url.Host;
            BSellers bsells = new BSellers();
            EyouSoft.Model.AccountStructure.MSellers seller = new EyouSoft.Model.AccountStructure.MSellers();
            seller = bsells.GetMSellersByWebSite(url);
            if (seller != null)
            {
                if (bsells.JudgeAuthor(url, EyouSoft.Model.Enum.FeeTypes.签证))
                {
                    model.AgencyId = seller.ID;
                }
            }
            model.DingDanId = Guid.NewGuid().ToString();
            model.XiaDanRenId = userInfo.UserId;
            model.YuDingShiJian = Convert.ToDateTime(YudingShiJian.Text);
            model.YuDingShuLiang = Convert.ToInt32(YuDingShuLiang.Text);
            model.AgencyJinE = Convert.ToDecimal(FenxiaoJia.Text);

            if (model.AgencyJinE - model.JinE > 0)
            {
                model.AgencyJinE = model.JinE;
            }



            EyouSoft.BLL.QianZhengStructure.BQianZhengDingDan bll = new EyouSoft.BLL.QianZhengStructure.BQianZhengDingDan();
            int count = bll.Insert(model);
            string msg = "";
            if (count > 0)
            {
                int code = new EyouSoft.BLL.OtherStructure.BDuanXin().FaSongDingDanDuanXin(model.DingDanId, EyouSoft.Model.Enum.DingDanLeiBie.签证订单, EyouSoft.Model.Enum.DuanXinFaSongLeiXing.下单);
                msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "1", "提交成功！");
            }
            else
            {
                msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "0", "提交失败！");
            }
            RECW(msg);
        }
        private void RECW(string msg)
        {
            Response.Clear();
            Response.Write(msg);
            Response.End();
        }
    }
}