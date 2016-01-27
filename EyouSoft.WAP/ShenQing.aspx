<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShenQing.aspx.cs" Inherits="EyouSoft.WAP.ShenQing" %>

<%@ Register Src="userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>免费代理商申请</title>

    <script src="/js/jquery_cm.js" type="text/javascript"></script>

    <script src="/js/slogin.js" type="text/javascript"></script>

</head>
<body>
    <uc1:WapHeader ID="WapHeader1" runat="server" HeadText="免费代理商申请" />
    <style>
        .user_form li
        {
            padding-left: 60px;
        }
    </style>
    <div class="warp">
        <div class="user_form">
            <ul>
                <li><span class="label_name">姓 名</span>
                    <input type="text" id="txt_zhuce_xingming" class="u-input" placeholder="请输入您的真实姓名">
                </li>
                <li><span class="label_name">手机号</span>
                    <input type="text" id="txt_zhuce_shouji" class="u-input" placeholder="请输入您的手机号">
                </li>
                <li><span class="label_name">身份证</span>
                    <input type="text" id="txt_zhuce_sfz" class="u-input" placeholder="请输入您的身份证号">
                </li>
                <li><span class="label_name">验证码</span>
                    <input type="tel" class="u-input" style="width: 140px;" placeholder="请输入短信验证码" id="txt_zhuce_yanzhengma">
                    <a class="yzm" href="javascript:void(0)" id="i_a_huoquyanzhengma">获取验证码</a> <a class="code_btn"
                        style="display: none;">50秒后重新发送</a> </li>
                <li class="font14" style="padding-left: 30px; position: relative;"><a data-div="checkbox"
                    href="javascript:void(0)" class="a_input" style="left: 10px; top: 13px;"></a>我已阅读并同意<span
                        class="font_blue">《服务条款》</span><!-------勾选后的样式是a_input_on------------->
                </li>
            </ul>
        </div>
        <div class="padd cent">
            <input type="button" id="btn_zhuce" class="y_btn" value="申　请"></div>
    </div>
    <!---------条款---------->
    <div id="TiaoKuanMask" class="user-mask" style="display: none;">
        <div class="user-mask-cnt" style="width: 80%; margin-top: 50px;">
            <asp:Literal ID="tiaokuan" runat="server"></asp:Literal>
        </div>
    </div>
    <div id="TiJiaoMask" class="user-mask" style="display: none;">
        <div class="h-mask-cnt" style="margin-top: 200px;">
            <div class="cent font_yellow font16" style="padding-top: 20px;">
                正在提交申请，请等待。。。
            </div>
        </div>
    </div>
    <div id="LoginMask" class="user-mask" style="display: none;">
        <div class="user-mask-cnt box" style="width: 88%; position: absolute; left: 50%;
            top: 50%; margin: -57px 0 0 -44%;">
            <p class="cent font16">
                已存在的手机号码，请直接登录</p>
            <p class="paddT">
                <a href="/Login.aspx" class="y_btn">立即前往登录</a></p>
        </div>
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
</body>

<script type="text/javascript">

    $(document).ready(function() {
        $("#i_a_huoquyanzhengma").click(function() { userLoginReg.getYanZhengMa(this) });
        $("#btn_zhuce").click(function() { userLoginReg.zhuCe(this) });
        $(".font_blue").click(function() {
            $("#TiaoKuanMask").css("display", "block");
        })
        $("#TiaoKuanMask").click(function() {
            $("#TiaoKuanMask").css("display", "none");
        })
        $("a[data-div=checkbox]").click(function() {
            var classname = $(this).attr("class");
            if (classname == "a_input") {
                $(this).removeClass("a_input").addClass("a_input_on");
            }
            else {
                $(this).removeClass("a_input_on").addClass("a_input");
            }
        });
    });

    var userLoginReg = {
        getYanZhengMa: function(obj) {
            $(obj).unbind("click");
            var _data = { shouJi: $.trim($("#txt_zhuce_shouji").val()) };
            var _getYanZhengMaResult = iLogin.getZhuCeYanZhengMa(_data);

            if (!_getYanZhengMaResult.success) { $(obj).click(function() { userLoginReg.getYanZhengMa(obj); }); return; }

            $(obj).removeClass("yzm").addClass("code_btn").text("验证码已发送");
            //$(obj).css({ color: "#dadada" }).text("验证码已发送");
            setTimeout(function() { $(obj).removeClass("code_btn").addClass("yzm").text("获取验证码").click(function() { userLoginReg.getYanZhengMa(obj); }); }, 30000);
        },
        zhuCe: function(obj) {
            if ($("#txt_zhuce_xingming").val() == "") {
                alert("姓名不能为空！");
                $("#txt_zhuce_xingming").focus();
                return false;
            }
            else {
                if (!/^[\u4e00-\u9fa5a-zA-Z_]+$/.test($("#txt_zhuce_xingming").val())) {
                    alert('请填写您的正确姓名');
                    $("#txt_zhuce_xingming").focus();
                    return false;
                }
            }
            if($("#txt_zhuce_yanzhengma").val() =="")
            {
               alert("验证码不能为空！");
                $("#txt_zhuce_yanzhengma").focus();
                return false;
            }
            if ($("#txt_zhuce_shouji").val() == "") {
                alert("手机号码不能为空！");
                $("#txt_zhuce_shouji").focus();
                return false;
            }
            else {
                if (!/^(13|15|18|14)\d{9}$/.test($("#txt_zhuce_shouji").val())) {
                    alert('请填写正确的手机号码');
                    $("#txt_zhuce_shouji").focus();
                    return false;
                }
            }
            if ($("#txt_zhuce_sfz").val() != "") {                
                if (!/(^\d{15}$)|(^\d{17}[0-9Xx]$)/.test($("#txt_zhuce_sfz").val())) {
                    alert('请填写正确的身份证号');
                    $("#txt_zhuce_sfz").focus();
                    return false;
                }
            }
            if ($("a[data-div=checkbox]").attr("class") != "a_input_on") {
                alert("请确认您是否阅读了服务条款并且确认了！");
                return false;
            }
            $("#TiJiaoMask").css("display", "block");
            $(obj).unbind("click");
            var _data = { shouJi: $.trim($("#txt_zhuce_shouji").val()), xingMing: $.trim($("#txt_zhuce_xingming").val()), yanZhengMa: $.trim($("#txt_zhuce_yanzhengma").val()) };
            var _zhuCeResult = iLogin.zhuCeSq(_data);

            if (!_zhuCeResult.success) 
            { $("#TiJiaoMask").css("display", "none"); $("#LoginMask").css("display","block"); return false;}
            else
            {window.location.href = "/SetShop.aspx?cardid=" + $("#txt_zhuce_sfz").val();}
            
        }
    }
</script>

</html>
