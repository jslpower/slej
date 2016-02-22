<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yaoqing.aspx.cs" Inherits="EyouSoft.WAP.yaoqing" %>

<!DOCTYPE html>

<html>
<head runat="server">
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
 
<title>邀请</title>
<link rel="stylesheet" href="css/style.css" type="text/css" media="screen" />
 <script src="/js/jq.mobi.min.js" type="text/javascript"></script>
<style type="text/css">
.yaoqing_box{ background:#fff;padding:10px;}
</style>
</head>
<body>
    <form id="form1" runat="server">
  <header>
    
    <h1>邀请</h1>
    
  </header>
  
  <div class="warp">
      <% if (!string.IsNullOrEmpty(EyouSoft.Common.Utils.GetQueryStringValue("uid")))
         { %>
      <div class="padd10">
          <div class="yaoqing_box radius4">
               <p>请先复制邀请码。</p><p></p><p></p>
               <p class="paddB">邀请码：<span class="font_yellow"><input type="text" readonly style="border:none; vertical-align:middle; background:#fff;"  class="font_yellow" id="liteyqm" runat=server></span></p>
                <!--<p style="border-bottom:solid 1px #ccc;" class="paddB">邀请网址：<span class="font_yellow"><input type="text" readonly style="border:none; vertical-align:middle; background:#fff;"  class="font_yellow" id="txturl" runat=server></span></p><p></p><p></p>-->
               <p class="paddT"><a href="javascript:void(0);" id="aXiaZai" class="y_btn radius4">复制邀请码后点击安装</a></p>
               <p class="paddT">下载安装步骤说明：</p>
               <p class="paddT">1、长按选择邀请码，并选择“拷贝”操作：</p>
               <p class="paddT"><img src="images/MobileCpStep1.jpg" border="0" width="80%"></p>
               <p class="paddT">2、点击“复制邀请码后点击安装”进行APP下载</p>
               <p class="paddT">3、安装下载后的APP</p>
          </div>
      </div>
<%}else{ %>
<div class="padd10">
          <div class="yaoqing_box radius4">
            
               <p class="paddT"><a href="javascript:void(0);" id="aXiaZai" class="y_btn radius4">立即安装</a></p>               
          </div>
      </div>
<%} %>
  </div>
    </form>
    <script type="text/javascript">
        var pageload = {
            isbol: false,
            GetApkdow: function() {
            if (pageload.isbol) {
                    <% if(Request.UserAgent.ToLower().Contains("micromessenger")){ %>
                    alert('请通过微信菜单打开浏览器');
                    <%} %>
                    location.href = "http://m.slej.cn/jinao.apk";
                }
                else {
                    alert("IOS版尚在开发中，即将跳转到网页版!");
                    location.href = "http://<%= yuMing%>";
                }

            }
        }
        $(function() {
            var u = navigator.userAgent;
            if (u.indexOf('Android') > -1 || u.indexOf('Linux') > -1) {//安卓手机
                pageload.isbol = true;
                // window.location.href = "mobile/index.html";
            } else if (u.indexOf('iPhone') > -1) {//苹果手机
                // window.location.href = "mobile/index.html";
                pageload.isbol = false;
            }
            $("#aXiaZai").click(function() {
                pageload.GetApkdow();
            });
            //else if (u.indexOf('Windows Phone') > -1) {//winphone手机
            //alert("winphone手机");
            // window.location.href = "mobile/index.html";
            //}

        })
    </script>
</body>
</html>
