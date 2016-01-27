<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterStep2.aspx.cs"
    Inherits="EyouSoft.WAP.RegisterStep2" %>

<%@ Register Src="userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">


    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

    <script src="/js/iscroll.js" type="text/javascript"></script>

    <script src="/js/slogin.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <uc1:WapHeader ID="WapHeader1" runat="server" HeadText="手机注册" />
    <div class="warp">
        <div class="reg_step">
            <ul class="clearfix">
                <li class="jiantou">1.填写手机号</li>
                <li class="jiantou font_yellow">2.短信验证</li>
                <li>3.注册成功</li>
            </ul>
        </div>
        <div class="user_form">
            <ul>
                <li><span class="label_name">验证码</span>
                    <input type="tel" class="u-input" style="width: 80px;" value="验证码" onfocus="javascript:if(this.value=='验证码')this.value='';"
                        onblur="javascript:if(this.value=='')this.value='验证码';">
                    <a id="code_msg" class="code_btn">50秒后重新发送</a> </li>
            </ul>
        </div>
        <div class="padd cent">
            <input name="" type="button" class="y_btn" value="下一步"></div>
    </div>
    </form>

    <script type="text/javascript">
    var pageOpt
        var second = parseInt($("#second").html());
        var timer;
        function change() {
            second--;
            if (second > -1) {
                $("#second").html(second);
                timer = setTimeout('change()', 1000); //调用自身实现
            }
            else {
                window.location.href = "/default.aspx"
            }
        }
        timer = setTimeout('change()', 1000);
    </script>

</body>
</html>
