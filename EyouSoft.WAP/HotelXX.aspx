<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelXX.aspx.cs" Inherits="EyouSoft.WAP.HotelXX" %>
<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<%@ Register Src="/userControl/ScrollImg.ascx" TagName="ScrollImg" TagPrefix="uc2" %>
<!doctype html>

<htm>
<head>
    <meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
 
<title>酒店详情</title>


<script src="js/jquery_cm.js" type="text/javascript"></script>
           
</head>
<body>
    <uc1:WapHeader runat="server" ID="WapHeader1" />
  
<div class="warp">
     
       <!--baner------------start-->
       <uc2:ScrollImg ID="ScrollImg1" runat="server" />
       <!--baner------------end-->
     
       
         <div class="jq_cont">
            <h2>
                <asp:Literal ID="HotelName" runat="server"></asp:Literal></h2>
            <p class="font13 font_gray mt10">
                星级：<asp:Literal ID="HotelStar" runat="server"></asp:Literal></p>
            <p class="font13 font_gray mt10">
                客服电话：<asp:Literal ID="KeFuTel" runat="server"></asp:Literal></p>
         </div>
         
         <div class="jq_cont mt10">
            <div class="h_txt"><a class="Rcont font_blue floatR" id="ckditu" href="javascript:void(0);">查看地图<i class="R_jiantou"></i></a>地址：<asp:Literal
                    ID="HotelAddress" runat="server"></asp:Literal></div>
         </div>

         <div class="jq_cont mt10">
            <div class="h_txt h_more"><a class="Rcont font_blue floatR" id="ckxiangq" href="javascript:void(0);">查看详情<i class="R_jiantou"></i></a><asp:Literal
                    ID="HotelJianJie" runat="server"></asp:Literal></div>
         </div>

         <div class="user_form h_form mt10">
            <ul>
               <li class="R_jiantou">
                  <span class="label_name"><s class="ico_ruzhu_date"></s>入住日期</span>
                  <input id="ruzhu" type="text" readonly="readonly" class="u-input" value="<%= ruzhutime%>">
               </li>
            </ul>
         </div>
         
         <div class="user_form h_form mt10">
            <ul>
               <li class="R_jiantou">
                  <span class="label_name"><s class="ico_ruzhu_date"></s>离店日期</span>
                  <input id="lidian" type="text" readonly="readonly" class="u-input" value="<%= lidiantime%>">
               </li>
            </ul>
         </div>
         <%= fangxin%>
    
  </div>
  <div class="datelist" style="display: none; padding-top:48px;  width:100%; height:100%; box-sizing:border-box;">
        <asp:Literal ID="litMonth" runat="server"></asp:Literal>
    </div>
    <input id="JiaoDian" type="hidden" />
</body>

<script type="text/javascript">
    $(".fx_name").click(function() {
        if ($(this).find("i").attr("class") == "add") {
            $(this).find("i").removeClass("add").addClass("minus");
        }
        else {
            $(this).find("i").removeClass("minus").addClass("add");
        }
        $(this).closest(".hotel_fx").find(".fx_more").toggle();
    });
    $("#ckditu").click(function() {
        window.location.href = "/BaiDuMap.aspx?jingdu=<%= Longitude%>&weidu=<%=Latitude %>&title=<%= HotelMing%>&Address=<%=Server.UrlEncode(Address) %>&mobile=<%=Server.UrlEncode(Mobile) %>";
    });
    $("#ckxiangq").click(function() {
        window.location.href = "/HotelJieShao.aspx?HotelId=<%= jiudianid%>";
    });

    $("#allmap").click(function() {
        $("#xinxi").toggle();
        $("#allmap").toggle();
    });
    
    $("#ruzhu").click(function() {
        $(".warp").toggle();
        $(".datelist").toggle();
        $('body,html').animate({ scrollTop: 0 }, 500);
        $("#JiaoDian").val("ruzhu");
    })
    $("#lidian").click(function() {
        $(".warp").toggle();
        $(".datelist").toggle();
        $('body,html').animate({ scrollTop: 0 }, 500);
        $("#JiaoDian").val("lidian");
    })
    
    $(".riqi_day_select").click(function() {
    $("#" + $("#JiaoDian").val()).val($(this).attr("data-date"));
    var hotelid = "<%= jiudianid%>";
    window.location.href = "/HotelXX.aspx?HotelId=" + hotelid + "&RuZhuRiQi=" + $("#ruzhu").val() + "&lidianriqi=" + $("#lidian").val();
        $(".warp").toggle();
        $(".datelist").toggle();
    })
    
    $(".yudin_btn").click(function() {
    var roomTypeId = $(this).attr("data-roomTypeId");
    var RoomRateIds = $(this).attr("data-RoomRateIds");
    window.location.href = "/HotelOrder.aspx?roomCount=1&roomTypeId=" + roomTypeId + "&checkInDate=" + $("#ruzhu").val() + "&checkOutDate=" + $("#lidian").val() + "&RoomRateIds=" + RoomRateIds;
    })
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
