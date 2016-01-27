using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using Common.page;
using EyouSoft.InterfaceLib.Common;
using EyouSoft.BLL.OtherStructure;
using EyouSoft.IDAL.MemberStructure;

namespace EyouSoft.WAP.Member
{
    public partial class UpdateMiMa : HuiYuanWapPageBase
    {
        BMember2 mobll = new BMember2();
        MMember2 mod = new MMember2();
        protected void Page_Load(object sender, EventArgs e)
        {
            WapHeader1.HeadText = "修改密码";
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
            MMember2 model = mobll.Get(HuiYuanInfo.UserId);
            if (Utils.GetFormValue("oldword").Trim() == model.PassWord)
            {
                if (Utils.GetFormValue("newword").Trim() == Utils.GetFormValue("twoword").Trim())
                {
                    if (IsNumAndEnCh(Utils.GetFormValue("newword").Trim()) && Utils.GetFormValue("newword").Trim().Length >= 6)
                    {
                        mod.PassWord = Utils.GetFormValue("newword").Trim();
                        mod.MemberID = HuiYuanInfo.UserId;
                        //IDAL.MemberStructure.DMember2 dal = new DMember2();
                        iscount = new EyouSoft.BLL.MemberStructure.BMember().UpdateMemberPass(mod);
                        if (iscount)
                        {
                            msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "1", "密码修改成功！");
                        }
                        else
                        {
                            msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "0", "密码修改失败！");

                        }
                    }
                    else
                    {
                        msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "0", "新密码不能为空且长度必须大于六位！");
                    }
                }
                else
                {
                    msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "0", "两次填写的密码必须一致！");

                }
            }
            else
            {
                msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "0", "您的旧密码填写有误！");

            }
            return msg;
        }
        public static bool IsNumAndEnCh(string input)
        {
            string pattern = @"^[A-Za-z0-9]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }
    }
}
