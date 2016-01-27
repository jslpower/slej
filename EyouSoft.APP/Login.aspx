<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EyouSoft.WAP.Login" %>

<%@ Register Src="userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>登录</title>

    <script src="/js/jquery_cm.js" type="text/javascript"></script>

    <script src="/js/slogin.js" type="text/javascript"></script>

    <script src="/js/table-toolbar.js" type="text/javascript"></script>

    <link rel="stylesheet" type="text/css" href="css/user.css" />
    <script type="text/javascript" src="cordova.js"></script>
    <script type="text/javascript" src="js/enow.core.js"></script>
</head>
<body>
    <uc1:WapHeader ID="WapHeader1" runat="server" HeadText="会员登录" />
    <div class="warp">
        <div class="user_form">
            <ul>
                <li class="padd0 cent font_yellow">已经是会员、贵宾、代理，请登录！</li>
                <li class="padd0 cent">
                    <input name="dlfs" type="radio" value="2" checked="checked" />
                    <label for="radio2">
                        验证码登录</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input name="dlfs" type="radio" value="1" />
                    <label for="radio1">
                        密码登录</label>
                    <input id="dlfs" type="hidden" value="2" />
                </li>
            </ul>
        </div>
        <div class="user_form" id="zhanghao" style="display: none;">
            <ul>
                <li><span class="label_name">用户名</span>
                    <input type="text" id="u" class="u-input" value="请输入手机号" onfocus="javascript:if(this.value=='请输入手机号')this.value='';"
                        onblur="javascript:if(this.value=='')this.value='请输入手机号';">
                </li>
                <li><span class="label_name">密 码</span>
                    <input type="password" id="p" class="u-input" value="请输入密码" onfocus="javascript:if(this.value=='请输入密码')this.value='';"
                        onblur="javascript:if(this.value=='')this.value='请输入密码';">
                </li>
            </ul>
            <div class="font14 paddT paddR right_txt" style="background: #e4e4e4;">
                <a href="/GetMiMa.aspx" class="font_blue">忘记密码？</a></div>
        </div>
        <div class="user_form" id="shouji">
            <ul>
                <li><span class="label_name">手机号</span>
                    <input type="text" id="txt_denglu_shouji" class="u-input" value="请输入手机号" onfocus="javascript:if(this.value=='请输入手机号')this.value='';"
                        onblur="javascript:if(this.value=='')this.value='请输入手机号';">
                </li>
                <li><span class="label_name">验证码</span>
                    <input type="tel" id="txt_denglu_yzm" class="u-input" style="width: 80px;" value="验证码"
                        onfocus="javascript:if(this.value=='验证码')this.value='';" onblur="javascript:if(this.value=='')this.value='验证码';">
                    <a id="l_huoquyzm" class="yzm">获取验证码</a> <a class="code_btn" style="display: none;">
                        50秒后重新发送</a> </li>
            </ul>
        </div>
        <div class="padd10 cent">
            <input id="loginbtn" type="button" class="y_btn" value="马上登录"></div>
        <div class="padd10 cent">
            <a href="/RegisterStep1.aspx" class="b_btn">1分钟免费注册</a></div>
        <div class="cent code_box">
            <p>
                <img src="/ErWeiMa.aspx?codeurl=<%=HttpContext.Current.Request.Url.AbsoluteUri.ToLower().Replace("p.","m.") %>" />
            </p>
            <p>
                分享给朋友~~</p>
        </div>
    </div>
    <div id="TiJiaoMask" class="user-mask" style="display: none;">
        <div class="h-mask-cnt" style="margin-top: 200px;">
            <div class="cent font_yellow font16" style="padding-top: 20px;">
                正在登录,请等待......
            </div>
        </div>
    </div>
</body>

<script type="text/javascript">
    $(function() {
        $("input[name=dlfs]").click(function() {
            $("#dlfs").val($(this).val());
            var fangshi = $("#dlfs").val();
            if (fangshi == "2") {
                $("#shouji").show();
                $("#zhanghao").hide();
            }
            else {
                $("#shouji").hide();
                $("#zhanghao").show();
            }
        });
    });
    function login() {
        var u, p, ckcode;
        if ($("#dlfs").val() == "1") {
            u = $.trim($("#u").val());
            p = $.trim($("#p").val());
            ckcode = "1";
        }
        else {
            u = $.trim($("#txt_denglu_shouji").val());
            p = $.trim($("#txt_denglu_yzm").val());
            ckcode = "2";
        }
        if (u == "") {
            alert("请输入用户名!");
            $("#u").focus();
            return;
        }
        if (p == "") {
            alert("请输入密码");
            return;
        }

        $("#loginbtn").css("cursor", "default").val("登录中");
        $("#TiJiaoMask").toggle();

        blogin5({ u: u, p: p, vc: ckcode }
                , function(h) {//login success callback
                    var s = '<%=Request.QueryString["rurl"] %>';
                    if (s.length > 0)
                    { window.location.href = s; }
                    else { window.location.href = "/Member/UserCenter.aspx"; }
                }
                , function(m) {//login error callbackfffffff
                    alert(m);
                    $("#loginbtn").css("cursor", "pointer").val("马上登录");
                    $("#TiJiaoMask").toggle();
                });
    }

    $(document).ready(function() {
        $("#loginbtn").click(function() { login() });
        $("#l_huoquyzm").click(function() { userLoginReg.getDLYanZhengMa(this) });
    });

    var userLoginReg = {
        getDLYanZhengMa: function(obj) {
            $(obj).unbind("click");
            var _data = { shouJi: $.trim($("#txt_denglu_shouji").val()) };
            var clock = 60;
            var _getYanZhengMaResult = iLogin.getDengLuYanZhengMa(_data);

            if (!_getYanZhengMaResult.success) { $(obj).click(function() { userLoginReg.getDLYanZhengMa(obj); }); return; }

            $(obj).removeClass("yzm").addClass("code_btn").text("验证码已发送");
            var iii = setInterval(function() {
                clock = clock - 1;
                $(obj).text("已发送(" + clock + "s)");
                if (clock <= 0) {
                    clearInterval(iii);
                    $(obj).removeClass("code_btn").addClass("yzm").text("获取验证码").click(function() { userLoginReg.getDLYanZhengMa(obj); });
                }
            }, 1000);
        }
    }
</script>

</html>
