using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;
using EyouSoft.Toolkit.ConfigHelper;

namespace EyouSoft.Web.CommonPage
{
    public partial class RegBox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            string dotype = Utils.GetQueryStringValue("register");
            if (Utils.GetQueryStringValue("Code") == "1") sendCode();
            if (dotype == "1")
            {
                Log();
            }*/
        }

        /*
        protected void Log()
        {
            string name = Utils.GetFormValue("txtYuDName");
            string Tel = Utils.GetFormValue("txtYuDTel");


            #region  验证码

            //string ViaCode = Utils.GetFormValue("txtCode");
            //List<string[]> list = new List<string[]>();
            //list = Session[Tel] as List<string[]>;
            //string msg = string.Empty;
            //bool via = false;
            //if (list != null)
            //{
            //    for (int i = 0; i < list.Count; i++)
            //    {
            //        if (!string.IsNullOrEmpty(ViaCode) && ViaCode == list[i][1] && DateTime.Compare(Convert.ToDateTime(list[i][2]).AddMinutes(5), DateTime.Now) > 0)
            //        {
            //            msg = list[i][1];
            //            via = true;
            //        }
            //    }
            //}

            //if (!string.IsNullOrEmpty(ViaCode) && !via)
            //{
            //    Utils.RCWE(UtilsCommons.AjaxReturnJson("-1", "验证码输入错误！"));
            //}
            #endregion



            Model.SSOStructure.MUserInfo userInfo = null;
            if (Security.Membership.UserProvider.IsLogin(out userInfo))
            {
                if (userInfo != null)
                {
                    Utils.RCWE(UtilsCommons.AjaxReturnJson("-1", "已经登录无需重复登录！"));
                }
            }
            else
            {
                var bll = new BLL.OtherStructure.BMember();
                if (bll.ExistsUserName(Tel, string.Empty)) Utils.RCWE(UtilsCommons.AjaxReturnJson("-2", "用户名已经存在，请登录！"));

                if (string.IsNullOrEmpty(name))
                {
                    Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "请填写用户名！"));
                }
                if (string.IsNullOrEmpty(Tel))
                {
                    Utils.RCWE(UtilsCommons.AjaxReturnJson("0", "请填写手机！"));
                }

                var model = new Model.MMember
                {
                    Account = Tel,
                    Address = string.Empty,
                    BirthDate = Utils.GetDateTimeNullable(Utils.GetFormValue("txtCSDate")),
                    CardNo = string.Empty,
                    CardType = Model.Enum.CardType.请选择,
                    CarInfo = "",
                    Contact = "",
                    Email = "",
                    Fax = string.Empty,
                    IsCar = false,
                    LoginIP = Common.Function.StringValidate.GetRemoteIP(),
                    LoginNum = 1,
                    LoginTime = DateTime.Now,
                    MemberID = string.Empty,
                    MemberName = name,
                    MemberState = Model.Enum.UserStatus.正常,
                    Mobile = Tel,
                    NickName = string.Empty,
                    PassWord = new Model.CompanyStructure.PassWord("000000"),
                    Photo = string.Empty,
                    qq = "",
                    Gender = EyouSoft.Model.Enum.Gender.男,
                    UserType = EyouSoft.Model.Enum.MemberTypes.普通会员,
                    RegisterTime = DateTime.Now
                };
                var r = bll.Add(model); int num = 0;
                if (r)
                {
                    num = Security.Membership.UserProvider.Login(model.Account, model.PassWord, out userInfo);
                }
                Utils.RCWE(UtilsCommons.AjaxReturnJson("1", string.Format("{0}", num > 0 ? "提交成功，请稍后……" : "失败！")));

            }
        }
        /// <summary>
        /// 发送验证码
        /// </summary>
        void sendCode()
        {
            string name = Utils.GetFormValue("txtYuDName");
            string Tel = Utils.GetFormValue("txtYuDTel");
            string code = new Random().Next(100000, 999999).ToString();
            string result = string.Empty;
            int i = new EyouSoft.BLL.VoSmsApi.Service().SendSms("", Tel, string.Format("你好，你正在使用金奥旅游,验证码{0}！有效期为五分钟，如果不是本人操作可以忽略！[商旅e家]", code), ConfigClass.GetConfigString("SMS_Username"), ConfigClass.GetConfigString("SMS_Pwd"));

            if (i == 0)
            {
                List<string[]> list = new List<string[]>();
                if (Session[Tel] != null)
                {
                    list = Session[Tel] as List<string[]>;
                    if (list.Count > 5)
                    {
                        result = "重复次数过多，请24小时之后再操作！";
                        return;
                    }
                    string[] arrStr = new string[] { Tel, code, DateTime.Now.ToString() };
                    list.Add(arrStr);

                }
                else
                {
                    list.Add(new string[] { Tel, code, DateTime.Now.ToString() });
                    Session[Tel] = list;
                }
                Session.Timeout = 1440;
            }

            Response.Clear();
            Response.Write(UtilsCommons.AjaxReturnJson(i == 0 ? "1" : "0", i == 1 ? "短信已发送，请查收！" : "获取短信失败，稍后再试！"));
            Response.End();

        }*/
         
    }
}
