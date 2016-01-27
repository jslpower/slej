<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yaoqing.aspx.cs" Inherits="EyouSoft.WebApp.yaoqing" %>
<%@ Register Src="/userControl/WapHeader.ascx" TagName="WapHeader" TagPrefix="uc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
 
<title>邀请</title>
<link rel="stylesheet" href="css/style.css" type="text/css" media="screen" />
 <script src="/js/jq.mobi.min.js" type="text/javascript"></script>
 <script type="text/javascript" src="cordova.js"></script>
    <script type="text/javascript" src="js/enow.core.js"></script>
<style type="text/css">
.yaoqing_box{ background:#fff;padding:10px;}
</style>
</head>
<body>
    <form id="form1" runat="server">
 <uc1:WapHeader runat="server" ID="WapHeader1" />
  
  <div class="warp">
  
      <div class="padd10">
          <div class="yaoqing_box radius4">
               <p style="border-bottom:solid 1px #ccc;" class="paddB">邀请码：<span class="font_yellow"><asp:Literal runat="server" ID="liteyqm"></asp:Literal></span></p>
               <p class="paddT"><a href="javascript:void(0);" id="aXiaZai" class="y_btn radius4">立即分享</a></p>
          </div>
      </div>

  </div>
    </form>
    <!-----分享--------->
<div class="user-mask" data-div="head_fenxiang" style="display: none;" id="fenxiang">
    <div class="fenxiang-tx">
        <div class="fx_menu radius4">
            <ul>
                <li onclick="ipage.weixinhaoyoushare()">
                    <img src="../images/fx_weixin.png"><p>
                        发送给微信好友</p>
                </li>
                <li onclick="ipage.weixinpengyoushare()">
                    <img src="../images/fx_pengyouquan.png"><p>
                        分享到朋友圈</p>
                </li>
            </ul>
        </div>
        <div class="item mt10 radius4 Appfxquxiao">
            取消</div>
    </div>
</div>
<script type="text/javascript">
    var Apploading = {
        init: function() {
          
            $("#aXiaZai").click(function() {
                $("div[data-div=head_fenxiang]").toggle();
            });
            $(".Appfxquxiao").click(function() {
                $("div[data-div=head_fenxiang]").toggle();
            });
        }
    }
    $(function() {
        //初始化
        Apploading.init();

    });
</script>
<!-----分享--------->
<script type="text/javascript">
    var fxPublic = {
        ShareSDKAppKey: '68c674555f80',
        WeiXinAppId: 'wx23b4841aaff3ad7e',
        WeiXinAppSecret: '75f1353f873294696b1d61588b92d8bd',
        fximgUrl: 'http://p.slej.cn/images/logo.jpg',
        ShareTitle: '安装商旅e家',
        ShareDescription: '安装商旅e家',
        fxwebpageUrl: 'http://m.slej.cn/yaoqing.aspx?uid=<%=uid %>'
    }
    //分享Start
    function shareinit() {
        $sharesdk.open(fxPublic.ShareSDKAppKey, true);
        var wxConf = {};
        wxConf["app_key"] = fxPublic.WeiXinAppId;
        wxConf["app_secret"] = fxPublic.WeiXinAppSecret;
        //            wxConf["redirect_uri"] = window.location.href;
        $sharesdk.setPlatformConfig($sharesdk.platformID.WeChatSession, wxConf);
        $sharesdk.setPlatformConfig($sharesdk.platformID.WeChatTimeline, wxConf);
    };

    var ipage = {
        shareoption: { webpageUrl: fxPublic.fxwebpageUrl, title: fxPublic.ShareTitle, description: fxPublic.ShareDescription, imgUrl: fxPublic.fximgUrl },
        shareonsuccess: function(result) {
            var _s = JSON.stringify(result);
            console.log(_s);

            //                ipage.ShowMsg(result.xiaoxi);
        },
        shareonerror: function(message) {
            console.log('分享错误信息：' + message);
        },
        weixinhaoyoushare: function() {

            //注：options.imgUrl指定的图片大小不能超过32KB，否则分享将会不成功
            //var _options = {webpageUrl:"http://www.enowinfo.com",title:"我是分享的标题2",description:"我是分享的内容2",imgUrl:"http://a.hiphotos.baidu.com/baike/s%3D220/sign=670fbb9e7e1ed21b7dc929e79d6fddae/8326cffc1e178a82599a55ccf503738da977e83c.jpg"};
            window.eNow.fenXiang.weiXin.haoYou(ipage.shareonsuccess, ipage.shareonerror, ipage.shareoption);
        },
        weixinpengyoushare: function() {

            //注：options.imgUrl指定的图片大小不能超过32KB，否则分享将会不成功
            //var _options = {webpageUrl:"http://www.baidu.com",title:"我是分享的标题1",description:"我是分享的内容1",imgUrl:"http://www.baidu.com/img/baidu_jgylogo3.gif"};

            window.eNow.fenXiang.weiXin.pengYouQuan(ipage.shareonsuccess, ipage.shareonerror, ipage.shareoption);
        }
    }
</script>
</body>
</html>
