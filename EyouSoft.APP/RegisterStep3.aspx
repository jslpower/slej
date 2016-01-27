<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterStep3.aspx.cs"
    Inherits="EyouSoft.WAP.RegisterStep3" %>

<%@ Register Src="userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">


    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

    <script src="/js/iscroll.js" type="text/javascript"></script>

</head>
<body>
    <uc1:WapHeader ID="WapHeader1" runat="server" HeadText="注册完成" />
    <div class="warp">
        <div class="reg_step">
            <ul class="clearfix">
                <li class="jiantou">1.填写手机号</li>
                <li class="jiantou">2.短信验证</li>
                <li class="font_yellow">3.注册成功</li>
            </ul>
        </div>
        <div class="reg_ok cent font_yellow font26">
            恭喜！注册成功</div>
        <div class="mt10 cent font16">
            <span id="second">5</span>秒后返回首页</div>
    </div>

    <script type="text/javascript">
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
