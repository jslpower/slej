<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DaiLiDefault.ascx.cs"
    Inherits="EyouSoft.WAP.userControl.DaiLiDefault" %>
    <%@ Register Src="/userControl/ScrollImg.ascx" TagName="ScrollImg" TagPrefix="uc2" %>
    
    <!--baner------------start-->
        <uc2:ScrollImg ID="ScrollImg1" runat="server" />
        <!--baner------------end-->
<asp:PlaceHolder ID="PlaceHolder1" runat="server">
<!---秒杀----->
<div class="cuxiao mt10">
    <div class="cuxiao_t R_jiantou">
        <a href="/TuanGouList.aspx?type=1" class="floatR font16">更多</a><img src="images/miaosha.gif" /></div>
    <div class="mall_list">
        <ul class="clearfix">
            <asp:Repeater ID="MiaoSha" runat="server">
                <ItemTemplate>
                    <li><a href="/TuanGouXX.aspx?id=<%# Eval("ID")%>">
                        <div class="img_box">
                            <img src="<%# EyouSoft.Common.TuPian.F1(Eval("ProductImg").ToString(), 640, 200)%>" />
                            <div class="car_banner_txt">
                                剩余:<i class="font_time" id="day_show<%# Container.ItemIndex+1 %>">0</i>天<i class="font_time" id="hour_show<%# Container.ItemIndex+1 %>">0</i>时<i class="font_time" id="minute_show<%# Container.ItemIndex+1 %>">0</i>分<i class="font_time" id="second_show<%# Container.ItemIndex+1 %>">0</i>秒</div>
                        </div>
                        <input id="time<%# Container.ItemIndex+1 %>" type="hidden" value="<%# GetMiaoshu(Eval("ValiDate"))%>" />
                        <div class="txt_box">
                            <dl>
                                <dt>
                                    <%# Eval("ProductName")%></dt>
                                <dd>
                                    <i class="font_yellow">¥<em class="font18"><%# Convert.ToInt32(Eval("GroupPrice"))%></em></i></dd>
                                <dd class="txt">
                                    <i class="line_x font12">¥<%# Convert.ToInt32(Eval("MarketPrice"))%></i></dd>
                            </dl>
                        </div>
                    </a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
</asp:PlaceHolder>
<asp:PlaceHolder ID="PlaceHolder2" runat="server">
<!---促销----->
<div class="cuxiao">
    <div class="cuxiao_t R_jiantou">
        <a href="/TuanGouList.aspx?type=3" class="floatR font16">更多</a><img src="images/cuxiao.gif" /></div>
    <div class="mall_list">
        <ul class="clearfix">
            <asp:Repeater ID="CuXiao" runat="server">
                <ItemTemplate>
                    <li><a href="/TuanGouXX.aspx?id=<%# Eval("ID")%>">
                        <div class="img_box">
                            <img src="<%# EyouSoft.Common.TuPian.F1(Eval("ProductImg").ToString(), 640, 200)%>" />
                        </div>
                        <div class="txt_box">
                            <dl>
                                <dt>
                                    <%# Eval("ProductName")%></dt>
                                <dd>
                                    <i class="font_yellow">¥<em class="font18"><%# Convert.ToInt32(Eval("GroupPrice"))%></em></i></dd>
                                <dd class="txt">
                                    <i class="line_x font12">¥<%# Convert.ToInt32(Eval("MarketPrice"))%></i></dd>
                            </dl>
                        </div>
                    </a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
</asp:PlaceHolder>
<!---热销----->
<div class="cuxiao">
    <div class="cuxiao_t R_jiantou">
        <a href="/Mall/Default.aspx" class="floatR font16">更多</a><img src="images/hot.gif" /></div>
    <div class="mall_list">
        <ul class="clearfix">
            <asp:Repeater ID="rpt_HuiYuanShopping" runat="server">
                <ItemTemplate>
                    <li><a href="/Mall/MoDetail.aspx?id=<%#  Eval("ProductID") %>">
                        <div class="img_box">
                            <img src="<%# getImgs(Eval("ProductImgs")) %>" /></div>
                        <div class="txt_box">
                            <dl>
                                <dt>
                                    <%# Eval("ProductName")%></dt>
                                <dd>
                                    <i class="line_x"><%#  Eval("MarketPrice", "{0:C0}")%></i></dd>
                                <dd class="txt">
                                    <i class="font_yellow">¥<%# EyouSoft.Common.UtilsCommons.GetGYStijia(EyouSoft.Model.Enum.FeeTypes.商城,  (decimal)Eval("SalePrice"),(decimal)Eval("MarketPrice"), EyouSoft.Model.Enum.MemberTypes.普通会员).ToString("F0")%></i></dd>
                            </dl>
                        </div>
                        </a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
     <div class="paddB paddL paddR">
        <a href="/Mall/ModList.aspx?t=1"><div class="y_btn">
            查看所有宝贝 ></div></a>
    </div>
 </div>   
<div class="fx_nav_tab" id="n4Tab">
          
          <div class="fx_nav_TabTitle">
              <ul class="clearfix">
                <li id="n4Tab_Title1" onClick="nTabs('n4Tab',this,1);" class="active">旅行度假</li>
                <li id="n4Tab_Title0" onClick="nTabs('n4Tab',this,0);" class="normal">商务差旅</li>
                <li id="n4Tab_Title2" onClick="nTabs('n4Tab',this,2);" class="normal" data-url="/EBao.aspx">E 额 宝</li>
                <li id="n4Tab_Title3" onClick="nTabs('n4Tab',this,3);" class="normal" data-url="/Mall/Default.aspx">E家商城</li>
              </ul>
          </div>
          
          <div class="fx_nav_TabContent">
            
                <div id="n4Tab_Content0" class="none">
                   <ul class="clearfix">
                       <li><a href="/Flight/Default.aspx">机票预订</a></li>
                       <li><a href="/Hotel.aspx">酒店预订</a></li>
                       <li><a href="/CarList.aspx">客车包租</a></li>
                   </ul>
                </div>
 
                 <div id="n4Tab_Content1">
                   <ul class="clearfix">
                       <li><a href="/JingQu.aspx">特价门票</a></li>
                       <li><a href="/Line_List.aspx?type=3">周边旅游</a></li>
                       <li><a href="/Line_List.aspx?type=1">国内旅游</a></li>
                       <li><a href="/Line_List.aspx?type=2">出境旅游</a></li>
                       <li><a href="/ZuTuanIndex.aspx">单独组团</a></li>
                   </ul>
                </div>

                <%--<div id="n4Tab_Content2" class="none">
                       <li><a href="">特价门票</a></li>
                       <li><a href="">出境旅游</a></li>
                       <li><a href="">单独组团</a></li>
                </div>

                <div id="n4Tab_Content3" class="none">
                       <li><a href="">特价门票</a></li>
                       <li><a href="">出境旅游</a></li>
                       <li><a href="">单独组团</a></li>
                </div>--%>
               
          </div>
          
       </div>

<script type="text/javascript">
    function nTabs(tabObj, obj, num) {
        var tabList = document.getElementById(tabObj).getElementsByTagName("li");
        if (num < 2) {
            for (i = 0; i < tabList.length; i++) {
                if (i == num) {
                    $("#" + tabObj + "_Title" + i).removeClass("normal").addClass("active");
                    $("#" + tabObj + "_Content" + i).css("display", "block");
                } else {
                    $("#" + tabObj + "_Title" + i).removeClass("active").addClass("normal");
                    $("#" + tabObj + "_Content" + i).css("display", "none");
                }
            }
        }
        else {
            var url = $("#" + tabObj + "_Title" + num).attr("data-url");
            window.location.href = url;
        }
    }
</script>
<script type="text/javascript">
    //var intDiff = parseInt(5);//倒计时总秒数量
    function timer(intDiff1, intDiff2) {
        window.setInterval(function() {
            var day1 = 0,
        hour1 = 0,
        minute1 = 0,
        second1 = 0; //时间默认值
            var day2 = 0,
        hour2 = 0,
        minute2 = 0,
        second2 = 0; //时间默认值      
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
            if (minute1 <= 9) minute1 = '0' + minute1;
            if (second1 <= 9) second1 = '0' + second1;
            if (minute2 <= 9) minute2 = '0' + minute2;
            if (second2 <= 9) second2 = '0' + second2;
            $('#day_show1').html(day1);
            $('#hour_show1').html('<s id="h"></s>' + hour1);
            $('#minute_show1').html('<s></s>' + minute1);
            $('#second_show1').html('<s></s>' + second1);
            $('#day_show2').html(day2);
            $('#hour_show2').html('<s id="h"></s>' + hour2);
            $('#minute_show2').html('<s></s>' + minute2);
            $('#second_show2').html('<s></s>' + second2);
            intDiff1--;
            intDiff2--;
        }, 1000);
    }
    $(function() {
        var intDiff1 = parseInt($("#time1").val()); //倒计时总秒数量
        var intDiff2 = parseInt($("#time2").val()); //倒计时总秒数量
        timer(intDiff1, intDiff2);
    }); 
</script>
 <script type="text/javascript">
        $(function() {
            $(".wid").click(function() {
            var url = $(this).attr("data-url");
                window.location.href = url;
            });
            $(".wid4").click(function() {
                var url = $(this).attr("data-url");
                window.location.href = url;
            });
            $(".wid6").click(function() {
                var url = $(this).attr("data-url");
                window.location.href = url;
            });
            $(".wid3").click(function() {
                var url = $(this).attr("data-url");
                window.location.href = url;
            });
        })
    </script>

