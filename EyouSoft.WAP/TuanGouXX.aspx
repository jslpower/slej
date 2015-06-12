<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TuanGouXX.aspx.cs" Inherits="EyouSoft.WAP.TuanGouXX" %>
<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
 
<title>促销秒杀</title>

<script src="js/jq.mobi.min.js" type="text/javascript"></script>
<script type="text/javascript" src="js/slogin.js"></script>
<script type="text/javascript">
//var intDiff = parseInt(5);//倒计时总秒数量
function timer1(intDiff) {
    window.setInterval(function() {
        var day = 0,
        hour = 0,
        minute = 0,
        second = 0; //时间默认值        
        if (intDiff > 0) {
            day = Math.floor(intDiff / (60 * 60 * 24));
            hour = Math.floor(intDiff / (60 * 60)) - (day * 24);
            minute = Math.floor(intDiff / 60) - (day * 24 * 60) - (hour * 60);
            second = Math.floor(intDiff) - (day * 24 * 60 * 60) - (hour * 60 * 60) - (minute * 60);
        }
        else {
            $('#QGimg').removeClass().addClass("tg_ydbtn tg_ydbtn01");  
            $('#QGimg').html("<a>已结束</a>");
         }
        if (minute <= 9) minute = '0' + minute;
        if (second <= 9) second = '0' + second;
        $('#day_show').html(day);
        $('#hour_show').html('<s id="h"></s>' + hour);
        $('#minute_show').html('<s></s>' + minute);
        $('#second_show').html('<s></s>' + second);
        intDiff--;
    }, 1000);
}
$(function() {
var intDiff = parseInt(<%= TotalSeconds%>);//倒计时总秒数量
    timer1(intDiff);
}); 
    </script>
</head>

<body>

  <uc1:WapHeader runat="server" ID="WapHeader1" />
  
<div class="warp">
     
         <div class="car_banner">
            <asp:Literal ID="ProductImg" runat="server"></asp:Literal>
         </div>
     
       
         <div class="jq_cont gray_line">
            <h2><asp:Literal ID="ProductName" runat="server"></asp:Literal></h2>
            <p class="font13 font_gray mt10"><asp:Literal ID="ydbtn" runat="server"></asp:Literal><i class="line_x">¥ <asp:Literal ID="yuanjia" runat="server"></asp:Literal></i><span class="right_txt paddL">团购价：<i class="font_yellow">¥<em class="font18"> <asp:Literal ID="qianggoujia" runat="server"></asp:Literal></em></i></span></p>
            <p class="font13 font_gray mt10"><span class="floatR"><i class="font_yellow"> <asp:Literal ID="goumaishu" runat="server"></asp:Literal></i> 剩余<i class="font_yellow"><asp:Literal ID="shengyushu" runat="server"></asp:Literal></i></span>剩余时间：<b class="fontblue font_yellow" id="day_show">0</b> 天 <b class="fontblue font_yellow"
                            id="hour_show">0</b> 时 <b class="fontblue font_yellow" id="minute_show">00</b> 分
                        <b class="fontblue font_yellow" id="second_show">00</b> 秒</p>
         </div>
         

         <div class="jq_cont">
                <asp:Literal ID="jianjie" runat="server"></asp:Literal>
         </div>
         
         <h2 class="mall_title mt10">产品详情</h2>
         
         <div class="jq_xx_cont mall_tab">
                      <h3>产品说明：</h3>
                      <asp:Literal ID="jieshao" runat="server"></asp:Literal>
   
   </div>
</div>
  
</body>
<script type="text/javascript">
    var PageOrder = {
        Init: function() {
            var _m = iLogin.getM();
            if (!_m.isLogin) {
                $("#QGbtn").click(function() {
                window.location.href = '/Login.aspx?rurl=' + encodeURIComponent(window.location.href);
                });
            }
            else {
                $("#QGbtn").click(function() {
                    PageOrder.subit();
                });
            }
        },
        subit: function() {
            window.location.href = '/TuanGouTJ.aspx?id=<%=EyouSoft.Common.Utils.GetQueryStringValue("id") %>';
        },
        Bind: function() {
            PageOrder.Init();
        },
        boxClick: function() { PageOrder.subit(); }
    };




    $(function() {
        PageOrder.Bind();
    })

    function login(data) {
        $("#QGbtn").click(function() { PageOrder.subit(); });
    }
    </script>
    
    
    <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>

    <script type="text/javascript">
    var wx_jsapi_config=<%=weixin_jsapi_config %>;
    wx.config(wx_jsapi_config);
    </script>

    <script type="text/javascript">
        wx.ready(function() {
            //分享到朋友圈
            wx.onMenuShareTimeline({
                title: '<%=FenXiangBiaoTi %>',
                link: '<%= FenXiangLianJie %>',
                imgUrl: '<%=FenXiangTuPianFilepath %>'
            });
            //分享给朋友
            wx.onMenuShareAppMessage({
                title: '<%=FenXiangBiaoTi %>',
                desc: '<%=FenXiangMiaoShu %>',
                link: '<%= FenXiangLianJie %>',
                imgUrl: '<%=FenXiangTuPianFilepath %>',
                type: 'link'
            });
            //分享到QQ
            wx.onMenuShareQQ({
                title: '<%=FenXiangBiaoTi %>',
                desc: '<%=FenXiangMiaoShu %>',
                link: '<%= FenXiangLianJie %>',
                imgUrl: '<%=FenXiangTuPianFilepath %>'
            });
        });
    </script>
</html>