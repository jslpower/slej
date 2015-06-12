<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="EyouSoft.Web.WebMaster.UserEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑管理用户信息</title>
    <link href="/Css/webmaster/style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/Js/jquery-1.4.4.js"></script>

    <script src="../JS/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="tablelist">
        <table width="780" cellspacing="1" cellpadding="0" border="0" bgcolor="#BDDCF4" align="center">
            <tbody>
                <tr>
                    <td height="35" align="right" bgcolor="#e3f1fc">
                        <span style="color: Red; font-size: 12px;">*</span><strong>用户名：</strong>
                    </td>
                    <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                        <asp:TextBox runat="server" ID="txtUserName" size="50" CssClass="inputtext" MaxLength="16"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right" bgcolor="#e3f1fc">
                        <span style="color: Red; font-size: 12px;">*</span><strong>账户状态：</strong>
                    </td>
                    <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                        <asp:DropDownList ID="ddlStateType" runat="server" CssClass="inputselect">
                            <asp:ListItem Value="1" Text="启用"></asp:ListItem>
                            <asp:ListItem Value="0" Text="停用"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right" bgcolor="#e3f1fc">
                        <strong>密码：</strong>
                    </td>
                    <td height="35" colspan="2" align="left" bgcolor="#FAFDFF" class="pandl3">
                        <asp:TextBox runat="server" ID="txtPassWord" size="50" CssClass="inputtext" MaxLength="16"
                            TextMode="Password"></asp:TextBox>
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
                                        <a href="javascript:;" id="btn_save">保存</a>
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

        var UserEdit = {
            existsUserName: function(un) {
                var isExists = "0";
                if ('<%= EyouSoft.Common.Utils.GetQueryStringValue("action") %>' != 'edit') {
                    var dataExists = {
                        exists: "1",
                        un: un
                    };
                    $.newAjax({
                        type: "post",
                        cache: false,
                        url: "/WebMaster/UserEdit.aspx?" + $.param(dataExists),
                        dataType: "json",
                        async: false,
                        success: function(ret) {
                            isExists = ret.result;
                        }
                    });
                }

                return isExists;
            },
            saveUser: function() {

                $("#btn_save").html("提交中").unbind("click").css({ "color": "#999999" });

                var un = $("#<%= txtUserName.ClientID %>").val();
                var na = $("#<%= txtContactName.ClientID %>").val();
                var pw = $("#<%= txtPassWord.ClientID %>").val();
                var cpw = $("#<%= txtCFPassWord.ClientID %>").val();
                var strErr = "";

                if ($.trim(un) == "") {
                    strErr += "请填写用户名<br />";
                }
                if ($.trim(na) == "") {
                    strErr += "请填写姓名<br />";
                }
                if ('<%= EyouSoft.Common.Utils.GetQueryStringValue("action") %>' != 'edit') {
                    if ($.trim(pw) == "") {
                        strErr += "请填写密码<br />";
                    }
                }
                if (pw != cpw) {
                    strErr += "请保证两次填写的密码一致<br />";
                }
                if (strErr == "") {
                    if (UserEdit.existsUserName(un) == "1") {
                        strErr += "用户名已经存在！<br />";
                    }
                }

                if (strErr != "") {
                    tableToolbar._showMsg(strErr);
                    UserEdit.bindBtn();
                    return false;
                }

                var data = {
                    action: '<%= EyouSoft.Common.Utils.GetQueryStringValue("action") %>',
                    id: '<%= EyouSoft.Common.Utils.GetQueryStringValue("id") %>',
                    save: "1",
                    leixing: '<%=EyouSoft.Common.Utils.GetQueryStringValue("LeiXing") %>',
                    gysid: '<%=EyouSoft.Common.Utils.GetQueryStringValue("GysId") %>'
                };

                $.newAjax({
                    type: "post",
                    cache: false,
                    url: "/WebMaster/UserEdit.aspx?" + $.param(data),
                    data: $("#btn_save").closest("form").serialize(),
                    dataType: "json",
                    success: function(ret) {
                        //ajax回发提示
                        if (ret.result == "1") {
                            tableToolbar._showMsg(ret.msg, function() { location.href = '/WebMaster/UserList.aspx' });
                        }
                        else {
                            tableToolbar._showMsg(ret.msg, function() { UserEdit.bindBtn(); });
                        }
                    },
                    error: function() {
                        tableToolbar._showMsg(tableToolbar.errorMsg, function() { UserEdit.bindBtn(); });
                    }
                });
            },
            bindBtn: function() {
                $("#btn_save").html("保存").css({ "color": "" });
                $("#btn_save").click(function() {
                    UserEdit.saveUser();
                    return false;
                });
            }
        };


        $(document).ready(function() {

            if ('<%= EyouSoft.Common.Utils.GetQueryStringValue("action") %>' != 'edit') {
                $("#<%= txtPassWord.ClientID %>").val("");
                $("#<%= txtCFPassWord.ClientID %>").val("");
            }

            UserEdit.bindBtn();
        });
   
    </script>

</body>
</html>
