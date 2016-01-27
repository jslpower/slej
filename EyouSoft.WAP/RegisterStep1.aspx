<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterStep1.aspx.cs"
    Inherits="EyouSoft.WAP.RegisterStep1" %>

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
    <div class="warp" id="step1">
        <div class="reg_step">
            <ul class="clearfix">
                <li class="jiantou font_yellow">1.填写手机号</li>
                <li class="jiantou">2.短信验证</li>
                <li>3.注册成功</li>
            </ul>
        </div>
        <div class="user_form">
            <ul>
                <li><span class="label_name">姓名</span>
                    <input id="txt_name" name="txt_name" type="tel" class="u-input" value="请输入姓名" onfocus="javascript:if(this.value=='请输入姓名')this.value='';"
                        onblur="javascript:if(this.value=='')this.value='请输入姓名';" />
                </li>
                <li><span class="label_name">手机号</span>
                    <input id="txt_shouji" name="txt_shouji" type="tel" class="u-input" value="请输入11位手机号"
                        onfocus="javascript:if(this.value=='请输入11位手机号')this.value='';" onblur="javascript:if(this.value=='')this.value='请输入11位手机号';" />
                </li>
            </ul>
        </div>
        <div class="padd cent">
            <input id="btn_step1" type="button" class="y_btn" value="下一步" /></div>
    </div>
    <div class="warp" id="step2" style="display: none">
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
                    <input id="txt_code" type="tel" class="u-input" style="width: 80px;" value="验证码"
                        onfocus="javascript:if(this.value=='验证码')this.value='';" onblur="javascript:if(this.value=='')this.value='验证码';">
                    <a id="code_msg" class="code_btn">60秒后重新发送</a> </li>
            </ul>
        </div>
        <div class="padd cent">
            <input id="btn_step2" type="button" class="y_btn" value="下一步"></div>
    </div>
    <div class="warp" id="step3" style="display: none">
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
            <span id="second">5</span>秒后跳转</div>
    </div>
    <div class="cent code_box">
        <p>
            <img src="/ErWeiMa.aspx?codeurl=<%=HttpContext.Current.Request.Url.AbsoluteUri.ToLower() %>" />
        </p>
          <p>
                长按上方二维码</p>
            <p>
                分享给朋友~~</p>
    </div>
    </form>
    <input type="hidden" id="mark" value="0" />

    <script type="text/javascript">
        var userLoginReg = {
            trim: function(obj) { return obj.replace(/(^\s*)|(\s*$)/g, ''); },
            getYanZhengMa: function(obj) {
                $(obj).unbind("click");
                var _data = { shouJi: userLoginReg.trim($("#txt_shouji").val()) };
                var _getYanZhengMaResult = iLogin.getZhuCeYanZhengMa(_data);

                if (!_getYanZhengMaResult.success) { $(obj).click(function() { userLoginReg.getYanZhengMa(obj); }); return; }
                $("#step1").hide(); $("#step2").show(); $("#mark").val("1");
                $("#code_msg").text("验证码已发送");
                setTimeout(function() { $("#code_msg").css({ color: "#fe6600" }).text("获取验证码").click(function() { userLoginReg.getYanZhengMa(obj); }); }, 60000);
            },
            zhuCe: function(obj) {
                $(obj).unbind("click");
                var _data = { shouJi: userLoginReg.trim($("#txt_shouji").val()), xingMing: userLoginReg.trim($("#txt_name").val()), yanZhengMa: userLoginReg.trim($("#txt_code").val()) };
                var _zhuCeResult = iLogin.zhuCe(_data);

                if (!_zhuCeResult.success) { $(obj).click(function() { userLoginReg.zhuCe(obj); }); return; }
                $("#step2").hide(); $("#step3").show(); $("#mark").val("2");
                userLoginReg.afterZhuCe();
                return false;
            },
            afterZhuCe: function() {

                var timer;

                timer = setTimeout(userLoginReg.setSecond, 1000);
            },
            setSecond: function() {
                var second = parseInt($("#second").html());
                second--;
                if (second > -1) {
                    $("#second").html(second);
                    timer = setTimeout(userLoginReg.setSecond, 1000);
                }
                else {

                    var rawUrl = '<%=Request.QueryString["rurl"] %>';
                    //tableToolbar._showMsg("登录成功，正进入系统....");
                    if (rawUrl != '' && rawUrl != 'undefined') {
                        window.location.href = rawUrl;
                    }
                    else {
                        window.location.href = '/default.aspx';
                    }
                }

            },
            initBack: function() {
                $("#back_btn_a").click(function() {
                    if ($("#mark").val() == "1") {
                        $("#step1").show(); $("#step2").hide(); $("#mark").val("0");
                    }
                    else {
                        $("#back_btn_a").attr("href", "javascript:window.history.go(-1);");
                    }
                })
            }
        }
        $(function() {
            userLoginReg.initBack();
            $("#btn_step1").click(function() { userLoginReg.getYanZhengMa(this) });
            $("#btn_step2").click(function() { userLoginReg.zhuCe(this) });

        })
    </script>

</body>
</html>
