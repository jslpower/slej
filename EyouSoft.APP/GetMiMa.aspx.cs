using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.BLL.OtherStructure;
using EyouSoft.IDAL.MemberStructure;
using EyouSoft.Common;

namespace EyouSoft.WAP
{
    public partial class GetMiMa : System.Web.UI.Page
    {
        BMember bll = new BMember();
        BMember2 mobll = new BMember2();
        MMember2 mod = new MMember2();
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "重置密码";
            string type = Utils.GetQueryStringValue("type").Trim();
            switch (type)
            {
                case "update":
                    Response.Clear();
                    Response.Write(UpdatePass());
                    Response.End();
                    break;
                default:
                    break;
            }
        }
        private string UpdatePass()
        {
            string msg = "";
            bool iscount = false;
            MMember2 model = mobll.GetByAccount(Utils.GetFormValue("txt_shouji"));
            if (model != null)
            {
                mod.PassWord = GetPassWord();
                mod.ZhiFuPassword = mod.PassWord;
                mod.MemberID = model.MemberID;
                iscount = new EyouSoft.BLL.MemberStructure.BMember().UpdateMemberPass(mod);
                new EyouSoft.BLL.MemberStructure.BMember().UpdateMemberZhifu(mod);
                if (iscount == true)
                {
                    var duanXinInfo = new EyouSoft.Model.OtherStructure.MDuanXinInfo();
                    duanXinInfo.JieShouShouJi = model.Mobile;
                    duanXinInfo.NeiRong = "您的新密码为：" + mod.PassWord + "，请请及时登陆系统修改！。【商旅e家】";

                    new EyouSoft.BLL.OtherStructure.BDuanXin().FaSong(duanXinInfo);
                    msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "1", "新密码已经通过短信发送至您手机，请查收！");
                }
                else
                {
                    msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "0", "重置失败，请联系客服！");
                }
            }
            else
            {
                msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "0", "您的登录名填写有误！");

            }
            return msg;
        }
        public string GetPassWord()
        {
            string pass = "";
            Random rand = new Random();
            for (int i = 0; i < 6; i++)
            {
                pass += rand.Next(0, 9);
            }
            return pass;
        }
    }
}
