<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EyouSoft.WAP.Flight.Default" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<%@ Register Src="/userControl/ScrollImg.ascx" TagName="ScrollImg" TagPrefix="uc2" %>
<!doctype html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title>
        <%=FenXiangBiaoTi %></title>

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

    <script src="/js/jquery_cm.js" type="text/javascript"></script>

    <script src="/js/foucs.js" type="text/javascript"></script>

    <link href="/css/flight.css" rel="stylesheet" type="text/css" />

    <script src="../cordova.js" type="text/javascript"></script>

    <script src="../js/enow.core.js" type="text/javascript"></script>
    <style type="text/css">
        .user_form li
        {
            padding-left: 80px;
        }
    </style>
</head>
<body>
    <form id="myform" name="myform" method="post">
    <uc1:WapHeader runat="server" ID="WapHeader1" HeadText="机票预订" />
    <div class="warp">
        <!--baner------------start-->
        <uc2:ScrollImg ID="ScrollImg1" runat="server" />
        <!--baner------------end-->
        <div class="flight_city mt10">
            <div class="flight_city_ico">
            </div>
            <div class="user_form">
                <ul>
                    <li class="R_jiantou"><span class="label_name">出发城市</span><input readonly="readonly"
                        class="serInput u-input " name="startcity" type="text" id="startcity" value="<%=EyouSoft.Common.Utils.GetFormValue("startcity")==""?"杭州-HGH":EyouSoft.Common.Utils.GetFormValue("startcity")%>"
                        placeholder="请选择出发城市" />
                    </li>
                    <li class="R_jiantou"><span class="label_name">到达城市</span>
                        <input readonly="readonly" class="u-input serInput" name="endcity" type="text" id="endcity"
                            value="<%= EyouSoft.Common.Utils.GetFormValue("endcity")==""?"广州-CAN":EyouSoft.Common.Utils.GetFormValue("endcity") %>"
                            placeholder="请选择到达城市" />
                    </li>
                </ul>
            </div>
        </div>
        <div class="flight_city mt10">
        <div class="user_form">
            <ul>
                <li class="R_jiantou"><span class="label_name">出发日期</span>
                    <input readonly="readonly" class="u-rili u-input" name="rili" type="text" id="rili"
                        value="<%= EyouSoft.Common.Utils.GetFormValue("rili")==""?DateTime.Now.AddDays(3).ToString("yyyy-MM-dd"):EyouSoft.Common.Utils.GetFormValue("rili")%>"
                        placeholder="请选择出发日期" />
                </li>
            </ul>
        </div>
        </div>
        <div class="padd cent">
            <input name="" type="button" class="y_btn" value="马 上 查 询" /></div>
        <div class="cent">
            <a href="XUZHI.ASPX" class="zd_btn">一分钟全知道</a></div>
        <div class="cent paddT">
            电脑版订机票，更流畅超快捷 <a href="http://www.slej.cn/JiPiao.aspx" class=" bg_blue">现在进入</a></div>
        <div class="padd flight_txt">
            <ul>
                <li>
                    <p>
                        <em>1</em><span class="font18 font_yellow">返点高</span></p>
                    <p class="shm">
                        返点比例达3-20%！头等舱甚至高达40%！</p>
                </li>
                <li>
                    <p>
                        <em>2</em><span class="font18 font_yellow">出票快</span></p>
                    <p class="shm">
                        5-10分钟完成预订、支付和出票整个过程！</p>
                </li>
                <li>
                    <p>
                        <em>3</em><span class="font18 font_yellow">支付安全</span></p>
                    <p class="shm">
                        系统网银或者信用卡支付，100%安全保证！</p>
                </li>
            </ul>
        </div>
    </div>
    <!---联系客服--->
    <div class="user-mask" style="display: none;">
        <div class="h-mask-cnt">
            <div class="day_xuanze">
                <div class="day_T">
                    联系客服</div>
                <ul class="hotel_mx_box" style="padding: 0;">
                    <li class="gray_line paddL"><span class="font_yellow">外联：代理号</span> 0571-57682362<span
                        class="font_yellow paddL">手机：</span>13569752891 <span class="font_yellow">微信：</span>863846384
                        <a href="http://wpa.qq.com/msgrd?v=3&amp;uin=2568751115&amp;site=qq&amp;menu=yes"
                            rel="nofollow" target="_blank">
                            <img border="0" title="点击这里给我发消息" src="http://wpa.qq.com/pa?p=2:2568751115:51" style="vertical-align: middle;"></a></li>
                    <li class="gray_line paddL"><span class="font_yellow">外联：王经理</span> 0571-56892233<span
                        class="font_yellow paddL">手机：</span>13566668888 <span class="font_yellow">微信：</span>13566668899
                        <a href="http://wpa.qq.com/msgrd?v=3&amp;uin=2568751115&amp;site=qq&amp;menu=yes"
                            rel="nofollow" target="_blank">
                            <img border="0" title="点击这里给我发消息" src="http://wpa.qq.com/pa?p=2:2568751115:51" style="vertical-align: middle;"></a></li>
                </ul>
            </div>
        </div>
    </div>
    </form>

    <script type="text/javascript">

        $(function() {
            $("#link_a").click(function() {
                if ($(this).attr("class") == "on") {
                    $(this).removeClass("on");
                    $(".user-mask").hide();
                } else {
                    $(this).addClass("on");
                    $(".user-mask").show();
                }
            })
            $(".flight_city_ico").click(function() {
                var temp = "";
                temp = $("#startcity").val();
                $("#startcity").val($("#endcity").val());
                $("#endcity").val(temp);
            })
            $("#startcity").click(function() {
                document.getElementById("myform").action = "/CommonPage/SelectCity.aspx?type=0";
                document.getElementById("myform").submit();
            })
            $("#endcity").click(function() {
                document.getElementById("myform").action = "/CommonPage/SelectCity.aspx?type=1";
                document.getElementById("myform").submit();
            })
            $("#rili").click(function() {
                document.getElementById("myform").action = "/CommonPage/SelectDate.aspx";
                document.getElementById("myform").submit();
            })
            $(".day_T").click(function() { $(".user-mask").hide(); $("#link_a").removeClass("on"); })
            $(".y_btn").click(function() {
                var s = $("#startcity").val();
                var e = $("#endcity").val();
                var t = $("#rili").val();
                var msg = "";
                if (s == "" || s == "undefined") {
                    msg = "请选择出发城市\n";
                }
                if (e == "" || e == "undefined") {
                    msg += "请选择到达城市\n";
                }
                if (t == "" || t == "undefined") {
                    msg += "请选择出发日期";
                }
                if (msg != "") {
                    alert(msg);
                    return false;
                }
                window.location.href = "/Flight/Flight_List.aspx?q=HuoQuHangBans&" + $.param({ s: s, e: e, t: t });
            })
        })
    </script>

    

</body>
</html>
