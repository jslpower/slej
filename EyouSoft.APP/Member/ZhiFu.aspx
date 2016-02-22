<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZhiFu.aspx.cs" Inherits="EyouSoft.WAP.Member.ZhiFu" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title></title>
    <link rel="stylesheet" href="/css/zhifu.css" type="text/css" media="screen">

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        function nTabs(tabObj, obj) {
            var tabList = document.getElementById(tabObj).getElementsByTagName("li");
            for (i = 0; i < tabList.length; i++) {
                if (tabList[i].id == obj.id) {
                    document.getElementById(tabObj + "_Title" + i).className = "active";
                    document.getElementById(tabObj + "_Content" + i).style.display = "block";
                } else {
                    document.getElementById(tabObj + "_Title" + i).className = "normal";
                    document.getElementById(tabObj + "_Content" + i).style.display = "none";
                }
            }
        }
    </script>

</head>
<body>
    <form id="form1">
    <uc1:WapHeader runat="server" ID="WapHeader1" />
    <div class="warp">
        <div class="user_dindan font16 mt10">
            <ul>
                <li class="purl" data-pid="<%= pid%>">
                    <asp:Label ID="lblchanpinmingcheng" runat="server" Text=""></asp:Label></li>
                <li>商品总价：¥ <i class="font22 font_yellow">
                    <asp:Literal ID="TradeMoney" runat="server"></asp:Literal></i></li>
            </ul>
        </div>
        <div class="paddL paddT">
            选择支付方式</div>
        <div class="jq_tab zhifu_tab mt10" id="n4Tab">
            <div class="jq_TabTitle">
                <ul class="clearfix">
                    <li id="n4Tab_Title0" onclick="nTabs('n4Tab',this);" class="active"><a href="javascript:void(0);">
                        E额宝支付</a></li>
                    <li id="n4Tab_Title1" onclick="nTabs('n4Tab',this);" class="normal"><a href="javascript:void(0);">
                        其他支付</a></li>
                    <li id="n4Tab_Title2" onclick="nTabs('n4Tab',this);" class="normal" style="width: 34%;">
                        <a href="javascript:void(0);">转账汇款</a></li>
                </ul>
            </div>
            <div class="jq_TabContent">
                <div id="n4Tab_Content0">
                    <div class="user_form">
                        <ul>
                            <li><span class="label_name">E额宝余额</span> <span class="font18 font_yellow" style="width: 103px;
                                display: inline-block;">
                                <asp:Literal ID="MyMoney" runat="server"></asp:Literal></span><a href="/Member/ChongZhi.aspx"
                                    class="yzm">立即充值</a> </li>
                            <li><span class="label_name">E额宝密码</span>
                                <input name="zhifuPwd" type="password" class="u-input" id="zhifuPwd" style="width: 103px;" /><a
                                    href="/Member/ZhiFuMiMa.aspx" class="yzm">修改密码</a> </li>
                            <li><span class="label_name">动态验证码 </span>
                                <input name="viacode" type="text" class="u-input" id="viacode" style="width: 103px;" /><a
                                    class="yzm" href="javascript:void(0)" id="i_a_huoquyuezhifuyanzhengma">获取验证码</a>
                            </li>
                        </ul>
                    </div>
                    <div class="padd cent">
                        <input name="" type="button" class="y_btn" value="付款" id="epay" /></div>
                    <div class="paddL font16">
                        <a href="/EBao.aspx">
                            <div class="paddL font16">
                                <span class="g_btn" style="width: 120px;">什么是E额宝>></span></div>
                        </a>
                    </div>
                    <div class="paddL paddR20 paddT indent">
                        E 额宝是商旅E家为用户开发的可以在本系统中用于充值、支付、收佣、提现、统计和累计的财务工具。E 额宝余额每天按照一定比例进行积分增值，凭积分情况换取积分卡后可兑换旅游现金券。</div>
                </div>
                <div id="n4Tab_Content1" class="none">
                    <div class="zhifu_type">
                        <ul>
                            
                                <li id="getBrandWCPayRequest"><s class="weixin"></s>
                                    <h3>
                                        微信支付</h3>
                                    <p>
                                        使用微信支付，安全便捷</p>
                                </li>
                         
                            <li id="alipay"><s class="zfb"></s>
                                <h3>
                                    支付宝</h3>
                                <p>
                                    支持有支付宝，网银的用户使用</p>
                            </li>
                            <li id="99bill"><s class="kq"></s>
                                <h3>
                                    快钱支付<span class="font14" style="color: #4d4d4d;">(储蓄卡/信用卡)</span></h3>
                                <p>
                                    支持快钱钱包用户，快捷支付</p>
                            </li>
                            <li id="fenqi">
                                <s style=" background:none; text-decoration:none;" class="icon-fenqifukuan"></s>
                                <h3>分期付款</h3>
                            </li>
                        </ul>
                    </div>
                </div>
                <div id="n4Tab_Content2" class="none">
                    <div class="mt10 user_T font16">
                        对公账户</div>
                    <div class="user_dindan">
                        <ul>
                            <li style="border: none 0;">
                                <p>
                                    开户行：浙江泰隆商业银行 杭州分行
                                </p>
                                <p>
                                    户 名：杭州金奥国际旅行社有限公司</p>
                                <p>
                                    账 号：33020 10120 1000 25496</p>
                            </li>
                            <li style="border: none 0;">
                                <p>
                                    开户行：杭州银行 建国路支行</p>
                                <p>
                                    户 名：杭州金奥国际旅行社有限公司</p>
                                <p>
                                    账 号：7610 8100 176 136</p>
                            </li>
                            <li style="border: none 0;">
                                <p>
                                    开户行：支付宝</p>
                                <p>
                                    户 名：杭州金奥国际旅行社有限公司</p>
                                <p>
                                    账 号：hzjaly888@163.com6</p>
                            </li>
                            <li style="border: none 0;">
                                <p>
                                    开户行：杭州银行 学院路支行</p>
                                <p>
                                    户 名：杭州金奥国际旅行社有限公司</p>
                                <p>
                                    账 号：7421 8100 351 087</p>
                            </li>
                        </ul>
                    </div>
                    <div class="mt10 user_T font16">
                        个人账户</div>
                    <div class="user_dindan">
                        <ul>
                            <li style="border: none 0;">
                                <p>
                                    开户行：工商银行 杭州城西支行</p>
                                <p>
                                    户 名：刘 钊 （法人代表）</p>
                                <p>
                                    账 号：6222 0812 0200 7765413</p>
                            </li>
                            <li style="border: none 0;">
                                <p>
                                    开户行：农业银行 杭州艮山支行</p>
                                <p>
                                    户 名：刘 钊 （法人代表）</p>
                                <p>
                                    账 号：62284 8032 13342 12214</p>
                            </li>
                            <li style="border: none 0;">
                                <p>
                                    开户行：建设银行 浙江杭州华星支行</p>
                                <p>
                                    户 名：刘 钊 （法人代表）</p>
                                <p>
                                    账 号：6236 6815 4000 0789 276</p>
                            </li>
                            <li style="border: none 0;">
                                <p>
                                    开户行：支付宝</p>
                                <p>
                                    户 名：刘 钊 （法人代表）</p>
                                <p>
                                    账 号：139 571 40211</p>
                                <p>
                                    绑定邮箱：289063740@qq.com</p>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!---分期付款点击显示层--->
<div id="fenqifukuanbox" class="user-mask" style="display:none;">
   
       <div class="fenqifukuan_box" >
                <img src="/images/fenqifukuan.jpg">
       </div>
   
</div><!---微信支付显示层--->
<div id="weixinzhifu" class="user-mask" style="display:none;">

   <div class="zhifu-weixin">
       
        
       <div class="cent code_big"><img src="http://m.slej.cn/ErWeiMa.aspx?d=1&codeurl=http://<%=HttpContext.Current.Request.Url.Host.Replace("p.","m.")%>"></div>
       
       <div class="cent font_gray">微信扫描二维码，进入会员中心即可微信支付</div>
       
          
   </div>
</div>
    </form>

    <script type="text/javascript">
        $(".purl").click(function() {
            var otype = "<%= DDLX%>";
            var Pid = $(this).attr("data-pid");
            if (otype == "8") {
                window.location.href = "/Car.aspx?id=" + Pid;
            }
            else if (otype == "3") {
                window.location.href = "/Mall/MoDetail.aspx?ID=" + Pid;
            }
            else if (otype == "4") {
                window.location.href = "/JingQuXX.aspx?ScenicId=" + Pid;
            }
            else if (otype == "5") {
                window.location.href = "/HotelXX.aspx?HotelId=" + Pid;
            }
            else if (otype == "7") {
                window.location.href = "/TuanGouXX.aspx?id=" + Pid;
            }
            else if (otype == "9") {
                window.location.href = "/ZiZuTuan.aspx?id=" + Pid;
            }
            else if (otype == "0" || otype == "1" || otype == "2") {//线路
                window.location.href = "/Line_Info.aspx?id=" + Pid;
            }
        });
    </script>

    <script type="text/javascript">
        var PageInfo = {
            urlLocation: '<%= EyouSoft.Common.Utils.GetQueryStringValue("Classid")%>',
            yeparam: { Pay: '<%= EyouSoft.Common.Utils.GetQueryStringValue("Pay")%>', Classid: '<%= EyouSoft.Common.Utils.GetQueryStringValue("Classid")%>', id: '<%= EyouSoft.Common.Utils.GetQueryStringValue("id")%>', token: '<%= EyouSoft.Common.Utils.GetQueryStringValue("token")%>' },
            wypara: { orderid: '<%= EyouSoft.Common.Utils.GetQueryStringValue("id")%>', type: '<%= DDLX%>', token: '<%= EyouSoft.Common.Utils.GetQueryStringValue("token")%>' },
            Sava: function() {
                if ($("#zhifuPwd").val() == '' || $("#zhifuPwd").val() == 'undefined') { alert("E额宝密码不可为空"); return false; }
                if ($("#viacode").val() == '' || $("#viacode").val() == 'undefined') { alert("动态验证码不可为空"); return false; }

                var sy = parseFloat('<%=ShengYuJinE %>');
                var dd = parseFloat('<%=ZhiFuJinE %>');
                if (dd < sy) {
                    var url = '/Member/ZhiFu.aspx?zhifu=1&' + $.param(PageInfo.yeparam);
                    PageInfo.GoAjax(url);
                }
                else {
                    alert("余额不足，你可以选择使用网银支付！");

                }

            },
            //获取余额支付验证码
            getYuEZhiFuYanZhengMa: function(obj) {
                $(obj).unbind("click");
                var _data = { txtZhiFuJinE: "<%=ZhiFuJinE %>" };
                var _v = false;
                $.ajax({ type: "POST", url: "/ashx/handler.ashx?dotype=getyuezhifuyanzhengma", cache: false, async: false, dataType: "json", data: _data,
                    success: function(response) {
                        if (response.result == 1) {
                            _v = true;
                        } else {
                            alert(response.msg);
                        }
                    }
                });

                if (!_v) {
                    $(obj).click(function() { PageInfo.getYuEZhiFuYanZhengMa(obj); }); return;
                }

                $(obj).css({ color: "#dadada" }).text("验证码已发送");
                setTimeout(function() { $(obj).css({ color: "#fe6600" }).text("获取验证码").click(function() { PageInfo.getYuEZhiFuYanZhengMa(obj); }); }, 30000);
            },
            GoAjax: function(url) {
                $.ajax({
                    type: "post",
                    cache: false,
                    url: url,
                    dataType: "json",
                    data: $("#form1").serialize(),
                    success: function(ret) {
                        alert(ret.msg)
                        if (ret.result == "1") {
                            if (PageInfo.urlLocation == "1") { location.href = "/Member/XianLuOrderList.aspx?type=1"; return false; }
                            else if (PageInfo.urlLocation == "2") { location.href = "/Member/DingDanList.aspx?OrderType=5"; return false; }
                            else if (PageInfo.urlLocation == "3") { location.href = "/Member/DingDanList.aspx?OrderType=4"; return false; }
                            else if (PageInfo.urlLocation == "4") { location.href = "/Member/DingDanList.aspx?OrderType=8"; return false; }
                            else if (PageInfo.urlLocation == "5") { location.href = "/Member/DingDanList.aspx?OrderType=3"; return false; }
                            else if (PageInfo.urlLocation == "6") { location.href = "/Member/DingDanList.aspx?OrderType=7"; return false; }
                            //else if (PageInfo.urlLocation == "7") { location.href = "/Member/VisaOrderList.aspx"; return false; }
                            else if (PageInfo.urlLocation == "8") { location.href = "/Member/XianLuOrderList.aspx?type=2"; return false; }
                            else if (PageInfo.urlLocation == "9") { location.href = "/Member/XianLuOrderList.aspx?type=3"; return false; }
                            else if (PageInfo.urlLocation == "11") { location.href = "/Member/JpOrderList.aspx"; return false; }
                            else { location.href = "/Member/ChangXianOrder.aspx"; return false; }
                        }

                    },
                    error: function() {
                        alert("数据丢失")
                    }
                });
            }



        };
        $(function() {
            //            $("#epay").click(function() {
            //                var sy = parseFloat('<%=ShengYuJinE %>');
            //                var dd = parseFloat('<%=ZhiFuJinE %>');
            //                if ($("#zhifuPwd").val() == '' || $("#zhifuPwd").val() == 'undefined') { alert("E额宝密码不可为空"); return false; }
            //                if ($("#viacode").val() == '' || $("#viacode").val() == 'undefined') { alert("动态验证码不可为空"); return false; }
            //                if (dd <= sy) {
            //                    alert(1);
            //                    var url = '/Member/ZhiFu.aspx?zhifu=1&' + $.param(PageInfo.yeparam);
            //                    PageInfo.GoAjax(url);
            //                }
            //                else {
            //                    $("#noMeney").html("余额不足，你可以选择使用网银支付！");

            //                }


            //            })
            $("#alipay").click(function() {
                if (window.confirm("确认使用支付宝")) {
                    location.href = "/alipay/default.aspx?" + $.param(PageInfo.wypara);
                }
            })

            $("#99bill").click(function() {
                if (window.confirm("确认使用快钱")) {
                    location.href = "/99bill/send.aspx?" + $.param(PageInfo.wypara);
                }
            })

            $("#ChongZhi").click(function() { location.href = "/Member/MyChongzhi.aspx?tp=1"; });
            $("#Chongzhi1").click(function() { location.href = "/Member/MyChongzhi.aspx?tp=1"; });
            $("#i_a_huoquyuezhifuyanzhengma").click(function() { PageInfo.getYuEZhiFuYanZhengMa(this) });
            $("#epay").bind("click", function() { PageInfo.Sava(); });

            $("#fenqi").click(function() { $("#fenqifukuanbox").show() });
            $("#fenqifukuanbox").click(function() { $("#fenqifukuanbox").hide() });
        });
    </script>

    <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>

    <script type="text/javascript">
     var wx_jsapi_config=<%=weixin_jsapi_config %>;
    wx.config(wx_jsapi_config);
    </script>

    <script language="javascript" type="text/javascript">

        $(function() {

            $('#getBrandWCPayRequest').click(function() {
                $("#weixinzhifu").show();
                //                wx.chooseWXPay({
                //                    timestamp: '<%= _TenPayTradeModel.TimeStamp %>', // 支付签名时间戳，注意微信jssdk中的所有使用timestamp字段均为小写。但最新版的支付后台生成签名使用的timeStamp字段名需大写其中的S字符
                //                    nonceStr: '<%= _TenPayTradeModel.NonceStr %>', // 支付签名随机串，不长于 32 位
                //                    package: 'prepay_id=<%= _TenPayTradeModel.PrepayId %>', // 统一支付接口返回的prepay_id参数值，提交格式如：prepay_id=***）
                //                    signType: 'MD5', // 签名方式，默认为'SHA1'，使用新版支付需传入'MD5'
                //                    paySign: '<%= _TenPayTradeModel.Sign %>', // 支付签名
                //                    success: function(res) {
                //                        // 支付成功后的回调函数
                //                    }
                //                });
            });
            $("#weixinzhifu").click(function() { $("#weixinzhifu").hide() });
        })
    </script>

</body>
</html>
