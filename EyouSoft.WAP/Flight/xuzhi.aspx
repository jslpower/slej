<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xuzhi.aspx.cs" Inherits="EyouSoft.WAP.Flight.xuzhi" %>

<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <title></title>

    <link rel="stylesheet" type="text/css" href="/css/flight.css" media="screen" />

    <script src="/js/jq.mobi.min.js" type="text/javascript"></script>

</head>
<body>
    <uc1:WapHeader runat="server" ID="WapHeader1" />
    <div class="warp">
        <div class="zhidao_t mt10">
            <img src="/images/zd-img.png"></div>
        <div class="padd flight_txt" style="background: #fff;">
            <ul>
                <li>
                    <p>
                        <em>1</em><span class="font18 font_yellow">系统登录</span></p>
                    <p class="shm">
                        机票栏目自成体系，高返点（返3-20%）机票需通过手机号登录后方可预订。</p>
                </li>
                <li>
                    <p>
                        <em>2</em><span class="font18 font_yellow">查询预订</span></p>
                    <p class="shm">
                        登录后输入起止城市名称和出发日期查询所需航班及返点比例后预订提交。</p>
                </li>
                <li>
                    <p>
                        <em>3</em><span class="font18 font_yellow">费用支付</span></p>
                    <p class="shm">
                        通过网银或信用卡按返点后的折后折价格在半小时内完成费用支付。</p>
                </li>
                <li>
                    <p>
                        <em>4</em><span class="font18 font_yellow">票面价格</span></p>
                    <p class="shm">
                        纸质机票（行程单）的票面价为返点前的价格。返点部份即为您的劳务费。</p>
                </li>
                <li>
                    <p>
                        <em>5</em><span class="font18 font_yellow">出票进度</span></p>
                    <p class="shm">
                        在“我的订单管理”中可查看机票预订和出票进度。</p>
                </li>
                <li>
                    <p>
                        <em>6</em><span class="font18 font_yellow">登机办理</span></p>
                    <p class="shm">
                        凭身份证（婴童凭户口本）到办票柜台即可办理，无须纸质机票（行程单）。。</p>
                </li>
                <li>
                    <p>
                        <em>7</em><span class="font18 font_yellow">取票方法</span></p>
                    <p class="shm">
                        凭身份证到机场自行打印纸质机票，也可在一周内致电0571-85095701取票。</p>
                </li>
                <li>
                    <p>
                        <em>8</em><span class="font18 font_yellow">机票验真</span></p>
                    <p class="shm">
                        登录www.travelsky.com输入姓名或致电400-815-8888进行机票验真核实。</p>
                </li>
                <li>
                    <p>
                        <em>9</em><span class="font18 font_yellow">婴童机票</span></p>
                    <p class="shm">
                        在“创建婴童票”中输入同行成人机票编码和婴童姓名完成婴童机票操作。</p>
                </li>
                <li>
                    <p>
                        <em>10</em><span class="font18 font_yellow">改签退票</span></p>
                    <p class="shm">
                        点击“改签”、“升舱“或“退票”按钮了解相应费用政策后确订相应操作。。</p>
                </li>
                <li>
                    <p>
                        <em>11</em><span class="font18 font_yellow">航空保险</span></p>
                    <p class="shm">
                        可在 “采购管理“中购买航空意外电子保险，一般只需6-10元/人/程。</p>
                </li>
                <li>
                    <p>
                        <em>12</em><span class="font18 font_yellow">综合查询</span></p>
                    <p class="shm">
                        更多机票问题，请致电400-6588-180进行咨询。</p>
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
</body>
</html>
