<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HuiYuanReg.aspx.cs" Inherits="EyouSoft.WAP.HuiYuanReg" %>
<%@ Register Src="userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>非会员预定</title>


    <script src="/js/jquery_cm.js" type="text/javascript"></script>

    <script src="/js/slogin.js" type="text/javascript"></script>

    <script src="/js/table-toolbar.js" type="text/javascript"></script>
</head>

<body>

  <uc1:WapHeader ID="WapHeader1" runat="server" HeadText="非会员预定" />
  
  <div class="warp">
    <div class="user_form">
            <ul>
                <li><span class="label_name">手机号</span>
                    <input type="text" id="txt_zhuce_shouji" class="u-input" placeholder="请输入手机号">
                </li>
                <li><span class="label_name">姓&nbsp;&nbsp;&nbsp;名</span>
                    <input type="text" id="txt_name" class="u-input" placeholder="请输入姓名">
                </li>
                <li><span class="label_name">验证码</span>
                    <input type="tel" id="txt_zhuce_yzm" class="u-input" style="width: 80px;" placeholder="验证码">
                    <a id="l_huoquyzm" class="yzm">获取验证码</a> <a class="code_btn" style="display: none;">
                        50秒后重新发送</a> </li>
            </ul>
        </div>
     
     
     
     <div class="padd cent"><input type="button" class="y_btn" id="btn_zhuce" value="预定"></div>
   
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
    $(document).ready(function() {
        $("#l_huoquyzm").click(function() { userLoginReg.getYanZhengMa(this) });
        $("#btn_zhuce").click(function() { userLoginReg.zhuCe(this) });
    });

    var userLoginReg = {
        getYanZhengMa: function(obj) {
            $(obj).unbind("click");
            var _data = { shouJi: $.trim($("#txt_zhuce_shouji").val()) };
            var _getYanZhengMaResult = iLogin.getZhuCeYanZhengMa(_data);

            if (!_getYanZhengMaResult.success) { $(obj).click(function() { userLoginReg.getYanZhengMa(obj); }); return; }

            $(obj).css({ color: "#dadada" }).text("验证码已发送");
            setTimeout(function() { $(obj).css({ color: "#fe6600" }).text("获取验证码").click(function() { userLoginReg.getYanZhengMa(obj); }); }, 30000);
        },
        zhuCe: function(obj) {
        $(obj).unbind("click");
        $("#TiJiaoMask").toggle();
        var _data = { shouJi: $.trim($("#txt_zhuce_shouji").val()), xingMing: $.trim($("#txt_name").val()), yanZhengMa: $.trim($("#txt_zhuce_yzm").val()) };
            var _zhuCeResult = iLogin.zhuCe(_data);

            if (!_zhuCeResult.success) { $(obj).click(function() {  userLoginReg.zhuCe(obj); });$("#TiJiaoMask").toggle(); return; }

            var s = '<%=Request.QueryString["rurl"] %>';
            if (s.length > 0)
            { window.location.href = s; }
            else { window.location.href = "/Member/UserCenter.aspx"; }
            return false;
        }
    }
</script>
</html>