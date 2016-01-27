using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using EyouSoft.Common;
using EyouSoft.Model.SSOStructure;

namespace EyouSoft.Web.ashx
{
    /// <summary>
    /// 公共处理程序
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Handler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {            
            context.Response.ContentType = "text/plain";

            string dotype = Utils.GetQueryStringValue("dotype");

            switch (dotype)
            {
                case "mislogin": MIsLogin(context); break;
                //case "dibiao": GetDiBiaos(); break;
                case "getzhuceyanzhengma": GetZhuCeYanZhengMa(); break;
                case "getzdengluyanzhengma": GetDengLuYanZhengMa(); break;
                case "zhuce": ZhuCe(); break;
                case "getyuezhifuyanzhengma": GetYuEZhiFuYanZhengMa(); break;
                case "huoquyuming_yaoqingma": huoquyuming_yaoqingma(); break;
                default: break;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        #region private members
        /// <summary>
        /// 是否登录
        /// </summary>
        /// <param name="context"></param>
        void MIsLogin(HttpContext context)
        {
            MUserInfo m;
            bool isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out m);

            var output = new System.Text.StringBuilder();
            output.Append("{");

            output.AppendFormat("\"retCode\":{0}", "1");
            output.AppendFormat(",\"isLogin\":{0}", isLogin ? "true" : "false");
            output.AppendFormat(",\"token\":\"{0}\"", isLogin ? m.UserId : "");

            output.Append("}");

            context.Response.Write(output);
        }

        /// <summary>
        /// 获取地标
        /// </summary>
        //void GetDiBiaos()
        //{
        //    string txtType = Utils.GetQueryStringValue("txtType");
        //    int txtId = Utils.GetInt(Utils.GetQueryStringValue("txtId"));

        //    if (txtId < 1) Utils.RCWE("[]");
        //    if (txtType != "chengshi" && txtType != "xianqu") Utils.RCWE("[]");

        //    int recordCount = 0;
        //    var chaXun = new EyouSoft.Model.OtherStructure.MDiBiaoInfo();
        //    if (txtType == "chengshi") chaXun.CityId = txtId;
        //    if (txtType == "xianqu") chaXun.DistrictId = txtId;

        //    var items = new EyouSoft.BLL.OtherStructure.BDiBiao().GetDiBiaos(2000, 1, ref recordCount, chaXun);

        //    if (items == null || items.Count == 0) Utils.RCWE("[]");

        //    Utils.RCWE(Newtonsoft.Json.JsonConvert.SerializeObject(items));
        //}

        /// <summary>
        /// 获取注册验证码
        /// </summary>
        void GetZhuCeYanZhengMa()
        {
            string username = Utils.GetFormValue("txt_zhuce_shouji");
            if (new EyouSoft.BLL.MemberStructure.BMember().IsExistsUsername(username) == 1)
            {
                Utils.RCWE(UtilsCommons.AjaxReturnJson("-1", "已经存在的手机号码，请直接登录"));
            }

            var yanZhengMa = new EyouSoft.BLL.OtherStructure.BYanZhengMa().CreateYanZhengMa(6);
            var info = new EyouSoft.Model.OtherStructure.MYanZhengMaInfo();
            info.IssueTime = DateTime.Now;
            info.LeiXing = EyouSoft.Model.Enum.YanZhengMaLeiXing.用户注册;
            info.ShouJi = username;
            info.Status = 0;
            info.YanZhengMa = yanZhengMa;

            new EyouSoft.BLL.OtherStructure.BYanZhengMa().Insert(info);

            //发送短信
            var duanXinInfo = new EyouSoft.Model.OtherStructure.MDuanXinInfo();
            duanXinInfo.JieShouShouJi = username;
            duanXinInfo.NeiRong = "您的注册验证码为：" + yanZhengMa + "，30分钟内有效。请勿将验证码提供给他人。【商旅e家】";

            new EyouSoft.BLL.OtherStructure.BDuanXin().FaSong(duanXinInfo);

            Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "", yanZhengMa));
        }
        void GetDengLuYanZhengMa()
        {
            string username = Utils.GetFormValue("txt_denglu_shouji");
            if (new EyouSoft.BLL.MemberStructure.BMember().IsExistsUsername(username) == 0)
            {
                Utils.RCWE(UtilsCommons.AjaxReturnJson("-1", "暂无该用户，请重新注册！"));
            }

            var yanZhengMa = new EyouSoft.BLL.OtherStructure.BYanZhengMa().CreateYanZhengMa(6);
            var info = new EyouSoft.Model.OtherStructure.MYanZhengMaInfo();
            info.IssueTime = DateTime.Now;
            info.LeiXing = EyouSoft.Model.Enum.YanZhengMaLeiXing.用户登录;
            info.ShouJi = username;
            info.Status = 0;
            info.YanZhengMa = yanZhengMa;

            new EyouSoft.BLL.OtherStructure.BYanZhengMa().Insert(info);

            //发送短信
            var duanXinInfo = new EyouSoft.Model.OtherStructure.MDuanXinInfo();
            duanXinInfo.JieShouShouJi = username;
            duanXinInfo.NeiRong = "您的登录验证码为：" + yanZhengMa + "，30分钟内有效。请勿将验证码提供给他人。【商旅e家】";

            new EyouSoft.BLL.OtherStructure.BDuanXin().FaSong(duanXinInfo);

            Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "", yanZhengMa));
        }

        /// <summary>
        /// 注册
        /// </summary>
        void ZhuCe()
        {
            string username = Utils.GetFormValue("txt_zhuce_shouji").Trim();
            string xingMing = Utils.GetFormValue("txt_zhuce_xingming").Trim();
            string yanZhengMa = Utils.GetFormValue("txt_zhuce_yanzhengma").Trim();

            var yanZhengMaInfo = new EyouSoft.BLL.OtherStructure.BYanZhengMa().GetInfo(username, yanZhengMa, EyouSoft.Model.Enum.YanZhengMaLeiXing.用户注册);
            if (yanZhengMaInfo == null
                || yanZhengMaInfo.YanZhengMa != yanZhengMa)
                Utils.RCWE(UtilsCommons.AjaxReturnJson("-1", "验证码错误，请输入正确的验证码"));

            if (yanZhengMaInfo.Status1 == EyouSoft.Model.Enum.YanZhengMaStatus.已过期)
            {
                Utils.RCWE(UtilsCommons.AjaxReturnJson("-2", "验证码已过期，请重新获取验证码"));
            }

            if (yanZhengMaInfo.Status1 == EyouSoft.Model.Enum.YanZhengMaStatus.已使用)
            {
                Utils.RCWE(UtilsCommons.AjaxReturnJson("-2", "验证码已使用，请重新获取验证码"));
            }

            if (new EyouSoft.BLL.MemberStructure.BMember().IsExistsUsername(username) == 1)
            {
                Utils.RCWE(UtilsCommons.AjaxReturnJson("-3", "已经存在的手机号码，请直接登录"));
            }

            var info = new MMember2();
            info.MemberID = Guid.NewGuid().ToString();
            info.RegisterTime = DateTime.Now;
            info.TotalMoney = 0;
            info.Account = username;
            info.MemberName = xingMing;
            info.MemberState = EyouSoft.Model.Enum.UserStatus.正常;
            info.Mobile = username;
            info.PassWord = new EyouSoft.BLL.OtherStructure.BYanZhengMa().CreateYanZhengMa(6);
            info.ZhiFuPassword = info.PassWord;
            info.UserType = EyouSoft.Model.Enum.MemberTypes.普通会员;

            var zhuCeResult = new EyouSoft.IDAL.MemberStructure.BMember2().Add(info);

            if (!zhuCeResult) Utils.RCWE(UtilsCommons.AjaxReturnJson("-4", "注册失败，请重新提交"));

            new EyouSoft.BLL.OtherStructure.BYanZhengMa().SetYiShiYong(yanZhengMaInfo.IdentityId);

            EyouSoft.Model.SSOStructure.MUserInfo userInfo = null;

            var pwdInfo = new EyouSoft.Model.CompanyStructure.PassWord();
            info.MD5Password = new EyouSoft.Model.CompanyStructure.PassWord(info.PassWord).MD5Password;
            pwdInfo.SetMD5Pwd(info.MD5Password);
            EyouSoft.Security.Membership.UserProvider.Login(info.Account, pwdInfo, out userInfo);

            //发送短信
            var duanXinInfo = new EyouSoft.Model.OtherStructure.MDuanXinInfo();
            duanXinInfo.JieShouShouJi = username;
            duanXinInfo.NeiRong = "欢迎您注册成为商旅e家会员，您的会员账号为：" + info.Account + "，密码：" + info.PassWord + "。请妥善保管你的账号和密码信息。【商旅e家】";
            new EyouSoft.BLL.OtherStructure.BDuanXin().FaSong(duanXinInfo);

            string jinao_dingdanxiaoxi_kefu_shouji = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("JINAO_DINGDANXIAOXI_KEFU_SHOUJI");
            string jinao_dingdanxiaoxi_jidiao_shouji = EyouSoft.Toolkit.ConfigHelper.ConfigClass.GetConfigString("JINAO_DINGDANXIAOXI_JIDIAO_SHOUJI");
            

            duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_kefu_shouji;            
            new EyouSoft.BLL.OtherStructure.BDuanXin().FaSong(duanXinInfo);


            duanXinInfo.JieShouShouJi = jinao_dingdanxiaoxi_jidiao_shouji;
            new EyouSoft.BLL.OtherStructure.BDuanXin().FaSong(duanXinInfo);

            Utils.RCWE(UtilsCommons.AjaxReturnJson("1", ""));
        }

        /// <summary>
        /// 获取余额支付验证码
        /// </summary>
        void GetYuEZhiFuYanZhengMa()
        {
            decimal txtZhiFuJinE = Utils.GetDecimal(Utils.GetFormValue("txtZhiFuJinE"));
            if (txtZhiFuJinE <= 0) Utils.RCWE(UtilsCommons.AjaxReturnJson("-1", "请填写正确的支付金额"));
            MUserInfo loginYongHuInfo = null;
            var isLogin = EyouSoft.Security.Membership.UserProvider.IsLogin(out loginYongHuInfo);
            if (!isLogin) Utils.RCWE(UtilsCommons.AjaxReturnJson("-2", "异常请求：请登录"));

            var yongHuInfo = new EyouSoft.BLL.OtherStructure.BMember().GetModel(loginYongHuInfo.UserId);

            if (yongHuInfo.TotalMoney < txtZhiFuJinE) Utils.RCWE(UtilsCommons.AjaxReturnJson("-3", "账户余额不足"));

            var yanZhengMa = new EyouSoft.BLL.OtherStructure.BYanZhengMa().CreateYanZhengMa(6);
            var info = new EyouSoft.Model.OtherStructure.MYanZhengMaInfo();
            info.IssueTime = DateTime.Now;
            info.LeiXing =  EyouSoft.Model.Enum.YanZhengMaLeiXing.余额支付;
            info.ShouJi = yongHuInfo.Account;
            info.Status = 0;
            info.YanZhengMa = yanZhengMa;

            new EyouSoft.BLL.OtherStructure.BYanZhengMa().Insert(info);

            //发送短信
            var duanXinInfo = new EyouSoft.Model.OtherStructure.MDuanXinInfo();
            duanXinInfo.JieShouShouJi = yongHuInfo.Account;
            duanXinInfo.NeiRong = "您正在使用余额支付" + txtZhiFuJinE.ToString("F2") + "元，支付验证码：" + yanZhengMa + "。请勿将付款验证码提供给他人，30分钟内有效。【商旅e家】";

            new EyouSoft.BLL.OtherStructure.BDuanXin().FaSong(duanXinInfo);

            Utils.RCWE(UtilsCommons.AjaxReturnJson("1", "", yanZhengMa));
        }


        /// <summary>
        /// 根据用户邀请码获取域名
        /// </summary>
        void huoquyuming_yaoqingma()
        {
            var txt = Utils.GetFormValue("txt");
            if (string.IsNullOrEmpty(txt)) Utils.RCWE_AJAX("0");

            var yuMing = new EyouSoft.BLL.MemberStructure.BMember().GetYuMing_YaoQingMa(txt);

            if (string.IsNullOrEmpty(yuMing)) Utils.RCWE_AJAX("-1");

            var obj = new { YuMing = "p." + yuMing };

            Utils.RCWE_AJAX("1", "", obj);
        }
        #endregion
    }
}
