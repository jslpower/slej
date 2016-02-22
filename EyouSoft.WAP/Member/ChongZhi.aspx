<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChongZhi.aspx.cs" Inherits="EyouSoft.WAP.Member.ChongZhi" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>账户充值</title>
    <link href="/css/Style.css" rel="stylesheet" type="text/css" />
    <link href="/css/user.css" rel="stylesheet" type="text/css" />
    <link href="/css/zhifu.css" rel="stylesheet" type="text/css" />

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1">
    <uc1:WapHeader runat="server" ID="WapHeader1" HeadText="E额宝充值" />
    <style>
        .user_form li
        {
            padding-left: 10px;
        }
    </style>
    <div class="warp">
        <div class="user_form">
            <ul>
                <li>充值金额 (¥)
                    <input type="text" value="" style="border: #eee solid 1px; width: 150px;" placeholder="请填写金额"
                        name="txtjine" id="txtjine">
                </li>
            </ul>
        </div>
        <div class="user_form user_form2">
            <ul>
                <li class="font18">选择付款方式</li>
            </ul>
        </div>
        <div class="zhifu_type">
            <ul>
                <li id="epay" class="R_jiantou"><s class="zfb"></s>
                    <h3>
                        支付宝</h3>
                    <p>
                        支持有支付宝，网银的用户使用</p>
                </li>
                
                    <li id="wxpay" class="R_jiantou"><s class="weixin"></s>
                        <h3>
                            微信支付</h3>
                        <p>
                            使用微信支付，安全便捷</p>
                    </li>
               
                <li id="bill99pay" class="R_jiantou"><s class="kq"></s>
                    <h3>
                        快钱支付<span class="font14" style="color: #4d4d4d;">(储蓄卡/信用卡)</span></h3>
                    <p>
                        支持快钱钱包用户，快捷支付</p>
                </li>
            </ul>
        </div>
    </div>
    
     <!---微信支付显示层--->
<div id="weixinzhifu" class="user-mask" style="display:none;">

   <div class="zhifu-weixin">
       
        
       <div class="cent code_big"><img src="http://m.slej.cn/ErWeiMa.aspx?d=1&codeurl=http://<%=HttpContext.Current.Request.Url.Host%>"></div>
       
       <div class="cent font_gray">微信扫描二维码，进入会员中心即可微信支付</div>
       
          
   </div>
</div>
    </form>

    <script type="text/javascript">

        var pageOpt = {
            save: function(type) {
                var $jine = $("#txtjine").val();
                if ($jine == null || $jine == 'undefined' || $jine == "" || parseFloat($jine) <= 0 || isNaN(parseFloat($jine)))
                { alert("请核查充值金额"); return false; }
                $.ajax({
                    type: "post",
                    cache: false,
                    url: '/Member/ChongZhi.aspx?chongzhi=1',
                    dataType: "json",
                    data: $("#epay").closest("form").serialize(),
                    success: function(ret) {
                        if (ret.result != "0") {
                            if (type == "kq") {
                                if (confirm("确认快钱充值，金额[" + ret.result + "]")) {
                                    location.href = "/99bill/send.aspx?orderid=" + ret.obj + "&type=11&token=" + ret.msg
                                }
                            }
                            if (type == "wx") {
                                if (confirm("确认微信充值，金额[" + ret.result + "]")) {
                                    location.href = "/tenPay/czSend.aspx?orderid=" + ret.obj + "&classid=12&token=" + ret.msg + "&openid=<%=openid %>&pay=1";
                                }
                            }
                            if (type == "zfb") {
                                if (confirm("确认支付宝充值，金额[" + ret.result + "]")) {
                                    location.href = "/alipay/default.aspx?orderid=" + ret.obj + "&type=11&token=" + ret.msg
                                }
                            }
                        }
                        else {
                            alert(ret.msg);
                        }
                    },
                    error: function() {
                        alert("数据错误");
                    }
                })
            }
        }

        var inlogo = {
            iswx: false,
            isWinXinpd: function() {

                var ua = window.navigator.userAgent.toLowerCase();
                if (ua.match(/MicroMessenger/i) == 'micromessenger') {
                    inlogo.iswx = true;
                } else {
                    inlogo.iswx = false;
                }

            }
        }
        $(function() {
            inlogo.isWinXinpd();
            $("#epay").click(function() {
                pageOpt.save("zfb");
            })
            $("#wxpay").click(function() {
                if (inlogo.iswx) {
                    pageOpt.save("wx");
                }
                else {
                    $("#weixinzhifu").show();
                }

            })
            $("#weixinzhifu").click(function() { $("#weixinzhifu").hide() });
            $("#bill99pay").click(function() {
                pageOpt.save("kq");
            })
        })
    </script>

</body>
</html>
