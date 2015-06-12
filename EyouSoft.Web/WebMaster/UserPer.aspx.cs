using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EyouSoft.Common;

namespace EyouSoft.Web.WebMaster
{
    public partial class UserPer : Common.Page.WebmasterPageBase
    {
        //权限html
        protected string PowerStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //权限验证
            PowerControl();

            if (Utils.GetQueryStringValue("dotype") == "save")
            {
                Response.Clear();
                Response.Write(this.Save());
                Response.End();
            }
            else
            {
                PageInit();
            }
        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="id">操作ID</param>
        protected void PageInit()
        {
            int RoleId = Utils.GetInt(EyouSoft.Common.Utils.GetQueryStringValue("id"));
            //当前角色的所有权限ID
            string[] PowerIds = { };
            System.Text.StringBuilder str = new System.Text.StringBuilder();

            var model = new BLL.OtherStructure.BWebmaster().GetModel(Utils.GetInt(Utils.GetQueryStringValue("id")));
            string[] pr = null;
            if (model != null)
            {
                pr = model.Permissions.Split(',');
            }

            var list1 = EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.Privs.Menu1)).Where(i => i.Value != "0").ToList();
            if (list1 != null)
            {
                //一级栏目
                for (int i = 0; i < list1.Count; i++)
                {
                    str.Append("<table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\"> <tbody><tr>");
                    str.AppendFormat(" <td width=\"92\" height=\"30\" align=\"center\" bgcolor=\"#BDDCF4\">{0}&nbsp;&nbsp;", list1[i].Text);
                    str.AppendFormat("<label><input type=\"checkbox\" name=\"chkAll\" value=\"{0}\"/>&nbsp;全选</label></td>", list1[i].Value);
                    str.Append(" </tr></tbody></table>");
                    str.Append("<div class=\"hr_5\"></div>");
                    str.Append(" <table width=\"100%\" cellspacing=\"1\" cellpadding=\"0\" border=\"0\"  align=\"center\"><tbody>");
                    var list2 = EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.Privs.Menu2)).Where(c => c.Value.StartsWith(list1[i].Value)).ToList();
                    if (list2 != null)
                    {
                        //每行显示4列,共循环多少次
                        for (int k = 0; k <= list2.Count / 3; k++)
                        {
                            str.Append("<tr>");
                            for (int j = k * 3; j < list2.Count; j++)
                            {
                                //当前权限是否选中
                                bool check = false;
                                if (pr != null && pr.Length > 0)
                                {
                                    for (int t = 0; t < pr.Length; t++)
                                    {
                                        check = false;
                                        if (pr[t] == list2[j].Value)
                                        {
                                            check = true;
                                            break;
                                        }
                                    }
                                }
                                str.AppendFormat("<td width=\"33%\" height=\"26\" align=\"left\"><label>&nbsp;&nbsp;<input type=\"checkbox\" MenuId =\"{0}\" Menu2Id=\"{1}\" name=\"chkMenu\" {2} value=\"{3}\"/>&nbsp;{4}</label></td>", list1[i].Value, list2[j].Value, check ? "checked=\"checked\"" : "", list2[j].Value, list2[j].Text);
                                if ((j != 0 && (j + 1) % 3 == 0) || j + 1 == list2.Count)
                                {
                                    str.Append("</tr>");
                                    break;
                                }
                            }
                        }
                    }
                    str.Append("</tbody></table><div class=\"hr_5\"></div>");
                }
            }
            var otherList = EyouSoft.Common.EnumObj.GetList(typeof(EyouSoft.Model.Enum.Privs.Privs));
            if (otherList != null && otherList.Count > 0)
            {
                str.Append("<table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\"> <tbody><tr>");
                str.Append(" <td width=\"92\" height=\"30\" align=\"center\" bgcolor=\"#BDDCF4\">其他&nbsp;&nbsp;");
                str.Append("<label><input type=\"checkbox\" name=\"chkAll\" value=\"10000\"/>&nbsp;全选</label></td>");
                str.Append(" </tr></tbody></table>");
                str.Append("<div class=\"hr_5\"></div>");
                str.Append(" <table width=\"100%\" cellspacing=\"1\" cellpadding=\"0\" border=\"0\"  align=\"center\"><tbody>");
                if (otherList != null)
                {
                    //每行显示4列,共循环多少次
                    for (int k = 0; k <= otherList.Count / 3; k++)
                    {
                        str.Append("<tr>");
                        for (int j = k * 3; j < otherList.Count; j++)
                        {
                            //当前权限是否选中
                            bool check = false;
                            if (pr != null && pr.Length > 0)
                            {
                                for (int t = 0; t < pr.Length; t++)
                                {
                                    check = false;
                                    if (pr[t] == otherList[j].Value)
                                    {
                                        check = true;
                                        break;
                                    }
                                }
                            }
                            str.AppendFormat("<td width=\"33%\" height=\"26\" align=\"left\"><label>&nbsp;&nbsp;<input type=\"checkbox\" MenuId =\"10000\"  Menu2Id=\"{0}\" name=\"chkMenu\" {1} value=\"{2}\"/>&nbsp;{3}</label></td>", otherList[j].Value, check ? "checked=\"checked\"" : "", otherList[j].Value, otherList[j].Text);
                            if ((j != 0 && (j + 1) % 3 == 0) || j + 1 == otherList.Count)
                            {
                                str.Append("</tr>");
                                break;
                            }
                        }
                    }
                }
                str.Append("</tbody></table><div class=\"hr_5\"></div>");
            }
            PowerStr = str.ToString();
        }

        /// <summary>
        /// 权限控制
        /// </summary>
        private bool PowerControl()
        {
            if (!this.CheckGrantPrivs(EyouSoft.Model.Enum.Privs.Privs.权限分配))
            {
                isPriv.Visible = false;
                return false;
            }
            isPriv.Visible = true;
            return true;
        }

        protected string Save()
        {
            int uid = Utils.GetInt(Utils.GetQueryStringValue("id"));
            if (uid <= 0)
            {
                return UtilsCommons.AjaxReturnJson("0", "url错误，请刷新后重试！");
            }

            if (!PowerControl())
            {
                return UtilsCommons.AjaxReturnJson("0", "你没有权限进行操作！");
            }
            string perm = "";
            int length = Utils.GetFormValues("chkMenu").Length;
            for (int i = 0; i < length; i++)
            {
                perm += Utils.GetFormValues("chkMenu")[i] + ",";
            }
            if (!string.IsNullOrEmpty(perm))
            {
                perm = perm.Trim(',');
            }
            if (string.IsNullOrEmpty(perm))
            {
                return UtilsCommons.AjaxReturnJson("0", "请选择权限！");
            }
            if (new BLL.OtherStructure.BWebmaster().UpdatePrivs(perm, uid))
            {
                return UtilsCommons.AjaxReturnJson("1", "权限分配成功");
            }
            return UtilsCommons.AjaxReturnJson("0", "权限分配失败");
        }
    }
}
