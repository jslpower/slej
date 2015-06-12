<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZuTuanIndex.aspx.cs" Inherits="EyouSoft.WAP.ZuTuanIndex" %>
<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
 
<title>单独组团</title>

<link rel="stylesheet" href="/css/zt.css" type="text/css" media="screen">
<script src="/js/jq.mobi.min.js" type="text/javascript"></script>


</head>

<body>

  <uc1:WapHeader runat="server" ID="WapHeader1" />
  
  <div class="warp">
      
       <div class="car_banner">
          <img src="images/zt_img.jpg">
       </div>
       
       <div class="jq_cont">
            <div><img src="images/zt_t1.png"></div>
            <div class="indent paddT">独立享受旅游相关服务，不必跟不相关的人在一起，避免尴尬，尊享自在！</div>
       </div>
       
       <div class="jq_cont mt10">
            <div><img src="images/zt_t2.png"></div>
            <div class="indent paddT">选择线路 —＞单独组团报价—＞输入成团人数—＞选择加餐标准、意外保险、接机送站、全陪导游等特殊要求，系统自动计算单独组团出游价格！</div>
            <div class="indent paddT">以下单独组团报价是在不减少行程内容的情况下，根据人数和客户需求，在拼团价格基础上进行合理调整之后的总价格。</div>
       </div>
       
  </div>

  <div class="zt_foot">
     <div class="zt_foot_box">
         <ul>
            <li class="gotozutuan" data-url="/Line_List.aspx?type=3">周边旅游</li>
            <li class="gotozutuan" data-url="/Line_List.aspx?type=1">国内旅游</li>
            <li class="gotozutuan" data-url="/Line_List.aspx?type=2">出境旅游</li>
         </ul>
     </div>
  </div>

  
  
</body>
<script type="text/javascript">
    $(".gotozutuan").click(function() {
        var url = $(this).attr("data-url");
        window.location.href = url;
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
