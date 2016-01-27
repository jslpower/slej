<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetShop.aspx.cs" Inherits="EyouSoft.WAP.SetShop" %>
<%@ Register Src="userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
 
<title>选择网店模式</title>
<link rel="stylesheet" href="/css/style.css" type="text/css" media="screen">
<link rel="stylesheet" href="/css/weidian.css" type="text/css" media="screen">
<script src="/js/jquery-1.7.1.min.js" type="text/javascript"></script>
</head>

<body>
  <uc1:WapHeader ID="WapHeader2" runat="server" HeadText="请选择网店形式" />
  
  <div class="warp">
    
      <div class="car_banner"><img src="images/weidian_banner.jpg"></div>
      
      <div class="padd10 cent font16 font_yellow" style="background:#fff;">提示：您的专卖店网站生成，
请选择网站形式</div>
     
      
      <div class="wangdian_check">
              <ul>
                 <li>
                    <div class="item"><a data-div="lywd" href="javascript:void(0);" class="check_on"><span class="title">暂无产品，先开旅行社联营网站</span><em></em></a></div>
                 </li>
                 
                 <li>
                    <div class="item"><a data-div="zywd" href="javascript:void(0);"><span class="title">我有产品，要开专卖店联营网站</span><em></em></a></div>
                 </li>
              </ul>
      </div>
          
      <div class="div_img" id="lywd" style=" height:2656;display:block; visibility:visible;">
                      <p><img src="/images/wap_img.jpg"></p>
                      <p><img src="/images/pc_img.jpg"></p>
      </div>

      <div class="div_img" id="zywd" style=" height:0px;display:block; visibility:hidden;">
                      <p><img src="/images/wap_img1.jpg"></p>
                      <p><img src="/images/pc_img1.jpg"></p>
      </div>


    
  </div>
  <form id="form1">
  
  <input id="ShopType" name="ShopType" type="hidden" value="0" />
<div class="pay mt10">
    <div class="paddL paddR">
        <div class="pay_box" style="background:#E4E4E4 ;">
            <a id="btn" href="javascript:void(0);" class="y_btn">保  存</a>
        </div>
    </div>
</div>
</form>  
</body>
<script type="text/javascript">
    var CardNum = "<%= CardNum%>";
    $("a[data-div=zywd]").click(function() {
        //320  2575专营店
        //320  2656连营店
        //$(this).closest("li").css("height", "3300px");
        var winwid = $(window).width();
        var imgwid = 320;
        var imghei = 2656;
        var winhei = Number(winwid) / Number(imgwid) * Number(imghei);
        $(this).addClass("check_on");
        $("#ShopType").val("1");
        $("a[data-div=lywd]").removeClass("check_on");
        $('#lywd').css("height", "0px");
        $('#zywd').css("height", winhei + "px");
        $("#zywd").css("visibility", "visible");
        $("#lywd").css("visibility", "hidden");
    });
    $("a[data-div=lywd]").click(function() {
        //$(this).closest("li").css("height", "3300px");
        var winwid = $(window).width();
        var imgwid = 320;
        var imghei = 2575;
        var winhei = Number(winwid) / Number(imgwid) * Number(imghei);
        $(this).addClass("check_on");
        $("#ShopType").val("0");
        $("a[data-div=zywd]").removeClass("check_on");
        $('#zywd').css("height", "0px");
        $('#lywd').css("height", winhei + "px");
        $("#zywd").css("visibility", "hidden");
        $("#lywd").css("visibility", "visible");
    });
    $("#btn").click(function() {
        var type = $("#ShopType").val();
        if (type == "0") {
            if (window.confirm("您确认选择旅行社联营网站？")) {
                window.location = "/ShenQingSuccess.aspx?cardid=" + CardNum + "&ShopType=" + type;
                
            }
        }
        else {
            if (window.confirm("您确认选择专卖店联营网站？")) {
                window.location = "/ShenQingSuccess.aspx?cardid=" + CardNum + "&ShopType=" + type;
            }
        }
    });
</script>
</html>


