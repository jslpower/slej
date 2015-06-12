using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.BLL.SystemStructure;
using EyouSoft.Model.SystemStructure;
using EyouSoft.Common;
using EyouSoft.IDAL.AccountStructure;

namespace EyouSoft.Web
{
    public partial class VisaXX : System.Web.UI.Page
    {
        public string imgurl = "";
        public string huiyjia = "0";
        public string guibjia = "0";
        public string fenxjia = "0";
        public string fujianurl = "";
        public string guibinurl = "";
        public string dailiurl = "";
        public int ShowOrHidden = 0;//0-显示，1-隐藏
        protected void Page_Load(object sender, EventArgs e)
        {
            ((EyouSoft.Web.MasterPage.Front2)(base.Master)).HeadMenuIndex = 4;
            
            Model.SSOStructure.MUserInfo userInfo = null;
            Security.Membership.UserProvider.IsLogin(out userInfo);
            initPage();
            guibinname.Text = "申请贵宾身份";
            dailiname.Text = "申请代理身份";
            guibinurl = "<a href=\"http://www.slej.cn/ShangChengXiangQing.aspx?ID=84368172-bf82-4e79-b7ca-f0fdb22f6767\" class=\"btn001\"><span>马上申请</span></a>"
            +"<br /><b class=\"fontblue\">立省"+(Convert.ToInt32(huiyjia) - Convert.ToInt32(guibjia))+"元</b>";
            dailiurl = "<a href=\"http://www.slej.cn/ShangChengXiangQing.aspx?ID=7cca0f34-977f-4f4e-8792-ae168c9c0652\" class=\"btn001\"><span>马上申请</span></a>"
            + "<br /><b class=\"fontblue\">立省" + (Convert.ToInt32(huiyjia) - Convert.ToInt32(fenxjia)) + "元</b>";
            if (userInfo != null)
            {
                if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.代理 || userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.员工)
                {
                    guibinname.Text = "贵宾价格总金额";
                    dailiname.Text = "代理价格总金额";
                    guibinurl = "";
                    dailiurl = "";
                }
                else if (userInfo.UserType == EyouSoft.Model.Enum.MemberTypes.贵宾会员)
                {
                    guibinname.Text = "贵宾价格总金额";
                    guibinurl = "";
                }
            }
            if (Utils.GetQueryStringValue("dotype") == "save") BaoCun();
            
        }
        private void initPage()
        {
            MFeeSettings feeSettings = new BFeeSettings().GetByType(EyouSoft.Model.Enum.FeeTypes.签证);

            string visaid = Request.QueryString["visaid"];
            EyouSoft.BLL.QianZhengStructure.BQianZheng bll = new EyouSoft.BLL.QianZhengStructure.BQianZheng();
            EyouSoft.Model.QianZhengStructure.MQianZhengInfo model = new EyouSoft.Model.QianZhengStructure.MQianZhengInfo();
            if (visaid != null && visaid != "")
            {
                model = bll.GetInfo(visaid);
                if (model.QianZhengId != "")
                {
                    VisaName.Text = model.Name;
                    QianZhengName.Text = model.Name;
                    EyouSoft.BLL.QianZhengStructure.BQianZhengGuoJia guojiabll = new EyouSoft.BLL.QianZhengStructure.BQianZhengGuoJia();
                    var list = guojiabll.GetInfo(model.GuoJiaId);
                    imgurl = list.FilePath;
                    //MenShiJia.Text = Convert.ToInt32(model.JiaGeMenShi).ToString();
                    //HuiYuanJia.Text = (model.JiaGe + (model.JiaGeMenShi - model.JiaGe) * feeSettings.PuTongHuiYuanJia / 100).ToString("f0");
                    huiyjia = (model.JiaGe + (model.JiaGeMenShi - model.JiaGe) * feeSettings.PuTongHuiYuanJia / 100).ToString("f0");
                    //DaiXiaoJIa.Text = (model.JiaGe + (model.JiaGeMenShi - model.JiaGe) * feeSettings.FreeFenXiaoJia / 100).ToString("f0");
                    //FenXiaoJia.Text = (model.JiaGe + (model.JiaGeMenShi - model.JiaGe) * feeSettings.FenXiaoJia / 100).ToString("f0");
                    guibjia = (model.JiaGe + (model.JiaGeMenShi - model.JiaGe) * feeSettings.GuiBinJia / 100).ToString("f0");
                    fenxjia = (model.JiaGe + (model.JiaGeMenShi - model.JiaGe) * feeSettings.FenXiaoJia / 100).ToString("f0");
                    BanLiShiJian.Text = model.BanLiShiJian;
                    YouXiaoQi.Text = model.YouXiaoQi.ToString();
                    TingLiu.Text = model.TingLiuShiJian.ToString();
                    MianShi.Text = model.MianShi;
                    YaoQing.Text = model.YaoQingHan;
                    LingQu.Text = model.SuoShuLingQu;
                    FanWei.Text = model.ShouLiFanWei;
                    LeiXing.Text = model.QianZhengLeiXing.ToString();
                    Cailiao.Text = model.SuoXuCaiLiao;
                    TiShi.Text = model.TeBieTiShi;
                    ZhuYi.Text = model.ZhuYiShiXiang;
                    fujianurl = model.FileUpLoad;
                    FenxiaoJiaGe.Text = fenxjia;
                    FenxiaoJiaGe.Visible = false;
                    string jiagexianshi = "";
                    jiagexianshi += "<dd>门市价：<span class=\"font18 font_yellow\" style=\"text-decoration:line-through\">¥ " + Convert.ToInt32(model.JiaGeMenShi).ToString() + "</span>元起&nbsp;&nbsp;&nbsp;&nbsp;";
                    jiagexianshi += "会员价：<span class=\"font18 font_yellow\">¥ " + (model.JiaGe + (model.JiaGeMenShi - model.JiaGe) * feeSettings.PuTongHuiYuanJia / 100).ToString("f0") + "</span>元起";
                    Model.SSOStructure.MUserInfo userInfo = null;
                    Security.Membership.UserProvider.IsLogin(out userInfo);
                    if (userInfo != null)
                    {
                        switch (userInfo.UserType)
                        {
                            case EyouSoft.Model.Enum.MemberTypes.代理:
                                DanJia.Text = (model.JiaGe + (model.JiaGeMenShi - model.JiaGe) * feeSettings.FenXiaoJia / 100).ToString("f0");
                                break;
                            case EyouSoft.Model.Enum.MemberTypes.贵宾会员:
                                DanJia.Text = (model.JiaGe + (model.JiaGeMenShi - model.JiaGe) * feeSettings.GuiBinJia / 100).ToString("f0");
                                break;
                            case EyouSoft.Model.Enum.MemberTypes.免费代理:
                                DanJia.Text = (model.JiaGe + (model.JiaGeMenShi - model.JiaGe) * feeSettings.FreeFenXiaoJia / 100).ToString("f0");
                                break;
                            case EyouSoft.Model.Enum.MemberTypes.普通会员:
                                DanJia.Text = (model.JiaGe + (model.JiaGeMenShi - model.JiaGe) * feeSettings.PuTongHuiYuanJia / 100).ToString("f0");
                                break;
                            case EyouSoft.Model.Enum.MemberTypes.员工:
                                DanJia.Text = (model.JiaGe + (model.JiaGeMenShi - model.JiaGe) * feeSettings.YuanGongJia / 100).ToString("f0");
                                break;
                            default:
                                DanJia.Text = (model.JiaGe + (model.JiaGeMenShi - model.JiaGe) * feeSettings.PuTongHuiYuanJia / 100).ToString("f0");
                                break;
                        }
                        if ((int)userInfo.UserType == 2)
                        {
                            jiagexianshi += "&nbsp;&nbsp;&nbsp;&nbsp;贵宾价：<span class=\"font18 font_yellow\">¥ " + (model.JiaGe + (model.JiaGeMenShi - model.JiaGe) * feeSettings.GuiBinJia / 100).ToString("f0") + "</span>元起";
                        }
                        else if ((int)userInfo.UserType == 3)
                        {
                            jiagexianshi += "&nbsp;&nbsp;&nbsp;&nbsp;代销价：<span class=\"font18 font_yellow\">¥ " + (model.JiaGe + (model.JiaGeMenShi - model.JiaGe) * feeSettings.FreeFenXiaoJia / 100).ToString("f0") + "</span>元起";
                        }
                        else if ((int)userInfo.UserType == 4)
                        {
                            jiagexianshi += "&nbsp;&nbsp;&nbsp;&nbsp;贵宾价：<span class=\"font18 font_yellow\">¥ " + (model.JiaGe + (model.JiaGeMenShi - model.JiaGe) * feeSettings.GuiBinJia / 100).ToString("f0") + "</span>元起";
                            jiagexianshi += "<dd>代理价：<span class=\"font18 font_yellow\">¥ " + (model.JiaGe + (model.JiaGeMenShi - model.JiaGe) * feeSettings.FenXiaoJia / 100).ToString("f0") + "</span>元起";
                        }
                        else if ((int)userInfo.UserType == 5)
                        {
                            jiagexianshi += "&nbsp;&nbsp;&nbsp;&nbsp;代销价：<span class=\"font18 font_yellow\">¥ " + (model.JiaGe + (model.JiaGeMenShi - model.JiaGe) * feeSettings.FreeFenXiaoJia / 100).ToString("f0") + "</span>元起";
                            jiagexianshi += "<dd>贵宾价：<span class=\"font18 font_yellow\">¥ " + (model.JiaGe + (model.JiaGeMenShi - model.JiaGe) * feeSettings.GuiBinJia / 100).ToString("f0") + "</span>元起&nbsp;&nbsp;&nbsp;&nbsp;";
                            jiagexianshi += "代理价：<span class=\"font18 font_yellow\">¥ " + (model.JiaGe + (model.JiaGeMenShi - model.JiaGe) * feeSettings.FenXiaoJia / 100).ToString("f0") + "</span>元起&nbsp;&nbsp;&nbsp;&nbsp;";
                            jiagexianshi += "员工价：<span class=\"font18 font_yellow\">¥ " + (model.JiaGe + (model.JiaGeMenShi - model.JiaGe) * feeSettings.YuanGongJia / 100).ToString("f0") + "</span>元起";
                        }
                    }
                    else
                    {
                        DanJia.Text = (model.JiaGe + (model.JiaGeMenShi - model.JiaGe) * feeSettings.PuTongHuiYuanJia / 100).ToString("f0");
                    }
                    jiagexianshi += "</dd>";
                    Zongjia.Text = DanJia.Text;
                    
                   
                    JiaGeList.Text = jiagexianshi;
                }
            }
            else
            {
                
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
            model.YuDingShuLiang = Convert.ToInt32(Utils.GetFormValue("visanum"));
            model.JinE = Convert.ToDecimal(model.DanJia)* model.YuDingShuLiang;
            model.LxrDianHua = Utils.GetFormValue("lxrmobile");
            model.LxrXingMing = Utils.GetFormValue("lxrname");
            model.QianZhengGuoJiaId = 0;
            model.QianZhengId = Request.QueryString["visaid"];
            model.QianZhengName = VisaName.Text;
            Model.SSOStructure.MUserInfo userInfo = null;
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
            model.YuDingShiJian = Convert.ToDateTime(Utils.GetFormValue("yudingtime"));

            model.AgencyJinE = Convert.ToDecimal(FenxiaoJiaGe.Text)*model.YuDingShuLiang;

            if (model.AgencyJinE - model.JinE > 0)
            {
                model.AgencyJinE = model.JinE;
            }
            if (seller == null)
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

                //返联盟推广
                var flmtgInfo = new EyouSoft.Model.OtherStructure.MTuiGuangFanLiInfo();
                flmtgInfo.DingDanId = model.DingDanId;
                flmtgInfo.DingDanLeiXing = EyouSoft.Model.OtherStructure.DingDanType.签证订单;
                flmtgInfo.FanLiBiLi = 0;
                flmtgInfo.XiaDanRenId = model.XiaDanRenId;
                new EyouSoft.BLL.OtherStructure.BTuiGuang().TuiGuangFanLi_C(flmtgInfo);
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
