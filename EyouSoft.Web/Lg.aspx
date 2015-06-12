<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Front2.Master" AutoEventWireup="true"
    CodeBehind="Lg.aspx.cs" Inherits="EyouSoft.Web.Lg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="/JS/slogin.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="mainbox">
        <div class="u_login">
            <table width="60%" border="0" align="center">
                <tr>
                    <td valign="top">
                        <div class="user_side">
                            <div class="title">
                                用户注册</div>
                            <div class="userbox">
                                <h5>
                                    还不是会员，一分钟免费注册</h5>
                                <ul>
                                    <li><span class="user-txt">真实姓名：</span><input type="text" id="txt_zhuce_xingming"
                                        class="inputbk formsize140"></li>
                                    <li><span class="user-txt">手机号码：</span><input type="text" id="txt_zhuce_shouji" class="inputbk formsize140"
                                        valid="required|isMobile"></li>
                                    <li><span class="user-txt">验证码：</span><input type="text" class="inputbk formsize60"
                                        id="txt_zhuce_yanzhengma">
                                        <a class="font_yellow" href="javascript:void(0)" id="i_a_huoquyanzhengma">获取验证码</a></li>
                                    <li class="padd">
                                        <input type="button" class="user-btn" value="马上注册" id="btn_zhuce"></li>
                                    <li class="notice">注意事项：<br />
                                        手机号码必须填写准确，此号码为平台核实注册信息并发放注册帐号之用！</li>
                                </ul>
                            </div>
                            <div class="bot">
                            </div>
                        </div>
                    </td>
                    <td valign="top">
                        <div class="user_side margin_T10">
                            <div class="title">
                                用户登录</div>
                            <div class="userbox" style="padding-bottom: 41px; *padding-bottom: 36px;">
                                <h5>
                                    已经是会员/贵宾/代理，马上登录</h5>
                                    
                                    <ul>
                     <li class="font_yellow" style="padding-right:10px;">
                         <label><input name="dlfs" type="radio" value="2" checked="checked" />　验证码登录</label>
                         <label class="floatR"><input name="dlfs" type="radio" value="1" />　密码登录</label>
                         <input id="dlfs" type="hidden" value="2" />
                     </li>
                 </ul>
                                <ul style="display: block;" id="shouji">
                <li><span class="user-txt">手机号码：</span><input id="txt_denglu_shouji" type="text" class="inputbk formsize140" /></li>
                <li><span class="user-txt">验证码：</span><input id="txt_denglu_yzm" type="text" class="inputbk formsize60" />
                    <a class="font_yellow" href="javascript:void(0)" id="l_huoquyzm">获取验证码</a></li>
            </ul>
            <ul id="zhanghao" style="display: none;">
                <li><span class="user-txt">账户：</span><input id="u" type="text" value="请输入手机号" onfocus="javascript:if(this.value=='请输入手机号')this.value='';"
                    onblur="javascript:if(this.value=='')this.value='请输入手机号';" class="inputbk formsize140"></li>
                <li><span class="user-txt">密码：</span><input id="p" type="password" value="请输入密码"
                    onfocus="javascript:if(this.value=='请输入密码')this.value='';" onblur="javascript:if(this.value=='')this.value='请输入密码';"
                    class="inputbk formsize140"></li>
                <li class="padd"><a class="font_yellow" href="/GetMiMa.aspx">忘记密码，请点这里取回！</a></li>
            </ul>
            <ul>
                <li class="padd">
                    <input type="button" id="btnLogin" class="user-btn" value="马上登录"></li>
            </ul>
                                
                            </div>
                            <div class="bot">
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>

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
                    { window.location.href = s; }
                    else { window.location.reload(); }
                }
                , function(m) {//login error callbackfffffff
                    tableToolbar._showMsg(m);
                    $("#btnLogin").click(function() { login(); return false; }).css("cursor", "pointer").val("马上登录");
                });
        }

        $(document).ready(function() {
            $("#btnLogin").click(function() { login(); });
            $("#a_LoginOut").click(function() {
                if (!confirm("确定退出当前登录！")) return false;

                $.ajax({ type: "post", cache: false, url: "/LogOut.aspx?r=1", dataType: "json",
                    success: function(ret) {
                        if (ret.result == "1") window.location.reload();
                        else window.location.reload();
                    },
                    error: function() {
                        window.location.reload();
                    }
                });

                return false;
            });
            $("#l_huoquyzm").click(function() { userLoginReg.getDLYanZhengMa(this) });
            $("#i_a_huoquyanzhengma").click(function() { userLoginReg.getYanZhengMa(this) });
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
            getDLYanZhengMa: function(obj) {
                $(obj).unbind("click");
                var _data = { shouJi: $.trim($("#txt_denglu_shouji").val()) };
                var _getYanZhengMaResult = iLogin.getDengLuYanZhengMa(_data);

                if (!_getYanZhengMaResult.success) { $(obj).click(function() { userLoginReg.getDLYanZhengMa(obj); }); return; }

                $(obj).css({ color: "#dadada" }).text("验证码已发送");
                setTimeout(function() { $(obj).css({ color: "#fe6600" }).text("获取验证码").click(function() { userLoginReg.getDLYanZhengMa(obj); }); }, 30000);
            },
            zhuCe: function(obj) {
                $(obj).unbind("click");
                var _data = { shouJi: $.trim($("#txt_zhuce_shouji").val()), xingMing: $.trim($("#txt_zhuce_xingming").val()), yanZhengMa: $.trim($("#txt_zhuce_yanzhengma").val()) };
                var _zhuCeResult = iLogin.zhuCe(_data);

                if (!_zhuCeResult.success) { $(obj).click(function() { userLoginReg.zhuCe(obj); }); return; }

                window.location.href = "/registSuccess.aspx";
                return false;
            }
        }
</script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Adv" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Foot" runat="server">
</asp:Content>
