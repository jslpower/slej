<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lg.aspx.cs" Inherits="EyouSoft.Web.CommonPage.Lg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Css/style.css" rel="stylesheet" type="text/css" />

    <script src="/JS/jquery-1.4.4.js" type="text/javascript"></script>

    <script src="/JS/table-toolbar.js" type="text/javascript"></script>

    <script src="/JS/jquery.blockUI.js" type="text/javascript"></script>

    <script src="/JS/slogin.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="mainbox">
        <div class="u_login">
            <div class="user_side">
                <div class="title">
                    用户登录</div>
                <div class="userbox">
                    <ul>
                        <li><span class="user-txt">账&nbsp;&nbsp;号：</span><input id="u" type="text" class="inputbk formsize180" /></li>
                        <li><span class="user-txt">密&nbsp;&nbsp;码：</span><input id="p" type="password" class="inputbk formsize180" /></li>
                        <li class="padd"><a href="#" class="font_yellow">忘记密码，请点这里取回！</a></li>
                        <li class="padd">
                            <input id="loginbtn" type="button" value="马上登录" class="user-btn" /></li>
                    </ul>
                </div>
                <div class="bot">
                </div>
            </div>
        </div>
    </div>
    </form>

    <script type="text/javascript">
        function login() {
            var u = $.trim($("#u").val()), p = $.trim($("#p").val()), ckcode = "";
            if (u == "") {
                tableToolbar._showMsg("请输入用户名!");
                $("#u").focus();
                return;
            }
            if (p == "") {
                tableToolbar._showMsg("请输入密码");
                return;
            }

            tableToolbar._showMsg("正在登录....");
            $("#btnLogin").unbind().css("cursor", "default").val("登录中");

            blogin5({ u: u, p: p, vc: ckcode }
                , function(h) {//login success callback
                    tableToolbar._showMsg("登录成功，正进入系统....");
                    var s = '<%=Request.QueryString["rurl"] %>';
                    if (s.length > 0)
                    { parent.window.location.href = s; }
                    else { parent.window.location.reload(); }
                }
                , function(m) {//login error callbackfffffff
                    tableToolbar._showMsg(m);
                    $("#loginbtn").click(function() { login(); return false; }).css("cursor", "pointer").val("马上登录");
                });
        }
        $(function() {
            $("#loginbtn").click(function() { login() });
        })
    </script>

</body>
</html>
