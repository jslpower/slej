<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TuanGou.ascx.cs" Inherits="EyouSoft.Web.UserControl.TuanGou" %>


    <script src="JS/left_focus.js" type="text/javascript"></script>
<script type="text/javascript">
    //var intDiff = parseInt(5);//倒计时总秒数量
    function timer(intDiff1, intDiff2, intDiff3, intDiff4, intDiff5) {
        window.setInterval(function() {
            var day1 = 0,
        hour1 = 0,
        minute1 = 0,
        second1 = 0; //时间默认值
            var day2 = 0,
        hour2 = 0,
        minute2 = 0,
        second2 = 0; //时间默认值
            var day3 = 0,
        hour3 = 0,
        minute3 = 0,
        second3 = 0; //时间默认值
            var day4 = 0,
        hour4 = 0,
        minute4 = 0,
        second4 = 0; //时间默认值
            var day5 = 0,
        hour5 = 0,
        minute5 = 0,
        second5 = 0; //时间默认值      
            if (intDiff1 > 0) {
                day1 = Math.floor(intDiff1 / (60 * 60 * 24));
                hour1 = Math.floor(intDiff1 / (60 * 60)) - (day1 * 24);
                minute1 = Math.floor(intDiff1 / 60) - (day1 * 24 * 60) - (hour1 * 60);
                second1 = Math.floor(intDiff1) - (day1 * 24 * 60 * 60) - (hour1 * 60 * 60) - (minute1 * 60);
            }
            if (intDiff2 > 0) {
                day2 = Math.floor(intDiff2 / (60 * 60 * 24));
                hour2 = Math.floor(intDiff2 / (60 * 60)) - (day2 * 24);
                minute2 = Math.floor(intDiff2 / 60) - (day2 * 24 * 60) - (hour2 * 60);
                second2 = Math.floor(intDiff2) - (day2 * 24 * 60 * 60) - (hour2 * 60 * 60) - (minute2 * 60);
            }
            if (intDiff3 > 0) {
                day3 = Math.floor(intDiff3 / (60 * 60 * 24));
                hour3 = Math.floor(intDiff3 / (60 * 60)) - (day3 * 24);
                minute3 = Math.floor(intDiff3 / 60) - (day3 * 24 * 60) - (hour3 * 60);
                second3 = Math.floor(intDiff3) - (day3 * 24 * 60 * 60) - (hour3 * 60 * 60) - (minute3 * 60);
            }
            if (intDiff4 > 0) {
                day4 = Math.floor(intDiff4 / (60 * 60 * 24));
                hour4 = Math.floor(intDiff4 / (60 * 60)) - (day4 * 24);
                minute4 = Math.floor(intDiff4 / 60) - (day4 * 24 * 60) - (hour4 * 60);
                second4 = Math.floor(intDiff4) - (day4 * 24 * 60 * 60) - (hour4 * 60 * 60) - (minute4 * 60);
            }
            if (intDiff5 > 0) {
                day5 = Math.floor(intDiff5 / (60 * 60 * 24));
                hour5 = Math.floor(intDiff5 / (60 * 60)) - (day5 * 24);
                minute5 = Math.floor(intDiff5 / 60) - (day5 * 24 * 60) - (hour5 * 60);
                second5 = Math.floor(intDiff5) - (day5 * 24 * 60 * 60) - (hour5 * 60 * 60) - (minute5 * 60);
            }
            if (minute1 <= 9) minute1 = '0' + minute1;
            if (second1 <= 9) second1 = '0' + second1;
            if (minute2 <= 9) minute2 = '0' + minute2;
            if (second2 <= 9) second2 = '0' + second2;
            if (minute3 <= 9) minute3 = '0' + minute3;
            if (second3 <= 9) second3 = '0' + second3;
            if (minute4 <= 9) minute4 = '0' + minute4;
            if (second4 <= 9) second4 = '0' + second4;
            if (minute5 <= 9) minute5 = '0' + minute5;
            if (second5 <= 9) second5 = '0' + second5;
            $('#day_show1').html(day1);
            $('#hour_show1').html('<s id="h"></s>' + hour1);
            $('#minute_show1').html('<s></s>' + minute1);
            $('#second_show1').html('<s></s>' + second1);
            $('#day_show2').html(day2);
            $('#hour_show2').html('<s id="h"></s>' + hour2);
            $('#minute_show2').html('<s></s>' + minute2);
            $('#second_show2').html('<s></s>' + second2);
            $('#day_show3').html(day3);
            $('#hour_show3').html('<s id="h"></s>' + hour3);
            $('#minute_show3').html('<s></s>' + minute3);
            $('#second_show3').html('<s></s>' + second3);
            $('#day_show4').html(day4);
            $('#hour_show4').html('<s id="h"></s>' + hour4);
            $('#minute_show4').html('<s></s>' + minute4);
            $('#second_show4').html('<s></s>' + second4);
            $('#day_show5').html(day5);
            $('#hour_show5').html('<s id="h"></s>' + hour5);
            $('#minute_show5').html('<s></s>' + minute5);
            $('#second_show5').html('<s></s>' + second5);
            intDiff1--;
            intDiff2--;
            intDiff3--;
            intDiff4--;
            intDiff5--;
        }, 1000);
    }
    $(function() {
    var intDiff1 = parseInt($("#time1").val()); //倒计时总秒数量
    var intDiff2 = parseInt($("#time2").val()); //倒计时总秒数量
    var intDiff3 = parseInt($("#time3").val()); //倒计时总秒数量
    var intDiff4 = parseInt($("#time4").val()); //倒计时总秒数量
    var intDiff5 = parseInt($("#time5").val()); //倒计时总秒数量
    timer(intDiff1, intDiff2, intDiff3, intDiff4, intDiff5);
    }); 
</script>

<div class="left_focus borderB">
              <h3><img src="images/cuxiao.png" /></h3>
              <ul class="left_focuslist b_imglist">
                  <asp:Repeater ID="CuXiao" runat="server">
                  <ItemTemplate>
                  <li> <a href="/TuanGouXX.aspx?id=<%# Eval("ID")%>" class="cx_img"><img src="<%# Eval("ProductImg")%>" />
                      <div class="tuijian"></div>
                  </a>
                    <p class="cx_title"><a href="/TuanGouXX.aspx?id=<%# Eval("ID")%>"><%# Eval("ProductName")%></a></p>
                  <p><span class="sales"><em>¥<%# Convert.ToInt32(Eval("GroupPrice"))%></em>起</span><span class="rate-info">原价：<s>¥<%# Convert.ToInt32(Eval("MarketPrice"))%></s></span></p>
                </li>
                  </ItemTemplate>
                  </asp:Repeater>
              </ul>
              <a class="prev" href="javascript:void(0)"></a> <a class="next" href="javascript:void(0)"></a>
              <div class="num">
                <ul>
                </ul>
              </div>
            </div><div class="left_focus R_side01R">
              <h3><img src="images/miaosha.png" /></h3>
              <ul class="left_focuslist b_imglist">
              <asp:Repeater ID="MiaoSha" runat="server">
                <ItemTemplate>
                <li> <a href="/TuanGouXX.aspx?id=<%# Eval("ID")%>" class="cx_img"><img src="<%# Eval("ProductImg")%>" />
                      <p class="cx_title"><%# Eval("ProductName")%></p>
                  </a>
                    <p class="borderB"><span class="sales"><em>¥<%# Convert.ToInt32(Eval("GroupPrice"))%></em><span class="zhe"><%# GetZheKou(Eval("GroupPrice"),Eval("MarketPrice"))%>折</span></span><span class="rate-info">原价：<s>¥<%# Convert.ToInt32(Eval("MarketPrice"))%></s></span></p>
                    <input id="time<%# Container.ItemIndex+1 %>" type="hidden" value="<%# GetMiaoshu(Eval("ValiDate"))%>" />
                  <p>剩余时间：<font class="fontblue font14" id="day_show<%# Container.ItemIndex+1 %>">26</font> 天 <font class="fontblue font14" id="hour_show<%# Container.ItemIndex+1 %>">8</font> 时 <font class="fontblue font14" id="minute_show<%# Container.ItemIndex+1 %>">20</font> 分 <font class="fontblue font14" id="second_show<%# Container.ItemIndex+1 %>">1</font> 秒</p>
                </li>
                </ItemTemplate>
                </asp:Repeater>
              </ul>
              <a class="prev" href="javascript:void(0)"></a> <a class="next" href="javascript:void(0)"></a>
              <div class="num">
                <ul>
                </ul>
              </div>
            </div>                        <script type="text/javascript">
                /*鼠标移过，左右按钮显示*/
                $(".left_focus").hover(function() {
                    $(this).find(".prev,.next").fadeTo("show", 0.1);
                }, function() {
                    $(this).find(".prev,.next").hide();
                })
                /*鼠标移过某个按钮 高亮显示*/
                $(".prev,.next").hover(function() {
                    $(this).fadeTo("show", 0.7);
                }, function() {
                    $(this).fadeTo("show", 0.1);
                })
                $(".left_focus").slide({ titCell: ".num ul", mainCell: ".left_focuslist", effect: "fold", autoPlay: true, delayTime: 700, autoPage: true });
</script>
<!-- 代码 结束 -->