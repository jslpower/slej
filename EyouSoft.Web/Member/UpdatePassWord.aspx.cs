using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Common.page;
using System.Web.UI.WebControls;
using EyouSoft.IDAL.MemberStructure;
using System.Text.RegularExpressions;
using EyouSoft.BLL.MemberStructure;
using EyouSoft.Common;

namespace EyouSoft.Web.Member
{
    public partial class UpdatePassWord : ClientModelViewPageBase<EyouSoft.Model.MemberStructure.WebModel.MMember2SearchModel>
    {
        BMember bll = new BMember();
        BMember2 mobll = new BMember2();
        MMember2 mod = new MMember2();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HuiYuanInfo.UserId == "Guest" || HuiYuanInfo.UserId == "")
            {
                Response.Redirect("/Default.aspx");
            }
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
            if (oldpassword.Value.Trim() == model.PassWord)
            {
                if (passwordone.Value.Trim() == passwordtwo.Value.Trim())
                {
                    if (IsNumAndEnCh(passwordone.Value.Trim()) && passwordone.Value.Trim().Length >= 6)
                    {
                        mod.PassWord = passwordone.Value.Trim();
                        mod.MemberID = HuiYuanInfo.UserId;
                        //IDAL.MemberStructure.DMember2 dal = new DMember2();
                        iscount = bll.UpdateMemberPass(mod);
                        if (iscount)
                        {
                            msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "1", "密码修改成功！");
                        }
                        else
                        {
                            msg = string.Format("{{\"result\":\"{0}\",\"msg\":\"{1}\"}}", "0", "密码修改失败！");

                        }
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

        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{
        //    MMember2 model = mobll.Get(HuiYuanInfo.UserId);
        //    if (oldpassword.Value.Trim() == model.PassWord)
        //    {
        //        if (passwordone.Value.Trim() == passwordtwo.Value.Trim())
        //        {
        //            if (IsNumAndEnCh(passwordone.Value.Trim()) && passwordone.Value.Trim().Length >= 6)
        //            {
        //                mod.PassWord = passwordone.Value.Trim();
        //                mod.MemberID = HuiYuanInfo.UserId;
        //                //IDAL.MemberStructure.DMember2 dal = new DMember2();
        //                bool iscount = bll.UpdateMemberPass(mod);
        //                if (iscount)
        //                {
        //                    Response.Write("<script type='text/javascript'>alert('密码修改成功!');</script>");
        //                    //ReturnAjax(1, "密码修改成功!");
        //                }
        //                else
        //                {
        //                    Response.Write("<script type='text/javascript'>alert('密码修改失败!');</script>");
        //                    //ReturnAjax(-1, "密码修改失败!");
        //                }
        //            }
        //        }
        //        else
        //        {
        //            Response.Write("<script type='text/javascript'>alert('两次填写的密码必须一致!');</script>");
        //            //ReturnAjax(-1, "两次填写的密码必须一致!");
        //        }
        //    }
        //    else
        //    {
        //        Response.Write("<script type='text/javascript'>alert('您的旧密码填写有误!');</script>");
        //        //ReturnAjax(-1, "您的旧密码填写有误!");
        //    }
        //}
        public static bool IsNumAndEnCh(string input)
        {
            string pattern = @"^[A-Za-z0-9]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }
    }
}