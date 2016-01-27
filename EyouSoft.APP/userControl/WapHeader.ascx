<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WapHeader.ascx.cs" Inherits="EyouSoft.WAP.userControl.WapHeader" %>
<link href="/css/Style.css?v20150625" rel="stylesheet" type="text/css" media="screen" />
<link href="../css/iconfont.css" rel="stylesheet" type="text/css" />
<header>
<%if (iscd)
  { %>
   <a id="back_btn_a" href="javascript:window.history.go(-1);"><i class="returnico"></i></a>
  <%} %>
   
    <h1><%=this.HeadText %></h1>
    <%if (iscd)
  { %>
    <a id="menus" href="javascript:void(0);"><b class="icon_home"></b></a>
      <%} %>
  </header>
<div data-div="head_div" class="head_div" style="display: none;">
    <div class="head_box">
        <ul>
            <li><i class="icon-tel"></i><a href="tel:<%= TelNum%>">联系电话</a></li>
            <li><i class="icon-back"></i><a href="/default.aspx">返回首页</a></li>
            <li><i class="icon-user"></i><a href="/Member/UserCenter.aspx">后台管理</a></li>
            <%if (isLogin)
              { %>
            <li><i class="icon-update"></i><a href="/Login.aspx">注册登录</a></li>
            <%} %>
            <%if (isfx)
              { %>
            <li><i class="icon-fenxiang"></i><a href="javascript:void(0);" id="afx">微信分享</a></li>
            <%} %>
            <li><i class="icon-back"></i><a href="javascript:location.reload();">刷新页面</a></li>
        </ul>
    </div>
</div>

<script type="text/javascript">
    var loading ={
        init: function() {
            $("#menus").click(function() {
                $("div[data-div=head_div]").toggle();
            });
            $("#afx").click(function() {
                $("div[data-div=head_fenxiang]").toggle();
            });
            $(".fxquxiao").click(function() {
                $("div[data-div=head_fenxiang]").toggle();
            });
        }
    }
    $(function() {
        //初始化
        loading.init();
       
    });
</script>


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
        <div class="item mt10 radius4 fxquxiao">
            取消</div>
    </div>
</div>
<!-----分享--------->
<script type="text/javascript">
    var fxPublic = {
        ShareSDKAppKey: '68c674555f80',
        WeiXinAppId: 'wx23b4841aaff3ad7e',
        WeiXinAppSecret: '75f1353f873294696b1d61588b92d8bd',
        fximgUrl: '<%=FenXiangTuPianFilepath %>',
        ShareTitle: '<%=FenXiangMiaoShu %>',
        ShareDescription: '<%=FenXiangMiaoShu %>',
        fxwebpageUrl: '<%=FenXiangLianJie %>'
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