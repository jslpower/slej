<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserLoginOrReg.ascx.cs"
    Inherits="EyouSoft.Web.UserControl.UserLoginOrReg" %>
<!------用户注册-------->
<asp:PlaceHolder ID="plnUserReg" runat="server">
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
                    <%--<asp:Button ID="Button1" runat="server" Text="马上注册" CssClass="user-btn" OnClick="Button1_Click" />--%>
                    <input type="button" class="user-btn" value="马上注册" id="btn_zhuce"></li>
                <li class="notice">注意事项：<br>
                    手机号码必须填写准确，此号码为平台核实注册信息并发放注册帐号之用！</li>
            </ul>
        </div>
        <div class="bot">
        </div>
    </div>
</asp:PlaceHolder>
<!------用户登录-------->
<asp:PlaceHolder ID="plnUserLog" runat="server">
    <div class="user_side margin_T10">
        <a id="login"></a>
        <div class="title">
            用户登录</div>
        <div class="userbox">
            <h5>
                已经是会员/贵宾/代理，马上登陆</h5>
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
            <ul  id="zhanghao" style="display: none;">
                <li><span class="user-txt">账户：</span><input id="u" type="text" value="请输入手机号" onfocus="javascript:if(this.value=='请输入手机号')this.value='';"
                    onblur="javascript:if(this.value=='')this.value='请输入手机号';" class="inputbk formsize140"></li>
                <li><span class="user-txt">密码：</span><input id="p" type="password" value="请输入密码"
                    onfocus="javascript:if(this.value=='请输入密码')this.value='';" onblur="javascript:if(this.value=='')this.value='请输入密码';"
                    class="inputbk formsize140"></li>
                <li class="padd"><a class="font_yellow" href="/GetMiMa.aspx">忘记密码，请点这里取回！</a></li>
            </ul>
            <%--<ul>
                <li class="padd"><a href="javascript:;" id="qiehuan" class="font_yellow">使用手机方式登录</a></li>
            </ul>--%>
            <ul>
                <li class="padd">
                    <input type="button" id="btnLogin" class="user-btn" value="马上登录"></li>
            </ul>
        </div>
        <div class="bot">
        </div>
    </div>
</asp:PlaceHolder>
<asp:PlaceHolder ID="plnUserInfo" Visible="false" runat="server">
    <div class="user_side margin_T10">
        <div class="title">
            用户登录</div>
        <div class="left_menu">
            <h5>
                <em style="color: Red">
                    <asp:Label ID="lblShenFen" runat="server" Text=""></asp:Label></em>，<asp:Literal
                        ID="ltrUserName" runat="server"></asp:Literal>，欢迎登录/<a id="a_LoginOut" href="javascript:void(0);"
                            style="color: Red"> 退出</a>
            </h5>
            <ul id="navigation">
                <li><a class="inactive" href="javascript:;">我的资料</a>
                    <ul style="display: none;">
                        <li><a href="/Member/UpdateMember.aspx">修改资料</a></li>
                        <li><a href="/Member/UpdatePassWord.aspx">修改密码</a></li>
                    </ul>
                </li>
                <li><a class="inactive" href="javascript:;">我的订单</a>
                    <ul style="display: none;">
                        <% if (isfenxiao == 1)
                           { %>
                        <li><a href="/Member/DingDanList.aspx">订单列表</a></li>
                        <%} %>
                        <li><a href="/Member/DuanXianOrder.aspx">短线订单</a></li>
                        <li><a href="/Member/ChangXianOrder.aspx">长线订单</a></li>
                        <li><a href="/Member/ChuJingOrder.aspx">出境订单</a></li>
                        <li><a href="/Member/ZuTuanOrderList.aspx">报价订单</a></li>
                        <li><a href="/Member/HotelOrderList.aspx">酒店订单</a></li>
                        <li><a href="/Member/ScenicList.aspx">门票订单</a></li>
                        <li><a href="/Member/ZuCheOrderList.aspx">租车订单</a></li>
                        <li><a href="/Member/SCOrderList.aspx">商城订单</a></li>
                        <li><a href="/Member/TuanGouDingDan.aspx">团购订单</a></li>
                        <li><a href="/Member/VisaOrderList.aspx">签证订单</a></li>
                    </ul>
                </li>
                <li><a class="inactive" href="/Member/GongGao.aspx">会员公告</a> </li>
                <li><a class="inactive" href="javascript:;">Ｅ&nbsp;&nbsp;额&nbsp;&nbsp;宝</a>
                    <ul style="display: none;">
                        <li><a href="/Ebao.aspx">什么是E额宝？</a></li>
                        <li><a href="/Member/UserTransaction.aspx">E额宝余额管理</a></li>
                        <li><a href="/Member/ChongzhiList.aspx">E额宝充值明细</a></li>
                        <% if (isfenxiao == 1)
                           { %>
                        <li><a href="/Member/FanLiList.aspx">E额宝返利明细</a></li>
                        <%} %>
                        <li><a href="/Member/TiXianList.aspx">E额宝提现明细</a></li>
                        <li><a href="/member/ZengZhi.aspx">E额宝积分增值</a></li>
                        <li><a href="/Member/DuiHuanList.aspx">E额宝积分兑换</a></li>
                        <% if (isfenxiao == 1)
                           { %>
                        <li><a href="/member/FenSiJiangLi.aspx">我的下级分销奖</a></li>
                        <%} %>
                        <li style="display: none;"><a href="/member/fensi.aspx">粉丝信息</a></li>
                        <li style="display: none;"><a href="/member/fensijiaoyi.aspx">粉丝交易</a></li>
                        <li><a href="/Member/TransactionList.aspx?type=1">E 额宝综合明细</a></li>
                        <li><a href="/Member/TransactionList.aspx">系统交易总明细</a></li>
                    </ul>
                </li>
                <li><a class="inactive" href="javascript:void(0)">联盟推广</a>
                    <ul style="display: none">
                        <li><a href="/member/tuiguangdaima.aspx">推广链接</a></li>
                        <li><a href="/member/tuiguangfanli.aspx">联盟返利</a></li>
                        <% if (isfenxiao == 1)
                           { %>
                        <li><a href="/webmaster/login.aspx?type=s" target="_blank">网站设置</a></li>
                        <%} %>
                    </ul>
                </li>
            </ul>
        </div>
        <%--<div class="userbox">
            <h5>
                &nbsp;&nbsp;欢迎，<asp:Literal ID="ltrUserName" runat="server"></asp:Literal>&nbsp;登录</h5>
            <ul>
                <li style="float: left; padding-left: 5px;"><a href="/Member/XianLuOrderList.aspx">
                    <h5>
                        订单管理</h5>
                </a></li>
                <li style="float: left; padding-left: 5px;"><a href="/Member/UserTransaction.aspx">
                    <h5>
                        E额宝</h5>
                </a></li>
                <li style="float: left; padding-left: 5px; padding-right: 5px"><a href="/Member/TransactionList.aspx">
                    <h5>
                        交易记录</h5>
                </a></li>
                <li><a href="/Member/UpdateMember.aspx">
                    <h5>
                        会员资料</h5>
                </a></li>
                <li style="float: left; padding-left: 5px;"><a id="a_LoginOut" href="javascript:void(0);">
                    退出</a> </li>
            </ul>
        </div>--%>
        <%--<div class="bot">
        </div>--%>
    </div>
</asp:PlaceHolder>

<script type="text/javascript" src="/JS/slogin.js"></script>

<script src="/Js/menu_min.js"></script>

<script language="javascript" type="text/javascript">
    $(document).ready(function() {
        $(".left_menu ul li").menu();
    }); 
</script>

<style type="text/css">
    .doti
    {
        background-color: #c1def0;
        border: #c1def0 solid 1px;
        text-align: right;
        font-size: 12px;
    }
</style>

<script type="text/javascript">
    $(function() {
    $("input[name=dlfs]").click(function() {
            $("#dlfs").val($(this).val());
            var fangshi = $("#dlfs").val();
            if (fangshi == "2") {
                $("#shouji").show();
                $("#zhanghao").hide();
            }
            else{
                $("#shouji").hide();
                $("#zhanghao").show();
            }
        });
    });
    function login() {
    var u,p,ckcode;
       if($("#dlfs").val()=="1")
       {
          u = $.trim($("#u").val());
          p = $.trim($("#p").val());
          ckcode = "1";
        }
        else
        {
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

