<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainDefault.ascx.cs" Inherits="EyouSoft.WAP.userControl.MainDefault" %>
<%@ Register Src="/userControl/ScrollImg.ascx" TagName="ScrollImg" TagPrefix="uc2" %>
<!--baner------------start-->
        <uc2:ScrollImg ID="ScrollImg1" runat="server" />
        <!--baner------------end-->
<nav id="nav" class="mt10">
          <ul class="nav_list">
              <li class="wid3" data-url ="/Line_List.aspx?type=1">
                <div class="nav_gn">
                   <h2>国内游</h2>
                   <p>旅行说走就走</p>
                </div>
              </li>

              <li class="wid3" data-url ="/Line_List.aspx?type=3">
                <div class="nav_zb">
                   <h2>周边游</h2>
                   <p>就近撒欢去</p>
                </div>
              </li>

              <li class="wid4" data-url ="/JingQu.aspx">
                <div class="nav_jq">
                   <h2>优惠门票</h2>
                   <p>1张起售，短信取票</p>
                </div>
              </li>
              
              <li class="wid3" data-url ="/Line_List.aspx?type=2">
                <div class="nav_cj">
                   <h2>出境游</h2>
                   <p>感受异域风情</p>
                </div>
              </li>

              <li class="wid4" data-url ="/EBao.aspx">
                <div class="nav_e">
                   <h2>E额宝</h2>
                   <p>安全快捷还增值</p>
                </div>
              </li>
              
              <li class="wid3" data-url ="/Hotel.aspx">
                <div class="nav_hotel">
                   <h2>酒店预订</h2>
                   <p>出行四海如家</p>
                </div>
              </li>
              
              <%--<li class="wid" data-url ="/Flight/Default.aspx">
                <div class="nav_jp">
                   <h2>高返机票</h2>
                   <p>省的就是赚的</p>
                </div>
              </li>--%>
              <li class="wid6" data-url ="/Flight/Default.aspx">
                <div class="nav_jp">
                   <h2>高返机票</h2>
                   <p>省的就是赚的</p>
                </div>
              </li>

              <li class="wid4" data-url ="/ZuTuanIndex.aspx">
                <div class="nav_zt">
                   <h2>单独组团</h2>
                   <p>人少也能独立成团</p>
                </div>
              </li>

              <li class="wid4" data-url="/CarList.aspx">
                <div class="nav_car">
                   <h2>客车包租</h2>
                   <p>带驾包车，智能计费</p>
                </div>
              </li>

              <li class="wid6" data-url="/Mall/Default.aspx">
                <div class="nav_mall">
                   <h2>商城联盟</h2>
                   <p>跨界互动，渠道倍增</p>
                </div>
              </li>

          </ul>
       </nav>


      
<asp:PlaceHolder ID="PlaceHolder1" runat="server">
      <!---秒杀----->
      <div class="cuxiao">
           <div class="cuxiao_t R_jiantou"><a href="/TuanGouList.aspx?type=1" class="floatR font16">更多</a><img src="images/miaosha.gif" /></div>
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
                           <dt><%# Eval("ProductName")%></dt>
                           <dd><i class="font_yellow">¥<em class="font18"><%# Convert.ToInt32(Eval("GroupPrice"))%></em></i></dd>
                           <dd class="txt"><i class="line_x font12">¥<%# Convert.ToInt32(Eval("MarketPrice"))%></i></dd>
                        </dl>
                    </div></a>
                 </li>
                 </ItemTemplate>
                </asp:Repeater> 
                 
                 
              </ul>
           </div>
      </div> 
</asp:PlaceHolder>      
<asp:PlaceHolder ID="PlaceHolder2" runat="server">
      <!---促销----->
      <div class="cuxiao">
           <div class="cuxiao_t R_jiantou"><a href="/TuanGouList.aspx?type=3" class="floatR font16">更多</a><img src="images/cuxiao.gif" /></div>
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
                           <dt><%# Eval("ProductName")%></dt>
                           <dd><i class="font_yellow">¥<em class="font18"><%# Convert.ToInt32(Eval("GroupPrice"))%></em></i></dd>
                           <dd class="txt"><i class="line_x font12">¥<%# Convert.ToInt32(Eval("MarketPrice"))%></i></dd>
                        </dl>
                    </div>
                    </a>
                 </li>
                  </ItemTemplate>
                  </asp:Repeater>
              </ul>
           </div>
      </div> 
</asp:PlaceHolder>      
      
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