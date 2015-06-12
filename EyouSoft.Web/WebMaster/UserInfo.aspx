<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="EyouSoft.Web.WebMaster.UserInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>个人信息</title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/Js/jquery-1.4.4.js"></script>

    <script src="../JS/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server" action="UserInfo.aspx?save=1">
    <div class="tablelist">
        <table width="780" cellspacing="1" cellpadding="0" border="0" bgcolor="#BDDCF4" align="center">
            <tbody>
                <tr>
                    <th colspan="3" align="center" bgcolor="#BDDCF4">
                        个人信息
                    </th>
                </tr>
                <tr>
                    <td height="35" align="right" bgcolor="#e3f1fc">
                        <strong>用户名：</strong>
                    </td>
                    <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                        <asp:Literal runat="server" ID="ltrUserName"></asp:Literal>
                        <input type=hidden  id="txtIsEnabled" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right" bgcolor="#e3f1fc">
                        <strong>密码：</strong>
                    </td>
                    <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                        <asp:TextBox runat="server" ID="txtPassWord" size="50" CssClass="inputtext" TextMode="Password"></asp:TextBox>
                        <span style="color: Red; font-size: 12px;">不填写密码则不修改密码</span>
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right" bgcolor="#e3f1fc">
                        <strong>重复密码：</strong>
                    </td>
                    <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                        <asp:TextBox runat="server" ID="txtCFPassWord" size="50" CssClass="inputtext" TextMode="Password"></asp:TextBox>
                        <span style="color: Red; font-size: 12px;">不填写密码则不修改密码</span>
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right" bgcolor="#e3f1fc">
                        <span style="color: Red; font-size: 12px;">*</span><strong>姓名：</strong>
                    </td>
                    <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                        <input id="txtContactName" runat="server" type="text" size="50" class="inputtext" />
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right" bgcolor="#e3f1fc">
                        <strong>电话：</strong>
                    </td>
                    <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                        <input id="txtTel" runat="server" type="text" size="50" class="inputtext" />
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right" bgcolor="#e3f1fc">
                        <strong>QQ：</strong>
                    </td>
                    <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                        <input id="txtQQ" runat="server" type="text" size="50" class="inputtext" />
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right" bgcolor="#e3f1fc">
                        <strong>手机：</strong>
                    </td>
                    <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                        <input id="txtMobile" runat="server" type="text" size="50" class="inputtext" />
                    </td>
                </tr>
                <tr>
                    <td height="30" align="center" colspan="3">
                        <table cellspacing="0" cellpadding="0" border="0" align="left">
                            <tbody>
                                <tr>
                                    <td width="114" height="40" align="center">
                                    </td>
                                    <td width="84" height="40" align="center" class="tjbtn02">
                                        <a href="javascript:;" id="btn_save" onclick="return save();">保存</a>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>

    <script type="text/javascript">

        $(document).ready(function() {
            $("#<%= txtPassWord.ClientID %>").val("");
            $("#<%= txtCFPassWord.ClientID %>").val("");
        });

        //保存表单
        function save() {
            var na = $.trim($("#<%= txtContactName.ClientID %>").val());
            var pw = $.trim($("#<%= txtPassWord.ClientID %>").val());
            var cpw = $.trim($("#<%= txtCFPassWord.ClientID %>").val());
            var strErr = "";

            if (na == "") {
                strErr += "请填写姓名<br />";
            }
            if (pw != cpw) {
                strErr += "请保证两次填写的密码一致<br />";
            }

            if (strErr != "") {
                tableToolbar._showMsg(strErr);
                return false;
            }

            //$("#btn_save").closest("form").get(0).submit();
            $("#<%=form1.ClientID %>").submit();
            return false;
        }
   
    </script>

</body>
</html>
